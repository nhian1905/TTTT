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
	NgayLap date ,
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
	NgayLap date ,
	NgayHetHan date ,
	NgayDongLai date ,
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
	NgayDongLai date,
	ThanhTien float
	foreign key(MaHoaDonCam) references HoaDonCam(MaHoaDonCam),
)
create table PhieuChuoc
(
	MaPhieuChuoc int identity(1,1) primary key,
	MaHoaDonCam int not null ,
	NgayChuoc date,
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

create table Tien
(
	ID int primary key,
	TongTien float,
	DoanhThuThang float,
	TongDoanhThu float
)
ALTER TABLE LoaiSP
ALTER COLUMN LaiXuat float

insert into Tien values(1,1000000000,50000000,600000000)
insert into PhieuChuoc values(1,'05/19/2020',0)
insert into ChiTiet_PhieuChuoc values(1,'IP01',0,0)
insert into PhieuChuoc values(2,'05/19/2020',0)
insert into ChiTiet_PhieuChuoc values(2,'IP02',0,0)

insert into Quyen values ('admin')
insert into TaiKhoan values ('admin',123,1)

insert into KhachHang values(N'Trần Nhị Ân',0919059069,381909647,'05/19/2020',N'Cà Mau','05/19/2020','1')
insert into KhachHang values(N'Nguyễn Chí Đang',0835629645,381000111,'05/19/2020',N'Cà Mau','05/19/2020','1')
insert into KhachHang values(N'Trần Nhất Phương',0947366755,381222333,'05/19/2020',N'Cà Mau','05/19/2020','1')
insert into KhachHang values(N'Lý Tấn Ngọc',0919599595,381987345,'05/19/2020',N'Cần Thơ','05/19/2020','1')

insert into LoaiSP values (N'DT',5)
insert into LoaiSP values (N'MT',3)

insert into SanPham values ('IMEI1602',N'IPHONE 12',1602,0,1,N'ĐIỆN THOẠI CẦM TAY',N'Màu đỏ',N'có trầy ở lưng',N'IPHONE',0,0,0,0)
insert into SanPham values ('IMEI111',N'SAMSUNG A12',1111,0,1,N'ĐIỆN THOẠI CẦM TAY',N'Màu Hồng',N'có trầy viền',N' SAMSUNG',0,0,0,0)
insert into SanPham values ('IMEI1789',N'OPPO A95',1789,0,1,N'ĐIỆN THOẠI CẦM TAY',N'Màu Xanh',N'100%',N' OPPO',0,0,0,0)
insert into SanPham values ('IMEI1666',N'OPPO FIND X',1666,0,1,N'ĐIỆN THOẠI CẦM TAY',N'Màu Tím',N'100%',N' OPPO',0,0,0,0)
insert into SanPham values ('IMEI1323',N'IPHONE X',1323,0,1,N'ĐIỆN THOẠI CẦM TAY',N'Màu Vàng',N'có trầy ở kính',N' IPHONE',0,0,0,0)




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

 @NgayHienTai date , @MaHDC int

as
	begin
		declare @SoNgayDaCam int 
		 select @SoNgayDaCam =  DATEDIFF(day,NgayDongLai,@NgayHienTai) from HoaDonCam  where  MaHoaDonCam = @MaHDC
		 select  @SoNgayDaCam * (c.LaiXuat * b.DinhGia) / 100 from ChiTiet_HoaDonCam a, SanPham b , LoaiSP c ,HoaDonCam d where a.MaSP =b.MaSP and b.MaLoai = c.MaLoai and a.MaHoaDonCam = d.MaHoaDonCam  and b.DaChuoc = 0 and b.DaThanhLy= 0 and b.QuaHan = 0 and b.ThanhLy = 0 and d.MaHoaDonCam = @MaHDC
	end
go


create proc USP_UpdateNgayDongLaiHDC
@MaHDC int

as
	begin
		declare @NgayDongLai date
		select @NgayDongLai = NgayDongLai from PhieuLai where MaHoaDonCam = @MaHDC
		update HoaDonCam set NgayDongLai = @NgayDongLai where MaHoaDonCam = @MaHDC
	end
go


create proc USP_UpdateQuaHan
@NHT Date
as
	begin
		declare @NgayHetHan Date
		select @NgayHetHan = NgayHetHan from HoaDonCam 
		if @NHT > @NgayHetHan
			update SanPham set QuaHan = 1 from HoaDonCam a , SanPham b , ChiTiet_HoaDonCam c where a.MaHoaDonCam = c.MaHoaDonCam and b.MaSP = c.MaSP and b.DaChuoc = 0 and b.ThanhLy = 0 and b.DaThanhLy = 0
	end
go

create proc USP_TimHoaDonCamByDate
@datein date , @dateout date
as
begin
	select  a.MaHoaDonCam,b.TenKH,a.NgayLap,a.NgayHetHan,a.TongTienCam
	from KhachHang b,HoaDonCam a
	where  a.MaKH=b.MaKH and  a.NgayLap between @datein and @dateout
end
go

create proc USP_TimHoaDonChuocByDate
@datein date , @dateout date
as
begin
	select  a.MaPhieuChuoc , b.MaHoaDonCam , a.NgayChuoc, a.TongTien
	from PhieuChuoc a,HoaDonCam b
	where  a.MaHoaDonCam=b.MaHoaDonCam and  b.NgayLap >= @datein and a.NgayChuoc<= @dateout
end
go

create proc USP_TimHoaDonTLByDate
@datein date , @dateout date
as
begin
	select  a.MaThanhLy , b.TenKH , a.NgayLap,a.TongTienThanhLy
	from ThanhLy a,KhachHang b
	where  a.MaKH=b.MaKH and  a.NgayLap between @datein and @dateout
end
go


create proc USP_InHoaDonPhieuCam
 @MaHDC int
 as
 begin

	 select a.MaHoaDonCam, c.TenKH ,c.DiaChi,c.SDT,c.CMND,c.NgayCapCMND, a.NgayLap , a.NgayHetHan , d.TenSP, d.DinhGia,e.LaiXuat,d.MauSac,d.HienTrang, a.TongTienCam
	from HoaDonCam a , ChiTiet_HoaDonCam b , KhachHang c  , SanPham d , LoaiSP e
	where a.MaHoaDonCam = b.MaHoaDonCam and d.MaSP = b.MaSP and d.MaLoai = e.MaLoai and a.MaKH = c.MaKH and a.MaHoaDonCam = @MaHDC AND B.MaHoaDonCam = @MaHDC
 end
 go


create proc USP_InHoaDonPhieuChuoc
 @MaPC int
 as
 begin

	 select a.MaPhieuChuoc , c.MaHoaDonCam, f.TenKH , f.SDT,f.CMND,f.DiaChi,c.NgayLap ,a.NgayChuoc,d.MaSP,e.TenLoai,d.TenSP,d.DinhGia,e.LaiXuat,b.TienLai,b.TongTien as ThanhTien,a.TongTien
	from PhieuChuoc a , ChiTiet_PhieuChuoc b , HoaDonCam c , SanPham d , LoaiSP e , KhachHang f
	where a.MaHoaDonCam = c.MaHoaDonCam and b.MaSP = d.MaSP and b.MaPhieuChuoc = a.MaPhieuChuoc and d.MaLoai = e.MaLoai and c.MaKH = f.MaKH and a.MaPhieuChuoc = @MaPC
 end
 go

create proc USP_InHoaDonPhieuTL
 @MaTL int
 as
 begin

	 select a.MaThanhLy ,  f.TenKH , f.SDT,f.CMND,f.DiaChi,a.NgayLap ,d.MaSP,e.TenLoai,d.TenSP,d.GiaThanhLy,a.TongTienThanhLy
	from ThanhLy a , ChiTiet_ThanhLy b  , SanPham d , LoaiSP e , KhachHang f
	where a.MaThanhLy = b.MaThanhLy and b.MaSP = d.MaSP and d.MaLoai = e.MaLoai and a.MaKH = f.MaKH and a.MaThanhLy=@MaTL
 end
 go


 create proc USP_InHoaDonPhieuDL
 @MaPL int
 as
 begin

	 select a.MaPhieuLai, b.MaHoaDonCam , c.TenKH, c.SDT,c.CMND,c.DiaChi,b.NgayLap,a.NgayDongLai,a.ThanhTien,b.TongTienCam
	from PhieuLai a,HoaDonCam b, KhachHang c
	where a.MaHoaDonCam = b.MaHoaDonCam and b.MaKH = c.MaKH and a.MaPhieuLai = @MaPL
 end
 go





 /*ThongKeLai*/
create proc USP_DongLai
as
	begin
		declare @TienPhieuLai float
		declare @TienPhieuChuoc float
		select @TienPhieuLai = SUM(ThanhTien) from PhieuLai 
		select @TienPhieuChuoc = SUM(TienLai) from ChiTiet_PhieuChuoc 
		select @TienPhieuLai+@TienPhieuChuoc
	end
go
exec USP_DongLai

/*DoanhThu*/
create proc USP_DoanhThuThang
 @Thang int
as
	begin
		declare @TienPhieuLai float
		declare @TienThanhLy float
		declare @TienLaiChuoc float
		select @TienPhieuLai = SUM(ThanhTien) from PhieuLai where MONTH(NgayDongLai)=@Thang
		select @TienLaiChuoc = SUM(a.TienLai) from ChiTiet_PhieuChuoc a,SanPham b,PhieuChuoc c where a.MaSP=b.MaSP and MONTH(c.NgayChuoc)=@Thang and a.MaPhieuChuoc=c.MaPhieuChuoc
		select @TienThanhLy = SUM(b.GiaThanhLy-b.DinhGia) from ChiTiet_ThanhLy a,SanPham b,ThanhLy c where a.MaSP=b.MaSP and MONTH(c.NgayLap)=@Thang and a.MaThanhLy=c.MaThanhLy
		select @TienPhieuLai+@TienLaiChuoc+@TienThanhLy
	end
go
exec USP_DoanhThuThang 5
select  SUM(ThanhTien) from PhieuLai where MONTH(NgayDongLai)=4
select SUM(a.TienLai) from ChiTiet_PhieuChuoc a,SanPham b,PhieuChuoc c where a.MaSP=b.MaSP and MONTH(c.NgayChuoc)=4 and a.MaPhieuChuoc=c.MaPhieuChuoc
select SUM(b.GiaThanhLy-b.DinhGia)+SUM(d.ThanhTien) from ChiTiet_ThanhLy a,SanPham b,ThanhLy c, PhieuLai d where a.MaSP=b.MaSP and MONTH(c.NgayLap)=4 and a.MaThanhLy=c.MaThanhLy and MONTH(d.NgayDongLai)=4
--create proc USP_DoanhThuThang123
--@Thang int
--as
--	begin
--		declare @TienPhieuLai float
--		declare @TienThanhLy float
--		declare @TienLaiChuoc float
--		select @TienPhieuLai = SUM(ThanhTien) from PhieuLai where MONTH(NgayDongLai)=@Thang
--		select @TienLaiChuoc = SUM(a.TienLai) from ChiTiet_PhieuChuoc a,SanPham b,PhieuChuoc c where a.MaSP=b.MaSP and MONTH(c.NgayChuoc)=@Thang and a.MaPhieuChuoc=c.MaPhieuChuoc
--		select @TienThanhLy = SUM(b.GiaThanhLy-b.DinhGia) from ChiTiet_ThanhLy a,SanPham b,ThanhLy c where a.MaSP=b.MaSP and MONTH(c.NgayLap)=@Thang and a.MaThanhLy=c.MaThanhLy
--		if @TienPhieuLai = ''
--			select @TienLaiChuoc+@TienThanhLy
--		else if @TienLaiChuoc = ''
--			select @TienPhieuLai+@TienThanhLy
--		else if @TienThanhLy = ''
--			select @TienPhieuLai+@TienLaiChuoc
--		else if @TienThanhLy = '' and @TienLaiChuoc=''
--			select @TienPhieuLai
--		else if @TienThanhLy = '' and  @TienPhieuLai=''
--			select @TienLaiChuoc
--		else if @TienLaiChuoc = '' and  @TienPhieuLai=''
--			select @TienThanhLy
--		else if @TienLaiChuoc = '' and  @TienPhieuLai='' and @TienThanhLy=''
--			select '0'
--		else 
--			select @TienPhieuLai+@TienLaiChuoc+@TienThanhLy
--	end
--go
--exec USP_DoanhThuThang123 4


exec USP_DoanhThuThang 9

select  a.MaThanhLy , b.TenKH , a.NgayLap,a.TongTienThanhLy
	from ThanhLy a,KhachHang b
	where  a.MaKH=b.MaKH and  MONTH(a.NgayLap)=5



select sum(MaThanhLy) from ChiTiet_ThanhLy
select SUM(a.GiaThanhLy-a.DinhGia) from ChiTiet_ThanhLy b,SanPham a where b.MaSP=a.MaSP

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
from ChiTiet_HoaDonCam a,SanPham b, LoaiSP c, KhachHang d, HoaDonCam e 
where b.MaLoai = c.MaLoai and a.MaHoaDonCam = e.MaHoaDonCam and a.MaSP = b.MaSP and e.MaKH = d.MaKH

select  e.MaHoaDonCam,d.TenKH,e.NgayLap,e.NgayHetHan,b.MaSP,c.TenLoai,b.TenSP,b.DinhGia,b.MoTa,b.MauSac,b.HienTrang 
from ChiTiet_HoaDonCam a,SanPham b, LoaiSP c, KhachHang d, HoaDonCam e 
where b.MaLoai = c.MaLoai and a.MaHoaDonCam = e.MaHoaDonCam and a.MaSP = b.MaSP and e.MaKH = d.MaKH and e.NgayLap>= '5/2/2022' and e.NgayLap <='5/10/2022'



/*BaoCaoLai*/
select  c.MaPhieuLai,a.MaHoaDonCam,b.TenKH,b.SDT,b.CMND,c.NgayDongLai,c.ThanhTien from HoaDonCam a,KhachHang b, PhieuLai c  where c.MaHoaDonCam = a.MaHoaDonCam and b.MaKH = a.MaKH

select  c.MaPhieuLai,a.MaHoaDonCam,b.TenKH,b.SDT,b.CMND,c.NgayDongLai,c.ThanhTien 
from HoaDonCam a,KhachHang b, PhieuLai c  
where c.MaHoaDonCam = a.MaHoaDonCam and b.MaKH = a.MaKH and c.NgayDongLai>='5/2/2022' and c.NgayDongLai <='5/10/2022'



/*BaoCaoThanhLy*/
select  a.MaThanhLy,b.TenKH,b.SDT,b.CMND,a.NgayLap,d.MaSP,e.TenLoai,d.TenSP,d.GiaThanhLy,d.MoTa,d.NhangHieu,d.MauSac,d.HienTrang
from ThanhLy a,KhachHang b, ChiTiet_ThanhLy c ,SanPham d,LoaiSP e
where a.MaThanhLy=c.MaThanhLy and a.MaKH=b.MaKH and c.MaSP=d.MaSP and d.MaLoai=e.MaLoai and a.NgayLap >=N'{0}' and a.NgayLap <=N'{1}'

/*BaoCaoChuoc*/
select  a.MaPhieuChuoc,f.MaHoaDonCam,b.TenKH,b.SDT,b.CMND,a.NgayChuoc,d.MaSP,e.TenLoai,d.TenSP,d.DinhGia,d.MoTa,d.NhangHieu,d.MauSac,d.HienTrang,c.TienLai,c.TongTien
from PhieuChuoc a, KhachHang b, ChiTiet_PhieuChuoc c ,SanPham d,LoaiSP e,HoaDonCam f
where a.MaHoaDonCam=f.MaHoaDonCam and f.MaKH=b.MaKH and c.MaSP=d.MaSP and d.MaLoai=e.MaLoai and a.MaPhieuChuoc=c.MaPhieuChuoc

select  a.MaPhieuChuoc,f.MaHoaDonCam,b.TenKH,b.SDT,b.CMND,a.NgayChuoc,d.MaSP,e.TenLoai,d.TenSP,d.DinhGia,d.MoTa,d.NhangHieu,d.MauSac,d.HienTrang,c.TienLai,c.TongTien from PhieuChuoc a, KhachHang b, ChiTiet_PhieuChuoc c ,SanPham d, LoaiSP e,HoaDonCam f where a.MaHoaDonCam = f.MaHoaDonCam and f.MaKH = b.MaKH and c.MaSP = d.MaSP and d.MaLoai = e.MaLoai and a.MaPhieuChuoc = c.MaPhieuChuoc and a.NgayChuoc >=N'{0}' and a.NgayChuoc <=N'{1}'

