CREATE DATABASE QUANLYQUANTRASUA
GO
USE QUANLYQUANTRASUA
GO

CREATE TABLE ChucVu(
    MaChucVu CHAR(10) NOT NULL, 
    TenChucVu NVARCHAR(20),
    LuongMotGioLam FLOAT,
	CONSTRAINT PK_ChucVu PRIMARY KEY(MaChucVu)
)
GO

CREATE TABLE NhanVien(
	ID INT IDENTITY(1,1) NOT NULL,
    MaNV AS ('NV'+ RIGHT('0000000' + CAST(ID AS VARCHAR(8)), 8)) PERSISTED, 
	-- VARCHAR(10)
    MaChucVu CHAR(10),
    HoTen NVARCHAR(40),
    NgaySinh DATE,
    GioiTinh CHAR(10),
    NgayBatDauLam DATE,
	SDT CHAR(10),
	TinhTrang NVARCHAR(10),
	CONSTRAINT PK_NhanVien PRIMARY KEY(MaNV),
    CONSTRAINT FK_NhanVien_ChucVu FOREIGN KEY(MaChucVu) REFERENCES ChucVu(MaChucVu)
	ON DELETE SET NULL
	ON UPDATE CASCADE
)
GO

CREATE TABLE DangNhap(
	TenNguoiDung NVARCHAR(30),
	MatKhau NVARCHAR(16),
	MaNV VARCHAR(10),
	CONSTRAINT PK_DangNhap PRIMARY KEY(TenNguoiDung),
	CONSTRAINT FK_DangNhap_NhanVien FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV)
)
GO

--NhomNguoiDung (MaNhomNguoiDung, TenNhom, TenRole)
CREATE TABLE NhomNguoiDung(
	MaNhomNguoiDung varchar(10),
	TenNhom nvarchar(30),
	TenRole varchar(30),
	CONSTRAINT PK_NhomNguoiDung PRIMARY KEY(MaNhomNguoiDung)
)
GO

CREATE TABLE PhanNhom(
	MaNV varchar(10),
	MaNhomNguoiDung varchar(10),
	CONSTRAINT PK_PhanNhom PRIMARY KEY(MaNV),
	CONSTRAINT FK_PhanNhom_NhanVien FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV),
	CONSTRAINT FK_PhanNhom_NhomNguoiDung FOREIGN KEY(MaNhomNguoiDung) REFERENCES NhomNguoiDung(MaNhomNguoiDung)
)

CREATE TABLE LoaiCa(
    MaLoaiCa CHAR(10) NOT NULL ,
    TenLoaiCa NVARCHAR(30),
    GioBatDau TIME,
    GioKetThuc TIME,
    TienThuongCa FLOAT,
	CONSTRAINT PK_LoaiCa PRIMARY KEY(MaLoaiCa)
)
GO

-- CaLam(MaLoaiCa, NgayLam, MaCa)
CREATE TABLE CaLam(
    MaLoaiCa CHAR(10),
    NgayLam DATE,
	MaCa AS ('CL' + RIGHT(RTRIM(MaLoaiCa), 1) + convert(varchar(8),cast(NgayLam as date),112)) PERSISTED,
	-- VD: CLS20230323 (ca sang ngay: 23/03/2023)
	-- VARCHAR(11)
	CONSTRAINT PK_CaLam PRIMARY KEY(MaCa),
    CONSTRAINT FK_CaLam_LoaiCa FOREIGN KEY(MaLoaiCa) REFERENCES LoaiCa(MaLoaiCa)
	ON DELETE SET NULL
	ON UPDATE CASCADE
)
GO

CREATE TABLE LoaiKhachHang(
    MaLoaiKH CHAR(10) NOT NULL,
    TenLoaiKH NVARCHAR(30),
    GhiChu NVARCHAR(Max),
	CONSTRAINT PK_LoaiKhachHang PRIMARY KEY(MaLoaiKH)
)
GO

CREATE TABLE KhachHang(
    ID INT IDENTITY(1,1) NOT NULL,
    MaKH AS ('KH'+ RIGHT('00000000' + CAST(ID AS VARCHAR(9)), 9)) PERSISTED,
	-- CHAR(11)
    MaLoaiKH CHAR(10),
    TenKH NVARCHAR(40),
    DiaChi NVARCHAR(200),
    SDT CHAR(10),
    DiemTichLuyHienTai FLOAT DEFAULT 0,
    TongDiemTichLuy FLOAT DEFAULT 0,
	CONSTRAINT PK_KhachHang PRIMARY KEY(MaKH),
    CONSTRAINT FK_KhachHang_LoaiKhachHang FOREIGN KEY (MaLoaiKH) REFERENCES LoaiKhachHang(MaLoaiKH)
	ON DELETE SET NULL
	ON UPDATE CASCADE
)
GO

--Ban(MaBan, SoBan, TrangThai)
CREATE TABLE Ban(
    MaBan CHAR(10) NOT NULL ,
    SoBan INT,
    TrangThai NVARCHAR(30) DEFAULT N'Trống',
	CONSTRAINT PK_Ban PRIMARY KEY(MaBan)
)
GO

--HoaDon(MaHoaDon, MaNV, MaKH, MaBan, NgayGioInHoaDon, TongGiaTien, DiemTichLuyThem)
CREATE TABLE HoaDon(
	ID INT IDENTITY(1,1) NOT NULL,
    MaHoaDon AS ('BILL'+ RIGHT('00000000' + CAST(ID AS VARCHAR(9)), 9)) PERSISTED,
	-- VARCHAR(13)
    MaNV VARCHAR(10),
    MaKH VARCHAR(11),
    MaBan CHAR(10),
    NgayGioInHoaDon DATETIME,
    TongGiaTien INT,
    DiemTichLuyThem AS (CAST(TongGiaTien AS FLOAT) / CAST(10000 AS FLOAT)),
    DiemSuDung FLOAT,
	CONSTRAINT PK_HoaDon PRIMARY KEY(MaHoaDon),

    CONSTRAINT FK_HoaDon_NhanVien FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV)
	ON DELETE SET NULL
	ON UPDATE CASCADE,

    CONSTRAINT FK_HoaDon_KhachHang FOREIGN KEY(MaKH) REFERENCES KhachHang(MaKH)
	ON DELETE SET NULL
	ON UPDATE CASCADE,

    CONSTRAINT FK_HoaDon_Ban FOREIGN KEY(MaBan) REFERENCES Ban(MaBan)
	ON DELETE SET NULL
	ON UPDATE CASCADE
)
GO

--LoaiMatHang(MaLoaiMH, TenLoaiHang)
CREATE TABLE LoaiMatHang(
    MaLoaiMH CHAR(10) NOT NULL,
    TenLoaiHang NVARCHAR(30),
	CONSTRAINT PK_LoaiMatHang PRIMARY KEY(MaLoaiMH)
)
GO

--MatHang(MaMH, MaLoaiMH, TenHang, GiaTien)
CREATE TABLE MatHang(
    MaMH CHAR(10) NOT NULL,
    MaLoaiMH CHAR(10),
    TenHang NVARCHAR(30),
    GiaTien FLOAT,
	CONSTRAINT PK_MatHang PRIMARY KEY(MaMH),
    CONSTRAINT FK_MatHang_LoaiMatHang FOREIGN KEY(MaLoaiMH) REFERENCES LoaiMatHang(MaLoaiMH)
	ON DELETE SET NULL
	ON UPDATE CASCADE
)
GO

--NguyenVatLieu(MaNVL, TenNVL, DonVi, GiaMotDonVi)
CREATE TABLE NguyenVatLieu(
    MaNVL CHAR(10) NOT NULL,
    TenNVL NVARCHAR(30),
    DonVi NCHAR(10),
    GiaMotDonVi FLOAT,
	CONSTRAINT PK_NguyenVatLieu PRIMARY KEY(MaNVL)
)
GO

--PhieuMua(MaPhieuMua, NgayGioMua)
CREATE TABLE PhieuMua(
    NgayGioMua DATETIME,
	MaPhieuMua AS CAST('PM' + replace(convert(varchar(8), NgayGioMua, 112)+convert(varchar(8), NgayGioMua, 114), ':','') AS VARCHAR(16))	PERSISTED
	-- VARCHAR(16)
	CONSTRAINT PK_PhieuMua PRIMARY KEY(MaPhieuMua)
)
GO

--Kho(MaKho, NgayThang)
CREATE TABLE Kho(
    NgayThang DATE,
	MaKho AS CAST('KHO' + convert(varchar(8),NgayThang,112) AS VARCHAR(11)) PERSISTED
	CONSTRAINT PK_Kho PRIMARY KEY(MaKho)
)
GO

-- Relationship tables

-- ChiTietLuongNgay(MaNV, MaCa, MaChucVu, MaLuong, NgayLuong, ThanhTien, KyLuong)
CREATE TABLE ChiTietLuongNgay(
    MaNV VARCHAR(10),
    MaCa VARCHAR(11),
    MaChucVu CHAR(10),
	MaLuong AS ('ML' + RIGHT(RTRIM(MaNV), 8) + RIGHT(RTRIM(MaCa), 9)) PERSISTED,
    NgayLuong DATE,
    ThanhTien FLOAT,
    KyLuong DATE,
    CONSTRAINT PK_ChiTietLuongNgay PRIMARY KEY (MaNV, MaCa, MaChucVu),
    CONSTRAINT FK_ChiTietLuongNgay_NhanVien FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV),
    CONSTRAINT FK_ChiTietLuongNgay_CaLam FOREIGN KEY(MaCa) REFERENCES CaLam(MaCa),
    CONSTRAINT FK_ChiTietLuongNgay_ChucVu FOREIGN KEY(MaChucVu) REFERENCES ChucVu(MaChucVu)
)
GO

--PhanCong(MaNV, MaCa, DiemDanh)
CREATE TABLE PhanCong(
    MaNV VARCHAR(10),
    MaCa VARCHAR(11),
    DiemDanh INT,
    CONSTRAINT PK_PhanCong PRIMARY KEY(MaNV, MaCa),
    CONSTRAINT FK_PhanCong_NhanVien FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV),
    CONSTRAINT FK_PhanCong_CaLam FOREIGN KEY (MaCa) REFERENCES CaLam(MaCa)
)
GO
--ChiTietHoaDon(MaHoaDon, MaMH, SoLuongMH, ThanhTien)
CREATE TABLE ChiTietHoaDon(
    MaHoaDon VARCHAR(13),
    MaMH CHAR(10),
    SoLuongMH INT,
    ThanhTien FLOAT,
	GhiChu NVARCHAR(255) NULL,
    CONSTRAINT PK_ChiTietHoaDon PRIMARY KEY(MaHoaDon, MaMH),
    CONSTRAINT FK_ChiTietHoaDon_HoaDon FOREIGN KEY(MaHoaDon) REFERENCES HoaDon(MaHoaDon),
    CONSTRAINT FK_ChiTietLuongNgay_MatHang FOREIGN KEY(MaMH) REFERENCES MatHang(MaMH)
)
GO

