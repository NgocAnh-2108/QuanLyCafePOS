using System;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QuanLyCafePOS.UI
{
    public static class CafeTheme
    {
        public const string StoreName = "Cafe Cozy";
        public const string StoreNameUpper = "CAFE COZY";
        public const string StoreAddress = "96 Thông Thiên Học, Đà Lạt";
        public const string StorePhone = "0979058531";

        public static readonly Color Brown = Color.FromArgb(92, 49, 20);
        public static readonly Color DarkBrown = Color.FromArgb(64, 34, 14);
        public static readonly Color Cream = Color.FromArgb(255, 248, 238);
        public static readonly Color Card = Color.FromArgb(255, 252, 247);
        public static readonly Color Border = Color.FromArgb(224, 209, 190);
        public static readonly Color Green = Color.FromArgb(56, 121, 61);
        public static readonly Color Orange = Color.FromArgb(236, 132, 28);
        public static readonly Color Blue = Color.FromArgb(43, 112, 171);
        public static readonly Color Red = Color.FromArgb(196, 55, 45);
        public static readonly Color Purple = Color.FromArgb(116, 81, 164);
        public static readonly Color Text = Color.FromArgb(55, 38, 27);

        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

        public static Font Font(float size, FontStyle style)
        {
            return new Font("Segoe UI", size, style);
        }

        public static Font Font(float size)
        {
            return new Font("Segoe UI", size, FontStyle.Regular);
        }

        public static Button Button(string text, Color backColor)
        {
            Button button = new Button();
            button.Text = text;
            button.BackColor = backColor;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = Font(9.5f, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
            button.UseVisualStyleBackColor = false;
            return button;
        }

        public static Label Label(string text, float size, FontStyle style, Color color)
        {
            Label label = new Label();
            label.Text = text;
            label.Font = Font(size, style);
            label.ForeColor = color;
            label.AutoSize = true;
            return label;
        }

        public static Panel CardPanel()
        {
            Panel panel = new Panel();
            panel.BackColor = Card;
            panel.Padding = new Padding(12);
            panel.BorderStyle = BorderStyle.FixedSingle;
            return panel;
        }

        public static void StyleGrid(DataGridView grid)
        {
            grid.BackgroundColor = Card;
            grid.BorderStyle = BorderStyle.FixedSingle;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.RowHeadersVisible = false;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Brown;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = Font(9, FontStyle.Bold);
            grid.DefaultCellStyle.Font = Font(9);
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(221, 238, 220);
            grid.DefaultCellStyle.SelectionForeColor = Text;
        }

        public static string MoneyNumber(decimal value)
        {
            return value.ToString("#,##0", CultureInfo.GetCultureInfo("vi-VN"));
        }

        public static string Money(decimal value)
        {
            return MoneyNumber(value) + " VNĐ";
        }

        public static decimal ParseMoney(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return 0;
            text = text.Replace("VNĐ", "").Replace("vnđ", "").Replace("VND", "").Replace("vnd", "")
                       .Replace("₫", "")
                       .Replace("đ", "")
                       .Replace("Đ", "")
                       .Replace(" ", "")
                       .Replace(".", "")
                       .Replace(",", "")
                       .Trim();
            decimal value;
            return decimal.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out value) ? value : 0;
        }

        public static void FormatMoneyCell(DataGridView grid, DataGridViewCellFormattingEventArgs e)
        {
            if (grid == null || e == null || e.Value == null || e.Value == DBNull.Value) return;
            string columnName = grid.Columns[e.ColumnIndex].HeaderText;
            if (string.IsNullOrWhiteSpace(columnName)) columnName = grid.Columns[e.ColumnIndex].Name;

            bool isPhoneColumn = columnName.Contains("SĐT")
                || columnName.Contains("SDT")
                || columnName.Contains("Điện thoại")
                || columnName.Contains("Dien thoai")
                || columnName.Contains("Số điện thoại");
            if (isPhoneColumn) return;

            bool isMoneyColumn = columnName.Contains("Giá")
                || columnName.Contains("Tiền")
                || columnName.Contains("Doanh thu")
                || columnName.Contains("Chi tiêu")
                || columnName.Contains("Tổng")
                || columnName.Contains("Thành tiền");

            if (!isMoneyColumn) return;

            decimal money;
            if (decimal.TryParse(Convert.ToString(e.Value), NumberStyles.Any, CultureInfo.InvariantCulture, out money))
            {
                e.Value = Money(money);
                e.FormattingApplied = true;
            }
        }

        public static void PlaceholderTextCompat(this TextBox textBox, string placeholder)
        {
            if (textBox == null) return;
            textBox.HandleCreated += delegate { SendMessage(textBox.Handle, EM_SETCUEBANNER, (IntPtr)1, placeholder); };
            if (textBox.IsHandleCreated)
            {
                SendMessage(textBox.Handle, EM_SETCUEBANNER, (IntPtr)1, placeholder);
            }
        }
    }
}
