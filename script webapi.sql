USE [PRUEBANEXT]
GO
/****** Object:  Table [dbo].[Eventos]    Script Date: 29/04/2023 4:27:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Eventos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Lugar] [varchar](50) NULL,
	[Fecha] [datetime] NULL,
	[Nroentrada] [int] NULL,
	[Descripcion] [varchar](250) NULL,
	[Precio] [decimal](18, 0) NULL,
	[Estado] [bit] NULL,
	[EstadoDesc] [varchar](50) NULL,
 CONSTRAINT [PK_Eventos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Eventos] ON 

INSERT [dbo].[Eventos] ([Id], [Lugar], [Fecha], [Nroentrada], [Descripcion], [Precio], [Estado], [EstadoDesc]) VALUES (2, N'GUAYAQUIL', CAST(N'2025-12-01T00:00:00.000' AS DateTime), 300, N'ME VERAS VOLVER', CAST(45 AS Decimal(18, 0)), 1, N'Activo')
INSERT [dbo].[Eventos] ([Id], [Lugar], [Fecha], [Nroentrada], [Descripcion], [Precio], [Estado], [EstadoDesc]) VALUES (3, N'quito', CAST(N'2023-12-18T00:00:00.000' AS DateTime), 300, N'3ME VERAS VOLVER', CAST(45 AS Decimal(18, 0)), 1, N'Activo')
INSERT [dbo].[Eventos] ([Id], [Lugar], [Fecha], [Nroentrada], [Descripcion], [Precio], [Estado], [EstadoDesc]) VALUES (4, N'quito', CAST(N'2023-12-18T00:00:00.000' AS DateTime), 300, N'3ME VERAS VOLVER', CAST(45 AS Decimal(18, 0)), 0, N'Activo')
INSERT [dbo].[Eventos] ([Id], [Lugar], [Fecha], [Nroentrada], [Descripcion], [Precio], [Estado], [EstadoDesc]) VALUES (5, N'ee', CAST(N'2025-12-12T00:00:00.000' AS DateTime), 500, N'sdsd', CAST(45 AS Decimal(18, 0)), 0, N'Activo')
INSERT [dbo].[Eventos] ([Id], [Lugar], [Fecha], [Nroentrada], [Descripcion], [Precio], [Estado], [EstadoDesc]) VALUES (6, N'gyeds', CAST(N'2023-03-31T00:00:00.000' AS DateTime), 432, N'concieto', CAST(23 AS Decimal(18, 0)), 1, N'Activo')
INSERT [dbo].[Eventos] ([Id], [Lugar], [Fecha], [Nroentrada], [Descripcion], [Precio], [Estado], [EstadoDesc]) VALUES (7, N'MACHALA', CAST(N'2023-05-27T00:00:00.000' AS DateTime), 50000, N'AVENTURA', CAST(45 AS Decimal(18, 0)), 1, N'Activo')
INSERT [dbo].[Eventos] ([Id], [Lugar], [Fecha], [Nroentrada], [Descripcion], [Precio], [Estado], [EstadoDesc]) VALUES (8, N'QUEVEDO', CAST(N'2023-04-08T00:00:00.000' AS DateTime), 2500, N'MARIA CONCHITA', CAST(30 AS Decimal(18, 0)), 1, N'Activo')
SET IDENTITY_INSERT [dbo].[Eventos] OFF
GO
ALTER TABLE [dbo].[Eventos] ADD  CONSTRAINT [DF_Eventos_Estado]  DEFAULT ((0)) FOR [Estado]
GO
ALTER TABLE [dbo].[Eventos] ADD  CONSTRAINT [DF_Eventos_EstadoDesc]  DEFAULT ('Activo') FOR [EstadoDesc]
GO
/****** Object:  StoredProcedure [dbo].[sp_Add_Evento]    Script Date: 29/04/2023 4:27:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Add_Evento]

	@Lugar  varchar(50) ,
	@Fecha datetime ,
	@Nroentrada int ,
	@Descripcion varchar(250) ,
	@Precio decimal(18, 0) 
AS
BEGIN
	INSERT INTO [dbo].[Eventos]
           ([Lugar]
           ,[Fecha]
           ,[Nroentrada]
           ,[Descripcion]
           ,[Precio]
           ,[Estado]
           ,[EstadoDesc])
     VALUES
           (@Lugar
           ,@Fecha
           ,@Nroentrada
           ,@Descripcion
           ,@Precio 
           ,1
           ,'Activo')

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Del_Evento]    Script Date: 29/04/2023 4:27:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Del_Evento]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN

	 UPDATE [dbo].[Eventos]
   SET  
      [Estado] = 0
      ,[EstadoDesc] = 'No Activo'

      WHERE [dbo].[Eventos].id =@id 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_Evento]    Script Date: 29/04/2023 4:27:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Get_Evento]
@id int
AS
BEGIN

	SELECT *  from [dbo].[Eventos]
      WHERE [dbo].[Eventos].id =@id 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_EventoTodos]    Script Date: 29/04/2023 4:27:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Get_EventoTodos]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT *  from [dbo].[Eventos]
      
END
GO
/****** Object:  StoredProcedure [dbo].[sp_upd_evento]    Script Date: 29/04/2023 4:27:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_upd_evento]
	-- Add the parameters for the stored procedure here
	@Id int,
	@Fecha datetime
AS
BEGIN
	 UPDATE [dbo].[Eventos]
   SET  [Fecha] =@Fecha
      WHERE  id=@Id

END
GO