--CongThuc(MaMH, MaNVL, SoLuong, CachLam)
CREATE TABLE CongThuc(
    MaMH CHAR(10),
    MaNVL CHAR(10),
    SoLuong INT,
    CachLam TEXT,
    CONSTRAINT PK_CongThuc PRIMARY KEY(MaMH, MaNVL),
    CONSTRAINT FK_CongThuc_MatHang FOREIGN KEY(MaMH) REFERENCES MatHang(MaMH),
    CONSTRAINT FK_CongThuc_NguyenVatLieu FOREIGN KEY(MaNVL) REFERENCES NguyenVatLieu(MaNVL)
)
GO
--LuuTru(MaNVL, MaKho,HSD, SoLuongConLai)
CREATE TABLE LuuTru(
    MaNVL CHAR(10),
    MaKho VARCHAR(11),
    HSD DATE,
    SoLuongConLai INT,
    CONSTRAINT PK_LuuTru PRIMARY KEY(MaNVL, MaKho),
    CONSTRAINT FK_LuuTru_NguyenVatLieu FOREIGN KEY(MaNVL) REFERENCES NguyenVatLieu(MaNVL),
    CONSTRAINT FK_LuuTru_Kho FOREIGN KEY(MaKho) REFERENCES Kho(MaKho)
)
GO
--NhapKho(MaNhapKho, MaNVL, MaKho, SoLuong, GioNhap)
CREATE TABLE NhapKho(
    MaNVL CHAR(10),
    MaKho VARCHAR(11),
    SoLuong INT,
    GioNhap TIME(0) not null,
    CONSTRAINT PK_NhapKho PRIMARY KEY (MaNVL, MaKho, GioNhap),
    CONSTRAINT FK_NhapKho_NguyenVatLieu FOREIGN KEY(MaNVL) REFERENCES NguyenVatLieu(MaNVL),
    CONSTRAINT FK_NhapKho_Kho FOREIGN KEY(MaKho) REFERENCES Kho(MaKho)
)
GO
--XuatKho(MaNVL, MaKho, SoLuong, GioXuat)
CREATE TABLE XuatKho(
    MaNVL CHAR(10),
    MaKho VARCHAR(11),
    SoLuong INT,
    NgayGioXuat DATETIME,
    CONSTRAINT PK_XuatKho PRIMARY KEY(MaNVL, MaKho, NgayGioXuat),
    CONSTRAINT FK_XuatKho_NguyenVatLieu FOREIGN KEY(MaNVL) REFERENCES NguyenVatLieu(MaNVL),
    CONSTRAINT FK_XuatKho_Kho FOREIGN KEY(MaKho) REFERENCES Kho(MaKho)
)
GO
--ChiTietMua(MaPhieuMua, MaNVL, SoLuongNVL, ThanhTien)
CREATE TABLE ChiTietMua(
    MaPhieuMua VARCHAR(16),
    MaNVL CHAR(10),
    SoLuongNVL INT,
    ThanhTien FLOAT,
	CONSTRAINT PK_ChiTietMua PRIMARY KEY(MaPhieuMua, MaNVL),
    CONSTRAINT FK_ChiTietMua_PhieuMua FOREIGN KEY(MaPhieuMua) REFERENCES PhieuMua(MaPhieuMua),
    CONSTRAINT FK_ChiTietMua_NguyenVatLieu FOREIGN KEY(MaNVL) REFERENCES NguyenVatLieu(MaNVL)
)
GO
-- ==================================================== DỮ LIỆU ====================================================================
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [LuongMotGioLam]) VALUES (N'BV004     ', N'Bảo Vệ', 18000)
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [LuongMotGioLam]) VALUES (N'CB001     ', N'Chạy Bàn', 23000)
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [LuongMotGioLam]) VALUES (N'LC005     ', N'Lao công', 21000)
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [LuongMotGioLam]) VALUES (N'PC003     ', N'Pha Chế', 23000)
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [LuongMotGioLam]) VALUES (N'TN002     ', N'Thu Ngân', 23000)
GO
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([ID], [MaChucVu], [HoTen], [NgaySinh], [GioiTinh], [NgayBatDauLam], [SDT], [TinhTrang]) VALUES (1, N'CB001     ', N'Nguyễn Việt An', CAST(N'2003-07-26' AS Date), N'Male      ', CAST(N'2023-03-09' AS Date), N'0905456789', N'Đang làm')
INSERT [dbo].[NhanVien] ([ID], [MaChucVu], [HoTen], [NgaySinh], [GioiTinh], [NgayBatDauLam], [SDT], [TinhTrang]) VALUES (2, N'CB001     ', N'Trần Viết Trung', CAST(N'2003-09-18' AS Date), N'Male      ', CAST(N'2023-03-09' AS Date), N'0912131415', N'Đang làm')
INSERT [dbo].[NhanVien] ([ID], [MaChucVu], [HoTen], [NgaySinh], [GioiTinh], [NgayBatDauLam], [SDT], [TinhTrang]) VALUES (3, N'CB001     ', N'Trần Nguyễn Trí Đạt', CAST(N'2003-05-06' AS Date), N'Male      ', CAST(N'2023-03-10' AS Date), N'0903123456', N'Đang làm')
INSERT [dbo].[NhanVien] ([ID], [MaChucVu], [HoTen], [NgaySinh], [GioiTinh], [NgayBatDauLam], [SDT], [TinhTrang]) VALUES (4, N'CB001     ', N'Vương Đình Hiếu', CAST(N'2003-04-08' AS Date), N'Male      ', CAST(N'2023-03-10' AS Date), N'0909123456', N'Đang làm')
INSERT [dbo].[NhanVien] ([ID], [MaChucVu], [HoTen], [NgaySinh], [GioiTinh], [NgayBatDauLam], [SDT], [TinhTrang]) VALUES (5, N'CB001     ', N'Bành Viết Hùng', CAST(N'2003-05-04' AS Date), N'Male      ', CAST(N'2023-03-10' AS Date), N'0905123456', N'Đang làm')
INSERT [dbo].[NhanVien] ([ID], [MaChucVu], [HoTen], [NgaySinh], [GioiTinh], [NgayBatDauLam], [SDT], [TinhTrang]) VALUES (6, N'CB001     ', N'Đặng Hoàng Toàn', CAST(N'2004-03-07' AS Date), N'Female    ', CAST(N'2023-03-09' AS Date), N'0904123456', N'Đang làm')
INSERT [dbo].[NhanVien] ([ID], [MaChucVu], [HoTen], [NgaySinh], [GioiTinh], [NgayBatDauLam], [SDT], [TinhTrang]) VALUES (7, N'TN002     ', N'Trình Học Tuấn', CAST(N'2004-08-25' AS Date), N'Female    ', CAST(N'2023-03-11' AS Date), N'0392123456', N'Đang làm')
INSERT [dbo].[NhanVien] ([ID], [MaChucVu], [HoTen], [NgaySinh], [GioiTinh], [NgayBatDauLam], [SDT], [TinhTrang]) VALUES (8, N'TN002     ', N'Nguyễn Công Quý', CAST(N'2003-05-29' AS Date), N'Male      ', CAST(N'2023-03-10' AS Date), N'0393123456', N'Đang làm')
INSERT [dbo].[NhanVien] ([ID], [MaChucVu], [HoTen], [NgaySinh], [GioiTinh], [NgayBatDauLam], [SDT], [TinhTrang]) VALUES (9, N'PC003     ', N'Lê Bình Phương Vi', CAST(N'2003-08-12' AS Date), N'Female    ', CAST(N'2023-03-09' AS Date), N'0898123456', N'Đang làm')
INSERT [dbo].[NhanVien] ([ID], [MaChucVu], [HoTen], [NgaySinh], [GioiTinh], [NgayBatDauLam], [SDT], [TinhTrang]) VALUES (10, N'PC003     ', N'Đàm Quỳnh Trang', CAST(N'2003-12-12' AS Date), N'Male      ', CAST(N'2023-03-10' AS Date), N'0893123456', N'Đang làm')
INSERT [dbo].[NhanVien] ([ID], [MaChucVu], [HoTen], [NgaySinh], [GioiTinh], [NgayBatDauLam], [SDT], [TinhTrang]) VALUES (11, N'PC003     ', N'Lê Đức Hải', CAST(N'2005-03-03' AS Date), N'Male      ', CAST(N'2023-04-01' AS Date), N'0396123456', N'Đang làm')
INSERT [dbo].[NhanVien] ([ID], [MaChucVu], [HoTen], [NgaySinh], [GioiTinh], [NgayBatDauLam], [SDT], [TinhTrang]) VALUES (12, N'PC003     ', N'Nguyễn Công Thiên', CAST(N'2003-05-26' AS Date), N'Male      ', CAST(N'2023-04-03' AS Date), N'0398123456', N'Đang làm')
INSERT [dbo].[NhanVien] ([ID], [MaChucVu], [HoTen], [NgaySinh], [GioiTinh], [NgayBatDauLam], [SDT], [TinhTrang]) VALUES (13, N'BV004     ', N'Trần Thu Trà', CAST(N'2003-01-23' AS Date), N'Female    ', CAST(N'2023-01-23' AS Date), N'0902123456', N'Đang làm')
INSERT [dbo].[NhanVien] ([ID], [MaChucVu], [HoTen], [NgaySinh], [GioiTinh], [NgayBatDauLam], [SDT], [TinhTrang]) VALUES (14, N'BV004     ', N'Vũ Văn Tiến', CAST(N'2006-08-27' AS Date), N'Male      ', CAST(N'2023-03-09' AS Date), N'0906123456', N'Đang làm')
INSERT [dbo].[NhanVien] ([ID], [MaChucVu], [HoTen], [NgaySinh], [GioiTinh], [NgayBatDauLam], [SDT], [TinhTrang]) VALUES (15, N'BV004     ', N'Hiếu Vương', CAST(N'2003-10-01' AS Date), N'Male      ', CAST(N'2023-04-19' AS Date), N'09865454  ', N'Đang làm')
INSERT [dbo].[NhanVien] ([ID], [MaChucVu], [HoTen], [NgaySinh], [GioiTinh], [NgayBatDauLam], [SDT], [TinhTrang]) VALUES (16, N'CB001     ', N'Hieu Ngu', CAST(N'2023-04-19' AS Date), N'Female    ', CAST(N'2023-04-19' AS Date), N'545454    ', N'Đã nghỉ')
INSERT [dbo].[NhanVien] ([ID], [MaChucVu], [HoTen], [NgaySinh], [GioiTinh], [NgayBatDauLam], [SDT], [TinhTrang]) VALUES (17, N'CB001     ', N'Phùng Thế Hưng', CAST(N'2003-10-01' AS Date), N'Male      ', CAST(N'2023-04-19' AS Date), N'0169785235', N'Đã nghỉ')
INSERT [dbo].[NhanVien] ([ID], [MaChucVu], [HoTen], [NgaySinh], [GioiTinh], [NgayBatDauLam], [SDT], [TinhTrang]) VALUES (18, N'BV004     ', N'Tú Ócc', CAST(N'2003-05-04' AS Date), N'Male      ', CAST(N'2023-05-04' AS Date), N'0123456897', N'Đang làm')
INSERT [dbo].[NhanVien] ([ID], [MaChucVu], [HoTen], [NgaySinh], [GioiTinh], [NgayBatDauLam], [SDT], [TinhTrang]) VALUES (19, N'BV004     ', N'Tuấn Óc', CAST(N'2003-05-15' AS Date), N'Male      ', CAST(N'2023-05-04' AS Date), N'012456987 ', N'Đã nghỉ')
INSERT [dbo].[NhanVien] ([ID], [MaChucVu], [HoTen], [NgaySinh], [GioiTinh], [NgayBatDauLam], [SDT], [TinhTrang]) VALUES (20, N'LC005     ', N'A Dính', CAST(N'1998-05-08' AS Date), N'Male      ', CAST(N'2023-03-01' AS Date), N'0896542321', N'Đã nghỉ')
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
GO
INSERT [dbo].[LoaiCa] ([MaLoaiCa], [TenLoaiCa], [GioBatDau], [GioKetThuc], [TienThuongCa]) VALUES (N'CC        ', N'Ca chiều', CAST(N'13:00:00' AS Time), CAST(N'17:00:00' AS Time), 0)
INSERT [dbo].[LoaiCa] ([MaLoaiCa], [TenLoaiCa], [GioBatDau], [GioKetThuc], [TienThuongCa]) VALUES (N'CS        ', N'Ca sáng', CAST(N'08:00:00' AS Time), CAST(N'12:00:00' AS Time), 0)
INSERT [dbo].[LoaiCa] ([MaLoaiCa], [TenLoaiCa], [GioBatDau], [GioKetThuc], [TienThuongCa]) VALUES (N'CT        ', N'Ca tối', CAST(N'18:00:00' AS Time), CAST(N'22:00:00' AS Time), 2000)
GO
INSERT [dbo].[LoaiKhachHang] ([MaLoaiKH], [TenLoaiKH], [GhiChu]) VALUES (N'MEM       ', N'Khách hàng thành viên', N'Được tích điểm tích lũy nhưng chưa đủ điều kiện sử dụng')
INSERT [dbo].[LoaiKhachHang] ([MaLoaiKH], [TenLoaiKH], [GhiChu]) VALUES (N'VIP       ', N'Khách hàng Vip', N'Được sử dụng điểm tích lũy để thanh toán hóa đơn')
GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([ID], [MaLoaiKH], [TenKH], [DiaChi], [SDT], [DiemTichLuyHienTai], [TongDiemTichLuy]) VALUES (1, N'VIP       ', N'Nguyễn Anh Đại', N'Đường 7, Linh Trung, Thủ Đức', N'0345090606', 99.8, 107.8)
INSERT [dbo].[KhachHang] ([ID], [MaLoaiKH], [TenKH], [DiaChi], [SDT], [DiemTichLuyHienTai], [TongDiemTichLuy]) VALUES (2, N'VIP       ', N'Lê Đức Duy', N'Thống Nhất, Linh Chiểu, Thủ Đức', N'0349512462', 96.6, 105.6)
INSERT [dbo].[KhachHang] ([ID], [MaLoaiKH], [TenKH], [DiaChi], [SDT], [DiemTichLuyHienTai], [TongDiemTichLuy]) VALUES (3, N'VIP       ', N'Đinh Thị Ngọc Bích', N'Hoàng Diệu 2, Linh Trung, Thủ Đức', N'0264123584', 104, 124)
INSERT [dbo].[KhachHang] ([ID], [MaLoaiKH], [TenKH], [DiaChi], [SDT], [DiemTichLuyHienTai], [TongDiemTichLuy]) VALUES (4, N'VIP       ', N'Hoàng Thị Kiều Oanh', N'Cộng Hòa, Tân Bình', N'0339267162', 106.5, 106.5)
INSERT [dbo].[KhachHang] ([ID], [MaLoaiKH], [TenKH], [DiaChi], [SDT], [DiemTichLuyHienTai], [TongDiemTichLuy]) VALUES (5, N'VIP       ', N'Nguyễn Hồng Vi', N'Lê Văn Việt, Quận 9', N'0981037321', 101.5, 106.5)
INSERT [dbo].[KhachHang] ([ID], [MaLoaiKH], [TenKH], [DiaChi], [SDT], [DiemTichLuyHienTai], [TongDiemTichLuy]) VALUES (6, N'MEM       ', N'Phạm Thu Hường', N'Số 7, Lê Văn Chí, Quận 9', N'0347921825', 7.8, 7.8)
INSERT [dbo].[KhachHang] ([ID], [MaLoaiKH], [TenKH], [DiaChi], [SDT], [DiemTichLuyHienTai], [TongDiemTichLuy]) VALUES (7, N'MEM       ', N'Phạm Trung Kiên', N'Đào Trinh Nhất, Linh Tây, Thủ Đức', N'0989708845', 14.8, 14.8)
INSERT [dbo].[KhachHang] ([ID], [MaLoaiKH], [TenKH], [DiaChi], [SDT], [DiemTichLuyHienTai], [TongDiemTichLuy]) VALUES (8, N'MEM       ', N'Mai Huy Thanh', N'Võ Oanh, Phường 25, Bình Thạnh', N'0982387138', 15.1, 15.1)
INSERT [dbo].[KhachHang] ([ID], [MaLoaiKH], [TenKH], [DiaChi], [SDT], [DiemTichLuyHienTai], [TongDiemTichLuy]) VALUES (9, N'MEM       ', N'Hoàng Thị Thiết', N'Số 9, Đặng Văn Bi, Thủ Đức', N'0975951646', 70, 70)
INSERT [dbo].[KhachHang] ([ID], [MaLoaiKH], [TenKH], [DiaChi], [SDT], [DiemTichLuyHienTai], [TongDiemTichLuy]) VALUES (10, N'MEM       ', N'Phạm Thị Anh Thư', N'Hẻm 23, Lê Văn Việt, Quận 9', N'0347054018', 50, 50)
INSERT [dbo].[KhachHang] ([ID], [MaLoaiKH], [TenKH], [DiaChi], [SDT], [DiemTichLuyHienTai], [TongDiemTichLuy]) VALUES (11, N'MEM       ', N'Nguyễn Thị Kiều Oanh', N'Phạm Văn Đồng, Bình Thạnh', N'0987654321', 70, 70)
INSERT [dbo].[KhachHang] ([ID], [MaLoaiKH], [TenKH], [DiaChi], [SDT], [DiemTichLuyHienTai], [TongDiemTichLuy]) VALUES (12, N'MEM       ', N'Đặng Minh Tiến', N'Điện Biên Phủ, Gò Vấp', N'0868112113', 15.2, 15.2)
INSERT [dbo].[KhachHang] ([ID], [MaLoaiKH], [TenKH], [DiaChi], [SDT], [DiemTichLuyHienTai], [TongDiemTichLuy]) VALUES (13, N'MEM       ', N'Trần Thị Hồng', N'CMT8, Quận 1', N'0968124114', 25, 25)
INSERT [dbo].[KhachHang] ([ID], [MaLoaiKH], [TenKH], [DiaChi], [SDT], [DiemTichLuyHienTai], [TongDiemTichLuy]) VALUES (14, N'VIP       ', N'Bùi Phương Linh', N'Đường số 8, Linh Chiểu, Thủ Đức', N'0345065178', 50.5, 150.5)
INSERT [dbo].[KhachHang] ([ID], [MaLoaiKH], [TenKH], [DiaChi], [SDT], [DiemTichLuyHienTai], [TongDiemTichLuy]) VALUES (15, N'MEM       ', N'Vũ Thị Thủy Tiên', N'Ngô Gia Trí, Bình Thạnh', N'0968090641', 7.8, 7.8)
INSERT [dbo].[KhachHang] ([ID], [MaLoaiKH], [TenKH], [DiaChi], [SDT], [DiemTichLuyHienTai], [TongDiemTichLuy]) VALUES (16, N'MEM       ', N'Nguyễn Thành An', N'Làng Đại học, Dĩ An, Bình Dương', N'0357123456', 7.8, 7.8)
INSERT [dbo].[KhachHang] ([ID], [MaLoaiKH], [TenKH], [DiaChi], [SDT], [DiemTichLuyHienTai], [TongDiemTichLuy]) VALUES (17, N'MEM       ', N'Trần Hoàng Anh Tú', N'Đường số 6, Linh Chiểu, Thủ Đức', N'0987456351', 9.5, 9.5)
INSERT [dbo].[KhachHang] ([ID], [MaLoaiKH], [TenKH], [DiaChi], [SDT], [DiemTichLuyHienTai], [TongDiemTichLuy]) VALUES (18, N'MEM       ', N'Ngô Văn Đạt', N'Số 9, Linh Đông, Thủ Đức', N'0347016254', 12, 12)
INSERT [dbo].[KhachHang] ([ID], [MaLoaiKH], [TenKH], [DiaChi], [SDT], [DiemTichLuyHienTai], [TongDiemTichLuy]) VALUES (19, N'MEM       ', N'Đỗ Hữu Thọ', N'D5, Võ Oanh, Bình Thạnh', N'046514692 ', 12, 12)
INSERT [dbo].[KhachHang] ([ID], [MaLoaiKH], [TenKH], [DiaChi], [SDT], [DiemTichLuyHienTai], [TongDiemTichLuy]) VALUES (20, N'MEM       ', N'Norin Phạm', N'Amsterdam, Quận 5', N'0868090172', 21.6, 21.6)
INSERT [dbo].[KhachHang] ([ID], [MaLoaiKH], [TenKH], [DiaChi], [SDT], [DiemTichLuyHienTai], [TongDiemTichLuy]) VALUES (21, N'MEM       ', N'Vương Văn Vũ', N'Đồng Nai', N'0986294256', 0, 0)
INSERT [dbo].[KhachHang] ([ID], [MaLoaiKH], [TenKH], [DiaChi], [SDT], [DiemTichLuyHienTai], [TongDiemTichLuy]) VALUES (22, N'MEM       ', N'Hoàng Phi Hồng', N'Hà Nội', N'0985294207', 0, 0)
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
GO
INSERT [dbo].[LoaiMatHang] ([MaLoaiMH], [TenLoaiHang]) VALUES (N'T001      ', N'Cà Phê Máy')
INSERT [dbo].[LoaiMatHang] ([MaLoaiMH], [TenLoaiHang]) VALUES (N'T002      ', N'100% Hoa Quả Tươi')
INSERT [dbo].[LoaiMatHang] ([MaLoaiMH], [TenLoaiHang]) VALUES (N'T003      ', N'Sinh tố & đá xay')
INSERT [dbo].[LoaiMatHang] ([MaLoaiMH], [TenLoaiHang]) VALUES (N'T004      ', N'Cà phê phin truyền thống')
INSERT [dbo].[LoaiMatHang] ([MaLoaiMH], [TenLoaiHang]) VALUES (N'T005      ', N'Trà sữa đặc biệt')
INSERT [dbo].[LoaiMatHang] ([MaLoaiMH], [TenLoaiHang]) VALUES (N'T006      ', N'Sữa chua & cacao')
INSERT [dbo].[LoaiMatHang] ([MaLoaiMH], [TenLoaiHang]) VALUES (N'T007      ', N'Trà Hoa quả đặc biệt')
INSERT [dbo].[LoaiMatHang] ([MaLoaiMH], [TenLoaiHang]) VALUES (N'T008      ', N'Topping')
GO
INSERT [dbo].[Ban] ([MaBan], [SoBan], [TrangThai]) VALUES (N'B01       ', 1, N'Trống')
INSERT [dbo].[Ban] ([MaBan], [SoBan], [TrangThai]) VALUES (N'B02       ', 2, N'Trống')
INSERT [dbo].[Ban] ([MaBan], [SoBan], [TrangThai]) VALUES (N'B03       ', 3, N'Trống')
INSERT [dbo].[Ban] ([MaBan], [SoBan], [TrangThai]) VALUES (N'B04       ', 4, N'Trống')
INSERT [dbo].[Ban] ([MaBan], [SoBan], [TrangThai]) VALUES (N'B05       ', 5, N'Trống')
INSERT [dbo].[Ban] ([MaBan], [SoBan], [TrangThai]) VALUES (N'B06       ', 6, N'Trống')
INSERT [dbo].[Ban] ([MaBan], [SoBan], [TrangThai]) VALUES (N'B07       ', 7, N'Trống')
INSERT [dbo].[Ban] ([MaBan], [SoBan], [TrangThai]) VALUES (N'B08       ', 8, N'Trống')
INSERT [dbo].[Ban] ([MaBan], [SoBan], [TrangThai]) VALUES (N'B09       ', 9, N'Trống')
INSERT [dbo].[Ban] ([MaBan], [SoBan], [TrangThai]) VALUES (N'B10       ', 10, N'Trống')
GO
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-03-03' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-03-04' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-03-05' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-03-06' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-03-07' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-03-08' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-03-09' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-03-10' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-03-11' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-03-12' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-03-13' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-03-14' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-03-15' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-03-16' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-03-17' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-03-18' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-03-19' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-03-20' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-03-21' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-03-22' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-03-23' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-03-24' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-03-25' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-03-26' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-03-27' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-03-28' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-03-29' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-03-30' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-03-31' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-04-01' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-04-02' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-04-03' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-04-04' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-04-05' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-04-06' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-04-07' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-04-08' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-04-09' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-04-10' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-04-11' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-04-12' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CC        ', CAST(N'2023-04-13' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-03-03' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-03-04' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-03-05' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-03-06' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-03-07' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-03-08' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-03-09' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-03-10' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-03-11' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-03-12' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-03-13' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-03-14' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-03-15' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-03-16' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-03-17' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-03-18' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-03-19' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-03-20' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-03-21' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-03-22' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-03-23' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-03-24' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-03-25' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-03-26' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-03-27' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-03-28' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-03-29' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-03-30' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-03-31' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-04-01' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-04-02' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-04-03' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-04-04' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-04-05' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-04-06' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-04-07' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-04-08' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-04-09' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-04-10' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-04-11' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-04-12' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-04-13' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-04-19' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-04-30' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CS        ', CAST(N'2023-05-09' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-03-03' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-03-04' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-03-05' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-03-06' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-03-07' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-03-08' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-03-09' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-03-10' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-03-11' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-03-12' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-03-13' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-03-14' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-03-15' AS Date))
GO
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-03-16' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-03-17' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-03-18' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-03-19' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-03-20' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-03-21' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-03-22' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-03-23' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-03-24' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-03-25' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-03-26' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-03-27' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-03-28' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-03-29' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-03-30' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-03-31' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-04-01' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-04-02' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-04-03' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-04-04' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-04-05' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-04-06' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-04-07' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-04-08' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-04-09' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-04-10' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-04-11' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-04-12' AS Date))
INSERT [dbo].[CaLam] ([MaLoaiCa], [NgayLam]) VALUES (N'CT        ', CAST(N'2023-04-13' AS Date))
GO
INSERT [dbo].[MatHang] ([MaMH], [MaLoaiMH], [TenHang], [GiaTien]) VALUES (N'D001      ', N'T001      ', N'Latte', 39000)
INSERT [dbo].[MatHang] ([MaMH], [MaLoaiMH], [TenHang], [GiaTien]) VALUES (N'D002      ', N'T001      ', N'Cappuccino', 39000)
INSERT [dbo].[MatHang] ([MaMH], [MaLoaiMH], [TenHang], [GiaTien]) VALUES (N'D003      ', N'T001      ', N'Matcha Latte', 39000)
INSERT [dbo].[MatHang] ([MaMH], [MaLoaiMH], [TenHang], [GiaTien]) VALUES (N'D004      ', N'T002      ', N'Nước Cam tươi', 39000)
INSERT [dbo].[MatHang] ([MaMH], [MaLoaiMH], [TenHang], [GiaTien]) VALUES (N'D005      ', N'T002      ', N'Nước Chanh dây', 25000)
INSERT [dbo].[MatHang] ([MaMH], [MaLoaiMH], [TenHang], [GiaTien]) VALUES (N'D006      ', N'T002      ', N'Nước Chanh tươi hoa Đậu Biếc', 25000)
INSERT [dbo].[MatHang] ([MaMH], [MaLoaiMH], [TenHang], [GiaTien]) VALUES (N'D007      ', N'T003      ', N'Sinh tố Chanh Dây', 35000)
INSERT [dbo].[MatHang] ([MaMH], [MaLoaiMH], [TenHang], [GiaTien]) VALUES (N'D008      ', N'T003      ', N'Sinh tố Xoài', 35000)
INSERT [dbo].[MatHang] ([MaMH], [MaLoaiMH], [TenHang], [GiaTien]) VALUES (N'D009      ', N'T003      ', N'Cốt dừa cacao', 35000)
INSERT [dbo].[MatHang] ([MaMH], [MaLoaiMH], [TenHang], [GiaTien]) VALUES (N'D010      ', N'T004      ', N'Cà phê đá', 20000)
INSERT [dbo].[MatHang] ([MaMH], [MaLoaiMH], [TenHang], [GiaTien]) VALUES (N'D011      ', N'T004      ', N'Cà phê sữa', 25000)
INSERT [dbo].[MatHang] ([MaMH], [MaLoaiMH], [TenHang], [GiaTien]) VALUES (N'D012      ', N'T004      ', N'Bạc sỉu', 30000)
INSERT [dbo].[MatHang] ([MaMH], [MaLoaiMH], [TenHang], [GiaTien]) VALUES (N'D013      ', N'T005      ', N'Sữa tươi trân châu đường đen', 39000)
INSERT [dbo].[MatHang] ([MaMH], [MaLoaiMH], [TenHang], [GiaTien]) VALUES (N'D014      ', N'T005      ', N'Oolong kem trứng nướng', 39000)
INSERT [dbo].[MatHang] ([MaMH], [MaLoaiMH], [TenHang], [GiaTien]) VALUES (N'D015      ', N'T005      ', N'Socola kem trứng nướng', 39000)
INSERT [dbo].[MatHang] ([MaMH], [MaLoaiMH], [TenHang], [GiaTien]) VALUES (N'D016      ', N'T006      ', N'Sữa chua xoài nha đam', 35000)
INSERT [dbo].[MatHang] ([MaMH], [MaLoaiMH], [TenHang], [GiaTien]) VALUES (N'D017      ', N'T006      ', N'Sữa chua việt quất nha đam', 35000)
INSERT [dbo].[MatHang] ([MaMH], [MaLoaiMH], [TenHang], [GiaTien]) VALUES (N'D018      ', N'T006      ', N'Sữa chua cacao kem trứng nướng', 35000)
INSERT [dbo].[MatHang] ([MaMH], [MaLoaiMH], [TenHang], [GiaTien]) VALUES (N'D019      ', N'T007      ', N'Trà sen vàng machiato', 39000)
INSERT [dbo].[MatHang] ([MaMH], [MaLoaiMH], [TenHang], [GiaTien]) VALUES (N'D020      ', N'T007      ', N'Trà ổi hồng', 39000)
INSERT [dbo].[MatHang] ([MaMH], [MaLoaiMH], [TenHang], [GiaTien]) VALUES (N'D021      ', N'T007      ', N'Trà đào cam sả', 39000)
INSERT [dbo].[MatHang] ([MaMH], [MaLoaiMH], [TenHang], [GiaTien]) VALUES (N'D022      ', N'T008      ', N'Trân châu đen', 7000)
INSERT [dbo].[MatHang] ([MaMH], [MaLoaiMH], [TenHang], [GiaTien]) VALUES (N'D023      ', N'T008      ', N'Trân châu trắng', 7000)
INSERT [dbo].[MatHang] ([MaMH], [MaLoaiMH], [TenHang], [GiaTien]) VALUES (N'D024      ', N'T008      ', N'Nha đam', 7000)
INSERT [dbo].[MatHang] ([MaMH], [MaLoaiMH], [TenHang], [GiaTien]) VALUES (N'D025      ', N'T005      ', N'Trà sữa gạo rang', 35000)
INSERT [dbo].[MatHang] ([MaMH], [MaLoaiMH], [TenHang], [GiaTien]) VALUES (N'D026      ', N'T001      ', N'Cà phê chồn', 40000)
GO
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL001    ', N'Cafe A', N'Gram      ', 298)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL002    ', N'Sữa tươi', N'ml        ', 32)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL003    ', N'Đường que', N'Gói       ', 400)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL004    ', N'Ly giấy 270ml', N'Cái       ', NULL)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL005    ', N'Ống hút nóng', N'Ống       ', NULL)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL006    ', N'Nắp ly nóng', N'Cái       ', NULL)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL007    ', N'Siro đường trắng', N'ml        ', 20)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL008    ', N'Nắp cầu phi 90', N'Cái       ', NULL)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL009    ', N'Ống hút phi 8', N'Ống       ', NULL)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL010    ', N'Ly nhựa 400ml', N'Cái       ', NULL)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL011    ', N'Bột matcha', N'Gram      ', 620)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL012    ', N'Sữa đặc', N'ml        ', 65)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL013    ', N'Nước sôi', N'ml        ', NULL)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL014    ', N'Cam xanh', N'Gram      ', 35)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL015    ', N'Đường nước', N'ml        ', 17)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL016    ', N'Chanh dây', N'Gram      ', 24)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL017    ', N'Chanh xanh', N'Gram      ', 22)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL018    ', N'Nước hoa đậu biếc', N'ml        ', NULL)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL019    ', N'Nước cốt dừa', N'ml        ', 68)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL020    ', N'Bột cacao', N'gram      ', 146)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL021    ', N'Ly nhựa 500ml', N'Cái       ', NULL)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL022    ', N'Cốt chanh dây', N'ml        ', 96)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL023    ', N'Siro đường', N'ml        ', 20)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL024    ', N'Nước lọc', NULL, NULL)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL025    ', N'Đá bi', NULL, NULL)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL026    ', N'Xoài thịt', N'Gram      ', 57)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL027    ', N'Cafe việt', N'Gram      ', 170)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL028    ', N'Trân châu đen', N'Gram      ', 32)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL029    ', N'Siro đường đen', N'ml        ', 130)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL030    ', N'Rich', N'ml        ', 70)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL031    ', N'Trà olong', N'Gram      ', 200)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL032    ', N'Bột kem trứng', N'Gram      ', 178)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL033    ', N'Sốt chocolate', N'ml        ', 176)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL034    ', N'Sữa chua', N'ml        ', 6250)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL035    ', N'Mứt xoài', N'Gram      ', 175)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL036    ', N'Nha đam', N'Gram      ', 28)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL037    ', N'Mứt việt quất otb', N'ml        ', 133)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL038    ', N'Trà nhài', N'Gram      ', 140)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL039    ', N'Hạt sen', N'Gram      ', 62)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL040    ', N'Kem machiato', N'ml        ', 70)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL041    ', N'Chunky ổi hồng', N'ml        ', 175)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL042    ', N'Chanh', N'Gram      ', 22)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL043    ', N'Trân châu 3Q', N'Gram      ', 37)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL044    ', N'Trà đào', N'ml        ', 12)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL045    ', N'Siro đào DVC', N'ml        ', 236)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL046    ', N'Đào ngâm', N'Lát       ', 1500)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL047    ', N'Cam vàng', N'Gram      ', 45)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL048    ', N'Sả', N'Gram      ', 15)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL049    ', N'Trân châu khô', N'Gram      ', NULL)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL050    ', N'Đường đen', N'ml        ', NULL)
INSERT [dbo].[NguyenVatLieu] ([MaNVL], [TenNVL], [DonVi], [GiaMotDonVi]) VALUES (N'NVL051    ', N'Đường cát trắng', N'Gram      ', NULL)
GO
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-02-01T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-02-02T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-02-03T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-02-04T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-02-05T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-02-06T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-02-07T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-02-08T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-02-09T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-02-10T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-02-11T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-02-12T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-02-13T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-02-14T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-02-15T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-02-16T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-02-17T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-02-18T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-02-19T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-02-20T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-02-21T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-02-22T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-02-23T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-02-24T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-02-25T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-02-26T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-02-27T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-02-28T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-03-01T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-03-02T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-03-03T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-03-04T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-03-05T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-03-06T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-03-07T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-03-08T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-03-09T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-03-10T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-03-11T07:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMua] ([NgayGioMua]) VALUES (CAST(N'2023-04-24T07:09:05.000' AS DateTime))
GO
INSERT [dbo].[ChiTietMua] ([MaPhieuMua], [MaNVL], [SoLuongNVL], [ThanhTien]) VALUES (N'PM20230201070000', N'NVL002    ', 100, 3200)
INSERT [dbo].[ChiTietMua] ([MaPhieuMua], [MaNVL], [SoLuongNVL], [ThanhTien]) VALUES (N'PM20230201070000', N'NVL003    ', 5, 2000)
INSERT [dbo].[ChiTietMua] ([MaPhieuMua], [MaNVL], [SoLuongNVL], [ThanhTien]) VALUES (N'PM20230202070000', N'NVL002    ', 1000, 32000)
GO
SET IDENTITY_INSERT [dbo].[HoaDon] ON 

