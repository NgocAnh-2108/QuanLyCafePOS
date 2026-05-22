/*
  CAFE COZY - Database SQL Server cho đồ án WinForms POS - bản v11
  Địa chỉ: 96 Thông Thiên Học, Đà Lạt
  SĐT: 0979058531

  Bản v11:
  - Dữ liệu mẫu tiếng Việt có dấu.
  - 20 bàn, có đặt trước bàn.
  - Phân quyền Admin / Nhân viên.
  - Món có hình ảnh, có ẩn món và xóa món.
  - Khách hàng thân thiết: mua từ 5 lần được giảm 5% trên hóa đơn.
  - Kho nguyên liệu đơn giản: nhân viên chọn nguyên liệu để kiểm hàng, admin xem lịch sử kiểm hàng.
  - Xóa nhân viên vẫn giữ lịch sử hóa đơn/nhập kho/kiểm kê bằng MaNV NULL.
*/

IF DB_ID(N'QuanLyCafeDB') IS NULL
BEGIN
    CREATE DATABASE QuanLyCafeDB;
END
GO

USE QuanLyCafeDB;
GO

IF OBJECT_ID(N'dbo.v_BaoCaoNgay', N'V') IS NOT NULL DROP VIEW dbo.v_BaoCaoNgay;
GO

IF OBJECT_ID(N'dbo.ChiTietNhapKho', N'U') IS NOT NULL DROP TABLE dbo.ChiTietNhapKho;
IF OBJECT_ID(N'dbo.NhapKho', N'U') IS NOT NULL DROP TABLE dbo.NhapKho;
IF OBJECT_ID(N'dbo.KiemKeKho', N'U') IS NOT NULL DROP TABLE dbo.KiemKeKho;
IF OBJECT_ID(N'dbo.ChiTietHoaDon', N'U') IS NOT NULL DROP TABLE dbo.ChiTietHoaDon;
IF OBJECT_ID(N'dbo.HoaDon', N'U') IS NOT NULL DROP TABLE dbo.HoaDon;
IF OBJECT_ID(N'dbo.DatBan', N'U') IS NOT NULL DROP TABLE dbo.DatBan;
IF OBJECT_ID(N'dbo.KhuyenMai', N'U') IS NOT NULL DROP TABLE dbo.KhuyenMai;
IF OBJECT_ID(N'dbo.KhachHang', N'U') IS NOT NULL DROP TABLE dbo.KhachHang;
IF OBJECT_ID(N'dbo.Mon', N'U') IS NOT NULL DROP TABLE dbo.Mon;
IF OBJECT_ID(N'dbo.LoaiMon', N'U') IS NOT NULL DROP TABLE dbo.LoaiMon;
IF OBJECT_ID(N'dbo.BanCafe', N'U') IS NOT NULL DROP TABLE dbo.BanCafe;
IF OBJECT_ID(N'dbo.NguyenLieu', N'U') IS NOT NULL DROP TABLE dbo.NguyenLieu;
IF OBJECT_ID(N'dbo.NhanVien', N'U') IS NOT NULL DROP TABLE dbo.NhanVien;
GO

CREATE TABLE dbo.NhanVien (
    MaNV INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    TenDangNhap NVARCHAR(50) NOT NULL UNIQUE,
    MatKhau NVARCHAR(100) NOT NULL,
    ChucVu NVARCHAR(50) NOT NULL,
    VaiTro NVARCHAR(20) NOT NULL DEFAULT N'Nhân viên',
    SDT NVARCHAR(20) NULL,
    Email NVARCHAR(100) NULL,
    TrangThai NVARCHAR(30) NOT NULL DEFAULT N'Đang làm',
    NgayTao DATETIME NOT NULL DEFAULT GETDATE()
);
GO

CREATE TABLE dbo.BanCafe (
    MaBan INT IDENTITY(1,1) PRIMARY KEY,
    TenBan NVARCHAR(50) NOT NULL,
    KhuVuc NVARCHAR(50) NOT NULL DEFAULT N'Trong nhà',
    TrangThai NVARCHAR(30) NOT NULL DEFAULT N'Trống',
    SoNguoi INT NOT NULL DEFAULT 0,
    ThoiGianVao DATETIME NULL
);
GO

