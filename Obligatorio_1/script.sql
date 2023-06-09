USE [ObligatorioP3]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11 May. 2023 12:05:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cabanas]    Script Date: 11 May. 2023 12:05:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cabanas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreCabana] [nvarchar](50) NOT NULL,
	[DescripCabana] [nvarchar](max) NULL,
	[Jacuzzi] [bit] NOT NULL,
	[Habilitado] [bit] NOT NULL,
	[MaxPersonas] [int] NULL,
	[FotoCabana] [nvarchar](max) NULL,
	[TipoId] [int] NOT NULL,
 CONSTRAINT [PK_Cabanas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mantenimientos]    Script Date: 11 May. 2023 12:05:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mantenimientos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FechaMant] [datetime2](7) NOT NULL,
	[DescMant] [nvarchar](200) NULL,
	[CostoMant] [int] NULL,
	[Personal] [nvarchar](max) NULL,
	[CabanaId] [int] NOT NULL,
 CONSTRAINT [PK_Mantenimientos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parametros]    Script Date: 11 May. 2023 12:05:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parametros](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Valor] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Parametros] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipos]    Script Date: 11 May. 2023 12:05:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](450) NOT NULL,
	[DescTipo] [nvarchar](max) NULL,
	[CostoTipo] [int] NULL,
 CONSTRAINT [PK_Tipos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 11 May. 2023 12:05:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](450) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230510004510_inicial', N'7.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230510004917_nuevosNull', N'7.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230510174613_mailIsUnique', N'7.0.5')
GO
SET IDENTITY_INSERT [dbo].[Cabanas] ON 

INSERT [dbo].[Cabanas] ([Id], [NombreCabana], [DescripCabana], [Jacuzzi], [Habilitado], [MaxPersonas], [FotoCabana], [TipoId]) VALUES (1, N'Berlin', N'Apta para niños', 0, 1, 5, N'Berlin_001.jpg', 3)
INSERT [dbo].[Cabanas] ([Id], [NombreCabana], [DescripCabana], [Jacuzzi], [Habilitado], [MaxPersonas], [FotoCabana], [TipoId]) VALUES (2, N'Londres', N'Con piscina apta para niños', 1, 1, 6, N'Londres_001.jpg', 1)
INSERT [dbo].[Cabanas] ([Id], [NombreCabana], [DescripCabana], [Jacuzzi], [Habilitado], [MaxPersonas], [FotoCabana], [TipoId]) VALUES (3, N'Paris', N'Apta para eventos', 1, 0, 10, N'Paris_001.jpg', 5)
INSERT [dbo].[Cabanas] ([Id], [NombreCabana], [DescripCabana], [Jacuzzi], [Habilitado], [MaxPersonas], [FotoCabana], [TipoId]) VALUES (4, N'Roma', N'Rústica, cerca del lago', 1, 0, 4, N'Roma_001.jpg', 1)
INSERT [dbo].[Cabanas] ([Id], [NombreCabana], [DescripCabana], [Jacuzzi], [Habilitado], [MaxPersonas], [FotoCabana], [TipoId]) VALUES (6, N'Madrid', N'Solo parejas', 1, 0, 2, N'Madrid_001.jpg', 4)
INSERT [dbo].[Cabanas] ([Id], [NombreCabana], [DescripCabana], [Jacuzzi], [Habilitado], [MaxPersonas], [FotoCabana], [TipoId]) VALUES (7, N'Estocolmo', N'Actividades al aire libre cerca', 0, 1, 8, N'Estocolmo_001.jpg', 2)
INSERT [dbo].[Cabanas] ([Id], [NombreCabana], [DescripCabana], [Jacuzzi], [Habilitado], [MaxPersonas], [FotoCabana], [TipoId]) VALUES (8, N'Moscú', N'Con vista a los cerros', 0, 1, 3, N'Moscú_001.jpg', 3)
INSERT [dbo].[Cabanas] ([Id], [NombreCabana], [DescripCabana], [Jacuzzi], [Habilitado], [MaxPersonas], [FotoCabana], [TipoId]) VALUES (9, N'Atenas', N'Amplio living, spa propio', 1, 1, 4, N'Atenas_001.jpg', 4)
INSERT [dbo].[Cabanas] ([Id], [NombreCabana], [DescripCabana], [Jacuzzi], [Habilitado], [MaxPersonas], [FotoCabana], [TipoId]) VALUES (10, N'Praga', N'Cocina de chef', 0, 0, 6, N'Praga_001.jpg', 2)
INSERT [dbo].[Cabanas] ([Id], [NombreCabana], [DescripCabana], [Jacuzzi], [Habilitado], [MaxPersonas], [FotoCabana], [TipoId]) VALUES (11, N'Viena', N'Para pequeños eventos empresariales', 0, 1, 10, N'Viena_001.jpg', 5)
SET IDENTITY_INSERT [dbo].[Cabanas] OFF
GO
SET IDENTITY_INSERT [dbo].[Mantenimientos] ON 

