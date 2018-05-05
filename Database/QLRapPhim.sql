CREATE DATABASE QLRP
GO

USE QLRP
GO

--drop database QLRP


CREATE TABLE NhanVien
(
	id VARCHAR(50) PRIMARY KEY,
	HoTen NVARCHAR(100) NOT NULL,
	NgaySinh DATE NOT NULL,
	DiaChi NVARCHAR(100),
	SDT VARCHAR(100),
	CMND INT NOT NULL Unique
)
GO

CREATE TABLE TaiKhoan
(
	UserName NVARCHAR(100) NOT NULL,
	Pass NVARCHAR(1000) NOT NULL,
	LoaiTK INT NOT NULL DEFAULT 2, -- 1:admin || 2:staff
	idNV VARCHAR(50) NOT NULL,

	FOREIGN KEY (idNV) REFERENCES dbo.NhanVien(ID)
)
GO

CREATE TABLE LoaiManHinh
(
	id VARCHAR(50) PRIMARY KEY,
	TenMH NVARCHAR(100) --2D || 3D || IMax
)
GO

CREATE TABLE PhongChieu
(
	id VARCHAR(50) PRIMARY KEY,
	TenPhong NVARCHAR(100) NOT NULL,
	idManHinh VARCHAR(50),
	SoChoNgoi INT NOT NULL,
	GheVip nvarchar(1000) not null,
	TinhTrang INT NOT NULL DEFAULT 1, -- 0:không hoạt động || 1:đang hoạt động
	SoHangGhe int not null,
	SoGheMotHang int not null,

	FOREIGN KEY (idManHinh) REFERENCES dbo.LoaiManHinh(id)
)
GO

CREATE TABLE Phim
(
	id varchar(50) PRIMARY KEY,
	TenPhim nvarchar(100) NOT NULL,
	MoTa nvarchar(1000) NULL,
	ThoiLuong float NOT NULL,
	NgayKhoiChieu date NOT NULL,
	NgayKetThuc date NOT NULL,
	SanXuat nvarchar(50) NOT NULL,
	DaoDien nvarchar(100) NULL,
	NamSX int NOT NULL,
)
GO

CREATE TABLE DinhDangPhim --Phim có hỗ trợ màn hình 3D hay IMax không?
(
	id varchar(50) NOT NULL primary key,
	idPhim VARCHAR(50) NOT NULL,
	idLoaiManHinh VARCHAR(50) NOT NULL,

	FOREIGN KEY (idPhim) REFERENCES dbo.Phim(id),
	FOREIGN KEY (idLoaiManHinh) REFERENCES dbo.LoaiManHinh,
)
GO

CREATE TABLE TheLoai
(
	id VARCHAR(50) PRIMARY KEY,
	TenTheLoai NVARCHAR(100) NOT NULL,
	MoTa NVARCHAR(100)
)
GO

CREATE TABLE PhanLoaiPhim --Quan hệ giữa Phim và LoaiPhim là quan hệ n-n
(
	idPhim VARCHAR(50) NOT NULL,
	idTheLoai VARCHAR(50) NOT NULL,

	FOREIGN KEY (idPhim) REFERENCES dbo.Phim(id),
	FOREIGN KEY (idTheLoai) REFERENCES dbo.TheLoai(id),

	CONSTRAINT PK_PhanLoaiPhim PRIMARY KEY(idPhim,idTheLoai)
)
GO

CREATE TABLE LichChieu
(
	id VARCHAR(50) PRIMARY KEY,
	ThoiGianChieu DATETIME NOT NULL,
	idPhong VARCHAR(50) NOT NULL,
	idDinhDang VARCHAR(50) NOT NULL,

	FOREIGN KEY (idPhong) REFERENCES dbo.PhongChieu(id),
	FOREIGN KEY (idDinhDang) REFERENCES dbo.DinhDangPhim(id),

	--CONSTRAINT PK_LichChieu PRIMARY KEY(ngayChieu,gioChieu,idPhong) --Vì cùng 1 thời điểm có thể có nhiều phòng cùng hoạt động nên khóa chính phải là cả 3 cái
)
GO