INSERT [dbo].[HoaDon] ([ID], [MaNV], [MaKH], [MaBan], [NgayGioInHoaDon], [TongGiaTien], [DiemSuDung]) VALUES (1, N'NV00000007', N'KH000000001', N'B03       ', CAST(N'2023-03-03T08:11:23.000' AS DateTime), 900000, 0)
INSERT [dbo].[HoaDon] ([ID], [MaNV], [MaKH], [MaBan], [NgayGioInHoaDon], [TongGiaTien], [DiemSuDung]) VALUES (2, N'NV00000007', N'KH000000001', N'B04       ', CAST(N'2023-03-04T09:25:45.000' AS DateTime), 100000, 0)
INSERT [dbo].[HoaDon] ([ID], [MaNV], [MaKH], [MaBan], [NgayGioInHoaDon], [TongGiaTien], [DiemSuDung]) VALUES (3, N'NV00000008', N'KH000000001', N'B05       ', CAST(N'2023-03-04T15:45:31.000' AS DateTime), 78000, 8)
INSERT [dbo].[HoaDon] ([ID], [MaNV], [MaKH], [MaBan], [NgayGioInHoaDon], [TongGiaTien], [DiemSuDung]) VALUES (4, N'NV00000007', N'KH000000002', N'B01       ', CAST(N'2023-03-03T07:35:39.000' AS DateTime), 1017000, 0)
INSERT [dbo].[HoaDon] ([ID], [MaNV], [MaKH], [MaBan], [NgayGioInHoaDon], [TongGiaTien], [DiemSuDung]) VALUES (5, N'NV00000007', N'KH000000002', N'B02       ', CAST(N'2023-03-05T07:25:19.000' AS DateTime), 39000, 9)
INSERT [dbo].[HoaDon] ([ID], [MaNV], [MaKH], [MaBan], [NgayGioInHoaDon], [TongGiaTien], [DiemSuDung]) VALUES (6, N'NV00000008', N'KH000000003', N'B03       ', CAST(N'2023-03-03T17:25:50.000' AS DateTime), 1170000, 0)
INSERT [dbo].[HoaDon] ([ID], [MaNV], [MaKH], [MaBan], [NgayGioInHoaDon], [TongGiaTien], [DiemSuDung]) VALUES (7, N'NV00000007', N'KH000000003', N'B05       ', CAST(N'2023-03-06T09:33:10.000' AS DateTime), 70000, 20)
INSERT [dbo].[HoaDon] ([ID], [MaNV], [MaKH], [MaBan], [NgayGioInHoaDon], [TongGiaTien], [DiemSuDung]) VALUES (8, N'NV00000007', N'KH000000004', N'B02       ', CAST(N'2023-03-03T10:33:10.000' AS DateTime), 1065000, 0)
INSERT [dbo].[HoaDon] ([ID], [MaNV], [MaKH], [MaBan], [NgayGioInHoaDon], [TongGiaTien], [DiemSuDung]) VALUES (9, N'NV00000007', N'KH000000005', N'B09       ', CAST(N'2023-03-03T10:42:41.000' AS DateTime), 1065000, 0)
INSERT [dbo].[HoaDon] ([ID], [MaNV], [MaKH], [MaBan], [NgayGioInHoaDon], [TongGiaTien], [DiemSuDung]) VALUES (10, N'NV00000007', N'KH000000005', N'B01       ', CAST(N'2023-03-07T10:37:26.000' AS DateTime), 35000, 5)
INSERT [dbo].[HoaDon] ([ID], [MaNV], [MaKH], [MaBan], [NgayGioInHoaDon], [TongGiaTien], [DiemSuDung]) VALUES (11, N'NV00000008', N'KH000000006', N'B10       ', CAST(N'2023-03-03T13:45:56.000' AS DateTime), 78000, 0)
INSERT [dbo].[HoaDon] ([ID], [MaNV], [MaKH], [MaBan], [NgayGioInHoaDon], [TongGiaTien], [DiemSuDung]) VALUES (12, N'NV00000008', N'KH000000007', N'B08       ', CAST(N'2023-03-03T13:48:32.000' AS DateTime), 148000, 0)
INSERT [dbo].[HoaDon] ([ID], [MaNV], [MaKH], [MaBan], [NgayGioInHoaDon], [TongGiaTien], [DiemSuDung]) VALUES (13, N'NV00000008', N'KH000000008', N'B06       ', CAST(N'2023-03-08T14:02:15.000' AS DateTime), 151000, 0)
INSERT [dbo].[HoaDon] ([ID], [MaNV], [MaKH], [MaBan], [NgayGioInHoaDon], [TongGiaTien], [DiemSuDung]) VALUES (14, N'NV00000007', N'KH000000009', N'B01       ', CAST(N'2023-03-13T09:02:52.000' AS DateTime), 700000, 0)
INSERT [dbo].[HoaDon] ([ID], [MaNV], [MaKH], [MaBan], [NgayGioInHoaDon], [TongGiaTien], [DiemSuDung]) VALUES (15, N'NV00000007', N'KH000000010', N'B02       ', CAST(N'2023-03-15T08:42:52.000' AS DateTime), 500000, 0)
INSERT [dbo].[HoaDon] ([ID], [MaNV], [MaKH], [MaBan], [NgayGioInHoaDon], [TongGiaTien], [DiemSuDung]) VALUES (16, N'NV00000008', N'KH000000011', N'B03       ', CAST(N'2023-03-25T18:54:23.000' AS DateTime), 700000, 0)
INSERT [dbo].[HoaDon] ([ID], [MaNV], [MaKH], [MaBan], [NgayGioInHoaDon], [TongGiaTien], [DiemSuDung]) VALUES (17, N'NV00000008', N'KH000000012', N'B04       ', CAST(N'2023-03-25T19:11:23.000' AS DateTime), 152000, 0)
INSERT [dbo].[HoaDon] ([ID], [MaNV], [MaKH], [MaBan], [NgayGioInHoaDon], [TongGiaTien], [DiemSuDung]) VALUES (18, N'NV00000007', N'KH000000013', N'B05       ', CAST(N'2023-03-27T10:36:44.000' AS DateTime), 250000, 0)
INSERT [dbo].[HoaDon] ([ID], [MaNV], [MaKH], [MaBan], [NgayGioInHoaDon], [TongGiaTien], [DiemSuDung]) VALUES (19, N'NV00000007', N'KH000000014', N'B06       ', CAST(N'2023-04-01T07:14:48.000' AS DateTime), 1505000, 100)
INSERT [dbo].[HoaDon] ([ID], [MaNV], [MaKH], [MaBan], [NgayGioInHoaDon], [TongGiaTien], [DiemSuDung]) VALUES (20, N'NV00000007', N'KH000000015', N'B07       ', CAST(N'2023-04-01T07:21:12.000' AS DateTime), 78000, 0)
INSERT [dbo].[HoaDon] ([ID], [MaNV], [MaKH], [MaBan], [NgayGioInHoaDon], [TongGiaTien], [DiemSuDung]) VALUES (21, N'NV00000007', N'KH000000016', N'B08       ', CAST(N'2023-04-01T07:23:51.000' AS DateTime), 78000, 0)
INSERT [dbo].[HoaDon] ([ID], [MaNV], [MaKH], [MaBan], [NgayGioInHoaDon], [TongGiaTien], [DiemSuDung]) VALUES (22, N'NV00000008', N'KH000000017', N'B09       ', CAST(N'2023-04-03T09:51:16.000' AS DateTime), 95000, 0)
INSERT [dbo].[HoaDon] ([ID], [MaNV], [MaKH], [MaBan], [NgayGioInHoaDon], [TongGiaTien], [DiemSuDung]) VALUES (23, N'NV00000008', N'KH000000018', N'B10       ', CAST(N'2023-04-03T10:11:35.000' AS DateTime), 120000, 0)
INSERT [dbo].[HoaDon] ([ID], [MaNV], [MaKH], [MaBan], [NgayGioInHoaDon], [TongGiaTien], [DiemSuDung]) VALUES (24, N'NV00000007', N'KH000000019', N'B03       ', CAST(N'2023-04-03T10:21:41.000' AS DateTime), 60000, 0)
INSERT [dbo].[HoaDon] ([ID], [MaNV], [MaKH], [MaBan], [NgayGioInHoaDon], [TongGiaTien], [DiemSuDung]) VALUES (25, N'NV00000007', N'KH000000019', N'B01       ', CAST(N'2023-04-05T09:58:35.000' AS DateTime), 60000, 0)
INSERT [dbo].[HoaDon] ([ID], [MaNV], [MaKH], [MaBan], [NgayGioInHoaDon], [TongGiaTien], [DiemSuDung]) VALUES (26, N'NV00000007', N'KH000000020', N'B02       ', CAST(N'2023-04-05T09:59:55.000' AS DateTime), 78000, 0)
INSERT [dbo].[HoaDon] ([ID], [MaNV], [MaKH], [MaBan], [NgayGioInHoaDon], [TongGiaTien], [DiemSuDung]) VALUES (27, N'NV00000007', N'KH000000020', N'B04       ', CAST(N'2023-04-06T10:58:32.000' AS DateTime), 78000, 0)
INSERT [dbo].[HoaDon] ([ID], [MaNV], [MaKH], [MaBan], [NgayGioInHoaDon], [TongGiaTien], [DiemSuDung]) VALUES (28, N'NV00000008', N'KH000000020', N'B07       ', CAST(N'2023-04-08T07:48:53.000' AS DateTime), 60000, 0)
INSERT [dbo].[HoaDon] ([ID], [MaNV], [MaKH], [MaBan], [NgayGioInHoaDon], [TongGiaTien], [DiemSuDung]) VALUES (56, N'NV00000007', NULL, N'B07       ', CAST(N'2023-05-04T19:00:56.727' AS DateTime), 78000, 0)
INSERT [dbo].[HoaDon] ([ID], [MaNV], [MaKH], [MaBan], [NgayGioInHoaDon], [TongGiaTien], [DiemSuDung]) VALUES (57, NULL, NULL, N'B02       ', CAST(N'2023-05-08T21:44:18.757' AS DateTime), 39000, 0)
INSERT [dbo].[HoaDon] ([ID], [MaNV], [MaKH], [MaBan], [NgayGioInHoaDon], [TongGiaTien], [DiemSuDung]) VALUES (61, N'NV00000007', N'KH000000015', NULL, CAST(N'2023-05-09T17:58:45.173' AS DateTime), 35000, 0)
INSERT [dbo].[HoaDon] ([ID], [MaNV], [MaKH], [MaBan], [NgayGioInHoaDon], [TongGiaTien], [DiemSuDung]) VALUES (62, N'NV00000007', N'KH000000007', N'B01       ', CAST(N'2023-05-09T17:59:49.637' AS DateTime), 39000, 40)
SET IDENTITY_INSERT [dbo].[HoaDon] OFF
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000001', N'D012      ', 30, 900000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000002', N'D005      ', 2, 50000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000002', N'D006      ', 2, 50000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000003', N'D001      ', 2, 78000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000004', N'D012      ', 30, 900000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000004', N'D019      ', 3, 117000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000005', N'D004      ', 1, 39000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000006', N'D014      ', 20, 780000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000006', N'D021      ', 10, 390000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000007', N'D009      ', 2, 70000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000008', N'D005      ', 15, 375000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000008', N'D012      ', 10, 300000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000008', N'D021      ', 10, 390000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000009', N'D005      ', 15, 375000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000009', N'D012      ', 10, 300000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000009', N'D021      ', 10, 390000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000010', N'D016      ', 1, 35000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000011', N'D001      ', 1, 39000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000011', N'D019      ', 1, 39000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000012', N'D001      ', 1, 39000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000012', N'D008      ', 2, 70000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000012', N'D020      ', 1, 39000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000013', N'D007      ', 3, 105000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000013', N'D013      ', 1, 39000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000013', N'D022      ', 1, 7000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000014', N'D018      ', 20, 700000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000015', N'D006      ', 10, 250000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000015', N'D011      ', 10, 250000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000016', N'D017      ', 20, 700000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000017', N'D012      ', 2, 60000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000017', N'D013      ', 2, 78000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000017', N'D023      ', 2, 14000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000018', N'D006      ', 5, 125000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000018', N'D021      ', 5, 125000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000019', N'D001      ', 9, 351000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000019', N'D007      ', 3, 105000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000019', N'D011      ', 15, 375000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000019', N'D013      ', 11, 429000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000019', N'D018      ', 7, 245000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000020', N'D013      ', 2, 78000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000021', N'D013      ', 2, 78000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000022', N'D011      ', 1, 25000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000022', N'D018      ', 2, 70000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000023', N'D012      ', 4, 120000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000024', N'D012      ', 2, 60000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000025', N'D012      ', 2, 60000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000026', N'D013      ', 2, 78000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000027', N'D013      ', 2, 78000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000028', N'D012      ', 2, 60000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000056', N'D014      ', 2, 78000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000057', N'D001      ', 1, 39000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000061', N'D018      ', 1, 35000, NULL)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMH], [SoLuongMH], [ThanhTien], [GhiChu]) VALUES (N'BILL000000062', N'D015      ', 1, 39000, NULL)
GO
INSERT [dbo].[Kho] ([NgayThang]) VALUES (CAST(N'2023-02-01' AS Date))
INSERT [dbo].[Kho] ([NgayThang]) VALUES (CAST(N'2023-02-07' AS Date))
INSERT [dbo].[Kho] ([NgayThang]) VALUES (CAST(N'2023-02-14' AS Date))
INSERT [dbo].[Kho] ([NgayThang]) VALUES (CAST(N'2023-02-21' AS Date))
INSERT [dbo].[Kho] ([NgayThang]) VALUES (CAST(N'2023-02-28' AS Date))
INSERT [dbo].[Kho] ([NgayThang]) VALUES (CAST(N'2023-03-07' AS Date))
INSERT [dbo].[Kho] ([NgayThang]) VALUES (CAST(N'2023-05-05' AS Date))
INSERT [dbo].[Kho] ([NgayThang]) VALUES (CAST(N'2023-05-07' AS Date))
GO
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL001    ', N'KHO20230201', CAST(N'2023-05-31' AS Date), 60)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL002    ', N'KHO20230207', CAST(N'2023-06-01' AS Date), 200)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL002    ', N'KHO20230505', CAST(N'2023-10-05' AS Date), 0)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL003    ', N'KHO20230214', CAST(N'2023-06-15' AS Date), 120)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL004    ', N'KHO20230221', CAST(N'2023-06-20' AS Date), 180)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL005    ', N'KHO20230228', CAST(N'2023-06-30' AS Date), 90)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL006    ', N'KHO20230307', CAST(N'2023-07-05' AS Date), 150)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL007    ', N'KHO20230201', CAST(N'2023-07-10' AS Date), 130)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL008    ', N'KHO20230207', CAST(N'2023-07-15' AS Date), 160)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL009    ', N'KHO20230214', CAST(N'2023-07-20' AS Date), 110)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL010    ', N'KHO20230221', CAST(N'2023-07-25' AS Date), 140)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL011    ', N'KHO20230228', CAST(N'2023-07-31' AS Date), 70)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL012    ', N'KHO20230307', CAST(N'2023-08-05' AS Date), 120)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL013    ', N'KHO20230201', CAST(N'2023-08-10' AS Date), 110)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL014    ', N'KHO20230207', CAST(N'2023-08-15' AS Date), 130)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL015    ', N'KHO20230214', CAST(N'2023-08-20' AS Date), 180)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL016    ', N'KHO20230221', CAST(N'2023-08-25' AS Date), 150)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL017    ', N'KHO20230228', CAST(N'2023-08-31' AS Date), 80)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL018    ', N'KHO20230307', CAST(N'2023-09-05' AS Date), 170)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL019    ', N'KHO20230201', CAST(N'2023-09-10' AS Date), 130)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL020    ', N'KHO20230207', CAST(N'2023-09-15' AS Date), 140)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL021    ', N'KHO20230214', CAST(N'2023-09-20' AS Date), 120)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL022    ', N'KHO20230221', CAST(N'2023-09-25' AS Date), 110)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL023    ', N'KHO20230228', CAST(N'2023-09-30' AS Date), 60)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL024    ', N'KHO20230307', CAST(N'2023-10-05' AS Date), 150)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL025    ', N'KHO20230201', CAST(N'2023-10-10' AS Date), 90)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL026    ', N'KHO20230207', CAST(N'2023-10-15' AS Date), 120)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL027    ', N'KHO20230214', CAST(N'2023-10-20' AS Date), 140)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL028    ', N'KHO20230221', CAST(N'2023-10-25' AS Date), 130)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL029    ', N'KHO20230228', CAST(N'2023-10-31' AS Date), 70)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL030    ', N'KHO20230307', CAST(N'2023-11-05' AS Date), 160)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL031    ', N'KHO20230221', CAST(N'2023-06-25' AS Date), 130)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL032    ', N'KHO20230228', CAST(N'2023-06-30' AS Date), 140)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL033    ', N'KHO20230201', CAST(N'2023-07-05' AS Date), 100)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL034    ', N'KHO20230207', CAST(N'2023-07-10' AS Date), 150)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL035    ', N'KHO20230214', CAST(N'2023-07-15' AS Date), 120)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL036    ', N'KHO20230221', CAST(N'2023-07-20' AS Date), 170)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL037    ', N'KHO20230228', CAST(N'2023-07-25' AS Date), 110)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL038    ', N'KHO20230201', CAST(N'2023-07-30' AS Date), 180)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL039    ', N'KHO20230207', CAST(N'2023-08-05' AS Date), 140)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL039    ', N'KHO20230507', CAST(N'2023-06-07' AS Date), 100)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL040    ', N'KHO20230214', CAST(N'2023-08-10' AS Date), 140)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL041    ', N'KHO20230221', CAST(N'2023-08-15' AS Date), 200)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL042    ', N'KHO20230228', CAST(N'2023-08-20' AS Date), 130)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL043    ', N'KHO20230201', CAST(N'2023-08-25' AS Date), 170)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL044    ', N'KHO20230207', CAST(N'2023-08-30' AS Date), 110)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL045    ', N'KHO20230214', CAST(N'2023-09-05' AS Date), 150)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL046    ', N'KHO20230221', CAST(N'2023-09-10' AS Date), 180)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL047    ', N'KHO20230228', CAST(N'2023-09-15' AS Date), 190)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL048    ', N'KHO20230201', CAST(N'2023-09-20' AS Date), 140)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL049    ', N'KHO20230207', CAST(N'2023-09-25' AS Date), 200)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL050    ', N'KHO20230214', CAST(N'2023-09-30' AS Date), 130)
INSERT [dbo].[LuuTru] ([MaNVL], [MaKho], [HSD], [SoLuongConLai]) VALUES (N'NVL051    ', N'KHO20230221', CAST(N'2023-10-05' AS Date), 170)
GO
INSERT [dbo].[NhapKho] ([MaNVL], [MaKho], [SoLuong], [GioNhap]) VALUES (N'NVL002    ', N'KHO20230505', 50, CAST(N'23:52:59' AS Time))
INSERT [dbo].[NhapKho] ([MaNVL], [MaKho], [SoLuong], [GioNhap]) VALUES (N'NVL002    ', N'KHO20230505', 50, CAST(N'23:53:28' AS Time))
INSERT [dbo].[NhapKho] ([MaNVL], [MaKho], [SoLuong], [GioNhap]) VALUES (N'NVL039    ', N'KHO20230507', 100, CAST(N'16:50:20' AS Time))
GO
INSERT [dbo].[XuatKho] ([MaNVL], [MaKho], [SoLuong], [NgayGioXuat]) VALUES (N'NVL001    ', N'KHO20230201', 40, CAST(N'2023-05-06T10:53:12.000' AS DateTime))
INSERT [dbo].[XuatKho] ([MaNVL], [MaKho], [SoLuong], [NgayGioXuat]) VALUES (N'NVL002    ', N'KHO20230505', 50, CAST(N'2023-05-06T09:26:38.000' AS DateTime))
INSERT [dbo].[XuatKho] ([MaNVL], [MaKho], [SoLuong], [NgayGioXuat]) VALUES (N'NVL002    ', N'KHO20230505', 50, CAST(N'2023-05-06T10:34:21.000' AS DateTime))
INSERT [dbo].[XuatKho] ([MaNVL], [MaKho], [SoLuong], [NgayGioXuat]) VALUES (N'NVL039    ', N'KHO20230207', 50, CAST(N'2023-05-07T16:52:05.000' AS DateTime))
GO
INSERT [dbo].[NhomNguoiDung] ([MaNhomNguoiDung], [TenNhom], [TenRole]) VALUES (N'NVGROUP', N'Nhân viên', N'Staff')
INSERT [dbo].[NhomNguoiDung] ([MaNhomNguoiDung], [TenNhom], [TenRole]) VALUES (N'QLGROUP', N'Quản lý', N'sysadmin')
GO
INSERT [dbo].[DangNhap] ([TenNguoiDung], [MatKhau], [MaNV]) VALUES (N'adminTS', N'0986294205', NULL)
GO
INSERT [dbo].[PhanNhom] ([MaNV], [MaNhomNguoiDung]) VALUES (N'NV00000001', N'NVGROUP')
INSERT [dbo].[PhanNhom] ([MaNV], [MaNhomNguoiDung]) VALUES (N'NV00000007', N'NVGROUP')
INSERT [dbo].[PhanNhom] ([MaNV], [MaNhomNguoiDung]) VALUES (N'NV00000008', N'NVGROUP')
GO

