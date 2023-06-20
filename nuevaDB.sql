-- CREATE DATABASE ObligatorioP3_V2
-- Consola Nugget --> add-migration inicial, update-database




USE ObligatorioP3_V2

/*
INSERT INTO ObligatorioP3_V2.dbo.Tipos (Nombre, DescTipo, CostoTipo)
SELECT Nombre, DescTipo, CostoTipo FROM ObligatorioP3.dbo.Tipos;
*/

/*
INSERT INTO ObligatorioP3_V2.dbo.Usuarios (Email, Password)
SELECT Email, Password FROM ObligatorioP3.dbo.Usuarios;
*/

/*
INSERT INTO ObligatorioP3_V2.dbo.Parametros(Nombre, Valor)
SELECT Nombre, Valor FROM ObligatorioP3.dbo.Parametros;
*/

/*
INSERT INTO ObligatorioP3_V2.dbo.Cabanas(NombreCabana_Value, DescripCabana, Jacuzzi,Habilitado,MaxPersonas,FotoCabana,TipoId)
SELECT NombreCabana, DescripCabana, Jacuzzi,Habilitado,MaxPersonas,FotoCabana,TipoId FROM ObligatorioP3.dbo.Cabanas;
*/

/*
INSERT INTO ObligatorioP3_V2.dbo.Mantenimientos (FechaMant, DescMant,CostoMant,Personal,CabanaId)
SELECT FechaMant, DescMant,CostoMant,Personal,CabanaId FROM ObligatorioP3.dbo.Mantenimientos;
*/



