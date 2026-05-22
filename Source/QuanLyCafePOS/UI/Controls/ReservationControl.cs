using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using QuanLyCafePOS.Data;
using QuanLyCafePOS.Models;
using QuanLyCafePOS.UI;

namespace QuanLyCafePOS.UI.Controls
{
    public partial class ReservationControl : UserControl
    {
        private int selectedReservationId;
        private int selectedTableId;
        private bool dataLoaded;

        public ReservationControl()
        {
            InitializeComponent();
            CafeTheme.StyleGrid(grid);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!IsInDesignMode() && !dataLoaded)
            {
                LoadTables();
                LoadData();
                dataLoaded = true;
            }
        }

        private bool IsInDesignMode()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode;
        }

        private void BtnAdd_Click(object sender, EventArgs e) { AddReservation(); }
        private void BtnCheckIn_Click(object sender, EventArgs e) { CheckInReservation(); }
        private void BtnCancel_Click(object sender, EventArgs e) { CancelReservation(); }
        private void BtnReload_Click(object sender, EventArgs e) { LoadTables(); LoadData(); }
        private void BtnClear_Click(object sender, EventArgs e) { ClearForm(); }

        private void LoadTables()
        {
            try
            {
                DataTable tables = Db.Query("SELECT MaBan, TenBan + N' - ' + TrangThai AS TenHienThi FROM dbo.BanCafe ORDER BY MaBan");
                cboTable.DataSource = tables;
                cboTable.DisplayMember = "TenHienThi";
                cboTable.ValueMember = "MaBan";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải bàn: " + ex.Message);
            }
        }

        private void LoadData()
        {
            try
            {
                DataTable data = Db.Query(@"SELECT d.MaDatBan, d.MaBan, b.TenBan AS [Bàn], d.TenKhach AS [Khách đặt], d.SDT AS [SĐT],
                                                   d.SoNguoi AS [Số người], d.ThoiGianDat AS [Thời gian đặt],
                                                   d.TrangThai AS [Trạng thái], ISNULL(nv.HoTen,N'Đã xóa') AS [Nhân viên tạo], d.GhiChu AS [Ghi chú]
                                            FROM dbo.DatBan d
                                            INNER JOIN dbo.BanCafe b ON d.MaBan=b.MaBan
                                            LEFT JOIN dbo.NhanVien nv ON d.MaNV=nv.MaNV
                                            ORDER BY CASE WHEN d.TrangThai=N'Đã đặt' THEN 0 ELSE 1 END, d.ThoiGianDat DESC");
                grid.DataSource = data;
                if (grid.Columns.Contains("MaDatBan")) grid.Columns["MaDatBan"].Visible = false;
                if (grid.Columns.Contains("MaBan")) grid.Columns["MaBan"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải đặt bàn: " + ex.Message);
            }
        }

        private void AddReservation()
        {
            if (cboTable.SelectedValue == null)
            {
                MessageBox.Show("Chọn bàn cần đặt trước.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show("Nhập tên khách đặt bàn.");
                return;
            }
            int people;
            if (!int.TryParse(txtPeople.Text.Trim(), out people) || people <= 0) people = 1;

            int maBan = Convert.ToInt32(cboTable.SelectedValue);
            DateTime bookingTime = dtBookingDate.Value.Date + dtBookingTime.Value.TimeOfDay;
            int employeeId = AppSession.MaNV > 0 ? AppSession.MaNV : 1;
            int? customerId = EnsureCustomer(txtCustomerName.Text.Trim(), txtPhone.Text.Trim());

            Db.Execute(@"INSERT INTO dbo.DatBan(MaBan, MaKH, TenKhach, SDT, SoNguoi, ThoiGianDat, TrangThai, MaNV, GhiChu)
                         VALUES(@MaBan, @MaKH, @TenKhach, @SDT, @SoNguoi, @ThoiGianDat, N'Đã đặt', @MaNV, @GhiChu);
                         UPDATE dbo.BanCafe
                         SET TrangThai = CASE WHEN TrangThai=N'Đang phục vụ' THEN TrangThai ELSE N'Đặt trước' END,
                             SoNguoi = CASE WHEN TrangThai=N'Đang phục vụ' THEN SoNguoi ELSE @SoNguoi END
                         WHERE MaBan=@MaBan;",
                Db.P("@MaBan", maBan),
                Db.P("@MaKH", customerId.HasValue ? (object)customerId.Value : DBNull.Value),
                Db.P("@TenKhach", txtCustomerName.Text.Trim()),
                Db.P("@SDT", string.IsNullOrWhiteSpace(txtPhone.Text) ? (object)DBNull.Value : txtPhone.Text.Trim()),
                Db.P("@SoNguoi", people),
                Db.P("@ThoiGianDat", bookingTime),
                Db.P("@MaNV", employeeId),
                Db.P("@GhiChu", txtNote.Text.Trim()));

            MessageBox.Show("Đã đặt trước bàn thành công.");
            ClearForm();
            LoadTables();
            LoadData();
        }

        private int? EnsureCustomer(string name, string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return null;
            object id = Db.Scalar("SELECT TOP 1 MaKH FROM dbo.KhachHang WHERE SDT=@SDT", Db.P("@SDT", phone));
            if (id != null && id != DBNull.Value) return Convert.ToInt32(id);

            object newId = Db.Scalar(@"INSERT INTO dbo.KhachHang(HoTen, SDT, SoLanMua, DiemTichLuy, TongChiTieu, GhiChu)
                                       VALUES(@HoTen, @SDT, 0, 0, 0, N'Tạo từ đặt bàn');
                                       SELECT CAST(SCOPE_IDENTITY() AS INT);",
                Db.P("@HoTen", name), Db.P("@SDT", phone));
            return Convert.ToInt32(newId);
        }

        private void CheckInReservation()
        {
            if (selectedReservationId <= 0 || selectedTableId <= 0)
            {
                MessageBox.Show("Chọn lịch đặt bàn cần nhận bàn.");
                return;
            }

            Db.Execute(@"UPDATE dbo.DatBan SET TrangThai=N'Đã nhận' WHERE MaDatBan=@MaDatBan;
                         UPDATE dbo.BanCafe SET TrangThai=N'Đang phục vụ', ThoiGianVao=GETDATE(), SoNguoi=CASE WHEN SoNguoi=0 THEN 1 ELSE SoNguoi END WHERE MaBan=@MaBan;",
                Db.P("@MaDatBan", selectedReservationId), Db.P("@MaBan", selectedTableId));
            MessageBox.Show("Đã nhận bàn. Vào màn Bán hàng / Order để chọn bàn và gọi món.");
            ClearForm();
            LoadTables();
            LoadData();
        }

        private void CancelReservation()
        {
            if (selectedReservationId <= 0 || selectedTableId <= 0)
            {
                MessageBox.Show("Chọn lịch đặt bàn cần hủy.");
                return;
            }

            if (MessageBox.Show("Hủy lịch đặt bàn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            Db.Execute(@"UPDATE dbo.DatBan SET TrangThai=N'Đã hủy' WHERE MaDatBan=@MaDatBan;
                         IF NOT EXISTS(SELECT 1 FROM dbo.DatBan WHERE MaBan=@MaBan AND TrangThai=N'Đã đặt')
                         BEGIN
                             UPDATE dbo.BanCafe SET TrangThai=N'Trống', SoNguoi=0 WHERE MaBan=@MaBan AND TrangThai=N'Đặt trước';
                         END",
                Db.P("@MaDatBan", selectedReservationId), Db.P("@MaBan", selectedTableId));
            ClearForm();
            LoadTables();
            LoadData();
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = grid.Rows[e.RowIndex];
            selectedReservationId = Convert.ToInt32(row.Cells["MaDatBan"].Value);
            selectedTableId = Convert.ToInt32(row.Cells["MaBan"].Value);
            cboTable.SelectedValue = selectedTableId;
            txtCustomerName.Text = Convert.ToString(row.Cells["Khách đặt"].Value);
            txtPhone.Text = Convert.ToString(row.Cells["SĐT"].Value);
            txtPeople.Text = Convert.ToString(row.Cells["Số người"].Value);
            DateTime time = Convert.ToDateTime(row.Cells["Thời gian đặt"].Value);
            dtBookingDate.Value = time.Date;
            dtBookingTime.Value = DateTime.Today.Add(time.TimeOfDay);
            txtNote.Text = Convert.ToString(row.Cells["Ghi chú"].Value);
            lblSelected.Text = "Đang chọn đặt bàn mã " + selectedReservationId;
        }

        private void ClearForm()
        {
            selectedReservationId = 0;
            selectedTableId = 0;
            txtCustomerName.Clear();
            txtPhone.Clear();
            txtPeople.Text = "2";
            txtNote.Clear();
            dtBookingDate.Value = DateTime.Today;
            dtBookingTime.Value = DateTime.Today.AddHours(19);
            lblSelected.Text = "Chưa chọn lịch đặt bàn";
        }
    }
}
