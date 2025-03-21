USE [master]
GO
/****** Object:  Database [MilitaryConscriptionDatabase]    Script Date: 31.01.2025 10:32:52 ******/
CREATE DATABASE [MilitaryConscriptionDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MilitaryConscriptionDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MilitaryConscriptionDatabase.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MilitaryConscriptionDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MilitaryConscriptionDatabase_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MilitaryConscriptionDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET RECOVERY FULL 
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MilitaryConscriptionDatabase', N'ON'
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET QUERY_STORE = ON
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MilitaryConscriptionDatabase]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 31.01.2025 10:32:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Description] [nvarchar](200) NULL,
	[CategoryId] [int] NOT NULL,
	[CategoryKey] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Conscript]    Script Date: 31.01.2025 10:32:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Conscript](
	[PassportId] [int] NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[MiddleName] [nvarchar](100) NULL,
	[BirthDate] [date] NULL,
	[RegistrationDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[PassportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConscriptDocument]    Script Date: 31.01.2025 10:32:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConscriptDocument](
	[ConscriptDocumentId] [int] IDENTITY(1,1) NOT NULL,
	[ConscriptId] [int] NULL,
	[DocumentFile] [varbinary](max) NULL,
	[DocumentName] [nvarchar](200) NULL,
	[Description] [nvarchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[ConscriptDocumentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConscriptionCommission]    Script Date: 31.01.2025 10:32:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConscriptionCommission](
	[ConscriptionCommissionId] [int] IDENTITY(1,1) NOT NULL,
	[CreateDate] [date] NULL,
	[WorksUntilDate] [date] NULL,
	[Protocol] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ConscriptionCommissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConscriptionCommissionEmployee]    Script Date: 31.01.2025 10:32:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConscriptionCommissionEmployee](
	[ConscriptionCommissionEmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[ConscriptionCommissionId] [int] NULL,
	[EmployeeId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ConscriptionCommissionEmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 31.01.2025 10:32:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[PassportId] [int] NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[MiddleName] [nvarchar](100) NULL,
	[BirthDate] [date] NULL,
	[PositionId] [int] NULL,
	[Login] [nvarchar](100) NULL,
	[Password] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[PassportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicalCommission]    Script Date: 31.01.2025 10:32:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicalCommission](
	[MilitaryDraftNoticeId] [int] NOT NULL,
	[HealthComplaints] [nvarchar](500) NULL,
	[Diagnoses] [nvarchar](500) NULL,
	[Note] [nvarchar](200) NULL,
	[Confirmed] [bit] NULL,
	[CategoryId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MilitaryDraftNoticeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MilitaryDraftNotice]    Script Date: 31.01.2025 10:32:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MilitaryDraftNotice](
	[MilitaryDraftNoticeId] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[Address] [nvarchar](200) NULL,
	[ConscriptId] [int] NULL,
	[ConscriptionCommissionId] [int] NULL,
	[Time] [time](7) NULL,
	[ResultId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MilitaryDraftNoticeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Passport]    Script Date: 31.01.2025 10:32:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passport](
	[PassportId] [int] IDENTITY(1,1) NOT NULL,
	[Serial] [int] NULL,
	[Number] [int] NULL,
	[IssuedBy] [nvarchar](200) NULL,
	[IssuedDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[PassportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 31.01.2025 10:32:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Position](
	[PositionId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[PositionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Result]    Script Date: 31.01.2025 10:32:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Result](
	[ResultId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[ResultId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MedicalCommission] ADD  DEFAULT ((0)) FOR [Confirmed]
GO
ALTER TABLE [dbo].[Conscript]  WITH CHECK ADD FOREIGN KEY([PassportId])
REFERENCES [dbo].[Passport] ([PassportId])
GO
ALTER TABLE [dbo].[ConscriptDocument]  WITH CHECK ADD FOREIGN KEY([ConscriptId])
REFERENCES [dbo].[Conscript] ([PassportId])
GO
ALTER TABLE [dbo].[ConscriptionCommissionEmployee]  WITH CHECK ADD FOREIGN KEY([ConscriptionCommissionId])
REFERENCES [dbo].[ConscriptionCommission] ([ConscriptionCommissionId])
GO
ALTER TABLE [dbo].[ConscriptionCommissionEmployee]  WITH CHECK ADD FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([PassportId])
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([PassportId])
REFERENCES [dbo].[Passport] ([PassportId])
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([PositionId])
REFERENCES [dbo].[Position] ([PositionId])
GO
ALTER TABLE [dbo].[MedicalCommission]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[MedicalCommission]  WITH CHECK ADD FOREIGN KEY([MilitaryDraftNoticeId])
REFERENCES [dbo].[MilitaryDraftNotice] ([MilitaryDraftNoticeId])
GO
ALTER TABLE [dbo].[MilitaryDraftNotice]  WITH CHECK ADD FOREIGN KEY([ConscriptId])
REFERENCES [dbo].[Conscript] ([PassportId])
GO
ALTER TABLE [dbo].[MilitaryDraftNotice]  WITH CHECK ADD FOREIGN KEY([ConscriptionCommissionId])
REFERENCES [dbo].[ConscriptionCommission] ([ConscriptionCommissionId])
GO
ALTER TABLE [dbo].[MilitaryDraftNotice]  WITH CHECK ADD FOREIGN KEY([ResultId])
REFERENCES [dbo].[Result] ([ResultId])
GO
USE [master]
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET  READ_WRITE 
GO
