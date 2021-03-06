ALTER TABLE [dbo].[Subscription] DROP CONSTRAINT [FK_Subscription_User]
GO
ALTER TABLE [dbo].[Subscription] DROP CONSTRAINT [FK_Subscription_Route]
GO
ALTER TABLE [dbo].[RoleByUser] DROP CONSTRAINT [FK_RoleByUser_User]
GO
ALTER TABLE [dbo].[RoleByUser] DROP CONSTRAINT [FK_RoleByUser_Role]
GO
ALTER TABLE [dbo].[Position] DROP CONSTRAINT [FK_Position_Route]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2018-11-13 7:38:35 AM ******/
DROP TABLE [dbo].[User]
GO
/****** Object:  Table [dbo].[Subscription]    Script Date: 2018-11-13 7:38:35 AM ******/
DROP TABLE [dbo].[Subscription]
GO
/****** Object:  Table [dbo].[Route]    Script Date: 2018-11-13 7:38:35 AM ******/
DROP TABLE [dbo].[Route]
GO
/****** Object:  Table [dbo].[RoleByUser]    Script Date: 2018-11-13 7:38:35 AM ******/
DROP TABLE [dbo].[RoleByUser]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 2018-11-13 7:38:35 AM ******/
DROP TABLE [dbo].[Role]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 2018-11-13 7:38:35 AM ******/
DROP TABLE [dbo].[Position]
GO
/****** Object:  User [CarPiDb]    Script Date: 2018-11-13 7:38:35 AM ******/
DROP USER [CarPiDb]
GO
/****** Object:  Database [CarPiDb]    Script Date: 2018-11-13 7:38:35 AM ******/
DROP DATABASE [CarPiDb]
GO
/****** Object:  Database [CarPiDb]    Script Date: 2018-11-13 7:38:35 AM ******/
CREATE DATABASE [CarPiDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GAPSeguros', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS2014\MSSQL\DATA\CarPi.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'GAPSeguros_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS2014\MSSQL\DATA\CarPi_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CarPiDb] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CarPiDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CarPiDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CarPiDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CarPiDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CarPiDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CarPiDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [CarPiDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CarPiDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CarPiDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CarPiDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CarPiDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CarPiDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CarPiDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CarPiDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CarPiDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CarPiDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CarPiDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CarPiDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CarPiDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CarPiDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CarPiDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CarPiDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CarPiDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CarPiDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CarPiDb] SET  MULTI_USER 
GO
ALTER DATABASE [CarPiDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CarPiDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CarPiDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CarPiDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CarPiDb] SET DELAYED_DURABILITY = DISABLED 
GO
/****** Object:  User [CarPiDb]    Script Date: 2018-11-13 7:38:35 AM ******/
CREATE USER [CarPiDb] FOR LOGIN [CarPiDb] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [CarPiDb]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 2018-11-13 7:38:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Position](
	[PositionId] [int] IDENTITY(1,1) NOT NULL,
	[RouteId] [int] NOT NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
 CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED 
(
	[PositionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 2018-11-13 7:38:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoleByUser]    Script Date: 2018-11-13 7:38:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleByUser](
	[RoleByUserId] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_RoleByUser] PRIMARY KEY CLUSTERED 
(
	[RoleByUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Route]    Script Date: 2018-11-13 7:38:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Route](
	[RouteId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Route] PRIMARY KEY CLUSTERED 
(
	[RouteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Subscription]    Script Date: 2018-11-13 7:38:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subscription](
	[SubscriptionId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RouteId] [int] NOT NULL,
 CONSTRAINT [PK_Subscription] PRIMARY KEY CLUSTERED 
(
	[SubscriptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 2018-11-13 7:38:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Position] ON 

INSERT [dbo].[Position] ([PositionId], [RouteId], [Latitude], [Longitude]) VALUES (1, 1, 6.1937122, -75.5773487)
INSERT [dbo].[Position] ([PositionId], [RouteId], [Latitude], [Longitude]) VALUES (3, 1, 6.2004108, -75.5732648)
INSERT [dbo].[Position] ([PositionId], [RouteId], [Latitude], [Longitude]) VALUES (5, 1, 6.2049641, -75.5722164)
INSERT [dbo].[Position] ([PositionId], [RouteId], [Latitude], [Longitude]) VALUES (6, 2, 6.1937122, -75.5773487)
INSERT [dbo].[Position] ([PositionId], [RouteId], [Latitude], [Longitude]) VALUES (7, 2, 6.2004108, -75.5732648)
INSERT [dbo].[Position] ([PositionId], [RouteId], [Latitude], [Longitude]) VALUES (8, 2, 6.2049641, -75.5722164)
INSERT [dbo].[Position] ([PositionId], [RouteId], [Latitude], [Longitude]) VALUES (10, 2, 6.201632, -75.567719)
SET IDENTITY_INSERT [dbo].[Position] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleId], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([RoleId], [Name]) VALUES (2, N'User')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[RoleByUser] ON 

INSERT [dbo].[RoleByUser] ([RoleByUserId], [RoleId], [UserId]) VALUES (2, 2, 2)
INSERT [dbo].[RoleByUser] ([RoleByUserId], [RoleId], [UserId]) VALUES (4, 1, 7)
INSERT [dbo].[RoleByUser] ([RoleByUserId], [RoleId], [UserId]) VALUES (7, 1, 1)
INSERT [dbo].[RoleByUser] ([RoleByUserId], [RoleId], [UserId]) VALUES (8, 2, 1)
SET IDENTITY_INSERT [dbo].[RoleByUser] OFF
SET IDENTITY_INSERT [dbo].[Route] ON 

INSERT [dbo].[Route] ([RouteId], [Name]) VALUES (1, N'Trabajo-Casa')
INSERT [dbo].[Route] ([RouteId], [Name]) VALUES (2, N'Casa-Trabajo')
SET IDENTITY_INSERT [dbo].[Route] OFF
SET IDENTITY_INSERT [dbo].[Subscription] ON 

INSERT [dbo].[Subscription] ([SubscriptionId], [UserId], [RouteId]) VALUES (17, 1, 1)
INSERT [dbo].[Subscription] ([SubscriptionId], [UserId], [RouteId]) VALUES (18, 1, 2)
SET IDENTITY_INSERT [dbo].[Subscription] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [Name], [Password]) VALUES (1, N'Mark', N'7c222fb2927d828af22f592134e8932480637c0d')
INSERT [dbo].[User] ([UserId], [Name], [Password]) VALUES (2, N'Luisa', N'7c222fb2927d828af22f592134e8932480637c0d')
INSERT [dbo].[User] ([UserId], [Name], [Password]) VALUES (7, N'rick', N'7110eda4d09e062aa5e4a390b0a572ac0d2c0220')
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Position]  WITH CHECK ADD  CONSTRAINT [FK_Position_Route] FOREIGN KEY([RouteId])
REFERENCES [dbo].[Route] ([RouteId])
GO
ALTER TABLE [dbo].[Position] CHECK CONSTRAINT [FK_Position_Route]
GO
ALTER TABLE [dbo].[RoleByUser]  WITH CHECK ADD  CONSTRAINT [FK_RoleByUser_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[RoleByUser] CHECK CONSTRAINT [FK_RoleByUser_Role]
GO
ALTER TABLE [dbo].[RoleByUser]  WITH CHECK ADD  CONSTRAINT [FK_RoleByUser_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[RoleByUser] CHECK CONSTRAINT [FK_RoleByUser_User]
GO
ALTER TABLE [dbo].[Subscription]  WITH CHECK ADD  CONSTRAINT [FK_Subscription_Route] FOREIGN KEY([RouteId])
REFERENCES [dbo].[Route] ([RouteId])
GO
ALTER TABLE [dbo].[Subscription] CHECK CONSTRAINT [FK_Subscription_Route]
GO
ALTER TABLE [dbo].[Subscription]  WITH CHECK ADD  CONSTRAINT [FK_Subscription_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Subscription] CHECK CONSTRAINT [FK_Subscription_User]
GO
ALTER DATABASE [CarPiDb] SET  READ_WRITE 
GO
