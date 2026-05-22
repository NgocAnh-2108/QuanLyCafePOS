using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyCafePOS.Data;
using QuanLyCafePOS.UI;
using QuanLyCafePOS.Models;

namespace QuanLyCafePOS.UI.Controls
{
    public partial class StaffControl : UserControl
    {
        private int selectedId;
        private bool dataLoaded;

        public StaffControl()
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
        private void BtnReload_Click(object sender, EventArgs e) { LoadData(); }

        private void LoadData()
        {
            try
            {
                DataTable data = Db.Query(@"SELECT MaNV, HoTen AS [Họ tên], TenDangNhap AS [Tài khoản], MatKhau AS [Mật khẩu],
                                                   ChucVu AS [Chức vụ], SDT, TrangThai AS [Trạng thái], NgayTao AS [Ngày tạo]
                                            FROM dbo.NhanVien ORDER BY MaNV DESC");
                grid.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải nhân viên: " + ex.Message);
            }
        }

        private void AddItem()
        {
            if (!ValidateInput()) return;
            Db.Execute(@"INSERT INTO dbo.NhanVien(HoTen, TenDangNhap, MatKhau, ChucVu, VaiTro, SDT, TrangThai)
                         VALUES(@HoTen, @TenDangNhap, @MatKhau, @ChucVu, @VaiTro, @SDT, @TrangThai)",
                Db.P("@HoTen", txtName.Text.Trim()),
                Db.P("@TenDangNhap", txtUsername.Text.Trim()),
                Db.P("@MatKhau", txtPassword.Text.Trim()),
                Db.P("@ChucVu", cboRole.Text),
                Db.P("@VaiTro", PermissionFromRole()),
                Db.P("@SDT", txtPhone.Text.Trim()),
                Db.P("@TrangThai", cboStatus.Text));
            ClearForm();
            LoadData();
        }

        private void UpdateItem()
        {
            if (selectedId <= 0)
            {
                MessageBox.Show("Chọn nhân viên cần sửa.");
                return;
            }

            if (!ValidateInput()) return;
            Db.Execute(@"UPDATE dbo.NhanVien
                         SET HoTen=@HoTen, TenDangNhap=@TenDangNhap, MatKhau=@MatKhau, ChucVu=@ChucVu, VaiTro=@VaiTro, SDT=@SDT, TrangThai=@TrangThai
                         WHERE MaNV=@MaNV",
                Db.P("@HoTen", txtName.Text.Trim()),
                Db.P("@TenDangNhap", txtUsername.Text.Trim()),
                Db.P("@MatKhau", txtPassword.Text.Trim()),
                Db.P("@ChucVu", cboRole.Text),
                Db.P("@VaiTro", PermissionFromRole()),
                Db.P("@SDT", txtPhone.Text.Trim()),
                Db.P("@TrangThai", cboStatus.Text),
                Db.P("@MaNV", selectedId));
            ClearForm();
            LoadData();
        }

        private void DeleteItem()
        {
            if (selectedId <= 0)
            {
                MessageBox.Show("Chọn nhân viên cần xóa.");
                return;
            }

            if (selectedId == AppSession.MaNV)
            {
                MessageBox.Show("Không nên xóa tài khoản đang đăng nhập. Hãy đăng nhập bằng tài khoản admin khác rồi xóa.");
                return;
            }

            DialogResult result = MessageBox.Show("Xóa nhân viên này khỏi danh sách? Lịch sử hóa đơn/nhập kho/kiểm kê vẫn được giữ và sẽ hiển thị là 'Đã xóa'.",
                "Xác nhận xóa nhân viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            try
            {
                using (SqlConnection con = new SqlConnection(Db.ConnectionString))
                {
                    con.Open();
                    SqlTransaction tran = con.BeginTransaction();
                    try
                    {
                        NullEmployeeReference(con, tran, "dbo.HoaDon", "MaNV");
                        NullEmployeeReference(con, tran, "dbo.NhapKho", "MaNV");
                        NullEmployeeReference(con, tran, "dbo.KiemKeKho", "MaNV");
                        NullEmployeeReference(con, tran, "dbo.DatBan", "MaNV");

                        SqlCommand delete = new SqlCommand("DELETE FROM dbo.NhanVien WHERE MaNV=@MaNV", con, tran);
                        delete.Parameters.AddWithValue("@MaNV", selectedId);
                        delete.ExecuteNonQuery();
                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }

                ClearForm();
                LoadData();
                MessageBox.Show("Đã xóa nhân viên.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không xóa được nhân viên: " + ex.Message + "\n\nBạn hãy chạy lại file SQL v9 để các bảng lịch sử cho phép xóa nhân viên.");
            }
        }

        private void NullEmployeeReference(SqlConnection con, SqlTransaction tran, string tableName, string columnName)
        {
            SqlCommand cmd = new SqlCommand("UPDATE " + tableName + " SET " + columnName + "=NULL WHERE " + columnName + "=@MaNV", con, tran);
            cmd.Parameters.AddWithValue("@MaNV", selectedId);
            cmd.ExecuteNonQuery();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Nhập họ tên.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Nhập tài khoản.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Nhập mật khẩu.");
                return false;
            }
            return true;
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = grid.Rows[e.RowIndex];
            selectedId = Convert.ToInt32(row.Cells["MaNV"].Value);
            txtName.Text = Convert.ToString(row.Cells["Họ tên"].Value);
            txtUsername.Text = Convert.ToString(row.Cells["Tài khoản"].Value);
            txtPassword.Text = Convert.ToString(row.Cells["Mật khẩu"].Value);
            cboRole.Text = Convert.ToString(row.Cells["Chức vụ"].Value);
            txtPhone.Text = Convert.ToString(row.Cells["SDT"].Value);
            cboStatus.Text = Convert.ToString(row.Cells["Trạng thái"].Value);
        }


        private string PermissionFromRole()
        {
            return cboRole.Text == "Quản lý" ? "Admin" : "Nhân viên";
        }

        private void ClearForm()
        {
            selectedId = 0;
            txtName.Clear();
            txtUsername.Clear();
            txtPassword.Text = "123456";
            txtPhone.Clear();
            cboRole.SelectedIndex = 1;
            cboStatus.SelectedIndex = 0;
        }
    }
}
