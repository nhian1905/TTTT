USE [master]
GO
/****** Object:  Database [QuanLyCamDo]    Script Date: 5/25/2022 7:00:44 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_DoanhThuThang]    Script Date: 5/25/2022 7:00:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
/****** Object:  StoredProcedure [dbo].[USP_DongLai]    Script Date: 5/25/2022 7:00:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
/****** Object:  StoredProcedure [dbo].[USP_InHoaDonPhieuCam]    Script Date: 5/25/2022 7:00:44 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_InHoaDonPhieuChuoc]    Script Date: 5/25/2022 7:00:44 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_InHoaDonPhieuDL]    Script Date: 5/25/2022 7:00:44 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_InHoaDonPhieuTL]    Script Date: 5/25/2022 7:00:44 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_TimHoaDonCamByDate]    Script Date: 5/25/2022 7:00:44 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_TimHoaDonChuocByDate]    Script Date: 5/25/2022 7:00:44 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_TimHoaDonTLByDate]    Script Date: 5/25/2022 7:00:44 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_TinhTienLai]    Script Date: 5/25/2022 7:00:44 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_UpdateNgayDongLaiHDC]    Script Date: 5/25/2022 7:00:44 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_UpdateQuaHan]    Script Date: 5/25/2022 7:00:44 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_UpdateTienPhieuChuoc]    Script Date: 5/25/2022 7:00:44 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_UpdateTongTienHDC]    Script Date: 5/25/2022 7:00:44 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_UpdateTongTienThanHLy]    Script Date: 5/25/2022 7:00:44 PM ******/
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
/****** Object:  Table [dbo].[ChiTiet_HoaDonCam]    Script Date: 5/25/2022 7:00:44 PM ******/
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
/****** Object:  Table [dbo].[ChiTiet_PhieuChuoc]    Script Date: 5/25/2022 7:00:44 PM ******/
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
/****** Object:  Table [dbo].[ChiTiet_ThanhLy]    Script Date: 5/25/2022 7:00:44 PM ******/
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
/****** Object:  Table [dbo].[HoaDonCam]    Script Date: 5/25/2022 7:00:44 PM ******/
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
/****** Object:  Table [dbo].[KhachHang]    Script Date: 5/25/2022 7:00:44 PM ******/
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
/****** Object:  Table [dbo].[LoaiSP]    Script Date: 5/25/2022 7:00:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSP](
	[MaLoai] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](100) NOT NULL,
	[LaiXuat] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhieuChuoc]    Script Date: 5/25/2022 7:00:44 PM ******/
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
/****** Object:  Table [dbo].[PhieuLai]    Script Date: 5/25/2022 7:00:44 PM ******/
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
/****** Object:  Table [dbo].[Quyen]    Script Date: 5/25/2022 7:00:44 PM ******/
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
/****** Object:  Table [dbo].[SanPham]    Script Date: 5/25/2022 7:00:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
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
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 5/25/2022 7:00:44 PM ******/
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
/****** Object:  Table [dbo].[ThanhLy]    Script Date: 5/25/2022 7:00:44 PM ******/
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
/****** Object:  Table [dbo].[Tien]    Script Date: 5/25/2022 7:00:44 PM ******/
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
INSERT [dbo].[ChiTiet_HoaDonCam] ([MaHoaDonCam], [MaSP]) VALUES (1, N'IMEI123')
INSERT [dbo].[ChiTiet_HoaDonCam] ([MaHoaDonCam], [MaSP]) VALUES (1, N'IP')
INSERT [dbo].[ChiTiet_HoaDonCam] ([MaHoaDonCam], [MaSP]) VALUES (2, N'IMEI456')
INSERT [dbo].[ChiTiet_HoaDonCam] ([MaHoaDonCam], [MaSP]) VALUES (3, N'IMEI41')
INSERT [dbo].[ChiTiet_HoaDonCam] ([MaHoaDonCam], [MaSP]) VALUES (3, N'IMEI456123')
INSERT [dbo].[ChiTiet_HoaDonCam] ([MaHoaDonCam], [MaSP]) VALUES (4, N'IMEI411')
INSERT [dbo].[ChiTiet_HoaDonCam] ([MaHoaDonCam], [MaSP]) VALUES (4, N'IMEI4119')
INSERT [dbo].[ChiTiet_HoaDonCam] ([MaHoaDonCam], [MaSP]) VALUES (5, N'Asusu vivo')
INSERT [dbo].[ChiTiet_HoaDonCam] ([MaHoaDonCam], [MaSP]) VALUES (5, N'IMEI56')
INSERT [dbo].[ChiTiet_HoaDonCam] ([MaHoaDonCam], [MaSP]) VALUES (6, N'Asusu vivo1')
INSERT [dbo].[ChiTiet_HoaDonCam] ([MaHoaDonCam], [MaSP]) VALUES (6, N'Asusu vivo2')
INSERT [dbo].[ChiTiet_HoaDonCam] ([MaHoaDonCam], [MaSP]) VALUES (6, N'Asusu vivo3')
INSERT [dbo].[ChiTiet_HoaDonCam] ([MaHoaDonCam], [MaSP]) VALUES (7, N'Asusu vivo111')
INSERT [dbo].[ChiTiet_HoaDonCam] ([MaHoaDonCam], [MaSP]) VALUES (7, N'Asusu vivo1113')
INSERT [dbo].[ChiTiet_HoaDonCam] ([MaHoaDonCam], [MaSP]) VALUES (8, N'Asusu vivo111356')
INSERT [dbo].[ChiTiet_HoaDonCam] ([MaHoaDonCam], [MaSP]) VALUES (8, N'Asusu vivo11135654')
INSERT [dbo].[ChiTiet_HoaDonCam] ([MaHoaDonCam], [MaSP]) VALUES (9, N'IMEI4561')
INSERT [dbo].[ChiTiet_HoaDonCam] ([MaHoaDonCam], [MaSP]) VALUES (10, N'IMEI4561111')
INSERT [dbo].[ChiTiet_HoaDonCam] ([MaHoaDonCam], [MaSP]) VALUES (11, N'IMEI160222')
INSERT [dbo].[ChiTiet_HoaDonCam] ([MaHoaDonCam], [MaSP]) VALUES (11, N'IMEI160226')
INSERT [dbo].[ChiTiet_HoaDonCam] ([MaHoaDonCam], [MaSP]) VALUES (12, N'IMEI000')
INSERT [dbo].[ChiTiet_HoaDonCam] ([MaHoaDonCam], [MaSP]) VALUES (12, N'IMEI0001')
INSERT [dbo].[ChiTiet_HoaDonCam] ([MaHoaDonCam], [MaSP]) VALUES (12, N'IMEI0002')
INSERT [dbo].[ChiTiet_HoaDonCam] ([MaHoaDonCam], [MaSP]) VALUES (13, N'IMEI1702')
INSERT [dbo].[ChiTiet_PhieuChuoc] ([MaPhieuChuoc], [MaSP], [TienLai], [TongTien]) VALUES (8, N'Asusu vivo111356', 9300, 19300)
INSERT [dbo].[ChiTiet_PhieuChuoc] ([MaPhieuChuoc], [MaSP], [TienLai], [TongTien]) VALUES (8, N'Asusu vivo11135654', 9300, 19300)
INSERT [dbo].[ChiTiet_PhieuChuoc] ([MaPhieuChuoc], [MaSP], [TienLai], [TongTien]) VALUES (9, N'Asusu vivo111', 9300, 19300)
INSERT [dbo].[ChiTiet_PhieuChuoc] ([MaPhieuChuoc], [MaSP], [TienLai], [TongTien]) VALUES (9, N'Asusu vivo1113', 9300, 19300)
INSERT [dbo].[ChiTiet_PhieuChuoc] ([MaPhieuChuoc], [MaSP], [TienLai], [TongTien]) VALUES (10, N'Asusu vivo1', 13800, 23800)
INSERT [dbo].[ChiTiet_PhieuChuoc] ([MaPhieuChuoc], [MaSP], [TienLai], [TongTien]) VALUES (10, N'Asusu vivo2', 13800, 23800)
INSERT [dbo].[ChiTiet_PhieuChuoc] ([MaPhieuChuoc], [MaSP], [TienLai], [TongTien]) VALUES (10, N'Asusu vivo3', 13800, 23800)
INSERT [dbo].[ChiTiet_PhieuChuoc] ([MaPhieuChuoc], [MaSP], [TienLai], [TongTien]) VALUES (12, N'Asusu vivo111', 9300, 19300)
INSERT [dbo].[ChiTiet_PhieuChuoc] ([MaPhieuChuoc], [MaSP], [TienLai], [TongTien]) VALUES (12, N'Asusu vivo1113', 9300, 19300)
INSERT [dbo].[ChiTiet_PhieuChuoc] ([MaPhieuChuoc], [MaSP], [TienLai], [TongTien]) VALUES (13, N'IMEI4561', 0, 10000)
INSERT [dbo].[ChiTiet_PhieuChuoc] ([MaPhieuChuoc], [MaSP], [TienLai], [TongTien]) VALUES (15, N'IMEI160222', 0, 50000)
INSERT [dbo].[ChiTiet_PhieuChuoc] ([MaPhieuChuoc], [MaSP], [TienLai], [TongTien]) VALUES (15, N'IMEI160226', 0, 50000)
INSERT [dbo].[ChiTiet_PhieuChuoc] ([MaPhieuChuoc], [MaSP], [TienLai], [TongTien]) VALUES (17, N'IMEI000', 0, 9999)
INSERT [dbo].[ChiTiet_PhieuChuoc] ([MaPhieuChuoc], [MaSP], [TienLai], [TongTien]) VALUES (17, N'IMEI0002', 0, 9999)
INSERT [dbo].[ChiTiet_ThanhLy] ([MaThanhLy], [MaSP]) VALUES (1, N'IMEI41')
INSERT [dbo].[ChiTiet_ThanhLy] ([MaThanhLy], [MaSP]) VALUES (2, N'IMEI456')
SET IDENTITY_INSERT [dbo].[HoaDonCam] ON 

