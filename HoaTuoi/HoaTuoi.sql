USE [HoaTuoi]
GO
/****** Object:  Table [dbo].[ChiTietDonHang]    Script Date: 9/19/2020 1:19:47 PM ******/
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
/****** Object:  Table [dbo].[DanhMuc]    Script Date: 9/19/2020 1:19:47 PM ******/
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
/****** Object:  Table [dbo].[DonHang]    Script Date: 9/19/2020 1:19:47 PM ******/
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
/****** Object:  Table [dbo].[GioHang]    Script Date: 9/19/2020 1:19:47 PM ******/
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
/****** Object:  Table [dbo].[Hoa]    Script Date: 9/19/2020 1:19:47 PM ******/
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
/****** Object:  Table [dbo].[Mua]    Script Date: 9/19/2020 1:19:47 PM ******/
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
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 9/19/2020 1:19:47 PM ******/
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
/****** Object:  Table [dbo].[SlideHoa]    Script Date: 9/19/2020 1:19:47 PM ******/
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
INSERT [dbo].[DanhMuc] ([IDDanhMuc], [TenDanhMuc]) VALUES (1, N'Tình Yêu')
INSERT [dbo].[DanhMuc] ([IDDanhMuc], [TenDanhMuc]) VALUES (2, N'Buồn Bã')
INSERT [dbo].[DanhMuc] ([IDDanhMuc], [TenDanhMuc]) VALUES (3, N'Mùa Đông')
INSERT [dbo].[DanhMuc] ([IDDanhMuc], [TenDanhMuc]) VALUES (4, N'Tạm Biệt')
SET IDENTITY_INSERT [dbo].[GioHang] ON 

INSERT [dbo].[GioHang] ([IDGioHang], [SoLuongHoa], [NgayTao], [ThanhTien]) VALUES (1, 1, CAST(N'2020-05-31 00:00:00.000' AS DateTime), 10000)
INSERT [dbo].[GioHang] ([IDGioHang], [SoLuongHoa], [NgayTao], [ThanhTien]) VALUES (2, 2, CAST(N'2020-05-31 16:26:05.340' AS DateTime), 40000)
INSERT [dbo].[GioHang] ([IDGioHang], [SoLuongHoa], [NgayTao], [ThanhTien]) VALUES (3, 3, CAST(N'2020-05-31 00:00:00.000' AS DateTime), 35000)
INSERT [dbo].[GioHang] ([IDGioHang], [SoLuongHoa], [NgayTao], [ThanhTien]) VALUES (4, 1, CAST(N'2020-05-31 00:00:00.000' AS DateTime), 10000)
INSERT [dbo].[GioHang] ([IDGioHang], [SoLuongHoa], [NgayTao], [ThanhTien]) VALUES (5, 3, CAST(N'2020-05-31 00:00:00.000' AS DateTime), 50000)
INSERT [dbo].[GioHang] ([IDGioHang], [SoLuongHoa], [NgayTao], [ThanhTien]) VALUES (6, 3, CAST(N'2020-05-31 00:00:00.000' AS DateTime), 50000)
INSERT [dbo].[GioHang] ([IDGioHang], [SoLuongHoa], [NgayTao], [ThanhTien]) VALUES (7, 3, CAST(N'2020-05-31 00:00:00.000' AS DateTime), 50000)
INSERT [dbo].[GioHang] ([IDGioHang], [SoLuongHoa], [NgayTao], [ThanhTien]) VALUES (8, 2, CAST(N'2020-06-25 00:00:00.000' AS DateTime), 20000)
INSERT [dbo].[GioHang] ([IDGioHang], [SoLuongHoa], [NgayTao], [ThanhTien]) VALUES (9, 3, CAST(N'2020-06-29 00:00:00.000' AS DateTime), 35000)
INSERT [dbo].[GioHang] ([IDGioHang], [SoLuongHoa], [NgayTao], [ThanhTien]) VALUES (10, 2, CAST(N'2020-07-22 00:00:00.000' AS DateTime), 20000)
SET IDENTITY_INSERT [dbo].[GioHang] OFF
INSERT [dbo].[Hoa] ([IDHoa], [TenHoa], [GiaTien], [AnhDaiDien], [IDDanhMuc]) VALUES (1, N'Hoa Cẩm Chướng', 10000, N'HoaCamChuong.jpg', 1)
INSERT [dbo].[Hoa] ([IDHoa], [TenHoa], [GiaTien], [AnhDaiDien], [IDDanhMuc]) VALUES (2, N'Hoa Hồng', 15000, N'HoaHong.jpg', 1)
INSERT [dbo].[Hoa] ([IDHoa], [TenHoa], [GiaTien], [AnhDaiDien], [IDDanhMuc]) VALUES (3, N'Hoa Hướng Dương', 20000, N'HoaHuongDuong.jpg', 1)
INSERT [dbo].[Hoa] ([IDHoa], [TenHoa], [GiaTien], [AnhDaiDien], [IDDanhMuc]) VALUES (4, N'Hoa Loa Kèn', 25000, N'HoaLoaKen.jpg', 2)
INSERT [dbo].[Hoa] ([IDHoa], [TenHoa], [GiaTien], [AnhDaiDien], [IDDanhMuc]) VALUES (5, N'Hoa Súng', 10000, N'HoaSung.jpg', 2)
INSERT [dbo].[Hoa] ([IDHoa], [TenHoa], [GiaTien], [AnhDaiDien], [IDDanhMuc]) VALUES (6, N'Hoa Thược Dược', 20000, N'HoaThuocDuoc.jpg', 2)
INSERT [dbo].[Hoa] ([IDHoa], [TenHoa], [GiaTien], [AnhDaiDien], [IDDanhMuc]) VALUES (7, N'Hoa Lan', 20000, N'HoaLan.jpg', 3)
INSERT [dbo].[Hoa] ([IDHoa], [TenHoa], [GiaTien], [AnhDaiDien], [IDDanhMuc]) VALUES (8, N'Hoa Sen', 20000, N'HoaSen.jpg', 4)
INSERT [dbo].[Hoa] ([IDHoa], [TenHoa], [GiaTien], [AnhDaiDien], [IDDanhMuc]) VALUES (9, N'Hoa Cẩm Nhung', 15000, N'HoaCamNhung.jpg', 4)
SET IDENTITY_INSERT [dbo].[Mua] ON 

