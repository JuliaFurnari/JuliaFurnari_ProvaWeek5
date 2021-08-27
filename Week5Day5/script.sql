USE [master]
GO
/****** Object:  Database [Agenda]    Script Date: 27-Aug-21 2:51:31 PM ******/
CREATE DATABASE [Agenda]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Agenda', FILENAME = N'C:\Users\julia.furnari\Agenda.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Agenda_log', FILENAME = N'C:\Users\julia.furnari\Agenda_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Agenda] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Agenda].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Agenda] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Agenda] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Agenda] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Agenda] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Agenda] SET ARITHABORT OFF 
GO
ALTER DATABASE [Agenda] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Agenda] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Agenda] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Agenda] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Agenda] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Agenda] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Agenda] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Agenda] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Agenda] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Agenda] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Agenda] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Agenda] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Agenda] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Agenda] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Agenda] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Agenda] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Agenda] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Agenda] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Agenda] SET  MULTI_USER 
GO
ALTER DATABASE [Agenda] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Agenda] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Agenda] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Agenda] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Agenda] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Agenda] SET QUERY_STORE = OFF
GO
USE [Agenda]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Agenda]
GO
/****** Object:  Table [dbo].[Impegno]    Script Date: 27-Aug-21 2:51:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Impegno](
	[Titolo] [nvarchar](50) NOT NULL,
	[Descrizione] [nvarchar](50) NOT NULL,
	[DataDiScadenza] [date] NOT NULL,
	[Importanza] [nvarchar](50) NOT NULL,
	[Eseguito] [bit] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Impegno] ON 

INSERT [dbo].[Impegno] ([Titolo], [Descrizione], [DataDiScadenza], [Importanza], [Eseguito], [Id]) VALUES (N'Corsi', N'Corso sicurezza', CAST(N'2021-08-27' AS Date), N'Bassa', 1, 1)
INSERT [dbo].[Impegno] ([Titolo], [Descrizione], [DataDiScadenza], [Importanza], [Eseguito], [Id]) VALUES (N'Impegno1', N'Descrizione1', CAST(N'2021-08-30' AS Date), N'Bassa', 1, 2)
SET IDENTITY_INSERT [dbo].[Impegno] OFF
GO
ALTER TABLE [dbo].[Impegno]  WITH CHECK ADD  CONSTRAINT [CHK_Importanza] CHECK  (([Importanza]='Alta' OR [Importanza]='Media' OR [Importanza]='Bassa'))
GO
ALTER TABLE [dbo].[Impegno] CHECK CONSTRAINT [CHK_Importanza]
GO
USE [master]
GO
ALTER DATABASE [Agenda] SET  READ_WRITE 
GO
