using System;
using System.Data;
using System.Windows.Forms;
using QuanLyCafePOS.Data;
using QuanLyCafePOS.Models;

namespace QuanLyCafePOS.UI.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = @"SELECT TOP 1 MaNV, HoTen, ChucVu, VaiTro
                               FROM dbo.NhanVien
                               WHERE LOWER(LTRIM(RTRIM(TenDangNhap))) = LOWER(LTRIM(RTRIM(@u)))
                                 AND MatKhau = @p
                                 AND ISNULL(TrangThai, N'') NOT IN (N'Nghỉ việc', N'Nghi viec', N'Khóa', N'Khoa', N'Ngừng làm', N'Ngung lam')";
                DataTable user = Db.Query(sql, Db.P("@u", txtUser.Text.Trim()), Db.P("@p", txtPass.Text.Trim()));

                if (user.Rows.Count == 0)
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                AppSession.MaNV = Convert.ToInt32(user.Rows[0]["MaNV"]);
                AppSession.HoTen = Convert.ToString(user.Rows[0]["HoTen"]);
                AppSession.ChucVu = Convert.ToString(user.Rows[0]["ChucVu"]);
                AppSession.VaiTro = Convert.ToString(user.Rows[0]["VaiTro"]);

                Hide();
                using (MainForm main = new MainForm())
                {
                    DialogResult result = main.ShowDialog(this);
                    AppSession.Clear();
                    txtPass.Clear();
                    if (result == DialogResult.OK)
                    {
                        Show();
                        txtUser.Focus();
                    }
                    else
                    {
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không kết nối được database.\n\n" +
                    "Cách xử lý nhanh:\n" +
                    "1) Chạy file SQL/QuanLyCafeDB.sql bản mới trong SQL Server.\n" +
                    "2) Trong App.config, dùng chuỗi kết nối:\n" +
                    "   Data Source=.;Initial Catalog=QuanLyCafeDB;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True\n\n" +
                    "Chi tiết lỗi: " + ex.Message,
                    "Lỗi kết nối",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
