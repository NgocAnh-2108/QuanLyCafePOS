using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using QuanLyCafePOS.UI;

namespace QuanLyCafePOS.UI.Forms
{
    public partial class ReportViewerForm : Form
    {
        private string reportText = string.Empty;
        private DataTable summaryTable;
        private DataTable topTable;
        private DataTable paymentTable;
        private DataTable invoiceTable;

        public ReportViewerForm()
        {
            InitializeComponent();
        }

        public ReportViewerForm(DateTime fromDate, DateTime toDate, string revenue, string orders, string bestSeller, DataTable top, DataTable payment, DataTable invoices)
        {
            InitializeComponent();
            Text = "Report Viewer";
            lblTitle.Text = "REPORT VIEWER - BÁO CÁO DOANH THU";

            summaryTable = BuildSummaryTable(fromDate, toDate, revenue, orders, bestSeller);
            topTable = top == null ? new DataTable() : top.Copy();
            paymentTable = payment == null ? new DataTable() : payment.Copy();
            invoiceTable = invoices == null ? new DataTable() : invoices.Copy();

            gridSummary.DataSource = summaryTable;
            gridTop.DataSource = topTable;
            gridPayment.DataSource = paymentTable;
            gridInvoice.DataSource = invoiceTable;
            StyleAllGrids();

            reportText = BuildReportText(fromDate, toDate, revenue, orders, bestSeller, topTable, paymentTable, invoiceTable);
        }

        private void StyleAllGrids()
        {
            CafeTheme.StyleGrid(gridSummary);
            CafeTheme.StyleGrid(gridTop);
            CafeTheme.StyleGrid(gridPayment);
            CafeTheme.StyleGrid(gridInvoice);
            gridSummary.CellFormatting += GridMoneyFormatting;
            gridTop.CellFormatting += GridMoneyFormatting;
            gridPayment.CellFormatting += GridMoneyFormatting;
            gridInvoice.CellFormatting += GridMoneyFormatting;
        }

        private DataTable BuildSummaryTable(DateTime fromDate, DateTime toDate, string revenue, string orders, string bestSeller)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Chỉ tiêu", typeof(string));
            table.Columns.Add("Giá trị", typeof(string));
            table.Rows.Add("Từ ngày", fromDate.ToString("dd/MM/yyyy"));
            table.Rows.Add("Đến ngày", toDate.ToString("dd/MM/yyyy"));
            table.Rows.Add("Tổng doanh thu", revenue);
            table.Rows.Add("Số đơn", orders);
            table.Rows.Add("Món bán chạy", bestSeller);
            return table;
        }

        private void BtnPrintPreview_Click(object sender, EventArgs e)
        {
            printPreviewDialogReport.Text = "Print Preview - Báo cáo";
            printPreviewDialogReport.Width = 1000;
            printPreviewDialogReport.Height = 720;
            try
            {
                printPreviewDialogReport.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không mở được Print Preview: " + ex.Message);
            }
        }

        private void BtnSaveTxt_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Lưu report";
                sfd.Filter = "Text report UTF-8 (*.txt)|*.txt|CSV UTF-8 (*.csv)|*.csv";
                sfd.FileName = "Report_CafeCozy_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
                if (sfd.ShowDialog(this) != DialogResult.OK) return;

                string extension = Path.GetExtension(sfd.FileName).ToLowerInvariant();
                if (extension == ".csv")
                {
                    File.WriteAllText(sfd.FileName, BuildCsvReport(), new UTF8Encoding(true));
                }
                else
                {
                    File.WriteAllText(sfd.FileName, reportText, new UTF8Encoding(true));
                }
                MessageBox.Show("Đã lưu report:\n" + sfd.FileName, "Report Viewer", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PrintDocumentReport_PrintPage(object sender, PrintPageEventArgs e)
        {
            using (Font font = new Font("Consolas", 9.5F))
            using (Brush brush = new SolidBrush(Color.Black))
            {
                RectangleF area = new RectangleF(e.MarginBounds.Left, e.MarginBounds.Top, e.MarginBounds.Width, e.MarginBounds.Height);
                e.Graphics.DrawString(reportText, font, brush, area);
            }
        }

        private void GridMoneyFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (grid != null) CafeTheme.FormatMoneyCell(grid, e);
        }

