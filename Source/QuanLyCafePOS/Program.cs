using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using QuanLyCafePOS.UI.Forms;

namespace QuanLyCafePOS
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            CultureInfo moneyCulture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            moneyCulture.NumberFormat.NumberGroupSeparator = ",";
            moneyCulture.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = moneyCulture;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi-VN");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