CREATE TABLE KhachHang
(
	id VARCHAR(50) PRIMARY KEY,
	HoTen NVARCHAR(100) NOT NULL,
	NgaySinh DATE NOT NULL,
	DiaChi NVARCHAR(100),
	SDT VARCHAR(100),
	CMND INT NOT NULL Unique,
	DiemTichLuy int
)
GO

CREATE TABLE CheDoKM
(
	id VARCHAR(50) PRIMARY KEY,
	TenKM NVARCHAR NOT NULL,
	MoTa NVARCHAR,
	NgayBatDau DATE NOT NULL DEFAULT GETDATE(),
	NgayKetThuc DATE NOT NULL,
	DiemTichLuy int,
	TiSuatKM FLOAT NOT NULL
)
GO

CREATE TABLE Ve
(
	id int identity(1,1) PRIMARY KEY,
	LoaiVe INT  DEFAULT '0', --0: Vé người lớn || 1: Vé học sinh - sinh viên || 2: vé trẻ em
	idLichChieu VARCHAR(50),
	MaGheNgoi VARCHAR(50),
	LoaiGheNgoi INT NOT NULL,--0: Ghế Thường || 1: Ghế Vip
	idKhachHang VARCHAR(50),
	idCheDoKM VARCHAR(50),
	GiaVe FLOAT, --(??) Đi vào trong idSuatChieu=>idPhong=>lấy ra idLoaiManHinh. 
	--Với mỗi loại vé kết hợp loại màn hình sẽ ra 1 giá vé tương ứng
	--(vd : vé thường + 2D = 100k; vé hssv + 2D = 60k)
	TrangThai INT NOT NULL DEFAULT '0' --0: 'Chưa Bán' || 1: 'Đã Bán'

	FOREIGN KEY (idLichChieu) REFERENCES dbo.LichChieu(id),
	--FOREIGN KEY (idCheDoKM) REFERENCES dbo.CheDoKM(id),
	FOREIGN KEY (idKhachHang) REFERENCES dbo.KhachHang(id)
)
GO


SELECT * FROM dbo.TaiKhoan

CREATE PROC USP_Login
@userName nvarchar(1000), @pass nvarchar(1000)
AS
BEGIN
	SELECT * FROM dbo.TaiKhoan WHERE UserName = @userName AND Pass = @pass
END
GO


SET IDENTITY_INSERT Ve OFF
GO


INSERT [dbo].[TheLoai] ([id], [TenTheLoai], [MoTa]) VALUES (N'TL01', N'Hành Động', NULL)
INSERT [dbo].[TheLoai] ([id], [TenTheLoai], [MoTa]) VALUES (N'TL02', N'Hoạt Hình', NULL)
INSERT [dbo].[TheLoai] ([id], [TenTheLoai], [MoTa]) VALUES (N'TL03', N'Hài', NULL)
INSERT [dbo].[TheLoai] ([id], [TenTheLoai], [MoTa]) VALUES (N'TL04', N'Viễn Tưởng', NULL)
INSERT [dbo].[TheLoai] ([id], [TenTheLoai], [MoTa]) VALUES (N'TL05', N'Phiêu lưu', NULL)
INSERT [dbo].[TheLoai] ([id], [TenTheLoai], [MoTa]) VALUES (N'TL06', N'Gia đình', NULL)
INSERT [dbo].[TheLoai] ([id], [TenTheLoai], [MoTa]) VALUES (N'TL07', N'Tình Cảm', NULL)
INSERT [dbo].[TheLoai] ([id], [TenTheLoai], [MoTa]) VALUES (N'TL08', N'Tâm Lý', NULL)

