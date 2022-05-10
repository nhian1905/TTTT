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
	MaSP nvarchar(50) primary key,
	TenSP nvarchar(100) not null,
	DinhGia float not null,
	GiaThanhLy float null,
	MaLoai int not null,
	MoTa nvarchar(max),
	MauSac nvarchar(max),
	HienTrang nvarchar(max),
	NhangHieu nvarchar(max),
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
	MaSP nvarchar(50) not null
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
	MaSP nvarchar(50) not null,
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
	MaSP nvarchar(50) not null ,
	TienLai float not null,
	TongTien float,
	CONSTRAINT pk_CTPC PRIMARY KEY (MaPhieuChuoc, MaSP),
	foreign key(MaSP) references SanPham(MaSP),
	foreign key(MaPhieuChuoc) references PhieuChuoc(MaPhieuChuoc)
)
insert into Quyen values ('admin')
insert into TaiKhoan values ('admin',123,1)

insert into KhachHang values(N'Trần Nhị Ân',0919059069,381909647,'05/19/2020',N'Cà Mau','05/19/2020','1')
insert into KhachHang values(N'Trần Nhị Ân',0919059069,381909647,'05/19/2020',N'Cà Mau','05/19/2020','1')
insert into KhachHang values(N'Trần Nhị Ân',0919059069,381909647,'05/19/2020',N'Cà Mau','05/19/2020','1')
insert into KhachHang values(N'Trần Nhị Ân',0919059069,381909647,'05/19/2020',N'Cà Mau','05/19/2020','1')

insert into LoaiSP values (N'DT',5)
insert into LoaiSP values (N'MT',3)

insert into SanPham values ('IP',N'Điện Thoại',2345.2,3456.3,1,N'Nguyên vẹn',N'Màu đỏ',N'có trầy',N'iphone 10',0,0,0,0)
insert into SanPham values ('LT',N'Máy Tính',2345.2,3456.3,1,N'Nguyên vẹn',N'Màu đỏ',N'có trầy',N' Asus',0,0,0,0)
insert into SanPham values ('LT1',N'Máy Tính',2345.2,3456.3,1,N'Nguyên vẹn',N'Màu đỏ',N'có trầy',N' Asus',0,1,0,0)
insert into SanPham values ('LT2',N'Máy Tính',2345.2,3456.3,1,N'Nguyên vẹn',N'Màu đỏ',N'có trầy',N' Asus',1,0,0,0)
insert into SanPham values ('LT3',N'Máy Tính',2345.2,3456.3,1,N'Nguyên vẹn',N'Màu đỏ',N'có trầy',N' Asus',0,0,0,1)
insert into SanPham values ('LT4',N'Máy Tính',2345.2,3456.3,1,N'Nguyên vẹn',N'Màu đỏ',N'có trầy',N' Asus',0,0,1,1)

insert into HoaDonCam values (1,'05/19/2020','06/19/2020',0)

insert into ChiTiet_HoaDonCam values (1,'IP')

insert into ThanhLy values(1,'05/19/2020',0)
insert into ThanhLy values(2,'05/19/2020',0)

create proc USP_UpdateTongTienHDC 
@Id_HDC int
as
begin
	declare @TT float
	SELECT @TT = ISNULL(SUM(GiaThanhLy),0) FROM ChiTiet_HoaDonCam a , SanPham b  WHERE a.MaSP = b.MaSP and MaHoaDonCam = @Id_HDC 
	update HoaDonCam set TongTienCam = @TT where MaHoaDonCam = @ID_HDC
end
go


create proc USP_UpdateTongTienThanHLy 
@MaThanhLy int
as
begin
	declare @TT float
	SELECT @TT = ISNULL(SUM(GiaThanhLy),0) FROM ChiTiet_ThanhLy a , SanPham b  WHERE a.MaSP = b.MaSP and MaThanhLy = @MaThanhLy 
	update ThanhLy set TongTienThanhLy = @TT where MaThanhLy = @MaThanhLy
end
go


select a.MaSP,b.TenLoai,a.TenSP,a.DinhGia,a.GiaThanhLy,a.MoTa,a.MauSac,a.HienTrang,a.NhangHieu,a.QuaHan,a.DaChuoc,a.ThanhLy,a.DaThanhLy from SanPham a , LoaiSP b where a.MaLoai = b.MaLoai and  a.ThanhLy  LIKE 1 or a.DaThanhLy LIKE 1 or a.QuaHan like 1 or a.DaChuoc Like 1

select a.MaHoaDonCam , b.TenKH , a.NgayLap , a.NgayHetHan ,a.TongTienCam
from HoaDonCam a , KhachHang b
where a.MaKH = b.MaKH
select c.MaHoaDonCam, a.MaSP,b.TenLoai,a.TenSP,a.DinhGia,a.GiaThanhLy,a.MoTa,a.MauSac,a.HienTrang,a.NhangHieu,a.QuaHan,a.DaChuoc,a.ThanhLy,a.DaThanhLy from SanPham a , LoaiSP b , ChiTiet_HoaDonCam c, HoaDonCam d where a.MaLoai = b.MaLoai and a.MaSP = c.MaSP and c.MaHoaDonCam = d.MaHoaDonCam