CREATE TABLE dbo.LoaiMon (
    MaLoai INT IDENTITY(1,1) PRIMARY KEY,
    TenLoai NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(255) NULL
);
GO

CREATE TABLE dbo.Mon (
    MaMon INT IDENTITY(1,1) PRIMARY KEY,
    MaLoai INT NOT NULL,
    TenMon NVARCHAR(120) NOT NULL,
    GiaBan DECIMAL(18,0) NOT NULL,
    DonViTinh NVARCHAR(20) NOT NULL DEFAULT N'ly',
    HinhAnh NVARCHAR(255) NULL,
    MoTa NVARCHAR(255) NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_Mon_LoaiMon FOREIGN KEY (MaLoai) REFERENCES dbo.LoaiMon(MaLoai)
);
GO

CREATE TABLE dbo.KhachHang (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    SDT NVARCHAR(20) NULL,
    SoLanMua INT NOT NULL DEFAULT 0,
    DiemTichLuy INT NOT NULL DEFAULT 0,
    TongChiTieu DECIMAL(18,0) NOT NULL DEFAULT 0,
    GhiChu NVARCHAR(255) NULL,
    NgayTao DATETIME NOT NULL DEFAULT GETDATE()
);
GO

CREATE TABLE dbo.KhuyenMai (
    MaKM INT IDENTITY(1,1) PRIMARY KEY,
    TenKM NVARCHAR(100) NOT NULL,
    LoaiKM NVARCHAR(30) NOT NULL DEFAULT N'Giảm tiền',
    GiaTri DECIMAL(18,0) NOT NULL DEFAULT 0,
    TuNgay DATE NOT NULL,
    DenNgay DATE NOT NULL,
    TrangThai BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE dbo.HoaDon (
    MaHD INT IDENTITY(1,1) PRIMARY KEY,
    MaBan INT NULL,
    MaNV INT NULL,
    MaKH INT NULL,
    NgayLap DATETIME NOT NULL DEFAULT GETDATE(),
    TrangThai NVARCHAR(30) NOT NULL DEFAULT N'Đã thanh toán',
    LoaiDon NVARCHAR(30) NOT NULL DEFAULT N'Uống tại chỗ',
    PhuongThucThanhToan NVARCHAR(30) NULL,
    TongTien DECIMAL(18,0) NOT NULL DEFAULT 0,
    GiamGia DECIMAL(18,0) NOT NULL DEFAULT 0,
    KhachDua DECIMAL(18,0) NOT NULL DEFAULT 0,
    TienThoi DECIMAL(18,0) NOT NULL DEFAULT 0,
    GhiChu NVARCHAR(255) NULL,
    CONSTRAINT FK_HoaDon_Ban FOREIGN KEY (MaBan) REFERENCES dbo.BanCafe(MaBan),
    CONSTRAINT FK_HoaDon_NhanVien FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV) ON DELETE SET NULL,
    CONSTRAINT FK_HoaDon_KhachHang FOREIGN KEY (MaKH) REFERENCES dbo.KhachHang(MaKH)
);
GO

CREATE TABLE dbo.ChiTietHoaDon (
    MaCT INT IDENTITY(1,1) PRIMARY KEY,
    MaHD INT NOT NULL,
    MaMon INT NOT NULL,
    TenMon NVARCHAR(120) NOT NULL,
    Size NVARCHAR(10) NULL DEFAULT N'M',
    Topping NVARCHAR(100) NULL,
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18,0) NOT NULL,
    ThanhTien DECIMAL(18,0) NOT NULL,
    CONSTRAINT FK_CTHD_HoaDon FOREIGN KEY (MaHD) REFERENCES dbo.HoaDon(MaHD),
    CONSTRAINT FK_CTHD_Mon FOREIGN KEY (MaMon) REFERENCES dbo.Mon(MaMon)
);
GO

CREATE TABLE dbo.NguyenLieu (
    MaNL INT IDENTITY(1,1) PRIMARY KEY,
    TenNL NVARCHAR(120) NOT NULL,
    DonVi NVARCHAR(20) NOT NULL,
    TonKho DECIMAL(18,2) NOT NULL DEFAULT 0,
    TonToiThieu DECIMAL(18,2) NOT NULL DEFAULT 0,
    GhiChu NVARCHAR(255) NULL
);
GO

