USE [master]
GO
/****** Object:  Database [HoaTuoi]    Script Date: 5/31/2020 6:10:50 PM ******/
CREATE DATABASE [HoaTuoi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WEB_HOA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\WEB_HOA.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'WEB_HOA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\WEB_HOA_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HoaTuoi] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HoaTuoi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HoaTuoi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HoaTuoi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HoaTuoi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HoaTuoi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HoaTuoi] SET ARITHABORT OFF 
GO
ALTER DATABASE [HoaTuoi] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [HoaTuoi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HoaTuoi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HoaTuoi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HoaTuoi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HoaTuoi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HoaTuoi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HoaTuoi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HoaTuoi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HoaTuoi] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HoaTuoi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HoaTuoi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HoaTuoi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HoaTuoi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HoaTuoi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HoaTuoi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HoaTuoi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HoaTuoi] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HoaTuoi] SET  MULTI_USER 
GO
ALTER DATABASE [HoaTuoi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HoaTuoi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HoaTuoi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HoaTuoi] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [HoaTuoi] SET DELAYED_DURABILITY = DISABLED 
GO
USE [HoaTuoi]
GO
/****** Object:  Table [dbo].[ChiTietDonHang]    Script Date: 5/31/2020 6:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonHang](
	[IDChiTietDonHang] [int] IDENTITY(1,1) NOT NULL,
	[SoLuongHoa] [int] NOT NULL,
	[ThanhTien] [int] NULL,
	[NgayTao] [datetime] NULL,
	[TenNguoiDung] [nvarchar](50) NULL,
	[DienThoai] [int] NULL,
	[DiaChi] [nvarchar](100) NULL,
	[IDDonHang] [int] NULL,
 CONSTRAINT [PK__ChiTietD__613E7D1C53EA8D90] PRIMARY KEY CLUSTERED 
(
	[IDChiTietDonHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DanhMuc]    Script Date: 5/31/2020 6:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMuc](
	[IDDanhMuc] [int] NOT NULL,
	[TenDanhMuc] [nvarchar](50) NULL,
 CONSTRAINT [PK_DanhMuc] PRIMARY KEY CLUSTERED 
(
	[IDDanhMuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 5/31/2020 6:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[IDDonHang] [int] IDENTITY(1,1) NOT NULL,
	[IDNguoiDung] [int] NOT NULL,
	[IDGioHang] [int] NULL,
 CONSTRAINT [PK__DonHang__C7C3C3C52963F2EF] PRIMARY KEY CLUSTERED 
(
	[IDDonHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GioHang]    Script Date: 5/31/2020 6:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GioHang](
	[IDGioHang] [int] IDENTITY(1,1) NOT NULL,
	[SoLuongHoa] [int] NOT NULL,
	[NgayTao] [datetime] NOT NULL,
	[ThanhTien] [int] NULL,
 CONSTRAINT [PK__GioHang__CCE77A1F4F4CF0F5] PRIMARY KEY CLUSTERED 
(
	[IDGioHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Hoa]    Script Date: 5/31/2020 6:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hoa](
	[IDHoa] [int] NOT NULL,
	[TenHoa] [nvarchar](50) NOT NULL,
	[GiaTien] [int] NOT NULL,
	[AnhDaiDien] [nvarchar](100) NOT NULL,
	[IDDanhMuc] [int] NULL,
 CONSTRAINT [PK__SanPham__5FFA2D426C9BDE8D] PRIMARY KEY CLUSTERED 
(
	[IDHoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Mua]    Script Date: 5/31/2020 6:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mua](
	[IDGioHang] [int] NULL,
	[IDHoa] [int] NULL,
	[SoLuong] [int] NULL,
	[IDMua] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Mua] PRIMARY KEY CLUSTERED 
(
	[IDMua] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 5/31/2020 6:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[IDNguoiDung] [int] IDENTITY(1,1) NOT NULL,
	[TenNguoiDung] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NOT NULL,
	[TenDangNhap] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](100) NOT NULL,
	[DienThoai] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Quyen] [int] NOT NULL,
 CONSTRAINT [PK__NguoiDun__FEE82D40C47D42EE] PRIMARY KEY CLUSTERED 
(
	[IDNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SlideHoa]    Script Date: 5/31/2020 6:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SlideHoa](
	[IDSlide] [int] NOT NULL,
	[AnhDaiDien] [nvarchar](100) NULL,
 CONSTRAINT [PK_SlideHoa] PRIMARY KEY CLUSTERED 
(
	[IDSlide] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonHang_DonHang] FOREIGN KEY([IDDonHang])
REFERENCES [dbo].[DonHang] ([IDDonHang])
GO
ALTER TABLE [dbo].[ChiTietDonHang] CHECK CONSTRAINT [FK_ChiTietDonHang_DonHang]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_GioHang] FOREIGN KEY([IDGioHang])
REFERENCES [dbo].[GioHang] ([IDGioHang])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_GioHang]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_NguoiDung] FOREIGN KEY([IDNguoiDung])
REFERENCES [dbo].[NguoiDung] ([IDNguoiDung])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_NguoiDung]
GO
ALTER TABLE [dbo].[Hoa]  WITH CHECK ADD  CONSTRAINT [FK_Hoa_DanhMuc] FOREIGN KEY([IDDanhMuc])
REFERENCES [dbo].[DanhMuc] ([IDDanhMuc])
GO
ALTER TABLE [dbo].[Hoa] CHECK CONSTRAINT [FK_Hoa_DanhMuc]
GO
ALTER TABLE [dbo].[Mua]  WITH CHECK ADD  CONSTRAINT [FK_Mua_GioHang] FOREIGN KEY([IDGioHang])
REFERENCES [dbo].[GioHang] ([IDGioHang])
GO
ALTER TABLE [dbo].[Mua] CHECK CONSTRAINT [FK_Mua_GioHang]
GO
ALTER TABLE [dbo].[Mua]  WITH CHECK ADD  CONSTRAINT [FK_Mua_Hoa] FOREIGN KEY([IDHoa])
REFERENCES [dbo].[Hoa] ([IDHoa])
GO
ALTER TABLE [dbo].[Mua] CHECK CONSTRAINT [FK_Mua_Hoa]
GO
/****** Object:  StoredProcedure [dbo].[GioHang_GetIDGioHangJustInsert]    Script Date: 5/31/2020 6:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GioHang_GetIDGioHangJustInsert](
    @IDGioHang int out
)
as
begin
    set @IDGioHang = (select top 1 IDGioHang from GioHang order by IDGioHang desc)
end
GO
/****** Object:  StoredProcedure [dbo].[GioHang_InsertProc]    Script Date: 5/31/2020 6:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GioHang_InsertProc](
        @SoLuongHoa int,
		@NgayTao date,
		@ThanhTien int
)
as
begin
    insert into GioHang(SoLuongHoa, NgayTao, ThanhTien)
	values(@SoLuongHoa, @NgayTao, @ThanhTien)
end
GO
/****** Object:  StoredProcedure [dbo].[Mua_InsertProc]    Script Date: 5/31/2020 6:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Mua_InsertProc](
    @SoLuong int,
	@IDHoa int,
	@IDGioHang int
)
as
begin
    insert into Mua(SoLuong, IDHoa, IDGioHang)
	values (@SoLuong, @IDHoa, @IDGioHang)
end
GO
/****** Object:  StoredProcedure [dbo].[NguoiDung_InsertProc]    Script Date: 5/31/2020 6:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[NguoiDung_InsertProc](
        @TenNguoiDung nvarchar(50),
        @MatKhau nvarchar(50),
        @TenDangNhap nvarchar(50),
		@DiaChi nvarchar(100),
		@DienThoai nvarchar(50),
		@Email nvarchar(50),
		@Quyen int
)
as
begin
    insert into NguoiDung(TenNguoiDung, MatKhau, TenDangNhap, DiaChi, DienThoai, Email, Quyen)
	values(@TenNguoiDung, @MatKhau, @TenDangNhap, @DiaChi, @DienThoai, @Email, @Quyen)
end
GO
USE [master]
GO
ALTER DATABASE [HoaTuoi] SET  READ_WRITE 
GO