INSERT [dbo].[PhanCong] ([MaNV], [MaCa], [DiemDanh]) VALUES (N'NV00000001', N'CLC20230303', 1)
INSERT [dbo].[PhanCong] ([MaNV], [MaCa], [DiemDanh]) VALUES (N'NV00000001', N'CLS20230303', 1)
INSERT [dbo].[PhanCong] ([MaNV], [MaCa], [DiemDanh]) VALUES (N'NV00000001', N'CLS20230430', 1)
INSERT [dbo].[PhanCong] ([MaNV], [MaCa], [DiemDanh]) VALUES (N'NV00000002', N'CLS20230303', 1)
INSERT [dbo].[PhanCong] ([MaNV], [MaCa], [DiemDanh]) VALUES (N'NV00000002', N'CLT20230303', 1)
INSERT [dbo].[PhanCong] ([MaNV], [MaCa], [DiemDanh]) VALUES (N'NV00000003', N'CLC20230303', 1)
INSERT [dbo].[PhanCong] ([MaNV], [MaCa], [DiemDanh]) VALUES (N'NV00000004', N'CLC20230303', 1)
INSERT [dbo].[PhanCong] ([MaNV], [MaCa], [DiemDanh]) VALUES (N'NV00000004', N'CLS20230303', 1)
INSERT [dbo].[PhanCong] ([MaNV], [MaCa], [DiemDanh]) VALUES (N'NV00000005', N'CLT20230303', 1)
INSERT [dbo].[PhanCong] ([MaNV], [MaCa], [DiemDanh]) VALUES (N'NV00000006', N'CLT20230303', 1)
INSERT [dbo].[PhanCong] ([MaNV], [MaCa], [DiemDanh]) VALUES (N'NV00000007', N'CLC20230303', 1)
INSERT [dbo].[PhanCong] ([MaNV], [MaCa], [DiemDanh]) VALUES (N'NV00000007', N'CLS20230303', 1)
INSERT [dbo].[PhanCong] ([MaNV], [MaCa], [DiemDanh]) VALUES (N'NV00000008', N'CLT20230303', 1)
INSERT [dbo].[PhanCong] ([MaNV], [MaCa], [DiemDanh]) VALUES (N'NV00000009', N'CLS20230303', 1)
INSERT [dbo].[PhanCong] ([MaNV], [MaCa], [DiemDanh]) VALUES (N'NV00000009', N'CLT20230303', 1)
INSERT [dbo].[PhanCong] ([MaNV], [MaCa], [DiemDanh]) VALUES (N'NV00000010', N'CLC20230303', 1)
INSERT [dbo].[PhanCong] ([MaNV], [MaCa], [DiemDanh]) VALUES (N'NV00000010', N'CLS20230303', 1)
INSERT [dbo].[PhanCong] ([MaNV], [MaCa], [DiemDanh]) VALUES (N'NV00000011', N'CLC20230303', 0)
INSERT [dbo].[PhanCong] ([MaNV], [MaCa], [DiemDanh]) VALUES (N'NV00000012', N'CLT20230303', 1)
INSERT [dbo].[PhanCong] ([MaNV], [MaCa], [DiemDanh]) VALUES (N'NV00000013', N'CLC20230303', 1)
INSERT [dbo].[PhanCong] ([MaNV], [MaCa], [DiemDanh]) VALUES (N'NV00000013', N'CLS20230303', 1)
INSERT [dbo].[PhanCong] ([MaNV], [MaCa], [DiemDanh]) VALUES (N'NV00000014', N'CLT20230303', 1)
INSERT [dbo].[PhanCong] ([MaNV], [MaCa], [DiemDanh]) VALUES (N'NV00000016', N'CLS20230419', 0)
GO