INSERT [dbo].[Mantenimientos] ([Id], [FechaMant], [DescMant], [CostoMant], [Personal], [CabanaId]) VALUES (1, CAST(N'2023-05-09T22:02:00.0000000' AS DateTime2), N'Cambio de sábanas', 10, N'Luis', 1)
INSERT [dbo].[Mantenimientos] ([Id], [FechaMant], [DescMant], [CostoMant], [Personal], [CabanaId]) VALUES (2, CAST(N'2023-05-11T22:03:00.0000000' AS DateTime2), N'Chequear frigobar', 15, N'Ana', 1)
INSERT [dbo].[Mantenimientos] ([Id], [FechaMant], [DescMant], [CostoMant], [Personal], [CabanaId]) VALUES (3, CAST(N'2023-05-13T10:42:00.0000000' AS DateTime2), N'Descripción de mantenimiento - 1', 100, N'Luis', 1)
INSERT [dbo].[Mantenimientos] ([Id], [FechaMant], [DescMant], [CostoMant], [Personal], [CabanaId]) VALUES (4, CAST(N'2023-05-13T10:44:00.0000000' AS DateTime2), N'Descripción de mantenimiento - 2', 100, N'Ana', 1)
INSERT [dbo].[Mantenimientos] ([Id], [FechaMant], [DescMant], [CostoMant], [Personal], [CabanaId]) VALUES (5, CAST(N'2023-05-13T10:44:00.0000000' AS DateTime2), N'Descripción de mantenimiento - 3', 150, N'Pedro', 1)
INSERT [dbo].[Mantenimientos] ([Id], [FechaMant], [DescMant], [CostoMant], [Personal], [CabanaId]) VALUES (6, CAST(N'2023-05-16T11:44:00.0000000' AS DateTime2), N'Descripción de mantenimiento - 1', 200, N'Ana', 2)
INSERT [dbo].[Mantenimientos] ([Id], [FechaMant], [DescMant], [CostoMant], [Personal], [CabanaId]) VALUES (7, CAST(N'2023-05-16T11:45:00.0000000' AS DateTime2), N'Descripción de mantenimiento - 2', 105, N'Luis', 2)
INSERT [dbo].[Mantenimientos] ([Id], [FechaMant], [DescMant], [CostoMant], [Personal], [CabanaId]) VALUES (8, CAST(N'2023-05-13T11:46:00.0000000' AS DateTime2), N'Descripción de mantenimiento - 1', 200, N'Pedro', 3)
INSERT [dbo].[Mantenimientos] ([Id], [FechaMant], [DescMant], [CostoMant], [Personal], [CabanaId]) VALUES (9, CAST(N'2023-05-17T12:01:00.0000000' AS DateTime2), N'Descripción de mantenimiento - 2', 110, N'Ana', 3)
INSERT [dbo].[Mantenimientos] ([Id], [FechaMant], [DescMant], [CostoMant], [Personal], [CabanaId]) VALUES (10, CAST(N'2023-05-14T12:02:00.0000000' AS DateTime2), N'Descripción de mantenimiento - 1', 50, N'Estela', 4)
SET IDENTITY_INSERT [dbo].[Mantenimientos] OFF
GO
SET IDENTITY_INSERT [dbo].[Parametros] ON 

INSERT [dbo].[Parametros] ([Id], [Nombre], [Valor]) VALUES (1, N'MinDescripCabana', N'10')
INSERT [dbo].[Parametros] ([Id], [Nombre], [Valor]) VALUES (2, N'MaxDescripCabana', N'500')
INSERT [dbo].[Parametros] ([Id], [Nombre], [Valor]) VALUES (3, N'MinDescripTipo', N'10')
INSERT [dbo].[Parametros] ([Id], [Nombre], [Valor]) VALUES (4, N'MaxDescripTipo', N'200')
SET IDENTITY_INSERT [dbo].[Parametros] OFF
GO
SET IDENTITY_INSERT [dbo].[Tipos] ON 

INSERT [dbo].[Tipos] ([Id], [Nombre], [DescTipo], [CostoTipo]) VALUES (1, N'Presidencial', N'Todos los servicios incluídos', 1500)
INSERT [dbo].[Tipos] ([Id], [Nombre], [DescTipo], [CostoTipo]) VALUES (2, N'VIP', N'Acceso ilimitado a spa', 800)
INSERT [dbo].[Tipos] ([Id], [Nombre], [DescTipo], [CostoTipo]) VALUES (3, N'Estandar', N'Media pensión', 200)
INSERT [dbo].[Tipos] ([Id], [Nombre], [DescTipo], [CostoTipo]) VALUES (4, N'Luna de Miel', N'Para parejas, mínimo dos noches', 500)
INSERT [dbo].[Tipos] ([Id], [Nombre], [DescTipo], [CostoTipo]) VALUES (5, N'Eventos', N'Para grupos grandes, admite alquiler por el día', 800)
SET IDENTITY_INSERT [dbo].[Tipos] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([Id], [Email], [Password]) VALUES (1, N'sofi@gmail.com', N'1234abC')
INSERT [dbo].[Usuarios] ([Id], [Email], [Password]) VALUES (2, N'lucas@gmail.com', N'7654abC')
INSERT [dbo].[Usuarios] ([Id], [Email], [Password]) VALUES (3, N'admin@gmail.com', N'Qwerty1')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
ALTER TABLE [dbo].[Cabanas]  WITH CHECK ADD  CONSTRAINT [FK_Cabanas_Tipos_TipoId] FOREIGN KEY([TipoId])
REFERENCES [dbo].[Tipos] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cabanas] CHECK CONSTRAINT [FK_Cabanas_Tipos_TipoId]
GO
ALTER TABLE [dbo].[Mantenimientos]  WITH CHECK ADD  CONSTRAINT [FK_Mantenimientos_Cabanas_CabanaId] FOREIGN KEY([CabanaId])
REFERENCES [dbo].[Cabanas] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Mantenimientos] CHECK CONSTRAINT [FK_Mantenimientos_Cabanas_CabanaId]
GO
