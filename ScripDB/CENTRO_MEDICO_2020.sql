USE [master]
GO
/****** Object:  Database [CENTRO_MEDICO_2020]    Script Date: 17/11/2020 16:34:15 ******/
CREATE DATABASE [CENTRO_MEDICO_2020]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CENTRO_MEDICO_2020', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CENTRO_MEDICO_2020.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CENTRO_MEDICO_2020_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CENTRO_MEDICO_2020_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CENTRO_MEDICO_2020] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CENTRO_MEDICO_2020].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CENTRO_MEDICO_2020] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CENTRO_MEDICO_2020] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CENTRO_MEDICO_2020] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CENTRO_MEDICO_2020] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CENTRO_MEDICO_2020] SET ARITHABORT OFF 
GO
ALTER DATABASE [CENTRO_MEDICO_2020] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CENTRO_MEDICO_2020] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CENTRO_MEDICO_2020] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CENTRO_MEDICO_2020] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CENTRO_MEDICO_2020] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CENTRO_MEDICO_2020] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CENTRO_MEDICO_2020] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CENTRO_MEDICO_2020] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CENTRO_MEDICO_2020] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CENTRO_MEDICO_2020] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CENTRO_MEDICO_2020] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CENTRO_MEDICO_2020] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CENTRO_MEDICO_2020] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CENTRO_MEDICO_2020] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CENTRO_MEDICO_2020] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CENTRO_MEDICO_2020] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CENTRO_MEDICO_2020] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CENTRO_MEDICO_2020] SET RECOVERY FULL 
GO
ALTER DATABASE [CENTRO_MEDICO_2020] SET  MULTI_USER 
GO
ALTER DATABASE [CENTRO_MEDICO_2020] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CENTRO_MEDICO_2020] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CENTRO_MEDICO_2020] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CENTRO_MEDICO_2020] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CENTRO_MEDICO_2020] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CENTRO_MEDICO_2020] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CENTRO_MEDICO_2020', N'ON'
GO
ALTER DATABASE [CENTRO_MEDICO_2020] SET QUERY_STORE = OFF
GO
USE [CENTRO_MEDICO_2020]
GO
/****** Object:  Table [dbo].[Anexos]    Script Date: 17/11/2020 16:34:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Anexos](
	[idAnexo] [int] IDENTITY(1,1) NOT NULL,
	[IdPaciente] [int] NULL,
	[ruta] [varchar](250) NULL,
	[Extencion] [varchar](50) NULL,
	[NombreArchivo] [varchar](250) NULL,
	[fechaCreacion] [datetime] NULL,
	[eliminado] [bit] NULL,
	[idEstado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idAnexo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CitasMedicas]    Script Date: 17/11/2020 16:34:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CitasMedicas](
	[idCita] [int] IDENTITY(1,1) NOT NULL,
	[idPaciente] [int] NULL,
	[idMedico] [int] NULL,
	[idConsulta] [int] NULL,
	[fechaCita] [datetime] NULL,
	[fechaFinalizacion] [datetime] NULL,
	[horaCita] [datetime] NULL,
	[fechaNuevaCita] [datetime] NULL,
	[comentario] [varchar](250) NULL,
	[fechaCreacion] [datetime] NULL,
	[fechaModificacion] [datetime] NULL,
	[userCreacion] [int] NULL,
	[userModificacion] [int] NULL,
	[eliminado] [bit] NULL,
	[idEstado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idCita] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ControlPacientes]    Script Date: 17/11/2020 16:34:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ControlPacientes](
	[idPaciente] [int] IDENTITY(1,1) NOT NULL,
	[nombrePaciente] [varchar](50) NULL,
	[fechaNacimiento] [datetime] NULL,
	[sexo] [varchar](10) NULL,
	[tipoSangre] [int] NULL,
	[edad] [varchar](25) NULL,
	[dpi] [varchar](20) NULL,
	[numTel1] [varchar](15) NULL,
	[numTel2] [varchar](15) NULL,
	[correo] [varchar](50) NULL,
	[fechaCreacion] [datetime] NULL,
	[fechaModificacion] [datetime] NULL,
	[userCreacion] [int] NULL,
	[userModificacion] [int] NULL,
	[eliminado] [bit] NULL,
	[idEstado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idPaciente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ESTADOS]    Script Date: 17/11/2020 16:34:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ESTADOS](
	[IdEstado] [int] IDENTITY(1,1) NOT NULL,
	[nombreEstado] [varchar](25) NOT NULL,
	[fechaCreacion] [datetime] NULL,
	[usuarioCreacion] [int] NULL,
	[eliminado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegistroMedicos]    Script Date: 17/11/2020 16:34:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegistroMedicos](
	[idMedico] [int] IDENTITY(1,1) NOT NULL,
	[nombreMedico] [varchar](50) NULL,
	[Colegiado] [varchar](50) NULL,
	[Especialidad] [varchar](100) NULL,
	[sexo] [varchar](10) NULL,
	[fechaNacimiento] [datetime] NULL,
	[fechaCreacion] [datetime] NULL,
	[fechaModificacion] [datetime] NULL,
	[userCreacion] [int] NULL,
	[userModificacion] [int] NULL,
	[eliminado] [bit] NULL,
	[idEstado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idMedico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoConsulta]    Script Date: 17/11/2020 16:34:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoConsulta](
	[idConsulta] [int] IDENTITY(1,1) NOT NULL,
	[nombreConsulta] [varchar](25) NOT NULL,
	[fechaCreacion] [datetime] NULL,
	[usuarioCreacion] [int] NULL,
	[eliminado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idConsulta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Anexos] ON 

INSERT [dbo].[Anexos] ([idAnexo], [IdPaciente], [ruta], [Extencion], [NombreArchivo], [fechaCreacion], [eliminado], [idEstado]) VALUES (1, 2, N'C:\\MBConfig\-ANEXO-6-11-2020-165032.jpg', N'.jpg', N'-ANEXO-6-11-2020-165032.jpg', CAST(N'2020-11-06T16:50:35.253' AS DateTime), 0, 1)
INSERT [dbo].[Anexos] ([idAnexo], [IdPaciente], [ruta], [Extencion], [NombreArchivo], [fechaCreacion], [eliminado], [idEstado]) VALUES (2, 15, N'C:\\MBConfig\-ANEXO-6-11-2020-224905.jpg', N'.jpg', N'-ANEXO-6-11-2020-224905.jpg', CAST(N'2020-11-06T22:49:05.330' AS DateTime), 1, 1)
INSERT [dbo].[Anexos] ([idAnexo], [IdPaciente], [ruta], [Extencion], [NombreArchivo], [fechaCreacion], [eliminado], [idEstado]) VALUES (3, 1, N'C:\\MBConfig\-ANEXO-6-11-2020-225412.png', N'.png', N'-ANEXO-6-11-2020-225412.png', CAST(N'2020-11-06T22:54:12.370' AS DateTime), 1, 1)
INSERT [dbo].[Anexos] ([idAnexo], [IdPaciente], [ruta], [Extencion], [NombreArchivo], [fechaCreacion], [eliminado], [idEstado]) VALUES (4, 2, N'C:\\MBConfig\-ANEXO-17-11-2020-153607.pdf', N'.pdf', N'-ANEXO-17-11-2020-153607.pdf', CAST(N'2020-11-17T15:36:07.377' AS DateTime), 1, 1)
INSERT [dbo].[Anexos] ([idAnexo], [IdPaciente], [ruta], [Extencion], [NombreArchivo], [fechaCreacion], [eliminado], [idEstado]) VALUES (5, 2, N'C:\\MBConfig\-ANEXO-17-11-2020-154107.txt', N'.txt', N'-ANEXO-17-11-2020-154107.txt', CAST(N'2020-11-17T15:41:07.797' AS DateTime), 1, 1)
INSERT [dbo].[Anexos] ([idAnexo], [IdPaciente], [ruta], [Extencion], [NombreArchivo], [fechaCreacion], [eliminado], [idEstado]) VALUES (6, 2, N'C:\\MBConfig\-ANEXO-17-11-2020-154715.txt', N'.txt', N'-ANEXO-17-11-2020-154715.txt', CAST(N'2020-11-17T15:47:15.130' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[Anexos] OFF
GO
SET IDENTITY_INSERT [dbo].[CitasMedicas] ON 

INSERT [dbo].[CitasMedicas] ([idCita], [idPaciente], [idMedico], [idConsulta], [fechaCita], [fechaFinalizacion], [horaCita], [fechaNuevaCita], [comentario], [fechaCreacion], [fechaModificacion], [userCreacion], [userModificacion], [eliminado], [idEstado]) VALUES (4, 1, 4, 3, CAST(N'2020-11-15T00:00:00.000' AS DateTime), CAST(N'2020-11-17T17:04:00.000' AS DateTime), CAST(N'2020-11-15T09:00:00.000' AS DateTime), CAST(N'2020-11-19T00:00:00.000' AS DateTime), N'Presenta dolores musculares', CAST(N'2020-11-15T10:07:00.000' AS DateTime), CAST(N'2020-11-17T16:28:00.000' AS DateTime), NULL, NULL, 0, 5)
INSERT [dbo].[CitasMedicas] ([idCita], [idPaciente], [idMedico], [idConsulta], [fechaCita], [fechaFinalizacion], [horaCita], [fechaNuevaCita], [comentario], [fechaCreacion], [fechaModificacion], [userCreacion], [userModificacion], [eliminado], [idEstado]) VALUES (5, 1, 4, 2, CAST(N'2020-11-15T00:00:00.000' AS DateTime), NULL, CAST(N'2020-11-15T10:20:00.000' AS DateTime), CAST(N'2020-12-11T00:00:00.000' AS DateTime), N'Presenta', CAST(N'2020-11-15T10:07:00.000' AS DateTime), CAST(N'2020-11-17T16:18:00.000' AS DateTime), NULL, NULL, 0, 6)
INSERT [dbo].[CitasMedicas] ([idCita], [idPaciente], [idMedico], [idConsulta], [fechaCita], [fechaFinalizacion], [horaCita], [fechaNuevaCita], [comentario], [fechaCreacion], [fechaModificacion], [userCreacion], [userModificacion], [eliminado], [idEstado]) VALUES (7, 1, 6, 2, CAST(N'2020-11-15T00:00:00.000' AS DateTime), NULL, CAST(N'2020-11-15T12:30:00.000' AS DateTime), NULL, N'Laboratorio Clinica No. 2', CAST(N'2020-11-15T10:15:00.000' AS DateTime), NULL, NULL, NULL, 0, 4)
INSERT [dbo].[CitasMedicas] ([idCita], [idPaciente], [idMedico], [idConsulta], [fechaCita], [fechaFinalizacion], [horaCita], [fechaNuevaCita], [comentario], [fechaCreacion], [fechaModificacion], [userCreacion], [userModificacion], [eliminado], [idEstado]) VALUES (8, 17, 6, 3, CAST(N'2020-11-16T00:00:00.000' AS DateTime), NULL, CAST(N'2020-11-15T11:00:00.000' AS DateTime), NULL, N'Obtener resultados de examenes de orina ', CAST(N'2020-11-15T10:21:00.000' AS DateTime), NULL, NULL, NULL, 0, 4)
INSERT [dbo].[CitasMedicas] ([idCita], [idPaciente], [idMedico], [idConsulta], [fechaCita], [fechaFinalizacion], [horaCita], [fechaNuevaCita], [comentario], [fechaCreacion], [fechaModificacion], [userCreacion], [userModificacion], [eliminado], [idEstado]) VALUES (9, 10, 5, 1, CAST(N'2020-11-17T00:00:00.000' AS DateTime), NULL, CAST(N'2020-11-15T10:30:00.000' AS DateTime), NULL, N'Cansancio mental, dolor bajo el costado ', CAST(N'2020-11-15T22:21:00.000' AS DateTime), NULL, NULL, NULL, 0, 4)
INSERT [dbo].[CitasMedicas] ([idCita], [idPaciente], [idMedico], [idConsulta], [fechaCita], [fechaFinalizacion], [horaCita], [fechaNuevaCita], [comentario], [fechaCreacion], [fechaModificacion], [userCreacion], [userModificacion], [eliminado], [idEstado]) VALUES (10, 21, 4, 1, CAST(N'2020-11-20T00:00:00.000' AS DateTime), NULL, CAST(N'2020-11-17T11:30:00.000' AS DateTime), NULL, N'Revisión de signos vitales, peso, chequeo de azúcar, revisión de visión, oídos y garganta ', CAST(N'2020-11-17T09:19:00.000' AS DateTime), CAST(N'2020-11-17T14:54:00.000' AS DateTime), NULL, NULL, 0, 3)
SET IDENTITY_INSERT [dbo].[CitasMedicas] OFF
GO
SET IDENTITY_INSERT [dbo].[ControlPacientes] ON 

INSERT [dbo].[ControlPacientes] ([idPaciente], [nombrePaciente], [fechaNacimiento], [sexo], [tipoSangre], [edad], [dpi], [numTel1], [numTel2], [correo], [fechaCreacion], [fechaModificacion], [userCreacion], [userModificacion], [eliminado], [idEstado]) VALUES (1, N'Hector Sandarty', CAST(N'2012-06-18T00:00:00.000' AS DateTime), N'Masculino', 1, N'25', N'2052853760101', N'32659865', N'35326598', N'sammy.kazzu@gmail.com', CAST(N'2012-06-18T22:34:09.000' AS DateTime), NULL, 1, NULL, 1, 0)
INSERT [dbo].[ControlPacientes] ([idPaciente], [nombrePaciente], [fechaNacimiento], [sexo], [tipoSangre], [edad], [dpi], [numTel1], [numTel2], [correo], [fechaCreacion], [fechaModificacion], [userCreacion], [userModificacion], [eliminado], [idEstado]) VALUES (2, N'Alex tesla', CAST(N'2012-06-18T22:34:09.000' AS DateTime), N'Femenino', 1, N'25', N'2052853760101', N'56235689', N'45895623', N'alex85.m@gmail.com', CAST(N'2012-06-18T22:34:09.000' AS DateTime), NULL, 1, NULL, 0, 1)
INSERT [dbo].[ControlPacientes] ([idPaciente], [nombrePaciente], [fechaNacimiento], [sexo], [tipoSangre], [edad], [dpi], [numTel1], [numTel2], [correo], [fechaCreacion], [fechaModificacion], [userCreacion], [userModificacion], [eliminado], [idEstado]) VALUES (3, N'Julio', CAST(N'2012-06-18T00:00:00.000' AS DateTime), N'Masculino', NULL, NULL, N'32132132132132', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0)
INSERT [dbo].[ControlPacientes] ([idPaciente], [nombrePaciente], [fechaNacimiento], [sexo], [tipoSangre], [edad], [dpi], [numTel1], [numTel2], [correo], [fechaCreacion], [fechaModificacion], [userCreacion], [userModificacion], [eliminado], [idEstado]) VALUES (4, N'Tomas', CAST(N'2012-06-18T22:34:09.000' AS DateTime), N'Masculino', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0)
INSERT [dbo].[ControlPacientes] ([idPaciente], [nombrePaciente], [fechaNacimiento], [sexo], [tipoSangre], [edad], [dpi], [numTel1], [numTel2], [correo], [fechaCreacion], [fechaModificacion], [userCreacion], [userModificacion], [eliminado], [idEstado]) VALUES (5, N'Julio', CAST(N'2012-06-18T22:34:09.000' AS DateTime), N'Masculino', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0)
INSERT [dbo].[ControlPacientes] ([idPaciente], [nombrePaciente], [fechaNacimiento], [sexo], [tipoSangre], [edad], [dpi], [numTel1], [numTel2], [correo], [fechaCreacion], [fechaModificacion], [userCreacion], [userModificacion], [eliminado], [idEstado]) VALUES (6, N'Madgalena', CAST(N'2012-06-18T22:34:09.000' AS DateTime), N'Femenino', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0)
INSERT [dbo].[ControlPacientes] ([idPaciente], [nombrePaciente], [fechaNacimiento], [sexo], [tipoSangre], [edad], [dpi], [numTel1], [numTel2], [correo], [fechaCreacion], [fechaModificacion], [userCreacion], [userModificacion], [eliminado], [idEstado]) VALUES (7, N'Ignacio Martinez Lopez', CAST(N'2012-06-18T00:00:00.000' AS DateTime), N'Masculino', NULL, NULL, N'2058968740102', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[ControlPacientes] ([idPaciente], [nombrePaciente], [fechaNacimiento], [sexo], [tipoSangre], [edad], [dpi], [numTel1], [numTel2], [correo], [fechaCreacion], [fechaModificacion], [userCreacion], [userModificacion], [eliminado], [idEstado]) VALUES (8, N'Edgar', CAST(N'2012-06-18T22:34:09.000' AS DateTime), N'Masculino', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0)
INSERT [dbo].[ControlPacientes] ([idPaciente], [nombrePaciente], [fechaNacimiento], [sexo], [tipoSangre], [edad], [dpi], [numTel1], [numTel2], [correo], [fechaCreacion], [fechaModificacion], [userCreacion], [userModificacion], [eliminado], [idEstado]) VALUES (9, N'Mateo', CAST(N'2012-06-18T22:34:09.000' AS DateTime), N'Masculino', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0)
INSERT [dbo].[ControlPacientes] ([idPaciente], [nombrePaciente], [fechaNacimiento], [sexo], [tipoSangre], [edad], [dpi], [numTel1], [numTel2], [correo], [fechaCreacion], [fechaModificacion], [userCreacion], [userModificacion], [eliminado], [idEstado]) VALUES (10, N'Julian Casuy', CAST(N'2017-10-25T00:00:00.000' AS DateTime), N'Masculino', NULL, NULL, N'111111111111', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[ControlPacientes] ([idPaciente], [nombrePaciente], [fechaNacimiento], [sexo], [tipoSangre], [edad], [dpi], [numTel1], [numTel2], [correo], [fechaCreacion], [fechaModificacion], [userCreacion], [userModificacion], [eliminado], [idEstado]) VALUES (11, N'Amanda', NULL, N'Femenino', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0)
INSERT [dbo].[ControlPacientes] ([idPaciente], [nombrePaciente], [fechaNacimiento], [sexo], [tipoSangre], [edad], [dpi], [numTel1], [numTel2], [correo], [fechaCreacion], [fechaModificacion], [userCreacion], [userModificacion], [eliminado], [idEstado]) VALUES (12, N'Ramon', NULL, N'Masculino', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0)
INSERT [dbo].[ControlPacientes] ([idPaciente], [nombrePaciente], [fechaNacimiento], [sexo], [tipoSangre], [edad], [dpi], [numTel1], [numTel2], [correo], [fechaCreacion], [fechaModificacion], [userCreacion], [userModificacion], [eliminado], [idEstado]) VALUES (15, N'Lucia', CAST(N'2020-11-07T00:00:00.000' AS DateTime), N'Femenino', NULL, NULL, N'211232321212', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0)
INSERT [dbo].[ControlPacientes] ([idPaciente], [nombrePaciente], [fechaNacimiento], [sexo], [tipoSangre], [edad], [dpi], [numTel1], [numTel2], [correo], [fechaCreacion], [fechaModificacion], [userCreacion], [userModificacion], [eliminado], [idEstado]) VALUES (16, N'Alex Francisco', CAST(N'2020-11-03T00:00:00.000' AS DateTime), N'Masculino', NULL, NULL, N'211232321212', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[ControlPacientes] ([idPaciente], [nombrePaciente], [fechaNacimiento], [sexo], [tipoSangre], [edad], [dpi], [numTel1], [numTel2], [correo], [fechaCreacion], [fechaModificacion], [userCreacion], [userModificacion], [eliminado], [idEstado]) VALUES (17, N'Tamara Diaz Gutierres', CAST(N'2016-02-01T00:00:00.000' AS DateTime), N'Femenino', NULL, NULL, N'2052853760101', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[ControlPacientes] ([idPaciente], [nombrePaciente], [fechaNacimiento], [sexo], [tipoSangre], [edad], [dpi], [numTel1], [numTel2], [correo], [fechaCreacion], [fechaModificacion], [userCreacion], [userModificacion], [eliminado], [idEstado]) VALUES (18, N'Leire Sarai Casuy Rodriguez', CAST(N'2019-05-17T00:00:00.000' AS DateTime), N'Femenino', NULL, NULL, N'2052853760101', NULL, NULL, NULL, CAST(N'2020-11-14T11:44:00.000' AS DateTime), NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[ControlPacientes] ([idPaciente], [nombrePaciente], [fechaNacimiento], [sexo], [tipoSangre], [edad], [dpi], [numTel1], [numTel2], [correo], [fechaCreacion], [fechaModificacion], [userCreacion], [userModificacion], [eliminado], [idEstado]) VALUES (19, N'Pamela Rodriguez Perez', CAST(N'1995-02-11T00:00:00.000' AS DateTime), N'Femenino', NULL, NULL, N'2052853760101', NULL, NULL, NULL, CAST(N'2020-11-15T10:33:00.000' AS DateTime), NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[ControlPacientes] ([idPaciente], [nombrePaciente], [fechaNacimiento], [sexo], [tipoSangre], [edad], [dpi], [numTel1], [numTel2], [correo], [fechaCreacion], [fechaModificacion], [userCreacion], [userModificacion], [eliminado], [idEstado]) VALUES (20, N'Ignacio Rigoberto', CAST(N'1991-11-11T00:00:00.000' AS DateTime), N'Masculino', NULL, NULL, N'2052853760101', NULL, NULL, NULL, CAST(N'2020-11-15T10:46:00.000' AS DateTime), NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[ControlPacientes] ([idPaciente], [nombrePaciente], [fechaNacimiento], [sexo], [tipoSangre], [edad], [dpi], [numTel1], [numTel2], [correo], [fechaCreacion], [fechaModificacion], [userCreacion], [userModificacion], [eliminado], [idEstado]) VALUES (21, N'Amelia Gutierres ', CAST(N'1989-02-11T00:00:00.000' AS DateTime), N'Femenino', NULL, NULL, N'2056986930120', NULL, NULL, NULL, CAST(N'2020-11-15T10:57:00.000' AS DateTime), NULL, NULL, NULL, 0, NULL)
SET IDENTITY_INSERT [dbo].[ControlPacientes] OFF
GO
SET IDENTITY_INSERT [dbo].[ESTADOS] ON 

INSERT [dbo].[ESTADOS] ([IdEstado], [nombreEstado], [fechaCreacion], [usuarioCreacion], [eliminado]) VALUES (1, N'Activo', CAST(N'2012-06-18T22:34:09.000' AS DateTime), 1, 0)
INSERT [dbo].[ESTADOS] ([IdEstado], [nombreEstado], [fechaCreacion], [usuarioCreacion], [eliminado]) VALUES (2, N'Inactivo', CAST(N'2012-06-18T22:34:09.000' AS DateTime), 1, 0)
INSERT [dbo].[ESTADOS] ([IdEstado], [nombreEstado], [fechaCreacion], [usuarioCreacion], [eliminado]) VALUES (3, N'Suspendido', CAST(N'2012-06-18T22:34:09.000' AS DateTime), 1, 0)
INSERT [dbo].[ESTADOS] ([IdEstado], [nombreEstado], [fechaCreacion], [usuarioCreacion], [eliminado]) VALUES (4, N'Pendiente', CAST(N'2012-06-18T22:34:09.000' AS DateTime), 1, 0)
INSERT [dbo].[ESTADOS] ([IdEstado], [nombreEstado], [fechaCreacion], [usuarioCreacion], [eliminado]) VALUES (5, N'En progreso', CAST(N'2012-06-18T22:34:09.000' AS DateTime), 1, 0)
INSERT [dbo].[ESTADOS] ([IdEstado], [nombreEstado], [fechaCreacion], [usuarioCreacion], [eliminado]) VALUES (6, N'Finalizada', CAST(N'2012-06-18T22:34:09.000' AS DateTime), 1, 0)
INSERT [dbo].[ESTADOS] ([IdEstado], [nombreEstado], [fechaCreacion], [usuarioCreacion], [eliminado]) VALUES (7, N'Cancelada', CAST(N'2012-06-18T22:34:09.000' AS DateTime), 1, 0)
SET IDENTITY_INSERT [dbo].[ESTADOS] OFF
GO
SET IDENTITY_INSERT [dbo].[RegistroMedicos] ON 

INSERT [dbo].[RegistroMedicos] ([idMedico], [nombreMedico], [Colegiado], [Especialidad], [sexo], [fechaNacimiento], [fechaCreacion], [fechaModificacion], [userCreacion], [userModificacion], [eliminado], [idEstado]) VALUES (1, N'Mariano Perez Oliva', N'SI No. Matricula 25365', N'Medico Pediatra', N'Masculino', CAST(N'2012-06-18T00:00:00.000' AS DateTime), CAST(N'2012-06-18T22:34:09.000' AS DateTime), NULL, 1, NULL, 1, 1)
INSERT [dbo].[RegistroMedicos] ([idMedico], [nombreMedico], [Colegiado], [Especialidad], [sexo], [fechaNacimiento], [fechaCreacion], [fechaModificacion], [userCreacion], [userModificacion], [eliminado], [idEstado]) VALUES (2, N'Tomas', N'SI', N'Medico General', N'Masculio', CAST(N'2012-06-18T22:34:09.000' AS DateTime), CAST(N'2012-06-18T22:34:09.000' AS DateTime), NULL, 1, NULL, 1, 0)
INSERT [dbo].[RegistroMedicos] ([idMedico], [nombreMedico], [Colegiado], [Especialidad], [sexo], [fechaNacimiento], [fechaCreacion], [fechaModificacion], [userCreacion], [userModificacion], [eliminado], [idEstado]) VALUES (3, N'Hector Casuy Culajay', N'SI', N'PEDIATRIA', N'Masculino', CAST(N'2020-11-01T00:00:00.000' AS DateTime), CAST(N'2020-11-06T21:06:00.000' AS DateTime), NULL, NULL, NULL, 1, 0)
INSERT [dbo].[RegistroMedicos] ([idMedico], [nombreMedico], [Colegiado], [Especialidad], [sexo], [fechaNacimiento], [fechaCreacion], [fechaModificacion], [userCreacion], [userModificacion], [eliminado], [idEstado]) VALUES (4, N'Dr. Maria Elizabeth Cubur', N'SI No. Matricula 00235', N'Dentista', N'Femenino', CAST(N'2020-11-19T00:00:00.000' AS DateTime), CAST(N'2020-11-06T22:00:00.000' AS DateTime), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[RegistroMedicos] ([idMedico], [nombreMedico], [Colegiado], [Especialidad], [sexo], [fechaNacimiento], [fechaCreacion], [fechaModificacion], [userCreacion], [userModificacion], [eliminado], [idEstado]) VALUES (5, N'DR. Jimmy Noe Miranda', N'SI No. Matricula 8563', N'Ginecologo', N'Femenino', CAST(N'1991-10-11T00:00:00.000' AS DateTime), CAST(N'2020-11-06T22:33:00.000' AS DateTime), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[RegistroMedicos] ([idMedico], [nombreMedico], [Colegiado], [Especialidad], [sexo], [fechaNacimiento], [fechaCreacion], [fechaModificacion], [userCreacion], [userModificacion], [eliminado], [idEstado]) VALUES (6, N'Ana Raquel Guzman Diaz', N'Asociación de médicos Guatemaltecos', N'Gastroenterología', N'Femenino', CAST(N'1985-02-14T00:00:00.000' AS DateTime), CAST(N'2020-11-14T11:25:00.000' AS DateTime), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[RegistroMedicos] ([idMedico], [nombreMedico], [Colegiado], [Especialidad], [sexo], [fechaNacimiento], [fechaCreacion], [fechaModificacion], [userCreacion], [userModificacion], [eliminado], [idEstado]) VALUES (7, N'Hector Casuy Culajay', N'Asociación de médicos Guatemaltecos', N'Análisis de Sangre', N'Masculino', CAST(N'1985-11-15T00:00:00.000' AS DateTime), CAST(N'2020-11-15T11:01:00.000' AS DateTime), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[RegistroMedicos] ([idMedico], [nombreMedico], [Colegiado], [Especialidad], [sexo], [fechaNacimiento], [fechaCreacion], [fechaModificacion], [userCreacion], [userModificacion], [eliminado], [idEstado]) VALUES (8, N'Fernando Rodriguez', N'Asociación de médicos Guatemaltecos', N'Anestesiología y reanimación', N'Masculino', CAST(N'1982-01-05T00:00:00.000' AS DateTime), CAST(N'2020-11-15T20:43:00.000' AS DateTime), NULL, NULL, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[RegistroMedicos] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoConsulta] ON 

INSERT [dbo].[TipoConsulta] ([idConsulta], [nombreConsulta], [fechaCreacion], [usuarioCreacion], [eliminado]) VALUES (1, N'Chequeo General', CAST(N'2012-06-18T22:34:09.000' AS DateTime), NULL, 0)
INSERT [dbo].[TipoConsulta] ([idConsulta], [nombreConsulta], [fechaCreacion], [usuarioCreacion], [eliminado]) VALUES (2, N'Examen de sangre', CAST(N'2012-06-18T22:34:09.000' AS DateTime), NULL, 0)
INSERT [dbo].[TipoConsulta] ([idConsulta], [nombreConsulta], [fechaCreacion], [usuarioCreacion], [eliminado]) VALUES (3, N'Laboratorio', CAST(N'2012-06-18T22:34:09.000' AS DateTime), NULL, 0)
INSERT [dbo].[TipoConsulta] ([idConsulta], [nombreConsulta], [fechaCreacion], [usuarioCreacion], [eliminado]) VALUES (4, N'Emergencia', CAST(N'2012-06-18T22:34:09.000' AS DateTime), NULL, 0)
SET IDENTITY_INSERT [dbo].[TipoConsulta] OFF
GO
ALTER TABLE [dbo].[Anexos] ADD  DEFAULT ((1)) FOR [eliminado]
GO
ALTER TABLE [dbo].[CitasMedicas] ADD  DEFAULT ((1)) FOR [eliminado]
GO
ALTER TABLE [dbo].[ControlPacientes] ADD  DEFAULT ((1)) FOR [eliminado]
GO
ALTER TABLE [dbo].[ESTADOS] ADD  DEFAULT ((1)) FOR [eliminado]
GO
ALTER TABLE [dbo].[RegistroMedicos] ADD  DEFAULT ((1)) FOR [eliminado]
GO
ALTER TABLE [dbo].[TipoConsulta] ADD  DEFAULT ((0)) FOR [eliminado]
GO
/****** Object:  StoredProcedure [dbo].[SP_CitasMedicas]    Script Date: 17/11/2020 16:34:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_CitasMedicas]
	@NumConsulta int,
	@DBSAP nvarchar(125) = NULL,	
	@Param1 nvarchar(125) = NULL,
	@Param2 nvarchar(125) = NULL,
	@Param3 nvarchar(125) = NULL,
	@Param4 nvarchar(125) = NULL,
	@Param5 nvarchar(125) = NULL,	
	@Param6 nvarchar(125) = NULL,
	@Param7 nvarchar(125) = NULL,
	@Param8 nvarchar(125) = NULL,
	@Param9 nvarchar(125) = NULL,
	@Param10 nvarchar(125) = NULL

AS
BEGIN
DECLARE @xSql  Nvarchar(max)

--//LISTA DE ESTADOS\\--
IF (@NumConsulta = 1)
BEGIN
SET @xSql=''
SET @xSql=@xSql+ 'SELECT IdEstado, ISNULL(nombreEstado, '''') AS nombreEstado '
SET @xSql=@xSql+ 'FROM ESTADOS WHERE eliminado = 0 '
EXEC(@xSql)
GOTO FIN
END

--//CREATE REGISTRO MEDICO\\--
IF (@NumConsulta = 2)
BEGIN
SET @xSql=''
SET @xSql=@xSql+ 'SELECT idConsulta, ISNULL(nombreConsulta, '''') AS nombreConsulta '
SET @xSql=@xSql+ 'FROM TipoConsulta WHERE eliminado = 0 '
EXEC(@xSql) 
GOTO FIN
END

--//CREATE REGISTRO MEDICO\\--
IF (@NumConsulta = 3)
BEGIN
INSERT INTO CitasMedicas (idPaciente, idMedico, idConsulta, fechaCita, horaCita, comentario, fechaCreacion, eliminado, idEstado) 
VALUES (@Param1, @Param2, @Param3, @Param4, @Param5, @Param6, @Param7, @Param8, @Param9)  
GOTO FIN
END

--//OBTENER LISTA CITAS POR MEDICO\\--
IF (@NumConsulta = 4)
BEGIN
SET @xSql=''
SET @xSql=@xSql+ 'SELECT T0.idCita, T0.idPaciente, T1.nombrePaciente, T1.sexo, DATEDIFF(YEAR,T1.fechaNacimiento,GETDATE()) AS Edad, T0.idConsulta, T2.nombreConsulta,  '
SET @xSql=@xSql+ 'CONVERT(CHAR(10),T0.fechaCita,103) AS fechaCita, CONVERT(CHAR(20),T0.fechaFinalizacion,20) AS fechaFinalizacion , '
SET @xSql=@xSql+ 'CONVERT(VARCHAR(20), ISNULL(T0.horaCita,''''),22) AS horaCita, CONVERT(CHAR(20),T0.fechaNuevaCita,103) AS fechaNuevaCita, T0.comentario, '
SET @xSql=@xSql+ 'CONVERT(CHAR(20), ISNULL(T0.fechaCreacion,''''),103) AS fechaCreacion, T0.idEstado, T3.nombreEstado '
SET @xSql=@xSql+ 'FROM CitasMedicas AS T0 '
SET @xSql=@xSql+ 'INNER JOIN ControlPacientes AS T1 on T0.idPaciente = T1.idPaciente '
SET @xSql=@xSql+ 'INNER JOIN TipoConsulta AS T2 ON T0.idConsulta = T2.idConsulta '
SET @xSql=@xSql+ 'INNER JOIN ESTADOS AS T3 ON T0.idEstado = T3.idEstado '
SET @xSql=@xSql+ 'WHERE idMedico = '+@Param1+' '
EXEC(@xSql)
GOTO FIN
END

--//OBTENER DETALLE DE CITA\\--
IF (@NumConsulta = 5)
BEGIN
SET @xSql=''
SET @xSql=@xSql+ 'SELECT T0.idCita, T0.idPaciente, T1.nombrePaciente, T0.idMedico, T0.idConsulta, '
SET @xSql=@xSql+ 'CONVERT(CHAR(10),T0.fechaCita,103) AS fechaCita, T0.fechaFinalizacion, '
SET @xSql=@xSql+ 'CONVERT(VARCHAR(20), ISNULL(T0.horaCita,''''),20) AS horaCita, CONVERT(CHAR(10),T0.fechaNuevaCita,103) AS fechaNuevaCita, T0.comentario, T0.idEstado '
SET @xSql=@xSql+ 'FROM CitasMedicas AS T0 '
SET @xSql=@xSql+ 'INNER JOIN ControlPacientes AS T1 on T0.idPaciente = T1.idPaciente '
SET @xSql=@xSql+ 'WHERE idCita = '+@Param1+' '
EXEC(@xSql)
GOTO FIN
END

--//ACTUALIZACION DETALLE CITA PACIENTE\\--
IF (@NumConsulta = 6)
BEGIN
UPDATE CitasMedicas 
SET idMedico =  @Param2, idConsulta = @Param3, fechaFinalizacion = @Param4, fechaNuevaCita = @Param6, comentario = @Param7, fechaModificacion = @Param8, idEstado = @Param9
WHERE idCita =  @Param1
GOTO FIN
END 

--//CAMBIAR ESTADO DEL MEDICO A INACTIVO\\--
IF (@NumConsulta = 7)
BEGIN
UPDATE RegistroMedicos set eliminado=1, idEstado=0 WHERE idMedico =  @Param1
GOTO FIN
END 

FIN:
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DatosMedicos]    Script Date: 17/11/2020 16:34:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_DatosMedicos]
	@NumConsulta int,
	@DBSAP nvarchar(125) = NULL,	
	@Param1 nvarchar(125) = NULL,
	@Param2 nvarchar(125) = NULL,
	@Param3 nvarchar(125) = NULL,
	@Param4 nvarchar(125) = NULL,
	@Param5 nvarchar(125) = NULL,	
	@Param6 nvarchar(125) = NULL,
	@Param7 nvarchar(125) = NULL,
	@Param8 nvarchar(125) = NULL

AS
BEGIN
DECLARE @xSql  Nvarchar(max)

--//LISTA DE MEDICOS AGREGADOS\\--
IF (@NumConsulta = 1)
BEGIN
SET @xSql=''
SET @xSql=@xSql+ 'SELECT idMedico, ISNULL(nombreMedico, '''') AS nombreMedico, ISNULL(Colegiado,'''') AS Colegiado, '
SET @xSql=@xSql+ 'ISNULL(Especialidad, '''') AS Especialidad, ISNULL(sexo,'''') AS sexo, ISNULL(CONVERT(VARCHAR(10),fechaNacimiento,103),'''') AS fechaNacimiento  '
SET @xSql=@xSql+ 'FROM RegistroMedicos WHERE eliminado=0 '
EXEC(@xSql)
GOTO FIN
END


--//CREATE REGISTRO MEDICO\\--
IF (@NumConsulta = 2)
BEGIN
INSERT INTO RegistroMedicos (nombreMedico, Colegiado, Especialidad, sexo, fechaNacimiento, fechaCreacion, eliminado, idEstado ) 
VALUES (@Param1, @Param2, @Param3, @Param4, @Param5, @Param6, @Param7, @Param8)  
GOTO FIN
END 

--//OBTENER DATOS POR IDMEDICO\\--
IF (@NumConsulta = 3)
BEGIN
SET @xSql=''
SET @xSql=@xSql+ 'SELECT idMedico, ISNULL(nombreMedico, '''') AS nombreMedico, ISNULL(Colegiado,'''') AS Colegiado, '
SET @xSql=@xSql+ 'ISNULL(Especialidad, '''') AS Especialidad, ISNULL(sexo,'''') AS sexo, ISNULL(CONVERT(VARCHAR(10),fechaNacimiento,103),'''') AS fechaNacimiento '
SET @xSql=@xSql+ 'FROM RegistroMedicos  WHERE idMedico = '+@Param1+' '
EXEC(@xSql)
GOTO FIN
END

--//ACTUALIZACION DE MEDICO POR IDPACIENTE\\--
IF (@NumConsulta = 4)
BEGIN
UPDATE RegistroMedicos 
SET nombreMedico =  @Param2, Colegiado =  @Param3, Especialidad =  @Param4, sexo = @Param5, fechaNacimiento = @Param6
WHERE idMedico =  @Param1
GOTO FIN
END 

--//CAMBIAR ESTADO DEL MEDICO A INACTIVO\\--
IF (@NumConsulta = 5)
BEGIN
UPDATE RegistroMedicos set eliminado=1, idEstado=0 WHERE idMedico =  @Param1
GOTO FIN
END 

FIN:
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DatosPacientes]    Script Date: 17/11/2020 16:34:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_DatosPacientes]
	@NumConsulta int,
	@DBSAP nvarchar(125) = NULL,	
	@Param1 nvarchar(125) = NULL,
	@Param2 nvarchar(125) = NULL,
	@Param3 nvarchar(125) = NULL,
	@Param4 nvarchar(125) = NULL,
	@Param5 nvarchar(125) = NULL,	
	@Param6 nvarchar(125) = NULL

AS
BEGIN
DECLARE @xSql  Nvarchar(max)

--//LISTA DE PACIENTES CREADOS\\--
IF (@NumConsulta = 1)
BEGIN
SET @xSql=''
SET @xSql=@xSql+ 'SELECT idPaciente, ISNULL(nombrePaciente,'''') AS nombrePaciente, isNull(CONVERT(VARCHAR(10),fechaNacimiento,103),getdate()) AS fechaNacimiento,  '
SET @xSql=@xSql+ 'ISNULL(Sexo,'''') AS Sexo, ISNULL(DPI,'''') AS DPI '
SET @xSql=@xSql+ 'FROM ControlPacientes where eliminado=0 '
EXEC(@xSql)
GOTO FIN
END

--//CREAR PACIENTES\\--
IF (@NumConsulta = 2)
BEGIN
INSERT INTO ControlPacientes (nombrePaciente, fechaNacimiento, fechaCreacion, sexo, DPI, eliminado ) values(@Param1, @Param2, @Param3, @Param4, @Param5, @Param6)  
GOTO FIN
END 

--//ACTUALIZACION DE PACIENTE POR IDPACIENTE\\--
IF (@NumConsulta = 3)
BEGIN
UPDATE ControlPacientes 
SET nombrePaciente =  @Param2, fechaNacimiento =  @Param3, sexo =  @Param4, DPI = @Param5
WHERE idPaciente =  @Param1
GOTO FIN
END

--//OBTENER DATOS POR IDPACIENTE\\--
IF (@NumConsulta = 4)
BEGIN
SET @xSql=''
SET @xSql=@xSql+ 'SELECT idPaciente, ISNULL(nombrePaciente,'''') AS nombrePaciente, ISNULL(sexo,'''') AS sexo, '
SET @xSql=@xSql+ 'CONVERT(VARCHAR(10),fechaNacimiento,103) AS fechaNacimiento, ISNULL(DPI,'''') AS DPI '
SET @xSql=@xSql+ 'FROM ControlPacientes  WHERE idPaciente = '+@Param1+' '
EXEC(@xSql)
GOTO FIN
END

--//CAMBIAR ESTADO DEL CLIENTE A INACTIVO\\--
IF (@NumConsulta = 5)
BEGIN
UPDATE ControlPacientes set eliminado=1, idEstado=0 WHERE idPaciente =  @Param1
GOTO FIN
END

--//CREAR REGISTRSO DE LOS ARCHIVOS ALMACENADOS\\--
IF (@NumConsulta = 6)
BEGIN
INSERT INTO Anexos (IdPaciente, ruta, Extencion, NombreArchivo, fechaCreacion, idEstado) values(@Param1, @Param2, @Param3, @Param4, GETDATE(),1)
GOTO FIN
END 

--//LISTAR DATOS DE ANEXOS\\--
IF (@NumConsulta = 7)
BEGIN
SET @xSql=''
SET @xSql=@xSql+ 'SELECT idAnexo, IdPaciente, ruta,  Extencion, NombreArchivo, CONVERT(VARCHAR(10),fechaCreacion,103) fechaCreacion ,idEstado '
SET @xSql=@xSql+ 'FROM Anexos  WHERE idPaciente = '+@Param1+' and idEstado=1 '
EXEC(@xSql)
GOTO FIN
END

FIN:
END
GO
USE [master]
GO
ALTER DATABASE [CENTRO_MEDICO_2020] SET  READ_WRITE 
GO