INSERT [dbo].[Mua] ([IDGioHang], [IDHoa], [SoLuong], [IDMua]) VALUES (5, 1, 1, 1)
INSERT [dbo].[Mua] ([IDGioHang], [IDHoa], [SoLuong], [IDMua]) VALUES (5, 3, 2, 2)
INSERT [dbo].[Mua] ([IDGioHang], [IDHoa], [SoLuong], [IDMua]) VALUES (6, 1, 1, 3)
INSERT [dbo].[Mua] ([IDGioHang], [IDHoa], [SoLuong], [IDMua]) VALUES (6, 3, 2, 4)
INSERT [dbo].[Mua] ([IDGioHang], [IDHoa], [SoLuong], [IDMua]) VALUES (7, 1, 1, 5)
INSERT [dbo].[Mua] ([IDGioHang], [IDHoa], [SoLuong], [IDMua]) VALUES (7, 3, 2, 6)
INSERT [dbo].[Mua] ([IDGioHang], [IDHoa], [SoLuong], [IDMua]) VALUES (8, 1, 2, 7)
INSERT [dbo].[Mua] ([IDGioHang], [IDHoa], [SoLuong], [IDMua]) VALUES (9, 1, 2, 8)
INSERT [dbo].[Mua] ([IDGioHang], [IDHoa], [SoLuong], [IDMua]) VALUES (9, 2, 1, 9)
INSERT [dbo].[Mua] ([IDGioHang], [IDHoa], [SoLuong], [IDMua]) VALUES (10, 1, 2, 10)
SET IDENTITY_INSERT [dbo].[Mua] OFF
SET IDENTITY_INSERT [dbo].[NguoiDung] ON 

INSERT [dbo].[NguoiDung] ([IDNguoiDung], [TenNguoiDung], [MatKhau], [TenDangNhap], [DiaChi], [DienThoai], [Email], [Quyen]) VALUES (1, N'Duc Anh Tran', N'admin', N'admin', N'Hanoi', N'0123456789', N'ducanhtran@gmail', 1)
INSERT [dbo].[NguoiDung] ([IDNguoiDung], [TenNguoiDung], [MatKhau], [TenDangNhap], [DiaChi], [DienThoai], [Email], [Quyen]) VALUES (2, N'ducanhtran123', N'ducanh', N'ducanh', N'Hanoi', N'0123889678', N'ducanh123@gmail.com', 1)
INSERT [dbo].[NguoiDung] ([IDNguoiDung], [TenNguoiDung], [MatKhau], [TenDangNhap], [DiaChi], [DienThoai], [Email], [Quyen]) VALUES (3, N'Cristian Ronaldo', N'1234', N'ronaldo', N'Real Madrid', N'0989123456', N'ronaldoJuve@gmail.com', 1)
SET IDENTITY_INSERT [dbo].[NguoiDung] OFF
INSERT [dbo].[SlideHoa] ([IDSlide], [AnhDaiDien]) VALUES (1, N'Slider1.jpg')
INSERT [dbo].[SlideHoa] ([IDSlide], [AnhDaiDien]) VALUES (2, N'Slider2.jpg')
INSERT [dbo].[SlideHoa] ([IDSlide], [AnhDaiDien]) VALUES (3, N'Slider3.jpg')
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
/****** Object:  StoredProcedure [dbo].[GioHang_GetIDGioHangJustInsert]    Script Date: 9/19/2020 1:19:47 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GioHang_InsertProc]    Script Date: 9/19/2020 1:19:47 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Mua_InsertProc]    Script Date: 9/19/2020 1:19:47 PM ******/
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
/****** Object:  StoredProcedure [dbo].[NguoiDung_InsertProc]    Script Date: 9/19/2020 1:19:47 PM ******/
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
