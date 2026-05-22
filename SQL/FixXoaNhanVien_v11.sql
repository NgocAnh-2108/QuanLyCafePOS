USE QuanLyCafeDB;
GO

/*
  Chạy file này nếu bạn đang dùng database cũ và muốn xóa nhân viên được.
  Script đổi các bảng lịch sử sang MaNV NULL + ON DELETE SET NULL.
*/

IF OBJECT_ID(N'dbo.FK_HoaDon_NhanVien', N'F') IS NOT NULL ALTER TABLE dbo.HoaDon DROP CONSTRAINT FK_HoaDon_NhanVien;
IF OBJECT_ID(N'dbo.FK_NhapKho_NhanVien', N'F') IS NOT NULL ALTER TABLE dbo.NhapKho DROP CONSTRAINT FK_NhapKho_NhanVien;
IF OBJECT_ID(N'dbo.FK_KiemKeKho_NhanVien', N'F') IS NOT NULL ALTER TABLE dbo.KiemKeKho DROP CONSTRAINT FK_KiemKeKho_NhanVien;
IF OBJECT_ID(N'dbo.FK_DatBan_NhanVien', N'F') IS NOT NULL ALTER TABLE dbo.DatBan DROP CONSTRAINT FK_DatBan_NhanVien;
GO

IF OBJECT_ID(N'dbo.HoaDon', N'U') IS NOT NULL ALTER TABLE dbo.HoaDon ALTER COLUMN MaNV INT NULL;
IF OBJECT_ID(N'dbo.NhapKho', N'U') IS NOT NULL ALTER TABLE dbo.NhapKho ALTER COLUMN MaNV INT NULL;
IF OBJECT_ID(N'dbo.KiemKeKho', N'U') IS NOT NULL ALTER TABLE dbo.KiemKeKho ALTER COLUMN MaNV INT NULL;
IF OBJECT_ID(N'dbo.DatBan', N'U') IS NOT NULL ALTER TABLE dbo.DatBan ALTER COLUMN MaNV INT NULL;
GO

IF OBJECT_ID(N'dbo.HoaDon', N'U') IS NOT NULL AND OBJECT_ID(N'dbo.FK_HoaDon_NhanVien', N'F') IS NULL
    ALTER TABLE dbo.HoaDon ADD CONSTRAINT FK_HoaDon_NhanVien FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV) ON DELETE SET NULL;
IF OBJECT_ID(N'dbo.NhapKho', N'U') IS NOT NULL AND OBJECT_ID(N'dbo.FK_NhapKho_NhanVien', N'F') IS NULL
    ALTER TABLE dbo.NhapKho ADD CONSTRAINT FK_NhapKho_NhanVien FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV) ON DELETE SET NULL;
IF OBJECT_ID(N'dbo.KiemKeKho', N'U') IS NOT NULL AND OBJECT_ID(N'dbo.FK_KiemKeKho_NhanVien', N'F') IS NULL
    ALTER TABLE dbo.KiemKeKho ADD CONSTRAINT FK_KiemKeKho_NhanVien FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV) ON DELETE SET NULL;
IF OBJECT_ID(N'dbo.DatBan', N'U') IS NOT NULL AND OBJECT_ID(N'dbo.FK_DatBan_NhanVien', N'F') IS NULL
    ALTER TABLE dbo.DatBan ADD CONSTRAINT FK_DatBan_NhanVien FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV) ON DELETE SET NULL;
GO

PRINT N'Đã cập nhật database để xóa nhân viên được và vẫn giữ lịch sử.';
GO
