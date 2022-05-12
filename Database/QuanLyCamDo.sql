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
	NgayDongLai datetime ,
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

insert into ChiTiet_PhieuChuoc values(4,'NhiAn',4000,7000)


create proc USP_UpdateTienPhieuChuoc
@MaPC int
as
	begin
		declare @TT float
		SELECT @TT = ISNULL(SUM(TongTien),0) FROM ChiTiet_PhieuChuoc WHERE MaPhieuChuoc = @MaPC
		update PhieuChuoc set TongTien = @TT where MaPhieuChuoc = @MaPC
	end
go


select a.MaSP,b.TenLoai,a.TenSP,a.DinhGia,a.GiaThanhLy,a.MoTa,a.MauSac,a.HienTrang,a.NhangHieu,a.QuaHan,a.DaChuoc,a.ThanhLy,a.DaThanhLy from SanPham a , LoaiSP b where a.MaLoai = b.MaLoai and  a.ThanhLy  LIKE 1 or a.DaThanhLy LIKE 1 or a.QuaHan like 1 or a.DaChuoc Like 1


select MaPhieuChuoc
from PhieuChuoc
where MaHoaDonCam = 4 and NgayChuoc = '2022-05-11 00:00:00.000'


select ChiTiet_HoaDonCam.MaSP,SanPham.MaLoai,LoaiSP.LaiXuat,SanPham.DinhGia
from ChiTiet_HoaDonCam, SanPham,LoaiSP,HoaDonCam
where ChiTiet_HoaDonCam.MaSP=SanPham.MaSP and SanPham.MaLoai=LoaiSP.MaLoai and HoaDonCam.MaHoaDonCam=3



SELECT DATEDIFF(day,HoaDonCam.NgayLap , HoaDonCam.NgayHetHan)*LoaiSP.LaiXuat*SanPham.DinhGia from HoaDonCam,SanPham,LoaiSP where MaHoaDonCam=3 and LoaiSP.MaLoai=LoaiSP.MaLoai 

SELECT DATEDIFF(day,HoaDonCam.NgayLap , HoaDonCam.NgayHetHan)from HoaDonCam where MaHoaDonCam=3 
select NgayHetHan-NgayLap as Ngay from HoaDonCam where MaHoaDonCam=1

select LoaiSP.LaiXuat*SanPham.DinhGia from ChiTiet_HoaDonCam, SanPham, LoaiSP, HoaDonCam 
where ChiTiet_HoaDonCam.MaSP = SanPham.MaSP and SanPham.MaLoai = LoaiSP.MaLoai and HoaDonCam.MaHoaDonCam = 3 and ChiTiet_HoaDonCam.MaHoaDonCam=HoaDonCam.MaHoaDonCam

select a.MaSP,b.TenLoai,a.TenSP,a.DinhGia,a.GiaThanhLy,a.MoTa,a.MauSac,a.HienTrang,a.NhangHieu,a.QuaHan,a.DaChuoc,a.ThanhLy,a.DaThanhLy from SanPham a , LoaiSP b where a.MaLoai = b.MaLoai and  a.ThanhLy  LIKE 1
SELECT DATEDIFF(day,HoaDonCam.NgayLap , HoaDonCam.NgayHetHan)from HoaDonCam where MaHoaDonCam=3
select c.MaPhieuChuoc, a.MaSP,a.TenSP,a.GiaThanhLy,b.LaiXuat, a.DaThanhLy * b.LaiXuat as TienLai ,a.MoTa,a.MauSac,a.HienTrang, a.NhangHieu, c.TongTien from SanPham a  , LoaiSP b, ChiTiet_PhieuChuoc c, PhieuChuoc d where   a.MaSP = c.MaSP and c.MaPhieuChuoc = d.MaPhieuChuoc and a.MaLoai = b.MaLoai