INSERT [dbo].[NhanVien] ([id], [HoTen], [NgaySinh], [DiaChi], [SDT], [CMND]) VALUES (N'NV00', N'admin', CAST(N'2018-04-22' AS Date), N'admin', NULL, 123456789)
INSERT [dbo].[NhanVien] ([id], [HoTen], [NgaySinh], [DiaChi], [SDT], [CMND]) VALUES (N'NV01', N'Bán Vé', CAST(N'2018-04-30' AS Date), NULL, NULL, 14725836)

INSERT [dbo].[TaiKhoan] ([UserName], [Pass], [LoaiTK], [idNV]) VALUES (N'admin', N'admin', 1, N'NV00')
INSERT [dbo].[TaiKhoan] ([UserName], [Pass], [LoaiTK], [idNV]) VALUES (N'NV01', N'1', 2, N'NV01')

INSERT [dbo].[KhachHang] ([id], [HoTen], [NgaySinh], [DiaChi], [SDT], [CMND], [DiemTichLuy]) VALUES (N'KH01', N'Nguyễn Văn A', CAST(N'1998-05-03' AS Date), N'Bla Bla', N'0123456789', 218161554, 0)
INSERT [dbo].[KhachHang] ([id], [HoTen], [NgaySinh], [DiaChi], [SDT], [CMND], [DiemTichLuy]) VALUES (N'KH02', N'Nguyễn Văn B', CAST(N'1998-05-03' AS Date), N'Bla Bla', N'0123456789', 218161564, 0)
INSERT [dbo].[KhachHang] ([id], [HoTen], [NgaySinh], [DiaChi], [SDT], [CMND], [DiemTichLuy]) VALUES (N'KH03', N'Nguyễn Văn B', CAST(N'1998-05-03' AS Date), N'Bla Bla', N'0123456789', 218161654, 0)

INSERT [dbo].[LoaiManHinh] ([id], [TenMH]) VALUES (N'MH01', N'2D')
INSERT [dbo].[LoaiManHinh] ([id], [TenMH]) VALUES (N'MH02', N'3D')
INSERT [dbo].[LoaiManHinh] ([id], [TenMH]) VALUES (N'MH03', N'IMAX')
INSERT [dbo].[LoaiManHinh] ([id], [TenMH]) VALUES (N'MH04', N'4D')

INSERT [dbo].[PhongChieu] ([id], [TenPhong], [idManHinh], [SoChoNgoi], [GheVip], [TinhTrang], [SoHangGhe], [SoGheMotHang]) VALUES (N'PC01', N'CINEMA 01', N'MH01', 140, N'E4-K11', 1, 10, 14)
INSERT [dbo].[PhongChieu] ([id], [TenPhong], [idManHinh], [SoChoNgoi], [GheVip], [TinhTrang], [SoHangGhe], [SoGheMotHang]) VALUES (N'PC02', N'CINEMA 02', N'MH02', 140, N'E4-K11', 1, 10, 14)
INSERT [dbo].[PhongChieu] ([id], [TenPhong], [idManHinh], [SoChoNgoi], [GheVip], [TinhTrang], [SoHangGhe], [SoGheMotHang]) VALUES (N'PC03', N'CINEMA 03', N'MH03', 140, N'E4-K11', 1, 10, 14)
INSERT [dbo].[PhongChieu] ([id], [TenPhong], [idManHinh], [SoChoNgoi], [GheVip], [TinhTrang], [SoHangGhe], [SoGheMotHang]) VALUES (N'PC04', N'CINEMA 04', N'MH04', 140, N'E4-K11', 1, 10, 14)

