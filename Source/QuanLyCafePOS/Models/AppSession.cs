namespace QuanLyCafePOS.Models
{
    public static class AppSession
    {
        public static int MaNV { get; set; }
        public static string HoTen { get; set; }
        public static string ChucVu { get; set; }
        public static string VaiTro { get; set; }

        public static bool IsLoggedIn
        {
            get { return MaNV > 0; }
        }

        public static bool IsAdmin
        {
            get
            {
                return !string.IsNullOrWhiteSpace(VaiTro)
                    && VaiTro.ToLowerInvariant().Contains("admin");
            }
        }

        public static bool IsNhanVien
        {
            get { return IsLoggedIn && !IsAdmin; }
        }

        public static void Clear()
        {
            MaNV = 0;
            HoTen = string.Empty;
            ChucVu = string.Empty;
            VaiTro = string.Empty;
        }
    }
}