INSERT [dbo].[ChiTietLuongNgay] ([MaNV], [MaCa], [MaChucVu], [NgayLuong], [ThanhTien], [KyLuong]) VALUES (N'NV00000001', N'CLC20230303', N'CB001     ', CAST(N'2023-03-03' AS Date), 92000, CAST(N'2023-03-31' AS Date))
INSERT [dbo].[ChiTietLuongNgay] ([MaNV], [MaCa], [MaChucVu], [NgayLuong], [ThanhTien], [KyLuong]) VALUES (N'NV00000001', N'CLS20230430', N'CB001     ', CAST(N'2023-04-30' AS Date), 92000, CAST(N'2023-04-30' AS Date))
INSERT [dbo].[ChiTietLuongNgay] ([MaNV], [MaCa], [MaChucVu], [NgayLuong], [ThanhTien], [KyLuong]) VALUES (N'NV00000002', N'CLS20230303', N'CB001     ', CAST(N'2023-03-03' AS Date), 92000, CAST(N'2023-03-31' AS Date))
INSERT [dbo].[ChiTietLuongNgay] ([MaNV], [MaCa], [MaChucVu], [NgayLuong], [ThanhTien], [KyLuong]) VALUES (N'NV00000003', N'CLC20230303', N'CB001     ', CAST(N'2023-03-03' AS Date), 92000, CAST(N'2023-03-31' AS Date))
INSERT [dbo].[ChiTietLuongNgay] ([MaNV], [MaCa], [MaChucVu], [NgayLuong], [ThanhTien], [KyLuong]) VALUES (N'NV00000004', N'CLC20230303', N'CB001     ', CAST(N'2023-03-03' AS Date), 92000, CAST(N'2023-03-31' AS Date))
INSERT [dbo].[ChiTietLuongNgay] ([MaNV], [MaCa], [MaChucVu], [NgayLuong], [ThanhTien], [KyLuong]) VALUES (N'NV00000005', N'CLT20230303', N'CB001     ', CAST(N'2023-03-03' AS Date), 100000, CAST(N'2023-03-31' AS Date))
INSERT [dbo].[ChiTietLuongNgay] ([MaNV], [MaCa], [MaChucVu], [NgayLuong], [ThanhTien], [KyLuong]) VALUES (N'NV00000006', N'CLT20230303', N'CB001     ', CAST(N'2023-03-03' AS Date), 100000, CAST(N'2023-03-31' AS Date))
INSERT [dbo].[ChiTietLuongNgay] ([MaNV], [MaCa], [MaChucVu], [NgayLuong], [ThanhTien], [KyLuong]) VALUES (N'NV00000007', N'CLC20230303', N'TN002     ', CAST(N'2023-03-03' AS Date), 92000, CAST(N'2023-03-31' AS Date))
INSERT [dbo].[ChiTietLuongNgay] ([MaNV], [MaCa], [MaChucVu], [NgayLuong], [ThanhTien], [KyLuong]) VALUES (N'NV00000008', N'CLT20230303', N'TN002     ', CAST(N'2023-03-03' AS Date), 100000, CAST(N'2023-03-31' AS Date))
INSERT [dbo].[ChiTietLuongNgay] ([MaNV], [MaCa], [MaChucVu], [NgayLuong], [ThanhTien], [KyLuong]) VALUES (N'NV00000009', N'CLS20230303', N'PC003     ', CAST(N'2023-03-03' AS Date), 92000, CAST(N'2023-03-31' AS Date))
INSERT [dbo].[ChiTietLuongNgay] ([MaNV], [MaCa], [MaChucVu], [NgayLuong], [ThanhTien], [KyLuong]) VALUES (N'NV00000010', N'CLS20230303', N'PC003     ', CAST(N'2023-03-03' AS Date), 92000, CAST(N'2023-03-31' AS Date))
INSERT [dbo].[ChiTietLuongNgay] ([MaNV], [MaCa], [MaChucVu], [NgayLuong], [ThanhTien], [KyLuong]) VALUES (N'NV00000011', N'CLC20230303', N'PC003     ', CAST(N'2023-03-03' AS Date), 0, CAST(N'2023-03-31' AS Date))
INSERT [dbo].[ChiTietLuongNgay] ([MaNV], [MaCa], [MaChucVu], [NgayLuong], [ThanhTien], [KyLuong]) VALUES (N'NV00000012', N'CLT20230303', N'PC003     ', CAST(N'2023-03-03' AS Date), 100000, CAST(N'2023-03-31' AS Date))
INSERT [dbo].[ChiTietLuongNgay] ([MaNV], [MaCa], [MaChucVu], [NgayLuong], [ThanhTien], [KyLuong]) VALUES (N'NV00000013', N'CLC20230303', N'BV004     ', CAST(N'2023-03-03' AS Date), 72000, CAST(N'2023-03-31' AS Date))
INSERT [dbo].[ChiTietLuongNgay] ([MaNV], [MaCa], [MaChucVu], [NgayLuong], [ThanhTien], [KyLuong]) VALUES (N'NV00000013', N'CLS20230303', N'BV004     ', CAST(N'2023-03-03' AS Date), 0, CAST(N'2023-03-31' AS Date))
INSERT [dbo].[ChiTietLuongNgay] ([MaNV], [MaCa], [MaChucVu], [NgayLuong], [ThanhTien], [KyLuong]) VALUES (N'NV00000014', N'CLT20230303', N'BV004     ', CAST(N'2023-03-03' AS Date), 80000, CAST(N'2023-03-31' AS Date))
INSERT [dbo].[ChiTietLuongNgay] ([MaNV], [MaCa], [MaChucVu], [NgayLuong], [ThanhTien], [KyLuong]) VALUES (N'NV00000016', N'CLS20230419', N'CB001     ', CAST(N'2023-04-19' AS Date), 0, CAST(N'2023-04-30' AS Date))
GO

--=======================================================================================================================================
--TẠO VIEW
--VIEW CALAM
create view VW_CaLam AS
select MaCa, MaLoaiCa, NgayLam from CaLam
GO
--VIEW CTHĐ
CREATE VIEW VW_ChiTietHoaDon AS
Select 
	MaHoaDon, 
	TenHang, 
	SoLuongMH, 
	ThanhTien
From MatHang inner join ChiTietHoaDon on MatHang.MaMH = ChiTietHoaDon.MaMH
GO
--VIEW CHI TIẾT LƯƠNG
CREATE VIEW VW_ChiTietLuong AS
SELECT MaNV, MaCa, ChucVu.TenChucVu, MaLuong, NgayLuong, ThanhTien, KyLuong 
FROM ChiTietLuongNgay join ChucVu ON ChiTietLuongNgay.MaChucVu=ChucVu.MaChucVu
GO
--VIEW CHI TIET MUA
CREATE VIEW VW_ChiTietMua AS
Select 
	MaPhieuMua, 
	TenNVL, 
	SoLuongNVL, 
	ThanhTien, 
	NgayGioMua
From NguyenVatLieu, (Select ChiTietMua.MaPhieuMua, MaNVL, SoLuongNVL, ThanhTien, NgayGioMua
					 From ChiTietMua inner join PhieuMua 
								on ChiTietMua.MaPhieuMua = PhieuMua.MaPhieuMua) Q
Where NguyenVatLieu.MaNVL = Q.MaNVL
GO
--VIEW DANH MỤC SẢN PHẨM BÁN CHẠY
CREATE VIEW VW_DanhMucSanPhamBanChay AS
SELECT TOP(10) P.TenHang, P.TenLoaiHang, sl AS SoLuong, Thang, Nam
FROM ( SELECT distinct MaMH, SUM (SoLuongMH) AS sl, MONTH(NgayGioInHoaDon) as Thang, YEAR(NgayGioInHoaDon) as Nam
				FROM HoaDon, ChiTietHoaDon
				WHERE HoaDon.MaHoaDon = ChiTietHoaDon.MaHoaDon
				GROUP BY MaMH,NgayGioInHoaDon) Q, ( SELECT MatHang.MaMH, TenHang, LoaiMatHang.TenLoaiHang
									FROM MatHang, LoaiMatHang
									WHERE MatHang.MaLoaiMH = LoaiMatHang.MaLoaiMH ) P
WHERE P.MaMH = Q.MaMH
ORDER BY sl DESC
GO
--VIEW THÔNG TIN NHẬP KHO
create view VW_ThongTinNhapKho
AS
SELECT NgayThang, NguyenVatLieu.TenNVL, SoLuong, GioNhap
FROM NhapKho inner join Kho vw on NhapKho.MaKho = vw.MaKho inner join NguyenVatLieu on NhapKho.MaNVL = NguyenVatLieu.MaNVL
GO
--VIEW THÔNG TIN XUẤT KHO
CREATE VIEW VW_ThongTinXuatKho
AS
SELECT NgayThang, XuatKho.NgayGioXuat, NguyenVatLieu.TenNVL, SoLuong
FROM XuatKho inner join Kho on XuatKho.MaKho = Kho.MaKho inner join NguyenVatLieu on XuatKho.MaNVL = NguyenVatLieu.MaNVL
GO
--VIEW LOAICALAM
create view VW_LoaiCaLam AS
SELECT MaLoaiCa, TenLoaiCa, GioBatDau, GioKetThuc
FROM  LoaiCa
GO
--VIEW LOAIKHACHHANG
CREATE VIEW VW_LoaiKhachHang AS
SELECT MaLoaiKH, TenLoaiKH, GhiChu
FROM LoaiKhachHang
GO
--VIEW LUONGNHANVIEN
CREATE VIEW VW_LuongNhanVien AS
SELECT DISTINCT NhanVien.MaNV, HoTen, TongTienLuong, q.KyLuong
FROM (ChiTietLuongNgay JOIN NhanVien 
	ON ChiTietLuongNgay.MaNV=NhanVien.MaNV) 
	JOIN (SELECT NhanVien.MaNV, KyLuong, SUM(ThanhTien) AS TongTienLuong
		FROM ChiTietLuongNgay JOIN NhanVien ON ChiTietLuongNgay.MaNV=NhanVien.MaNV
		GROUP BY NhanVien.MaNV, ChiTietLuongNgay.KyLuong) AS q 
		ON NhanVien.MaNV = q.MaNV
GO
--VIEW LƯU TRỮ KHO
create view VW_LuuTruKho AS
SELECT LuuTru.MaKho, TenNVL, HSD, SoLuongConLai, NguyenVatLieu.DonVi ,NgayThang
FROM LuuTru inner join Kho on LuuTru.MaKho = Kho.MaKho 	inner join NguyenVatLieu on LuuTru.MaNVL = NguyenVatLieu.MaNVL
GO
--VIEW MENU
CREATE VIEW VW_Menu
AS
SELECT MaMH, TenLoaiHang, TenHang, GiaTien
FROM MatHang inner join LoaiMatHang on MatHang.MaLoaiMH = LoaiMatHang.MaLoaiMH
GO
--VIEW PHÂN CÔNG
create view VW_PhanCong as
select PhanCong.MaNV, HoTen, TenLoaiCa, NgayLam, DiemDanh
from PhanCong, NhanVien, (select MaCa, TenLoaiCa, NgayLam from CaLam, LoaiCa where CaLam.MaLoaiCa = LoaiCa.MaLoaiCa)Q
where PhanCong.MaNV = NhanVien.MaNV and  PhanCong.MaCa = Q.MaCa
GO
--VIEW THÔNG TIN CHỨC VỤ
CREATE VIEW VW_ThongTinChucVu AS
SELECT p.MaChucVu, ChucVu.TenChucVu, ChucVu.LuongMotGioLam, SoLuongNhanVien
FROM	(SELECT ChucVu.MaChucVu, COUNT(MaNV) AS SoLuongNhanVien
		FROM ChucVu LEFT JOIN NhanVien ON ChucVu.MaChucVu=NhanVien.MaChucVu	
		WHERE TinhTrang LIKE N'Đang làm' OR NhanVien.MaNV IS NULL
		GROUP BY ChucVu.MaChucVu) AS p join ChucVu ON p.MaChucVu=ChucVu.MaChucVu
GO
--VIEW THÔNG TIN ĐĂNG NHẬP
create view VW_ThongTinDangNhap AS
SELECT DangNhap.MaNV, TenNguoiDung, MatKhau, TenRole
FROM DangNhap left join PhanNhom on DangNhap.MaNV = PhanNhom.MaNV left join NhomNguoiDung on 
	PhanNhom.MaNhomNguoiDung = NhomNguoiDung.MaNhomNguoiDung
GO
--VIEW THÔNG TIN HÓA ĐƠN
CREATE VIEW VW_ThongTinHoaDon AS
Select 
	MaHoaDon,
	MaNV,
	MaKH,
	MaBan,
	NgayGioInHoaDon,
	TongGiaTien,
	DiemTichLuyThem,
	DiemSuDung
From HoaDon
GO
--VIEW THÔNG TIN KHÁCH HÀNG
CREATE VIEW VW_ThongTinKhachHang AS
SELECT KhachHang.MaKH, LoaiKhachHang.TenLoaiKH, KhachHang.TenKH, DiaChi, SDT, DiemTichLuyHienTai, TongDiemTichLuy
FROM KhachHang, LoaiKhachHang
WHERE KhachHang.MaLoaiKH = LoaiKhachHang.MaLoaiKH
GO
--VIEW THÔNG TIN NHÂN VIÊN
CREATE VIEW VW_ThongTinNV AS
SELECT MaNV, ChucVu.TenChucVu, HoTen, NgaySinh, GioiTinh, NgayBatDauLam, SDT, TinhTrang
FROM NhanVien, ChucVu
WHERE NhanVien.MaChucVu = ChucVu.MaChucVu
GO


--=======================================================================================================================================
--TẠO PROC VÀ FUNCTION

--================ FUNCTION ======================================================
--HÀM LẤY CTHĐ CỦA BÀN ĐANG PHỤC VỤ
CREATE function [dbo].[Table_FN_LayChiTietHoaDonCuaBanDangPhucVu](@MaBan char(10))
RETURNS TABLE
RETURN(
	   SELECT VW_ChiTietHoaDon.MaHoaDon, HoaDon.MaBan, TenHang, SoLuongMH, ThanhTien 
	   FROM VW_ChiTietHoaDon join HoaDon on VW_ChiTietHoaDon.MaHoaDon = HoaDon.MaHoaDon
	   WHERE HoaDon.MaBan = @MaBan and NgayGioInHoaDon IS NULL
	)
GO
--HÀM LẤY CTHĐ CỦA KHÁCH MUA MANG ĐI ĐANG PHỤC VỤ
CREATE function [dbo].[Table_FN_LayCTHDCuaKhachMangDiDangPhucVu]()
RETURNS TABLE
RETURN(
	   SELECT VW_ChiTietHoaDon.MaHoaDon, HoaDon.MaBan, TenHang, SoLuongMH, ThanhTien 
	   FROM VW_ChiTietHoaDon join HoaDon on VW_ChiTietHoaDon.MaHoaDon = HoaDon.MaHoaDon
	   WHERE MaBan IS NULL and NgayGioInHoaDon IS NULL
	)