INSERT [dbo].[Phim] ([id], [TenPhim], [MoTa], [ThoiLuong], [NgayKhoiChieu], [NgayKetThuc], [SanXuat], [DaoDien], [NamSX]) VALUES (N'P01', N'Avengers: Cuộc Chiến Vô Cực', N'Avengers: Infinity War', 150, CAST(N'2018-05-01' AS Date), CAST(N'2018-06-01' AS Date), N'Mỹ', N'Anthony Russo,  Joe Russo', 2018)
INSERT [dbo].[Phim] ([id], [TenPhim], [MoTa], [ThoiLuong], [NgayKhoiChieu], [NgayKetThuc], [SanXuat], [DaoDien], [NamSX]) VALUES (N'P02', N'Lật Mặt: 3 Chàng Khuyết', N'Lat Mat 3 Chang Khuyet', 100, CAST(N'2018-05-01' AS Date), CAST(N'2018-06-01' AS Date), N'Việt Nam', N'Lý Hải', 2018)
INSERT [dbo].[Phim] ([id], [TenPhim], [MoTa], [ThoiLuong], [NgayKhoiChieu], [NgayKetThuc], [SanXuat], [DaoDien], [NamSX]) VALUES (N'P03', N'100 Ngày Bên Em', NULL, 100, CAST(N'2018-05-01' AS Date), CAST(N'2018-06-01' AS Date), N'Việt Nam', N'Vũ Ngọc Phượng', 2018)
INSERT [dbo].[Phim] ([id], [TenPhim], [MoTa], [ThoiLuong], [NgayKhoiChieu], [NgayKetThuc], [SanXuat], [DaoDien], [NamSX]) VALUES (N'P04', N'Ngỗng Vịt Phiêu Lưu Ký', N'Duck Duck Goose', 91, CAST(N'2018-05-01' AS Date), CAST(N'2018-06-01' AS Date), N'Mỹ', N'Christopher Jenkins', 2018)

INSERT [dbo].[PhanLoaiPhim] ([idPhim], [idTheLoai]) VALUES (N'P01', N'TL01')
INSERT [dbo].[PhanLoaiPhim] ([idPhim], [idTheLoai]) VALUES (N'P01', N'TL04')
INSERT [dbo].[PhanLoaiPhim] ([idPhim], [idTheLoai]) VALUES (N'P01', N'TL05')
INSERT [dbo].[PhanLoaiPhim] ([idPhim], [idTheLoai]) VALUES (N'P02', N'TL01')
INSERT [dbo].[PhanLoaiPhim] ([idPhim], [idTheLoai]) VALUES (N'P02', N'TL07')
INSERT [dbo].[PhanLoaiPhim] ([idPhim], [idTheLoai]) VALUES (N'P02', N'TL08')
INSERT [dbo].[PhanLoaiPhim] ([idPhim], [idTheLoai]) VALUES (N'P03', N'TL03')
INSERT [dbo].[PhanLoaiPhim] ([idPhim], [idTheLoai]) VALUES (N'P03', N'TL07')
INSERT [dbo].[PhanLoaiPhim] ([idPhim], [idTheLoai]) VALUES (N'P03', N'TL08')
INSERT [dbo].[PhanLoaiPhim] ([idPhim], [idTheLoai]) VALUES (N'P04', N'TL02')
INSERT [dbo].[PhanLoaiPhim] ([idPhim], [idTheLoai]) VALUES (N'P04', N'TL03')
INSERT [dbo].[PhanLoaiPhim] ([idPhim], [idTheLoai]) VALUES (N'P04', N'TL05')

INSERT [dbo].[DinhDangPhim] ([id], [idPhim], [idLoaiManHinh]) VALUES (N'DD01', N'P01', N'MH01')
INSERT [dbo].[DinhDangPhim] ([id], [idPhim], [idLoaiManHinh]) VALUES (N'DD02', N'P01', N'MH03')
INSERT [dbo].[DinhDangPhim] ([id], [idPhim], [idLoaiManHinh]) VALUES (N'DD03', N'P02', N'MH01')
INSERT [dbo].[DinhDangPhim] ([id], [idPhim], [idLoaiManHinh]) VALUES (N'DD04', N'P03', N'MH02')