CREATE TABLE dbo.NhapKho (
    MaNK INT IDENTITY(1,1) PRIMARY KEY,
    NgayNhap DATETIME NOT NULL DEFAULT GETDATE(),
    MaNV INT NULL,
    NhaCungCap NVARCHAR(120) NULL,
    TongTien DECIMAL(18,0) NOT NULL DEFAULT 0,
    GhiChu NVARCHAR(255) NULL,
    CONSTRAINT FK_NhapKho_NhanVien FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV) ON DELETE SET NULL
);
GO

CREATE TABLE dbo.ChiTietNhapKho (
    MaCTNK INT IDENTITY(1,1) PRIMARY KEY,
    MaNK INT NOT NULL,
    MaNL INT NOT NULL,
    SoLuong DECIMAL(18,2) NOT NULL,
    DonGia DECIMAL(18,0) NOT NULL,
    ThanhTien DECIMAL(18,0) NOT NULL,
    CONSTRAINT FK_CTNK_NhapKho FOREIGN KEY (MaNK) REFERENCES dbo.NhapKho(MaNK),
    CONSTRAINT FK_CTNK_NguyenLieu FOREIGN KEY (MaNL) REFERENCES dbo.NguyenLieu(MaNL)
);
GO

CREATE TABLE dbo.KiemKeKho (
    MaKK INT IDENTITY(1,1) PRIMARY KEY,
    NgayKiemKe DATETIME NOT NULL DEFAULT GETDATE(),
    MaNL INT NOT NULL,
    MaNV INT NULL,
    TonHeThong DECIMAL(18,2) NOT NULL DEFAULT 0,
    TonThucTe DECIMAL(18,2) NOT NULL DEFAULT 0,
    ChenhLech DECIMAL(18,2) NOT NULL DEFAULT 0,
    GhiChu NVARCHAR(255) NULL,
    CONSTRAINT FK_KiemKeKho_NguyenLieu FOREIGN KEY (MaNL) REFERENCES dbo.NguyenLieu(MaNL),
    CONSTRAINT FK_KiemKeKho_NhanVien FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV) ON DELETE SET NULL
);
GO

CREATE TABLE dbo.DatBan (
    MaDatBan INT IDENTITY(1,1) PRIMARY KEY,
    MaBan INT NOT NULL,
    MaKH INT NULL,
    TenKhach NVARCHAR(100) NOT NULL,
    SDT NVARCHAR(20) NULL,
    SoNguoi INT NOT NULL DEFAULT 1,
    ThoiGianDat DATETIME NOT NULL,
    TrangThai NVARCHAR(30) NOT NULL DEFAULT N'Đã đặt',
    MaNV INT NULL,
    GhiChu NVARCHAR(255) NULL,
    NgayTao DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_DatBan_Ban FOREIGN KEY (MaBan) REFERENCES dbo.BanCafe(MaBan),
    CONSTRAINT FK_DatBan_KhachHang FOREIGN KEY (MaKH) REFERENCES dbo.KhachHang(MaKH),
    CONSTRAINT FK_DatBan_NhanVien FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV) ON DELETE SET NULL
);
GO

INSERT INTO dbo.NhanVien (HoTen, TenDangNhap, MatKhau, ChucVu, VaiTro, SDT, Email, TrangThai) VALUES
(N'Nguyễn Văn Admin', N'admin', N'123456', N'Quản lý', N'Admin', N'0979058531', N'admin@cafecozy.local', N'Đang làm'),
(N'Trần Thị Lan', N'lan', N'123456', N'Thu ngân', N'Nhân viên', N'0912345678', N'lan@cafecozy.local', N'Đang làm'),
(N'Lê Văn Cường', N'cuong', N'123456', N'Pha chế', N'Nhân viên', N'0988111222', NULL, N'Đang làm'),
(N'Phạm Thị Dung', N'dung', N'123456', N'Phục vụ', N'Nhân viên', N'0977333444', NULL, N'Đang làm');
GO

