using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using QuanLyCafePOS.Data;
using QuanLyCafePOS.UI;

namespace QuanLyCafePOS.UI.Controls
{
    public partial class TableControl : UserControl
    {
        private int selectedId;
        private bool dataLoaded;

        public TableControl()
        {
            InitializeComponent();
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

        private void BtnAdd_Click(object sender, EventArgs e) { AddItem(); }
        private void BtnUpdate_Click(object sender, EventArgs e) { UpdateItem(); }
        private void BtnDelete_Click(object sender, EventArgs e) { DeleteItem(); }
        private void BtnReset_Click(object sender, EventArgs e) { ResetTable(); }
        private void BtnReload_Click(object sender, EventArgs e) { LoadData(); }

        private void LoadData()
        {
            try
            {
                DataTable data = Db.Query(@"SELECT MaBan, TenBan AS [Tên bàn], KhuVuc AS [Khu vực],
                                                   CASE TrangThai WHEN N'Trống' THEN N'Trống' WHEN N'Đang phục vụ' THEN N'Đang phục vụ' WHEN N'Đặt trước' THEN N'Đặt trước' ELSE TrangThai END AS [Trạng thái],
                                                   SoNguoi AS [Số người], ThoiGianVao AS [Thời gian vào]
                                            FROM dbo.BanCafe ORDER BY MaBan");
                grid.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải bàn: " + ex.Message);
            }
        }

        private void AddItem()
        {
            int people;
            if (!ValidateInput(out people)) return;
            Db.Execute(@"INSERT INTO dbo.BanCafe(TenBan, KhuVuc, TrangThai, SoNguoi, ThoiGianVao)
                         VALUES(@TenBan, @KhuVuc, @TrangThai, @SoNguoi, CASE WHEN @TrangThai=N'Đang phục vụ' THEN GETDATE() ELSE NULL END)",
                Db.P("@TenBan", txtName.Text.Trim()),
                Db.P("@KhuVuc", txtArea.Text.Trim()),
                Db.P("@TrangThai", StatusValue(cboStatus.Text)),
                Db.P("@SoNguoi", people));
            ClearForm();
            LoadData();
        }

        private void UpdateItem()
        {
            if (selectedId <= 0)
            {
                MessageBox.Show("Chọn bàn cần sửa.");
                return;
            }
            int people;
            if (!ValidateInput(out people)) return;
            string status = StatusValue(cboStatus.Text);
            Db.Execute(@"UPDATE dbo.BanCafe
                         SET TenBan=@TenBan, KhuVuc=@KhuVuc, TrangThai=@TrangThai, SoNguoi=@SoNguoi,
                             ThoiGianVao=CASE WHEN @TrangThai=N'Đang phục vụ' THEN ISNULL(ThoiGianVao, GETDATE()) ELSE NULL END
                         WHERE MaBan=@MaBan",
                Db.P("@TenBan", txtName.Text.Trim()),
                Db.P("@KhuVuc", txtArea.Text.Trim()),
                Db.P("@TrangThai", status),
                Db.P("@SoNguoi", people),
                Db.P("@MaBan", selectedId));
            ClearForm();
            LoadData();
        }

        private void DeleteItem()
        {
            if (selectedId <= 0)
            {
                MessageBox.Show("Chọn bàn cần xóa.");
                return;
            }
            if (MessageBox.Show("Xóa bàn này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Db.Execute("DELETE FROM dbo.BanCafe WHERE MaBan=@id", Db.P("@id", selectedId));
                ClearForm();
                LoadData();
            }
        }

        private void ResetTable()
        {
            if (selectedId <= 0)
            {
                MessageBox.Show("Chọn bàn cần trả về trạng thái trống.");
                return;
            }
            Db.Execute("UPDATE dbo.BanCafe SET TrangThai=N'Trống', SoNguoi=0, ThoiGianVao=NULL WHERE MaBan=@id", Db.P("@id", selectedId));
            ClearForm();
            LoadData();
        }

        private bool ValidateInput(out int people)
        {
            people = 0;
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Nhập tên bàn.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtArea.Text)) txtArea.Text = "Trong nhà";
            int.TryParse(txtPeople.Text, out people);
            if (people < 0) people = 0;
            return true;
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = grid.Rows[e.RowIndex];
            selectedId = Convert.ToInt32(row.Cells["MaBan"].Value);
            txtName.Text = Convert.ToString(row.Cells["Tên bàn"].Value);
            txtArea.Text = Convert.ToString(row.Cells["Khu vực"].Value);
            cboStatus.Text = Convert.ToString(row.Cells["Trạng thái"].Value);
            txtPeople.Text = Convert.ToString(row.Cells["Số người"].Value);
        }

        private string StatusValue(string display)
        {
            if (display == "Trống") return "Trống";
            if (display == "Đang phục vụ") return "Đang phục vụ";
            if (display == "Đặt trước") return "Đặt trước";
            return display;
        }

        private void ClearForm()
        {
            selectedId = 0;
            txtName.Clear();
            txtArea.Text = "Trong nhà";
            cboStatus.SelectedIndex = 0;
            txtPeople.Text = "0";
        }
    }
}
