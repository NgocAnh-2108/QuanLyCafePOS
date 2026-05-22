using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using QuanLyCafePOS.Data;
using QuanLyCafePOS.UI;
using QuanLyCafePOS.UI.Forms;

namespace QuanLyCafePOS.UI.Controls
{
    public partial class ReportControl : UserControl
    {
        private bool dataLoaded;
        private DataTable lastTop;
        private DataTable lastInvoices;
        private DataTable lastPayment;

        public ReportControl()
        {
            InitializeComponent();
            CafeTheme.StyleGrid(gridTop);
            CafeTheme.StyleGrid(gridPayment);
            CafeTheme.StyleGrid(gridInvoice);
            gridTop.CellFormatting += GridMoneyFormatting;
            gridPayment.CellFormatting += GridMoneyFormatting;
            gridInvoice.CellFormatting += GridMoneyFormatting;
            dtFrom.Value = DateTime.Today.AddDays(-6);
            dtTo.Value = DateTime.Today;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!IsInDesignMode() && !dataLoaded)
            {
                LoadReport();
                dataLoaded = true;
            }
        }

        private void GridMoneyFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (grid != null) CafeTheme.FormatMoneyCell(grid, e);
        }

        private bool IsInDesignMode()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode;
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            if (lastTop == null || lastInvoices == null || lastPayment == null)
            {
                LoadReport();
            }

            using (ReportViewerForm viewer = new ReportViewerForm(
                dtFrom.Value.Date,
                dtTo.Value.Date,
                lblRevenue.Text,
                lblOrders.Text,
                lblBestSeller.Text,
                lastTop,
                lastPayment,
                lastInvoices))
            {
                viewer.ShowDialog(this);
            }
        }

        private void LoadReport()
        {
            try
            {
                DateTime from = dtFrom.Value.Date;
                DateTime to = dtTo.Value.Date.AddDays(1).AddSeconds(-1);

                object revenueObj = Db.Scalar(@"SELECT ISNULL(SUM(TongTien),0)
                                                FROM dbo.HoaDon
                                                WHERE TrangThai=N'Đã thanh toán' AND NgayLap BETWEEN @from AND @to",
                    Db.P("@from", from), Db.P("@to", to));
                decimal revenue = Convert.ToDecimal(revenueObj);
                lblRevenue.Text = CafeTheme.Money(revenue);

                object ordersObj = Db.Scalar(@"SELECT COUNT(*) FROM dbo.HoaDon
                                               WHERE TrangThai=N'Đã thanh toán' AND NgayLap BETWEEN @from AND @to",
                    Db.P("@from", from), Db.P("@to", to));
                lblOrders.Text = Convert.ToInt32(ordersObj).ToString("N0") + " đơn";

                object best = Db.Scalar(@"SELECT TOP 1 c.TenMon
                                           FROM dbo.ChiTietHoaDon c INNER JOIN dbo.HoaDon h ON c.MaHD=h.MaHD
                                           WHERE h.TrangThai=N'Đã thanh toán' AND h.NgayLap BETWEEN @from AND @to
                                           GROUP BY c.TenMon
                                           ORDER BY SUM(c.SoLuong) DESC",
                    Db.P("@from", from), Db.P("@to", to));
                lblBestSeller.Text = best == null || best == DBNull.Value ? "Chưa có" : Convert.ToString(best);

                lastTop = Db.Query(@"SELECT TOP 10 c.TenMon AS [Tên món], SUM(c.SoLuong) AS [Số lượng], SUM(c.ThanhTien) AS [Doanh thu]
                                           FROM dbo.ChiTietHoaDon c INNER JOIN dbo.HoaDon h ON c.MaHD=h.MaHD
                                           WHERE h.TrangThai=N'Đã thanh toán' AND h.NgayLap BETWEEN @from AND @to
                                           GROUP BY c.TenMon
                                           ORDER BY SUM(c.SoLuong) DESC",
                    Db.P("@from", from), Db.P("@to", to));
                gridTop.DataSource = lastTop;

                lastInvoices = Db.Query(@"SELECT TOP 100 h.MaHD AS [Mã HD], h.NgayLap AS [Ngày lập],
                                                       ISNULL(h.LoaiDon, CASE WHEN h.MaBan IS NULL THEN N'Mang về' ELSE N'Uống tại chỗ' END) AS [Loại đơn],
                                                       ISNULL(b.TenBan, N'Mang về') AS [Bàn],
                                                       ISNULL(k.HoTen, N'Khách lẻ') AS [Khách hàng],
                                                       ISNULL(nv.HoTen,N'Đã xóa') AS [Thu ngân], ISNULL(h.PhuongThucThanhToan, N'') AS [Thanh toán],
                                                       h.TongTien AS [Tổng tiền], h.GiamGia AS [Giảm giá]
                                                FROM dbo.HoaDon h
                                                LEFT JOIN dbo.BanCafe b ON h.MaBan=b.MaBan
                                                LEFT JOIN dbo.KhachHang k ON h.MaKH=k.MaKH
                                                LEFT JOIN dbo.NhanVien nv ON h.MaNV=nv.MaNV
                                                WHERE h.TrangThai=N'Đã thanh toán' AND h.NgayLap BETWEEN @from AND @to
                                                ORDER BY h.MaHD DESC",
                    Db.P("@from", from), Db.P("@to", to));
                gridInvoice.DataSource = lastInvoices;

                lastPayment = Db.Query(@"SELECT ISNULL(PhuongThucThanhToan, N'Không rõ') AS [Phương thức], COUNT(*) AS [Số đơn], SUM(TongTien) AS [Doanh thu]
                                          FROM dbo.HoaDon
                                          WHERE TrangThai=N'Đã thanh toán' AND NgayLap BETWEEN @from AND @to
                                          GROUP BY ISNULL(PhuongThucThanhToan, N'Không rõ')
                                          ORDER BY SUM(TongTien) DESC",
                    Db.P("@from", from), Db.P("@to", to));
                gridPayment.DataSource = lastPayment;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải báo cáo: " + ex.Message);
            }
        }
    }
}