INSERT INTO dbo.BanCafe (TenBan, KhuVuc, TrangThai, SoNguoi, ThoiGianVao) VALUES
(N'Bàn 1',  N'Trong nhà', N'Trống', 0, NULL),
(N'Bàn 2',  N'Trong nhà', N'Trống', 0, NULL),
(N'Bàn 3',  N'Trong nhà', N'Trống', 0, NULL),
(N'Bàn 4',  N'Trong nhà', N'Đang phục vụ', 2, DATEADD(MINUTE,-18,GETDATE())),
(N'Bàn 5',  N'Trong nhà', N'Trống', 0, NULL),
(N'Bàn 6',  N'Trong nhà', N'Đặt trước', 3, NULL),
(N'Bàn 7',  N'Sân vườn', N'Trống', 0, NULL),
(N'Bàn 8',  N'Sân vườn', N'Đang phục vụ', 2, DATEADD(MINUTE,-12,GETDATE())),
(N'Bàn 9',  N'Sân vườn', N'Trống', 0, NULL),
(N'Bàn 10', N'Sân vườn', N'Trống', 0, NULL),
(N'Bàn 11', N'Tầng 2', N'Trống', 0, NULL),
(N'Bàn 12', N'Tầng 2', N'Đặt trước', 4, NULL),
(N'Bàn 13', N'Tầng 2', N'Trống', 0, NULL),
(N'Bàn 14', N'Tầng 2', N'Trống', 0, NULL),
(N'Bàn 15', N'Tầng 2', N'Trống', 0, NULL),
(N'Bàn 16', N'Phòng lạnh', N'Trống', 0, NULL),
(N'Bàn 17', N'Phòng lạnh', N'Trống', 0, NULL),
(N'Bàn 18', N'Phòng lạnh', N'Trống', 0, NULL),
(N'Bàn 19', N'Ban công', N'Trống', 0, NULL),
(N'Bàn 20', N'Ban công', N'Trống', 0, NULL);
GO

INSERT INTO dbo.LoaiMon (TenLoai, MoTa) VALUES
(N'Cà phê', N'Cà phê truyền thống và hiện đại'),
(N'Trà sữa', N'Trà sữa và topping'),
(N'Trà trái cây', N'Trà đào, trà vải, trà chanh'),
(N'Nước ép', N'Nước ép trái cây tươi'),
(N'Bánh ngọt', N'Bánh ăn kèm đồ uống');
GO

INSERT INTO dbo.Mon (MaLoai, TenMon, GiaBan, DonViTinh, HinhAnh, MoTa, IsActive) VALUES
(1, N'Cà phê đen', 29000, N'ly', N'ProductImages\ca_phe_den.png', N'Cà phê đen đá/nóng', 1),
(1, N'Cà phê sữa', 35000, N'ly', N'ProductImages\ca_phe_sua.png', N'Cà phê sữa đá', 1),
(1, N'Bạc xỉu', 35000, N'ly', N'ProductImages\bac_xiu.png', N'Nhiều sữa, ít cà phê', 1),
(1, N'Latte', 42000, N'ly', N'ProductImages\latte.png', N'Latte nóng', 1),
(1, N'Cappuccino', 42000, N'ly', N'ProductImages\cappuccino.png', N'Cappuccino', 1),
(1, N'Mocha', 45000, N'ly', N'ProductImages\mocha.png', N'Mocha chocolate', 1),
(1, N'Americano', 32000, N'ly', N'ProductImages\americano.png', N'Americano đá', 1),
(1, N'Caramel Macchiato', 48000, N'ly', N'ProductImages\caramel_macchiato.png', N'Macchiato caramel', 1),
(2, N'Trà sữa trân châu', 39000, N'ly', N'ProductImages\tra_sua_tran_chau.png', N'Trà sữa topping trân châu', 1),
(2, N'Matcha đá xay', 49000, N'ly', N'ProductImages\matcha_da_xay.png', N'Matcha kem cheese', 1),
(3, N'Trà đào', 39000, N'ly', N'ProductImages\tra_dao.png', N'Trà đào miếng', 1),
(3, N'Trà vải', 39000, N'ly', N'ProductImages\tra_vai.png', N'Trà vải tươi', 1),
(3, N'Trà chanh mật ong', 39000, N'ly', N'ProductImages\tra_chanh_mat_ong.png', N'Trà chanh mật ong', 1),
(4, N'Nước ép cam', 45000, N'ly', N'ProductImages\nuoc_ep_cam.png', N'Cam tươi', 1),
(4, N'Nước ép dưa hấu', 39000, N'ly', N'ProductImages\nuoc_ep_dua_hau.png', N'Dưa hấu tươi', 1),
(5, N'Bánh tiramisu', 45000, N'phần', N'ProductImages\banh_tiramisu.png', N'Bánh kem vị cà phê', 1),
(5, N'Bánh flan', 25000, N'phần', N'ProductImages\banh_flan.png', N'Flan caramel', 1);
GO