INSERT [dbo].[LichChieu] ([id], [ThoiGianChieu], [idPhong], [idDinhDang]) VALUES (N'LC01', CAST(N'2018-05-02T08:50:00.000' AS DateTime), N'PC01', N'DD01')
INSERT [dbo].[LichChieu] ([id], [ThoiGianChieu], [idPhong], [idDinhDang]) VALUES (N'LC02', CAST(N'2018-05-02T08:05:00.000' AS DateTime), N'PC02', N'DD01')
INSERT [dbo].[LichChieu] ([id], [ThoiGianChieu], [idPhong], [idDinhDang]) VALUES (N'LC03', CAST(N'2018-05-02T08:10:00.000' AS DateTime), N'PC03', N'DD02')
INSERT [dbo].[LichChieu] ([id], [ThoiGianChieu], [idPhong], [idDinhDang]) VALUES (N'LC04', CAST(N'2018-05-02T09:20:00.000' AS DateTime), N'PC04', N'DD03')
SET IDENTITY_INSERT [dbo].[Ve] ON 

INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (1, 0, N'LC01', N'A1', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (2, 0, N'LC01', N'A2', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (3, 0, N'LC01', N'A3', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (4, 0, N'LC01', N'A4', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (5, 0, N'LC01', N'A5', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (6, 0, N'LC01', N'A6', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (7, 0, N'LC01', N'A7', 0, NULL, N'0', 85000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (8, 0, N'LC01', N'A8', 0, NULL, N'0', 85000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (9, 0, N'LC01', N'A9', 0, NULL, N'0', 85000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (10, 0, N'LC01', N'A10', 0, NULL, N'0', 85000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (11, 0, N'LC01', N'A11', 0, NULL, N'0', 85000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (12, 0, N'LC01', N'A12', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (13, 0, N'LC01', N'A13', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (14, 0, N'LC01', N'A14', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (15, 0, N'LC01', N'B1', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (16, 0, N'LC01', N'B2', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (17, 0, N'LC01', N'B3', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (18, 0, N'LC01', N'B4', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (19, 0, N'LC01', N'B5', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (20, 0, N'LC01', N'B6', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (21, 0, N'LC01', N'B7', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (22, 0, N'LC01', N'B8', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (23, 0, N'LC01', N'B9', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (24, 0, N'LC01', N'B10', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (25, 0, N'LC01', N'B11', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (26, 0, N'LC01', N'B12', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (27, 0, N'LC01', N'B13', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (28, 0, N'LC01', N'B14', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (29, 0, N'LC01', N'C1', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (30, 0, N'LC01', N'C2', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (31, 0, N'LC01', N'C3', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (32, 0, N'LC01', N'C4', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (33, 0, N'LC01', N'C5', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (34, 0, N'LC01', N'C6', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (35, 0, N'LC01', N'C7', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (36, 0, N'LC01', N'C8', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (37, 0, N'LC01', N'C9', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (38, 0, N'LC01', N'C10', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (39, 0, N'LC01', N'C11', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (40, 0, N'LC01', N'C12', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (41, 0, N'LC01', N'C13', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (42, 0, N'LC01', N'C14', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (43, 0, N'LC01', N'D1', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (44, 0, N'LC01', N'D2', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (45, 0, N'LC01', N'D3', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (46, 0, N'LC01', N'D4', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (47, 0, N'LC01', N'D5', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (48, 0, N'LC01', N'D6', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (49, 0, N'LC01', N'D7', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (50, 0, N'LC01', N'D8', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (51, 0, N'LC01', N'D9', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (52, 0, N'LC01', N'D10', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (53, 0, N'LC01', N'D11', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (54, 0, N'LC01', N'D12', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (55, 0, N'LC01', N'D13', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (56, 0, N'LC01', N'D14', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (57, 0, N'LC01', N'E1', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (58, 0, N'LC01', N'E2', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (59, 0, N'LC01', N'E3', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (60, 0, N'LC01', N'E4', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (61, 0, N'LC01', N'E5', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (62, 0, N'LC01', N'E6', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (63, 0, N'LC01', N'E7', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (64, 0, N'LC01', N'E8', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (65, 0, N'LC01', N'E9', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (66, 0, N'LC01', N'E10', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (67, 0, N'LC01', N'E11', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (68, 0, N'LC01', N'E12', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (69, 0, N'LC01', N'E13', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (70, 0, N'LC01', N'E14', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (71, 0, N'LC01', N'F1', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (72, 0, N'LC01', N'F2', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (73, 0, N'LC01', N'F3', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (74, 0, N'LC01', N'F4', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (75, 0, N'LC01', N'F5', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (76, 0, N'LC01', N'F6', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (77, 0, N'LC01', N'F7', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (78, 0, N'LC01', N'F8', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (79, 0, N'LC01', N'F9', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (80, 0, N'LC01', N'F10', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (81, 0, N'LC01', N'F11', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (82, 0, N'LC01', N'F12', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (83, 0, N'LC01', N'F13', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (84, 0, N'LC01', N'F14', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (85, 0, N'LC01', N'G1', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (86, 0, N'LC01', N'G2', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (87, 0, N'LC01', N'G3', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (88, 0, N'LC01', N'G4', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (89, 0, N'LC01', N'G5', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (90, 0, N'LC01', N'G6', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (91, 0, N'LC01', N'G7', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (92, 0, N'LC01', N'G8', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (93, 0, N'LC01', N'G9', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (94, 0, N'LC01', N'G10', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (95, 0, N'LC01', N'G11', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (96, 0, N'LC01', N'G12', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (97, 0, N'LC01', N'G13', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (98, 0, N'LC01', N'G14', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (99, 0, N'LC01', N'J1', 0, NULL, N'0', 85000.0000, 0)
GO
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (100, 0, N'LC01', N'J2', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (101, 0, N'LC01', N'J3', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (102, 0, N'LC01', N'J4', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (103, 0, N'LC01', N'J5', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (104, 0, N'LC01', N'J6', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (105, 0, N'LC01', N'J7', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (106, 0, N'LC01', N'J8', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (107, 0, N'LC01', N'J9', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (108, 0, N'LC01', N'J10', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (109, 0, N'LC01', N'J11', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (110, 0, N'LC01', N'J12', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (111, 0, N'LC01', N'J13', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (112, 0, N'LC01', N'J14', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (113, 0, N'LC01', N'I1', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (114, 0, N'LC01', N'I2', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (115, 0, N'LC01', N'I3', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (116, 0, N'LC01', N'I4', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (117, 0, N'LC01', N'I5', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (118, 0, N'LC01', N'I6', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (119, 0, N'LC01', N'I7', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (120, 0, N'LC01', N'I8', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (121, 0, N'LC01', N'I9', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (122, 0, N'LC01', N'I10', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (123, 0, N'LC01', N'I11', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (124, 0, N'LC01', N'I12', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (125, 0, N'LC01', N'I13', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (126, 0, N'LC01', N'I14', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (127, 0, N'LC01', N'K1', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (128, 0, N'LC01', N'K2', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (129, 0, N'LC01', N'K3', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (130, 0, N'LC01', N'K4', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (131, 0, N'LC01', N'K5', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (132, 0, N'LC01', N'K6', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (133, 0, N'LC01', N'K7', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (134, 0, N'LC01', N'K8', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (135, 0, N'LC01', N'K9', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (136, 0, N'LC01', N'K10', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (137, 0, N'LC01', N'K11', 1, NULL, N'0', 100000.0000, 1)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (138, 0, N'LC01', N'K12', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (139, 0, N'LC01', N'K13', 0, NULL, N'0', 85000.0000, 0)
INSERT [dbo].[Ve] ([id], [LoaiVe], [idLichChieu], [MaGheNgoi], [LoaiGheNgoi], [idKhachHang], [idCheDoKM], [GiaVe], [TrangThai]) VALUES (140, 0, N'LC01', N'K14', 0, NULL, N'0', 85000.0000, 0)
SET IDENTITY_INSERT [dbo].[Ve] OFF

