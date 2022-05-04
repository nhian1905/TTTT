create database QuanLyCamDo
use QuanLyCamDo

create table Quyen
(
	ID_Quyen int identity(1,1) primary key,
	Name_Quyen nvarchar(50) 
)
create table TaiKhoan
(
	UsersName nvarchar(100) primary key,
	Password nvarchar(max),
	ID_Quyen int not null

	foreign key(ID_Quyen) references Quyen(ID_Quyen)
)
create table KhachHang
(
	MaKH int identity(1,1) primary key,
	TenKH nvarchar(100) not null,
	SDT int ,
	CMND int not null,
	NamSinh Date,
	DiaChi nvarchar(100),
	NgayCapCMND Date,
	HinhAnh  nvarchar(max)
)

create table LoaiSP 
(
	MaLoai int identity(1,1) primary key,
	TenLoai nvarchar(100) not null,
	LaiXuat int not null
)

create table SanPham
(
	MaSP int identity(1,1) primary key,
	TenSP nvarchar(100) not null,
	DinhGia float not null,
	GiaThanhLy float null,
	MaLoai int not null,
	MoTa nvarchar(max),
	MauSac nvarchar(max),
	HienTrang nvarchar(max),
	NhangHieu nvarchar(max),
	MaRieng nvarchar(max),
	QuaHan bit,
	DaChuoc bit,
	ThanhLy bit,
	DaThanhLy bit
	foreign key(MaLoai) references LoaiSP(MaLoai)
)

create table ThanhLy
(
	MaThanhLy int identity(1,1) primary key,
	MaKH int not null,
	NgayLap datetime ,
	TongTienThanhLy float
	foreign key(MaKH) references KhachHang(MaKH)
)

create table ChiTiet_ThanhLy
(
	MaThanhLy int not null,
	MaSP int not null
	CONSTRAINT pk_HDTL PRIMARY KEY (MaThanhLy, MaSP),
	foreign key(MaThanhLy) references ThanhLy(MaThanhLy),
	foreign key(MaSP) references SanPham(MaSP)
)

create table HoaDonCam
(
	MaHoaDonCam int identity(1,1) primary key,
	MaKH int not null,
	NgayLap datetime ,
	NgayHetHan datetime ,
	TongTienCam float,
	foreign key(MaKH) references KhachHang(MaKH)
)

create table ChiTiet_HoaDonCam
(	
	MaHoaDonCam int not null ,
	MaSP int not null,
	CONSTRAINT pk_CTHDC PRIMARY KEY (MaHoaDonCam, MaSP),
	foreign key(MaHoaDonCam) references HoaDonCam(MaHoaDonCam),
	foreign key(MaSP) references SanPham(MaSP)
)

create table PhieuLai
(
	MaPhieuLai int identity(1,1) primary key,
	MaHoaDonCam int not null,
	NgayDongLai datetime,
	ThanhTien float
	foreign key(MaHoaDonCam) references HoaDonCam(MaHoaDonCam),
)
create table PhieuChuoc
(
	MaPhieuChuoc int identity(1,1) primary key,
	MaHoaDonCam int not null ,
	NgayChuoc datetime,
	TongTien float
	foreign key(MaHoaDonCam) references HoaDonCam(MaHoaDonCam),
)
create table ChiTiet_PhieuChuoc
(
	MaPhieuChuoc int not null,
	MaSP int not null ,
	TienLai float not null,
	TongTien float,
	CONSTRAINT pk_CTPC PRIMARY KEY (MaPhieuChuoc, MaSP),
	foreign key(MaSP) references SanPham(MaSP)
)