INSERT INTO dbo.NguyenLieu (TenNL, DonVi, TonKho, TonToiThieu, GhiChu) VALUES
(N'Sữa tươi', N'lít', 12.50, 5.00, N'Dùng cho cà phê sữa, bạc xỉu'),
(N'Cà phê hạt', N'kg', 8.80, 1.00, N'Robusta rang mộc'),
(N'Trân châu', N'kg', 3.30, 0.50, N'Topping trà sữa'),
(N'Đào ngâm', N'kg', 4.40, 0.50, N'Trà đào'),
(N'Đường', N'kg', 12.00, 3.00, NULL),
(N'Trà đen', N'kg', 5.00, 1.00, NULL),
(N'Ly nhựa 500ml', N'cái', 350.00, 100.00, NULL),
(N'Ống hút', N'cái', 500.00, 100.00, NULL),
(N'Kem cheese', N'kg', 3.00, 1.00, NULL),
(N'Mật ong', N'lít', 4.00, 1.00, NULL);
GO

INSERT INTO dbo.KhachHang (HoTen, SDT, SoLanMua, DiemTichLuy, TongChiTieu, GhiChu) VALUES
(N'Anh Minh', N'0909000001', 8, 245, 2450000, N'Khách thân thiết'),
(N'Chị Hương', N'0909000002', 6, 198, 1980000, N'Khách thân thiết'),
(N'Anh Tuấn', N'0909000003', 4, 165, 1650000, N'Gần đạt thân thiết'),
(N'Chị Mai', N'0909000004', 1, 25, 250000, N'Khách mới'),
(N'Bạn đặt bàn tối', N'0909000005', 2, 60, 600000, N'Hay đặt bàn nhóm');
GO

INSERT INTO dbo.KhuyenMai (TenKM, LoaiKM, GiaTri, TuNgay, DenNgay, TrangThai) VALUES
(N'Giảm 10.000đ hóa đơn từ 100.000đ', N'Giảm tiền', 10000, CAST(GETDATE() AS DATE), DATEADD(DAY, 30, CAST(GETDATE() AS DATE)), 1),
(N'Giảm 10 phần trăm cuối tuần', N'Phần trăm', 10, CAST(GETDATE() AS DATE), DATEADD(DAY, 30, CAST(GETDATE() AS DATE)), 1);
GO

DECLARE @MaNVThuNgan INT = (SELECT TOP 1 MaNV FROM dbo.NhanVien WHERE TenDangNhap = N'lan');
DECLARE @MaNVQuanLy INT = (SELECT TOP 1 MaNV FROM dbo.NhanVien WHERE TenDangNhap = N'admin');
DECLARE @KHMinh INT = (SELECT TOP 1 MaKH FROM dbo.KhachHang WHERE SDT=N'0909000001');
DECLARE @KHHuong INT = (SELECT TOP 1 MaKH FROM dbo.KhachHang WHERE SDT=N'0909000002');
DECLARE @KHTuan INT = (SELECT TOP 1 MaKH FROM dbo.KhachHang WHERE SDT=N'0909000003');
DECLARE @KHDatBan INT = (SELECT TOP 1 MaKH FROM dbo.KhachHang WHERE SDT=N'0909000005');
DECLARE @Ban1 INT = (SELECT TOP 1 MaBan FROM dbo.BanCafe WHERE TenBan = N'Bàn 1');
DECLARE @Ban4 INT = (SELECT TOP 1 MaBan FROM dbo.BanCafe WHERE TenBan = N'Bàn 4');
DECLARE @Ban6 INT = (SELECT TOP 1 MaBan FROM dbo.BanCafe WHERE TenBan = N'Bàn 6');
DECLARE @Ban8 INT = (SELECT TOP 1 MaBan FROM dbo.BanCafe WHERE TenBan = N'Bàn 8');
DECLARE @Ban12 INT = (SELECT TOP 1 MaBan FROM dbo.BanCafe WHERE TenBan = N'Bàn 12');
DECLARE @MonCafeSua INT = (SELECT TOP 1 MaMon FROM dbo.Mon WHERE TenMon = N'Cà phê sữa');
DECLARE @MonBacXiu INT = (SELECT TOP 1 MaMon FROM dbo.Mon WHERE TenMon = N'Bạc xỉu');
DECLARE @MonTraDao INT = (SELECT TOP 1 MaMon FROM dbo.Mon WHERE TenMon = N'Trà đào');
DECLARE @MonMatcha INT = (SELECT TOP 1 MaMon FROM dbo.Mon WHERE TenMon = N'Matcha đá xay');
DECLARE @MonLatte INT = (SELECT TOP 1 MaMon FROM dbo.Mon WHERE TenMon = N'Latte');
DECLARE @MonBanhFlan INT = (SELECT TOP 1 MaMon FROM dbo.Mon WHERE TenMon = N'Bánh flan');
DECLARE @NLSua INT = (SELECT TOP 1 MaNL FROM dbo.NguyenLieu WHERE TenNL=N'Sữa tươi');
DECLARE @NLCafe INT = (SELECT TOP 1 MaNL FROM dbo.NguyenLieu WHERE TenNL=N'Cà phê hạt');
DECLARE @NLTranChau INT = (SELECT TOP 1 MaNL FROM dbo.NguyenLieu WHERE TenNL=N'Trân châu');

