USE QuanLyCafeDB;
GO
IF NOT EXISTS (SELECT 1 FROM dbo.NhanVien WHERE TenDangNhap = N'admin')
BEGIN
    INSERT INTO dbo.NhanVien(HoTen, TenDangNhap, MatKhau, ChucVu, VaiTro, SDT, Email, TrangThai)
    VALUES (N'Nguyễn Văn Admin', N'admin', N'123456', N'Quản lý', N'Admin', N'0979058531', N'admin@cafecozy.local', N'Đang làm');
END
ELSE
BEGIN
    UPDATE dbo.NhanVien
    SET HoTen=N'Nguyễn Văn Admin', MatKhau=N'123456', ChucVu=N'Quản lý', VaiTro=N'Admin', TrangThai=N'Đang làm', SDT=N'0979058531'
    WHERE TenDangNhap=N'admin';
END
GO
