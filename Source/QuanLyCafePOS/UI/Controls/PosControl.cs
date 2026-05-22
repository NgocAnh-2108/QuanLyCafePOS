using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using QuanLyCafePOS.Data;
using QuanLyCafePOS.Models;
using QuanLyCafePOS.UI;

namespace QuanLyCafePOS.UI.Controls
{
    public partial class PosControl : UserControl
    {
        private DataTable cart;
        private int selectedTableId;
        private string selectedTableName;
        private int currentInvoiceId;
        private int selectedCustomerId;
        private string selectedCustomerName = "Khách lẻ";
        private int selectedCustomerPurchaseCount;
        private string paymentMethod = "Tiền mặt";
        private bool dataLoaded;
        private bool updatingMoney;
        private string printReceiptText = string.Empty;

        public PosControl()
        {
            InitializeComponent();
            txtSearch.PlaceholderTextCompat("Tìm kiếm món...");
            txtCustomerSearch.PlaceholderTextCompat("SĐT hoặc tên khách hàng...");
            CreateCartTable();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!IsInDesignMode() && !dataLoaded)
            {
                LoadTables();
                LoadCategories();
                LoadProducts();
                SelectPaymentMethod("Tiền mặt");
                ClearCustomerSelection();
                UpdateOrderModeText();
                dataLoaded = true;
            }
        }

