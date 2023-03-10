USE [master]
GO
/****** Object:  Database [QuanLyCV]    Script Date: 10/02/2023 8:19:34 SA ******/
CREATE DATABASE [QuanLyCV]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyCV', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.GIAHUNGSQL\MSSQL\DATA\QuanLyCV.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLyCV_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.GIAHUNGSQL\MSSQL\DATA\QuanLyCV_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [QuanLyCV] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyCV].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyCV] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyCV] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyCV] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyCV] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyCV] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyCV] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyCV] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyCV] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyCV] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyCV] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyCV] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyCV] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyCV] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyCV] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyCV] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyCV] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyCV] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyCV] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyCV] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyCV] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyCV] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyCV] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyCV] SET RECOVERY FULL 
GO
ALTER DATABASE [QuanLyCV] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyCV] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyCV] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyCV] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyCV] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyCV] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanLyCV] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QuanLyCV', N'ON'
GO
ALTER DATABASE [QuanLyCV] SET QUERY_STORE = ON
GO
ALTER DATABASE [QuanLyCV] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [QuanLyCV]
GO
/****** Object:  Table [dbo].[ACOUNT]    Script Date: 10/02/2023 8:19:34 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ACOUNT](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EMAIL] [varchar](250) NOT NULL,
	[MAT_KHAU] [varchar](250) NULL,
	[LINK_ANH] [char](250) NULL,
	[HO_TEN] [nvarchar](50) NOT NULL,
	[PHONE] [char](12) NOT NULL,
	[NGAY_DANG_KY] [datetime] NULL,
	[DIA_CHI] [nvarchar](250) NOT NULL,
	[TRANG_THAI] [bit] NULL,
	[IS_REMOVE] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BAI_VIET]    Script Date: 10/02/2023 8:19:34 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BAI_VIET](
	[MA_BV] [int] IDENTITY(1,1) NOT NULL,
	[TIEU_DE] [nvarchar](250) NOT NULL,
	[MO_TA] [nvarchar](255) NULL,
	[SLUG] [varchar](250) NOT NULL,
	[IMAGES] [varchar](250) NULL,
	[NOI_DUNG] [ntext] NULL,
	[NOI_BAT] [bit] NULL,
	[TRANG_THAI] [bit] NULL,
	[NGAY_DANG] [datetime] NULL,
	[IS_REMOVE] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MA_BV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[SLUG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[SLUG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[SLUG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[SLUG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Loai_C_V]    Script Date: 10/02/2023 8:19:34 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loai_C_V](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LoaiCV] [nchar](50) NULL,
	[ID_LOAI] [int] NULL,
 CONSTRAINT [PK_Loai_C_V] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 10/02/2023 8:19:34 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenNhaCungCap] [nchar](50) NULL,
	[LoaiCongViec] [nchar](50) NULL,
	[TenCongViec] [nvarchar](500) NULL,
	[NgayDang] [datetime] NULL,
	[LuongBatDau] [float] NULL,
	[HinhAnh] [nvarchar](500) NULL,
	[LoaiIdCv] [int] NULL,
	[DiaChi] [nvarchar](max) NULL,
	[MoTa] [nvarchar](max) NULL,
	[ID_TrangThai] [int] NULL,
 CONSTRAINT [PK_NhaCungCap] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanLoaiCV]    Script Date: 10/02/2023 8:19:34 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanLoaiCV](
	[ID] [int] NOT NULL,
	[ID_LOAI_CV] [int] NULL,
	[GHI_CHU_LOAI] [nchar](50) NULL,
 CONSTRAINT [PK_PhanLoaiCV] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SLIDE]    Script Date: 10/02/2023 8:19:34 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SLIDE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TIEU_DE] [nvarchar](250) NULL,
	[LINK] [varchar](250) NOT NULL,
	[IMAGES] [varchar](250) NULL,
	[STT] [tinyint] NULL,
	[TRANG_THAI] [bit] NULL,
	[NOI_BAT] [bit] NULL,
	[NGAY_DANG] [datetime] NULL,
	[IS_REMOVE] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[STT_TT]    Script Date: 10/02/2023 8:19:34 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STT_TT](
	[ID_STT] [int] NOT NULL,
	[Loai_Trang_Thai] [nvarchar](100) NULL,
 CONSTRAINT [PK_STT_TT] PRIMARY KEY CLUSTERED 
(
	[ID_STT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/02/2023 8:19:34 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ACOUNT] ADD  DEFAULT (getdate()) FOR [NGAY_DANG_KY]
GO
ALTER TABLE [dbo].[ACOUNT] ADD  DEFAULT ((0)) FOR [TRANG_THAI]
GO
ALTER TABLE [dbo].[ACOUNT] ADD  DEFAULT ((0)) FOR [IS_REMOVE]
GO
ALTER TABLE [dbo].[BAI_VIET] ADD  DEFAULT ((0)) FOR [NOI_BAT]
GO
ALTER TABLE [dbo].[BAI_VIET] ADD  DEFAULT ((0)) FOR [TRANG_THAI]
GO
ALTER TABLE [dbo].[BAI_VIET] ADD  DEFAULT (getdate()) FOR [NGAY_DANG]
GO
ALTER TABLE [dbo].[BAI_VIET] ADD  DEFAULT ((0)) FOR [IS_REMOVE]
GO
ALTER TABLE [dbo].[NhaCungCap] ADD  CONSTRAINT [DF_NhaCungCap_NgayDang]  DEFAULT (getdate()) FOR [NgayDang]
GO
ALTER TABLE [dbo].[SLIDE] ADD  DEFAULT ((0)) FOR [STT]
GO
ALTER TABLE [dbo].[SLIDE] ADD  DEFAULT ((0)) FOR [TRANG_THAI]
GO
ALTER TABLE [dbo].[SLIDE] ADD  DEFAULT ((0)) FOR [NOI_BAT]
GO
ALTER TABLE [dbo].[SLIDE] ADD  DEFAULT (getdate()) FOR [NGAY_DANG]
GO
ALTER TABLE [dbo].[SLIDE] ADD  DEFAULT ((0)) FOR [IS_REMOVE]
GO
ALTER TABLE [dbo].[NhaCungCap]  WITH CHECK ADD  CONSTRAINT [FK_LoaiCVCate] FOREIGN KEY([LoaiIdCv])
REFERENCES [dbo].[Loai_C_V] ([ID])
GO
ALTER TABLE [dbo].[NhaCungCap] CHECK CONSTRAINT [FK_LoaiCVCate]
GO
ALTER TABLE [dbo].[NhaCungCap]  WITH CHECK ADD  CONSTRAINT [FK_NhaCungCap_STT_TT] FOREIGN KEY([ID_TrangThai])
REFERENCES [dbo].[STT_TT] ([ID_STT])
GO
ALTER TABLE [dbo].[NhaCungCap] CHECK CONSTRAINT [FK_NhaCungCap_STT_TT]
GO
/****** Object:  StoredProcedure [dbo].[detailts_hd]    Script Date: 10/02/2023 8:19:34 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[detailts_hd](
@start datetime,
@end datetime
)

as 
begin
select * from HOA_DON where NGAY_MUA between @start and @end

end
GO
/****** Object:  StoredProcedure [dbo].[search_by_id]    Script Date: 10/02/2023 8:19:34 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[search_by_id] (@id INT)
AS
BEGIN
   SELECT *
   FROM Loai_C_V
   WHERE ID = @id
END


EXEC search_by_id @id = 5
GO
/****** Object:  StoredProcedure [dbo].[spDanhSach]    Script Date: 10/02/2023 8:19:34 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDanhSach] (@idCv INT)
AS
BEGIN
  SELECT NhaCungCap.*, Loai_C_V.*, STT_TT.*
FROM NhaCungCap
JOIN Loai_C_V ON NhaCungCap.LoaiIdCv = Loai_C_V.ID
LEFT join STT_TT  ON  NhaCungCap.ID_TrangThai= ID_STT
WHERE NhaCungCap.ID = @idCv
END
GO
/****** Object:  StoredProcedure [dbo].[spDanhSachCv]    Script Date: 10/02/2023 8:19:34 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[spDanhSachCv] @idLoaiCv int
--exec spDanhSachCv 1
as begin
select TenNhaCungCap,
		NhaCungCap.ID,
		TenCongViec,
		NgayDang,
		LuongBatDau,
		HinhAnh,
		LoaiIdCv,
		ID_TrangThai,
		LoaiCV,
		ID_STT,
		Loai_Trang_Thai
		from NhaCungCap
		LEFT join Loai_C_V PL on PL.ID = NhaCungCap.LoaiIdCv
		LEFT join STT_TT ST ON ST.ID_STT = NhaCungCap.ID_TrangThai
		where (@idLoaiCv = 0 or Pl.ID = @idLoaiCv)
		order by TenCongViec
end

GO
USE [master]
GO
ALTER DATABASE [QuanLyCV] SET  READ_WRITE 
GO
