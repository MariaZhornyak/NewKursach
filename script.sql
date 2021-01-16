USE [master]
GO
/****** Object:  Database [Kursach]    Script Date: 16.01.2021 15:28:41 ******/
CREATE DATABASE [Kursach]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Kursach', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Kursach.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Kursach_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Kursach_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Kursach] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Kursach].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Kursach] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Kursach] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Kursach] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Kursach] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Kursach] SET ARITHABORT OFF 
GO
ALTER DATABASE [Kursach] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Kursach] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Kursach] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Kursach] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Kursach] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Kursach] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Kursach] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Kursach] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Kursach] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Kursach] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Kursach] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Kursach] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Kursach] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Kursach] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Kursach] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Kursach] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Kursach] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Kursach] SET RECOVERY FULL 
GO
ALTER DATABASE [Kursach] SET  MULTI_USER 
GO
ALTER DATABASE [Kursach] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Kursach] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Kursach] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Kursach] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Kursach] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Kursach', N'ON'
GO
ALTER DATABASE [Kursach] SET QUERY_STORE = OFF
GO
USE [Kursach]
GO
/****** Object:  Table [dbo].[Visits]    Script Date: 16.01.2021 15:28:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Visits](
	[VisitID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NULL,
	[SpecialityID] [int] NULL,
 CONSTRAINT [PK_Visits] PRIMARY KEY CLUSTERED 
(
	[VisitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 16.01.2021 15:28:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[BeginningYear] [date] NULL,
	[DOB] [date] NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeSpeciality]    Script Date: 16.01.2021 15:28:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeSpeciality](
	[SpecialityID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NULL,
	[ServiceID] [int] NULL,
 CONSTRAINT [PK_EmployeeSpeciality] PRIMARY KEY CLUSTERED 
(
	[SpecialityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 16.01.2021 15:28:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[ServiceID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceName] [nvarchar](50) NULL,
	[Duration] [float] NULL,
	[Price] [smallmoney] NULL,
	[CategoryID] [int] NULL,
 CONSTRAINT [PK_Services_1] PRIMARY KEY CLUSTERED 
(
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Доходы сотрудников]    Script Date: 16.01.2021 15:28:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Доходы сотрудников]
AS
SELECT        TOP (100) PERCENT dbo.EmployeeSpeciality.EmployeeID, dbo.Employees.EmployeeName, SUM(dbo.Services.Price) AS Profit, COUNT(dbo.Visits.VisitID) AS NumberOfVisits
FROM            dbo.Employees INNER JOIN
                         dbo.EmployeeSpeciality ON dbo.Employees.EmployeeID = dbo.EmployeeSpeciality.EmployeeID INNER JOIN
                         dbo.Services ON dbo.EmployeeSpeciality.ServiceID = dbo.Services.ServiceID INNER JOIN
                         dbo.Visits ON dbo.EmployeeSpeciality.SpecialityID = dbo.Visits.SpecialityID
GROUP BY dbo.Employees.EmployeeName, dbo.EmployeeSpeciality.EmployeeID
GO
/****** Object:  View [dbo].[Информация про сотрудников]    Script Date: 16.01.2021 15:28:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Информация про сотрудников]
AS
SELECT        EmployeeID, EmployeeName, PhoneNumber, DATEDIFF(year, BeginningYear, GETDATE()) AS WorkingExperience, DOB
FROM            dbo.Employees
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 16.01.2021 15:28:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 16.01.2021 15:28:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[ClientID] [int] IDENTITY(1,1) NOT NULL,
	[ClientName] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[DOB] [date] NULL,
	[Email] [nvarchar](50) NULL,
	[WayOfAttraction] [nvarchar](50) NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SchedulePoint]    Script Date: 16.01.2021 15:28:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SchedulePoint](
	[PointID] [int] IDENTITY(1,1) NOT NULL,
	[VisitID] [int] NULL,
	[EmployeeID] [int] NULL,
	[StartTime] [datetime] NULL,
 CONSTRAINT [PK_SchedulePoint] PRIMARY KEY CLUSTERED 
(
	[PointID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EmployeeSpeciality]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeSpeciality_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeSpeciality] CHECK CONSTRAINT [FK_EmployeeSpeciality_Employees]
GO
ALTER TABLE [dbo].[EmployeeSpeciality]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeSpeciality_Services] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Services] ([ServiceID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeSpeciality] CHECK CONSTRAINT [FK_EmployeeSpeciality_Services]
GO
ALTER TABLE [dbo].[SchedulePoint]  WITH CHECK ADD  CONSTRAINT [FK_SchedulePoint_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SchedulePoint] CHECK CONSTRAINT [FK_SchedulePoint_Employees]
GO
ALTER TABLE [dbo].[SchedulePoint]  WITH CHECK ADD  CONSTRAINT [FK_SchedulePoint_Visits] FOREIGN KEY([VisitID])
REFERENCES [dbo].[Visits] ([VisitID])
GO
ALTER TABLE [dbo].[SchedulePoint] CHECK CONSTRAINT [FK_SchedulePoint_Visits]
GO
ALTER TABLE [dbo].[Services]  WITH CHECK ADD  CONSTRAINT [FK_Services_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Services] CHECK CONSTRAINT [FK_Services_Categories]
GO
ALTER TABLE [dbo].[Visits]  WITH CHECK ADD  CONSTRAINT [FK_Visits_Clients] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Clients] ([ClientID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Visits] CHECK CONSTRAINT [FK_Visits_Clients]
GO
ALTER TABLE [dbo].[Visits]  WITH CHECK ADD  CONSTRAINT [FK_Visits_EmployeeSpeciality] FOREIGN KEY([SpecialityID])
REFERENCES [dbo].[EmployeeSpeciality] ([SpecialityID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Visits] CHECK CONSTRAINT [FK_Visits_EmployeeSpeciality]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[31] 4[33] 2[8] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Employees"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 212
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "EmployeeSpeciality"
            Begin Extent = 
               Top = 18
               Left = 273
               Bottom = 131
               Right = 447
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Services"
            Begin Extent = 
               Top = 125
               Left = 481
               Bottom = 255
               Right = 655
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Visits"
            Begin Extent = 
               Top = 0
               Left = 547
               Bottom = 113
               Right = 721
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 3840
         Alias = 1455
         Table = 1755
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1710
         SortOrder = 2070
         GroupBy = 1350
         Filter = 1350
         Or = 1635
         Or = 1350
         Or = 1350
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Доходы сотрудников'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Доходы сотрудников'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Доходы сотрудников'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[20] 2[1] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Employees"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 212
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Информация про сотрудников'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Информация про сотрудников'
GO
USE [master]
GO
ALTER DATABASE [Kursach] SET  READ_WRITE 
GO