        private bool IsInDesignMode()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode;
        }

        private void CreateCartTable()
        {
            cart = new DataTable();
            cart.Columns.Add("MaMon", typeof(int));
            cart.Columns.Add("Tên món", typeof(string));
            cart.Columns.Add("SL", typeof(int));
            cart.Columns.Add("Đơn giá", typeof(decimal));
            cart.Columns.Add("Thành tiền", typeof(decimal));

            cartGrid.DataSource = cart;
            cartGrid.CellFormatting += CartGrid_CellFormatting;
            if (cartGrid.Columns.Contains("MaMon")) cartGrid.Columns["MaMon"].Visible = false;

            cart.ColumnChanged += delegate { Recalculate(); };
            cart.RowChanged += delegate { Recalculate(); };
            cart.RowDeleted += delegate { Recalculate(); };
        }

        private void CartGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            CafeTheme.FormatMoneyCell(cartGrid, e);
        }

        private void BtnReloadTables_Click(object sender, EventArgs e) { LoadTables(); }
        private void CboCategory_SelectedIndexChanged(object sender, EventArgs e) { if (dataLoaded) LoadProducts(); }
        private void TxtSearch_TextChanged(object sender, EventArgs e) { if (dataLoaded) LoadProducts(); }
        private void BtnMinus_Click(object sender, EventArgs e) { ChangeQuantity(-1); }
        private void BtnPlus_Click(object sender, EventArgs e) { ChangeQuantity(1); }
        private void BtnRemove_Click(object sender, EventArgs e) { RemoveSelectedItem(); }
        private void BtnCash_Click(object sender, EventArgs e) { SelectPaymentMethod("Tiền mặt"); }
        private void BtnBank_Click(object sender, EventArgs e) { SelectPaymentMethod("Chuyển khoản"); }
        private void BtnCard_Click(object sender, EventArgs e) { SelectPaymentMethod("Thẻ"); }
        private void BtnFindCustomer_Click(object sender, EventArgs e) { FindCustomer(); }
        private void BtnClearCustomer_Click(object sender, EventArgs e) { ClearCustomerSelection(); Recalculate(); }

        private void RdoDineIn_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdoDineIn.Checked) return;
            btnHold.Enabled = true;
            if (selectedTableId <= 0)
            {
                selectedTableName = string.Empty;
                currentInvoiceId = 0;
                lblSelectedTable.Text = "Uống tại chỗ: chọn bàn để order";
            }
            UpdateOrderModeText();
            Recalculate();
        }

        private void RdoTakeAway_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdoTakeAway.Checked) return;

            if (cart != null && cart.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show(
                    "Chuyển sang bán mang về sẽ xóa giỏ hàng hiện tại. Bạn có muốn tiếp tục?",
                    "Đổi loại đơn",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    rdoDineIn.Checked = true;
                    return;
                }
            }

            ClearCurrentOrder(false);
            selectedTableId = 0;
            selectedTableName = "Mang về";
            currentInvoiceId = 0;
            btnHold.Enabled = false;
            lblSelectedTable.Text = "Đơn mang về";
            UpdateOrderModeText();
            Recalculate();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            if (cart.Rows.Count == 0) return;
            DialogResult result = MessageBox.Show("Xóa toàn bộ món đang order?", "Hủy món", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cart.Rows.Clear();
                Recalculate();
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            if (cart.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có món để in hóa đơn.");
                return;
            }

            decimal subtotal = GetSubtotal();
            decimal discount = GetTotalDiscount(subtotal);
            decimal total = subtotal - discount;
            decimal paid = GetPaidAmount(total);
            decimal change = GetChange(total, paid);
            ShowReceiptPreview(currentInvoiceId, total, discount, paid, change);
        }

        private void LoadTables()
        {
            try
            {
                tablePanel.Controls.Clear();
                DataTable data = Db.Query(@"SELECT MaBan, TenBan, KhuVuc, TrangThai, SoNguoi,
                                          CASE WHEN ThoiGianVao IS NULL THEN 0 ELSE DATEDIFF(MINUTE, ThoiGianVao, GETDATE()) END AS Phut
                                          FROM dbo.BanCafe ORDER BY MaBan");
                foreach (DataRow row in data.Rows)
                {
                    string status = Convert.ToString(row["TrangThai"]);
                    string text = Convert.ToString(row["TenBan"]) + "\n" + StatusText(status);
                    if (Convert.ToInt32(row["SoNguoi"]) > 0) text += " - " + row["SoNguoi"] + " người";
                    if (Convert.ToInt32(row["Phut"]) > 0) text += "\n" + row["Phut"] + " phút";

                    Button b = CafeTheme.Button(text, StatusColor(status));
                    b.Size = new Size(118, 78);
                    b.Margin = new Padding(6);
                    b.Tag = row;
                    b.Click += TableButton_Click;
                    tablePanel.Controls.Add(b);
                }
            }
            catch (Exception ex)
            {
                tablePanel.Controls.Clear();
                tablePanel.Controls.Add(CafeTheme.Label("Lỗi tải bàn: " + ex.Message, 9, FontStyle.Regular, CafeTheme.Red));
            }
        }

        private void LoadCategories()
        {
            try
            {
                DataTable categories = Db.Query("SELECT MaLoai, TenLoai FROM dbo.LoaiMon ORDER BY TenLoai");
                DataRow all = categories.NewRow();
                all["MaLoai"] = 0;
                all["TenLoai"] = "Tất cả";
                categories.Rows.InsertAt(all, 0);
                cboCategory.DataSource = categories;
                cboCategory.DisplayMember = "TenLoai";
                cboCategory.ValueMember = "MaLoai";
            }
            catch (Exception ex)
            {
                productPanel.Controls.Clear();
                productPanel.Controls.Add(CafeTheme.Label("Lỗi tải loại món: " + ex.Message, 9, FontStyle.Regular, CafeTheme.Red));
            }
        }

        private void LoadProducts()
        {
            if (productPanel == null) return;
            foreach (Control oldControl in productPanel.Controls)
            {
                oldControl.Dispose();
            }
            productPanel.Controls.Clear();

            try
            {
                int maLoai = 0;
                if (cboCategory.SelectedValue != null)
                {
                    int.TryParse(cboCategory.SelectedValue.ToString(), out maLoai);
                }

                string kw = txtSearch == null ? string.Empty : txtSearch.Text.Trim();
                DataTable products = Db.Query(@"SELECT MaMon, TenMon, GiaBan, HinhAnh
                                                FROM dbo.Mon
                                                WHERE IsActive=1
                                                  AND (@loai=0 OR MaLoai=@loai)
                                                  AND (@kw='' OR TenMon LIKE N'%' + @kw + N'%')
                                                ORDER BY TenMon",
                    Db.P("@loai", maLoai), Db.P("@kw", kw));

                foreach (DataRow row in products.Rows)
                {
                    Panel card = new Panel();
                    card.Width = 176;
                    card.Height = 278;
                    card.BackColor = Color.FromArgb(255, 250, 242);
                    card.BorderStyle = BorderStyle.FixedSingle;
                    card.Margin = new Padding(7);
                    card.Tag = row;
                    card.Cursor = Cursors.Hand;

                    Panel imageArea = new Panel();
                    imageArea.Dock = DockStyle.Top;
                    imageArea.Height = 198;
                    imageArea.BackColor = Color.White;
                    imageArea.Cursor = Cursors.Hand;

                    string imagePath = row["HinhAnh"] == DBNull.Value ? string.Empty : Convert.ToString(row["HinhAnh"]);
                    string fullImagePath = ResolveImagePath(imagePath);
                    if (!string.IsNullOrWhiteSpace(fullImagePath) && File.Exists(fullImagePath))
                    {
                        PictureBox picture = new PictureBox();
                        picture.Width = 132;
                        picture.Height = 188;
                        picture.Left = (imageArea.Width - picture.Width) / 2;
                        picture.Top = 5;
                        picture.Anchor = AnchorStyles.Top;
                        picture.SizeMode = PictureBoxSizeMode.StretchImage;
                        picture.BackColor = Color.White;
                        picture.Cursor = Cursors.Hand;
                        try
                        {
                            picture.Image = LoadBitmapNoLock(fullImagePath);
                        }
                        catch
                        {
                            picture.Image = null;
                        }
                        imageArea.Controls.Add(picture);
                        imageArea.Resize += delegate
                        {
                            picture.Left = Math.Max(0, (imageArea.ClientSize.Width - picture.Width) / 2);
                        };
                    }
                    else
                    {
                        Label icon = new Label();
                        icon.Text = "☕";
                        icon.Dock = DockStyle.Fill;
                        icon.TextAlign = ContentAlignment.MiddleCenter;
                        icon.Font = CafeTheme.Font(34F, FontStyle.Regular);
                        icon.ForeColor = CafeTheme.Brown;
                        icon.Cursor = Cursors.Hand;
                        imageArea.Controls.Add(icon);
                    }

                    Label name = new Label();
                    name.Text = Convert.ToString(row["TenMon"]);
                    name.Dock = DockStyle.Top;
                    name.Height = 42;
                    name.TextAlign = ContentAlignment.MiddleCenter;
                    name.Font = CafeTheme.Font(9.5F, FontStyle.Bold);
                    name.ForeColor = CafeTheme.Text;
                    name.AutoEllipsis = true;
                    name.Cursor = Cursors.Hand;

                    decimal price = Convert.ToDecimal(row["GiaBan"]);
                    Label priceLabel = new Label();
                    priceLabel.Text = CafeTheme.Money(price);
                    priceLabel.Dock = DockStyle.Bottom;
                    priceLabel.Height = 34;
                    priceLabel.TextAlign = ContentAlignment.MiddleCenter;
                    priceLabel.Font = CafeTheme.Font(10F, FontStyle.Bold);
                    priceLabel.ForeColor = CafeTheme.Orange;
                    priceLabel.Cursor = Cursors.Hand;

                    card.Controls.Add(priceLabel);
                    card.Controls.Add(name);
                    card.Controls.Add(imageArea);

                    WireProductClick(card);
                    productPanel.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                productPanel.Controls.Add(CafeTheme.Label("Lỗi tải món: " + ex.Message, 9, FontStyle.Regular, CafeTheme.Red));
            }
        }

        private Bitmap LoadBitmapNoLock(string fullPath)
        {
            using (FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (Image img = Image.FromStream(fs))
            {
                return new Bitmap(img);
            }
        }

        private void WireProductClick(Control control)
        {
            if (control == null) return;
            control.Click += Product_Click;
            foreach (Control child in control.Controls)
            {
                WireProductClick(child);
            }
        }

        private void TableButton_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b == null) return;
            DataRow row = b.Tag as DataRow;
            if (row == null) return;

            if (cart.Rows.Count > 0 && currentInvoiceId == 0)
            {
                DialogResult result = MessageBox.Show(
                    "Bạn đang có order chưa lưu. Chuyển bàn sẽ xóa order hiện tại. Tiếp tục?",
                    "Chọn bàn",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;
            }

            rdoDineIn.Checked = true;
            selectedTableId = Convert.ToInt32(row["MaBan"]);
            selectedTableName = Convert.ToString(row["TenBan"]);
            LoadPendingOrderForSelectedTable();
        }

        private void LoadPendingOrderForSelectedTable()
        {
            currentInvoiceId = 0;
            cart.Rows.Clear();
            updatingMoney = true;
            txtDiscount.Text = CafeTheme.Money(0);
            txtCustomerPay.Text = CafeTheme.Money(0);
            updatingMoney = false;
            ClearCustomerSelection();

            try
            {
                DataTable invoice = Db.Query(@"SELECT TOP 1 h.MaHD, h.TongTien, h.GiamGia, h.KhachDua, h.PhuongThucThanhToan, h.MaKH,
                                                      k.HoTen, k.SDT, ISNULL(k.SoLanMua,0) AS SoLanMua
                                               FROM dbo.HoaDon h
                                               LEFT JOIN dbo.KhachHang k ON h.MaKH=k.MaKH
                                               WHERE h.MaBan=@MaBan AND h.TrangThai=N'Đang phục vụ'
                                               ORDER BY h.MaHD DESC", Db.P("@MaBan", selectedTableId));
                if (invoice.Rows.Count > 0)
                {
                    currentInvoiceId = Convert.ToInt32(invoice.Rows[0]["MaHD"]);
                    DataTable details = Db.Query(@"SELECT MaMon, TenMon, SoLuong, DonGia, ThanhTien
                                                   FROM dbo.ChiTietHoaDon
                                                   WHERE MaHD=@MaHD
                                                   ORDER BY MaCT", Db.P("@MaHD", currentInvoiceId));
                    foreach (DataRow d in details.Rows)
                    {
                        cart.Rows.Add(
                            Convert.ToInt32(d["MaMon"]),
                            Convert.ToString(d["TenMon"]),
                            Convert.ToInt32(d["SoLuong"]),
                            Convert.ToDecimal(d["DonGia"]),
                            Convert.ToDecimal(d["ThanhTien"]));
                    }

                    txtDiscount.Text = CafeTheme.Money(Convert.ToDecimal(invoice.Rows[0]["GiamGia"]));
                    if (invoice.Rows[0]["MaKH"] != DBNull.Value)
                    {
                        selectedCustomerId = Convert.ToInt32(invoice.Rows[0]["MaKH"]);
                        selectedCustomerName = Convert.ToString(invoice.Rows[0]["HoTen"]);
                        selectedCustomerPurchaseCount = Convert.ToInt32(invoice.Rows[0]["SoLanMua"]);
                        txtCustomerSearch.Text = Convert.ToString(invoice.Rows[0]["SDT"]);
                        UpdateCustomerInfoLabel();
                    }
                    lblSelectedTable.Text = "Đang mở: " + selectedTableName + " - HD" + currentInvoiceId.ToString("0000");
                }
                else
                {
                    lblSelectedTable.Text = "Đang chọn: " + selectedTableName + " - order mới";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải order của bàn: " + ex.Message);
                lblSelectedTable.Text = "Đang chọn: " + selectedTableName;
            }

            UpdateOrderModeText();
            Recalculate();
        }

        private void Product_Click(object sender, EventArgs e)
        {
            if (rdoDineIn.Checked && selectedTableId <= 0)
            {
                MessageBox.Show("Hãy chọn bàn trước khi order, hoặc đổi sang 'Mang về'.", "POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Control current = sender as Control;
            while (current != null && !(current.Tag is DataRow))
            {
                current = current.Parent;
            }

            if (current == null) return;
            DataRow row = current.Tag as DataRow;
            if (row == null) return;

            int maMon = Convert.ToInt32(row["MaMon"]);
            string name = Convert.ToString(row["TenMon"]);
            decimal price = Convert.ToDecimal(row["GiaBan"]);
            DataRow[] found = cart.Select("MaMon=" + maMon);

            if (found.Length > 0)
            {
                int quantity = Convert.ToInt32(found[0]["SL"]) + 1;
                found[0]["SL"] = quantity;
                found[0]["Thành tiền"] = quantity * price;
            }
            else
            {
                cart.Rows.Add(maMon, name, 1, price, price);
            }

            Recalculate();
        }

        private void ChangeQuantity(int delta)
        {
            if (cartGrid.CurrentRow == null) return;
            DataRowView view = cartGrid.CurrentRow.DataBoundItem as DataRowView;
            if (view == null) return;

            int quantity = Convert.ToInt32(view.Row["SL"]) + delta;
            if (quantity <= 0)
            {
                view.Row.Delete();
            }
            else
            {
                view.Row["SL"] = quantity;
                view.Row["Thành tiền"] = quantity * Convert.ToDecimal(view.Row["Đơn giá"]);
            }
            Recalculate();
        }

        private void RemoveSelectedItem()
        {
            if (cartGrid.CurrentRow == null) return;
            DataRowView view = cartGrid.CurrentRow.DataBoundItem as DataRowView;
            if (view != null) view.Row.Delete();
            Recalculate();
        }

        private void Recalculate()
        {
            if (lblTotal == null || cart == null) return;

            decimal subtotal = GetSubtotal();
            decimal manualDiscount = NormalizeDiscount(subtotal, ParseMoney(txtDiscount == null ? "0" : txtDiscount.Text));
            decimal loyaltyDiscount = GetLoyaltyDiscount(subtotal);
            decimal totalDiscount = NormalizeDiscount(subtotal, manualDiscount + loyaltyDiscount);
            decimal total = subtotal - totalDiscount;

            if (paymentMethod != "Tiền mặt" && txtCustomerPay != null)
            {
                string totalText = CafeTheme.Money(total);
                if (!updatingMoney && txtCustomerPay.Text != totalText)
                {
                    updatingMoney = true;
                    txtCustomerPay.Text = totalText;
                    updatingMoney = false;
                }
            }

            decimal paid = GetPaidAmount(total);
            decimal change = GetChange(total, paid);

            lblLoyaltyDiscount.Text = "Giảm thân thiết: " + CafeTheme.Money(loyaltyDiscount);
            lblTotal.Text = "Tổng tiền: " + CafeTheme.Money(total);
            lblChange.Text = "Tiền thối: " + CafeTheme.Money(change);
            lblPaymentCurrent.Text = "PTTT: " + paymentMethod + "  |  " + GetOrderTypeText();
            UpdateOrderModeText();
        }

        private void TxtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (!updatingMoney) Recalculate();
        }

        private void TxtCustomerPay_TextChanged(object sender, EventArgs e)
        {
            if (!updatingMoney) Recalculate();
        }

        private void TxtMoney_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox == null) return;
            updatingMoney = true;
            textBox.Text = CafeTheme.Money(ParseMoney(textBox.Text));
            updatingMoney = false;
            Recalculate();
        }

        private void BtnHold_Click(object sender, EventArgs e)
        {
            if (!rdoDineIn.Checked)
            {
                MessageBox.Show("Đơn mang về không cần tạm giữ. Bạn có thể thanh toán trực tiếp.");
                return;
            }

            if (selectedTableId <= 0)
            {
                MessageBox.Show("Hãy chọn bàn trước khi tạm giữ.");
                return;
            }

            if (cart.Rows.Count == 0)
            {
                MessageBox.Show("Order chưa có món.");
                return;
            }

            try
            {
                int invoiceId = SaveInvoice("Đang phục vụ", false);
                MarkTableAsServing();
                MessageBox.Show("Đã tạm giữ order cho " + selectedTableName + ".\nMã order: HD" + invoiceId.ToString("0000"), "POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearCurrentOrder(true);
                LoadTables();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạm giữ order: " + ex.Message);
            }
        }

        private void BtnPay_Click(object sender, EventArgs e)
        {
            if (rdoDineIn.Checked && selectedTableId <= 0)
            {
                MessageBox.Show("Hãy chọn bàn cần thanh toán, hoặc đổi sang 'Mang về'.");
                return;
            }

            if (cart.Rows.Count == 0)
            {
                MessageBox.Show("Hóa đơn chưa có món.");
                return;
            }

            decimal subtotal = GetSubtotal();
            decimal discount = GetTotalDiscount(subtotal);
            decimal total = subtotal - discount;
            decimal paid = GetPaidAmount(total);
            decimal change = GetChange(total, paid);

            if (paymentMethod == "Tiền mặt" && paid < total)
            {
                MessageBox.Show("Khách đưa chưa đủ tiền.");
                return;
            }

            try
            {
                int invoiceId = SaveInvoice("Đã thanh toán", true);
                if (selectedCustomerId > 0)
                {
                    UpdateCustomerAfterPayment(total);
                }
                if (rdoDineIn.Checked)
                {
                    MarkTableAsEmpty();
                }

                string receiptPath = SaveReceipt(invoiceId, total, discount, paid, change);
                MessageBox.Show(
                    "Thanh toán thành công!\n" +
                    "Mã hóa đơn: HD" + invoiceId.ToString("0000") + "\n" +
                    "Loại đơn: " + GetOrderTypeText() + "\n" +
                    "Phương thức: " + paymentMethod + "\n" +
                    "File hóa đơn: " + receiptPath,
                    "POS",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ShowReceiptPreview(invoiceId, total, discount, paid, change);
                ClearCurrentOrder(true);
                ClearCustomerSelection();
                LoadTables();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thanh toán: " + ex.Message);
            }
        }

        private int SaveInvoice(string status, bool isPayment)
        {
            decimal subtotal = GetSubtotal();
            decimal discount = GetTotalDiscount(subtotal);
            decimal total = subtotal - discount;
            decimal paid = isPayment ? GetPaidAmount(total) : 0;
            decimal change = isPayment ? GetChange(total, paid) : 0;
            string method = isPayment ? paymentMethod : "Chưa thanh toán";
            string loaiDon = GetOrderTypeText();
            object maBanValue = rdoDineIn.Checked && selectedTableId > 0 ? (object)selectedTableId : DBNull.Value;
            object maKhValue = selectedCustomerId > 0 ? (object)selectedCustomerId : DBNull.Value;
            int invoiceId = currentInvoiceId;

            using (SqlConnection con = new SqlConnection(Db.ConnectionString))
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                try
                {
                    if (invoiceId > 0)
                    {
                        SqlCommand updateInvoice = new SqlCommand(@"UPDATE dbo.HoaDon
                            SET MaBan=@MaBan, MaNV=@MaNV, MaKH=@MaKH, NgayLap=GETDATE(), TrangThai=@TrangThai,
                                LoaiDon=@LoaiDon, PhuongThucThanhToan=@PhuongThucThanhToan,
                                TongTien=@TongTien, GiamGia=@GiamGia, KhachDua=@KhachDua, TienThoi=@TienThoi
                            WHERE MaHD=@MaHD", con, tran);
                        AddInvoiceParameters(updateInvoice, maBanValue, maKhValue, status, loaiDon, method, total, discount, paid, change);
                        updateInvoice.Parameters.AddWithValue("@MaHD", invoiceId);
                        updateInvoice.ExecuteNonQuery();

                        SqlCommand deleteDetails = new SqlCommand("DELETE FROM dbo.ChiTietHoaDon WHERE MaHD=@MaHD", con, tran);
                        deleteDetails.Parameters.AddWithValue("@MaHD", invoiceId);
                        deleteDetails.ExecuteNonQuery();
                    }
                    else
                    {
                        SqlCommand insertInvoice = new SqlCommand(@"INSERT INTO dbo.HoaDon(MaBan, MaNV, MaKH, NgayLap, TrangThai, LoaiDon, PhuongThucThanhToan, TongTien, GiamGia, KhachDua, TienThoi)
                            VALUES(@MaBan, @MaNV, @MaKH, GETDATE(), @TrangThai, @LoaiDon, @PhuongThucThanhToan, @TongTien, @GiamGia, @KhachDua, @TienThoi);
                            SELECT CAST(SCOPE_IDENTITY() AS INT);", con, tran);
                        AddInvoiceParameters(insertInvoice, maBanValue, maKhValue, status, loaiDon, method, total, discount, paid, change);
                        invoiceId = Convert.ToInt32(insertInvoice.ExecuteScalar());
                    }

                    foreach (DataRow row in cart.Rows)
                    {
                        SqlCommand detail = new SqlCommand(@"INSERT INTO dbo.ChiTietHoaDon(MaHD, MaMon, TenMon, Size, Topping, SoLuong, DonGia, ThanhTien)
                                                           VALUES(@MaHD, @MaMon, @TenMon, N'M', NULL, @SoLuong, @DonGia, @ThanhTien)", con, tran);
                        detail.Parameters.AddWithValue("@MaHD", invoiceId);
                        detail.Parameters.AddWithValue("@MaMon", Convert.ToInt32(row["MaMon"]));
                        detail.Parameters.AddWithValue("@TenMon", Convert.ToString(row["Tên món"]));
                        detail.Parameters.AddWithValue("@SoLuong", Convert.ToInt32(row["SL"]));
                        detail.Parameters.AddWithValue("@DonGia", Convert.ToDecimal(row["Đơn giá"]));
                        detail.Parameters.AddWithValue("@ThanhTien", Convert.ToDecimal(row["Thành tiền"]));
                        detail.ExecuteNonQuery();
                    }

                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }

            currentInvoiceId = invoiceId;
            return invoiceId;
        }

        private void AddInvoiceParameters(SqlCommand cmd, object maBanValue, object maKhValue, string status, string loaiDon, string method, decimal total, decimal discount, decimal paid, decimal change)
        {
            SqlParameter maBan = cmd.Parameters.Add("@MaBan", SqlDbType.Int);
            maBan.Value = maBanValue;
            SqlParameter maKh = cmd.Parameters.Add("@MaKH", SqlDbType.Int);
            maKh.Value = maKhValue;
            cmd.Parameters.AddWithValue("@MaNV", AppSession.MaNV);
            cmd.Parameters.AddWithValue("@TrangThai", status);
            cmd.Parameters.AddWithValue("@LoaiDon", loaiDon);
            cmd.Parameters.AddWithValue("@PhuongThucThanhToan", method);
            cmd.Parameters.AddWithValue("@TongTien", total);
            cmd.Parameters.AddWithValue("@GiamGia", discount);
            cmd.Parameters.AddWithValue("@KhachDua", paid);
            cmd.Parameters.AddWithValue("@TienThoi", change);
        }

        private void MarkTableAsServing()
        {
            if (selectedTableId <= 0) return;
            Db.Execute(@"UPDATE dbo.BanCafe
                         SET TrangThai=N'Đang phục vụ', SoNguoi=CASE WHEN SoNguoi=0 THEN 2 ELSE SoNguoi END,
                             ThoiGianVao=ISNULL(ThoiGianVao, GETDATE())
                         WHERE MaBan=@id", Db.P("@id", selectedTableId));
        }

        private void MarkTableAsEmpty()
        {
            if (selectedTableId <= 0) return;
            Db.Execute(@"UPDATE dbo.BanCafe
                         SET TrangThai=N'Trống', SoNguoi=0, ThoiGianVao=NULL
                         WHERE MaBan=@MaBan", Db.P("@MaBan", selectedTableId));
        }

        private void SelectPaymentMethod(string method)
        {
            paymentMethod = method;
            if (txtCustomerPay != null) txtCustomerPay.ReadOnly = paymentMethod != "Tiền mặt";
            StylePaymentButtons();
            Recalculate();
        }

        private void StylePaymentButtons()
        {
            SetPaymentButtonStyle(btnCash, paymentMethod == "Tiền mặt");
            SetPaymentButtonStyle(btnBank, paymentMethod == "Chuyển khoản");
            SetPaymentButtonStyle(btnCard, paymentMethod == "Thẻ");
        }

        private void SetPaymentButtonStyle(Button button, bool selected)
        {
            if (button == null) return;
            button.FlatAppearance.BorderSize = selected ? 3 : 0;
            button.FlatAppearance.BorderColor = Color.FromArgb(55, 38, 27);
        }

        private void FindCustomer()
        {
            string keyword = txtCustomerSearch.Text.Trim();
            if (keyword.Length == 0)
            {
                ClearCustomerSelection();
                Recalculate();
                return;
            }

            DataTable customer = Db.Query(@"SELECT TOP 1 MaKH, HoTen, SDT, ISNULL(SoLanMua,0) AS SoLanMua, ISNULL(TongChiTieu,0) AS TongChiTieu
                                            FROM dbo.KhachHang
                                            WHERE SDT=@kw OR HoTen LIKE N'%' + @kw + N'%'
                                            ORDER BY CASE WHEN SDT=@kw THEN 0 ELSE 1 END, SoLanMua DESC", Db.P("@kw", keyword));
            if (customer.Rows.Count == 0)
            {
                DialogResult create = MessageBox.Show("Không tìm thấy khách hàng. Tạo khách hàng mới từ thông tin đang nhập?", "Khách hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (create == DialogResult.Yes)
                {
                    CreateQuickCustomer(keyword);
                }
                return;
            }

            SelectCustomer(customer.Rows[0]);
            Recalculate();
        }

        private void CreateQuickCustomer(string text)
        {
            string phone = string.Empty;
            string name = text;
            bool looksLikePhone = true;
            foreach (char c in text)
            {
                if (!char.IsDigit(c) && c != '+' && c != ' ')
                {
                    looksLikePhone = false;
                    break;
                }
            }

            if (looksLikePhone)
            {
                phone = text.Trim();
                name = "Khách " + phone;
            }

            object id = Db.Scalar(@"INSERT INTO dbo.KhachHang(HoTen, SDT, SoLanMua, DiemTichLuy, TongChiTieu, GhiChu)
                                    VALUES(@HoTen, @SDT, 0, 0, 0, N'Tạo nhanh từ POS');
                                    SELECT CAST(SCOPE_IDENTITY() AS INT);",
                Db.P("@HoTen", name.Trim()),
                Db.P("@SDT", string.IsNullOrWhiteSpace(phone) ? (object)DBNull.Value : phone));
            DataTable customer = Db.Query("SELECT MaKH, HoTen, SDT, ISNULL(SoLanMua,0) AS SoLanMua, ISNULL(TongChiTieu,0) AS TongChiTieu FROM dbo.KhachHang WHERE MaKH=@id", Db.P("@id", Convert.ToInt32(id)));
            if (customer.Rows.Count > 0) SelectCustomer(customer.Rows[0]);
            Recalculate();
        }

        private void SelectCustomer(DataRow row)
        {
            selectedCustomerId = Convert.ToInt32(row["MaKH"]);
            selectedCustomerName = Convert.ToString(row["HoTen"]);
            selectedCustomerPurchaseCount = Convert.ToInt32(row["SoLanMua"]);
            txtCustomerSearch.Text = row["SDT"] == DBNull.Value || string.IsNullOrWhiteSpace(Convert.ToString(row["SDT"]))
                ? selectedCustomerName
                : Convert.ToString(row["SDT"]);
            UpdateCustomerInfoLabel();
        }

        private void ClearCustomerSelection()
        {
            selectedCustomerId = 0;
            selectedCustomerName = "Khách lẻ";
            selectedCustomerPurchaseCount = 0;
            if (txtCustomerSearch != null) txtCustomerSearch.Clear();
            if (lblCustomerInfo != null) lblCustomerInfo.Text = "Khách lẻ - không áp dụng giảm thân thiết";
        }

        private void UpdateCustomerInfoLabel()
        {
            string status = selectedCustomerPurchaseCount >= 5 ? "Khách thân thiết - giảm 5%" : "Chưa đủ 5 lần mua";
            lblCustomerInfo.Text = selectedCustomerName + " | Đã mua: " + selectedCustomerPurchaseCount.ToString("N0") + " lần | " + status;
        }

        private void UpdateCustomerAfterPayment(decimal paidTotal)
        {
            int points = Convert.ToInt32(Math.Floor(paidTotal / 10000m));
            Db.Execute(@"UPDATE dbo.KhachHang
                         SET SoLanMua = ISNULL(SoLanMua,0) + 1,
                             DiemTichLuy = ISNULL(DiemTichLuy,0) + @Diem,
                             TongChiTieu = ISNULL(TongChiTieu,0) + @TongTien
                         WHERE MaKH=@MaKH",
                Db.P("@Diem", points),
                Db.P("@TongTien", paidTotal),
                Db.P("@MaKH", selectedCustomerId));
        }

        private string SaveReceipt(int invoiceId, decimal total, decimal discount, decimal paid, decimal change)
        {
            string folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Receipts");
            Directory.CreateDirectory(folder);
            string file = Path.Combine(folder, "HD" + invoiceId.ToString("0000") + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt");
            File.WriteAllText(file, BuildReceiptText(invoiceId, total, discount, paid, change), Encoding.UTF8);
            return file;
        }

        private void ShowReceiptPreview(int invoiceId, decimal total, decimal discount, decimal paid, decimal change)
        {
            printReceiptText = BuildReceiptText(invoiceId, total, discount, paid, change);
            printPreviewReceipt.Text = "Print Preview - Hóa đơn";
            printPreviewReceipt.Width = 850;
            printPreviewReceipt.Height = 700;
            try
            {
                printPreviewReceipt.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không mở được Print Preview: " + ex.Message);
            }
        }

        private void PrintDocumentReceipt_PrintPage(object sender, PrintPageEventArgs e)
        {
            using (Font font = new Font("Consolas", 10F))
            using (Brush brush = new SolidBrush(Color.Black))
            {
                RectangleF area = new RectangleF(e.MarginBounds.Left, e.MarginBounds.Top, e.MarginBounds.Width, e.MarginBounds.Height);
                e.Graphics.DrawString(printReceiptText, font, brush, area);
            }
        }

        private string BuildReceiptText(int invoiceId, decimal total, decimal discount, decimal paid, decimal change)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(CafeTheme.StoreNameUpper);
            sb.AppendLine(CafeTheme.StoreAddress);
            sb.AppendLine("SĐT: " + CafeTheme.StorePhone);
            sb.AppendLine("--------------------------------");
            sb.AppendLine("HÓA ĐƠN THANH TOÁN");
            sb.AppendLine("Mã HĐ: " + (invoiceId == 0 ? "Xem trước" : "HD" + invoiceId.ToString("0000")));
            sb.AppendLine("Loại đơn: " + GetOrderTypeText());
            sb.AppendLine("Bàn: " + GetTableDisplayText());
            sb.AppendLine("Khách: " + selectedCustomerName);
            sb.AppendLine("Thu ngân: " + AppSession.HoTen);
            sb.AppendLine("Ngày: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            sb.AppendLine("Thanh toán: " + paymentMethod);
            sb.AppendLine("--------------------------------");
            foreach (DataRow row in cart.Rows)
            {
                sb.AppendLine(Convert.ToString(row["Tên món"]) + " x" + row["SL"] + "  " + CafeTheme.Money(Convert.ToDecimal(row["Thành tiền"])));
            }
            sb.AppendLine("--------------------------------");
            sb.AppendLine("Giảm giá: " + CafeTheme.Money(discount));
            sb.AppendLine("Tổng tiền: " + CafeTheme.Money(total));
            sb.AppendLine("Khách đưa: " + CafeTheme.Money(paid));
            sb.AppendLine("Tiền thối: " + CafeTheme.Money(change < 0 ? 0 : change));
            sb.AppendLine("Cảm ơn quý khách!");
            return sb.ToString();
        }

        private decimal GetSubtotal()
        {
            decimal subtotal = 0;
            foreach (DataRow row in cart.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    subtotal += Convert.ToDecimal(row["Thành tiền"]);
                }
            }
            return subtotal;
        }

        private decimal ParseMoney(string text)
        {
            return CafeTheme.ParseMoney(text);
        }

        private decimal NormalizeDiscount(decimal subtotal, decimal discount)
        {
            if (discount < 0) discount = 0;
            if (discount > subtotal) discount = subtotal;
            return discount;
        }

        private decimal GetLoyaltyDiscount(decimal subtotal)
        {
            if (selectedCustomerId <= 0 || selectedCustomerPurchaseCount < 5) return 0;
            return Math.Floor(subtotal * 0.05m);
        }

        private decimal GetTotalDiscount(decimal subtotal)
        {
            decimal manualDiscount = NormalizeDiscount(subtotal, ParseMoney(txtDiscount == null ? "0" : txtDiscount.Text));
            decimal loyaltyDiscount = GetLoyaltyDiscount(subtotal);
            return NormalizeDiscount(subtotal, manualDiscount + loyaltyDiscount);
        }

        private decimal GetPaidAmount(decimal total)
        {
            if (paymentMethod != "Tiền mặt") return total;
            return ParseMoney(txtCustomerPay == null ? "0" : txtCustomerPay.Text);
        }

        private decimal GetChange(decimal total, decimal paid)
        {
            decimal change = paid - total;
            return change < 0 ? 0 : change;
        }

        private string GetOrderTypeText()
        {
            return rdoTakeAway != null && rdoTakeAway.Checked ? "Mang về" : "Uống tại chỗ";
        }

        private string GetTableDisplayText()
        {
            if (rdoTakeAway.Checked) return "Mang về";
            return string.IsNullOrWhiteSpace(selectedTableName) ? "Chưa chọn bàn" : selectedTableName;
        }

        private void UpdateOrderModeText()
        {
            if (lblInvoice == null) return;
            string tableText = GetTableDisplayText();
            if (currentInvoiceId > 0)
            {
                lblInvoice.Text = "HÓA ĐƠN - " + tableText + " - HD" + currentInvoiceId.ToString("0000");
            }
            else
            {
                lblInvoice.Text = "HÓA ĐƠN - " + tableText;
            }
        }

        private void ClearCurrentOrder(bool resetTableSelection)
        {
            if (cart != null) cart.Rows.Clear();
            currentInvoiceId = 0;
            updatingMoney = true;
            txtDiscount.Text = CafeTheme.Money(0);
            txtCustomerPay.Text = CafeTheme.Money(0);
            updatingMoney = false;

            if (resetTableSelection)
            {
                selectedTableId = 0;
                selectedTableName = rdoTakeAway.Checked ? "Mang về" : string.Empty;
                lblSelectedTable.Text = rdoTakeAway.Checked ? "Đơn mang về" : "Uống tại chỗ: chọn bàn để order";
            }
            UpdateOrderModeText();
            Recalculate();
        }

        private string ResolveImagePath(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) return string.Empty;
            if (Path.IsPathRooted(path)) return path;
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
        }

        private string StatusText(string status)
        {
            if (status == "Trống" || status == "Trong") return "Trống";
            if (status == "Đang phục vụ" || status == "Dang phuc vu") return "Đang phục vụ";
            if (status == "Đặt trước" || status == "Dat truoc") return "Đặt trước";
            return status;
        }

        private Color StatusColor(string status)
        {
            if (status == "Đang phục vụ" || status == "Dang phuc vu") return CafeTheme.Orange;
            if (status == "Đặt trước" || status == "Dat truoc") return CafeTheme.Blue;
            return CafeTheme.Green;
        }
    }
}
