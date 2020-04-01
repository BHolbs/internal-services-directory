USE [master]
GO
/****** Object:  Database [ContosoUniversityData]    Script Date: 3/31/2020 3:32:36 PM ******/
CREATE DATABASE [ContosoUniversityData]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ContosoUniversityData', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ContosoUniversityData.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ContosoUniversityData_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ContosoUniversityData_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ContosoUniversityData] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ContosoUniversityData].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ContosoUniversityData] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ContosoUniversityData] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ContosoUniversityData] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ContosoUniversityData] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ContosoUniversityData] SET ARITHABORT OFF 
GO
ALTER DATABASE [ContosoUniversityData] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ContosoUniversityData] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ContosoUniversityData] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ContosoUniversityData] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ContosoUniversityData] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ContosoUniversityData] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ContosoUniversityData] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ContosoUniversityData] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ContosoUniversityData] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ContosoUniversityData] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ContosoUniversityData] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ContosoUniversityData] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ContosoUniversityData] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ContosoUniversityData] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ContosoUniversityData] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ContosoUniversityData] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ContosoUniversityData] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ContosoUniversityData] SET RECOVERY FULL 
GO
ALTER DATABASE [ContosoUniversityData] SET  MULTI_USER 
GO
ALTER DATABASE [ContosoUniversityData] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ContosoUniversityData] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ContosoUniversityData] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ContosoUniversityData] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ContosoUniversityData] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ContosoUniversityData', N'ON'
GO
ALTER DATABASE [ContosoUniversityData] SET QUERY_STORE = OFF
GO
USE [ContosoUniversityData]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 3/31/2020 3:32:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Credits] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enrollment]    Script Date: 3/31/2020 3:32:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrollment](
	[EnrollmentID] [int] IDENTITY(1,1) NOT NULL,
	[Grade] [decimal](3, 2) NULL,
	[CourseID] [int] NOT NULL,
	[StudentID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EnrollmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 3/31/2020 3:32:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[EnrollmentDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Enrollment]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Enrollment_dbo.Course_CourseID] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([CourseID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Enrollment] CHECK CONSTRAINT [FK_dbo.Enrollment_dbo.Course_CourseID]
GO
ALTER TABLE [dbo].[Enrollment]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Enrollment_dbo.Student_StudentID] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([StudentID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Enrollment] CHECK CONSTRAINT [FK_dbo.Enrollment_dbo.Student_StudentID]
GO
USE [master]
GO
ALTER DATABASE [ContosoUniversityData] SET  READ_WRITE 
GO