INSERT [dbo].[HoaDonCam] ([MaHoaDonCam], [MaKH], [NgayLap], [NgayHetHan], [NgayDongLai], [TongTienCam]) VALUES (1, 1, CAST(N'2022-04-16' AS Date), CAST(N'2022-05-15' AS Date), CAST(N'2022-04-16' AS Date), 50666)
INSERT [dbo].[HoaDonCam] ([MaHoaDonCam], [MaKH], [NgayLap], [NgayHetHan], [NgayDongLai], [TongTienCam]) VALUES (2, 2, CAST(N'2022-05-03' AS Date), CAST(N'2022-05-13' AS Date), CAST(N'2022-05-03' AS Date), 10000)
INSERT [dbo].[HoaDonCam] ([MaHoaDonCam], [MaKH], [NgayLap], [NgayHetHan], [NgayDongLai], [TongTienCam]) VALUES (3, 2, CAST(N'2022-05-01' AS Date), CAST(N'2022-05-14' AS Date), CAST(N'2022-05-01' AS Date), 20000)
INSERT [dbo].[HoaDonCam] ([MaHoaDonCam], [MaKH], [NgayLap], [NgayHetHan], [NgayDongLai], [TongTienCam]) VALUES (4, 1, CAST(N'2022-05-03' AS Date), CAST(N'2022-05-12' AS Date), CAST(N'2022-05-03' AS Date), 20000)
INSERT [dbo].[HoaDonCam] ([MaHoaDonCam], [MaKH], [NgayLap], [NgayHetHan], [NgayDongLai], [TongTienCam]) VALUES (5, 2, CAST(N'2022-04-10' AS Date), CAST(N'2022-05-30' AS Date), CAST(N'2022-04-10' AS Date), 20000)
INSERT [dbo].[HoaDonCam] ([MaHoaDonCam], [MaKH], [NgayLap], [NgayHetHan], [NgayDongLai], [TongTienCam]) VALUES (6, 3, CAST(N'2022-04-01' AS Date), CAST(N'2022-05-16' AS Date), CAST(N'2022-04-01' AS Date), 30000)
INSERT [dbo].[HoaDonCam] ([MaHoaDonCam], [MaKH], [NgayLap], [NgayHetHan], [NgayDongLai], [TongTienCam]) VALUES (7, 3, CAST(N'2022-04-16' AS Date), CAST(N'2022-05-20' AS Date), CAST(N'2022-04-16' AS Date), 20000)
INSERT [dbo].[HoaDonCam] ([MaHoaDonCam], [MaKH], [NgayLap], [NgayHetHan], [NgayDongLai], [TongTienCam]) VALUES (8, 3, CAST(N'2022-04-16' AS Date), CAST(N'2022-05-20' AS Date), CAST(N'2022-04-16' AS Date), 20000)
INSERT [dbo].[HoaDonCam] ([MaHoaDonCam], [MaKH], [NgayLap], [NgayHetHan], [NgayDongLai], [TongTienCam]) VALUES (9, 1, CAST(N'2022-05-10' AS Date), CAST(N'2022-05-31' AS Date), CAST(N'2022-05-17' AS Date), 10000)
INSERT [dbo].[HoaDonCam] ([MaHoaDonCam], [MaKH], [NgayLap], [NgayHetHan], [NgayDongLai], [TongTienCam]) VALUES (10, 4, CAST(N'2022-05-10' AS Date), CAST(N'2022-05-30' AS Date), CAST(N'2022-05-17' AS Date), 10000)
INSERT [dbo].[HoaDonCam] ([MaHoaDonCam], [MaKH], [NgayLap], [NgayHetHan], [NgayDongLai], [TongTienCam]) VALUES (11, 4, CAST(N'2022-05-17' AS Date), CAST(N'2022-06-17' AS Date), CAST(N'2022-05-17' AS Date), 100000)
INSERT [dbo].[HoaDonCam] ([MaHoaDonCam], [MaKH], [NgayLap], [NgayHetHan], [NgayDongLai], [TongTienCam]) VALUES (12, 2, CAST(N'2022-04-17' AS Date), CAST(N'2022-06-17' AS Date), CAST(N'2022-05-12' AS Date), 29997)
INSERT [dbo].[HoaDonCam] ([MaHoaDonCam], [MaKH], [NgayLap], [NgayHetHan], [NgayDongLai], [TongTienCam]) VALUES (13, 5, CAST(N'2022-05-12' AS Date), CAST(N'2022-05-18' AS Date), CAST(N'2022-05-18' AS Date), 7000)
SET IDENTITY_INSERT [dbo].[HoaDonCam] OFF
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CMND], [NamSinh], [DiaChi], [NgayCapCMND], [HinhAnh]) VALUES (1, N'Trần Nhị Ân', 919059069, 381909647, CAST(N'2020-05-19' AS Date), N'Cà Mau', CAST(N'2020-05-19' AS Date), N'1')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CMND], [NamSinh], [DiaChi], [NgayCapCMND], [HinhAnh]) VALUES (2, N'Nguyễn Chí Đang', 919059069, 381909647, CAST(N'2020-05-19' AS Date), N'Cà Mau', CAST(N'2020-05-19' AS Date), N'')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CMND], [NamSinh], [DiaChi], [NgayCapCMND], [HinhAnh]) VALUES (3, N'Phúc Ngu', 919059069, 381909647, CAST(N'2020-05-19' AS Date), N'Cà Mau', CAST(N'2020-05-19' AS Date), N'')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CMND], [NamSinh], [DiaChi], [NgayCapCMND], [HinhAnh]) VALUES (4, N'Tô Lê Long Thịnh', 919059069, 381909647, CAST(N'2020-05-19' AS Date), N'Cà Mau', CAST(N'2020-05-19' AS Date), N'')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CMND], [NamSinh], [DiaChi], [NgayCapCMND], [HinhAnh]) VALUES (5, N'Le Nhut Linh', 83839399, 32423423, CAST(N'2001-05-18' AS Date), N'Ca Mau', CAST(N'2022-05-18' AS Date), N'')
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
SET IDENTITY_INSERT [dbo].[LoaiSP] ON 

