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

insert into PhieuChuoc values(1,'05/19/2020',0)
insert into ChiTiet_PhieuChuoc values(1,'IP01',0,0)
insert into PhieuChuoc values(2,'05/19/2020',0)
insert into ChiTiet_PhieuChuoc values(2,'IP02',0,0)

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




create proc USP_UpdateTienPhieuChuoc
@MaPC int
as
	begin
		declare @TT float
		SELECT @TT = ISNULL(SUM(TongTien),0) FROM ChiTiet_PhieuChuoc WHERE MaPhieuChuoc = @MaPC
		update PhieuChuoc set TongTien = @TT where MaPhieuChuoc = @MaPC
	end
go


create proc USP_UpdateTongTienHDC
@Id_HDC int
as
	begin
		declare @TT float
		SELECT @TT = ISNULL(SUM(b.DinhGia),0) FROM ChiTiet_HoaDonCam a , SanPham b  WHERE a.MaSP = b.MaSP and a.MaHoaDonCam = @Id_HDC 
		update HoaDonCam set TongTienCam = @TT where MaHoaDonCam = @ID_HDC
	end
GO



create proc USP_UpdateTongTienThanHLy
@MaThanhLy int
as
	begin
		declare @TT float
		SELECT @TT = ISNULL(SUM(GiaThanhLy),0) FROM ChiTiet_ThanhLy a , SanPham b  WHERE a.MaSP = b.MaSP and MaThanhLy = @MaThanhLy 
		update ThanhLy set TongTienThanhLy = @TT where MaThanhLy = @MaThanhLy
	end
GO


create proc USP_TinhTienLai

 @NgayHienTai Datetime , @MaHDC int

as
	begin
		declare @SoNgayDaCam int 
		 select @SoNgayDaCam =  DATEDIFF(day,a.NgayDongLai,@NgayHienTai) from HoaDonCam a 
			where  a.MaHoaDonCam = @MaHDC
		 select  @SoNgayDaCam * (c.LaiXuat * b.DinhGia) / 100 from ChiTiet_HoaDonCam a, SanPham b , LoaiSP c ,HoaDonCam d 
			where a.MaSP =b.MaSP and b.MaLoai = c.MaLoai and a.MaHoaDonCam = d.MaHoaDonCam and d.MaHoaDonCam = @MaHDC and b.DaChuoc = 0 and b.DaThanhLy= 0 and b.QuaHan = 0 and b.ThanhLy = 0
	end
go

exec USP_TinhTienLai '2022-5-12',1


create proc USP_UpdateNgayDongLaiHDC
@MaHDC int

as
	begin
		declare @NgayDongLai date
		select @NgayDongLai = NgayDongLai from PhieuLai where MaHoaDonCam = @MaHDC
		update HoaDonCam set NgayDongLai = @NgayDongLai where MaHoaDonCam = @MaHDC
	end
go



select a.MaSP,b.TenLoai,a.TenSP,a.DinhGia,a.GiaThanhLy,a.MoTa,a.MauSac,a.HienTrang,a.NhangHieu,a.QuaHan,a.DaChuoc,a.ThanhLy,a.DaThanhLy from SanPham a , LoaiSP b where a.MaLoai = b.MaLoai and  a.ThanhLy  LIKE 1 or a.DaThanhLy LIKE 1 or a.QuaHan like 1 or a.DaChuoc Like 1


select MaPhieuChuoc
from PhieuChuoc
where MaHoaDonCam = 4 and NgayChuoc = '2022-05-11 00:00:00.000'


select ChiTiet_HoaDonCam.MaSP,SanPham.MaLoai,LoaiSP.LaiXuat,SanPham.DinhGia
from ChiTiet_HoaDonCam, SanPham,LoaiSP,HoaDonCam
where ChiTiet_HoaDonCam.MaSP=SanPham.MaSP and SanPham.MaLoai=LoaiSP.MaLoai and HoaDonCam.MaHoaDonCam=3