GO
--HÀM LẤY THÔNG TIN NHÂN VIÊN ĐĂNG NHẬP
CREATE function [dbo].[Table_FN_LayThongTinNhanVienDangNhap](@userName nvarchar(30))
RETURNS TABLE
AS
RETURN(
		SELECT vw.MaNV, TenChucVu, HoTen, NgaySinh, GioiTinh, NgayBatDauLam, SDT, TinhTrang 
		FROM VW_ThongTinNV vw inner join DangNhap on vw.MaNV = DangNhap.MaNV	
		WHERE DangNhap.TenNguoiDung = @userName
		)
GO
--HÀM LỌC CA LÀM
CREATE FUNCTION [dbo].[Table_FN_LocCaLam](@MaLoaiCa char(10), @NgayLam date)
RETURNS TABLE
RETURN(
	select *
	from VW_CaLam
	where MaLoaiCa = ISNULL(@MaLoaiCa, MaLoaiCa) and NgayLam = ISNULL(@NgayLam, NgayLam)
	)
GO
--HÀM LỌC CHI TIẾT LƯƠNG
CREATE FUNCTION [dbo].[Table_FN_LocChiTietLuong] (@MaNV varchar(10), @MaCa varchar(11), @TenChucVu nvarchar(20))
RETURNS TABLE
RETURN(
	SELECT * FROM VW_ChiTietLuong
	WHERE MaNV=ISNULL(@MaNV, MaNV) AND MaCa=ISNULL(@MaCa, MaCa) AND TenChucVu=ISNULL(@TenChucVu, TenChucVu)
	)
GO
--HÀM LỌC CHI TIẾT MUA
CREATE FUNCTION [dbo].[Table_FN_LocChiTietMua](@MaPhieuMua varchar(16), @TenNVL nvarchar(30), @NgayGioMua DATETIME)
RETURNS TABLE
RETURN(
	select *
	from VW_ChiTietMua
	where MaPhieuMua = ISNULL(@MaPhieuMua, MaPhieuMua)and TenNVL LIKE '%' + ISNULL(@TenNVL, TenNVL) +'%' and 
			CAST(NgayGioMua as date) = ISNULL(CAST(@NgayGioMua as date), CAST(NgayGioMua as date)) 
	)
GO
--HÀM LỌC CHỨC VỤ
CREATE FUNCTION [dbo].[Table_FN_LocChucVu] (@TenChucVu nvarchar(20))
RETURNS TABLE
RETURN(
	SELECT * FROM VW_ThongTinChucVu
	WHERE TenChucVu LIKE '%' + @TenChucVu + '%'
	)
GO
--HÀM LỌC HÓA ĐƠN
CREATE function [dbo].[Table_FN_LocHoaDon](@MaNV varchar(10), @MaKH varchar(11), @NgayHoaDon date)
RETURNS TABLE AS
RETURN
(	
	SELECT *
	FROM VW_ThongTinHoaDon
	WHERE (MaNV = ISNULL(@MaNV, MaNV) OR MaNV IS NULL) 
		and (MaKH = ISNULL(@MaKH, MaKH) OR MaKH IS NULL)  
		and	CAST(NgayGioInHoaDon AS date) = ISNULL(CAST(@NgayHoaDon AS date), NgayGioInHoaDon)
)
GO
--HÀM LỌC KHO LƯU TRỮ
CREATE function [dbo].[Table_FN_LocKhoLuuTru](@NgayThang date, @TenNVL nvarchar(30))
RETURNS TABLE
RETURN(
		SELECT * FROM VW_LuuTruKho
		WHERE NgayThang = ISNULL(@NgayThang, NgayThang) and
			TenNVL LIKE '%' + ISNULL(@TenNVL, TenNVL) + '%'
	)
GO
--HÀM LỌC NHÂN VIÊN
CREATE FUNCTION [dbo].[Table_FN_LocNhanVien] (@MaNV varchar(10), @HoTen nvarchar(40), @ChucVu nvarchar(20))
RETURNS TABLE
RETURN(
	SELECT * FROM VW_ThongTinNV
	WHERE MaNV= ISNULL(@MaNV, MaNV) AND HoTen LIKE '%' + ISNULL(@HoTen, HoTen) + '%' AND TenChucVu=ISNULL(@ChucVu, TenChucVu)
		AND TinhTrang LIKE N'Đang làm'
	)
GO
--HÀM TÌM KIẾM THÔNG TIN NHẬP KHO
CREATE function [dbo].[Table_FN_LocNhapKho](@NgayThang date, @TenNVL nvarchar(30))
RETURNS TABLE
RETURN(
		SELECT * FROM VW_ThongTinNhapKho
		WHERE NgayThang = ISNULL(@NgayThang, NgayThang) and
			TenNVL LIKE '%' + ISNULL(@TenNVL, TenNVL) + '%'
	)
GO
--HÀM TÌM KIẾM THÔNG TIN PHÂN CÔNG
CREATE function [dbo].[Table_FN_LocPhanCong](@MaNV varchar(10), @TenLoaiCa nvarchar(30), @NgayLam date)
returns table
as
return
	select *
	from VW_PhanCong
	where 
		MaNV = ISNULL(@MaNV, MaNV) and TenLoaiCa = ISNULL(@TenLoaiCa, TenLoaiCa) and 
			NgayLam = ISNULL(@NgayLam, NgayLam);
GO
--HÀM LỌC PHIẾU MUA
CREATE FUNCTION [dbo].[Table_FN_LocPhieuMua](@MaPhieuMua varchar(16), @TenNVL varchar(10), @NgayGioMua DATETIME)
RETURNS TABLE
RETURN(
	select *
	from VW_ChiTietMua
	where MaPhieuMua = ISNULL(@MaPhieuMua, MaPhieuMua) and TenNVL = ISNULL(@TenNVL, TenNVL) and 
			CAST(NgayGioMua as date) = ISNULL(CAST(@NgayGioMua as date), CAST(NgayGioMua as date))
	)
GO
--HÀM LỌC SẢN PHẨM BÁN CHẠY
CREATE FUNCTION [dbo].[Table_FN_LocSanPhamBanChay](@thang int, @nam int)
RETURNS TABLE AS
RETURN 
(
	SELECT TOP(10)
		TenHang,
		TenLoaiHang,
		SoLuong,
		Thang,
		Nam
	FROM VW_DanhMucSanPhamBanChay
	WHERE Thang = @thang and Nam = @nam
)
GO
--HÀM LỌC THÔNG TIN KHÁCH HÀNG
CREATE FUNCTION [dbo].[Table_FN_LocThongTinKhachHang](@makh char(11), @tenkh nvarchar(40), @tenloaikh nvarchar(30) )
RETURNS TABLE AS
RETURN
(
	SELECT 
			MaKH,
			TenLoaiKH,
			TenKH,
			DiaChi,
			SDT,
			DiemTichLuyHienTai,
			TongDiemTichLuy
	FROM VW_ThongTinKhachHang
	WHERE MaKH = ISNULL(@makh, MaKH) and TenKH LIKE '%' + ISNULL(@tenkh, TenKH) + '%' and
			TenLoaiKH = ISNULL(@tenloaikh, TenLoaiKH)
)
GO
--HÀM LỌC THÔNG TIN XUẤT KHO
CREATE function [dbo].[Table_FN_LocXuatKho](@NgayXuat date, @TenNVL nvarchar(30))
RETURNS TABLE
RETURN(
		SELECT * FROM VW_ThongTinXuatKho
		WHERE CAST(NgayGioXuat AS DATE) = CAST(ISNULL(@NgayXuat, NgayGioXuat) AS DATE) and
			TenNVL LIKE '%' + ISNULL(@TenNVL, TenNVL) + '%'
	)
GO
--HÀM TÌM KIẾM CHI TIẾT HÓA ĐƠN
CREATE FUNCTION [dbo].[Table_FN_TimKiemChiTietHoaDon](@MaHoaDon varchar(13))
RETURNS TABLE
RETURN(
	select *
	from VW_ChiTietHoaDon
	where MaHoaDon = @MaHoaDon
	)
GO
--HÀM TÌM KIẾM LƯƠNG NHÂN VIÊN
CREATE FUNCTION [dbo].[Table_FN_TimKiemLuongNV] (@MaNV varchar(10))
RETURNS TABLE
RETURN(
	SELECT * FROM VW_LuongNhanVien
	WHERE MaNV=@MaNV 
	)
GO
--HÀM LẤY MÃ HÓA ĐƠN CỦA BÀN ĐANG PHỤC VỤ
CREATE function [dbo].[Scalar_FN_LayMaHoaDonCuaBanDangPhucVu](@MaBan char(10))
RETURNS VARCHAR(13)
AS
BEGIN
   DECLARE @MaHoaDon varchar(13)
   SELECT @MaHoaDon = MaHoaDon FROM HoaDon WHERE MaBan = @MaBan AND NgayGioInHoaDon IS NULL
   RETURN @MaHoaDon
END
GO
--HÀM LẤY MÃ HÓA ĐƠN CỦA KHÁCH MUA MANG ĐI ĐANG PHỤC VỤ
CREATE function [dbo].[Scalar_FN_LayMaHoaDonCuaKhachMangDiDangPhucVu]()
RETURNS VARCHAR(13)
AS
BEGIN
   DECLARE @MaHoaDon varchar(13)
   SELECT @MaHoaDon = MaHoaDon FROM HoaDon WHERE MaBan IS NULL AND NgayGioInHoaDon IS NULL
   RETURN @MaHoaDon
END
GO
--HÀM LẤY MÃ KHO TỪ NGÀY THÁNG
CREATE FUNCTION [dbo].[Scalar_FN_LayMaKhoTuNgayThang](@NgayThang Date)
RETURNS VARCHAR(11)
AS
BEGIN
   DECLARE @MaKho varchar(11) 
   SELECT @MaKho = MaKho FROM Kho WHERE NgayThang = @NgayThang
   RETURN @MaKho
END
GO
--HÀM LẤY MÃ NHÂN VIÊN ĐĂNG NHẬP
CREATE function [dbo].[Scalar_FN_LayMaNVDangNhap](@userName nvarchar(30))
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @maNV varchar(10)
	SELECT @maNV = MaNV FROM DangNhap WHERE TenNguoiDung = @userName
	RETURN @maNV
END
GO
--HÀM LẤY TỔNG SỐ TIỀN CTHĐ
CREATE function [dbo].[Scalar_FN_LayTongSoTienCTHD] (@MaHoaDon varchar(13))
RETURNS float
BEGIN
	DECLARE @tongTien float
	SELECT @tongTien = SUM(ThanhTien) FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon
	RETURN @tongTien
END
GO
--HÀM TÍNH TỔNG SỐ TIỀN CTPM
CREATE function [dbo].[Scalar_FN_LayTongSoTienCTPM] (@MaPhieuMua varchar(16))
RETURNS float
BEGIN
	DECLARE @tongtien float
	SELECT @tongtien = SUM(ThanhTien) FROM ChiTietMua WHERE MaPhieuMua = @MaPhieuMua
	RETURN @tongtien
END
GO
--HÀM TÍNH TỔNG ĐIỂM TÍCH LŨY SỬ DỤNG THEO THÁNG NĂM
CREATE FUNCTION [dbo].[Scalar_FN_TinhTongDTLSuDung] (@year int, @month int)
RETURNS FLOAT
AS
BEGIN
	DECLARE @ngayDauThang date, @ngayCuoiThang date, @TongDiemSuDung float
	SET @ngayDauThang = DATEFROMPARTS(@year, @month, 1)
	SET @ngayCuoiThang = EOMONTH(@ngayDauThang)
	SELECT @TongDiemSuDung = SUM(DiemSuDung) FROM HoaDon WHERE NgayGioInHoaDon BETWEEN @ngayDauThang and @ngayCuoiThang
	IF @TongDiemSuDung IS NULL
		RETURN 0
	RETURN @TongDiemSuDung
END
GO
--HÀM TÍNH TỔNG TIỀN HÓA ĐƠN THEO THÁNG NĂM
CREATE FUNCTION [dbo].[Scalar_FN_TinhTongTienHoaDonTheoNgayThang] (@year int, @month int)
RETURNS FLOAT
AS
BEGIN
	DECLARE @ngayDauThang date, @ngayCuoiThang date, @TongTien float
	SET @ngayDauThang = DATEFROMPARTS(@year, @month, 1)
	SET @ngayCuoiThang = EOMONTH(@ngayDauThang)
	SELECT @TongTien = SUM(TongGiaTien) FROM HoaDon WHERE NgayGioInHoaDon BETWEEN @ngayDauThang and @ngayCuoiThang
	IF @TongTien IS NULL
		RETURN 0
	RETURN @TongTien
END
GO
--TÍNH TỔNG TIỀN LƯƠNG THEO THÁNG NĂM
CREATE FUNCTION [dbo].[Scalar_FN_TinhTongTienLuongTheoThangNam] (@year int, @month int)
RETURNS FLOAT
AS
BEGIN
	DECLARE @TongTien float
	SELECT @TongTien = SUM(ThanhTien) FROM ChiTietLuongNgay WHERE YEAR(KyLuong) = @year and MONTH(KyLuong) = @month
	IF @TongTien IS NULL
		RETURN 0
	RETURN @TongTien
END
GO
--TÍNH TỔNG TIỀN PHIẾU MUA THEO THÁNG NĂM
CREATE FUNCTION [dbo].[Scalar_FN_TinhTongTienPhieuMuaTheoThangNam] (@year int, @month int)
RETURNS FLOAT
AS
BEGIN
	DECLARE @ngayDauThang date, @ngayCuoiThang date, @TongTien float
	SET @ngayDauThang = DATEFROMPARTS(@year, @month, 1)
	SET @ngayCuoiThang = EOMONTH(@ngayDauThang)
	SELECT @TongTien = SUM(ThanhTien) FROM VW_ChiTietMua WHERE NgayGioMua BETWEEN @ngayDauThang and @ngayCuoiThang
	IF @TongTien is NULL
	BEGIN
		RETURN 0
	END
	RETURN @TongTien
END
GO
--HÀM TÍNH TỔNG TIỀN DOANH THU
CREATE FUNCTION [dbo].[Scalar_FN_TinhTongTienDoanhThu] (@year int, @month int)
RETURNS FLOAT
AS
BEGIN
	DECLARE @TongTien float, @TongTienHoaDon float, @TongDiemSuDung float, @TongTienPhieuMua float, @TongTienLuong float;
	
	SET @TongTienHoaDon = 0;
    SET @TongDiemSuDung = 0;
    SET @TongTienPhieuMua = 0;
    SET @TongTienLuong = 0;
    SET @TongTien = 0;

	SELECT @TongTienHoaDon = dbo.Scalar_FN_TinhTongTienHoaDonTheoNgayThang(@year, @month)
	SELECT @TongDiemSuDung = dbo.Scalar_FN_TinhTongDTLSuDung(@year, @month)
	SELECT @TongTienPhieuMua = dbo.Scalar_FN_TinhTongTienPhieuMuaTheoThangNam(@year, @month)
	SELECT @TongTienLuong = dbo.Scalar_FN_TinhTongTienLuongTheoThangNam(@year, @month)
	SET @TongTien = @TongTienHoaDon - @TongDiemSuDung * 1000 - @TongTienPhieuMua - @TongTienLuong
	RETURN @TongTien
END
GO
--HÀM TÍNH TỔNG TIỀN HÓA ĐƠN THEO CÁC THUỘC TÍNH
CREATE function [dbo].[Scalar_FN_TinhTongTienHoaDon] (@MaNV varchar(10), @MaKH varchar(11), @NgayHoaDon date)
RETURNS float
AS
BEGIN
	DECLARE @tongTien float
	SET @tongTien = 0
	SELECT @tongTien = SUM(TongGiaTien) FROM dbo.Table_FN_LocHoaDon(@MaNV, @MaKH, @NgayHoaDon)
	RETURN @tongTien
END
GO
--TÍNH TỔNG TIỀN PHIẾU MUA THEO CÁC THUỘC TÍNH
CREATE function [dbo].[Scalar_FN_TinhTongTienPhieuMua] (@MaPhieuMua varchar(16), @TenNVL varchar(10), @NgayGioMua DATETIME)
RETURNS float
AS
BEGIN
	DECLARE @tongTien float
	SET @tongTien = 0
	SELECT @tongTien = SUM(ThanhTien) FROM dbo.Table_FN_LocChiTietMua(@MaPhieuMua, @TenNVL, @NgayGioMua)
	RETURN @tongTien
END
GO

--====================== PROCEDURE ====================================
--===CẬP NHẬT VÀ SỬA ĐỔI

--CẬP NHẬT CHI TIẾT HÓA ĐƠN
CREATE PROCEDURE [dbo].[USP_CapNhatChiTietHoaDon] ( @mahoadonSua VARCHAR(13), @mamhSua CHAR(10), @soluongmhThemVao INT)
AS 
BEGIN
	declare @GiaTien float, @thanhtien float, @soluongmh int
	SELECT @soluongmh = SoLuongMH FROM ChiTietHoaDon WHERE MaHoaDon = @mahoadonSua and MaMH = @mamhSua
	SET @soluongmh += @soluongmhThemVao
	select @GiaTien = GiaTien from MatHang where MaMH = @mamhSua
	set @thanhtien = @GiaTien * @soluongmh
	SET XACT_ABORT ON
	BEGIN TRAN
		BEGIN TRY
			UPDATE dbo.ChiTietHoaDon
			SET SoLuongMH = @soluongmh, ThanhTien = @thanhtien
			Where MaHoaDon = @mahoadonSua and MaMH = @mamhSua
		COMMIT TRAN
		END TRY
		BEGIN CATCH
			ROLLBACK;
			throw
		END CATCH 