INSERT INTO dbo.HoaDon (MaBan, MaNV, MaKH, NgayLap, TrangThai, LoaiDon, PhuongThucThanhToan, TongTien, GiamGia, KhachDua, TienThoi, GhiChu)
VALUES (@Ban1, @MaNVThuNgan, @KHMinh, DATEADD(DAY,-1,GETDATE()), N'Đã thanh toán', N'Uống tại chỗ', N'Tiền mặt', 104000, 5000, 200000, 96000, N'Dữ liệu mẫu');
DECLARE @HD1 INT = CAST(SCOPE_IDENTITY() AS INT);
INSERT INTO dbo.ChiTietHoaDon (MaHD, MaMon, TenMon, Size, Topping, SoLuong, DonGia, ThanhTien) VALUES
(@HD1, @MonCafeSua, N'Cà phê sữa', N'M', NULL, 1, 35000, 35000),
(@HD1, @MonBacXiu, N'Bạc xỉu', N'M', NULL, 1, 35000, 35000),
(@HD1, @MonTraDao, N'Trà đào', N'M', NULL, 1, 39000, 39000);

INSERT INTO dbo.HoaDon (MaBan, MaNV, MaKH, NgayLap, TrangThai, LoaiDon, PhuongThucThanhToan, TongTien, GiamGia, KhachDua, TienThoi, GhiChu)
VALUES (NULL, @MaNVThuNgan, @KHHuong, GETDATE(), N'Đã thanh toán', N'Mang về', N'Chuyển khoản', 184000, 9000, 184000, 0, N'Đơn mang về mẫu, đã áp dụng giảm thân thiết');
DECLARE @HD2 INT = CAST(SCOPE_IDENTITY() AS INT);
INSERT INTO dbo.ChiTietHoaDon (MaHD, MaMon, TenMon, Size, Topping, SoLuong, DonGia, ThanhTien) VALUES
(@HD2, @MonCafeSua, N'Cà phê sữa', N'M', NULL, 2, 35000, 70000),
(@HD2, @MonBacXiu, N'Bạc xỉu', N'M', NULL, 1, 35000, 35000),
(@HD2, @MonTraDao, N'Trà đào', N'M', N'Thạch đào', 1, 39000, 39000),
(@HD2, @MonMatcha, N'Matcha đá xay', N'L', N'Kem cheese', 1, 49000, 49000);