SELECT DATEDIFF(day,CONVERT(date, NgayDongLai,  103) , CONVERT(date, NgayDongLai,  103)) from HoaDonCam where HoaDonCam.MaHoaDonCam=3
select GETDATE()
select CONVERT(date, NgayHetHan,103)from HoaDonCam where MaHoaDonCam=3
Select DATEDIFF(day,HoaDonCam.NgayDongLai,GETDATE()) from HoaDonCam where MaHoaDonCam=3
SELECT HoaDonCam.NgayHetHan from HoaDonCam where MaHoaDonCam=3
SELECT DATEDIFF(day,HoaDonCam.NgayLap , HoaDonCam.NgayHetHan)*LoaiSP.LaiXuat*SanPham.DinhGia from HoaDonCam,SanPham,LoaiSP where MaHoaDonCam=3 and LoaiSP.MaLoai=LoaiSP.MaLoai 
SELECT DATEDIFF(day,CONVERT(date, HoaDonCam.NgayDongLai,  103) , CONVERT(date, GETDATE(),  103)) from HoaDonCam where HoaDonCam.MaHoaDonCam=3
SELECT DATEDIFF(day,03/09/2008 , 03/011/2008 )

select LoaiSP.LaiXuat*SanPham.DinhGia from ChiTiet_HoaDonCam, SanPham, LoaiSP, HoaDonCam 
where ChiTiet_HoaDonCam.MaSP = SanPham.MaSP and SanPham.MaLoai = LoaiSP.MaLoai and HoaDonCam.MaHoaDonCam = 3 and ChiTiet_HoaDonCam.MaHoaDonCam=HoaDonCam.MaHoaDonCam 
and SanPham.ThanhLy=0 and SanPham.DaThanhLy=0 and SanPham.DaChuoc=0 and SanPham.QuaHan=0 and SanPham.MaSP=7

select a.MaSP,b.TenLoai,a.TenSP,a.DinhGia,a.GiaThanhLy,a.MoTa,a.MauSac,a.HienTrang,a.NhangHieu,a.QuaHan,a.DaChuoc,a.ThanhLy,a.DaThanhLy from SanPham a , LoaiSP b where a.MaLoai = b.MaLoai and  a.ThanhLy  LIKE 1
SELECT DATEDIFF(day,HoaDonCam.NgayLap , HoaDonCam.NgayHetHan)from HoaDonCam where MaHoaDonCam=3
select c.MaPhieuChuoc, a.MaSP,a.TenSP,a.GiaThanhLy,b.LaiXuat, a.DaThanhLy * b.LaiXuat as TienLai ,a.MoTa,a.MauSac,a.HienTrang, a.NhangHieu, c.TongTien from SanPham a  , LoaiSP b, ChiTiet_PhieuChuoc c, PhieuChuoc d where   a.MaSP = c.MaSP and c.MaPhieuChuoc = d.MaPhieuChuoc and a.MaLoai = b.MaLoai


/*BaoCaoCam*/
select  e.MaHoaDonCam,d.TenKH,e.NgayLap,e.NgayHetHan,b.MaSP,c.TenLoai,b.TenSP,b.DinhGia,b.MoTa,b.MauSac,b.HienTrang  
from ChiTiet_HoaDonCam a,SanPham b,LoaiSP c, KhachHang d,HoaDonCam e
where b.MaLoai=c.MaLoai and a.MaHoaDonCam=e.MaHoaDonCam and a.MaSP=b.MaSP and e.MaKH=d.MaKH and b.DaChuoc=0 and b.DaThanhLy=0 and b.QuaHan=0 and b.ThanhLy=0


/*BaoCaoLai*/
select  c.MaPhieuLai,a.MaHoaDonCam,b.TenKH,b.SDT,b.CMND,c.NgayDongLai,c.ThanhTien from HoaDonCam a,KhachHang b, PhieuLai c  where c.MaHoaDonCam = a.MaHoaDonCam and b.MaKH = a.MaKH
/*BaoCaoThanhLy*/
select  a.MaThanhLy,b.TenKH,b.SDT,b.CMND,a.NgayLap,d.MaSP,e.TenLoai,d.TenSP,d.GiaThanhLy,d.MoTa,d.NhangHieu,d.MauSac,d.HienTrang
from ThanhLy a,KhachHang b, ChiTiet_ThanhLy c ,SanPham d,LoaiSP e
where a.MaThanhLy=c.MaThanhLy and a.MaKH=b.MaKH and c.MaSP=d.MaSP and d.MaLoai=e.MaLoai

/*BaoCaoLai*/



