using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using QuanLyCafePOS.Data;
using QuanLyCafePOS.UI;

namespace QuanLyCafePOS.UI.Controls
{
    public partial class CustomerControl : UserControl
    {
        private int selectedId;
        private bool dataLoaded;

        public CustomerControl()
        {
            InitializeComponent();
            txtSearch.PlaceholderTextCompat("Tìm tên hoặc số điện thoại...");
            CafeTheme.StyleGrid(grid);
            grid.CellFormatting += Grid_CellFormatting;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!IsInDesignMode() && !dataLoaded)
            {
                LoadData();
                dataLoaded = true;
            }
        }

        private bool IsInDesignMode()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode;
        }

        private void BtnAdd_Click(object sender, EventArgs e) { AddCustomer(); }
        private void BtnUpdate_Click(object sender, EventArgs e) { UpdateCustomer(); }
        private void BtnDelete_Click(object sender, EventArgs e) { DeleteCustomer(); }
        private void BtnReload_Click(object sender, EventArgs e) { LoadData(); }
        private void BtnClear_Click(object sender, EventArgs e) { ClearForm(); }
        private void TxtSearch_TextChanged(object sender, EventArgs e) { if (dataLoaded) LoadData(); }

        private void LoadData()
        {
            try
            {
                string kw = txtSearch == null ? string.Empty : txtSearch.Text.Trim();
                DataTable data = Db.Query(@"SELECT MaKH, HoTen AS [Khách hàng], SDT AS [SĐT], ISNULL(SoLanMua,0) AS [Số lần mua],
                                                   ISNULL(DiemTichLuy,0) AS [Điểm], ISNULL(TongChiTieu,0) AS [Tổng chi tiêu],
                                                   CASE WHEN ISNULL(SoLanMua,0) >= 5 THEN N'Thân thiết - giảm 5%' ELSE N'Thường' END AS [Hạng],
                                                   GhiChu AS [Ghi chú]
                                            FROM dbo.KhachHang
                                            WHERE @kw=N'' OR HoTen LIKE N'%' + @kw + N'%' OR SDT LIKE N'%' + @kw + N'%'
                                            ORDER BY SoLanMua DESC, TongChiTieu DESC, HoTen", Db.P("@kw", kw));
                grid.DataSource = data;
                if (grid.Columns.Contains("MaKH")) grid.Columns["MaKH"].Width = 65;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải khách hàng: " + ex.Message);
            }
        }

        private void AddCustomer()
        {
            if (!ValidateInput()) return;
            Db.Execute(@"INSERT INTO dbo.KhachHang(HoTen, SDT, SoLanMua, DiemTichLuy, TongChiTieu, GhiChu)
                         VALUES(@HoTen, @SDT, 0, 0, 0, @GhiChu)",
                Db.P("@HoTen", txtName.Text.Trim()),
                Db.P("@SDT", string.IsNullOrWhiteSpace(txtPhone.Text) ? (object)DBNull.Value : txtPhone.Text.Trim()),
                Db.P("@GhiChu", txtNote.Text.Trim()));
            ClearForm();
            LoadData();
        }

        private void UpdateCustomer()
        {
            if (selectedId <= 0)
            {
                MessageBox.Show("Chọn khách hàng cần sửa.");
                return;
            }
            if (!ValidateInput()) return;
            Db.Execute(@"UPDATE dbo.KhachHang
                         SET HoTen=@HoTen, SDT=@SDT, GhiChu=@GhiChu
                         WHERE MaKH=@MaKH",
                Db.P("@HoTen", txtName.Text.Trim()),
                Db.P("@SDT", string.IsNullOrWhiteSpace(txtPhone.Text) ? (object)DBNull.Value : txtPhone.Text.Trim()),
                Db.P("@GhiChu", txtNote.Text.Trim()),
                Db.P("@MaKH", selectedId));
            ClearForm();
            LoadData();
        }

        private void DeleteCustomer()
        {
            if (selectedId <= 0)
            {
                MessageBox.Show("Chọn khách hàng cần xóa.");
                return;
            }

            int used = Convert.ToInt32(Db.Scalar("SELECT COUNT(*) FROM dbo.HoaDon WHERE MaKH=@id", Db.P("@id", selectedId)));
            if (used > 0)
            {
                MessageBox.Show("Khách hàng này đã có hóa đơn nên không xóa để giữ lịch sử mua hàng.");
                return;
            }

            if (MessageBox.Show("Xóa khách hàng này khỏi database?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Db.Execute("DELETE FROM dbo.KhachHang WHERE MaKH=@id", Db.P("@id", selectedId));
                ClearForm();
                LoadData();
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Nhập tên khách hàng.");
                return false;
            }
            return true;
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = grid.Rows[e.RowIndex];
            selectedId = Convert.ToInt32(row.Cells["MaKH"].Value);
            txtName.Text = Convert.ToString(row.Cells["Khách hàng"].Value);
            txtPhone.Text = Convert.ToString(row.Cells["SĐT"].Value);
            txtNote.Text = Convert.ToString(row.Cells["Ghi chú"].Value);
            lblSelected.Text = "Đang chọn: " + txtName.Text + " (mã " + selectedId + ")";
        }

        private void Grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            CafeTheme.FormatMoneyCell(grid, e);
        }

        private void ClearForm()
        {
            selectedId = 0;
            txtName.Clear();
            txtPhone.Clear();
            txtNote.Clear();
            lblSelected.Text = "Chưa chọn khách hàng";
        }
    }
}
