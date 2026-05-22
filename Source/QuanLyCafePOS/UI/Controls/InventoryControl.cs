using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using QuanLyCafePOS.Data;
using QuanLyCafePOS.Models;
using QuanLyCafePOS.UI;

namespace QuanLyCafePOS.UI.Controls
{
    public partial class InventoryControl : UserControl
    {
        private bool dataLoaded;
        private bool loadingIngredients;
        private bool loadingAdminGrid;
        private readonly CultureInfo vi = CultureInfo.GetCultureInfo("vi-VN");

        public InventoryControl()
        {
            InitializeComponent();
            CafeTheme.StyleGrid(gridIngredients);
            CafeTheme.StyleGrid(gridCheckHistory);
            gridIngredients.CellFormatting += GridStockFormatting;
            gridCheckHistory.CellFormatting += GridStockFormatting;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!IsInDesignMode() && !dataLoaded)
            {
                ApplyPermissions();
                LoadData();
                dataLoaded = true;
            }
        }

        private bool IsInDesignMode()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode;
        }

        private void ApplyPermissions()
        {
            bool admin = AppSession.IsAdmin;

            adminPanel.Visible = admin;
            gridIngredients.Visible = admin;
            checkPanel.Visible = !admin;

            if (admin)
            {
                lblTitle.Text = "Kho nguyên liệu";
                lblHistoryTitle.Text = "Lịch sử kiểm hàng cuối ngày";
                rootLayout.RowStyles[1].Height = 220;
                rootLayout.RowStyles[2].Height = 210;
                rootLayout.RowStyles[3].Height = 0;
                rootLayout.RowStyles[4].Height = 48;
            }
            else
            {
                lblTitle.Text = "Kiểm hàng cuối ngày";
                lblHistoryTitle.Text = "Lịch sử kiểm hàng gần đây";
                rootLayout.RowStyles[1].Height = 0;
                rootLayout.RowStyles[2].Height = 0;
                rootLayout.RowStyles[3].Height = 150;
                rootLayout.RowStyles[4].Height = 48;
            }
        }

        private void LoadData()
        {
            if (AppSession.IsAdmin)
            {
                LoadAdminIngredients();
            }
            else
            {
                LoadCheckIngredients();
            }

            LoadCheckHistory();
        }

        private void BtnReloadAll_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BtnReloadHistory_Click(object sender, EventArgs e)
        {
            LoadCheckHistory();
        }

        
        private void LoadAdminIngredients()
        {
            loadingAdminGrid = true;
            try
            {
                gridIngredients.DataSource = Db.Query(@"SELECT MaNL AS [Mã],
                                                               TenNL AS [Tên nguyên liệu],
                                                               DonVi AS [Đơn vị],
                                                               TonKho AS [Tồn kho],
                                                               TonToiThieu AS [Tồn tối thiểu],
                                                               ISNULL(GhiChu,N'') AS [Ghi chú]
                                                        FROM dbo.NguyenLieu
                                                        ORDER BY TenNL");

                if (gridIngredients.Columns.Contains("Mã"))
                {
                    gridIngredients.Columns["Mã"].Width = 60;
                    gridIngredients.Columns["Mã"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nguyên liệu: " + ex.Message);
            }
            finally
            {
                loadingAdminGrid = false;
                ShowSelectedAdminIngredient();
            }
        }

        private void BtnAddIngredient_Click(object sender, EventArgs e)
        {
            if (!EnsureAdmin()) return;

            decimal stock;
            decimal minimum;
            if (!ValidateIngredientInput(out stock, out minimum)) return;

            try
            {
                Db.Execute(@"INSERT INTO dbo.NguyenLieu(TenNL, DonVi, TonKho, TonToiThieu, GhiChu)
                             VALUES(@TenNL, @DonVi, @TonKho, @TonToiThieu, @GhiChu)",
                    Db.P("@TenNL", txtIngredientName.Text.Trim()),
                    Db.P("@DonVi", txtIngredientUnit.Text.Trim()),
                    Db.P("@TonKho", stock),
                    Db.P("@TonToiThieu", minimum),
                    Db.P("@GhiChu", EmptyToDbNull(txtIngredientNote.Text)));

                MessageBox.Show("Đã thêm nguyên liệu.");
                ClearIngredientInput();
                LoadAdminIngredients();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm nguyên liệu: " + ex.Message);
            }
        }

        private void BtnUpdateIngredient_Click(object sender, EventArgs e)
        {
            if (!EnsureAdmin()) return;

            int ingredientId;
            if (!TryGetSelectedIngredientId(out ingredientId))
            {
                MessageBox.Show("Chọn nguyên liệu cần sửa trong bảng.");
                return;
            }

            decimal stock;
            decimal minimum;
            if (!ValidateIngredientInput(out stock, out minimum)) return;

            try
            {
                Db.Execute(@"UPDATE dbo.NguyenLieu
                             SET TenNL=@TenNL, DonVi=@DonVi, TonKho=@TonKho, TonToiThieu=@TonToiThieu, GhiChu=@GhiChu
                             WHERE MaNL=@MaNL",
                    Db.P("@TenNL", txtIngredientName.Text.Trim()),
                    Db.P("@DonVi", txtIngredientUnit.Text.Trim()),
                    Db.P("@TonKho", stock),
                    Db.P("@TonToiThieu", minimum),
                    Db.P("@GhiChu", EmptyToDbNull(txtIngredientNote.Text)),
                    Db.P("@MaNL", ingredientId));

                MessageBox.Show("Đã sửa nguyên liệu.");
                LoadAdminIngredients();
                SelectAdminIngredient(ingredientId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa nguyên liệu: " + ex.Message);
            }
        }

        private void BtnDeleteIngredient_Click(object sender, EventArgs e)
        {
            if (!EnsureAdmin()) return;

            int ingredientId;
            if (!TryGetSelectedIngredientId(out ingredientId))
            {
                MessageBox.Show("Chọn nguyên liệu cần xóa trong bảng.");
                return;
            }

            string ingredientName = txtIngredientName.Text.Trim();
            DialogResult result = MessageBox.Show(
                "Xóa nguyên liệu này khỏi database?\nNếu nguyên liệu đã có lịch sử nhập/kiểm hàng thì hệ thống sẽ xóa luôn lịch sử liên quan.",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = Db.Open())
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    ExecuteInTransaction(conn, tran, "DELETE FROM dbo.KiemKeKho WHERE MaNL=@MaNL", ingredientId);
                    ExecuteInTransaction(conn, tran, "DELETE FROM dbo.ChiTietNhapKho WHERE MaNL=@MaNL", ingredientId);
                    ExecuteInTransaction(conn, tran, "DELETE FROM dbo.NguyenLieu WHERE MaNL=@MaNL", ingredientId);
                    tran.Commit();
                }

                MessageBox.Show("Đã xóa nguyên liệu: " + ingredientName);
                ClearIngredientInput();
                LoadAdminIngredients();
                LoadCheckHistory();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa nguyên liệu: " + ex.Message);
            }
        }

        private void BtnClearIngredient_Click(object sender, EventArgs e)
        {
            ClearIngredientInput();
        }

        private void GridIngredients_SelectionChanged(object sender, EventArgs e)
        {
            if (!loadingAdminGrid)
            {
                ShowSelectedAdminIngredient();
            }
        }

        private void ExecuteInTransaction(SqlConnection conn, SqlTransaction tran, string sql, int ingredientId)
        {
            using (SqlCommand cmd = new SqlCommand(sql, conn, tran))
            {
                cmd.Parameters.AddWithValue("@MaNL", ingredientId);
                cmd.ExecuteNonQuery();
            }
        }

        private bool EnsureAdmin()
        {
            if (AppSession.IsAdmin) return true;
            MessageBox.Show("Chỉ admin mới được thêm, sửa, xóa nguyên liệu.");
            return false;
        }

        private bool ValidateIngredientInput(out decimal stock, out decimal minimum)
        {
            stock = 0;
            minimum = 0;

            if (string.IsNullOrWhiteSpace(txtIngredientName.Text))
            {
                MessageBox.Show("Nhập tên nguyên liệu.");
                txtIngredientName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtIngredientUnit.Text))
            {
                MessageBox.Show("Nhập đơn vị, ví dụ: kg, lít, cái.");
                txtIngredientUnit.Focus();
                return false;
            }

            if (!TryParseDecimal(txtIngredientStock.Text, out stock) || stock < 0)
            {
                MessageBox.Show("Tồn kho phải là số lớn hơn hoặc bằng 0.");
                txtIngredientStock.Focus();
                txtIngredientStock.SelectAll();
                return false;
            }

            if (!TryParseDecimal(txtIngredientMinimum.Text, out minimum) || minimum < 0)
            {
                MessageBox.Show("Tồn tối thiểu phải là số lớn hơn hoặc bằng 0.");
                txtIngredientMinimum.Focus();
                txtIngredientMinimum.SelectAll();
                return false;
            }

            return true;
        }

        private void ClearIngredientInput()
        {
            txtIngredientName.Text = string.Empty;
            txtIngredientUnit.Text = string.Empty;
            txtIngredientStock.Text = "0";
            txtIngredientMinimum.Text = "0";
            txtIngredientNote.Text = string.Empty;

            loadingAdminGrid = true;
            try
            {
                gridIngredients.ClearSelection();
                gridIngredients.CurrentCell = null;
            }
            catch
            {
            }
            finally
            {
                loadingAdminGrid = false;
            }

            txtIngredientName.Focus();
        }

        private void ShowSelectedAdminIngredient()
        {
            if (!AppSession.IsAdmin) return;

            if (gridIngredients.CurrentRow == null || gridIngredients.CurrentRow.IsNewRow)
            {
                return;
            }

            DataGridViewRow row = gridIngredients.CurrentRow;
            txtIngredientName.Text = GetCellText(row, "Tên nguyên liệu");
            txtIngredientUnit.Text = GetCellText(row, "Đơn vị");
            txtIngredientStock.Text = ToDecimal(row.Cells["Tồn kho"].Value).ToString("N2", vi);
            txtIngredientMinimum.Text = ToDecimal(row.Cells["Tồn tối thiểu"].Value).ToString("N2", vi);
            txtIngredientNote.Text = GetCellText(row, "Ghi chú");
        }

        private string GetCellText(DataGridViewRow row, string columnName)
        {
            if (!row.DataGridView.Columns.Contains(columnName)) return string.Empty;
            object value = row.Cells[columnName].Value;
            if (value == null || value == DBNull.Value) return string.Empty;
            return Convert.ToString(value);
        }

        private bool TryGetSelectedIngredientId(out int ingredientId)
        {
            ingredientId = 0;
            if (gridIngredients.CurrentRow == null || gridIngredients.CurrentRow.IsNewRow) return false;
            object value = gridIngredients.CurrentRow.Cells["Mã"].Value;
            return value != null && value != DBNull.Value && int.TryParse(Convert.ToString(value), out ingredientId);
        }

        private void SelectAdminIngredient(int ingredientId)
        {
            foreach (DataGridViewRow row in gridIngredients.Rows)
            {
                if (row.IsNewRow) continue;
                int id;
                object value = row.Cells["Mã"].Value;
                if (value != null && int.TryParse(Convert.ToString(value), out id) && id == ingredientId)
                {
                    row.Selected = true;
                    gridIngredients.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }

        private object EmptyToDbNull(string text)
        {
            return string.IsNullOrWhiteSpace(text) ? (object)DBNull.Value : text.Trim();
        }

        // =========================
        // Nhân viên: kiểm hàng cuối ngày
        // =========================
        private void LoadCheckIngredients()
        {
            loadingIngredients = true;
            try
            {
                DataTable data = Db.Query(@"SELECT MaNL, TenNL, DonVi, TonKho
                                            FROM dbo.NguyenLieu
                                            ORDER BY TenNL");

                if (!data.Columns.Contains("HienThi"))
                {
                    data.Columns.Add("HienThi", typeof(string));
                }

                foreach (DataRow row in data.Rows)
                {
                    row["HienThi"] = Convert.ToString(row["TenNL"]) + " (" + Convert.ToString(row["DonVi"]) + ")";
                }

                cboIngredient.DataSource = data;
                cboIngredient.DisplayMember = "HienThi";
                cboIngredient.ValueMember = "MaNL";

                if (cboIngredient.Items.Count > 0)
                {
                    cboIngredient.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải nguyên liệu: " + ex.Message);
            }
            finally
            {
                loadingIngredients = false;
                ShowSelectedCheckIngredient();
            }
        }

        private void CboIngredient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadingIngredients)
            {
                ShowSelectedCheckIngredient();
            }
        }

        private void ShowSelectedCheckIngredient()
        {
            DataRowView row = cboIngredient.SelectedItem as DataRowView;
            if (row == null)
            {
                txtSystemStock.Text = string.Empty;
                txtActualStock.Text = string.Empty;
                lblUnit.Text = string.Empty;
                return;
            }

            decimal stock = ToDecimal(row["TonKho"]);
            string unit = Convert.ToString(row["DonVi"]);
            txtSystemStock.Text = stock.ToString("N2", vi);
            txtActualStock.Text = stock.ToString("N2", vi);
            lblUnit.Text = unit;
            txtNote.Text = string.Empty;
            txtActualStock.SelectAll();
            txtActualStock.Focus();
        }


        private void BtnAddCheck_Click(object sender, EventArgs e)
        {
            SaveSingleCheck();
        }

        private void BtnSaveCheck_Click(object sender, EventArgs e)
        {
            SaveSingleCheck();
        }

        private void BtnClearCheck_Click(object sender, EventArgs e)
        {
            ShowSelectedCheckIngredient();
        }

        private void TxtActualStock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SaveSingleCheck();
            }
        }

        private void SaveSingleCheck()
        {
            if (AppSession.IsAdmin)
            {
                MessageBox.Show("Admin quản lý nguyên liệu và xem lịch sử kiểm hàng. Nhân viên bấm Lưu kiểm hàng để lưu kiểm hàng cuối ngày.");
                return;
            }

            DataRowView row = cboIngredient.SelectedItem as DataRowView;
            if (row == null)
            {
                MessageBox.Show("Chọn nguyên liệu cần kiểm.");
                return;
            }

            decimal actualStock;
            if (!TryParseDecimal(txtActualStock.Text, out actualStock) || actualStock < 0)
            {
                MessageBox.Show("Tồn thực tế phải là số lớn hơn hoặc bằng 0.");
                txtActualStock.Focus();
                txtActualStock.SelectAll();
                return;
            }

            int ingredientId = Convert.ToInt32(row["MaNL"]);
            string ingredientName = Convert.ToString(row["TenNL"]);
            decimal systemStock = ToDecimal(row["TonKho"]);
            decimal difference = actualStock - systemStock;
            string note = txtNote.Text.Trim();

            try
            {
                using (SqlConnection conn = Db.Open())
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    using (SqlCommand insert = new SqlCommand(@"INSERT INTO dbo.KiemKeKho(MaNL, MaNV, TonHeThong, TonThucTe, ChenhLech, GhiChu)
                                                              VALUES(@MaNL, @MaNV, @TonHeThong, @TonThucTe, @ChenhLech, @GhiChu)", conn, tran))
                    {
                        insert.Parameters.AddWithValue("@MaNL", ingredientId);
                        insert.Parameters.AddWithValue("@MaNV", AppSession.MaNV);
                        insert.Parameters.AddWithValue("@TonHeThong", systemStock);
                        insert.Parameters.AddWithValue("@TonThucTe", actualStock);
                        insert.Parameters.AddWithValue("@ChenhLech", difference);
                        insert.Parameters.AddWithValue("@GhiChu", string.IsNullOrWhiteSpace(note) ? (object)DBNull.Value : note);
                        insert.ExecuteNonQuery();
                    }

                    using (SqlCommand update = new SqlCommand("UPDATE dbo.NguyenLieu SET TonKho=@TonKho WHERE MaNL=@MaNL", conn, tran))
                    {
                        update.Parameters.AddWithValue("@TonKho", actualStock);
                        update.Parameters.AddWithValue("@MaNL", ingredientId);
                        update.ExecuteNonQuery();
                    }

                    tran.Commit();
                }

                MessageBox.Show("Đã lưu kiểm hàng cho: " + ingredientName);
                LoadCheckIngredients();
                SelectCheckIngredient(ingredientId);
                LoadCheckHistory();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu kiểm hàng: " + ex.Message);
            }
        }

        private void SelectCheckIngredient(int ingredientId)
        {
            try
            {
                cboIngredient.SelectedValue = ingredientId;
            }
            catch
            {
                if (cboIngredient.Items.Count > 0) cboIngredient.SelectedIndex = 0;
            }
        }

        // =========================
        // Lịch sử kiểm hàng
        // =========================
        private void LoadCheckHistory()
        {
            try
            {
                gridCheckHistory.DataSource = Db.Query(@"SELECT TOP 200 kk.NgayKiemKe AS [Ngày kiểm],
                                                                 ISNULL(nv.HoTen,N'Đã xóa') AS [Người kiểm],
                                                                 nl.TenNL AS [Nguyên liệu],
                                                                 nl.DonVi AS [Đơn vị],
                                                                 kk.TonHeThong AS [Tồn hệ thống],
                                                                 kk.TonThucTe AS [Tồn thực tế],
                                                                 kk.ChenhLech AS [Chênh lệch],
                                                                 ISNULL(kk.GhiChu,N'') AS [Ghi chú]
                                                          FROM dbo.KiemKeKho kk
                                                          INNER JOIN dbo.NguyenLieu nl ON kk.MaNL=nl.MaNL
                                                          LEFT JOIN dbo.NhanVien nv ON kk.MaNV=nv.MaNV
                                                          ORDER BY kk.MaKK DESC");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lịch sử kiểm hàng: " + ex.Message);
            }
        }

        private bool TryParseDecimal(string text, out decimal value)
        {
            value = 0;
            if (string.IsNullOrWhiteSpace(text)) return false;

            string clean = text.Replace("VNĐ", "").Replace("VND", "").Replace("vnd", "").Trim();
            return decimal.TryParse(clean, NumberStyles.Any, vi, out value)
                || decimal.TryParse(clean, NumberStyles.Any, CultureInfo.InvariantCulture, out value);
        }

        private decimal ToDecimal(object value)
        {
            if (value == null || value == DBNull.Value) return 0;
            if (value is decimal) return (decimal)value;
            if (value is int || value is long || value is float || value is double) return Convert.ToDecimal(value, CultureInfo.InvariantCulture);

            decimal number;
            return TryParseDecimal(Convert.ToString(value), out number) ? number : 0;
        }

        private void GridStockFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (grid == null || e.RowIndex < 0 || e.Value == null || e.Value == DBNull.Value) return;

            string header = grid.Columns[e.ColumnIndex].HeaderText;
            if (header.Contains("Tồn") || header.Contains("Chênh"))
            {
                e.Value = ToDecimal(e.Value).ToString("N2", vi);
                e.FormattingApplied = true;
            }
        }
    }
}