INSERT [dbo].[LoaiSP] ([MaLoai], [TenLoai], [LaiXuat]) VALUES (1, N'Điện thoại', 5)
INSERT [dbo].[LoaiSP] ([MaLoai], [TenLoai], [LaiXuat]) VALUES (2, N'Máy tính', 3)
SET IDENTITY_INSERT [dbo].[LoaiSP] OFF
SET IDENTITY_INSERT [dbo].[PhieuChuoc] ON 

INSERT [dbo].[PhieuChuoc] ([MaPhieuChuoc], [MaHoaDonCam], [NgayChuoc], [TongTien]) VALUES (3, 1, CAST(N'2020-05-19' AS Date), 0)
INSERT [dbo].[PhieuChuoc] ([MaPhieuChuoc], [MaHoaDonCam], [NgayChuoc], [TongTien]) VALUES (4, 2, CAST(N'2020-05-19' AS Date), 0)
INSERT [dbo].[PhieuChuoc] ([MaPhieuChuoc], [MaHoaDonCam], [NgayChuoc], [TongTien]) VALUES (5, 2, CAST(N'2020-05-19' AS Date), 0)
INSERT [dbo].[PhieuChuoc] ([MaPhieuChuoc], [MaHoaDonCam], [NgayChuoc], [TongTien]) VALUES (6, 2, CAST(N'2020-05-19' AS Date), 0)
INSERT [dbo].[PhieuChuoc] ([MaPhieuChuoc], [MaHoaDonCam], [NgayChuoc], [TongTien]) VALUES (7, 1, CAST(N'2022-05-17' AS Date), 0)
INSERT [dbo].[PhieuChuoc] ([MaPhieuChuoc], [MaHoaDonCam], [NgayChuoc], [TongTien]) VALUES (8, 8, CAST(N'2022-05-17' AS Date), 38600)
INSERT [dbo].[PhieuChuoc] ([MaPhieuChuoc], [MaHoaDonCam], [NgayChuoc], [TongTien]) VALUES (9, 7, CAST(N'2022-04-28' AS Date), 38600)
INSERT [dbo].[PhieuChuoc] ([MaPhieuChuoc], [MaHoaDonCam], [NgayChuoc], [TongTien]) VALUES (10, 6, CAST(N'2022-05-17' AS Date), 71400)
INSERT [dbo].[PhieuChuoc] ([MaPhieuChuoc], [MaHoaDonCam], [NgayChuoc], [TongTien]) VALUES (11, 6, CAST(N'2022-05-17' AS Date), 0)
INSERT [dbo].[PhieuChuoc] ([MaPhieuChuoc], [MaHoaDonCam], [NgayChuoc], [TongTien]) VALUES (12, 7, CAST(N'2022-05-17' AS Date), 38600)
INSERT [dbo].[PhieuChuoc] ([MaPhieuChuoc], [MaHoaDonCam], [NgayChuoc], [TongTien]) VALUES (13, 9, CAST(N'2022-05-17' AS Date), 10000)
INSERT [dbo].[PhieuChuoc] ([MaPhieuChuoc], [MaHoaDonCam], [NgayChuoc], [TongTien]) VALUES (14, 10, CAST(N'2022-05-17' AS Date), 0)
INSERT [dbo].[PhieuChuoc] ([MaPhieuChuoc], [MaHoaDonCam], [NgayChuoc], [TongTien]) VALUES (15, 11, CAST(N'2022-05-17' AS Date), 100000)
INSERT [dbo].[PhieuChuoc] ([MaPhieuChuoc], [MaHoaDonCam], [NgayChuoc], [TongTien]) VALUES (16, 11, CAST(N'2022-05-17' AS Date), 0)
INSERT [dbo].[PhieuChuoc] ([MaPhieuChuoc], [MaHoaDonCam], [NgayChuoc], [TongTien]) VALUES (17, 12, CAST(N'2022-05-17' AS Date), 19998)
SET IDENTITY_INSERT [dbo].[PhieuChuoc] OFF
SET IDENTITY_INSERT [dbo].[PhieuLai] ON 

