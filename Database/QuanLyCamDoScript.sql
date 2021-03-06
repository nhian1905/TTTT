USE [master]
GO
/****** Object:  Database [QuanLyCamDo]    Script Date: 6/13/2022 2:39:14 PM ******/
CREATE DATABASE [QuanLyCamDo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyCamDo', FILENAME = N'D:\SQL 2012\MSSQL11.SQLEXPRESS\MSSQL\DATA\QuanLyCamDo.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QuanLyCamDo_log', FILENAME = N'D:\SQL 2012\MSSQL11.SQLEXPRESS\MSSQL\DATA\QuanLyCamDo_log.ldf' , SIZE = 784KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QuanLyCamDo] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyCamDo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyCamDo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyCamDo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyCamDo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyCamDo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyCamDo] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyCamDo] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QuanLyCamDo] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyCamDo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyCamDo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyCamDo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyCamDo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyCamDo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyCamDo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyCamDo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyCamDo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyCamDo] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyCamDo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyCamDo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyCamDo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyCamDo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyCamDo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyCamDo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyCamDo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyCamDo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyCamDo] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyCamDo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyCamDo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyCamDo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyCamDo] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QuanLyCamDo]
GO
/****** Object:  StoredProcedure [dbo].[USP_DoanhThuThang]    Script Date: 6/13/2022 2:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*DoanhThu*/
create proc [dbo].[USP_DoanhThuThang]
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

GO
/****** Object:  StoredProcedure [dbo].[USP_DongLai]    Script Date: 6/13/2022 2:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


 /*ThongKeLai*/
create proc [dbo].[USP_DongLai]
as
	begin
		declare @TienPhieuLai float
		declare @TienPhieuChuoc float
		select @TienPhieuLai = SUM(ThanhTien) from PhieuLai 
		select @TienPhieuChuoc = SUM(TienLai) from ChiTiet_PhieuChuoc 
		select @TienPhieuLai+@TienPhieuChuoc
	end

GO
/****** Object:  StoredProcedure [dbo].[USP_DongLaiTheoNgay]    Script Date: 6/13/2022 2:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*ThongKeLaiTheoNgay*/
create proc [dbo].[USP_DongLaiTheoNgay]
@NgayDau date,
@NgayCuoi date
as
	begin
		declare @TienPhieuLai float
		declare @TienPhieuChuoc float
		select @TienPhieuLai = SUM(ThanhTien) from PhieuLai where PhieuLai.NgayDongLai between @NgayDau and @NgayCuoi
		select @TienPhieuChuoc = SUM(b.TienLai) from PhieuChuoc a,ChiTiet_PhieuChuoc b where a.MaPhieuChuoc=b.MaPhieuChuoc and a.NgayChuoc between @NgayDau and @NgayCuoi
		select @TienPhieuLai+@TienPhieuChuoc
	end

GO
/****** Object:  StoredProcedure [dbo].[USP_InHoaDonPhieuCam]    Script Date: 6/13/2022 2:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[USP_InHoaDonPhieuCam]
 @MaHDC int
 as
 begin

	 select a.MaHoaDonCam, c.TenKH ,c.DiaChi,c.SDT,c.CMND,c.NgayCapCMND, a.NgayLap , a.NgayHetHan , d.TenSP, d.DinhGia,e.LaiXuat,d.MauSac,d.HienTrang, a.TongTienCam
	from HoaDonCam a , ChiTiet_HoaDonCam b , KhachHang c  , SanPham d , LoaiSP e
	where a.MaHoaDonCam = b.MaHoaDonCam and d.MaSP = b.MaSP and d.MaLoai = e.MaLoai and a.MaKH = c.MaKH and a.MaHoaDonCam = @MaHDC AND B.MaHoaDonCam = @MaHDC
 end

GO
/****** Object:  StoredProcedure [dbo].[USP_InHoaDonPhieuChuoc]    Script Date: 6/13/2022 2:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[USP_InHoaDonPhieuChuoc]
 @MaPC int
 as
 begin

	 select a.MaPhieuChuoc , c.MaHoaDonCam, f.TenKH , f.SDT,f.CMND,f.DiaChi,c.NgayLap ,a.NgayChuoc,d.MaSP,e.TenLoai,d.TenSP,d.DinhGia,e.LaiXuat,b.TienLai,b.TongTien as ThanhTien,a.TongTien
	from PhieuChuoc a , ChiTiet_PhieuChuoc b , HoaDonCam c , SanPham d , LoaiSP e , KhachHang f
	where a.MaHoaDonCam = c.MaHoaDonCam and b.MaSP = d.MaSP and b.MaPhieuChuoc = a.MaPhieuChuoc and d.MaLoai = e.MaLoai and c.MaKH = f.MaKH and a.MaPhieuChuoc = @MaPC
 end

GO
/****** Object:  StoredProcedure [dbo].[USP_InHoaDonPhieuDL]    Script Date: 6/13/2022 2:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


 create proc [dbo].[USP_InHoaDonPhieuDL]
 @MaPL int
 as
 begin

	 select a.MaPhieuLai, b.MaHoaDonCam , c.TenKH, c.SDT,c.CMND,c.DiaChi,b.NgayLap,a.NgayDongLai,a.ThanhTien,b.TongTienCam
	from PhieuLai a,HoaDonCam b, KhachHang c
	where a.MaHoaDonCam = b.MaHoaDonCam and b.MaKH = c.MaKH and a.MaPhieuLai = @MaPL
 end

GO
/****** Object:  StoredProcedure [dbo].[USP_InHoaDonPhieuTL]    Script Date: 6/13/2022 2:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[USP_InHoaDonPhieuTL]
 @MaTL int
 as
 begin

	 select a.MaThanhLy ,  f.TenKH , f.SDT,f.CMND,f.DiaChi,a.NgayLap ,d.MaSP,e.TenLoai,d.TenSP,d.GiaThanhLy,a.TongTienThanhLy
	from ThanhLy a , ChiTiet_ThanhLy b  , SanPham d , LoaiSP e , KhachHang f
	where a.MaThanhLy = b.MaThanhLy and b.MaSP = d.MaSP and d.MaLoai = e.MaLoai and a.MaKH = f.MaKH and a.MaThanhLy=@MaTL
 end

GO
/****** Object:  StoredProcedure [dbo].[USP_TimHoaDonCamByDate]    Script Date: 6/13/2022 2:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[USP_TimHoaDonCamByDate]
@datein date , @dateout date
as
begin
	select  a.MaHoaDonCam,b.TenKH,a.NgayLap,a.NgayHetHan,a.TongTienCam
	from KhachHang b,HoaDonCam a
	where  a.MaKH=b.MaKH and  a.NgayLap between @datein and @dateout
end

GO
/****** Object:  StoredProcedure [dbo].[USP_TimHoaDonChuocByDate]    Script Date: 6/13/2022 2:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[USP_TimHoaDonChuocByDate]
@datein date , @dateout date
as
begin
	select  a.MaPhieuChuoc , b.MaHoaDonCam , a.NgayChuoc, a.TongTien
	from PhieuChuoc a,HoaDonCam b
	where  a.MaHoaDonCam=b.MaHoaDonCam and  b.NgayLap >= @datein and a.NgayChuoc<= @dateout
end

GO
/****** Object:  StoredProcedure [dbo].[USP_TimHoaDonTLByDate]    Script Date: 6/13/2022 2:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[USP_TimHoaDonTLByDate]
@datein date , @dateout date
as
begin
	select  a.MaThanhLy , b.TenKH , a.NgayLap,a.TongTienThanhLy
	from ThanhLy a,KhachHang b
	where  a.MaKH=b.MaKH and  a.NgayLap between @datein and @dateout
end

GO
/****** Object:  StoredProcedure [dbo].[USP_TinhTienLai]    Script Date: 6/13/2022 2:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[USP_TinhTienLai]

 @NgayHienTai date , @MaHDC int

as
	begin
		declare @SoNgayDaCam int 
		 select @SoNgayDaCam =  DATEDIFF(day,NgayDongLai,@NgayHienTai) from HoaDonCam  where  MaHoaDonCam = @MaHDC
		 select  @SoNgayDaCam * (c.LaiXuat * b.DinhGia) / 100 from ChiTiet_HoaDonCam a, SanPham b , LoaiSP c ,HoaDonCam d where a.MaSP =b.MaSP and b.MaLoai = c.MaLoai and a.MaHoaDonCam = d.MaHoaDonCam  and b.DaChuoc = 0 and b.DaThanhLy= 0 and b.QuaHan = 0 and b.ThanhLy = 0 and d.MaHoaDonCam = @MaHDC
	end

GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateNgayDongLaiHDC]    Script Date: 6/13/2022 2:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[USP_UpdateNgayDongLaiHDC]
@MaHDC int

as
	begin
		declare @NgayDongLai date
		select @NgayDongLai = NgayDongLai from PhieuLai where MaHoaDonCam = @MaHDC
		update HoaDonCam set NgayDongLai = @NgayDongLai where MaHoaDonCam = @MaHDC
	end

GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateQuaHan]    Script Date: 6/13/2022 2:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[USP_UpdateQuaHan]
@NHT Date
as
	begin
		declare @NgayHetHan Date
		select @NgayHetHan = NgayHetHan from HoaDonCam 
		if @NHT > @NgayHetHan
			update SanPham set QuaHan = 1 from HoaDonCam a , SanPham b , ChiTiet_HoaDonCam c where a.MaHoaDonCam = c.MaHoaDonCam and b.MaSP = c.MaSP and b.DaChuoc = 0 and b.ThanhLy = 0 and b.DaThanhLy = 0
	end

GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateTienPhieuChuoc]    Script Date: 6/13/2022 2:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_UpdateTienPhieuChuoc]
@MaPC int
as
	begin
		declare @TT float
		SELECT @TT = ISNULL(SUM(TongTien),0) FROM ChiTiet_PhieuChuoc WHERE MaPhieuChuoc = @MaPC
		update PhieuChuoc set TongTien = @TT where MaPhieuChuoc = @MaPC
	end

GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateTongTienHDC]    Script Date: 6/13/2022 2:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[USP_UpdateTongTienHDC]
@Id_HDC int
as
	begin
		declare @TT float
		SELECT @TT = ISNULL(SUM(b.DinhGia),0) FROM ChiTiet_HoaDonCam a , SanPham b  WHERE a.MaSP = b.MaSP and a.MaHoaDonCam = @Id_HDC 
		update HoaDonCam set TongTienCam = @TT where MaHoaDonCam = @ID_HDC
	end

GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateTongTienThanHLy]    Script Date: 6/13/2022 2:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



create proc [dbo].[USP_UpdateTongTienThanHLy]
@MaThanhLy int
as
	begin
		declare @TT float
		SELECT @TT = ISNULL(SUM(GiaThanhLy),0) FROM ChiTiet_ThanhLy a , SanPham b  WHERE a.MaSP = b.MaSP and MaThanhLy = @MaThanhLy 
		update ThanhLy set TongTienThanhLy = @TT where MaThanhLy = @MaThanhLy
	end

GO
/****** Object:  Table [dbo].[ChiTiet_HoaDonCam]    Script Date: 6/13/2022 2:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTiet_HoaDonCam](
	[MaHoaDonCam] [int] NOT NULL,
	[MaSP] [nvarchar](50) NOT NULL,
 CONSTRAINT [pk_CTHDC] PRIMARY KEY CLUSTERED 
(
	[MaHoaDonCam] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTiet_PhieuChuoc]    Script Date: 6/13/2022 2:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTiet_PhieuChuoc](
	[MaPhieuChuoc] [int] NOT NULL,
	[MaSP] [nvarchar](50) NOT NULL,
	[TienLai] [float] NOT NULL,
	[TongTien] [float] NULL,
 CONSTRAINT [pk_CTPC] PRIMARY KEY CLUSTERED 
(
	[MaPhieuChuoc] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTiet_ThanhLy]    Script Date: 6/13/2022 2:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTiet_ThanhLy](
	[MaThanhLy] [int] NOT NULL,
	[MaSP] [nvarchar](50) NOT NULL,
 CONSTRAINT [pk_HDTL] PRIMARY KEY CLUSTERED 
(
	[MaThanhLy] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDonCam]    Script Date: 6/13/2022 2:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonCam](
	[MaHoaDonCam] [int] IDENTITY(1,1) NOT NULL,
	[MaKH] [int] NOT NULL,
	[NgayLap] [date] NULL,
	[NgayHetHan] [date] NULL,
	[NgayDongLai] [date] NULL,
	[TongTienCam] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHoaDonCam] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 6/13/2022 2:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[TenKH] [nvarchar](100) NOT NULL,
	[SDT] [int] NULL,
	[CMND] [int] NOT NULL,
	[NamSinh] [date] NULL,
	[DiaChi] [nvarchar](100) NULL,
	[NgayCapCMND] [date] NULL,
	[HinhAnh] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiSP]    Script Date: 6/13/2022 2:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSP](
	[MaLoai] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](100) NOT NULL,
	[LaiXuat] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhieuChuoc]    Script Date: 6/13/2022 2:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuChuoc](
	[MaPhieuChuoc] [int] IDENTITY(1,1) NOT NULL,
	[MaHoaDonCam] [int] NOT NULL,
	[NgayChuoc] [date] NULL,
	[TongTien] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieuChuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhieuLai]    Script Date: 6/13/2022 2:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuLai](
	[MaPhieuLai] [int] IDENTITY(1,1) NOT NULL,
	[MaHoaDonCam] [int] NOT NULL,
	[NgayDongLai] [date] NULL,
	[ThanhTien] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieuLai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Quyen]    Script Date: 6/13/2022 2:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quyen](
	[ID_Quyen] [int] IDENTITY(1,1) NOT NULL,
	[Name_Quyen] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Quyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 6/13/2022 2:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[ID_SP] [nvarchar](50) NULL,
	[MaSP] [nvarchar](50) NOT NULL,
	[TenSP] [nvarchar](100) NOT NULL,
	[DinhGia] [float] NOT NULL,
	[GiaThanhLy] [float] NULL,
	[MaLoai] [int] NOT NULL,
	[MoTa] [nvarchar](max) NULL,
	[MauSac] [nvarchar](max) NULL,
	[HienTrang] [nvarchar](max) NULL,
	[NhangHieu] [nvarchar](max) NULL,
	[QuaHan] [bit] NULL,
	[DaChuoc] [bit] NULL,
	[ThanhLy] [bit] NULL,
	[DaThanhLy] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 6/13/2022 2:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[UsersName] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](max) NULL,
	[ID_Quyen] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UsersName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ThanhLy]    Script Date: 6/13/2022 2:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThanhLy](
	[MaThanhLy] [int] IDENTITY(1,1) NOT NULL,
	[MaKH] [int] NOT NULL,
	[NgayLap] [date] NULL,
	[TongTienThanhLy] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaThanhLy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tien]    Script Date: 6/13/2022 2:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tien](
	[ID] [int] NOT NULL,
	[TongTien] [float] NULL,
	[DoanhThuThang] [float] NULL,
	[TongDoanhThu] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[ChiTiet_HoaDonCam] ([MaHoaDonCam], [MaSP]) VALUES (1, N'IMEI111')
INSERT [dbo].[ChiTiet_HoaDonCam] ([MaHoaDonCam], [MaSP]) VALUES (1, N'IMEI1602')
INSERT [dbo].[ChiTiet_HoaDonCam] ([MaHoaDonCam], [MaSP]) VALUES (3, N'Asus1602')
INSERT [dbo].[ChiTiet_HoaDonCam] ([MaHoaDonCam], [MaSP]) VALUES (4, N'LT1111')
INSERT [dbo].[ChiTiet_HoaDonCam] ([MaHoaDonCam], [MaSP]) VALUES (4, N'Wa1111')
INSERT [dbo].[ChiTiet_PhieuChuoc] ([MaPhieuChuoc], [MaSP], [TienLai], [TongTien]) VALUES (1, N'IMEI1602', 1, 5)
INSERT [dbo].[ChiTiet_PhieuChuoc] ([MaPhieuChuoc], [MaSP], [TienLai], [TongTien]) VALUES (2, N'IMEI111', 1, 6)
INSERT [dbo].[ChiTiet_PhieuChuoc] ([MaPhieuChuoc], [MaSP], [TienLai], [TongTien]) VALUES (5, N'Asus1602', 0, 5555)
INSERT [dbo].[ChiTiet_ThanhLy] ([MaThanhLy], [MaSP]) VALUES (1, N'IMEI1789')
SET IDENTITY_INSERT [dbo].[HoaDonCam] ON 

INSERT [dbo].[HoaDonCam] ([MaHoaDonCam], [MaKH], [NgayLap], [NgayHetHan], [NgayDongLai], [TongTienCam]) VALUES (1, 1, CAST(N'2022-04-16' AS Date), CAST(N'2022-05-16' AS Date), CAST(N'2022-04-16' AS Date), 1111)
INSERT [dbo].[HoaDonCam] ([MaHoaDonCam], [MaKH], [NgayLap], [NgayHetHan], [NgayDongLai], [TongTienCam]) VALUES (2, 2, CAST(N'2022-04-16' AS Date), CAST(N'2022-05-16' AS Date), CAST(N'2022-04-16' AS Date), 2222)
INSERT [dbo].[HoaDonCam] ([MaHoaDonCam], [MaKH], [NgayLap], [NgayHetHan], [NgayDongLai], [TongTienCam]) VALUES (3, 4, CAST(N'2022-06-13' AS Date), CAST(N'2022-07-13' AS Date), CAST(N'2022-06-13' AS Date), 5555)
INSERT [dbo].[HoaDonCam] ([MaHoaDonCam], [MaKH], [NgayLap], [NgayHetHan], [NgayDongLai], [TongTienCam]) VALUES (4, 3, CAST(N'2022-06-13' AS Date), CAST(N'2022-07-13' AS Date), CAST(N'2022-06-13' AS Date), 16665)
SET IDENTITY_INSERT [dbo].[HoaDonCam] OFF
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CMND], [NamSinh], [DiaChi], [NgayCapCMND], [HinhAnh]) VALUES (1, N'Trần Nhị Ân', 919059069, 381909647, CAST(N'2020-05-19' AS Date), N'Cà Mau', CAST(N'2020-05-19' AS Date), N'1')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CMND], [NamSinh], [DiaChi], [NgayCapCMND], [HinhAnh]) VALUES (2, N'Nguyễn Chí Đang', 835629645, 381000111, CAST(N'2020-05-19' AS Date), N'Cà Mau', CAST(N'2020-05-19' AS Date), N'1')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CMND], [NamSinh], [DiaChi], [NgayCapCMND], [HinhAnh]) VALUES (3, N'Trần Nhất Phương', 947366755, 381222333, CAST(N'2020-05-19' AS Date), N'Cà Mau', CAST(N'2020-05-19' AS Date), N'1')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CMND], [NamSinh], [DiaChi], [NgayCapCMND], [HinhAnh]) VALUES (4, N'Lý Tấn Ngọc', 919599595, 381987345, CAST(N'2020-05-19' AS Date), N'Cần Thơ', CAST(N'2020-05-19' AS Date), N'1')
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
SET IDENTITY_INSERT [dbo].[LoaiSP] ON 

INSERT [dbo].[LoaiSP] ([MaLoai], [TenLoai], [LaiXuat]) VALUES (1, N'Điện Thoại', 5)
INSERT [dbo].[LoaiSP] ([MaLoai], [TenLoai], [LaiXuat]) VALUES (2, N'Máy Tính', 3)
INSERT [dbo].[LoaiSP] ([MaLoai], [TenLoai], [LaiXuat]) VALUES (3, N'Xe Máy', 0.6)
SET IDENTITY_INSERT [dbo].[LoaiSP] OFF
SET IDENTITY_INSERT [dbo].[PhieuChuoc] ON 

INSERT [dbo].[PhieuChuoc] ([MaPhieuChuoc], [MaHoaDonCam], [NgayChuoc], [TongTien]) VALUES (1, 1, CAST(N'2020-05-19' AS Date), 1111)
INSERT [dbo].[PhieuChuoc] ([MaPhieuChuoc], [MaHoaDonCam], [NgayChuoc], [TongTien]) VALUES (2, 2, CAST(N'2020-05-19' AS Date), 2222)
INSERT [dbo].[PhieuChuoc] ([MaPhieuChuoc], [MaHoaDonCam], [NgayChuoc], [TongTien]) VALUES (3, 1, CAST(N'2020-05-19' AS Date), 3333)
INSERT [dbo].[PhieuChuoc] ([MaPhieuChuoc], [MaHoaDonCam], [NgayChuoc], [TongTien]) VALUES (4, 2, CAST(N'2020-05-19' AS Date), 4444)
INSERT [dbo].[PhieuChuoc] ([MaPhieuChuoc], [MaHoaDonCam], [NgayChuoc], [TongTien]) VALUES (5, 3, CAST(N'2022-06-13' AS Date), 5555)
SET IDENTITY_INSERT [dbo].[PhieuChuoc] OFF
SET IDENTITY_INSERT [dbo].[PhieuLai] ON 

INSERT [dbo].[PhieuLai] ([MaPhieuLai], [MaHoaDonCam], [NgayDongLai], [ThanhTien]) VALUES (1, 1, CAST(N'2022-04-16' AS Date), 1111)
INSERT [dbo].[PhieuLai] ([MaPhieuLai], [MaHoaDonCam], [NgayDongLai], [ThanhTien]) VALUES (2, 2, CAST(N'2022-04-16' AS Date), 2222)
SET IDENTITY_INSERT [dbo].[PhieuLai] OFF
SET IDENTITY_INSERT [dbo].[Quyen] ON 

INSERT [dbo].[Quyen] ([ID_Quyen], [Name_Quyen]) VALUES (1, N'admin')
SET IDENTITY_INSERT [dbo].[Quyen] OFF
INSERT [dbo].[SanPham] ([ID_SP], [MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'MT1', N'Asus1602', N'Asus', 5555, 0, 2, N'máy tính xách tay', N'Xám', N'Trung bình (85%-95%)', N'Asus', 0, 1, 0, 0)
INSERT [dbo].[SanPham] ([ID_SP], [MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'DT02', N'IMEI111', N'SAMSUNG A12', 1111, 2222, 1, N'ĐIỆN THOẠI CẦM TAY', N'Màu Hồng', N'có trầy viền', N' SAMSUNG', 1, 0, 0, 0)
INSERT [dbo].[SanPham] ([ID_SP], [MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'DT05', N'IMEI1323', N'IPHONE X', 1323, 3333, 1, N'ĐIỆN THOẠI CẦM TAY', N'Màu Vàng', N'có trầy ở kính', N' IPHONE', 0, 0, 0, 0)
INSERT [dbo].[SanPham] ([ID_SP], [MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'DT01', N'IMEI1602', N'IPHONE 12', 1602, 1111, 1, N'ĐIỆN THOẠI CẦM TAY', N'Màu đỏ', N'có trầy ở lưng', N'IPHONE', 1, 0, 0, 0)
INSERT [dbo].[SanPham] ([ID_SP], [MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'DT04', N'IMEI1666', N'OPPO FIND X', 1666, 4444, 1, N'ĐIỆN THOẠI CẦM TAY', N'Màu Tím', N'100%', N' OPPO', 0, 0, 0, 0)
INSERT [dbo].[SanPham] ([ID_SP], [MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'DT03', N'IMEI1789', N'OPPO A95', 1789, 5555, 1, N'ĐIỆN THOẠI CẦM TAY', N'Màu Xanh', N'100%', N' OPPO', 0, 0, 0, 0)
INSERT [dbo].[SanPham] ([ID_SP], [MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'MT2', N'LT1111', N'Macbook', 7777, 0, 2, N'Tươi tắn', N'Hồng', N'99%', N'MAC', 0, 0, 0, 0)
INSERT [dbo].[SanPham] ([ID_SP], [MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'XM1', N'Wa1111', N'Wave 110', 8888, 0, 3, N'Xe của a xăm mình', N'Xanh', N'Trung bình (85%-95%)', N'HONDA', 0, 0, 0, 0)
INSERT [dbo].[TaiKhoan] ([UsersName], [Password], [ID_Quyen]) VALUES (N'admin', N'123', 1)
SET IDENTITY_INSERT [dbo].[ThanhLy] ON 

INSERT [dbo].[ThanhLy] ([MaThanhLy], [MaKH], [NgayLap], [TongTienThanhLy]) VALUES (1, 1, CAST(N'2022-05-17' AS Date), 1111)
SET IDENTITY_INSERT [dbo].[ThanhLy] OFF
INSERT [dbo].[Tien] ([ID], [TongTien], [DoanhThuThang], [TongDoanhThu]) VALUES (1, 1000000000, 50000000, 600000000)
ALTER TABLE [dbo].[ChiTiet_HoaDonCam]  WITH CHECK ADD FOREIGN KEY([MaHoaDonCam])
REFERENCES [dbo].[HoaDonCam] ([MaHoaDonCam])
GO
ALTER TABLE [dbo].[ChiTiet_HoaDonCam]  WITH CHECK ADD FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[ChiTiet_PhieuChuoc]  WITH CHECK ADD FOREIGN KEY([MaPhieuChuoc])
REFERENCES [dbo].[PhieuChuoc] ([MaPhieuChuoc])
GO
ALTER TABLE [dbo].[ChiTiet_PhieuChuoc]  WITH CHECK ADD FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[ChiTiet_ThanhLy]  WITH CHECK ADD FOREIGN KEY([MaThanhLy])
REFERENCES [dbo].[ThanhLy] ([MaThanhLy])
GO
ALTER TABLE [dbo].[ChiTiet_ThanhLy]  WITH CHECK ADD FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[HoaDonCam]  WITH CHECK ADD FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[PhieuChuoc]  WITH CHECK ADD FOREIGN KEY([MaHoaDonCam])
REFERENCES [dbo].[HoaDonCam] ([MaHoaDonCam])
GO
ALTER TABLE [dbo].[PhieuLai]  WITH CHECK ADD FOREIGN KEY([MaHoaDonCam])
REFERENCES [dbo].[HoaDonCam] ([MaHoaDonCam])
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD FOREIGN KEY([MaLoai])
REFERENCES [dbo].[LoaiSP] ([MaLoai])
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD FOREIGN KEY([ID_Quyen])
REFERENCES [dbo].[Quyen] ([ID_Quyen])
GO
ALTER TABLE [dbo].[ThanhLy]  WITH CHECK ADD FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
USE [master]
GO
ALTER DATABASE [QuanLyCamDo] SET  READ_WRITE 
GO