END
GO
--CẬP NHẬT HÓA ĐƠN
CREATE PROCEDURE [dbo].[USP_CapNhatHoaDon] ( @mahoadon varchar (13), @maban char(10), 
										@ngaygioinhoadon DATETIME, @DiemSuDung float)
AS 
BEGIN
	DECLARE @tongGiaTien float
	SELECT @tongGiaTien = dbo.Scalar_FN_LayTongSoTienCTHD(@mahoadon)
	SET XACT_ABORT ON
	BEGIN TRAN
		BEGIN TRY
			UPDATE dbo.HoaDon
			SET MaBan = @maban, NgayGioInHoaDon = @ngaygioinhoadon, DiemSuDung = @DiemSuDung, TongGiaTien = @tongGiaTien
			Where MaHoaDon = @mahoadon
		COMMIT TRAN
		END TRY
		BEGIN CATCH
			ROLLBACK;
			throw
		END CATCH 
END
GO
--ĐIỂM DANH PHÂN CÔNG
CREATE procedure [dbo].[USP_DiemDanhPhanCong] @MaNV varchar(10), @MaLoaiCa char(10), @NgayLam date, @DiemDanh int
as
begin
	declare @MaCa varchar(11)
	set @MaCa = 'CL' + RIGHT(RTRIM(@MaLoaiCa), 1) + convert(varchar(8),cast(@NgayLam as date),112)
	set xact_abort on
	begin try
		begin tran
			update PhanCong
			set DiemDanh = @DiemDanh
			where MaNV = @MaNV and @MaCa = MaCa
		commit tran
	end try
	begin catch
		rollback;
		throw
	end catch
