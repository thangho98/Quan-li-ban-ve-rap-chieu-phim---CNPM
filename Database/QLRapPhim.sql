CREATE DATABASE QuanLyRapPhim
GO

USE QuanLyRapPhim
GO


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
	DienTich FLOAT NOT NULL,
	TinhTrang INT NOT NULL DEFAULT 1 -- 0:không hoạt động || 1:đang hoạt động

	FOREIGN KEY (idManHinh) REFERENCES dbo.LoaiManHinh(id)
)
GO

CREATE TABLE Phim
(
	id VARCHAR(50) PRIMARY KEY,
	TenPhim NVARCHAR(100) NOT NULL,
	ThoiLuong FLOAT NOT NULL,
	DaoDien NVARCHAR(100)
)
GO

CREATE TABLE ManHinhHoTro --Phim có hỗ trợ màn hình 3D hay IMax không?
(
	idPhim VARCHAR(50) NOT NULL,
	idLoaiManHinh VARCHAR(50) NOT NULL,

	FOREIGN KEY (idPhim) REFERENCES dbo.Phim(id),
	FOREIGN KEY (idLoaiManHinh) REFERENCES dbo.LoaiManHinh,

	CONSTRAINT PK_ManHinhHoTro PRIMARY KEY (idPhim,idLoaiManHinh)
)
GO

CREATE TABLE TheLoai
(
	id VARCHAR(50) PRIMARY KEY,
	TenLoai NVARCHAR(100) NOT NULL,
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

CREATE TABLE SuatChieu
(
	id VARCHAR(50) PRIMARY KEY,
	NgayChieu DATE NOT NULL,
	GioChieu TIME,
	idPhong VARCHAR(50) NOT NULL,
	idPhim VARCHAR(50) NOT NULL,

	FOREIGN KEY (idPhong) REFERENCES dbo.PhongChieu(id),
	FOREIGN KEY (idPhim) REFERENCES dbo.Phim(id),

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
	TenKM NVARCHAR NOT NULL, --1:Vé thường || 2:Vé Học sinh - Sinh viên
	MoTa NVARCHAR,
	NgayBatDau DATE NOT NULL DEFAULT GETDATE(),
	NgayKetThuc DATE NOT NULL,
	DiemTichLuy int,
	TiSuatKM FLOAT NOT NULL
)
GO

CREATE TABLE Ve
(
	id VARCHAR(50) PRIMARY KEY,
	LoaiVe INT NOT NULL, --1:Vé thường || 2:Vé Học sinh - Sinh viên
	idSuatChieu VARCHAR(50),
	idGheNgoi VARCHAR(50),
	idKhachHang VARCHAR(50) DEFAULT 'GUEST',
	idCheDoKM VARCHAR(50) DEFAULT '0',
	GiaVe FLOAT NOT NULL, --(??) Đi vào trong idSuatChieu=>idPhong=>lấy ra idLoaiManHinh. 
	--Với mỗi loại vé kết hợp loại màn hình sẽ ra 1 giá vé tương ứng
	--(vd : vé thường + 2D = 100k; vé hssv + 2D = 60k)

	FOREIGN KEY (idSuatChieu) REFERENCES dbo.SuatChieu(id),
	FOREIGN KEY (idCheDoKM) REFERENCES dbo.CheDoKM(id),
	FOREIGN KEY (idKhachHang) REFERENCES dbo.KhachHang(id)
)
GO



INSERT INTO dbo.NhanVien
( id, hoTen, ngaySinh, diaChi, CMND )
VALUES  
( 
	'NV00', -- id - int
	N'admin', -- hoTen - nvarchar(100)
	GETDATE(), -- ngaySinh - date
	N'207 Quốc lộ 13', -- diaChi - nvarchar(100)
	123456789  -- soCMND - int
)
GO

SELECT * FROM dbo.NhanVien
GO

CREATE PROC USP_GetNVByCMND
@CMND int
AS
BEGIN
	SELECT * FROM dbo.NhanVien WHERE @CMND = CMND
END
GO

EXEC dbo.USP_GetNVByCMND @CMND = 123456789 -- int
