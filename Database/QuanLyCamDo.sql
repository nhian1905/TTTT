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
	LaiXuat float not null
)

create table SanPham
(
	ID_SP nvarchar(50) null,
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

insert into Quyen values ('admin')
insert into TaiKhoan values ('admin',123,1)

insert into KhachHang values(N'Trần Nhị Ân',0919059069,381909647,'05/19/2020',N'Cà Mau','05/19/2020','1')
insert into KhachHang values(N'Nguyễn Chí Đang',0835629645,381000111,'05/19/2020',N'Cà Mau','05/19/2020','1')
insert into KhachHang values(N'Trần Nhất Phương',0947366755,381222333,'05/19/2020',N'Cà Mau','05/19/2020','1')
insert into KhachHang values(N'Lý Tấn Ngọc',0919599595,381987345,'05/19/2020',N'Cần Thơ','05/19/2020','1')

insert into LoaiSP values (N'Điện Thoại',5)
insert into LoaiSP values (N'Máy Tính',3)
insert into LoaiSP values (N'Xe Máy',0.6)

insert into SanPham values ('DT01','IMEI1602',N'IPHONE 12',1602,0,1,N'ĐIỆN THOẠI CẦM TAY',N'Màu đỏ',N'có trầy ở lưng',N'IPHONE',0,0,0,0)
insert into SanPham values ('DT02','IMEI111',N'SAMSUNG A12',1111,0,1,N'ĐIỆN THOẠI CẦM TAY',N'Màu Hồng',N'có trầy viền',N' SAMSUNG',0,0,0,0)
insert into SanPham values ('DT03','IMEI1789',N'OPPO A95',1789,0,1,N'ĐIỆN THOẠI CẦM TAY',N'Màu Xanh',N'100%',N' OPPO',0,0,0,0)
insert into SanPham values ('DT04','IMEI1666',N'OPPO FIND X',1666,0,1,N'ĐIỆN THOẠI CẦM TAY',N'Màu Tím',N'100%',N' OPPO',0,0,0,0)
insert into SanPham values ('DT05','IMEI1323',N'IPHONE X',1323,0,1,N'ĐIỆN THOẠI CẦM TAY',N'Màu Vàng',N'có trầy ở kính',N' IPHONE',0,0,0,0)

insert into HoaDonCam values (1,'2022-04-16','2022-05-16','2022-04-16','0')
insert into HoaDonCam values (2,'2022-04-16','2022-05-16','2022-04-16','0')
insert into ChiTiet_HoaDonCam values(1,'IMEI1602')
insert into ChiTiet_HoaDonCam values(1,'IMEI111')

insert into PhieuChuoc values(1,'05/19/2020',0)
insert into PhieuChuoc values(2,'05/19/2020',0)
insert into ChiTiet_PhieuChuoc values(1,'IMEI1602',0,0)
insert into ChiTiet_PhieuChuoc values(2,'IMEI111',0,0)

insert into PhieuLai values(1,'2022-04-16',1111)
insert into PhieuLai values(2,'2022-04-16',2222)


insert into ThanhLy values(1,'2022-05-17',0)
insert into ChiTiet_ThanhLy values(1,'IMEI1789')

insert into Tien values(1,1000000000,50000000,600000000)
go
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
/*ThongKeLaiTheoNgay*/
create proc USP_DongLaiTheoNgay
@NgayDau date,
@NgayCuoi date
as
	begin
		declare @TienPhieuLai float
		declare @TienPhieuChuoc float
		select @TienPhieuLai = SUM(ThanhTien) from PhieuLai where PhieuLai.NgayDongLai>=@NgayDau and PhieuLai.NgayDongLai<=@NgayCuoi
		select @TienPhieuChuoc = SUM(b.TienLai) from PhieuChuoc a,ChiTiet_PhieuChuoc b where a.MaPhieuChuoc=b.MaPhieuChuoc and a.NgayChuoc between @NgayDau and @NgayCuoi
		select @TienPhieuLai+@TienPhieuChuoc
	end
go


select a.ID_SP,a.MaSP,a.TenSP,b.TenLoai,a.DinhGia,a.MauSac,a.MoTa,a.NhangHieu,a.HienTrang from SanPham a,LoaiSP b where a.MaLoai=b.MaLoai and a.DaChuoc=1

exec USP_DongLaiTheoNgay N'4/1/2022',N'6/30/2022' 