INSERT INTO dbo.HoaDon (MaBan, MaNV, MaKH, NgayLap, TrangThai, LoaiDon, PhuongThucThanhToan, TongTien, GiamGia, KhachDua, TienThoi, GhiChu)
VALUES (@Ban4, @MaNVThuNgan, @KHTuan, DATEADD(MINUTE,-18,GETDATE()), N'Đang phục vụ', N'Uống tại chỗ', N'Chưa thanh toán', 77000, 0, 0, 0, N'Order tạm giữ mẫu');
DECLARE @HD3 INT = CAST(SCOPE_IDENTITY() AS INT);
INSERT INTO dbo.ChiTietHoaDon (MaHD, MaMon, TenMon, Size, Topping, SoLuong, DonGia, ThanhTien) VALUES
(@HD3, @MonCafeSua, N'Cà phê sữa', N'M', NULL, 1, 35000, 35000),
(@HD3, @MonLatte, N'Latte', N'M', NULL, 1, 42000, 42000);

INSERT INTO dbo.HoaDon (MaBan, MaNV, MaKH, NgayLap, TrangThai, LoaiDon, PhuongThucThanhToan, TongTien, GiamGia, KhachDua, TienThoi, GhiChu)
VALUES (@Ban8, @MaNVThuNgan, NULL, DATEADD(MINUTE,-12,GETDATE()), N'Đang phục vụ', N'Uống tại chỗ', N'Chưa thanh toán', 74000, 0, 0, 0, N'Order tạm giữ mẫu');
DECLARE @HD4 INT = CAST(SCOPE_IDENTITY() AS INT);
INSERT INTO dbo.ChiTietHoaDon (MaHD, MaMon, TenMon, Size, Topping, SoLuong, DonGia, ThanhTien) VALUES
(@HD4, @MonBacXiu, N'Bạc xỉu', N'M', NULL, 1, 35000, 35000),
(@HD4, @MonTraDao, N'Trà đào', N'M', NULL, 1, 39000, 39000);

INSERT INTO dbo.DatBan(MaBan, MaKH, TenKhach, SDT, SoNguoi, ThoiGianDat, TrangThai, MaNV, GhiChu) VALUES
(@Ban6, @KHDatBan, N'Bạn đặt bàn tối', N'0909000005', 3, DATEADD(HOUR, 3, GETDATE()), N'Đã đặt', @MaNVThuNgan, N'Đến khoảng 19:00'),
(@Ban12, @KHHuong, N'Chị Hương', N'0909000002', 4, DATEADD(DAY, 1, DATEADD(HOUR, 10, CAST(CAST(GETDATE() AS DATE) AS DATETIME))), N'Đã đặt', @MaNVThuNgan, N'Sinh nhật nhỏ');

INSERT INTO dbo.NhapKho(NgayNhap, MaNV, NhaCungCap, TongTien, GhiChu)
VALUES(DATEADD(DAY,-1,GETDATE()), @MaNVQuanLy, N'Nhà cung cấp Đà Lạt', 650000, N'Nhập hàng đầu ngày');
DECLARE @NK1 INT = CAST(SCOPE_IDENTITY() AS INT);
INSERT INTO dbo.ChiTietNhapKho(MaNK, MaNL, SoLuong, DonGia, ThanhTien) VALUES
(@NK1, @NLSua, 10.00, 25000, 250000),
(@NK1, @NLCafe, 5.00, 80000, 400000);

INSERT INTO dbo.KiemKeKho(NgayKiemKe, MaNL, MaNV, TonHeThong, TonThucTe, ChenhLech, GhiChu) VALUES
(DATEADD(DAY,-1,GETDATE()), @NLSua, @MaNVThuNgan, 12.50, 12.20, -0.30, N'Kiểm kê cuối ngày'),
(DATEADD(DAY,-1,GETDATE()), @NLCafe, @MaNVThuNgan, 8.80, 8.80, 0.00, N'Khớp tồn'),
(DATEADD(DAY,-1,GETDATE()), @NLTranChau, @MaNVThuNgan, 3.30, 3.10, -0.20, N'Hao hụt pha chế');
GO

IF OBJECT_ID(N'dbo.v_BaoCaoNgay', N'V') IS NOT NULL DROP VIEW dbo.v_BaoCaoNgay;
GO
CREATE VIEW dbo.v_BaoCaoNgay AS
SELECT
    CAST(NgayLap AS DATE) AS Ngay,
    COUNT(*) AS SoDon,
    SUM(TongTien) AS DoanhThu
FROM dbo.HoaDon
WHERE TrangThai = N'Đã thanh toán'
GROUP BY CAST(NgayLap AS DATE);
GO

PRINT N'Đã tạo xong database QuanLyCafeDB cho Cafe Cozy.';
GO
