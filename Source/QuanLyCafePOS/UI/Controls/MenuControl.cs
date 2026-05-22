using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using QuanLyCafePOS.Data;
using QuanLyCafePOS.UI;

namespace QuanLyCafePOS.UI.Controls
{
    public partial class MenuControl : UserControl
    {
        private int selectedId;
        private bool dataLoaded;
        private string selectedImagePath = string.Empty;

        public MenuControl()
        {
            InitializeComponent();
            txtSearch.PlaceholderTextCompat("Tìm món...");
            FixNoImageLabel();
            CafeTheme.StyleGrid(grid);
            grid.CellFormatting += Grid_CellFormatting;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!IsInDesignMode() && !dataLoaded)
            {
                LoadCategories();
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
        private void BtnHide_Click(object sender, EventArgs e) { HideItem(); }
        private void BtnDelete_Click(object sender, EventArgs e) { DeleteItem(); }
        private void BtnReload_Click(object sender, EventArgs e) { LoadData(); }
        private void TxtSearch_TextChanged(object sender, EventArgs e) { if (dataLoaded) LoadData(); }
        private void TxtPrice_Leave(object sender, EventArgs e) { txtPrice.Text = CafeTheme.Money(CafeTheme.ParseMoney(txtPrice.Text)); }

        private void BtnChooseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh món";
                ofd.Filter = "Ảnh (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Tất cả file (*.*)|*.*";
                if (ofd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    selectedImagePath = CopyImageToAppFolder(ofd.FileName);
                    txtImage.Text = selectedImagePath;
                    LoadImagePreview(selectedImagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không tải được ảnh món: " + ex.Message, "Ảnh món", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void BtnClearImage_Click(object sender, EventArgs e)
        {
            selectedImagePath = string.Empty;
            txtImage.Clear();
            SetPicture(null);
        }

        private void LoadCategories()
        {
            try
            {
                DataTable categories = Db.Query("SELECT MaLoai, TenLoai FROM dbo.LoaiMon ORDER BY TenLoai");
                cboCategory.DataSource = categories;
                cboCategory.DisplayMember = "TenLoai";
                cboCategory.ValueMember = "MaLoai";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải loại món: " + ex.Message);
            }
        }

        private void LoadData()
        {
            try
            {
                DataTable data = Db.Query(@"SELECT m.MaMon, m.MaLoai, m.HinhAnh,
                                                   m.TenMon AS [Tên món], l.TenLoai AS [Loại],
                                                   m.GiaBan AS [Giá bán], m.DonViTinh AS [Đơn vị],
                                                   CASE WHEN ISNULL(m.HinhAnh,N'')=N'' THEN N'Chưa có' ELSE N'Có ảnh' END AS [Ảnh],
                                                   CASE WHEN m.IsActive=1 THEN N'Đang bán' ELSE N'Ngừng bán' END AS [Trạng thái]
                                            FROM dbo.Mon m INNER JOIN dbo.LoaiMon l ON m.MaLoai=l.MaLoai
                                            WHERE (@kw='' OR m.TenMon LIKE N'%' + @kw + N'%')
                                            ORDER BY m.MaMon DESC", Db.P("@kw", txtSearch == null ? "" : txtSearch.Text.Trim()));
                grid.DataSource = data;
                if (grid.Columns.Contains("MaLoai")) grid.Columns["MaLoai"].Visible = false;
                if (grid.Columns.Contains("HinhAnh")) grid.Columns["HinhAnh"].Visible = false;
                if (grid.Columns.Contains("MaMon")) grid.Columns["MaMon"].Width = 60;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thực đơn: " + ex.Message);
            }
        }

        private void AddItem()
        {
            decimal price;
            if (!ValidateInput(out price)) return;
            Db.Execute(@"INSERT INTO dbo.Mon(MaLoai, TenMon, GiaBan, DonViTinh, HinhAnh, IsActive)
                         VALUES(@MaLoai, @TenMon, @GiaBan, @DonViTinh, @HinhAnh, @IsActive)",
                Db.P("@MaLoai", Convert.ToInt32(cboCategory.SelectedValue)),
                Db.P("@TenMon", txtName.Text.Trim()),
                Db.P("@GiaBan", price),
                Db.P("@DonViTinh", txtUnit.Text.Trim()),
                Db.P("@HinhAnh", string.IsNullOrWhiteSpace(txtImage.Text) ? (object)DBNull.Value : txtImage.Text.Trim()),
                Db.P("@IsActive", chkActive.Checked));
            ClearForm();
            LoadData();
        }

        private void UpdateItem()
        {
            if (selectedId <= 0)
            {
                MessageBox.Show("Chọn món cần sửa.");
                return;
            }

            decimal price;
            if (!ValidateInput(out price)) return;
            Db.Execute(@"UPDATE dbo.Mon
                         SET MaLoai=@MaLoai, TenMon=@TenMon, GiaBan=@GiaBan, DonViTinh=@DonViTinh,
                             HinhAnh=@HinhAnh, IsActive=@IsActive
                         WHERE MaMon=@MaMon",
                Db.P("@MaLoai", Convert.ToInt32(cboCategory.SelectedValue)),
                Db.P("@TenMon", txtName.Text.Trim()),
                Db.P("@GiaBan", price),
                Db.P("@DonViTinh", txtUnit.Text.Trim()),
                Db.P("@HinhAnh", string.IsNullOrWhiteSpace(txtImage.Text) ? (object)DBNull.Value : txtImage.Text.Trim()),
                Db.P("@IsActive", chkActive.Checked),
                Db.P("@MaMon", selectedId));
            ClearForm();
            LoadData();
        }

        private void HideItem()
        {
            if (selectedId <= 0)
            {
                MessageBox.Show("Chọn món cần ẩn khỏi màn hình bán hàng.");
                return;
            }

            if (MessageBox.Show("Ẩn món này khỏi màn hình bán hàng? Món vẫn còn trong database để giữ lịch sử hóa đơn.", "Ẩn món", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Db.Execute("UPDATE dbo.Mon SET IsActive=0 WHERE MaMon=@id", Db.P("@id", selectedId));
                ClearForm();
                LoadData();
            }
        }

        private void DeleteItem()
        {
            if (selectedId <= 0)
            {
                MessageBox.Show("Chọn món cần xóa vĩnh viễn.");
                return;
            }

            int usedCount = Convert.ToInt32(Db.Scalar("SELECT COUNT(*) FROM dbo.ChiTietHoaDon WHERE MaMon=@id", Db.P("@id", selectedId)));
            if (usedCount > 0)
            {
                MessageBox.Show("Món này đã có trong hóa đơn nên không xóa vĩnh viễn để tránh mất lịch sử bán hàng. Bạn có thể bấm nút Ẩn món.", "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Xóa vĩnh viễn món này khỏi database?", "Xóa món", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Db.Execute("DELETE FROM dbo.Mon WHERE MaMon=@id", Db.P("@id", selectedId));
                ClearForm();
                LoadData();
            }
        }

        private bool ValidateInput(out decimal price)
        {
            price = 0;
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Nhập tên món.");
                return false;
            }

            price = CafeTheme.ParseMoney(txtPrice.Text);
            if (price <= 0)
            {
                MessageBox.Show("Giá bán không hợp lệ.");
                return false;
            }

            if (cboCategory.SelectedValue == null)
            {
                MessageBox.Show("Chọn loại món.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUnit.Text)) txtUnit.Text = "ly";
            return true;
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = grid.Rows[e.RowIndex];
            selectedId = Convert.ToInt32(row.Cells["MaMon"].Value);
            cboCategory.SelectedValue = Convert.ToInt32(row.Cells["MaLoai"].Value);
            txtName.Text = Convert.ToString(row.Cells["Tên món"].Value);
            txtPrice.Text = CafeTheme.Money(Convert.ToDecimal(row.Cells["Giá bán"].Value));
            txtUnit.Text = Convert.ToString(row.Cells["Đơn vị"].Value);
            chkActive.Checked = Convert.ToString(row.Cells["Trạng thái"].Value) == "Đang bán";
            selectedImagePath = row.Cells["HinhAnh"].Value == DBNull.Value ? string.Empty : Convert.ToString(row.Cells["HinhAnh"].Value);
            txtImage.Text = selectedImagePath;
            LoadImagePreview(selectedImagePath);
        }

        private void Grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            CafeTheme.FormatMoneyCell(grid, e);
        }

        private string CopyImageToAppFolder(string sourcePath)
        {
            if (string.IsNullOrWhiteSpace(sourcePath) || !File.Exists(sourcePath))
            {
                throw new FileNotFoundException("Không tìm thấy file ảnh đã chọn.");
            }

            string folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProductImages");
            Directory.CreateDirectory(folder);

            string fileName = "mon_" + DateTime.Now.ToString("yyyyMMdd_HHmmss_fff") + "_" + Guid.NewGuid().ToString("N").Substring(0, 6) + ".png";
            string destPath = Path.Combine(folder, fileName);

            using (FileStream fs = new FileStream(sourcePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (Image original = Image.FromStream(fs))
            using (Bitmap bitmap = new Bitmap(original))
            {
                bitmap.Save(destPath, ImageFormat.Png);
            }

            return Path.Combine("ProductImages", fileName);
        }

        private string ResolveImagePath(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) return string.Empty;
            if (Path.IsPathRooted(path)) return path;
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
        }

        private Bitmap LoadBitmapNoLock(string fullPath)
        {
            using (FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (Image img = Image.FromStream(fs))
            {
                return new Bitmap(img);
            }
        }

        private void LoadImagePreview(string path)
        {
            string fullPath = ResolveImagePath(path);
            if (string.IsNullOrWhiteSpace(fullPath) || !File.Exists(fullPath))
            {
                SetPicture(null);
                return;
            }

            try
            {
                SetPicture(LoadBitmapNoLock(fullPath));
            }
            catch (Exception ex)
            {
                SetPicture(null);
                MessageBox.Show("Không đọc được ảnh này. Hãy chọn file JPG/PNG/BMP khác.\n\nChi tiết: " + ex.Message,
                    "Ảnh món", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SetPicture(Image image)
        {
            if (picProduct.Image != null)
            {
                Image old = picProduct.Image;
                picProduct.Image = null;
                old.Dispose();
            }
            picProduct.Image = image;
            lblNoImage.Visible = image == null;
        }

        private void FixNoImageLabel()
        {
            lblNoImage.Parent = picProduct;
            lblNoImage.Dock = DockStyle.Fill;
            lblNoImage.Location = Point.Empty;
            lblNoImage.BackColor = Color.Transparent;
            lblNoImage.BringToFront();
        }

        private void ClearForm()
        {
            selectedId = 0;
            txtName.Clear();
            txtPrice.Clear();
            txtUnit.Text = "ly";
            txtImage.Clear();
            selectedImagePath = string.Empty;
            chkActive.Checked = true;
            SetPicture(null);
        }
    }
}