INSERT [dbo].[PhieuLai] ([MaPhieuLai], [MaHoaDonCam], [NgayDongLai], [ThanhTien]) VALUES (1, 10, CAST(N'2022-05-17' AS Date), 3500)
INSERT [dbo].[PhieuLai] ([MaPhieuLai], [MaHoaDonCam], [NgayDongLai], [ThanhTien]) VALUES (2, 9, CAST(N'2022-04-17' AS Date), 3500)
INSERT [dbo].[PhieuLai] ([MaPhieuLai], [MaHoaDonCam], [NgayDongLai], [ThanhTien]) VALUES (5, 12, CAST(N'2022-05-18' AS Date), 9299.07)
INSERT [dbo].[PhieuLai] ([MaPhieuLai], [MaHoaDonCam], [NgayDongLai], [ThanhTien]) VALUES (6, 13, CAST(N'2022-05-18' AS Date), 2100)
SET IDENTITY_INSERT [dbo].[PhieuLai] OFF
SET IDENTITY_INSERT [dbo].[Quyen] ON 

INSERT [dbo].[Quyen] ([ID_Quyen], [Name_Quyen]) VALUES (1, N'admin')
SET IDENTITY_INSERT [dbo].[Quyen] OFF
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'Asusu vivo', N'Vivo book pro12', 10000, 123, 2, N'Điện thoại cầm tay', N'Xanh', N'100%', N'IPHONE', 0, 0, 1, 0)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'Asusu vivo1', N'Vivo book pro12', 10000, 0, 2, N'Điện thoại cầm tay', N'Xanh', N'100%', N'IPHONE', 0, 1, 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'Asusu vivo111', N'Vivo book pro12', 10000, 0, 2, N'Điện thoại cầm tay', N'Xanh', N'100%', N'IPHONE', 0, 1, 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'Asusu vivo1113', N'Vivo book pro12', 10000, 0, 2, N'Điện thoại cầm tay', N'Xanh', N'100%', N'IPHONE', 0, 1, 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'Asusu vivo111356', N'Vivo book pro12', 10000, 0, 2, N'Điện thoại cầm tay', N'Xanh', N'100%', N'IPHONE', 1, 0, 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'Asusu vivo11135654', N'Vivo book pro12', 10000, 0, 2, N'Điện thoại cầm tay', N'Xanh', N'100%', N'IPHONE', 1, 0, 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'Asusu vivo2', N'Vivo book pro12', 10000, 1324233, 2, N'Điện thoại cầm tay', N'Xanh', N'100%', N'IPHONE', 1, 0, 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'Asusu vivo3', N'Vivo book pro12', 10000, 0, 2, N'Điện thoại cầm tay', N'Xanh', N'100%', N'IPHONE', 1, 0, 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'IMEI000', N'ASUS A14', 9999, 0, 2, N'Máy tính sách tay', N'Xám', N'2 năm sử dụng', N'ASUS', 1, 0, 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'IMEI0001', N'ASUS A14', 9999, 0, 2, N'Máy tính sách tay', N'Xám', N'2 năm sử dụng', N'ASUS', 1, 0, 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'IMEI0002', N'ASUS A14', 9999, 0, 2, N'Máy tính sách tay', N'Xám', N'2 năm sử dụng', N'ASUS', 1, 0, 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'IMEI123', N'IPHONE 10', 50000, 0, 1, N'Điện thoại cầm tay', N'Đỏ', N'100%', N'IPHONE', 1, 0, 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'IMEI160222', N'IPHONE 11', 50000, 0, 1, N'Điện thoại cầm tay', N'Trắng', N'100 %', N'IPHONE', 0, 1, 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'IMEI160226', N'IPHONE 11', 50000, 0, 1, N'Điện thoại cầm tay', N'Trắng', N'100 %', N'IPHONE', 0, 1, 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'IMEI1702', N'OPPO F3', 7000, 0, 1, N'dien thoai cam tay', N'Den', N'sai 2 nam', N'OPPO', 1, 0, 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'IMEI41', N'IPHONE 12', 10000, 4123123, 1, N'Điện thoại cầm tay', N'Hồng', N'100%', N'IPHONE', 0, 0, 0, 1)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'IMEI411', N'IPHONE 12', 10000, 0, 1, N'Điện thoại cầm tay', N'Hồng', N'100%', N'IPHONE', 1, 0, 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'IMEI4119', N'IPHONE 12', 10000, 0, 1, N'Điện thoại cầm tay', N'Hồng', N'100%', N'IPHONE', 1, 0, 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'IMEI456', N'IPHONE 12', 10000, 8888888, 1, N'Điện thoại cầm tay', N'Hồng', N'100%', N'IPHONE', 0, 0, 0, 1)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'IMEI4561', N'IPHONE 12', 10000, 0, 1, N'Điện thoại cầm tay', N'Hồng', N'100%', N'IPHONE', 0, 1, 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'IMEI4561111', N'IPHONE 12', 10000, 0, 1, N'Điện thoại cầm tay', N'Hồng', N'100%', N'IPHONE', 1, 0, 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'IMEI456123', N'IPHONE 12', 10000, 0, 1, N'Điện thoại cầm tay', N'Hồng', N'100%', N'IPHONE', 1, 0, 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'IMEI56', N'IPHONE 12', 10000, 123, 1, N'Điện thoại cầm tay', N'Hồng', N'100%', N'IPHONE', 0, 0, 1, 0)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'IP', N'SAM SUNG A12', 666, 0, 1, N'ĐIỆN THOẠI CẦM TAY', N'XANH', N'CÓ TRẦY Ở MẶT LƯNG', N'SAMSUNG', 1, 0, 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'LT', N'Máy Tính', 2345, 3456, 1, N'Nguyên vẹn', N'Màu đỏ', N'có trầy', N' Asus', 0, 0, 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'LT1', N'Máy Tính', 2345, 3456, 1, N'Nguyên vẹn', N'Màu đỏ', N'có trầy', N' Asus', 0, 0, 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'LT2', N'Máy Tính', 2345, 3456, 1, N'Nguyên vẹn', N'Màu đỏ', N'có trầy', N' Asus', 0, 0, 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DinhGia], [GiaThanhLy], [MaLoai], [MoTa], [MauSac], [HienTrang], [NhangHieu], [QuaHan], [DaChuoc], [ThanhLy], [DaThanhLy]) VALUES (N'LT3', N'Máy Tính', 2345, 3456, 1, N'Nguyên vẹn', N'Màu đỏ', N'có trầy', N' Asus', 0, 0, 0, 0)
INSERT [dbo].[TaiKhoan] ([UsersName], [Password], [ID_Quyen]) VALUES (N'admin', N'123', 1)
SET IDENTITY_INSERT [dbo].[ThanhLy] ON 

INSERT [dbo].[ThanhLy] ([MaThanhLy], [MaKH], [NgayLap], [TongTienThanhLy]) VALUES (1, 2, CAST(N'2022-05-16' AS Date), 4123123)
INSERT [dbo].[ThanhLy] ([MaThanhLy], [MaKH], [NgayLap], [TongTienThanhLy]) VALUES (2, 1, CAST(N'2022-04-17' AS Date), 8888888)
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