        private string BuildReportText(DateTime fromDate, DateTime toDate, string revenue, string orders, string bestSeller, DataTable top, DataTable payment, DataTable invoices)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("BÁO CÁO DOANH THU");
            sb.AppendLine("Từ ngày: " + fromDate.ToString("dd/MM/yyyy") + "    Đến ngày: " + toDate.ToString("dd/MM/yyyy"));
            sb.AppendLine(new string('=', 110));
            AppendFixedTable(sb, "TỔNG HỢP", summaryTable);
            sb.AppendLine();
            AppendFixedTable(sb, "TOP MÓN BÁN CHẠY", top);
            sb.AppendLine();
            AppendFixedTable(sb, "DOANH THU THEO PHƯƠNG THỨC THANH TOÁN", payment);
            sb.AppendLine();
            AppendFixedTable(sb, "DANH SÁCH HÓA ĐƠN", invoices);
            return sb.ToString();
        }

        private void AppendFixedTable(StringBuilder sb, string title, DataTable table)
        {
            sb.AppendLine(title);
            if (table == null || table.Columns.Count == 0 || table.Rows.Count == 0)
            {
                sb.AppendLine("Không có dữ liệu");
                return;
            }

            int[] widths = CalculateWidths(table);
            AppendRow(sb, table, widths, true, null);
            sb.AppendLine(BuildSeparator(widths));
            foreach (DataRow row in table.Rows)
            {
                AppendRow(sb, table, widths, false, row);
            }
        }

        private int[] CalculateWidths(DataTable table)
        {
            int[] widths = new int[table.Columns.Count];
            for (int i = 0; i < table.Columns.Count; i++)
            {
                widths[i] = Math.Min(Math.Max(table.Columns[i].ColumnName.Length, 10), 26);
            }

            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    string text = FormatCell(row[i]);
                    widths[i] = Math.Min(Math.Max(widths[i], text.Length), 30);
                }
            }
            return widths;
        }

        private void AppendRow(StringBuilder sb, DataTable table, int[] widths, bool header, DataRow row)
        {
            for (int i = 0; i < table.Columns.Count; i++)
            {
                if (i > 0) sb.Append(" | ");
                string text = header ? table.Columns[i].ColumnName : FormatCell(row[i]);
                sb.Append(TrimToWidth(text, widths[i]).PadRight(widths[i]));
            }
            sb.AppendLine();
        }

        private string BuildSeparator(int[] widths)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < widths.Length; i++)
            {
                if (i > 0) sb.Append("-+-");
                sb.Append(new string('-', widths[i]));
            }
            return sb.ToString();
        }

        private string TrimToWidth(string text, int width)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;
            if (text.Length <= width) return text;
            if (width <= 3) return text.Substring(0, width);
            return text.Substring(0, width - 3) + "...";
        }

        private string BuildCsvReport()
        {
            StringBuilder sb = new StringBuilder();
            AppendCsvTable(sb, "TỔNG HỢP", summaryTable);
            AppendCsvTable(sb, "TOP MÓN BÁN CHẠY", topTable);
            AppendCsvTable(sb, "DOANH THU THEO PHƯƠNG THỨC THANH TOÁN", paymentTable);
            AppendCsvTable(sb, "DANH SÁCH HÓA ĐƠN", invoiceTable);
            return sb.ToString();
        }

        private void AppendCsvTable(StringBuilder sb, string title, DataTable table)
        {
            sb.AppendLine(title);
            if (table == null || table.Columns.Count == 0)
            {
                sb.AppendLine("Không có dữ liệu");
                sb.AppendLine();
                return;
            }
            for (int i = 0; i < table.Columns.Count; i++)
            {
                if (i > 0) sb.Append(',');
                sb.Append(CsvEscape(table.Columns[i].ColumnName));
            }
            sb.AppendLine();
            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    if (i > 0) sb.Append(',');
                    sb.Append(CsvEscape(FormatCell(row[i])));
                }
                sb.AppendLine();
            }
            sb.AppendLine();
        }

        private string CsvEscape(string text)
        {
            if (text == null) text = string.Empty;
            return "\"" + text.Replace("\"", "\"\"") + "\"";
        }

        private string FormatCell(object value)
        {
            if (value == null || value == DBNull.Value) return string.Empty;
            if (value is DateTime) return ((DateTime)value).ToString("dd/MM/yyyy HH:mm");
            if (value is decimal) return CafeTheme.Money(Convert.ToDecimal(value));
            if (value is double || value is float) return CafeTheme.Money(Convert.ToDecimal(value));
            if (value is int) return Convert.ToInt32(value).ToString("N0");
            if (value is long) return Convert.ToInt64(value).ToString("N0");
            return Convert.ToString(value);
        }
    }
}