end
GO
--ĐỔI MẬT KHẨU
CREATE PROCEDURE [dbo].[USP_DoiMatKhau] @TenNguoiDung nvarchar(30), @MatKhau nvarchar(16)
AS
BEGIN 
	SET XACT_ABORT ON
	DECLARE @sqlString nvarchar(max)
	SET @sqlString = 'CREATE LOGIN [' + @TenNguoiDung + '] WITH PASSWORD=''' + @MatKhau +''''
	BEGIN TRY
		BEGIN TRAN
			UPDATE DangNhap 
			SET MatKhau = @MatKhau
			WHERE TenNguoiDung = @TenNguoiDung
			EXEC(@sqlString)
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK;
		THROW
	END CATCH
END
GO

--GÁN QUYỀN TÀI KHOẢN
CREATE PROCEDURE USP_GanQuyenTaiKhoan @TenNguoiDung nvarchar(30), @MaNhomNguoiDung varchar(10)
AS
BEGIN
	DECLARE @sqlString nvarchar(max), @TenRole varchar(30)
	SELECT @TenRole = TenRole FROM NhomNguoiDung WHERE MaNhomNguoiDung = @MaNhomNguoiDung
	SET XACT_ABORT ON
	BEGIN TRY
		BEGIN TRAN
			IF @TenRole LIKE 'sysadmin'
			BEGIN
				SET @sqlString = 'ALTER SERVER ROLE sysadmin' +' ADD MEMBER ' + @TenNguoiDung;
			END
			ELSE
			BEGIN
				SET @sqlString = 'ALTER ROLE '+ @TenRole +' ADD MEMBER ' + @TenNguoiDung;
			END
			EXEC(@sqlString)
		COMMIT TRAN
	END TRY
	BEGIN CATCH
	ROLLBACK;
	THROW;
	END CATCH
END
GO

--SỬA CHI TIẾT LƯƠNG
CREATE PROCEDURE [dbo].[usp_SuaChiTietLuong] @MaNV varchar(10), @MaCa varchar(11), @MaChucVu Char(10), 
										@NgayLuong date, @ThanhTien float, @KyLuong date
	AS
	BEGIN
		SET XACT_ABORT ON
		BEGIN TRY
			BEGIN TRANSACTION
			--
				UPDATE ChiTietLuongNgay
				SET MaCa=@MaCa, MaChucVu=@MaChucVu, NgayLuong=@NgayLuong, ThanhTien=@ThanhTien, KyLuong=@KyLuong
				WHERE MaNV = @MaNV and MaCa = @MaCa
			--
			COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK;
		throw
	END CATCH
END
GO
--SỬA CHI TIẾT MUA
CREATE PROCEDURE [dbo].[USP_SuaChiTietMua] (@MaPhieuMua VARCHAR(16), @MaNVL CHAR(10), @SoLuongNVL INT)
AS 
BEGIN
	Declare @ThanhTien float, @GiaMotDonVi float
	select @GiaMotDonVi = GiaMotDonVi from NguyenVatLieu where MaNVL = @MaNVL
	set @ThanhTien = @GiaMotDonVi * @SoLuongNVL
	SET XACT_ABORT ON
	BEGIN TRAN
		BEGIN TRY
			UPDATE dbo.ChiTietMua
			SET SoLuongNVL = @SoLuongNVL, ThanhTien = @ThanhTien
			Where MaPhieuMua = @MaPhieuMua and MaNVL = @MaNVL
		COMMIT TRAN
		END TRY
		BEGIN CATCH
			ROLLBACK
		END CATCH 
END
GO
--SỬA CHỨC VỤ
CREATE PROCEDURE [dbo].[usp_SuaChucVu] @MaChucVu char(10), @TenChucVu nvarchar(20), @LuongMotGioLam float
	AS
	BEGIN
		SET XACT_ABORT ON
		BEGIN TRY
			BEGIN TRANSACTION
			--
				UPDATE  ChucVu
				SET TenChucVu=@TenChucVu, LuongMotGioLam=@LuongMotGioLam
				WHERE MaChucVu=@MaChucVu
			--
			COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK;
		throw
	END CATCH
END
GO
--SỬA KHÁCH HÀNG
CREATE PROCEDURE [dbo].[USP_SuaKhachHang] ( @makh char(11), @tenkh nvarchar(40), @maloaikh char(10), @diachi nvarchar(200), @sdt char(10), 
					@currentpoint float, @totalpoint float )
AS 
BEGIN
	SET XACT_ABORT ON
	BEGIN TRAN
		BEGIN TRY
			UPDATE KhachHang
			SET TenKH = @tenkh, MaLoaiKH = @maloaikh, DiaChi = @diachi, SDT = @sdt, DiemTichLuyHienTai = @currentpoint,
				TongDiemTichLuy = @totalpoint
			WHERE MaKH = @makh;
		COMMIT TRAN
		END TRY
		BEGIN CATCH
			ROLLBACK;
			throw
		END CATCH 
END
GO
--SỬA MẶT HÀNG
CREATE PROCEDURE [dbo].[USP_SuaMatHang] @MaMH char(10), @MaLoaiMH char(10), @TenHang nvarchar(30), @GiaTien float
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			UPDATE MatHang
			SET MaLoaiMH = @MaLoaiMH, TenHang = @TenHang, GiaTien = @GiaTien
			WHERE MaMH = @MaMH
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK;
		THROW
	END CATCH
END
GO
--SỬA NHÂN VIÊN
CREATE PROCEDURE [dbo].[usp_SuaNhanVien] @MaNV varchar(10),@MaChucVu Char(10), @HoTen nvarchar(40), @NgaySinh date, @GioiTinh char(10), 
									@NgayBatDauLam date, @SDT char(10), @TinhTrang nvarchar(10)
	AS
	BEGIN
		SET XACT_ABORT ON
		BEGIN TRY
			BEGIN TRANSACTION
			--
				UPDATE NhanVien
				SET MaChucVu=@MaChucVu, HoTen=@HoTen, NgaySinh=@NgaySinh, GioiTinh=@GioiTinh, NgayBatDauLam=@NgayBatDauLam,
					SDT=@SDT, TinhTrang=@TinhTrang
				WHERE MaNV = @MaNV 
			--
			COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK
	END CATCH
END
GO
--SỬA TRẠNG THÁI BÀN
CREATE PROCEDURE [dbo].[USP_SuaTrangThaiBan] ( @MaBan char(10), @TrangThai nvarchar(30))
AS 
BEGIN
	SET XACT_ABORT ON
	BEGIN TRAN
		BEGIN TRY
			UPDATE dbo.Ban
			SET TrangThai = @TrangThai
			Where MaBan = @MaBan
		COMMIT TRAN
		END TRY
		BEGIN CATCH
			ROLLBACK;
			throw
		END CATCH 
END
GO
--====THAO TÁC THÊM, NHẬP XUẤT 

--THAO TÁC NHẬP KHO
CREATE procedure [dbo].[USP_ThaoTacNhapKho] @MaNVL char(10), @SoLuongNhap int, @GioNhap time(0), @NgayThang date, @HSD date
AS
BEGIN
	DECLARE @MaKho varchar(11)
	SET XACT_ABORT ON
	BEGIN TRY
		--Nếu chưa tồn tại => thêm kho mới
		IF NOT EXISTS (SELECT 1 FROM Kho WHERE NgayThang = @NgayThang)
		BEGIN
			BEGIN TRY
				BEGIN TRAN
					INSERT INTO	Kho(NgayThang) VALUES (@NgayThang)
				COMMIT TRAN
			END TRY
			BEGIN CATCH
				ROLLBACK;
				THROW
			END	CATCH
		END
		--
		BEGIN TRAN
			SELECT @MaKho =  dbo.Scalar_FN_LayMaKhoTuNgayThang(@NgayThang)
			INSERT INTO NhapKho VALUES (@MaNVL, @MaKho, @SoLuongNhap, @GioNhap)
			-- Nếu đã có nguyên vật liệu đó ở trong mã kho ngày hôm nay
			-- thì thêm số lượng vào số lượng còn lại trong kho
			IF EXISTS (SELECT 1 FROM LuuTru WHERE MaKho = @MaKho and MaNVL = @MaNVL)
			BEGIN
				UPDATE LuuTru
				SET SoLuongConLai += @SoLuongNhap
				WHERE MaKho = @MaKho and MaNVL = @MaNVL
			END
			-- Ngược lại thêm vào lưu trữ
			ELSE
			BEGIN
				INSERT INTO LuuTru VALUES (@MaNVL, @MaKho, @HSD, @SoLuongNhap)
			END
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK;
		THROW
	END CATCH
END
GO
--THAO TÁC XUẤT KHO
CREATE PROCEDURE [dbo].[USP_ThaoTacXuatKho] @MaNVL char(10), @MaKho varchar(11), @SoLuongXuat int, @NgayGioXuat datetime
AS
BEGIN
	SET XACT_ABORT ON
	BEGIN TRY
		BEGIN TRAN
			--
			INSERT INTO XuatKho VALUES(@MaNVL, @MaKho, @SoLuongXuat, @NgayGioXuat)
			--
			UPDATE LuuTru
			SET SoLuongConLai -= @SoLuongXuat
			WHERE MaKho = @MaKho AND MaNVL = @MaNVL
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK;
		THROW
	END CATCH
END
GO
--THÊM CA LÀM
CREATE procedure [dbo].[USP_ThemCaLam] @MaLoaiCa char(10), @NgayLam	 date
as
begin
	set xact_abort on
	begin try
		begin tran
			insert into CaLam values(@MaLoaiCa, @NgayLam)
		commit tran
	end try
	begin catch
		rollback;
		throw
	end catch
end
GO
--THÊM CHI TIẾT HÓA ĐƠN
CREATE PROCEDURE [dbo].[USP_ThemChiTietHoaDon] ( @mahoadon VARCHAR(13), @mamh CHAR(10), @soluongmh INT)
AS 
BEGIN
	declare @GiaTien float, @thanhtien float
	select @GiaTien = GiaTien from MatHang where MaMH = @mamh
	set @thanhtien = @GiaTien * @soluongmh
	SET XACT_ABORT ON
	BEGIN TRAN
		BEGIN TRY
			IF EXISTS (SELECT 1 FROM ChiTietHoaDon WHERE MaHoaDon = @mahoadon AND MaMH = @mamh)
			BEGIN
				EXEC USP_CapNhatChiTietHoaDon @mahoadonSua = @mahoadon, @mamhSua = @mamh, @soluongmhThemVao = @soluongmh
			END
			ELSE
			BEGIN
				INSERT INTO ChiTietHoaDon(MaHoaDon, MaMH, SoLuongMH, ThanhTien) VALUES
				(@mahoadon, @mamh, @soluongmh, @thanhtien)
			END
		COMMIT TRAN
		END TRY
		BEGIN CATCH
			ROLLBACK;
			throw
		END CATCH 
END
GO
--THÊM CHI TIẾT LƯƠNG
CREATE PROCEDURE [dbo].[usp_ThemChiTietLuong] @MaNV varchar(10), @MaCa varchar(11),
										@NgayLuong date, @ThanhTien float, @KyLuong date
	AS
	BEGIN
		DECLARE @MaChucVu char(10)
		select @MaChucVu = MaChucVu from NhanVien where NhanVien.MaNV = @MaNV
		SET XACT_ABORT ON
		BEGIN TRY
			BEGIN TRANSACTION
			--
				INSERT INTO ChiTietLuongNgay
				VALUES  (
					@MaNV, @MaCa, @MaChucVu, @NgayLuong, @ThanhTien, @KyLuong 
				)	
			--
			COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK;
		throw
	END CATCH
END
GO
--THÊM CHI TIẾT MUA
CREATE PROCEDURE [dbo].[USP_ThemChitietMua] ( @MaPhieuMua VARCHAR(16), @MaNVL CHAR(10), @SoLuongNVL INT)
AS 
BEGIN
    Declare @ThanhTien float, @GiaMotDonVi float
	select @GiaMotDonVi = GiaMotDonVi from NguyenVatLieu where MaNVL = @MaNVL
	set @ThanhTien = @GiaMotDonVi * @SoLuongNVL
	SET XACT_ABORT ON
	BEGIN TRAN
		BEGIN TRY
			INSERT INTO ChiTietMua(MaPhieuMua, MaNVL, SoLuongNVL, ThanhTien) VALUES
			(@MaPhieuMua, @MaNVL, @SoLuongNVL, @ThanhTien);
		COMMIT TRAN
		END TRY
		BEGIN CATCH
			ROLLBACK;
			throw
		END CATCH 
END
GO
--THÊM CHỨC VỤ
CREATE PROCEDURE [dbo].[usp_ThemChucVu] @MaChucVu char(10), @TenChucVu nvarchar(20), @LuongMotGioLam float
	AS
	BEGIN
		SET XACT_ABORT ON
		BEGIN TRY
			BEGIN TRANSACTION
			--
				INSERT INTO ChucVu
				VALUES  (
					@MaChucVu, @TenChucVu, @LuongMotGioLam
				)
			--
			COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK;
		throw
	END CATCH
END
GO
--THÊM HÓA ĐƠN
CREATE PROCEDURE [dbo].[USP_ThemHoaDon] ( @manv varchar(10), @makh varchar(11), @maban char(10))
AS 
BEGIN
	SET XACT_ABORT ON
	BEGIN TRAN
		BEGIN TRY
			INSERT INTO HoaDon(MaNV, MaKH, MaBan, TongGiaTien) VALUES
			(@manv, @makh, @maban, 0);
			EXEC USP_SuaTrangThaiBan @MaBan = @maBan, @TrangThai = N'Có người'
		COMMIT TRAN
		END TRY
		BEGIN CATCH
			ROLLBACK;
			throw
		END CATCH 
END
GO
--THÊM KHÁCH HÀNG
CREATE PROCEDURE [dbo].[USP_ThemKhachHang] ( @maloaikh char(10), @tenkh nvarchar(40), @diachi nvarchar(200), @sdt char(10),
											 @currentpoint float, @totalpoint float )
AS 
BEGIN
	SET XACT_ABORT ON
	BEGIN TRAN
		BEGIN TRY
			INSERT INTO KhachHang(MaLoaiKH, TenKH, DiaChi, SDT, DiemTichLuyHienTai, TongDiemTichLuy) VALUES
			(@maloaikh, @tenkh, @diachi, @sdt, @currentpoint, @totalpoint);
		COMMIT TRAN
		END TRY
		BEGIN CATCH
			ROLLBACK;
			throw
		END CATCH 
END
GO
--THÊM MẶT HÀNG
CREATE PROCEDURE [dbo].[USP_ThemMatHang] @MaMH char(10), @MaLoaiMH char(10), @TenHang nvarchar(30), @GiaTien float
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			INSERT INTO MatHang VALUES(@MaMH, @MaLoaiMH, @TenHang, @GiaTien)
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK;
		THROW
	END CATCH
END
GO
--THÊM NHÂN VIÊN
CREATE PROCEDURE [dbo].[usp_ThemNhanVien] @MaChucVu Char(10), @HoTen nvarchar(40), @NgaySinh date, @GioiTinh char(10), 
									@NgayBatDauLam date, @SDT char(10), @TinhTrang nvarchar(10)
	AS
	BEGIN
		SET XACT_ABORT ON
		BEGIN TRY
			BEGIN TRANSACTION
			--
				INSERT INTO NhanVien
				VALUES  (
					@MaChucVu, @HoTen, @NgaySinh, @GioiTinh, @NgayBatDauLam, @SDT, @TinhTrang
				)	
			--
			COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK;
		throw
	END CATCH
END
GO
--THÊM PHÂN CÔNG
CREATE procedure [dbo].[USP_ThemPhanCong] @MaNV varchar(10), @MaCa varchar(11)
as
begin
	set xact_abort on
	begin try
		begin tran
			insert into PhanCong values(@MaNV, @MaCa, 0)
		commit tran
	end try
	begin catch
		rollback;
		throw
	end catch
end
GO
--THÊM PHIẾU MUA
CREATE procedure [dbo].[USP_ThemPhieuMua] @NgayGioMua datetime
AS 
BEGIN
	SET XACT_ABORT ON
	BEGIN TRAN
		BEGIN TRY
			INSERT INTO PhieuMua(NgayGioMua) VALUES
			(@NgayGioMua);
		COMMIT TRAN
		END TRY
		BEGIN CATCH
			ROLLBACK;
			throw
		END CATCH 
END
GO
--THÊM TÀI KHOẢN
CREATE PROCEDURE [dbo].[USP_ThemTaiKhoan] @MaNV varchar(10), @TenNguoiDung nvarchar(30), @MatKhau nvarchar(16), 
					@MaNhomNguoiDung varchar(10)
AS
BEGIN
	SET XACT_ABORT ON
	BEGIN TRY
		-- Khối transaction Tạo tài khoản SQL
		BEGIN TRAN
			INSERT INTO PhanNhom VALUES(@MaNV, @MaNhomNguoiDung)
			INSERT INTO DangNhap VALUES(@TenNguoiDung, @MatKhau, @MaNV)
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK;
		THROW
	END CATCH
END
GO
--======= XÓA 

--XÓA CTHĐ
CREATE PROCEDURE [dbo].[USP_XoaChiTietHoaDon] ( @MaHoaDon varchar(13), @mamh varchar(10))
AS 
BEGIN
	SET XACT_ABORT ON
	BEGIN TRAN
		BEGIN TRY
			DELETE dbo.ChiTietHoaDon
			Where MaHoaDon = @MaHoaDon and MaMH = @mamh
		COMMIT TRAN
		END TRY
		BEGIN CATCH
			ROLLBACK;
			throw
		END CATCH 
END
GO
--XÓA CHI TIẾT LƯƠNG
CREATE PROCEDURE [dbo].[usp_XoaChiTietLuong] @MaNV varchar(10), @MaCa varchar(11)
	AS
	BEGIN
		SET XACT_ABORT ON
		BEGIN TRY
			BEGIN TRANSACTION
			--
				DELETE ChiTietLuongNgay 
				WHERE MaNV = @MaNV and MaCa = @MaCa
			--
			COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK;
		throw
	END CATCH
END
GO
--XÓA CHI TIẾT MUA
CREATE PROCEDURE [dbo].[USP_XoaChiTietMua] ( @MaPhieuMua VARCHAR(16), @MaNVL CHAR(10))
AS 
BEGIN
	SET XACT_ABORT ON
	BEGIN TRAN
		BEGIN TRY
			DELETE dbo.chitietmua
			Where MaPhieuMua = @MaPhieuMua and MaNVL = @MaNVL
		COMMIT TRAN
		END TRY
		BEGIN CATCH
			ROLLBACK;
			throw
		END CATCH 
END
GO
--XÓA HÓA ĐƠN
CREATE PROCEDURE [dbo].[USP_XoaHoaDon] ( @MaHoaDon varchar(13))
AS 
BEGIN
	SET XACT_ABORT ON
	BEGIN TRAN
		BEGIN TRY
			DELETE dbo.HoaDon
			Where MaHoaDon = @MaHoaDon
		COMMIT TRAN
		END TRY
		BEGIN CATCH
			ROLLBACK;
			throw
		END CATCH 
END
GO
--XÓA KHÁCH HÀNG
CREATE PROCEDURE [dbo].[USP_XoaKhachHang] ( @makh char(11) )
AS 
BEGIN
	SET XACT_ABORT ON
	BEGIN TRAN
		BEGIN TRY
			DELETE KhachHang WHERE MaKH = @makh;
		COMMIT TRAN
		END TRY
		BEGIN CATCH
			ROLLBACK;
			throw
		END CATCH 
END
GO
--XÓA NHÂN VIÊN
ALTER PROCEDURE [dbo].[usp_XoaNhanVien] @MaNV varchar(10)
AS
BEGIN
	SET XACT_ABORT ON
	BEGIN TRY
		BEGIN TRAN
		--
			DELETE FROM NhanVien
			WHERE MaNV = @MaNV
		--
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK;
		throw
	END CATCH
END
GO

EXEC usp_XoaNhanVien 'NV00000024'
select * from DangNhap
--XÓA PHÂN CÔNG
CREATE procedure [dbo].[USP_XoaPhanCong] @MaNV varchar(10), @MaLoaiCa char(10), @NgayLam date
as
begin
	declare @MaCa varchar(11)
	set @MaCa = 'CL' + RIGHT(RTRIM(@MaLoaiCa), 1) + convert(varchar(8),cast(@NgayLam as date),112)
	set xact_abort on
	begin try
		begin tran
			delete from PhanCong
			where MaCa = @MaCa and MaNV = @MaNV
		commit tran
	end try
	begin catch
		rollback;
		throw
	end catch
end
GO
--XÓA TÀI KHOẢN NHÂN VIÊN
ALTER procedure [dbo].[USP_XoaTaiKhoanNhanVien] @MaNV varchar(10)
as
begin
	SET XACT_ABORT ON
	
	declare @TenNguoiDung varchar(30), @stringSQL nvarchar(max), @SID smallint, @sqlKill nvarchar(max);
	select @TenNguoiDung =  TenNguoiDung from DangNhap where MaNV = @MaNV
	
	begin try
			
		SELECT @SID = session_id FROM sys.dm_exec_sessions WHERE login_name = @TenNguoiDung
		SET @sqlKill = 'KILL ' + CAST(@SID as varchar(4))
		PRINT @SID
		EXEC (@sqlKill)
		PRINT 'Loi trong XoaTaiKhoan ne thang ngu'
		begin tran
		set @stringSQL = 'drop user ['+@TenNguoiDung+']';
		EXEC(@stringSQL);
		set @stringSQL = 'drop login ['+@TenNguoiDung+']';
		EXEC(@stringSQL);
		
		commit tran
	end try
	begin catch
		rollback;
		throw
	end catch
end
GO
select session_id FROM sys.dm_exec_sessions WHERE login_name = 'aaa'

exec USP_XoaTaiKhoanNhanVien 'NV00000006' 
--=======================================================================================================================================

-- TẠO TRIGGER

-- Sau khi thực hiện in hóa đơn (update ngày giờ) thì sửa lại trạng thái bàn là trống và update điểm tích lũy cho khách hàng
CREATE TRIGGER TRG_HoaDon_AfterUpdate_UpdateDTLAndTableStatus on HoaDon 
AFTER UPDATE 
AS
DECLARE @makh varchar(11), @maban char(10), @dtlAdd float, @dtlUsed float
SELECT @makh = ol.MaKH, @maban = ne.MaBan, @dtlAdd = ne.DiemTichLuyThem, @dtlUsed = ne.DiemSuDung
FROM inserted ne, deleted ol
WHERE ne.MaHoaDon LIKE ol.MaHoaDon
BEGIN
	if @makh IS NOT null		-- Nếu khách không phải hội viên thì thôi
	BEGIN
		UPDATE KhachHang
		SET DiemTichLuyHienTai += @dtlAdd - @dtlUsed, TongDiemTichLuy += @dtlAdd
		WHERE MaKH = @makh
	END

	if @maban IS NOT null		-- Nếu khách mua về thì không sửa trạng thái
	BEGIN
		UPDATE Ban 
		SET TrangThai = N'Trống'
		WHERE MaBan = @maban
	END
END
GO
-- Nếu điểm tổng lớn hơn hoặc bằng 100 thì set thành khách vip
CREATE TRIGGER TRG_KhachHang_AfterUpdate_UpdateVIP on KhachHang
AFTER UPDATE
AS
DECLARE @maKH char(10), @diemTichLuyHienTai float, @tongDiemTichLuy float, @maLoaiKH char(10)
SELECT @maKH = ne.MaKH,  @diemTichLuyHienTai = ne.diemTichLuyHienTai, @tongDiemTichLuy = ne.TongDiemTichLuy, @maLoaiKH = ol.MaLoaiKH
FROM inserted ne, deleted ol
WHERE ne.MaKH = ol.MaKH

IF @maLoaiKH NOT LIKE 'VIP'
BEGIN
   IF @tongDiemTichLuy >= 100
   BEGIN
		UPDATE KhachHang
		SET MaLoaiKH = 'VIP'
		WHERE MaKH LIKE @maKH
   END
END

GO

-- Update điểm danh trong phân công thì tự động insert MaNV, MaCV, MaCa,.... vào chi tiết lương	hoặc xóa chi tiết lương khi hủy điểm danh
CREATE TRIGGER [dbo].[TRG_PhanCong_AfterUpdate_GenerateSalaryForPresentEmp] on [dbo].[PhanCong]
AFTER UPDATE
AS
DECLARE @maNV varchar(10), @maChucVu char(10), @maCa varchar(11), @ngayLuong date, @thanhTien float, @diemDanh int,
		@luong1GioLam float, @tienThuongCa float, @maLoaiCa char(10), @Flag int, @oldDiemDanh int, @kyLuong date

SELECT @maNV = ne.MaNV, @maCa = ne.MaCa, @diemDanh = ne.DiemDanh, @oldDiemDanh = ol.DiemDanh
FROM inserted ne, deleted ol
WHERE ne.MaNV = ol.MaNV

SET @Flag = 1
IF @diemDanh = @oldDiemDanh
BEGIN
	Set @Flag = 0
END

SELECT @maChucVu = 	nv.MaChucVu
FROM NhanVien nv
WHERE nv.MaNV = @maNV

SELECT @ngayLuong = ca.NgayLam, @maLoaiCa = ca.MaLoaiCa
FROM CaLam ca
WHERE ca.MaCa = @maCa

SET @kyLuong = EOMONTH(@ngayLuong)

SELECT @tienThuongCa = TienThuongCa 
FROM LoaiCa
WHERE MaLoaiCa = @maLoaiCa

SELECT @luong1GioLam = LuongMotGioLam
FROM ChucVu
WHERE MaChucVu = @maChucVu

SET @thanhTien = @luong1GioLam * 4 + @tienThuongCa


IF @diemDanh = 1  AND @Flag = 1		-- flag bằng 0 nghĩa là KHÔNG có sự thay đổi
BEGIN
	exec dbo.usp_ThemChiTietLuong @MaNV = @maNV, @MaCa = @maCa, @NgayLuong = @ngayLuong, @ThanhTien = @thanhTien, 
		@KyLuong = @kyLuong
END
IF @diemDanh = 0 AND @Flag = 1
BEGIN
	exec dbo.usp_XoaChiTietLuong  @MaNV = @maNV, @MaCa = @maCa
END
GO

-- Trigger xóa nhân viên
alter trigger TRG_InsteadDelete_XoaNhanVien ON NhanVien
Instead of DELETE
AS
DECLARE @MaNV varchar(10)
SELECT @MaNV=ol.MaNV
FROM deleted ol
BEGIN
	
	--Chuyển đổi trạng thái làm việc của nhân viên thành 'Đã nghỉ'
	UPDATE NhanVien Set TinhTrang = N'Đã nghỉ' WHERE MaNV = @MaNV
	-- Xóa Nhân viên khỏi bảng phân nhóm
	DELETE FROM PhanNhom WHERE MaNV = @MaNV
	-- Xóa tài khoản SQL
	PRINT 'loi ne thang ngu'
	EXEC USP_XoaTaiKhoanNhanVien @MaNV
	-- Xóa tài khoản khỏi bảng đăng nhập
	
	DELETE FROM DangNhap WHERE MaNV = @MaNV
END
GO

--TRIGGER TẠO TÀI KHOẢN SQL SAU KHI THÊM VÀO BẢNG ĐĂNG NHẬP
CREATE TRIGGER TRG_AfterInsert_TaoTaiKhoanSQLSauKhiThemDangNhap ON DangNhap
AFTER INSERT
AS
DECLARE @TenNguoiDung nvarchar(30), @MatKhau nvarchar(16)
SELECT @TenNguoiDung = ne.TenNguoiDung, @MatKhau = ne.MatKhau 
FROM inserted ne
DECLARE @sqlString nvarchar(max)
BEGIN
	/* Tạo tài khoản login trên cơ sở dữ liệu cho nhân viên với tên người dùng và tài khoản
		được truyền vào*/
	SET @sqlString = 'CREATE LOGIN [' + @TenNguoiDung +'] WITH PASSWORD='''+ @MatKhau
		+''', DEFAULT_DATABASE=[QUANLYQUANTRASUA], CHECK_EXPIRATION=OFF,
		CHECK_POLICY=OFF'
	EXEC (@sqlString)

	-- Tạo tài khoản người dùng đối với nhân viên đó trên database (tên ngườidùng trùng với tên login)
	SET @sqlString= 'CREATE USER ' + @TenNguoiDung +' FOR LOGIN '+ @TenNguoiDung
	EXEC (@sqlString)ENDGO
--=======================================================================================================================================

--TẠO LOGIN ADMIN

create login [adminTS] with password = '0986294205', DEFAULT_DATABASE = [QUANLYQUANTRASUA],
CHECK_EXPIRATION = OFF, CHECK_POLICY=OFF
GO
create user adminTS for login adminTS
GO
ALTER SERVER ROLE sysadmin ADD MEMBER adminTS
GO

--=======================================================================================================================================
--TẠO ROLE STAFF

CREATE ROLE Staff
GO

--Gán quyền thao tác trên các bảng cho Nhân viên
GRANT SELECT, REFERENCES ON Ban TO Staff
GRANT SELECT, REFERENCES ON CaLam TO Staff
GRANT SELECT, REFERENCES ON ChiTietHoaDon TO Staff
GRANT SELECT, REFERENCES ON ChiTietLuongNgay TO Staff
GRANT SELECT, INSERT, DELETE, UPDATE, REFERENCES ON ChiTietMua TO Staff
GRANT SELECT, REFERENCES ON ChucVu TO Staff
GRANT SELECT, REFERENCES ON DangNhap TO Staff
GRANT SELECT, INSERT, UPDATE, REFERENCES ON HoaDon TO Staff
GRANT SELECT, INSERT, UPDATE, REFERENCES ON KhachHang TO Staff	  
GRANT SELECT, REFERENCES ON DangNhap TO Staff
GRANT SELECT, INSERT, DELETE, UPDATE, REFERENCES ON Kho TO Staff
GRANT SELECT, REFERENCES ON LoaiCa TO Staff
GRANT SELECT, REFERENCES ON LoaiKhachHang TO Staff
GRANT SELECT, REFERENCES ON LoaiMatHang TO Staff
GRANT SELECT, INSERT, DELETE, UPDATE, REFERENCES ON LuuTru TO Staff
GRANT SELECT, REFERENCES ON NguyenVatLieu TO Staff
GRANT SELECT, REFERENCES ON NhanVien TO Staff
GRANT SELECT, INSERT, DELETE, UPDATE, REFERENCES ON NhapKho TO Staff
GRANT SELECT, REFERENCES ON NhomNguoiDung TO Staff
GRANT SELECT, REFERENCES ON PhanCong TO Staff
GRANT SELECT, REFERENCES ON PhanNhom TO Staff
GRANT SELECT, INSERT, DELETE, UPDATE, REFERENCES ON PhieuMua TO Staff
GRANT SELECT, INSERT, DELETE, UPDATE, REFERENCES ON XuatKho TO Staff

-- Gán quyền thực thi các thủ tục và hàm cho Nhân viên
GRANT EXECUTE TO Staff
GRANT SELECT TO Staff

/* Không cho thực thi thủ tục trên Ca làm */
DENY EXECUTE ON USP_ThemCaLam to Staff;

/* Không cho thực thi thủ tục trên Chi tiết lương */
DENY EXECUTE ON usp_SuaChiTietLuong to Staff;DENY EXECUTE ON usp_ThemChiTietLuong to Staff;DENY EXECUTE ON usp_XoaChiTietLuong to Staff;/* Không cho thực thi thủ tục trên Chi tiết mua */DENY EXECUTE ON USP_SuaChiTietMua to Staff;DENY EXECUTE ON USP_ThemChiTietMua to Staff;DENY EXECUTE ON USP_XoaChiTietMua to Staff;/* Không cho thực thi thủ tục trên Chức vụ */DENY EXECUTE ON usp_SuaChucVu to Staff;DENY EXECUTE ON usp_ThemChucVu to Staff;/* Không cho thực thi thủ tục trên Đăng nhập */DENY EXECUTE ON USP_DoiMatKhau to Staff;DENY EXECUTE ON USP_GanQuyenTaiKhoan to Staff;DENY EXECUTE ON USP_DoiMatKhau to Staff;DENY EXECUTE ON USP_ThemTaiKhoan to Staff;/* Không cho thực thi thủ tục trên Nhân viên */DENY EXECUTE ON usp_SuaNhanVien to Staff;DENY EXECUTE ON usp_ThemNhanVien to Staff;DENY EXECUTE ON usp_XoaNhanVien to Staff;/* Không cho thực thi thủ tục trên Phân công */DENY EXECUTE ON USP_ThemPhanCong to Staff;DENY EXECUTE ON USP_XoaPhanCong to Staff;DENY EXECUTE ON USP_DiemDanhPhanCong to Staff;
GO