/*

USE [ObligatorioP3_V2]
GO
SET IDENTITY_INSERT [dbo].[Tipos] ON 
GO
INSERT [dbo].[Tipos] ([Id], [NombreTipo_Value], [DescTipo_Value], [CostoTipo]) VALUES (1, N'Presidencial', N'Todos los servicios incluídos', 1500)
GO
INSERT [dbo].[Tipos] ([Id], [NombreTipo_Value], [DescTipo_Value], [CostoTipo]) VALUES (2, N'VIP', N'Acceso ilimitado a spa', 800)
GO
INSERT [dbo].[Tipos] ([Id], [NombreTipo_Value], [DescTipo_Value], [CostoTipo]) VALUES (3, N'Estandar', N'Media pensión', 200)
GO
INSERT [dbo].[Tipos] ([Id], [NombreTipo_Value], [DescTipo_Value], [CostoTipo]) VALUES (4, N'Luna de Miel', N'Para parejas, mínimo dos noches', 500)
GO
INSERT [dbo].[Tipos] ([Id], [NombreTipo_Value], [DescTipo_Value], [CostoTipo]) VALUES (5, N'Eventos', N'Para grupos grandes, admite alquiler por el día', 800)
GO
INSERT [dbo].[Tipos] ([Id], [NombreTipo_Value], [DescTipo_Value], [CostoTipo]) VALUES (6, N'ParaBorrar', N'Probar borrar este ', 200)
GO
SET IDENTITY_INSERT [dbo].[Tipos] OFF
GO
SET IDENTITY_INSERT [dbo].[Cabanas] ON 
GO
INSERT [dbo].[Cabanas] ([Id], [NombreCabana_Value], [DescripCabana_Value], [Jacuzzi], [Habilitado], [MaxPersonas], [FotoCabana], [TipoId]) VALUES (1, N'Berlin', N'Apta para niños', 0, 1, 5, N'Berlin_001.jpg', 3)
GO
INSERT [dbo].[Cabanas] ([Id], [NombreCabana_Value], [DescripCabana_Value], [Jacuzzi], [Habilitado], [MaxPersonas], [FotoCabana], [TipoId]) VALUES (2, N'Londres', N'Con piscina apta para niños', 1, 1, 6, N'Londres_001.jpg', 1)
GO
INSERT [dbo].[Cabanas] ([Id], [NombreCabana_Value], [DescripCabana_Value], [Jacuzzi], [Habilitado], [MaxPersonas], [FotoCabana], [TipoId]) VALUES (3, N'Paris', N'Apta para eventos', 1, 0, 10, N'Paris_001.jpg', 5)
GO
INSERT [dbo].[Cabanas] ([Id], [NombreCabana_Value], [DescripCabana_Value], [Jacuzzi], [Habilitado], [MaxPersonas], [FotoCabana], [TipoId]) VALUES (4, N'Roma', N'Rústica, cerca del lago', 1, 0, 4, N'Roma_001.jpg', 1)
GO
INSERT [dbo].[Cabanas] ([Id], [NombreCabana_Value], [DescripCabana_Value], [Jacuzzi], [Habilitado], [MaxPersonas], [FotoCabana], [TipoId]) VALUES (5, N'Madrid', N'Solo parejas', 1, 0, 2, N'Madrid_001.jpg', 4)
GO
INSERT [dbo].[Cabanas] ([Id], [NombreCabana_Value], [DescripCabana_Value], [Jacuzzi], [Habilitado], [MaxPersonas], [FotoCabana], [TipoId]) VALUES (6, N'Estocolmo', N'Actividades al aire libre cerca', 0, 1, 8, N'Estocolmo_001.jpg', 2)
GO
INSERT [dbo].[Cabanas] ([Id], [NombreCabana_Value], [DescripCabana_Value], [Jacuzzi], [Habilitado], [MaxPersonas], [FotoCabana], [TipoId]) VALUES (7, N'Moscú', N'Con vista a los cerros', 0, 1, 3, N'Moscú_001.jpg', 3)
GO
INSERT [dbo].[Cabanas] ([Id], [NombreCabana_Value], [DescripCabana_Value], [Jacuzzi], [Habilitado], [MaxPersonas], [FotoCabana], [TipoId]) VALUES (8, N'Atenas', N'Amplio living, spa propio', 1, 1, 4, N'Atenas_001.jpg', 4)
GO
INSERT [dbo].[Cabanas] ([Id], [NombreCabana_Value], [DescripCabana_Value], [Jacuzzi], [Habilitado], [MaxPersonas], [FotoCabana], [TipoId]) VALUES (9, N'Praga', N'Cocina de chef', 0, 0, 6, N'Praga_001.jpg', 2)
GO
INSERT [dbo].[Cabanas] ([Id], [NombreCabana_Value], [DescripCabana_Value], [Jacuzzi], [Habilitado], [MaxPersonas], [FotoCabana], [TipoId]) VALUES (10, N'Viena', N'Para pequeños eventos empresariales', 0, 1, 10, N'Viena_001.jpg', 5)
GO
INSERT [dbo].[Cabanas] ([Id], [NombreCabana_Value], [DescripCabana_Value], [Jacuzzi], [Habilitado], [MaxPersonas], [FotoCabana], [TipoId]) VALUES (11, N'Prueba', N'Defensa defensaaaaaa', 1, 0, 3, N'Prueba_001.jpg', 1)
GO
SET IDENTITY_INSERT [dbo].[Cabanas] OFF
GO
SET IDENTITY_INSERT [dbo].[Mantenimientos] ON 
GO
INSERT [dbo].[Mantenimientos] ([Id], [FechaMant], [DescMant], [CostoMant], [Personal], [CabanaId]) VALUES (1, CAST(N'2023-05-09T22:02:00.0000000' AS DateTime2), N'Cambio de sábanas', 10, N'Luis', 1)
GO
INSERT [dbo].[Mantenimientos] ([Id], [FechaMant], [DescMant], [CostoMant], [Personal], [CabanaId]) VALUES (2, CAST(N'2023-05-11T22:03:00.0000000' AS DateTime2), N'Chequear frigobar', 15, N'Ana', 1)
GO
INSERT [dbo].[Mantenimientos] ([Id], [FechaMant], [DescMant], [CostoMant], [Personal], [CabanaId]) VALUES (3, CAST(N'2023-05-13T10:42:00.0000000' AS DateTime2), N'Descripción de mantenimiento - 1', 100, N'Luis', 1)
GO
INSERT [dbo].[Mantenimientos] ([Id], [FechaMant], [DescMant], [CostoMant], [Personal], [CabanaId]) VALUES (4, CAST(N'2023-05-13T10:44:00.0000000' AS DateTime2), N'Descripción de mantenimiento - 2', 100, N'Ana', 1)
GO
INSERT [dbo].[Mantenimientos] ([Id], [FechaMant], [DescMant], [CostoMant], [Personal], [CabanaId]) VALUES (5, CAST(N'2023-05-13T10:44:00.0000000' AS DateTime2), N'Descripción de mantenimiento - 3', 150, N'Pedro', 1)
GO
INSERT [dbo].[Mantenimientos] ([Id], [FechaMant], [DescMant], [CostoMant], [Personal], [CabanaId]) VALUES (6, CAST(N'2023-05-16T11:44:00.0000000' AS DateTime2), N'Descripción de mantenimiento - 1', 200, N'Ana', 2)
GO
INSERT [dbo].[Mantenimientos] ([Id], [FechaMant], [DescMant], [CostoMant], [Personal], [CabanaId]) VALUES (7, CAST(N'2023-05-16T11:45:00.0000000' AS DateTime2), N'Descripción de mantenimiento - 2', 105, N'Luis', 2)
GO
INSERT [dbo].[Mantenimientos] ([Id], [FechaMant], [DescMant], [CostoMant], [Personal], [CabanaId]) VALUES (8, CAST(N'2023-05-13T11:46:00.0000000' AS DateTime2), N'Descripción de mantenimiento - 1', 200, N'Pedro', 3)
GO
INSERT [dbo].[Mantenimientos] ([Id], [FechaMant], [DescMant], [CostoMant], [Personal], [CabanaId]) VALUES (9, CAST(N'2023-05-17T12:01:00.0000000' AS DateTime2), N'Descripción de mantenimiento - 2', 110, N'Ana', 3)
GO
INSERT [dbo].[Mantenimientos] ([Id], [FechaMant], [DescMant], [CostoMant], [Personal], [CabanaId]) VALUES (10, CAST(N'2023-05-14T12:02:00.0000000' AS DateTime2), N'Descripción de mantenimiento - 1', 50, N'Estela', 4)
GO
INSERT [dbo].[Mantenimientos] ([Id], [FechaMant], [DescMant], [CostoMant], [Personal], [CabanaId]) VALUES (11, CAST(N'2023-05-26T21:45:00.0000000' AS DateTime2), N'Se limpió todo, se cambiaron sábanas', 200, N'Luis', 1)
GO
INSERT [dbo].[Mantenimientos] ([Id], [FechaMant], [DescMant], [CostoMant], [Personal], [CabanaId]) VALUES (12, CAST(N'2023-05-26T21:46:00.0000000' AS DateTime2), N'Descripción de mantenimiento - 1', 100, N'Luis', 1)
GO
INSERT [dbo].[Mantenimientos] ([Id], [FechaMant], [DescMant], [CostoMant], [Personal], [CabanaId]) VALUES (13, CAST(N'2023-05-26T21:46:00.0000000' AS DateTime2), N'Descripción de mantenimiento - 2', 120, N'Luis', 1)
GO
SET IDENTITY_INSERT [dbo].[Mantenimientos] OFF
GO
SET IDENTITY_INSERT [dbo].[Parametros] ON 
GO
INSERT [dbo].[Parametros] ([Id], [Nombre], [Valor]) VALUES (1, N'MinDescripCabana', N'10')
GO
INSERT [dbo].[Parametros] ([Id], [Nombre], [Valor]) VALUES (2, N'MaxDescripCabana', N'500')
GO
INSERT [dbo].[Parametros] ([Id], [Nombre], [Valor]) VALUES (3, N'MinDescripTipo', N'10')
GO
INSERT [dbo].[Parametros] ([Id], [Nombre], [Valor]) VALUES (4, N'MaxDescripTipo', N'200')
GO
SET IDENTITY_INSERT [dbo].[Parametros] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 
GO
INSERT [dbo].[Usuarios] ([Id], [Email], [Password]) VALUES (1, N'sofi@gmail.com', N'1234abC')
GO
INSERT [dbo].[Usuarios] ([Id], [Email], [Password]) VALUES (2, N'lucas@gmail.com', N'7654abC')
GO
INSERT [dbo].[Usuarios] ([Id], [Email], [Password]) VALUES (3, N'admin@gmail.com', N'Qwerty1')
GO
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
*/
