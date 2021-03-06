USE [master]
GO
/****** Object:  Database [MostriVsEroi]    Script Date: 10/1/2021 3:05:53 PM ******/
CREATE DATABASE [MostriVsEroi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MostriVsEroi', FILENAME = N'C:\Users\annamaria.ciasca\MostriVsEroi.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MostriVsEroi_log', FILENAME = N'C:\Users\annamaria.ciasca\MostriVsEroi_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MostriVsEroi] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MostriVsEroi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MostriVsEroi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MostriVsEroi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MostriVsEroi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MostriVsEroi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MostriVsEroi] SET ARITHABORT OFF 
GO
ALTER DATABASE [MostriVsEroi] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MostriVsEroi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MostriVsEroi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MostriVsEroi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MostriVsEroi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MostriVsEroi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MostriVsEroi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MostriVsEroi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MostriVsEroi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MostriVsEroi] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MostriVsEroi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MostriVsEroi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MostriVsEroi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MostriVsEroi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MostriVsEroi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MostriVsEroi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MostriVsEroi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MostriVsEroi] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MostriVsEroi] SET  MULTI_USER 
GO
ALTER DATABASE [MostriVsEroi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MostriVsEroi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MostriVsEroi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MostriVsEroi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MostriVsEroi] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MostriVsEroi] SET QUERY_STORE = OFF
GO
USE [MostriVsEroi]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [MostriVsEroi]
GO
/****** Object:  Table [dbo].[Arma]    Script Date: 10/1/2021 3:05:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Arma](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[PuntiDanno] [int] NOT NULL,
	[IdCategoria] [int] NOT NULL,
 CONSTRAINT [PK_Arma] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 10/1/2021 3:05:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Flag] [bit] NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Eroe]    Script Date: 10/1/2021 3:05:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Eroe](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[IdArma] [int] NOT NULL,
	[Livello] [int] NOT NULL,
	[PuntiVita] [int] NOT NULL,
	[PuntiAccumulati] [int] NOT NULL,
	[IdGiocatore] [int] NOT NULL,
 CONSTRAINT [PK_Eroe] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Giocatore]    Script Date: 10/1/2021 3:05:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Giocatore](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[IsAuthenticated] [bit] NOT NULL,
	[IsAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_Giocatore] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mostro]    Script Date: 10/1/2021 3:05:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mostro](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[IdArma] [int] NOT NULL,
	[Livello] [int] NOT NULL,
	[PuntiVita] [int] NOT NULL,
 CONSTRAINT [PK_Mostro] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Arma] ON 

INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (1, N'Alabarda', 15, 1)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (2, N'Ascia', 8, 1)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (3, N'Mazza', 5, 1)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (4, N'Spada', 10, 1)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (5, N'Spadone', 15, 1)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (6, N'Arco e frecce', 8, 2)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (7, N'Bacchetta', 5, 2)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (8, N'Bastone Magico', 10, 2)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (9, N'Onda d''urto', 15, 2)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (10, N'Pugnale', 5, 2)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (11, N'Discorso noioso', 4, 3)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (12, N'Farneticazione', 7, 3)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (13, N'Imprecazione', 5, 3)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (15, N'Magia nera', 3, 3)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (16, N'Arco', 7, 4)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (17, N'Clava', 5, 4)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (18, N'Spada rotta', 3, 4)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (19, N'Mazza chiodata', 10, 4)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (20, N'Alabarda del drago', 30, 5)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (21, N'Divinazione', 15, 5)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (22, N'Fulmine', 10, 5)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (23, N'Fulmine Celeste', 15, 5)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (24, N'Tempesta', 8, 5)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (25, N'Tempesta Oscura', 15, 5)
SET IDENTITY_INSERT [dbo].[Arma] OFF
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([Id], [Nome], [Flag]) VALUES (1, N'Guerriero ', 0)
INSERT [dbo].[Categoria] ([Id], [Nome], [Flag]) VALUES (2, N'Mago', 0)
INSERT [dbo].[Categoria] ([Id], [Nome], [Flag]) VALUES (3, N'Cultista', 1)
INSERT [dbo].[Categoria] ([Id], [Nome], [Flag]) VALUES (4, N'Orco', 1)
INSERT [dbo].[Categoria] ([Id], [Nome], [Flag]) VALUES (5, N'Signore del Male', 1)
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Eroe] ON 

INSERT [dbo].[Eroe] ([Id], [Nome], [IdCategoria], [IdArma], [Livello], [PuntiVita], [PuntiAccumulati], [IdGiocatore]) VALUES (1, N'Frodo', 1, 1, 1, 20, 20, 1)
INSERT [dbo].[Eroe] ([Id], [Nome], [IdCategoria], [IdArma], [Livello], [PuntiVita], [PuntiAccumulati], [IdGiocatore]) VALUES (2, N'Gandalf ', 2, 9, 3, 60, 50, 1)
INSERT [dbo].[Eroe] ([Id], [Nome], [IdCategoria], [IdArma], [Livello], [PuntiVita], [PuntiAccumulati], [IdGiocatore]) VALUES (3, N'Saruman', 2, 8, 4, 80, 90, 2)
INSERT [dbo].[Eroe] ([Id], [Nome], [IdCategoria], [IdArma], [Livello], [PuntiVita], [PuntiAccumulati], [IdGiocatore]) VALUES (4, N'Aragorn', 1, 4, 2, 40, 30, 3)
INSERT [dbo].[Eroe] ([Id], [Nome], [IdCategoria], [IdArma], [Livello], [PuntiVita], [PuntiAccumulati], [IdGiocatore]) VALUES (5, N'Arwen', 1, 2, 2, 40, 30, 3)
INSERT [dbo].[Eroe] ([Id], [Nome], [IdCategoria], [IdArma], [Livello], [PuntiVita], [PuntiAccumulati], [IdGiocatore]) VALUES (6, N'Harry Potter', 2, 7, 1, 20, 25, 4)
INSERT [dbo].[Eroe] ([Id], [Nome], [IdCategoria], [IdArma], [Livello], [PuntiVita], [PuntiAccumulati], [IdGiocatore]) VALUES (7, N'Hermione', 2, 7, 1, 20, 0, 1)
INSERT [dbo].[Eroe] ([Id], [Nome], [IdCategoria], [IdArma], [Livello], [PuntiVita], [PuntiAccumulati], [IdGiocatore]) VALUES (10, N'Queen', 1, 5, 1, 20, 0, 4)
SET IDENTITY_INSERT [dbo].[Eroe] OFF
GO
SET IDENTITY_INSERT [dbo].[Giocatore] ON 

INSERT [dbo].[Giocatore] ([Id], [Nome], [Password], [IsAuthenticated], [IsAdmin]) VALUES (1, N'Annamaria', N'Anna00', 1, 1)
INSERT [dbo].[Giocatore] ([Id], [Nome], [Password], [IsAuthenticated], [IsAdmin]) VALUES (2, N'Mario', N'Mario77 ', 1, 0)
INSERT [dbo].[Giocatore] ([Id], [Nome], [Password], [IsAuthenticated], [IsAdmin]) VALUES (3, N'Luigi', N'Gigi11', 1, 0)
INSERT [dbo].[Giocatore] ([Id], [Nome], [Password], [IsAuthenticated], [IsAdmin]) VALUES (4, N'Maria', N'1234', 1, 1)
INSERT [dbo].[Giocatore] ([Id], [Nome], [Password], [IsAuthenticated], [IsAdmin]) VALUES (5, N'Sara', N'5678', 1, 0)
INSERT [dbo].[Giocatore] ([Id], [Nome], [Password], [IsAuthenticated], [IsAdmin]) VALUES (7, N'Francesca', N'Fra00', 1, 0)
INSERT [dbo].[Giocatore] ([Id], [Nome], [Password], [IsAuthenticated], [IsAdmin]) VALUES (12, N'Marco', N'Marco345', 1, 0)
INSERT [dbo].[Giocatore] ([Id], [Nome], [Password], [IsAuthenticated], [IsAdmin]) VALUES (13, N'Michael', N'000', 1, 0)
SET IDENTITY_INSERT [dbo].[Giocatore] OFF
GO
SET IDENTITY_INSERT [dbo].[Mostro] ON 

INSERT [dbo].[Mostro] ([Id], [Nome], [IdCategoria], [IdArma], [Livello], [PuntiVita]) VALUES (1, N'Gollum', 4, 15, 1, 20)
INSERT [dbo].[Mostro] ([Id], [Nome], [IdCategoria], [IdArma], [Livello], [PuntiVita]) VALUES (2, N'Voldemort', 5, 19, 5, 100)
INSERT [dbo].[Mostro] ([Id], [Nome], [IdCategoria], [IdArma], [Livello], [PuntiVita]) VALUES (3, N'Cattivo', 3, 11, 1, 20)
INSERT [dbo].[Mostro] ([Id], [Nome], [IdCategoria], [IdArma], [Livello], [PuntiVita]) VALUES (7, N'Berto', 4, 16, 2, 40)
INSERT [dbo].[Mostro] ([Id], [Nome], [IdCategoria], [IdArma], [Livello], [PuntiVita]) VALUES (8, N'Franco', 3, 11, 2, 40)
SET IDENTITY_INSERT [dbo].[Mostro] OFF
GO
ALTER TABLE [dbo].[Arma]  WITH CHECK ADD  CONSTRAINT [FK_Arma_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([Id])
GO
ALTER TABLE [dbo].[Arma] CHECK CONSTRAINT [FK_Arma_Categoria]
GO
ALTER TABLE [dbo].[Categoria]  WITH CHECK ADD  CONSTRAINT [FK_Categoria_Categoria] FOREIGN KEY([Id])
REFERENCES [dbo].[Categoria] ([Id])
GO
ALTER TABLE [dbo].[Categoria] CHECK CONSTRAINT [FK_Categoria_Categoria]
GO
ALTER TABLE [dbo].[Eroe]  WITH CHECK ADD  CONSTRAINT [FK_Eroe_Arma] FOREIGN KEY([IdArma])
REFERENCES [dbo].[Arma] ([Id])
GO
ALTER TABLE [dbo].[Eroe] CHECK CONSTRAINT [FK_Eroe_Arma]
GO
ALTER TABLE [dbo].[Eroe]  WITH CHECK ADD  CONSTRAINT [FK_Eroe_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([Id])
GO
ALTER TABLE [dbo].[Eroe] CHECK CONSTRAINT [FK_Eroe_Categoria]
GO
ALTER TABLE [dbo].[Eroe]  WITH CHECK ADD  CONSTRAINT [FK_Eroe_Giocatore] FOREIGN KEY([IdGiocatore])
REFERENCES [dbo].[Giocatore] ([Id])
GO
ALTER TABLE [dbo].[Eroe] CHECK CONSTRAINT [FK_Eroe_Giocatore]
GO
ALTER TABLE [dbo].[Mostro]  WITH CHECK ADD  CONSTRAINT [FK_Mostro_Arma] FOREIGN KEY([IdArma])
REFERENCES [dbo].[Arma] ([Id])
GO
ALTER TABLE [dbo].[Mostro] CHECK CONSTRAINT [FK_Mostro_Arma]
GO
ALTER TABLE [dbo].[Mostro]  WITH CHECK ADD  CONSTRAINT [FK_Mostro_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([Id])
GO
ALTER TABLE [dbo].[Mostro] CHECK CONSTRAINT [FK_Mostro_Categoria]
GO
USE [master]
GO
ALTER DATABASE [MostriVsEroi] SET  READ_WRITE 
GO
