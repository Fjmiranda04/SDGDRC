--hfd32434Daasdj

--CREATE TABLAS
IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'WEBGLSS_Agentes'))
BEGIN
	CREATE TABLE [dbo].[WEBGLSS_Agentes](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Codigo] [varchar](10) NULL,
		[NroId] [varchar](20) NOT NULL,
		[NombreCompleto] [varchar](50) NOT NULL,
		[Email] [varchar](50) NOT NULL,
		[RecibeEmail] [bit] NULL,
		[NitEmpresa] [varchar](20) NOT NULL,
		[delmrk] [varchar](2) NULL,
	 CONSTRAINT [PK_WEBGLSS_Agentes] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'WEBGLSS_Clientes'))
BEGIN
	CREATE TABLE [dbo].[WEBGLSS_Clientes](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Codigo] [varchar](15) NULL,
		[TipoDoc] [varchar](5) NOT NULL,
		[NroId] [varchar](30) NULL,
		[NombreCompleto] [varchar](100) NULL,
		[PrimerNombre] [varchar](100) NULL,
		[SegundoNombre] [varchar](40) NULL,
		[PrimerApellido] [varchar](40) NULL,
		[SegundoApellido] [varchar](40) NULL,
		[Ciudad] [varchar](50) NULL,
		[Direccion] [varchar](90) NULL,
		[Celular] [varchar](50) NOT NULL,
		[Telefono] [varchar](50) NULL,
		[Email] [varchar](100) NOT NULL,
		[Sexo] [varchar](5) NULL,
		[FechaCreacion] [datetime2](7) NOT NULL,
		[NitEmpresa] [varchar](20) NOT NULL,
		[delmrk] [varchar](2) NULL,
	 CONSTRAINT [PK_WEBGLSS_Clientes] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'WEBGLSS_Configuracion'))
BEGIN
	CREATE TABLE [dbo].[WEBGLSS_Configuracion](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Clave] [varchar](500) NULL,
		[Valor] [varchar](100) NULL,
		[Descripcion] [varchar](200) NULL,
	 CONSTRAINT [PK_WEBGLSS_Configuracion] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'WEBGLSS_ContactoClientes'))
BEGIN
	CREATE TABLE [dbo].[WEBGLSS_ContactoClientes](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[NroIdCli] [varchar](20) NOT NULL,
		[NombreContacto] [varchar](50) NOT NULL,
		[Telefono] [varchar](20) NULL,
		[Celular] [varchar](20) NOT NULL,
		[Email] [varchar](100) NOT NULL,
		[NitEmpresa] [varchar](20) NOT NULL,
		[delmrk] [varchar](2) NULL,
	 CONSTRAINT [PK_WEBGLSS_ContactoClientes] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'WEBGLSS_Elementos'))
BEGIN
	CREATE TABLE [dbo].[WEBGLSS_Elementos](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[NumEle] [varchar](5) NULL,
		[RefEle] [varchar](15) NULL,
		[TipEle] [varchar](5) NULL,
		[NomEle] [varchar](30) NULL,
		[VlrEle] [varchar](15) NULL,
		[delmrk] [varchar](2) NULL,
	 CONSTRAINT [PK_WEBGLSS_Elementos] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'WEBGLSS_EmailConfiguracion'))
BEGIN
	CREATE TABLE [dbo].[WEBGLSS_EmailConfiguracion](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[KeyValue] [varchar](20) NOT NULL,
		[Remitente] [varchar](40) NOT NULL,
		[NombreRemitente] [varchar](100) NOT NULL,
		[ReplyTo] [varchar](500) NULL,
		[Titulo] [varchar](100) NULL,
		[Asunto] [varchar](100) NOT NULL,
		[Cuerpo] [varchar](1000) NOT NULL,
		[Template] [varchar](50) NULL,
		[LogoEmpresa] [varchar](200) NULL,
		[WebEmpresa] [varchar](50) NULL,
		[NombreEmpresa] [varchar](50) NOT NULL,
		[Token] [varchar](2000) NOT NULL,
	 CONSTRAINT [PK_WEBGLSS_EmailConfiguracion] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'WEBGLSS_Empleados'))
BEGIN
	CREATE TABLE [dbo].[WEBGLSS_Empleados](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Codigo] [nvarchar](max) NULL,
		[NroId] [varchar](20) NOT NULL,
		[NombreCompleto] [varchar](100) NOT NULL,
		[PrimerNombre] [varchar](40) NOT NULL,
		[SegundoNombre] [varchar](40) NULL,
		[PrimerApellido] [varchar](40) NOT NULL,
		[SegundoApellido] [varchar](40) NOT NULL,
		[Ciudad] [varchar](50) NOT NULL,
		[Direccion] [varchar](100) NOT NULL,
		[Celular] [varchar](50) NOT NULL,
		[Telefono] [varchar](50) NULL,
		[Email] [varchar](50) NOT NULL,
		[Sexo] [varchar](20) NOT NULL,
		[FechaCreacion] [date] NOT NULL,
		[NitEmpresa] [varchar](20) NOT NULL,
		[delmrk] [varchar](2) NULL,
	 CONSTRAINT [PK_WEBGLSS_Empleados] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'WEBGLSS_Estados'))
BEGIN
	CREATE TABLE [dbo].[WEBGLSS_Estados](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Nombre] [varchar](20) NOT NULL,
		[delmrk] [varchar](1) NULL,
	 CONSTRAINT [PK_WEBGLSS_Estados] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'WEBGLSS_Etiquetas'))
BEGIN
	CREATE TABLE [dbo].[WEBGLSS_Etiquetas](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Nombre] [varchar](40) NULL,
		[delmrk] [varchar](2) NULL,
	 CONSTRAINT [PK_WEBGLSS_Etiquetas] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'WEBGLSS_MatrizPQRSF'))
BEGIN
	CREATE TABLE [dbo].[WEBGLSS_MatrizPQRSF](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[NitEmpresa] [varchar](20) NOT NULL,
		[Fecha] [datetime] NOT NULL,
		[FechaCierre] [datetime] NOT NULL DEFAULT(GETDATE()),
		[FechaCierreReal] [datetime] NOT NULL DEFAULT('19000101'),
		[Tipo] [varchar](20) NULL DEFAULT('PQRSF Externa'),
		[Asunto] [varchar](60) NOT NULL,
		[Descripcion] [varchar](8000) NOT NULL DEFAULT(''),
		[Etiquetas] [varchar](300) NULL DEFAULT(''),
		[IdEstado] [int] NOT NULL DEFAULT(2),
		[IdPrioridad] [int] NOT NULL DEFAULT(5),
		[IdSituacion] [int] NOT NULL,
		[IdProceso] [varchar](4) NOT NULL DEFAULT('0000'),
		[IdContacto] [int] NOT NULL,
		[NroIdeCli] [varchar](30) NOT NULL,
		[NroIdResponsable] [varchar](20) NULL DEFAULT('0000000000'),
		[NroIdPerfilo] [varchar](20) NULL,
		[NroIdCerro] [varchar](20) NULL,
		[Perfilacion] [bit] NOT NULL DEFAULT(0),
	 CONSTRAINT [PK_WEBGLSS_MatrizPQRSF] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'WEBGLSS_MenuRoles'))
BEGIN
	CREATE TABLE [dbo].[WEBGLSS_MenuRoles](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[idRol] [varchar](50) NULL,
		[CodMnu] [varchar](10) NULL,
		[delmrk] [varchar](2) NULL,
	 CONSTRAINT [PK_WEBGLSS_MenuRoles] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'WEBGLSS_Menus'))
BEGIN
	CREATE TABLE [dbo].[WEBGLSS_Menus](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[CodMnu] [varchar](10) NULL,
		[NomMnu] [varchar](50) NOT NULL,
		[Orden] [varchar](3) NULL,
		[NvlMnu] [varchar](3) NULL,
		[TpoMnu] [varchar](10) NOT NULL,
		[DepMnu] [varchar](10) NOT NULL,
		[Controller] [varchar](20) NOT NULL,
		[Action] [varchar](20) NOT NULL,
		[IcoMnu] [varchar](40) NULL,
		[delmrk] [varchar](2) NULL,
	 CONSTRAINT [PK_WEBGLSS_Menus] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'WEBGLSS_MenuUsuarios'))
BEGIN
	CREATE TABLE [dbo].[WEBGLSS_MenuUsuarios](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[NroIdUsr] [varchar](20) NOT NULL,
		[CodMnu] [varchar](10) NOT NULL,
		[delmrk] [varchar](2) NULL,
	 CONSTRAINT [PK_WEBGLSS_MenuUsuarios] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC,
		[NroIdUsr] ASC,
		[CodMnu] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'WEBGLSS_NotasPQRSF'))
BEGIN
	CREATE TABLE [dbo].[WEBGLSS_NotasPQRSF](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[IdPQRSF] [int] NOT NULL,
		[Fecha] [datetime] NOT NULL,
		[Tipo] [varchar](15) NOT NULL,
		[Nota] [varchar](1000) NOT NULL,
		[NroIdeAutor] [varchar](20) NULL,
		[NitEmpresa] [varchar](20) NOT NULL,
	 CONSTRAINT [PK_WEBGLSS_NotasPQRSF] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'WEBGLSS_Perfiles'))
BEGIN
	CREATE TABLE [dbo].[WEBGLSS_Perfiles](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[CodPerfil] [varchar](10) NOT NULL,
		[NomPerfil] [varchar](40) NOT NULL,
		[delmrk] [varchar](2) NULL,
	 CONSTRAINT [PK_WEBGLSS_Perfiles] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'WEBGLSS_Preguntas'))
BEGIN
	CREATE TABLE [dbo].[WEBGLSS_Preguntas](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[NomPregunta] [varchar](200) NOT NULL,
		[NitEmpresa] [varchar](20) NOT NULL,
		[delmrk] [varchar](2) NULL,
	 CONSTRAINT [PK_WEBGLSS_Preguntas] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'WEBGLSS_Prioridades'))
BEGIN
	CREATE TABLE [dbo].[WEBGLSS_Prioridades](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Nombre] [varchar](20) NOT NULL,
		[delmrk] [varchar](1) NULL,
	 CONSTRAINT [PK_WEBGLSS_Prioridades] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'WEBGLSS_Procesos'))
BEGIN
	CREATE TABLE [dbo].[WEBGLSS_Procesos](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Nombre] [varchar](30) NULL,
		[delmrk] [varchar](2) NULL,
	 CONSTRAINT [PK_WEBGLSS_Procesos] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'WEBGLSS_Respuestas'))
BEGIN
	CREATE TABLE [dbo].[WEBGLSS_Respuestas](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[IdPregunta] [int] NOT NULL,
		[IdPQRSF] [int] NOT NULL,
		[Opcion] [bit] NULL,
		[Observaciones] [varchar](100) NULL,
		[NitEmpresa] [varchar](20) NOT NULL,
		[delmrk] [varchar](2) NULL,
	 CONSTRAINT [PK_WEBGLSS_Respuestas] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'WEBGLSS_Seguimientos'))
BEGIN
	CREATE TABLE [dbo].[WEBGLSS_Seguimientos](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[IdPQRSF] [int] NOT NULL,
		[Fecha] [date] NOT NULL,
		[NitEmpresa] [nvarchar](max) NULL,
		[Observaciones] [varchar](200) NOT NULL,
	 CONSTRAINT [PK_WEBGLSS_Seguimientos] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'WEBGLSS_SituacionesNoConformes'))
BEGIN
	CREATE TABLE [dbo].[WEBGLSS_SituacionesNoConformes](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Codigo] [varchar](4) NULL,
		[TipoSituacion] [varchar](20) NULL,
		[delmrk] [varchar](2) NULL,
	 CONSTRAINT [PK_WEBGLSS_SituacionesNoConformes] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'WEBGLSS_SolicitudClientes'))
BEGIN
	CREATE TABLE [dbo].[WEBGLSS_SolicitudClientes](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Codigo] [varchar](20) NOT NULL,
		[TipDoc] [varchar](5) NOT NULL,
		[NroIde] [varchar](20) NOT NULL,
		[NombreCompleto] [varchar](100) NOT NULL,
		[PrimerNombre] [varchar](40) NOT NULL,
		[SegundoNombre] [varchar](40) NULL,
		[PrimerApellido] [varchar](40) NOT NULL,
		[SegundoApellido] [varchar](40) NOT NULL,
		[Ciudad] [varchar](50) NOT NULL,
		[Direccion] [varchar](90) NOT NULL,
		[Celular] [varchar](20) NOT NULL,
		[Telefono] [varchar](20) NOT NULL,
		[Email] [varchar](50) NOT NULL,
		[Password] [varchar](50) NOT NULL,
		[FechaCreacion] [datetime2](7) NOT NULL,
		[NitEmpresa] [varchar](20) NOT NULL,
		[Estado] [varchar](2) NOT NULL,
		[delmrk] [varchar](2) NULL,
	 CONSTRAINT [PK_WEBGLSS_SolicitudClientes] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'WEBGLSS_Terceros'))
BEGIN
	CREATE TABLE [dbo].[WEBGLSS_Terceros](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Codigo] [varchar](20) NOT NULL,
		[TipoDoc] [varchar](5) NOT NULL,
		[NroId] [varchar](20) NOT NULL,
		[NombreCompleto] [varchar](100) NOT NULL,
		[PrimerNombre] [varchar](40) NOT NULL,
		[SegundoNombre] [varchar](40) NULL,
		[PrimerApellido] [varchar](40) NOT NULL,
		[SegundoApellido] [varchar](40) NOT NULL,
		[Ciudad] [varchar](50) NOT NULL,
		[Direccion] [varchar](90) NOT NULL,
		[Celular] [varchar](20) NOT NULL,
		[Telefono] [varchar](20) NOT NULL,
		[Email] [varchar](50) NOT NULL,
		[FechaCreacion] [datetime2](7) NOT NULL,
		[NitEmpresa] [varchar](20) NOT NULL,
		[Usuario] [varchar](40) NULL,
		[delmrk] [varchar](2) NULL,
	 CONSTRAINT [PK_WEBGLSS_Terceros] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'WEBGLSS_TratamientosPQRSF'))
BEGIN
	CREATE TABLE [dbo].[WEBGLSS_TratamientosPQRSF](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[IdPQRSF] [int] NOT NULL,
		[Actividad] [varchar](200) NOT NULL,
		[NroIdResponsable] [varchar](20) NOT NULL,
		[FechaCumplimiento] [date] NOT NULL,
		[Observaciones] [text] NULL,
		[NitEmpresa] [varchar](20) NOT NULL,
		[Checked] [bit] NULL,
		[FechaCheck] [date] NOT NULL,
		[EnvioCorreo] [bit] NULL,
	 CONSTRAINT [PK_WEBGLSS_TratamientosPQRSF] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'WEBGLSS_UsuarioEmpresas'))
BEGIN
	CREATE TABLE [dbo].[WEBGLSS_UsuarioEmpresas](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[IdEmpresa] [int] NOT NULL,
		[NitEmpresa] [varchar](20) NOT NULL,
		[NroIde] [varchar](20) NOT NULL,
		[Email] [varchar](40) NOT NULL,
	 CONSTRAINT [PK_WEBGLSS_UsuarioEmpresas] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'WEBGLSSS_Archivos'))
BEGIN
	CREATE TABLE [dbo].[WEBGLSSS_Archivos](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[CodPQRSF] [int] NOT NULL,
		[Nombre] [varchar](100) NULL,
		[Ruta] [varchar](150) NULL,
		[Url] [varchar](200) NULL,
		[ContentType] [varchar](150) NULL,
		[NitEmpresa] [varchar](20) NOT NULL,
		[delmrk] [varchar](2) NULL,
	 CONSTRAINT [PK_WEBGLSSS_Archivos] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'WEBGLSS_Permisos'))
BEGIN
	CREATE TABLE [dbo].[WEBGLSS_Permisos]
	(
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[codigo] [varchar](6) NOT NULL,
		[Permiso] [varchar](500) NOT NULL,
		[Descripcion] [varchar](1000) NOT NULL,
		[Tipo] [varchar](50) NULL,
	 ) ON [PRIMARY] 
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'WEBGLSS_PermisosUsuarios'))
BEGIN
	CREATE TABLE [dbo].[WEBGLSS_PermisosUsuarios]
	(
		[IdUsuario] [varchar] (200) NOT NULL,
		[IdPermiso] [int] NOT NULL,
		[Activo] [bit] NOT NULL,
	 ) ON [PRIMARY] 
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'WEBGLSS_Proponentes'))
BEGIN

	CREATE TABLE [dbo].[WEBGLSS_Proponentes]
	(
		[IdProponente] [int] IDENTITY(1,1),
		[IdEmpresa] [int] NOT NULL DEFAULT(0),
		[NitEmpresa] [varchar](20) NOT NULL DEFAULT(''),
		[Password] [varchar](100) NOT NULL DEFAULT(''),
		[delmrk] [varchar](1) NOT NULL DEFAULT ('1'),
		[pronit] [varchar](15) NOT NULL DEFAULT (''),
		[pronom] [varchar](100) NOT NULL DEFAULT (''),
		[PRONIT1] [varchar](15) NOT NULL DEFAULT (''),
		[procod] [varchar](10) NULL DEFAULT (''),
		[proconta] [varchar](50) NOT NULL DEFAULT (''),
		[procargo] [varchar](50) NOT NULL DEFAULT (''),
		[prodir] [varchar](200) NULL DEFAULT (''),
		[prociud] [varchar](100) NOT NULL DEFAULT (''),
		[promail] [varchar](200) NULL DEFAULT (''),
		[procuen] [varchar](200) NULL DEFAULT (''),
		[protel] [varchar](50) NULL DEFAULT (''),
		[profax] [varchar](50) NOT NULL DEFAULT (''),
		[proaa] [varchar](10) NOT NULL DEFAULT (''),
		[proban] [varchar](100) NOT NULL DEFAULT (''),
		[proauto] [numeric](1, 0) NOT NULL DEFAULT ((0)),
		[progran] [numeric](1, 0) NOT NULL DEFAULT ((0)),
		[proica] [numeric](1, 0) NOT NULL DEFAULT ((0)),
		[proregi] [numeric](1, 0) NOT NULL DEFAULT ((0)),
		[proautoica] [numeric](1, 0) NOT NULL DEFAULT ((0)),
		[proPriNom] [varchar](20) NOT NULL DEFAULT (''),
		[proSegNom] [varchar](30) NOT NULL DEFAULT (''),
		[proPriApe] [varchar](20) NOT NULL DEFAULT (''),
		[proSegApe] [varchar](30) NOT NULL DEFAULT (''),
		[tipDoc] [varchar](2) NOT NULL DEFAULT (''),
		[digVer] [varchar](1) NOT NULL DEFAULT (''),
		[proconta2] [varchar](30) NOT NULL DEFAULT (''),
		[protel2] [varchar](40) NOT NULL DEFAULT (''),
		[procel] [varchar](50) NOT NULL DEFAULT (''),
		[proweb] [varchar](40) NOT NULL DEFAULT (''),
		[proObser] [varchar](60) NOT NULL DEFAULT (''),
		[tipDocu] [varchar](2) NOT NULL DEFAULT (''),
		[proreplegal] [varchar](100) NOT NULL DEFAULT (''),
		[protipcuen] [int] NOT NULL DEFAULT ((0)),
		[prores] [varchar](100) NOT NULL DEFAULT (''),
		[prores2] [varchar](100) NOT NULL DEFAULT (''),
		[proactividad] [varchar](150) NOT NULL DEFAULT (''),
		[pronoactividad] [numeric](5, 0) NOT NULL  DEFAULT ((0)),
		[profecres] [datetime] NOT NULL DEFAULT (''),
		[profecres2] [datetime] NOT NULL DEFAULT (''),
		[proporica] [numeric](18, 3) NOT NULL DEFAULT ((0)),
		[procer] [int] NOT NULL DEFAULT ((0)),
		[proent] [varchar](100) NOT NULL DEFAULT (''),
		[proproc] [int] NOT NULL DEFAULT ((0)),
		[procual] [varchar](100) NOT NULL DEFAULT (''),
		[prosis] [int] NOT NULL DEFAULT ((0)),
		[proesta] [int] NOT NULL DEFAULT ((0)),
		[proase] [int] NOT NULL DEFAULT ((0)),
		[proflex] [int] NOT NULL DEFAULT ((0)),
		[propres] [int] NOT NULL DEFAULT ((0)),
		[prociudades] [varchar](150) NOT NULL  DEFAULT (''),
		[proasesores] [varchar](150) NOT NULL  DEFAULT (''),
		[procondiciones] [varchar](500) NOT NULL  DEFAULT (''),
		[proced] [varchar](50) NOT NULL  DEFAULT (''),
		[pronom2] [varchar](100) NOT NULL  DEFAULT (''),
		[pronit2] [varchar](100) NOT NULL  DEFAULT (''),
		[proCla] [int] NOT NULL DEFAULT ((1)),
		[proCal] [varchar](4) NOT NULL DEFAULT (''),
		[proCodCiud] [varchar](5) NOT NULL DEFAULT (''),
		[proPersona] [int] NOT NULL DEFAULT (0),
		[proPais] [varchar](10) NOT NULL DEFAULT (''),
		[proTarjeta] [varchar](25) NOT NULL DEFAULT (''),
		[proCredaDias] [int] NOT NULL DEFAULT ((0)),
		[proTipoProvee] [varchar](15) NOT NULL DEFAULT (''),
		[procodActividad] [varchar](4) NOT NULL DEFAULT (''),
		[activc] [int] NOT NULL DEFAULT ((0)),
		[RUt] [varchar](20) NOT NULL DEFAULT (''),
		[fechav] [datetime] NOT NULL DEFAULT ('19000101'),
		[InscrR] [datetime] NOT NULL DEFAULT ('19000101'),
		[RUp] [int] NOT NULL DEFAULT ((0)),
		[certie] [int] NOT NULL DEFAULT ((0)),
		[timeEnv] [int] NOT NULL DEFAULT ((0)),
		[garanp] [int] NOT NULL DEFAULT ((0)),
		[bienser] [int] NOT NULL DEFAULT ((0)),
		[Nummatri] [varchar](20) NOT NULL DEFAULT (''),
		[Rfinal] [numeric](18, 0) NOT NULL DEFAULT ((0)),
		[Generaf] [int] NOT NULL DEFAULT ((0)),
		[Rinicial] [numeric](18, 0) NOT NULL DEFAULT ((0)),
		[Reteiva] [varchar](20) NOT NULL DEFAULT (''),
		[Reteica] [varchar](20) NOT NULL DEFAULT (''),
		[Retefuen] [varchar](20) NOT NULL DEFAULT (''),
		[proestado] [int] NOT NULL DEFAULT ((2)),
		[proiva] [numeric](1, 0) NOT NULL DEFAULT ((0)),
		[prodeclarar] [int] NOT NULL DEFAULT ((0)),
		[ContCalificacion] [varchar](4) NOT NULL DEFAULT (''),
		[ProFechaServer] [datetime] NOT NULL DEFAULT (getdate()),
		[proTipoTer] [varchar](8) NOT NULL DEFAULT ((1)),
		[ProEstacion] [varchar](200) NOT NULL DEFAULT (host_name()),
		[ProUsuario] [varchar](200) NOT NULL DEFAULT (''),
		[ModifiedByUser] [varchar](200) NULL DEFAULT (''),
		[InsDateTime] [datetime] NOT NULL DEFAULT (getdate()),
		[proOblFac] [int] NOT NULL DEFAULT ((0)),
		[proEtiqueta] [varchar](20) NOT NULL DEFAULT (''),
		[proRst] [int] NOT NULL DEFAULT ((0)),
	) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'WEBGLSS_SolicitudNovedades'))
BEGIN
	CREATE TABLE [dbo].[WEBGLSS_SolicitudNovedades]
	(
		[Id] [int] identity(1,1) NOT NULL,
		[Codigo] [varchar](20) NOT NULL DEFAULT(''),
		[Fecha] [datetime] NOT NULL DEFAULT GETDATE(),
		[TipoNovedad] [varchar](4) NOT NULL DEFAULT(''),
		[CodigoEmp] [varchar](20) NOT NULL DEFAULT(''),
		[ValorAnterior] [varchar](30) NOT NULL DEFAULT(''),
		[ValorAnteriorExt] [varchar](30) NOT NULL DEFAULT(''),
		[ValorNuevo] [varchar](30) NOT NULL DEFAULT(''),
		[ValorNuevoExt] [varchar](30) NOT NULL DEFAULT(''),
		[Motivo] [varchar](250) NOT NULL DEFAULT(''),
		[Descripcion] [varchar](250) NOT NULL DEFAULT(''),
		[Estado] [int] NOT NULL DEFAULT(0),
		[FechaAprobacion] [datetime] NOT NULL DEFAULT'19000101',
		[UsuarioAprobo] [varchar](100) NOT NULL DEFAULT '',
		[RazonesAprobacion] [varchar](250) NOT NULL DEFAULT ''
	 ) ON [PRIMARY] 
END
GO
--END CREATE TABLAS


-- START ALTER CAMPOS TABLAS
IF NOT EXISTS ( select * from dbo.syscolumns where id = object_id(N'[dbo].[WEBGLSS_Agentes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1 and  name = 'Area')
	ALTER TABLE WEBGLSS_Agentes ADD Area VARCHAR(5) DEFAULT '' NOT NULL
GO

IF NOT EXISTS ( select * from dbo.syscolumns where id = object_id(N'[dbo].[WEBGLSS_SolicitudClientes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1 and  name = 'Password')
	ALTER TABLE WEBGLSS_SolicitudClientes ADD Password VARCHAR(50) DEFAULT '' NOT NULL
GO

IF NOT EXISTS ( select * from dbo.syscolumns where id = object_id(N'[dbo].[WEBGLSS_SolicitudNovedades]') and OBJECTPROPERTY(id, N'IsUserTable') = 1 and  name = 'FechaPeriodoI')
	ALTER TABLE WEBGLSS_SolicitudNovedades ADD FechaPeriodoI DATE DEFAULT '19000101' NOT NULL
GO

IF NOT EXISTS ( select * from dbo.syscolumns where id = object_id(N'[dbo].[WEBGLSS_SolicitudNovedades]') and OBJECTPROPERTY(id, N'IsUserTable') = 1 and  name = 'FechaPeriodoF')
	ALTER TABLE WEBGLSS_SolicitudNovedades ADD FechaPeriodoF DATE DEFAULT '19000101' NOT NULL
GO

IF NOT EXISTS ( select * from dbo.syscolumns where id = object_id(N'[dbo].[WEBGLSS_SolicitudNovedades]') and OBJECTPROPERTY(id, N'IsUserTable') = 1 and  name = 'FechaVacacionesI')
	ALTER TABLE WEBGLSS_SolicitudNovedades ADD FechaVacacionesI DATE DEFAULT '19000101' NOT NULL
GO

IF NOT EXISTS ( select * from dbo.syscolumns where id = object_id(N'[dbo].[WEBGLSS_SolicitudNovedades]') and OBJECTPROPERTY(id, N'IsUserTable') = 1 and  name = 'FechaVacacionesF')
	ALTER TABLE WEBGLSS_SolicitudNovedades ADD FechaVacacionesF DATE DEFAULT '19000101' NOT NULL
GO

IF NOT EXISTS ( select * from dbo.syscolumns where id = object_id(N'[dbo].[WEBGLSS_SolicitudNovedades]') and OBJECTPROPERTY(id, N'IsUserTable') = 1 and  name = 'DiasHabiles')
	ALTER TABLE WEBGLSS_SolicitudNovedades ADD DiasHabiles INT DEFAULT 0 NOT NULL
GO

IF NOT EXISTS ( select * from dbo.syscolumns where id = object_id(N'[dbo].[WEBGLSS_SolicitudNovedades]') and OBJECTPROPERTY(id, N'IsUserTable') = 1 and  name = 'DiasCompensados')
	ALTER TABLE WEBGLSS_SolicitudNovedades ADD DiasCompensados INT DEFAULT 0 NOT NULL
GO

IF NOT EXISTS ( select * from dbo.syscolumns where id = object_id(N'[dbo].[WEBGLSS_SolicitudNovedades]') and OBJECTPROPERTY(id, N'IsUserTable') = 1 and  name = 'DiasDisfrute')
	ALTER TABLE WEBGLSS_SolicitudNovedades ADD DiasDisfrute INT DEFAULT 0 NOT NULL
GO

IF NOT EXISTS ( select * from dbo.syscolumns where id = object_id(N'[dbo].[WEBGLSS_SolicitudNovedades]') and OBJECTPROPERTY(id, N'IsUserTable') = 1 and  name = 'TotalDias')
	ALTER TABLE WEBGLSS_SolicitudNovedades ADD TotalDias INT DEFAULT 0 NOT NULL
GO

IF NOT EXISTS ( select * from dbo.syscolumns where id = object_id(N'[dbo].[WEBGLSS_SolicitudNovedades]') and OBJECTPROPERTY(id, N'IsUserTable') = 1 and  name = 'DiasPagar')
	ALTER TABLE WEBGLSS_SolicitudNovedades ADD DiasPagar INT DEFAULT 0 NOT NULL
GO

-- END ALTER CAMPOS TABLAS


-- START CREATE TYPES
IF NOT EXISTS(SELECT * FROM SYS.types WHERE NAME = 'WEBGLSS_TypeDetalles') 
BEGIN
	CREATE TYPE [dbo].[WEBGLSS_TypeDetalles] AS TABLE(  								
			 		 codigo					VARCHAR(20)
					,cantidad				NUMERIC(18,2)			
			 		,detalle				VARCHAR(200)
					,medida					VARCHAR(5)
					,vlrUni					NUMERIC(18,2)
					,tipoMov				VARCHAR(4)
					,cuentaInv				VARCHAR(15)
					,cuentaCos				VARCHAR(15)
					,cuentaIng				VARCHAR(15)
					,tecnico				VARCHAR(20)
					,iva					NUMERIC(18,2)
					,costo					NUMERIC(18,2)
					,dependencia			VARCHAR(6)
					,escala					VARCHAR(10)
					,porDescuento			VARCHAR(6)
					,tercero				VARCHAR(20)
					,valorIva				NUMERIC(18,2)
					,subtotal				NUMERIC(18,2)
					,cco					VARCHAR(6)
					,NumDoc					VARCHAR(20)
					,tipdoc_ped				VARCHAR(10)
				);
END
GO

IF NOT EXISTS(SELECT * FROM SYS.types WHERE NAME = 'WEBGLSS_TypeConfiguracion') 
BEGIN
	CREATE TYPE [dbo].[WEBGLSS_TypeConfiguracion] AS TABLE(  								
			 		 Id						INT
					,Clave					VARCHAR(500)			
			 		,Valor					VARCHAR(100)
					,Descripcion			VARCHAR(2005)
				);
END
GO

-- END CREATE TYPES

-- START INSERTS VALUES


--IF NOT EXISTS (SELECT * FROM WEBGLSS_Configuracion)
--BEGIN	
--	SET IDENTITY_INSERT [dbo].[WEBGLSS_Configuracion] ON 
--	INSERT [dbo].[WEBGLSS_Configuracion] ([Id], [Clave], [Valor], [Descripcion]) VALUES (1, N'ID_EMPRESA', N'1', N'IdEmpresa')
--	INSERT [dbo].[WEBGLSS_Configuracion] ([Id], [Clave], [Valor], [Descripcion]) VALUES (2, N'PRINCIPAL_EMAILS', N'jairo142014@hotmail.com', N'Correos Confirmacion')
--	INSERT [dbo].[WEBGLSS_Configuracion] ([Id], [Clave], [Valor], [Descripcion]) VALUES (3, N'AWS_URL_BUCKET', N'https://gl-901362291.s3.amazonaws.com/', N'Url Bucket AWS')
--	INSERT [dbo].[WEBGLSS_Configuracion] ([Id], [Clave], [Valor], [Descripcion]) VALUES (4, N'AWS_ID_BUCKET', N'us-east-1:c432f057-8e05-435e-a7fb-308c70fe1cb5', N'IdBucket')
--	INSERT [dbo].[WEBGLSS_Configuracion] ([Id], [Clave], [Valor], [Descripcion]) VALUES (5, N'AWS_NAME_BUCKET', N'gl-901362291', N'NombreBucket')
--	INSERT [dbo].[WEBGLSS_Configuracion] ([Id], [Clave], [Valor], [Descripcion]) VALUES (6, N'LOGO_EMPRESA', N'/img/logos/LogoGLpb.png', N'Logo de la empresa')
--	INSERT [dbo].[WEBGLSS_Configuracion] ([Id], [Clave], [Valor], [Descripcion]) VALUES (7, N'WEB_EMPRESA', N'https://www.glerp.net.co/', N'Pagina de la empresa')
--	INSERT [dbo].[WEBGLSS_Configuracion] ([Id], [Clave], [Valor], [Descripcion]) VALUES (8, N'CONNECTION_STRING', N'GLSELFSERVICE_KEY', N'Key Cadena Conexión')
--	INSERT [dbo].[WEBGLSS_Configuracion] ([Id], [Clave], [Valor], [Descripcion]) VALUES (9, N'NIT_EMPRESA', N'901362291', N'Numero Nit de la Empresa')
--	INSERT [dbo].[WEBGLSS_Configuracion] ([Id], [Clave], [Valor], [Descripcion]) VALUES (10, N'NAME_EMPRESA', N'GENERAL LEDGER & CIA', N'Nombre de la empresa')
--	SET IDENTITY_INSERT [dbo].[WEBGLSS_Configuracion] OFF
--END
--GO

	INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'a17942b2-986e-4901-9765-1d8e22e70ae3', N'AGENTE', N'AGENTE', N'c61bdafe-2174-4574-8e35-8f6db8f48218')

	INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'ef7c9c4e-6671-4f75-a5d0-147cd17722fd', N'CLIENTE', N'CLIENTE', N'a0285306-ce55-4535-a945-e6a0fad2be1d')

	INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'f2224629-c117-4247-aece-812b8950fc03', N'ADMIN', N'ADMIN', N'92c8a3fc-8668-4c77-8c5b-f6598a23f8e1')

END
GO


IF NOT EXISTS (SELECT * FROM WEBGLSS_Configuracion)
BEGIN	
	SET IDENTITY_INSERT [dbo].[WEBGLSS_Configuracion] ON 
	INSERT [dbo].[WEBGLSS_Configuracion] ([Id], [Clave], [Valor], [Descripcion]) VALUES (1, N'ID_EMPRESA', N'1', N'IdEmpresa')
	INSERT [dbo].[WEBGLSS_Configuracion] ([Id], [Clave], [Valor], [Descripcion]) VALUES (2, N'PRINCIPAL_EMAILS', N'jairo142014@hotmail.com', N'Correos Confirmacion')
	INSERT [dbo].[WEBGLSS_Configuracion] ([Id], [Clave], [Valor], [Descripcion]) VALUES (3, N'AWS_URL_BUCKET', N'https://gl-901362291.s3.amazonaws.com/', N'Url Bucket AWS')
	INSERT [dbo].[WEBGLSS_Configuracion] ([Id], [Clave], [Valor], [Descripcion]) VALUES (4, N'AWS_ID_BUCKET', N'us-east-1:c432f057-8e05-435e-a7fb-308c70fe1cb5', N'IdBucket')
	INSERT [dbo].[WEBGLSS_Configuracion] ([Id], [Clave], [Valor], [Descripcion]) VALUES (5, N'AWS_NAME_BUCKET', N'gl-901362291', N'NombreBucket')
	INSERT [dbo].[WEBGLSS_Configuracion] ([Id], [Clave], [Valor], [Descripcion]) VALUES (6, N'LOGO_EMPRESA', N'/img/logos/LogoGLpb.png', N'Logo de la empresa')
	INSERT [dbo].[WEBGLSS_Configuracion] ([Id], [Clave], [Valor], [Descripcion]) VALUES (7, N'WEB_EMPRESA', N'https://www.glerp.net.co/', N'Pagina de la empresa')
	INSERT [dbo].[WEBGLSS_Configuracion] ([Id], [Clave], [Valor], [Descripcion]) VALUES (8, N'CONNECTION_STRING', N'GLSELFSERVICE_KEY', N'Key Cadena Conexión')
	INSERT [dbo].[WEBGLSS_Configuracion] ([Id], [Clave], [Valor], [Descripcion]) VALUES (9, N'NIT_EMPRESA', N'901362291', N'Numero Nit de la Empresa')
	INSERT [dbo].[WEBGLSS_Configuracion] ([Id], [Clave], [Valor], [Descripcion]) VALUES (10, N'NAME_EMPRESA', N'GENERAL LEDGER & CIA', N'Nombre de la empresa')
	SET IDENTITY_INSERT [dbo].[WEBGLSS_Configuracion] OFF
END
GO

IF NOT EXISTS (SELECT * FROM WEBGLSS_EmailConfiguracion)
BEGIN
	
	SET IDENTITY_INSERT [dbo].[WEBGLSS_EmailConfiguracion] ON 
	INSERT [dbo].[WEBGLSS_EmailConfiguracion] ([KeyValue], [Remitente], [NombreRemitente], [ReplyTo], [Titulo], [Asunto], [Cuerpo], [Template], [LogoEmpresa], [WebEmpresa], [NombreEmpresa], [Token]) 
	VALUES (
	 N'MAILCLIENTEPQRSF'
	, N'notificaciones@glerp.net.co'
	, N'Notificaciones Sismedica SAS'
	, N'jairo142014@hotmail.com'
	, N'NOTIFICACI�N NUEVA PQRSF'
	, N'Nueva PQRSFs'
	, N'Cordial saludo Sr(a). <<NOMBRECLIENTE>>.    Usted ha enviado una nueva PQRSF con la siguiente informaci�n: <br>     Fecha de radicaci�n: <<FECHA>> <br>   PQRSF Nro: <<NUMERO>> <br>   Tipo de PQRSF: <<TIPO>> <br>   Descripci�n: <<DESCRIPCION>> <br>   Unos de nuestros agentes atendera su PQRSF en la brevedad posible.<br>�Fel�z d�a!" <br>  Ingrese aqu� para ver la informaci�n de su PQRSF: <a href="<<LINK>>">Ver PQRSF </a>'
	, N'351ndgwv6dqlzqx8'
	, N'https://www.glerp.net.co/wp-content/uploads/2017/02/logo-general-ledger-ac-edwards2.png'
	, N'glerp.net.co'
	, N'Sismedica SAS SAS'
	, N'Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiIxIiwianRpIjoiNzZkM2M4MmE1MTIxYzdkNWRjNmEyM2Y2ZTkyODAwYTVhNWMxNWU1NTYyNGI3YmEyYTRjYTdmZjM5ZWYxZTdlN2QyZGFhNDk5YmMwY2ZiNjgiLCJpYXQiOjE2NDM3NzA4MjQuNDIxMTQ1LCJuYmYiOjE2NDM3NzA4MjQuNDIxMTUsImV4cCI6NDc5OTQ0NDQyNC40MTc0ODcsInN1YiI6IjIxMjEiLCJzY29wZXMiOlsiZW1haWxfZnVsbCIsImRvbWFpbnNfZnVsbCIsImFjdGl2aXR5X2Z1bGwiLCJhbmFseXRpY3NfZnVsbCIsInRva2Vuc19mdWxsIiwid2ViaG9va3NfZnVsbCIsInRlbXBsYXRlc19mdWxsIiwic3VwcHJlc3Npb25zX2Z1bGwiXX0.e6pHAy-tLQX-jfbWUTS9WIQatlKQkrh0U-UT-BH302ZvN4sroUPlqnfd6eKRUIlXJrv3DXqbTCoTjDikJhr7IjP4nKouBbLbXAViKGaNkX8FYkdr5f4vi9tyYdvqz0m7wA58zE4bA__X-zqjfvj3JNdD3Jm1-hDTbrD1r3i8ICxqWfyXhXxupKS9WRRfInxzegT2QDwOHXfUHQ1o3HSVZlNfMeiEm5W-QyJLTCIdzbbsP0homDWcK2gdGWkHvguTcGqF3CdFGO50D9EOHSly5Oalmq1DHgL3O4-a72nXV2kT0ohn43FL1BrRuhBvumOsN9BGoR1AjOmfXf13COtuY_tB62h5pRlJTOBcvvUqnuYE28_cGtDV7dqVoqWT7g_PHSjAL5Y4ZLpu2jQ6ObTg40Vs4jYajGsEMrJalwd0OaCuV7fhTQM9o1PxiFQ1XuAFjfIgByQKRk_NkZcVZfnZ2AUnkhJ0xbYLHN9oAO221pzO6BUa_OjzZbg-P8nssYsaGSiGhIvXvddDfhlSZRD4XHNNj8bAeCV0JUrahjjZru2hoKl2yYXK330McBHre0brDoJqp4YkKzVnenvK8l80Jh7uIdp2oDJrD5nZFdpoie1MkWgKMm1bMoeYVEiZeNardP2D00bfmyALKLofZYhKTTRV0itkTAKE2jXtQrJrrqE')
	
	INSERT [dbo].[WEBGLSS_EmailConfiguracion] ( [KeyValue], [Remitente], [NombreRemitente], [ReplyTo], [Titulo], [Asunto], [Cuerpo], [Template], [LogoEmpresa], [WebEmpresa], [NombreEmpresa], [Token]) VALUES ( N'REQUEST_NEW_USER', N'notificaciones@glerp.net.co', N'Notificaciones Sismedica SAS SAS', N'jairo142014@hotmail.com', N'NOTIFICACIÓN NUEVA SOLICITUD DE REGISTRO DE USUARIO', N'Solicitud de nuevo usuario', N'Un nuevo usuario ha realizado una solicitud para  registrarse en el sistema:
	<table style="border: 1px solid black;border-collapse: collapse">
	<tbody>
	<tr>
	<td style="font-weight:bold">Identificaci�n:</td>
	<td><<TIPDOC>>. <<NUMDOC>></td>
	</tr>
	<tr>
	<td style="font-weight:bold">Nombre y Apellidos:</td>
	<td><<NOMBRE>> <<APELLIDOS>></td>
	</tr>
	<tr>
	<td style="font-weight:bold">Ciudad:</td>
	<td ><<CIUDAD>></td>
	</tr>
	<tr>
	<td style="font-weight:bold">Direcci�n:</td>
	<td><<DIRECCION>></td>
	</tr>
	<tr>
	<td style="font-weight:bold">No.Celular:</td>
	<td><<CELULAR>></td>
	</tr>
	<tr>
	<td style="font-weight:bold">Tel�fono:</td>
	<td><<TELEFONO>></td>
	</tr>
	<tr>
	<td style="font-weight:bold">Email:</td>
	<td><<EMAIL>></td>
	</tr>
	</tbody>
	</table>', N'351ndgwv6dqlzqx8', N'https://www.glerp.net.co/wp-content/uploads/2017/02/logo-general-ledger-ac-edwards2.png', N'glerp.net.co', N'Sismedica SAS SAS', N'Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiIxIiwianRpIjoiNzZkM2M4MmE1MTIxYzdkNWRjNmEyM2Y2ZTkyODAwYTVhNWMxNWU1NTYyNGI3YmEyYTRjYTdmZjM5ZWYxZTdlN2QyZGFhNDk5YmMwY2ZiNjgiLCJpYXQiOjE2NDM3NzA4MjQuNDIxMTQ1LCJuYmYiOjE2NDM3NzA4MjQuNDIxMTUsImV4cCI6NDc5OTQ0NDQyNC40MTc0ODcsInN1YiI6IjIxMjEiLCJzY29wZXMiOlsiZW1haWxfZnVsbCIsImRvbWFpbnNfZnVsbCIsImFjdGl2aXR5X2Z1bGwiLCJhbmFseXRpY3NfZnVsbCIsInRva2Vuc19mdWxsIiwid2ViaG9va3NfZnVsbCIsInRlbXBsYXRlc19mdWxsIiwic3VwcHJlc3Npb25zX2Z1bGwiXX0.e6pHAy-tLQX-jfbWUTS9WIQatlKQkrh0U-UT-BH302ZvN4sroUPlqnfd6eKRUIlXJrv3DXqbTCoTjDikJhr7IjP4nKouBbLbXAViKGaNkX8FYkdr5f4vi9tyYdvqz0m7wA58zE4bA__X-zqjfvj3JNdD3Jm1-hDTbrD1r3i8ICxqWfyXhXxupKS9WRRfInxzegT2QDwOHXfUHQ1o3HSVZlNfMeiEm5W-QyJLTCIdzbbsP0homDWcK2gdGWkHvguTcGqF3CdFGO50D9EOHSly5Oalmq1DHgL3O4-a72nXV2kT0ohn43FL1BrRuhBvumOsN9BGoR1AjOmfXf13COtuY_tB62h5pRlJTOBcvvUqnuYE28_cGtDV7dqVoqWT7g_PHSjAL5Y4ZLpu2jQ6ObTg40Vs4jYajGsEMrJalwd0OaCuV7fhTQM9o1PxiFQ1XuAFjfIgByQKRk_NkZcVZfnZ2AUnkhJ0xbYLHN9oAO221pzO6BUa_OjzZbg-P8nssYsaGSiGhIvXvddDfhlSZRD4XHNNj8bAeCV0JUrahjjZru2hoKl2yYXK330McBHre0brDoJqp4YkKzVnenvK8l80Jh7uIdp2oDJrD5nZFdpoie1MkWgKMm1bMoeYVEiZeNardP2D00bfmyALKLofZYhKTTRV0itkTAKE2jXtQrJrrqE')
	
	INSERT [dbo].[WEBGLSS_EmailConfiguracion] ( [KeyValue], [Remitente], [NombreRemitente], [ReplyTo], [Titulo], [Asunto], [Cuerpo], [Template], [LogoEmpresa], [WebEmpresa], [NombreEmpresa], [Token]) VALUES ( N'APPROVE_USER', N'notificaciones@glerp.net.co', N'Notificaciones Sismedica SAS SAS', N'jairo142014@hotmail.com', N'NOTIFICACIÓN NUEVA SOLICITUD DE REGISTRO DE USUARIO', N'Solicitud de usuario aprobada', N'Cordial Saludo Sr(a). <<NOMBREUSUARIO>>. <br> Su cuenta ha sido aprovada por favor click en el siguiente enlace para confirmar: <a href="<<LINK>>">Confirmar Cuenta</a>  <br>  ¡Feliz día!', N'351ndgwv6dqlzqx8', N'https://www.glerp.net.co/wp-content/uploads/2017/02/logo-general-ledger-ac-edwards2.png', N'glerp.net.co', N'Sismedica SAS SAS', N'Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiIxIiwianRpIjoiNzZkM2M4MmE1MTIxYzdkNWRjNmEyM2Y2ZTkyODAwYTVhNWMxNWU1NTYyNGI3YmEyYTRjYTdmZjM5ZWYxZTdlN2QyZGFhNDk5YmMwY2ZiNjgiLCJpYXQiOjE2NDM3NzA4MjQuNDIxMTQ1LCJuYmYiOjE2NDM3NzA4MjQuNDIxMTUsImV4cCI6NDc5OTQ0NDQyNC40MTc0ODcsInN1YiI6IjIxMjEiLCJzY29wZXMiOlsiZW1haWxfZnVsbCIsImRvbWFpbnNfZnVsbCIsImFjdGl2aXR5X2Z1bGwiLCJhbmFseXRpY3NfZnVsbCIsInRva2Vuc19mdWxsIiwid2ViaG9va3NfZnVsbCIsInRlbXBsYXRlc19mdWxsIiwic3VwcHJlc3Npb25zX2Z1bGwiXX0.e6pHAy-tLQX-jfbWUTS9WIQatlKQkrh0U-UT-BH302ZvN4sroUPlqnfd6eKRUIlXJrv3DXqbTCoTjDikJhr7IjP4nKouBbLbXAViKGaNkX8FYkdr5f4vi9tyYdvqz0m7wA58zE4bA__X-zqjfvj3JNdD3Jm1-hDTbrD1r3i8ICxqWfyXhXxupKS9WRRfInxzegT2QDwOHXfUHQ1o3HSVZlNfMeiEm5W-QyJLTCIdzbbsP0homDWcK2gdGWkHvguTcGqF3CdFGO50D9EOHSly5Oalmq1DHgL3O4-a72nXV2kT0ohn43FL1BrRuhBvumOsN9BGoR1AjOmfXf13COtuY_tB62h5pRlJTOBcvvUqnuYE28_cGtDV7dqVoqWT7g_PHSjAL5Y4ZLpu2jQ6ObTg40Vs4jYajGsEMrJalwd0OaCuV7fhTQM9o1PxiFQ1XuAFjfIgByQKRk_NkZcVZfnZ2AUnkhJ0xbYLHN9oAO221pzO6BUa_OjzZbg-P8nssYsaGSiGhIvXvddDfhlSZRD4XHNNj8bAeCV0JUrahjjZru2hoKl2yYXK330McBHre0brDoJqp4YkKzVnenvK8l80Jh7uIdp2oDJrD5nZFdpoie1MkWgKMm1bMoeYVEiZeNardP2D00bfmyALKLofZYhKTTRV0itkTAKE2jXtQrJrrqE')

	INSERT [dbo].[WEBGLSS_EmailConfiguracion] ( [KeyValue], [Remitente], [NombreRemitente], [ReplyTo], [Titulo], [Asunto], [Cuerpo], [Template], [LogoEmpresa], [WebEmpresa], [NombreEmpresa], [Token]) VALUES ( N'PROPQRSF', N'notificaciones@glerp.net.co', N'Notificaciones Sismedica SAS SAS', N'jairo142014@hotmail.com', N'NOTIFICACIÓN DE NUEVA PQRSF ASIGNADA', N'Nueva PQRSF asignada', N'Sr(a). Agente se le ha asignado una nueva PQRSF número: <<NUMERO>>  ', N'351ndgwv6dqlzqx8', N'https://www.glerp.net.co/wp-content/uploads/2017/02/logo-general-ledger-ac-edwards2.png', N'glerp.net.co', N'Sismedica SAS SAS', N'Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiIxIiwianRpIjoiNzZkM2M4MmE1MTIxYzdkNWRjNmEyM2Y2ZTkyODAwYTVhNWMxNWU1NTYyNGI3YmEyYTRjYTdmZjM5ZWYxZTdlN2QyZGFhNDk5YmMwY2ZiNjgiLCJpYXQiOjE2NDM3NzA4MjQuNDIxMTQ1LCJuYmYiOjE2NDM3NzA4MjQuNDIxMTUsImV4cCI6NDc5OTQ0NDQyNC40MTc0ODcsInN1YiI6IjIxMjEiLCJzY29wZXMiOlsiZW1haWxfZnVsbCIsImRvbWFpbnNfZnVsbCIsImFjdGl2aXR5X2Z1bGwiLCJhbmFseXRpY3NfZnVsbCIsInRva2Vuc19mdWxsIiwid2ViaG9va3NfZnVsbCIsInRlbXBsYXRlc19mdWxsIiwic3VwcHJlc3Npb25zX2Z1bGwiXX0.e6pHAy-tLQX-jfbWUTS9WIQatlKQkrh0U-UT-BH302ZvN4sroUPlqnfd6eKRUIlXJrv3DXqbTCoTjDikJhr7IjP4nKouBbLbXAViKGaNkX8FYkdr5f4vi9tyYdvqz0m7wA58zE4bA__X-zqjfvj3JNdD3Jm1-hDTbrD1r3i8ICxqWfyXhXxupKS9WRRfInxzegT2QDwOHXfUHQ1o3HSVZlNfMeiEm5W-QyJLTCIdzbbsP0homDWcK2gdGWkHvguTcGqF3CdFGO50D9EOHSly5Oalmq1DHgL3O4-a72nXV2kT0ohn43FL1BrRuhBvumOsN9BGoR1AjOmfXf13COtuY_tB62h5pRlJTOBcvvUqnuYE28_cGtDV7dqVoqWT7g_PHSjAL5Y4ZLpu2jQ6ObTg40Vs4jYajGsEMrJalwd0OaCuV7fhTQM9o1PxiFQ1XuAFjfIgByQKRk_NkZcVZfnZ2AUnkhJ0xbYLHN9oAO221pzO6BUa_OjzZbg-P8nssYsaGSiGhIvXvddDfhlSZRD4XHNNj8bAeCV0JUrahjjZru2hoKl2yYXK330McBHre0brDoJqp4YkKzVnenvK8l80Jh7uIdp2oDJrD5nZFdpoie1MkWgKMm1bMoeYVEiZeNardP2D00bfmyALKLofZYhKTTRV0itkTAKE2jXtQrJrrqE')

	INSERT [dbo].[WEBGLSS_EmailConfiguracion] ( [KeyValue], [Remitente], [NombreRemitente], [ReplyTo], [Titulo], [Asunto], [Cuerpo], [Template], [LogoEmpresa], [WebEmpresa], [NombreEmpresa], [Token]) VALUES ( N'CERTI_EMPLEADO', N'notificaciones@glerp.net.co', N'Notificaciones Sismedica SAS SAS', N'jairo142014@hotmail.com', N'CERTIFICADO <<NOMCERTIFICADO>>', N'CERTIFICADO <<NOMCERTIFICADO>>', N'Sr(a). <<Empleado>> se adjunta certificado <<NOMCERTIFICADO>>', N'351ndgwv6dqlzqx8', N'https://www.glerp.net.co/wp-content/uploads/2017/02/logo-general-ledger-ac-edwards2.png', N'glerp.net.co', N'Sismedica SAS SAS', N'Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiIxIiwianRpIjoiNzZkM2M4MmE1MTIxYzdkNWRjNmEyM2Y2ZTkyODAwYTVhNWMxNWU1NTYyNGI3YmEyYTRjYTdmZjM5ZWYxZTdlN2QyZGFhNDk5YmMwY2ZiNjgiLCJpYXQiOjE2NDM3NzA4MjQuNDIxMTQ1LCJuYmYiOjE2NDM3NzA4MjQuNDIxMTUsImV4cCI6NDc5OTQ0NDQyNC40MTc0ODcsInN1YiI6IjIxMjEiLCJzY29wZXMiOlsiZW1haWxfZnVsbCIsImRvbWFpbnNfZnVsbCIsImFjdGl2aXR5X2Z1bGwiLCJhbmFseXRpY3NfZnVsbCIsInRva2Vuc19mdWxsIiwid2ViaG9va3NfZnVsbCIsInRlbXBsYXRlc19mdWxsIiwic3VwcHJlc3Npb25zX2Z1bGwiXX0.e6pHAy-tLQX-jfbWUTS9WIQatlKQkrh0U-UT-BH302ZvN4sroUPlqnfd6eKRUIlXJrv3DXqbTCoTjDikJhr7IjP4nKouBbLbXAViKGaNkX8FYkdr5f4vi9tyYdvqz0m7wA58zE4bA__X-zqjfvj3JNdD3Jm1-hDTbrD1r3i8ICxqWfyXhXxupKS9WRRfInxzegT2QDwOHXfUHQ1o3HSVZlNfMeiEm5W-QyJLTCIdzbbsP0homDWcK2gdGWkHvguTcGqF3CdFGO50D9EOHSly5Oalmq1DHgL3O4-a72nXV2kT0ohn43FL1BrRuhBvumOsN9BGoR1AjOmfXf13COtuY_tB62h5pRlJTOBcvvUqnuYE28_cGtDV7dqVoqWT7g_PHSjAL5Y4ZLpu2jQ6ObTg40Vs4jYajGsEMrJalwd0OaCuV7fhTQM9o1PxiFQ1XuAFjfIgByQKRk_NkZcVZfnZ2AUnkhJ0xbYLHN9oAO221pzO6BUa_OjzZbg-P8nssYsaGSiGhIvXvddDfhlSZRD4XHNNj8bAeCV0JUrahjjZru2hoKl2yYXK330McBHre0brDoJqp4YkKzVnenvK8l80Jh7uIdp2oDJrD5nZFdpoie1MkWgKMm1bMoeYVEiZeNardP2D00bfmyALKLofZYhKTTRV0itkTAKE2jXtQrJrrqE')

	SET IDENTITY_INSERT [dbo].[WEBGLSS_EmailConfiguracion] OFF

END
GO


IF NOT EXISTS (SELECT * FROM WEBGLSS_Estados)
BEGIN
	SET IDENTITY_INSERT [dbo].[WEBGLSS_Estados] ON 
	INSERT [dbo].[WEBGLSS_Estados] ([Id], [Nombre], [delmrk]) VALUES (1, N'Nueva', N'1')
	INSERT [dbo].[WEBGLSS_Estados] ([Id], [Nombre], [delmrk]) VALUES (2, N'Abierta', N'1')
	INSERT [dbo].[WEBGLSS_Estados] ([Id], [Nombre], [delmrk]) VALUES (3, N'Pendiente', N'1')
	INSERT [dbo].[WEBGLSS_Estados] ([Id], [Nombre], [delmrk]) VALUES (4, N'En Gesti�n', N'1')
	INSERT [dbo].[WEBGLSS_Estados] ([Id], [Nombre], [delmrk]) VALUES (5, N'Cerrada', N'1')
SET IDENTITY_INSERT [dbo].[WEBGLSS_Estados] OFF
END
GO

IF NOT EXISTS (SELECT * FROM WEBGLSS_Prioridades)
BEGIN
	SET IDENTITY_INSERT [dbo].[WEBGLSS_Prioridades] ON 
	INSERT [dbo].[WEBGLSS_Prioridades] ([Id], [Nombre], [delmrk]) VALUES (1, N'Baja', N'1')
	INSERT [dbo].[WEBGLSS_Prioridades] ([Id], [Nombre], [delmrk]) VALUES (2, N'Media', N'1')
	INSERT [dbo].[WEBGLSS_Prioridades] ([Id], [Nombre], [delmrk]) VALUES (3, N'Alta', N'1')
	INSERT [dbo].[WEBGLSS_Prioridades] ([Id], [Nombre], [delmrk]) VALUES (4, N'Urgente', N'1')
	INSERT [dbo].[WEBGLSS_Prioridades] ([Id], [Nombre], [delmrk]) VALUES (5, N'Sin Asignar', N'1')
	SET IDENTITY_INSERT [dbo].[WEBGLSS_Prioridades] OFF
END
GO

IF NOT EXISTS (SELECT * FROM WEBGLSS_SituacionesNoConformes)
BEGIN
	SET IDENTITY_INSERT [dbo].[WEBGLSS_SituacionesNoConformes] ON
	INSERT [dbo].[WEBGLSS_SituacionesNoConformes] ([Id], [Codigo], [TipoSituacion], [delmrk]) VALUES (1, N'0001', N'PETICI�N', N'1')
	INSERT [dbo].[WEBGLSS_SituacionesNoConformes] ([Id], [Codigo], [TipoSituacion], [delmrk]) VALUES (2, N'0002', N'QUEJA', N'1')
	INSERT [dbo].[WEBGLSS_SituacionesNoConformes] ([Id], [Codigo], [TipoSituacion], [delmrk]) VALUES (3, N'0003', N'RECLAMO', N'1')
	INSERT [dbo].[WEBGLSS_SituacionesNoConformes] ([Id], [Codigo], [TipoSituacion], [delmrk]) VALUES (4, N'0004', N'SUGERENCIA', N'1')
	INSERT [dbo].[WEBGLSS_SituacionesNoConformes] ([Id], [Codigo], [TipoSituacion], [delmrk]) VALUES (5, N'0005', N'FELICITACI�N', N'1')
	SET IDENTITY_INSERT [dbo].[WEBGLSS_SituacionesNoConformes] OFF
END
GO

-- MENUS START
	
	--MENUS

	UPDATE WEBGLSS_Menus SET TpoMnu = 'Menu',Controller = 'NO',Action ='NO' WHERE CodMnu = '0009'
	UPDATE WEBGLSS_Menus SET DepMnu = '0009' WHERE CodMnu = '0028'

	--IF NOT EXISTS (SELECT * FROM WEBGLSS_Menus WHERE CodMnu = '0009')
	--BEGIN
	--	INSERT [dbo].[WEBGLSS_Menus] ( [CodMnu], [NomMnu], [Orden], [NvlMnu], [TpoMnu], [DepMnu], [Controller], [Action], [IcoMnu], [delmrk]) VALUES ( N'0009', N'Dashboard', N'1', N'1', N'Menu', N'NO', N'Home', N'Index', N'fas fa-tachometer-alt', N'1')
	--END

	--IF NOT EXISTS (SELECT * FROM WEBGLSS_Menus WHERE CodMnu = '0001')
	--BEGIN
	--	INSERT [dbo].[WEBGLSS_Menus] ( [CodMnu], [NomMnu], [Orden], [NvlMnu], [TpoMnu], [DepMnu], [Controller], [Action], [IcoMnu], [delmrk]) VALUES ( N'0001', N'PQRSF', N'2', N'2', N'Menu', N'NO', N'NO', N'NO', N'fas fa-headset', N'1')
	--END

	--IF NOT EXISTS (SELECT * FROM WEBGLSS_Menus WHERE CodMnu = '0014')
	--BEGIN
	--	INSERT [dbo].[WEBGLSS_Menus] ( [CodMnu], [NomMnu], [Orden], [NvlMnu], [TpoMnu], [DepMnu], [Controller], [Action], [IcoMnu], [delmrk]) VALUES ( N'0014', N'Pedidos', N'3', N'2', N'Menu', N'NO', N'NO', N'NO', N'fas fa-shopping-cart', N'1')
	--END

	--IF NOT EXISTS (SELECT * FROM WEBGLSS_Menus WHERE CodMnu = '0024')
	--BEGIN
	--	INSERT [dbo].[WEBGLSS_Menus] ( [CodMnu], [NomMnu], [Orden], [NvlMnu], [TpoMnu], [DepMnu], [Controller], [Action], [IcoMnu], [delmrk]) VALUES ( N'0024', N'Proveedores', N'4', N'2', N'Menu', N'NO', N'NO', N'NO', N'fa fa-truck', N'1')
	--END

	IF NOT EXISTS (SELECT * FROM WEBGLSS_Menus WHERE CodMnu = '0020')
	BEGIN
		INSERT [dbo].[WEBGLSS_Menus] ( [CodMnu], [NomMnu], [Orden], [NvlMnu], [TpoMnu], [DepMnu], [Controller], [Action], [IcoMnu], [delmrk]) VALUES ( N'0020', N'Gesti�n Humana', N'5', N'2', N'Menu', N'NO', N'NO', N'NO', N'fas fa-suitcase', N'1')
	END

	--IF NOT EXISTS (SELECT * FROM WEBGLSS_Menus WHERE CodMnu = '0018')
	--BEGIN
	--	INSERT [dbo].[WEBGLSS_Menus] ( [CodMnu], [NomMnu], [Orden], [NvlMnu], [TpoMnu], [DepMnu], [Controller], [Action], [IcoMnu], [delmrk]) VALUES ( N'0018', N'Gestión de Cartera', N'6', N'2', N'Menu', N'NO', N'NO', N'NO', N'fas fa-briefcase', N'1')
	--END

	--IF NOT EXISTS (SELECT * FROM WEBGLSS_Menus WHERE CodMnu = '0011')
	--BEGIN
	--	INSERT [dbo].[WEBGLSS_Menus] ( [CodMnu], [NomMnu], [Orden], [NvlMnu], [TpoMnu], [DepMnu], [Controller], [Action], [IcoMnu], [delmrk]) VALUES ( N'0011', N'Configuraciones', N'7', N'2', N'Menu', N'NO', N'NO', N'NO', N'fa fa-cog', N'1')
	--END


	--SUBMENUS
	--IF NOT EXISTS (SELECT * FROM WEBGLSS_Menus WHERE CodMnu = '0002')
	--BEGIN
	--	INSERT [dbo].[WEBGLSS_Menus] ( [CodMnu], [NomMnu], [Orden], [NvlMnu], [TpoMnu], [DepMnu], [Controller], [Action], [IcoMnu], [delmrk]) VALUES ( N'0002', N'Mis PQRSF', N'1', N'3', N'Submenu', N'0001', N'PQRSF', N'Index', N'fas fa-clipboard-list', N'1')
	--END

	--IF NOT EXISTS (SELECT * FROM WEBGLSS_Menus WHERE CodMnu = '0003')
	--BEGIN
	--	INSERT [dbo].[WEBGLSS_Menus] ( [CodMnu], [NomMnu], [Orden], [NvlMnu], [TpoMnu], [DepMnu], [Controller], [Action], [IcoMnu], [delmrk]) VALUES ( N'0003', N'Radicación de PQRSF', N'2', N'3', N'Submenu', N'0001', N'PQRSF', N'Create', N'fas fa-plus-circle', N'1')
	--END

	--IF NOT EXISTS (SELECT * FROM WEBGLSS_Menus WHERE CodMnu = '0004')
	--BEGIN
	--	INSERT [dbo].[WEBGLSS_Menus] ( [CodMnu], [NomMnu], [Orden], [NvlMnu], [TpoMnu], [DepMnu], [Controller], [Action], [IcoMnu], [delmrk]) VALUES ( N'0004', N'Listado de PQRSF', N'3', N'3', N'Submenu', N'0001', N'PQRSF', N'List', N'fas fa-list', N'1')
	--END

	--IF NOT EXISTS (SELECT * FROM WEBGLSS_Menus WHERE CodMnu = '0010')
	--BEGIN
	--	INSERT [dbo].[WEBGLSS_Menus] ( [CodMnu], [NomMnu], [Orden], [NvlMnu], [TpoMnu], [DepMnu], [Controller], [Action], [IcoMnu], [delmrk]) VALUES ( N'0010', N'Estadisticas', N'4', N'3', N'Submenu', N'0001', N'PQRSF', N'Statistic', N'fas fa-chart-area', N'1')
	--END

	--IF NOT EXISTS (SELECT * FROM WEBGLSS_Menus WHERE CodMnu = '0012')
	--BEGIN
	--	INSERT [dbo].[WEBGLSS_Menus] ( [CodMnu], [NomMnu], [Orden], [NvlMnu], [TpoMnu], [DepMnu], [Controller], [Action], [IcoMnu], [delmrk]) VALUES ( N'0012', N'Usuarios', N'2', N'3', N'Submenu', N'0011', N'Configuration', N'Index', N'fas fa-users', N'1')
	--END

	--IF NOT EXISTS (SELECT * FROM WEBGLSS_Menus WHERE CodMnu = '0013')
	--BEGIN
	--	INSERT [dbo].[WEBGLSS_Menus] ( [CodMnu], [NomMnu], [Orden], [NvlMnu], [TpoMnu], [DepMnu], [Controller], [Action], [IcoMnu], [delmrk]) VALUES ( N'0013', N'Roles de Usuario', N'1', N'3', N'Submenu', N'0011', N'Configuration', N'Perfiles', N'fas fa-id-badge', N'1')	
	--END

	--IF NOT EXISTS (SELECT * FROM WEBGLSS_Menus WHERE CodMnu = '0015')
	--BEGIN
	--	INSERT [dbo].[WEBGLSS_Menus] ( [CodMnu], [NomMnu], [Orden], [NvlMnu], [TpoMnu], [DepMnu], [Controller], [Action], [IcoMnu], [delmrk]) VALUES ( N'0015', N'Nuevo Pedido', N'2', N'3', N'SubMenu', N'0014', N'Pedido', N'Create', N'fas fa-cart-plus', N'1')
	--END

	--IF NOT EXISTS (SELECT * FROM WEBGLSS_Menus WHERE CodMnu = '0016')
	--BEGIN
	--	INSERT [dbo].[WEBGLSS_Menus] ( [CodMnu], [NomMnu], [Orden], [NvlMnu], [TpoMnu], [DepMnu], [Controller], [Action], [IcoMnu], [delmrk]) VALUES ( N'0016', N'Mis Pedidos', N'1', N'3', N'SubMenu', N'0014', N'Pedido', N'Index', N'fas fa-cubes', N'1')
	--END

	--IF NOT EXISTS (SELECT * FROM WEBGLSS_Menus WHERE CodMnu = '0017')
	--BEGIN
	--	INSERT [dbo].[WEBGLSS_Menus] ( [CodMnu], [NomMnu], [Orden], [NvlMnu], [TpoMnu], [DepMnu], [Controller], [Action], [IcoMnu], [delmrk]) VALUES ( N'0017', N'Aprobar Clientes', N'3', N'3', N'SubMenu', N'0011', N'Configuration', N'UserRequest', N'fas fa-user-plus', N'1')	
	--END

	--IF NOT EXISTS (SELECT * FROM WEBGLSS_Menus WHERE CodMnu = '0019')
	--BEGIN
	--	INSERT [dbo].[WEBGLSS_Menus] ( [CodMnu], [NomMnu], [Orden], [NvlMnu], [TpoMnu], [DepMnu], [Controller], [Action], [IcoMnu], [delmrk]) VALUES ( N'0019', N'Mi Estado de Cuenta', N'1', N'3', N'SubMenu', N'0018', N'Cartera', N'Index', N'fas fa-money-bill-alt', N'1')
	--END

	IF NOT EXISTS (SELECT * FROM WEBGLSS_Menus WHERE CodMnu = '0021')
	BEGIN
		INSERT [dbo].[WEBGLSS_Menus] ( [CodMnu], [NomMnu], [Orden], [NvlMnu], [TpoMnu], [DepMnu], [Controller], [Action], [IcoMnu], [delmrk]) VALUES ( N'0021', N'Certificados', N'1', N'3', N'SubMenu', N'0020', N'GestionHumana', N'Index', N'fas fa-file-alt', N'1')
	END

	--IF NOT EXISTS (SELECT * FROM WEBGLSS_Menus WHERE CodMnu = '0022')
	--BEGIN
	--	INSERT [dbo].[WEBGLSS_Menus] ( [CodMnu], [NomMnu], [Orden], [NvlMnu], [TpoMnu], [DepMnu], [Controller], [Action], [IcoMnu], [delmrk]) VALUES ( N'0022', N'Perfiles', N'4', N'3', N'SubMenu', N'0001', N'Profiler', N'Index', N'fa fa-cog', N'1')
	--END

	--IF NOT EXISTS (SELECT * FROM WEBGLSS_Menus WHERE CodMnu = '0023')
	--BEGIN
	--	INSERT [dbo].[WEBGLSS_Menus] ( [CodMnu], [NomMnu], [Orden], [NvlMnu], [TpoMnu], [DepMnu], [Controller], [Action], [IcoMnu], [delmrk]) VALUES ( N'0023', N'Permisos', N'4', N'3', N'SubMenu', N'0011', N'Configuration', N'Permisos', N'fa fa-cog', N'1')
	--END

	--IF NOT EXISTS (SELECT * FROM WEBGLSS_Menus WHERE CodMnu = '0025')
	--BEGIN
	--	INSERT [dbo].[WEBGLSS_Menus] ( [CodMnu], [NomMnu], [Orden], [NvlMnu], [TpoMnu], [DepMnu], [Controller], [Action], [IcoMnu], [delmrk]) VALUES ( N'0025', N'Listado de Proveedores', N'1', N'3', N'SubMenu', N'0024', N'Proveedor', N'Index', N'fa fa-user-plus', N'1')
	--END

	IF NOT EXISTS (SELECT * FROM WEBGLSS_Menus WHERE CodMnu = '0026')
	BEGIN
		INSERT [dbo].[WEBGLSS_Menus] ( [CodMnu], [NomMnu], [Orden], [NvlMnu], [TpoMnu], [DepMnu], [Controller], [Action], [IcoMnu], [delmrk]) VALUES ( N'0026', N'Solicitudes', N'2', N'3', N'SubMenu', N'0020', N'GestionHumana', N'Solicitudes', N'fa fa-user-plus', N'1')
	END

	IF NOT EXISTS (SELECT * FROM WEBGLSS_Menus WHERE CodMnu = '0027')
	BEGIN
		INSERT [dbo].[WEBGLSS_Menus] ( [CodMnu], [NomMnu], [Orden], [NvlMnu], [TpoMnu], [DepMnu], [Controller], [Action], [IcoMnu], [delmrk]) VALUES ( N'0027', N'Solicitudes de Empleados', N'3', N'3', N'SubMenu', N'0020', N'GestionHumana', N'SolicitudesEmpleado', N'fa fa-user-plus', N'1')
	END

	--IF NOT EXISTS (SELECT * FROM WEBGLSS_Menus WHERE CodMnu = '0028')
	--BEGIN
	--	INSERT [dbo].[WEBGLSS_Menus] ( [CodMnu], [NomMnu], [Orden], [NvlMnu], [TpoMnu], [DepMnu], [Controller], [Action], [IcoMnu], [delmrk]) VALUES ( N'0028', N'Dashboard Cuentas Por Cobrar', N'2', N'3', N'SubMenu', N'0009', N'Cartera', N'Dashboard', N'fa fa-chart-pie', N'1')
	--END

	--IF NOT EXISTS (SELECT * FROM WEBGLSS_Menus WHERE CodMnu = '0029')
	--BEGIN
	--	INSERT [dbo].[WEBGLSS_Menus] ( [CodMnu], [NomMnu], [Orden], [NvlMnu], [TpoMnu], [DepMnu], [Controller], [Action], [IcoMnu], [delmrk]) VALUES ( N'0029', N'Dashboard PQRSF', N'1', N'3', N'SubMenu', N'0009', N'Home', N'Index', N'fa fa-chart-pie', N'1')
	--END

	--IF NOT EXISTS (SELECT * FROM WEBGLSS_Menus WHERE CodMnu = '0030')
	--BEGIN
	--	INSERT [dbo].[WEBGLSS_Menus] ( [CodMnu], [NomMnu], [Orden], [NvlMnu], [TpoMnu], [DepMnu], [Controller], [Action], [IcoMnu], [delmrk]) VALUES ( N'0030', N'Dashboard Empleados', N'3', N'3', N'SubMenu', N'0009', N'', N'', N'fa fa-chart-pie', N'1')
	--END

	--IF NOT EXISTS (SELECT * FROM WEBGLSS_Menus WHERE CodMnu = '0031')
	--BEGIN
	--	INSERT [dbo].[WEBGLSS_Menus] ( [CodMnu], [NomMnu], [Orden], [NvlMnu], [TpoMnu], [DepMnu], [Controller], [Action], [IcoMnu], [delmrk]) VALUES ( N'0031', N'General', N'1', N'3', N'Menu', N'0011', N'Configuration', N'ConfiguracionGeneral', N'fa fa-chart-pie', N'1')
	--END
	

-- MENUS END


IF NOT EXISTS (SELECT * FROM WEBGLSS_Permisos)
BEGIN
	
	SET IDENTITY_INSERT [dbo].[WEBGLSS_Permisos] ON 
	INSERT [dbo].[WEBGLSS_Permisos] ([Id], [codigo], [Permiso], [Descripcion], [Tipo]) VALUES (2, N'000001', N'Radicar PQRSF', N'Permite que un usuario pueda radicar PQRSF Editado', N'PQRSF')
	INSERT [dbo].[WEBGLSS_Permisos] ([Id], [codigo], [Permiso], [Descripcion], [Tipo]) VALUES (3, N'000002', N'Perfilar PQRSF', N'Permite a un usuario hacer la perfilaci�n de PQRSF', N'PQRSF')
	INSERT [dbo].[WEBGLSS_Permisos] ([Id], [codigo], [Permiso], [Descripcion], [Tipo]) VALUES (4, N'000003', N'Adicionar Permisos', N'Permite agregar permisos nuevos al sistema', N'PQRSF')
	INSERT [dbo].[WEBGLSS_Permisos] ([Id], [codigo], [Permiso], [Descripcion], [Tipo]) VALUES (5, N'000004', N'Adicionar Usuarios', N'Permite adicionar usuarios nuevos al sistema', N'CONFIGURACION')
	INSERT [dbo].[WEBGLSS_Permisos] ([Id], [codigo], [Permiso], [Descripcion], [Tipo]) VALUES (6, N'000005', N'Adicionar Agentes', N'Permite adicionar un nuevo agente', N'CONFIGURACION')
	INSERT [dbo].[WEBGLSS_Permisos] ([Id], [codigo], [Permiso], [Descripcion], [Tipo]) VALUES (7, N'000006', N'Ver todas las PQRSF', N'Permite que un usuario pueda ver todas las PQRSF', N'PQRSF')
	SET IDENTITY_INSERT [dbo].[WEBGLSS_Permisos] OFF

END
GO


SELECT * INTO #TMPPERMISOS FROM WEBGLSS_Permisos
--SELECT * INTO #TMPUSUARIOS FROM AspNetUsers


WHILE EXISTS(SELECT * FROM #TMPPERMISOS)
BEGIN
	
	DECLARE @USUARIO VARCHAR(50) = '', @PERMISO VARCHAR(4) = ''
	SELECT TOP(1) @PERMISO = id FROM #TMPPERMISOS

	SELECT * INTO #TMPUSUARIOS FROM AspNetUsers

	WHILE EXISTS(SELECT * FROM #TMPUSUARIOS)
	BEGIN
		
		SELECT TOP(1) @USUARIO = id FROM #TMPUSUARIOS

		IF NOT EXISTS (SELECT * FROM WEBGLSS_PermisosUsuarios WHERE idpermiso = @PERMISO AND IdUsuario = @USUARIO)
		BEGIN
			INSERT INTO WEBGLSS_PermisosUsuarios(IdPermiso,IdUsuario,Activo)
			VALUES(@PERMISO,@USUARIO,0)
		END

		DELETE TOP(1) #TMPUSUARIOS

	END
	DROP TABLE #TMPUSUARIOS
	DELETE TOP(1) #TMPPERMISOS

END
GO

--DROP TABLE #TMPUSUARIOS
DROP TABLE #TMPPERMISOS


--END INSERTS VALUES
ALTER TABLE [dbo].[WEBGLSS_Agentes] ADD  DEFAULT (CONVERT([bit],(1),(0))) FOR [RecibeEmail]
GO
ALTER TABLE [dbo].[WEBGLSS_Agentes] ADD  DEFAULT ('1') FOR [delmrk]
GO
ALTER TABLE [dbo].[WEBGLSS_Clientes] ADD  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[WEBGLSS_Clientes] ADD  DEFAULT ((1)) FOR [delmrk]
GO
ALTER TABLE [dbo].[WEBGLSS_ContactoClientes] ADD  DEFAULT ('1') FOR [delmrk]
GO
ALTER TABLE [dbo].[WEBGLSS_Elementos] ADD  DEFAULT ('1') FOR [delmrk]
GO
ALTER TABLE [dbo].[WEBGLSS_Empleados] ADD  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[WEBGLSS_Empleados] ADD  DEFAULT ('1') FOR [delmrk]
GO
ALTER TABLE [dbo].[WEBGLSS_Estados] ADD  DEFAULT ('1') FOR [delmrk]
GO
ALTER TABLE [dbo].[WEBGLSS_Etiquetas] ADD  DEFAULT ((1)) FOR [delmrk]
GO
ALTER TABLE [dbo].[WEBGLSS_MatrizPQRSF] ADD  DEFAULT (getdate()) FOR [Fecha]
GO
ALTER TABLE [dbo].[WEBGLSS_MatrizPQRSF] ADD  DEFAULT (getdate()) FOR [FechaCierre]
GO
ALTER TABLE [dbo].[WEBGLSS_MatrizPQRSF] ADD  DEFAULT (getdate()) FOR [FechaCierreReal]
GO
ALTER TABLE [dbo].[WEBGLSS_MatrizPQRSF] ADD  DEFAULT ('PQRSF Externa') FOR [Tipo]
GO
ALTER TABLE [dbo].[WEBGLSS_MatrizPQRSF] ADD  DEFAULT ((2)) FOR [IdEstado]
GO
ALTER TABLE [dbo].[WEBGLSS_MatrizPQRSF] ADD  DEFAULT ((5)) FOR [IdPrioridad]
GO
ALTER TABLE [dbo].[WEBGLSS_MatrizPQRSF] ADD  DEFAULT ((1)) FOR [IdProceso]
GO
ALTER TABLE [dbo].[WEBGLSS_MatrizPQRSF] ADD  DEFAULT ('0000000000') FOR [NroIdResponsable]
GO
ALTER TABLE [dbo].[WEBGLSS_MatrizPQRSF] ADD  DEFAULT ('0000000000') FOR [NroIdPerfilo]
GO
ALTER TABLE [dbo].[WEBGLSS_MatrizPQRSF] ADD  DEFAULT ('0000000000') FOR [NroIdCerro]
GO
ALTER TABLE [dbo].[WEBGLSS_MatrizPQRSF] ADD  DEFAULT (CONVERT([bit],(0),(0))) FOR [Perfilacion]
GO
ALTER TABLE [dbo].[WEBGLSS_MenuRoles] ADD  DEFAULT ('1') FOR [delmrk]
GO
ALTER TABLE [dbo].[WEBGLSS_Menus] ADD  DEFAULT ((1)) FOR [delmrk]
GO
ALTER TABLE [dbo].[WEBGLSS_MenuUsuarios] ADD  DEFAULT ('1') FOR [delmrk]
GO
ALTER TABLE [dbo].[WEBGLSS_NotasPQRSF] ADD  DEFAULT (getdate()) FOR [Fecha]
GO
ALTER TABLE [dbo].[WEBGLSS_NotasPQRSF] ADD  DEFAULT ('Nota') FOR [Tipo]
GO
ALTER TABLE [dbo].[WEBGLSS_Perfiles] ADD  DEFAULT ('1') FOR [delmrk]
GO
ALTER TABLE [dbo].[WEBGLSS_Preguntas] ADD  DEFAULT ((1)) FOR [delmrk]
GO
ALTER TABLE [dbo].[WEBGLSS_Prioridades] ADD  DEFAULT ('1') FOR [delmrk]
GO
ALTER TABLE [dbo].[WEBGLSS_Procesos] ADD  DEFAULT ((1)) FOR [delmrk]
GO
ALTER TABLE [dbo].[WEBGLSS_Respuestas] ADD  DEFAULT ((1)) FOR [delmrk]
GO
ALTER TABLE [dbo].[WEBGLSS_Seguimientos] ADD  DEFAULT (getdate()) FOR [Fecha]
GO
ALTER TABLE [dbo].[WEBGLSS_SituacionesNoConformes] ADD  DEFAULT ((1)) FOR [delmrk]
GO
ALTER TABLE [dbo].[WEBGLSS_SolicitudClientes] ADD  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[WEBGLSS_SolicitudClientes] ADD  DEFAULT ('1') FOR [Estado]
GO
ALTER TABLE [dbo].[WEBGLSS_SolicitudClientes] ADD  DEFAULT ('1') FOR [delmrk]
GO
ALTER TABLE [dbo].[WEBGLSS_Terceros] ADD  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[WEBGLSS_Terceros] ADD  DEFAULT ('1') FOR [delmrk]
GO
ALTER TABLE [dbo].[WEBGLSS_TratamientosPQRSF] ADD  DEFAULT (CONVERT([bit],(0),(0))) FOR [Checked]
GO
ALTER TABLE [dbo].[WEBGLSS_TratamientosPQRSF] ADD  DEFAULT (getdate()) FOR [FechaCheck]
GO
ALTER TABLE [dbo].[WEBGLSS_TratamientosPQRSF] ADD  DEFAULT (CONVERT([bit],(1),(0))) FOR [EnvioCorreo]
GO
ALTER TABLE [dbo].[WEBGLSSS_Archivos] ADD  DEFAULT ((1)) FOR [delmrk]
GO


update WEBGLSS_MatrizPQRSF set IdEstado = 2 where IdEstado = 1
-- START CREATE PROCEDURES

IF OBJECT_ID(N'dbo.WEBGLSS_SP_VENTAS') IS NULL
BEGIN
    PRINT 'Create procedure : dbo.WEBGLSS_SP_VENTAS'
    EXECUTE('CREATE PROCEDURE dbo.WEBGLSS_SP_VENTAS AS RETURN 0') 
END
GO

PRINT 'Alter procedure : dbo.WEBGLSS_SP_VENTAS'
GO

ALTER PROCEDURE [dbo].[WEBGLSS_SP_VENTAS] 
    @Operacion	VARCHAR(20) = '',
	@Email		VARCHAR(200)='',
	@Nombre		VARCHAR(200)='',
	@Telefono	VARCHAR(20) = '',
	@Cargo		VARCHAR(100) = '',
	@Cedula		VARCHAR(20)='',
	@Filter     VARCHAR(200)='',
	@NroIdCliente VARCHAR(20)='',
	@Nit			VARCHAR(20) = '',
	@Ciudad			VARCHAR(100) = '',
	@Direccion		VARCHAR(200)='',
	@NroIdVendedor  VARCHAR(100)='',
	@Vendedor  VARCHAR(100)='',
	@CedVendedor  VARCHAR(100)=''
AS
BEGIN
	
	IF @Operacion = 'GETSOLIC'
	BEGIN
		SELECT 
			SOL.NombreContacto		AS Nombre,
			SOL.Cargo				AS Cargo,
			SOL.Telefono			AS Telefono,
			SOL.Email				AS Email,
			SOL.Cedula				AS Cedula
		FROM CliOtrosContactos SOL
		WHERE SOL.DelMrk = 1 AND SOL.CodigoCliente = @NroIdCliente AND (SOL.NombreContacto LIKE '%'+@Filter+'%'  OR SOL.Cedula LIKE '%'+@Filter+'%')
		RETURN;
	END	

	IF @Operacion = 'GETCLIENTES'
	BEGIN
		SELECT 
			CLI.clinom		AS Nombre,
			CLI.clinit		AS Nit,
			CLI.cliciud		AS Ciudad,
			CLI.clidir		AS Direccion,
			VEN.vencod		AS NroIdVendedor,
			VEN.vennom		AS Vendedor,
			VEN.venced		AS CedVendedor
		FROM clientes CLI
		LEFT JOIN vendedores VEN ON CLI.Vendedor = VEN.vencod
		WHERE CLI.delmrk = 1 AND (CLI.clinit LIKE '%'+@Filter+'%'  OR CLI.clinom LIKE '%'+@Filter+'%')
		RETURN;
	END	
END
GO

IF OBJECT_ID(N'dbo.WEBGLSS_SP_PEDIDOS') IS NULL
BEGIN
    PRINT 'Create procedure : dbo.WEBGLSS_SP_PEDIDOS'
    EXECUTE('CREATE PROCEDURE dbo.WEBGLSS_SP_PEDIDOS AS RETURN 0') 
END
GO

PRINT 'Alter procedure : dbo.WEBGLSS_SP_PEDIDOS'
GO

ALTER PROCEDURE [dbo].[WEBGLSS_SP_PEDIDOS] 
    @Operacion		VARCHAR(20) = '',
	@NroIdCliente	VARCHAR(20) = '',
	@FechaI			DATE = '19000101',
	@FechaF			DATE = '19000101',
	@Escala			VARCHAR(10) = '',
	@NroFac			VARCHAR(15)='',

	@Fecha			DATETIME = '19000101',
	@FechaRequerido DATETIME = '19000101',
	@CodigoCliente	VARCHAR(20) = '',
	@CodigoSolicitante	VARCHAR(20) = '',
	@NitCliente	VARCHAR(20) = '',
	@CodigoEscala	VARCHAR(6) = '',
	@CodigoVendedor VARCHAR(20) = '',
	@TipoCliente	VARCHAR(20) = '',
	@Direccion		VARCHAR(100) = '',
	@CodigoPostal	VARCHAR(20) = '',
	@CodigoCiudad	VARCHAR(10) = '',
	@CodigoPais		VARCHAR(10) = '',
	@CodigoSucursal VARCHAR(20) = '',
	@Detalle		VARCHAR(500) = '',
	@SubTotal		NUMERIC(18,2) = 0,
	@ValorIva		NUMERIC(18,2) = 0,
	@Total			NUMERIC(18,2) = 0,
	@IvaIncluido	INT = 0,
	@TServicios WEBGLSS_TypeDetalles READONLY
AS
BEGIN
	
	 IF @Operacion = 'GETPED'
    BEGIN
        SELECT 
            PED.nrofac AS NumeroPedido,
            PED.fecfac AS Fecha,
            CLI.clinom AS Cliente,
            PED.fechaReq AS FechaRequerido,
            PED.vlrfac AS Total,
            PED.subtotal AS SubTotal,
            PED.iva AS ValorIva,
            PED.detalle AS Descripcion,
            CASE 
                WHEN PED.estado = '0' THEN 'GENERADO' 
                WHEN PED.estado = '1' THEN 'AUTORIZADO' 
                WHEN PED.estado = '2' THEN 'NO AUTORIZADO'
                WHEN PED.estado = '3' THEN 'FACTURADO' 
                ELSE 'REMISIONADO' 
            END AS Estado,
            PRO.ciunom AS Ciudad,
            SUC.direccion AS Direccion,
            PED.Calificacion AS Calificacion
        FROM accpedidos PED
        LEFT JOIN clientes CLI ON PED.codcli = CLI.clicod
        LEFT JOIN prociudades PRO ON PRO.ciucod = CLI.cliCodCiud
        LEFT JOIN proPaises PAI ON CLI.cliPais = PAI.codPais
        LEFT JOIN vendedores VEN ON PED.vendedor = VEN.vencod 
        LEFT JOIN Sucursales SUC ON PED.cxc_Id_Sucursal = SUC.id_Sucursal
        LEFT JOIN ProZona ZON ON SUC.Barrio = ZON.CodZona 
        WHERE PED.fecfac BETWEEN @FechaI AND @FechaF 
        AND CLI.clinit = CASE WHEN @NroIdCliente = '' THEN CLI.clinit ELSE @NroIdCliente END
    END
	IF @Operacion = 'GETDET'
    BEGIN
        SELECT 
            DET.codart AS CodigoArticulo,
            DET.detalle AS Detalle,
            DET.cantid AS Cantidad,
            DET.vlruni AS ValorUnitario,
            DET.vlrIva AS Iva,
            DET.dsubtotal AS ValorSubtotal
        FROM accmovpedidos DET
        WHERE DET.numfac = @NroFac
    END

	IF @Operacion = 'GETINFOCLIENTE'
	BEGIN

		--INFO GENERAL

		SELECT 
			 dbo.getConsecutivo_con_Fuente((SELECT docfte FROM tipodocumento WHERE doccod = '44')) AS Consecutivo
			,clinom												AS NombreCliente
			,clinit												AS NitCliente
			,clicod												AS CodigoCliente
			,CASE WHEN cliesc = '' THEN '0001' ELSE cliesc END	AS CodigoEscala
			,Vendedor											AS CodigoVendedor
			,CliTipoCli											AS TipoCliente
			,CliTel												AS Telefono
			,CliDir												AS Direccion
			,cliCodPostal										AS CodigoPostal
			,CLICODCIUD											AS CodigoCiudad
			,CLIPAIS											AS CodigoPais
			,CAST((SELECT TOP(1) ivainc FROM inv_gl_cfg )	AS INT)		AS IvaIncluido
        FROM Clientes                 
        WHERE clinit = @NroIdCliente		

	END
	

	IF @Operacion = 'GETSUCBYCLIENTE'
	BEGIN

		--INFO SUCURSALES
		SELECT   
			LEFT(UPPER(CASE zona        WHEN 'NA' THEN ''                                          
													WHEN 'ZF' THEN 'Zona Franca - '                                         
													WHEN 'ZI' THEN 'Zona Insular - '                                          
													WHEN 'ZL' THEN 'Zona Limitrofe - '                                         
													WHEN 'CI' THEN 'Convenio Internacional - '                                                
							END        ) + LTRIM(RTRIM(Direccion)) + ' - '        + LTRIM(RTRIM(isnull(ZON.nomzona,''))) +case when ZON.nomzona is null then '' else ' - ' end +                                                                                                        
							LTRIM(RTRIM(ISNULL(CIU.ciunom,SUC.Ciudad)))        +' / '+ 
							LTRIM(RTRIM(ISNULL(PAI.nompais,SUC.pais)))        ,300)
							AS Sucursal,
							CAST(id_Sucursal AS VARCHAR(20)) AS CodigoSucursal
		FROM Sucursales SUC
		LEFT JOIN prociudades CIU ON SUC.ciudad = CIU.ciucod
		LEFT JOIN proPaises   PAI ON SUC.pais   = PAI.codPais
		LEFT JOIN ProZona     ZON ON SUC.Barrio = ZON.CodZona                                                                                                                                                                         
		WHERE  codcli = @NroIdCliente

	END

	IF @Operacion = 'GETSOLIBYCLIENTE'
	BEGIN
		--INFO SOLICITANTES
		SELECT   
			CON.Id,
			CON.NombreContacto,
			CON.CodigoCliente,
			CON.Cargo
		FROM CliOtrosContactos CON
		--LEFT JOIN clientes CLI ON CON.CodigoCliente = CLI.Clicod                                                                                                                                                                       
		WHERE  CON.CodigoCliente = @NroIdCliente
	END

	IF @operacion = 'GETARTICULOS'
	BEGIN

		SELECT	ACCGLARTI.arcod							AS Codigo
			,LEFT(RTRIM(LTRIM(ACCGLARTI.ARESPE)), 100)	AS Descripcion
			,CASE
				WHEN ACCGLARTI.CostoUltCompra=0 THEN ACCGLARTI.ArCosto
				ELSE ACCGLARTI.CostoUltCompra
				END                                     AS Costo
			,ARREF										AS Referencia
			,CASE
				WHEN GETDATE() BETWEEN accglArti.ArFecIniExcIVA AND accglArti.ArFecFinExcIVA THEN 0
				ELSE AccglArti.ArIva
				END                                    AS Iva
			,SUM(ACCGLARTIDEP.existencia)              AS Existencia
			,ACCGLARTI.ARMED						   AS Medida								
			,ArMinimo                                  AS PrecioMinimo
			,0                                         AS Minimo
			,0                                         AS Maximo
			,CASE UPPER(@Escala)
				WHEN 'ARVENTA' THEN ACCGLARTI.arventa
				WHEN 'ARDISCO' THEN ACCGLARTI.ArDisco
				WHEN 'AREVEN' THEN ACCGLARTI.ArEven
				WHEN 'ARPRECIO' THEN ACCGLARTI.ArPrecio
				END                                    AS Precio,
			@Escala									   AS Escala					
		FROM	ACCGLARTI
				INNER JOIN ACCGLARTIDEP ON ACCGLARTIDEP.CodArticulo=ACCGLARTI.arcod
				INNER JOIN prolineas ON prolineas.lincod=ACCGLARTI.arlin
		WHERE	ACCGLARTI.DELMRK='1'
				AND ACCGLARTI.arDesconti=0
		GROUP BY ACCGLARTI.arcod
				,ACCGLARTI.ARESPE
				,ACCGLARTI.CostoUltCompra
				,ARREF
				,AccglArti.ArIva
				,ACCGLARTI.ARMED
				,accglArti.arsector
				,accglArti.artipoar
				,ArMinimo
				,armar
				,Accglarti.Arlote
				,arDosificacion
				,ArEspecificacion
				,ACCGLARTI.arventa
				,ACCGLARTI.ArDisco
				,ACCGLARTI.ArEven
				,ACCGLARTI.ArPrecio
				,ArModalidad
				,arporpre1
				,arporpre2
				,arporpre3
				,arporpre4
				,arporpremin
				,ACCGLARTI.ArCosto
				,accglArti.ArFecIniExcIVA
				,accglArti.ArFecFinExcIVA
				,ACCGLARTI.Arpesado
		Union All
		SELECT	
			Case When view_EquiArt.codBarraEqui = '' 
			Then ACCGLARTI.arcod Else view_EquiArt.codBarraEqui End						AS Codigo
			,LEFT(RTRIM(LTRIM(ACCGLARTI.ARESPE)), 100) + ' ' +  view_EquiArt.MedidaVta	AS Descripcion
			,CASE
				WHEN ACCGLARTI.CostoUltCompra=0 THEN ACCGLARTI.ArCosto
				ELSE ACCGLARTI.CostoUltCompra
				END																		AS Costo
			,ARREF																		AS Referencia
			,CASE
				WHEN GETDATE() BETWEEN accglArti.ArFecIniExcIVA AND accglArti.ArFecFinExcIVA THEN 0
				ELSE AccglArti.ArIva
				END																		AS Iva
			,SUM(ACCGLARTIDEP.existencia * Round(1/view_EquiArt.VlrEqui,0))             AS Existencia
			,ACCGLARTI.ARMED															AS Medida
			,ArMinimo																	AS PrecioMinimo
			,0																			AS Minimo                           
			,0																			AS Maximo
			,CASE UPPER(@Escala)
				WHEN 'ARVENTA' THEN view_EquiArt.arventa
				WHEN 'ARDISCO' THEN view_EquiArt.ArDisco
				WHEN 'AREVEN' THEN view_EquiArt.ArEven
				WHEN 'ARPRECIO' THEN view_EquiArt.ArPrecio
				END																		AS Precio,
				@Escala									   AS Escala
		FROM	ACCGLARTI
				INNER JOIN ACCGLARTIDEP ON ACCGLARTIDEP.CodArticulo=ACCGLARTI.arcod
				INNER JOIN prolineas ON prolineas.lincod=ACCGLARTI.arlin
				Inner Join view_EquiArt ON view_EquiArt.CodArticulo = accglArti.ArCod
		WHERE	ACCGLARTI.DELMRK='1'
				AND arDesconti=0
				and ACCGLARTI.ArDifMed = 1
		GROUP BY ACCGLARTI.arcod
				,ACCGLARTI.ARESPE
				,ACCGLARTI.CostoUltCompra
				,ARREF
				,AccglArti.ArIva
				,ACCGLARTI.ARMED
				,accglArti.arsector
				,accglArti.artipoar
				,ArMinimo
				,armar
				,Accglarti.Arlote
				,arDosificacion
				,ArEspecificacion
				,view_EquiArt.arventa
				,view_EquiArt.ArDisco
				,view_EquiArt.ArEven
				,view_EquiArt.ArPrecio
				,view_EquiArt.MedidaVta
				,ArModalidad
				,arporpre1
				,arporpre2
				,arporpre3
				,arporpre4
				,arporpremin
				,ACCGLARTI.ArCosto
				,accglArti.ArFecIniExcIVA
				,accglArti.ArFecFinExcIVA
				,view_EquiArt.codBarraEqui
				,ACCGLARTI.Arpesado

	END

	IF @Operacion = 'GETSERVICIOS'
	BEGIN
		
		SELECT 
			tracod	AS Codigo,
			tranom	AS Servicio,
			tramed	AS Medida,
			travlr	AS Valor,
			traiva	AS Iva,
			Costo	AS Costo,
			trades	AS Descripcion
			,CASE UPPER(@Escala)
				WHEN 'ARVENTA'	THEN arventa
				WHEN 'ARDISCO'	THEN ArDisco
				WHEN 'AREVEN'	THEN ArEven
				WHEN 'ARPRECIO' THEN ArPrecio
			END      AS Precio,
			@Escala		AS Escala
		FROM trabajos
		WHERE delmrk = '1'

	END

	IF @Operacion = 'SAVEPEDIDO'
	BEGIN
		
		DECLARE @consecutivo VARCHAR(20)=''
		DECLARE @fuente      VARCHAR(4)=''

		EXEC Proc_Buscar_Consecutivo '44' ,@consecutivo OUTPUT ,@fuente OUTPUT ,''

		SELECT @TipoCliente=CliTipoCli FROM clientes WHERE clicod=@CodigoCliente OR clinit = @NitCliente

		INSERT INTO accpedidos (nrofac,tipodoc,tipocli,codcli,fecfac,venfac,vlrfac,saldo,descuento,estado,subtotal,iva,clitipo,_nivainc,ciudad ,direccion,REDONDEO,cxc_Id_Sucursal,detalle,vendedor,fechaReq,solicitante)
		VALUES(@consecutivo,'FR',@tipoCLiente,@CodigoCliente,@Fecha,0,@Total,@Total,0,0,@SubTotal,@ValorIva,@tipoCLiente,@IvaIncluido,@CodigoCiudad,@Direccion,1,@CodigoSucursal,@Detalle,@CodigoVendedor,@FechaRequerido,@CodigoSolicitante)
	
	
		INSERT INTO accmovpedidos (numfac,codart,tipdoc,cantid,detalle,medida,vlruni,tipmov,ctainv,ctacos,ctaing,teccod,ivaart,costo,movdep,MovEsc,PorDescuento,tercod,vlriva,dsubtotal,ccosto,NumDoc, tipdoc_ped)
								SELECT @consecutivo,ISNULL(codigo,''),'FR',ISNULL(cantidad,0),ISNULL(detalle,''),ISNULL(medida,''),ISNULL(vlruni,0),ISNULL(tipoMov,''),
								CASE WHEN tipoMov = 'INV' THEN ISNULL(dbo.GetPucInventario(codigo,'',1),'') ELSE '' END,
								CASE WHEN tipoMov = 'INV' THEN ISNULL(dbo.GetPucInventario(codigo,'',2),'') ELSE '' END,
								CASE WHEN tipoMov = 'INV' THEN ISNULL(dbo.GetPucInventario(codigo,'',3),'') ELSE ISNULL((SELECT TOP(1) tracon FROM Trabajos WHERE tracod = codigo),'') END,
								ISNULL(tecnico,''),ISNULL(iva,0),ISNULL(costo,0),ISNULL(dependencia,''),ISNULL(@CodigoEscala,'0001'),ISNULL(porDescuento,0),ISNULL(tercero,''),ISNULL(valoriva,0),ISNULL(subtotal,0),ISNULL(cco,''),ISNULL(NumDoc,''), ISNULL(tipdoc_ped,'')
								FROM @TServicios


		SELECT 
			PED.nrofac		AS NumeroPedido,
			PED.fecfac		AS Fecha,
			CLI.clinom		AS Cliente,
			PED.fechaReq	AS FechaRequerido,
			PED.vlrfac		AS Total,
			PED.subtotal	AS SubTotal,
			PED.iva			AS ValorIva,
			PED.detalle		AS Descripcion,
			CASE WHEN 
				PED.estado = '0' THEN 'GENERADO' 
				ELSE CASE WHEN PED.estado = 1 THEN 'AUTORIZADO' 
				ELSE CASE WHEN PED.estado = 2 THEN 'NO AUTORIZADO'
				ELSE CASE WHEN PED.estado = 3 THEN 'FACTURADO' ELSE 'REMISIONADO' END END END END AS Estado,
			PRO.ciunom		AS Ciudad,
			SUC.direccion	AS Direccion,
			PED.Calificacion AS Calificacion			
		FROM GLERP.DBO.accpedidos		PED
		LEFT JOIN GLERP.DBO.clientes	CLI ON PED.codcli			= CLI.clicod
		LEFT JOIN GLERP.DBO.prociudades	PRO ON PRO.ciucod			= CLI.cliCodCiud
		LEFT JOIN GLERP.DBO.proPaises	PAI ON CLI.cliPais			= PAI.codPais
		LEFT JOIN GLERP.DBO.vendedores	VEN ON PED.vendedor			= VEN.vencod 
		LEFT JOIN GLERP.DBO.Sucursales	SUC ON PED.cxc_Id_Sucursal	= SUC.id_Sucursal
		LEFT JOIN GLERP.DBO.ProZona		ZON ON SUC.Barrio			= ZON.CodZona 
		WHERE PED.nrofac = @consecutivo
	END

END
GO

IF OBJECT_ID(N'dbo.WEBGLSS_SP_GESTIONHUMANA') IS NULL
BEGIN
    PRINT 'Create procedure : dbo.WEBGLSS_SP_GESTIONHUMANA'
    EXECUTE('CREATE PROCEDURE dbo.WEBGLSS_SP_GESTIONHUMANA AS RETURN 0') 
END
GO

PRINT 'Alter procedure : dbo.WEBGLSS_SP_GESTIONHUMANA'
GO

ALTER PROCEDURE [dbo].[WEBGLSS_SP_GESTIONHUMANA] 
    @Operacion		VARCHAR(20) = '',
	@NumeroCedula	VARCHAR(20) = '',
	@Periodo		VARCHAR(5) = '0',
	@Banco			VARCHAR(20) = '',
	@CodEmpleado	VARCHAR(20) = ''
AS
BEGIN

	IF @Operacion = 'GETCERLABS'
	BEGIN
		
		DECLARE @SueldoPromTable AS TABLE
		(
			empSuelBas  NUMERIC(18,2),
			PROMEDIO_HORAS_EXTRA NUMERIC(18,2)
		)  

		SET @CodEmpleado  = (SELECT TOP(1) empcod FROM neEmpleados WHERE empced = @NumeroCedula)

		SELECT
		  Empleado.*
		 ,logempresa					AS Logo
		 ,LTRIM(RTRIM(CFG.nomempresa))	AS NombreEmpresa
		 ,LTRIM(RTRIM(CFG.nitempresa + '-' + digver))	AS NitEmpresa
		 ,LTRIM(RTRIM(CFG.dirempresa))					AS DireccionEmpresa
		 ,LTRIM(RTRIM(CFG.contelefono))					AS Contelefono
		 ,LTRIM(RTRIM(CFG.conciudad))					AS Conciudad
		 ,ISNULL(DEP.nomdpto, '')						AS NombreDepartamento
		 ,CFG.reprelegal								AS RepresentanteLegal
		 ,(SELECT ISNULL(cedreplegal, '') FROM inv_gl_cfg) AS NitRepresentanteLegal
		 ,CFGN.responsabledocu							AS DocumentoRepresentanteLegal
		 ,CFGN.cargo									AS CargoRepresentanteLegal
		 ,CONVERT(VARCHAR,GETDATE(),106)				AS FechaCertificado
		INTO #TempReport
		FROM  
		(
		  SELECT
			  EMP.empNom				AS CTSNombreEmpleado
			 ,EMP.empced				AS CTSCedula
			 ,CASE WHEN empContrato = 1 THEN 'INDEFINIDO' ELSE CASE WHEN empContrato = 2 THEN 'T�RMINO FIJO' ELSE CASE WHEN empContrato = 3 THEN 'LABOR CONTRATADA' ELSE 'PASANTE' END END END AS CTSTipoContrato
			 ,EMP.empsuelbas			AS CTSSueldo
			 ,DBO.CantidadConLetra(EMP.empsuelbas,'COP') AS CTSSueldoEscrito
			 ,LTRIM(RTRIM(CAR.Nombre))	AS CTSCargo
			 ,CONVERT(VARCHAR,EMP.empFecing,106)				AS CTSFechaIngreso
			 ,CONVERT(VARCHAR,EMP.empfecret,106)				AS CTSFechaRetiro
			 ,EMP.empSubTransporte		AS CTSSubSidioTransporte
			 ,0.00						AS CTSHorasExtras
		 FROM neEmpleados EMP
		 LEFT JOIN necargoempleado  CAR ON EMP.EmpCargo = CAR.codigo 
		 WHERE empCed = @NumeroCedula
		)AS Empleado,ne_gl_cfg CFGN,
		gl_cfg CFG
		LEFT JOIN prociudades      CIU ON CFG.imprimircont = CIU.ciucod
		LEFT JOIN proDepartamentos DEP ON CIU.codDpto = DEP.coddpto

		INSERT INTO @SueldoPromTable EXEC PA_SueldoEmp @CodEmpleado= @CodEmpleado

		SELECT TMP.*,SU.empSuelBas AS CTSSueldoPromedio,SU.PROMEDIO_HORAS_EXTRA AS CTSHorasExtraPromedio FROM #TempReport AS TMP,@SueldoPromTable AS SU

		DROP TABLE #TempReport

	END

	IF @Operacion = 'GETCERLAB'
	BEGIN
		
		DECLARE @EmpSueldo AS TABLE
		(
			Cedula  VARCHAR(20),
			NombreEmpl VARCHAR(200),
			Periodo	VARCHAR(5),
			Salario	NUMERIC(18,2),
			Cesantias			NUMERIC(18,2),
			OtrosIng			NUMERIC(18,2),
			TotalIng			NUMERIC(18,2),
			Salud				NUMERIC(18,2),
			Pension				NUMERIC(18,2),
			PensionVoluntaria	NUMERIC(18,2),
			Retencion			NUMERIC(18,2)
		) 

		DECLARE @Fecha VARCHAR(10) = CONVERT(VARCHAR,GETDATE(),112)
		
		INSERT INTO @EmpSueldo EXEC PA_RecHumanos	@Operacion=N'RI'
													,@FechaInicio= @Fecha
													,@FechaFin= @Fecha
													,@Numero=@NumeroCedula
													,@TraerRet=0
													,@Agrupacion=@Periodo
													,@Porcentaje=0
													,@AumentarSueldo=1
													,@AumentarSubtrans=1
													,@AumentarProvisiones=1
													,@AumentarParafiscales=1
													,@AumetarPrestacionesSociales=1
													,@Monto=0
													,@TipoAumento=N''
													,@Round=1
													,@MontoSubtr=0
		
		SELECT
		  EMP.Cedula					AS CTSCedula
		  ,EMP.NombreEmpl				AS CTSNombreEmpleado
		  ,EMP.Periodo					AS Periodo
		  ,EMP.Salario					AS Salario
		  ,EMP.Cesantias			
		  ,EMP.OtrosIng			
		  ,EMP.TotalIng			
		  ,EMP.Salud				
		  ,EMP.Pension				
		  ,EMP.PensionVoluntaria	
		  ,EMP.Retencion			
		 ,logempresa					AS Logo
		 ,LTRIM(RTRIM(CFG.nomempresa))	AS NombreEmpresa
		 ,LTRIM(RTRIM(CFG.nitempresa + '-' + digver))	AS NitEmpresa
		 ,LTRIM(RTRIM(CFG.dirempresa))					AS DireccionEmpresa
		 ,LTRIM(RTRIM(CFG.contelefono))					AS Contelefono
		 ,LTRIM(RTRIM(CFG.conciudad))					AS Conciudad
		 ,ISNULL(DEP.nomdpto, '')						AS NombreDepartamento
		 ,CFG.reprelegal								AS RepresentanteLegal
		 ,(SELECT ISNULL(cedreplegal, '') FROM inv_gl_cfg) AS NitRepresentanteLegal
		 ,CFGN.responsabledocu							AS DocumentoRepresentanteLegal
		 ,CFGN.cargo									AS CargoRepresentanteLegal
		 ,CONVERT(VARCHAR,GETDATE(),106)				AS FechaCertificado
		 FROM @EmpSueldo AS EMP, ne_gl_cfg CFGN,
		gl_cfg CFG
		LEFT JOIN prociudades      CIU ON CFG.imprimircont = CIU.ciucod
		LEFT JOIN proDepartamentos DEP ON CIU.codDpto = DEP.coddpto

	END

	IF @Operacion = 'GETCONTRATO'
	BEGIN
		
		SELECT gl_cfg.nomempresa		AS NombreEmpresa	
          ,gl_cfg.dirempresa	AS DireccionEmpresa
          ,EMP.empNom			AS NombreEmpleado
          ,EMP.empCed			AS CedulaEmpleado
          ,EMP.empDir			AS DireccionEmpleado
		  ,EMP.emptel			AS Telefono
          ,CONVERT(VARCHAR,EMP.empFechana,103)		AS FechaNacimientoEmpleado
          ,EMP.empSuelBas		AS SalarioBasico
          ,EMP.empFPago			AS PeriodoPago
          ,CONVERT(VARCHAR,EMP.empFecing,103)		AS FechaInicio
		  ,CONVERT(VARCHAR,EMP.empFecRet,103)		AS FechaFin
          ,EMP.emprecordar		
          ,CASE WHEN EMP.empContrato = 1 THEN 'INDEFINIDO' ELSE CASE WHEN EMP.empContrato = 2 THEN 'T�RMINO FIJO' ELSE CASE WHEN EMP.empContrato = 3 THEN 'LABOR CONTRATADA' ELSE 'PASANTE' END END END AS TipoContrato
          ,ISNULL(CASE WHEN LEN(EMP.empmunicipio) <= 5 THEN CIU.ciunom ELSE EMP.empmunicipio END,'') AS DepartamentoFirma
          ,CAR.Nombre			AS Cargo
		  ,PRO.Nombre			AS ProfesionEmpleado
          ,
           --Datos del Representante Legal de La empresa
           reprelegal        AS representante
          ,cedreplegal       AS cedRepresentante
          ,(SELECT ISNULL(c.ciunom, '') AS nombreCiudad
             FROM inv_gl_cfg i
             LEFT JOIN prociudades c
               ON c.ciucod=i.repreCiudad)                 
           AS CiudadRepresentante
          ,(SELECT ISNULL(d.nomdpto, '') AS nombreDpto
             FROM inv_gl_cfg i
             LEFT JOIN prociudades c
               ON c.ciucod=i.repreCiudad
             LEFT JOIN prodepartamentos d
               ON d.coddpto=c.codDpto)                 
           AS dptoCiudadRepresentante
          ,
           --Otros Datos de la EMpresa
           gl_cfg.conciudad  AS CiudadEmpresa
          ,gl_cfg.nitEmpresa AS NitEmpresa
          ,ISNULL(CIUE.ciunom,'') 	AS CiudadFirma
		  ,CONVERT(VARCHAR,GETDATE(),103) AS FechaFirma
          ,EMP.TipDoc AS TipoDoc
    FROM neEmpleados EMP CROSS JOIN gl_cfg CROSS JOIN inv_gl_cfg
    LEFT JOIN prociudades CIUE ON empCiuExp = CIUE.ciucod 
	LEFT JOIN prociudades CIU	ON EMP.empmunicipio = CIU.ciucod
	LEFT JOIN NeCargoEmpleado CAR ON EMP.EmpCargo = CAR.Codigo
	LEFT JOIN NeCargoEmpleado PRO ON EMP.empCar = PRO.Codigo
	WHERE EMP.empCed=@NumeroCedula

	END

	IF @Operacion = 'GETEXAMI'
	BEGIN
		
		SELECT
			  EMP.empNom				AS NombreEmpleado
			 ,(SELECT TOP(1) LTRIM(RTRIM(nomempresa)) FROM gl_cfg)	AS NombreEmpresa
			 ,(SELECT TOP(1) LTRIM(RTRIM(nitempresa + '-' + digver)) FROM gl_cfg)	AS NitEmpresa
			 ,(SELECT TOP(1) LTRIM(RTRIM(dirempresa)) FROM gl_cfg)	AS DireccionEmpresa
			 ,(SELECT TOP(1) LTRIM(RTRIM(contelefono)) FROM gl_cfg)	AS TelefonoEmpresa
			 ,(SELECT TOP(1) LTRIM(RTRIM(termail)) FROM accglter WHERE ternit = (SELECT TOP(1) JefeRRHH FROM gl_cfg2))	AS EmailEmpresa
			 ,EMP.empced				AS Cedula
			 ,ISNULL(LTRIM(RTRIM(CAR.Nombre)),'')	AS Cargo
			 ,ISNULL(SUB.Nombre_Sub,'')	AS CentroCosto
			 ,CONVERT(VARCHAR,GETDATE(),106) AS Fecha
			 ,(SELECT TOP(1) empNom FROM neEmpleados WHERE empCed = (SELECT TOP(1) JefeRRHH FROM gl_cfg2)) AS JefeRRHH
		 FROM neEmpleados EMP
		 LEFT JOIN necargoempleado  CAR ON EMP.EmpCargo = CAR.codigo 
		 LEFT JOIN View_SubCentro_Costo SUB ON EMP.empCCosto = SUB.Codigo_Sub
		 WHERE empCed = @NumeroCedula

	END

	IF @Operacion = 'GETBANCOS'
	BEGIN
		SELECT DISTINCT bancod AS Codigo,bannom AS Nombre FROM bancos  WHERE  delmrk = 1  ORDER BY bancos.bannom 
	END

	IF @Operacion = 'GETCARTABAN'
	BEGIN

		SELECT
				  EMP.empNom				AS NombreEmpleado
				 ,EMP.empced				AS Cedula
				 ,(SELECT TOP(1) LTRIM(RTRIM(nomempresa)) FROM gl_cfg)	AS NombreEmpresa
				 ,(SELECT TOP(1) LTRIM(RTRIM(nitempresa + '-' + digver)) FROM gl_cfg)	AS NitEmpresa
				 ,CASE WHEN empContrato = 1 THEN 'INDEFINIDO' ELSE CASE WHEN empContrato = 2 THEN 'T�RMINO FIJO' ELSE CASE WHEN empContrato = 3 THEN 'LABOR CONTRATADA' ELSE 'PASANTE' END END END AS TipoContrato
				 ,EMP.empsuelbas			AS Sueldo
				 ,ISNULL(LTRIM(RTRIM(CAR.Nombre)),'')	AS Cargo
				 ,CONVERT(VARCHAR,EMP.empFecing,106)				AS FechaIngreso
				 ,CONVERT(VARCHAR,EMP.empfecret,106)				AS FechaRetiro
				 ,(SELECT TOP(1) nroCtaBanco FROM accglpuc WHERE glcod ='11200509' ) AS CuentaBanco
				 ,(SELECT TOP(1) nombreBanco FROM accglpuc WHERE glcod ='11200509' ) AS NombreBanco
				 ,CONVERT(VARCHAR,GETDATE(),106) AS Fecha
				 ,(SELECT TOP(1) LTRIM(RTRIM(conciudad)) FROM gl_cfg)	AS Ciudad
				 ,'' Codigo
				 ,'' Version
				 ,'' FechaVigencia
			FROM neEmpleados EMP
			LEFT JOIN necargoempleado  CAR ON EMP.EmpCargo = CAR.codigo 
			WHERe empced = @NumeroCedula
	END

	IF @Operacion = 'GET_HIST_LAB_EMP'
	BEGIN
		
		SET @CodEmpleado  = (SELECT TOP(1) empcod FROM neEmpleados WHERE empced = @NumeroCedula)

		SELECT 
			 EMP.empNom AS NombreEmpleado
			,EMP.empCed AS CedulaEmpleado
			,HIS.HisIni AS FechaInicial
			,HIS.HisFin AS FechaFinal
			,HIS.HisMotivo AS Motivo
		FROM NeHistorico HIS
		LEFT JOIN neEmpleados EMP ON HIS.HisEmp = EMP.empcod
		WHERE HisEmp = @CodEmpleado
		ORDER BY HIS.HisIni ASC
	END

END
GO


IF OBJECT_ID(N'dbo.WEBGLSS_SP_PERFILES') IS NULL
BEGIN
    PRINT 'Create procedure : dbo.WEBGLSS_SP_PERFILES'
    EXECUTE('CREATE PROCEDURE dbo.WEBGLSS_SP_PERFILES AS RETURN 0') 
END
GO

PRINT 'Alter procedure : dbo.WEBGLSS_SP_PERFILES'
GO

ALTER PROCEDURE [dbo].[WEBGLSS_SP_PERFILES] 
    @Operacion		VARCHAR(20) = '',
	@Search			VARCHAR(MAX) = '',
	@Codigo			VARCHAR(20) = '',
	@Nombre			VARCHAR(50) = '',
	@NroId			VARCHAR(20) = '',
	@Email			VARCHAR(50) = '',
	@RecibeEmail	BIT = 0,
	@Area			VARCHAR(5) = '',
	@IdPQRSF		INT = 0,
	@Ruta			VARCHAR(150) = '',
	@NombreArchivo	VARCHAR(100) = '',
	@Url			VARCHAR(200) = '',
	@ContentType	VARCHAR(150) = '',
	@NitEmpresa	    VARCHAR(20) = ''
AS
BEGIN
	
	SET @Nombre = UPPER(@Nombre)

	IF @Operacion = 'GETETIQUETAS'
	BEGIN
		SELECT * FROM proEtiquetas
		WHERE delmrk = 1 AND Nombre LIKE CASE WHEN @Search = '' THEN Nombre ELSE '%' + @Search + '%' END
	END

	IF @Operacion = 'SAVEETIQUETAS'
	BEGIN
		SELECT @Codigo = REPLICATE('0',4 - LEN(CAST(MAX(CAST(codigo AS INT) + 1) AS VARCHAR))) +  CAST((MAX(CAST(codigo AS INT) + 1)) AS VARCHAR) FROM proEtiquetas

		INSERT INTO proEtiquetas(delmrk,codigo,nombre) VALUES(1,@Codigo,@Nombre)

		SELECT * FROM proEtiquetas WHERE codigo = @Codigo
	END

	IF @Operacion = 'EDITETIQUETAS'
	BEGIN
		UPDATE proEtiquetas set nombre = @Nombre WHERE codigo = @Codigo
		SELECT * FROM proEtiquetas WHERE codigo = @Codigo
	END

	IF @Operacion = 'DELETEETIQUETA'
	BEGIN
		UPDATE proEtiquetas set delmrk = 0 WHERE codigo = @Codigo
		SELECT * FROM proEtiquetas WHERE codigo = @Codigo
	END
	---------------------------------------------------------------------------------------------------------------------------------------------------------
	IF @Operacion = 'GETPREGUNTAS'
	BEGIN
		SELECT * FROM WEBGLSS_Preguntas
		WHERE delmrk = 1 AND NomPregunta LIKE CASE WHEN @Search = '' THEN NomPregunta ELSE '%' + @Search + '%' END
	END

	IF @Operacion = 'SAVEPREGUNTA'
	BEGIN

		INSERT INTO WEBGLSS_Preguntas(delmrk,NomPregunta,NitEmpresa) VALUES(1,@Nombre,'')
		
		SELECT * FROM WEBGLSS_Preguntas WHERE id = SCOPE_IDENTITY()
	END

	IF @Operacion = 'EDITPREGUNTA'
	BEGIN
		UPDATE WEBGLSS_Preguntas set NomPregunta = @Nombre WHERE id = @Codigo
		SELECT * FROM WEBGLSS_Preguntas WHERE id = @Codigo
	END

	IF @Operacion = 'DELETEPREGUNTA'
	BEGIN
		UPDATE WEBGLSS_Preguntas SET delmrk = 0 WHERE id = @Codigo
		SELECT * FROM WEBGLSS_Preguntas WHERE id = @Codigo
	END
	--------------------------------------------------------------------------------------------------------------------------------------------------------------
	IF @Operacion = 'GETAREAS'
	BEGIN
		SELECT * FROM proareas
		WHERE delmrk = 1 AND nomare LIKE CASE WHEN @Search = '' THEN nomare ELSE '%' + @Search + '%' END
	END

	IF @Operacion = 'SAVEAREA'
	BEGIN
		
		SELECT @Codigo = REPLICATE('0',4 - LEN(CAST(MAX(CAST(codare AS INT) + 1) AS VARCHAR))) +  CAST((MAX(CAST(codare AS INT) + 1)) AS VARCHAR) FROM proareas

		INSERT INTO proareas(delmrk,codare,nomare,areResponsable) VALUES(1,@Codigo,@Nombre,'')
		
		SELECT * FROM proareas WHERE codare = @Codigo
	END

	IF @Operacion = 'EDITAREA'
	BEGIN
		UPDATE proareas set nomare = @Nombre WHERE codare = @Codigo
		SELECT * FROM proareas WHERE codare = @Codigo
	END

	IF @Operacion = 'DELETEAREA'
	BEGIN
		UPDATE proareas SET delmrk = 0 WHERE codare = @Codigo
		SELECT * FROM proareas WHERE codare = @Codigo
	END

	IF @Operacion = 'GETTERCERO'
	BEGIN
		SELECT TOP(1) * FROM accglTer WHERE ternit = @Codigo
	END
	-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	IF @Operacion = 'GETAGENTES'
	BEGIN
		SELECT 
			 AG.Id
			,AG.Codigo
			,AG.NroId
			,AG.NombreCompleto
			,AG.Email
			,AG.RecibeEmail
			,AG.NitEmpresa
			,AG.delmrk
			,ISNULL(AR.nomare,'SIN �REA') AS Area
		FROM WEBGLSS_Agentes AG
		LEFT JOIN proareas AR ON AG.Area = AR.codare
		WHERE AG.delmrk = 1 AND (NombreCompleto LIKE CASE WHEN @Search = '' THEN NombreCompleto ELSE '%' + @Search + '%' END OR
		                         AG.NroId LIKE CASE WHEN @Search = '' THEN AG.NroId ELSE '%' + @Search + '%' END )
		AND NroId <> '0000000000'
	END

	IF @Operacion = 'GETAGENTE'
	BEGIN
		SELECT 
			 AG.Id
			,AG.Codigo
			,AG.NroId
			,AG.NombreCompleto
			,AG.Email
			,AG.RecibeEmail
			,AG.NitEmpresa
			,AG.delmrk
			,AG.Area
		FROM WEBGLSS_Agentes AG
		WHERE AG.delmrk = 1 AND  NroId = @Codigo
	END

	IF @Operacion = 'SAVEAGENTE'
	BEGIN

		IF EXISTS(SELECT * FROM WEBGLSS_Agentes WHERE NroId = @NroId)
		BEGIN

			UPDATE WEBGLSS_Agentes SET delmrk = 1 WHERE NroId = @NroId
			SELECT * FROM WEBGLSS_Agentes WHERE NroId = @NroId
		END
		ELSE
		BEGIN
			SELECT @Codigo = REPLICATE('0',10 - LEN(CAST(MAX(CAST(codigo AS INT) + 1) AS VARCHAR))) +  CAST((MAX(CAST(codigo AS INT) + 1)) AS VARCHAR) FROM WEBGLSS_Agentes
		
			INSERT INTO WEBGLSS_Agentes(Codigo,NroId,NombreCompleto,Email,RecibeEmail,NitEmpresa,delmrk,Area)
			VALUES(@Codigo,@NroId,@Nombre,@Email,@RecibeEmail,'','1',@Area)

			SELECT * FROM WEBGLSS_Agentes WHERE id = SCOPE_IDENTITY()
		END

	END

	IF @Operacion = 'GETUSERTOAGENTE'
	BEGIN
		SELECT Id,NroId,Nombre,Email FROM AspNetUsers
		WHERE NroId = @Codigo
	END

	IF @Operacion = 'ENABLEDMAIL'
	BEGIN
		UPDATE WEBGLSS_Agentes SET RecibeEmail = CASE WHEN RecibeEmail = 1 THEN 0 ELSE 1 END WHERE Id = @Codigo
		SELECT * FROM WEBGLSS_Agentes WHERE Id = @Codigo
	END

	IF @Operacion = 'DELETEAGENTE'
	BEGIN
		UPDATE WEBGLSS_Agentes SET delmrk = 0 WHERE Id = @Codigo
		SELECT * FROM WEBGLSS_Agentes WHERE Id = @Codigo
	END

	IF @Operacion = 'SAVE_FILE'
	BEGIN
		
		INSERT INTO WEBGLSSS_Archivos(CodPQRSF,Nombre,Ruta,Url,ContentType,NitEmpresa,delmrk)
		VALUES(@IdPQRSF,@NombreArchivo,@Ruta,@Url,@ContentType,@NitEmpresa,1)

		SELECT * FROM WEBGLSSS_Archivos WHERE Id = SCOPE_IDENTITY()

	END

	IF @Operacion = 'GET_SITUACIONES'
	BEGIN
		
		SELECT Id,Codigo,TipoSituacion,delmrk 
		FROM WEBGLSS_SituacionesNoConformes
		WHERE delmrk = 1
	END

	IF @Operacion = 'GET_ESTADOS'
	BEGIN
		
		SELECT Id,Nombre,delmrk 
		FROM WEBGLSS_Estados
		WHERE delmrk = 1

	END

	IF @Operacion = 'GET_PRIORIDADES'
	BEGIN
		
		SELECT Id,Nombre,delmrk 
		FROM WEBGLSS_Prioridades
		WHERE delmrk = 1

	END

	IF @Operacion = 'GET_CONTACTOS'
	BEGIN
		
		SELECT Id,NroIdCli,NombreContacto,Telefono,Celular,Email,NitEmpresa,delmrk
		FROM WEBGLSS_ContactoClientes
		WHERE delmrk = 1

	END

	IF @Operacion = 'GET_DEPENDENCIA'
	BEGIN
	
		SELECT *
		FROM prodepende
		WHERE delmrk = 1
	END

	IF @Operacion = 'GET_TIP_PERMISOS'
	BEGIN
	
		SELECT *
		FROM V_MotivosPermisos
		WHERE delmrk = 1
	END

END
GO


IF OBJECT_ID(N'dbo.WEBGLSS_SP_TERCERO_CLIENTE') IS NULL
BEGIN
    PRINT 'Create procedure : dbo.WEBGLSS_SP_TERCERO_CLIENTE'
    EXECUTE('CREATE PROCEDURE dbo.WEBGLSS_SP_TERCERO_CLIENTE AS RETURN 0') 
END
GO

PRINT 'Alter procedure : dbo.WEBGLSS_SP_TERCERO_CLIENTE'
GO

ALTER PROCEDURE [dbo].[WEBGLSS_SP_TERCERO_CLIENTE]
	 @ternit	VARCHAR(15)		= ''
	,@tipdoc	VARCHAR(2)		= ''
	,@terprinom	VARCHAR(20)		= ''
	,@TerSegNom	VARCHAR(30)		= 0
	,@terpriape VARCHAR(20)		= ''
	,@tersegape VARCHAR(30)		= ''
	,@terdir VARCHAR(200)		= ''
	,@terCodCiu VARCHAR(5)		= ''
	,@tertel VARCHAR(50)		= ''
	,@termail VARCHAR(200)		= ''
	,@tercod VARCHAR(20) = ''
	,@Operacion VARCHAR(20)		= ''
	,@clinit VARCHAR(20) = ''
	,@clicod VARCHAR(20) = ''
	,@clinom VARCHAR(200) = ''
	,@cliPriNom VARCHAR(20) = ''
	,@cliSegNom VARCHAR(30) = ''
	,@cliPriApe VARCHAR(20) = ''
	,@cliSegApe VARCHAR(30) = ''
	,@clidir VARCHAR(200) = ''
	,@clicodciud VARCHAR(5) = ''
	,@clitel VARCHAR(50) = ''
	,@clicel VARCHAR(50) = ''
	,@climail VARCHAR(200) = ''
AS
BEGIN	
		
		DECLARE @ternom VARCHAR(200) = '',@mensaje VARCHAR(500) = ''
		IF @Operacion = 'IC'
		BEGIN

			SET @clinom = @cliPriNom + ' ' + @cliSegNom+ ' ' +  @cliPriApe+ ' ' + @cliSegApe

			INSERT INTO accglter
			(tipdoc, ternit, ternom, terpriape, tersegape, terprinom, TerSegNom, termail, tertel, terdir, terCodCiu, terPais,tercel)
			VALUES (@tipdoc, @clinit, UPPER(@clinom), UPPER(@cliPriNom), UPPER(@cliSegNom), UPPER(@cliPriApe), UPPER(@cliSegApe), @climail, @clitel, @clidir, @clicodciud,169,@clicel)	

			SELECT @tercod = tercod FROM accglTer WHERE ternit = @clinit

			INSERT INTO Clientes
			(clicod,tipdoc, clinit, clinom, clipriape, clisegape, cliprinom, cliSegNom, climail, clitel, clidir, cliCodCiud, cliPais,clicel1)
			VALUES (@tercod,@tipdoc, @clinit, UPPER(@clinom), UPPER(@cliPriNom), UPPER(@cliSegNom), UPPER(@cliPriApe), UPPER(@cliSegApe), @climail, @clitel, @clidir, @clicodciud,169,@clicel)	

			SELECT * FROM clientes WHERE clicod = @tercod

		END

		IF @Operacion = 'SC'
		BEGIN
			SELECT * FROM clientes WHERE clinit = @clinit
		END

		IF @Operacion = 'GET_CLIENTES'
		BEGIN
			SELECT * FROM clientes WHERE delmrk = 1
			ORDER BY clinom ASC
		END
END
GO


IF OBJECT_ID(N'dbo.WEBGLSS_SP_AnalisisVenCMI') IS NULL
BEGIN
    PRINT 'Create procedure : dbo.WEBGLSS_SP_AnalisisVenCMI'
    EXECUTE('CREATE PROCEDURE dbo.WEBGLSS_SP_AnalisisVenCMI AS RETURN 0') 
END
GO

PRINT 'Alter procedure : dbo.WEBGLSS_SP_AnalisisVenCMI'
GO
ALTER PROCEDURE [dbo].[WEBGLSS_SP_AnalisisVenCMI]
@Operacion VARCHAR(20)=''
,@SubOperacion VARCHAR(20)=''
,@FechaIni VARCHAR(50)='19000101'
,@FechaFin VARCHAR(50)='19000101'
,@rangoDias INT=0
,@clinit VARCHAR(MAX)=''
,@NDocumento VARCHAR(15)=''
,@SuperSalud BIT=0
,@Anno VARCHAR(4)=''
,@Anno1 VARCHAR(4)=''
,@codCliente VARCHAR(20)=''
,@search VARCHAR(MAX)=''
,@Factura VARCHAR(20) = ''
,@TipoFac VARCHAR(2) = ''
AS
BEGIN
	DECLARE @tipo INT,@lim1 INT,@lim2 INT,@lim3 INT

	SET @search = LTRIM(RTRIM(@search))

	IF @Operacion='S' -- OK
	BEGIN
		DECLARE @Todo INT=1

		SELECT	RecFac
				,RecTip
				,CAST(0 AS NUMERIC(18, 2)) AS Abono
		INTO	#REcibosTmp
		FROM	Recibos
		WHERE	id = 0

		IF CAST(GETDATE() AS DATE)>@FechaFin
		BEGIN
			INSERT INTO #REcibosTmp (RecFac, RecTip, Abono)
			SELECT	RECFAC,RECTIP,ISNULL(SUM(RecVlr+RecrtIVA+RecrtICA+RecrtFTE+RecrtCREE+
											 RecDescto+RecrtGarantias), 0) AS ABONO
			FROM	RECIBOS
			WHERE	RECFEC <= @FechaFin
					AND RECEST = 0
			GROUP BY RECFAC,RECTIP

			SET @Todo=0
		END

		SELECT dbo.acccccxc.tipodoc
				,ISNULL(dbo.clientes.clinom, '')         AS nombres
				,dbo.acccccxc.nrofac
				,dbo.acccccxc.vendedor
				,ISNULL(dbo.vendedores.vennom, '')       AS vennom
				,ISNULL(dbo.ProZona.NomZona, '')         AS NomZona
				,ISNULL(clientes.CliTel, '')             AS CliTel
				,dbo.acccccxc.fecfac+dbo.acccccxc.venfac AS venfac
				,GETDATE()                               AS fechaActual
				,ISNULL(clientes.CliDir, '')             AS CliDir
				,dbo.acccccxc.fecfac
				,(ISNULL(VLRFAC, 0)*TCambio)             AS vlrfac
				,dbo.acccccxc.codcli
				,dbo.acccccxc.clitipo
				,dbo.tipocliente.tipnom
				,CASE
					WHEN ISNULL(LTRIM(RTRIM(acccccxc.Calificacion)), '')='' THEN 'SIN GESTION'
					ELSE ISNULL(LTRIM(RTRIM(acccccxc.Calificacion)), '')
				END                                     AS Calificacion
				,SubTotal * TCambio                       AS SubTotal
				,dbo.acccccxc.saldo * TCambio			AS Valor
				,CASE
					WHEN @Todo=1 THEN acccccxc.saldo * TCambio
					ELSE (ISNULL(VLRFAC, 0)-ISNULL(ABONO, 0))*ACCCCCXC.TCAMBIO
				END                                     
				AS SALDO
				,ISNULL(dbo.acccccxc.FechaPago, '')      AS FechaPago
				,dbo.acccccxc.vlrfac  * TCambio                    AS valor1
				,dbo.acccccxc.vlrfac   * TCambio                   AS valor2
				,dbo.acccccxc.vlrfac   * TCambio                   AS valor3
				,dbo.acccccxc.vlrfac    * TCambio                  AS valor4
				,dbo.acccccxc.vlrfac    * TCambio                  AS valor5
				,CASE
					WHEN UPPER(LTRIM(RTRIM(dbo.acccccxc.Calificacion))) IN ('', 'OBJETADO', 'PREJURIDICO') THEN 0
					WHEN UPPER(LTRIM(RTRIM(dbo.acccccxc.Calificacion))) IN ('SIN GESTI�N', 'EN PROGRAMACI�N') THEN 1
					WHEN UPPER(LTRIM(RTRIM(dbo.acccccxc.Calificacion))) IN ('CONFIRMADO') AND
					YEAR(FechaPago)<>1900 THEN 2
				END                                     AS Estado
				,CASE
					WHEN DATEDIFF(DAY, dbo.acccccxc.fecfac, @FechaFin)<0 THEN DATEDIFF(DAY, dbo.acccccxc.fecfac, @FechaFin)
					ELSE DATEDIFF(DAY, dbo.acccccxc.fecfac, @FechaFin)
				END                                     AS DiasFact
				,CASE
					WHEN DATEDIFF(DAY, dbo.acccccxc.fecfac+dbo.acccccxc.venfac, @FechaFin)<0 THEN DATEDIFF(DAY, dbo.acccccxc.fecfac+dbo.acccccxc.venfac, @FechaFin)
					ELSE DATEDIFF(DAY, dbo.acccccxc.fecfac+dbo.acccccxc.venfac, @FechaFin)
				END                                     AS Vencido
				,acccccxc.iva * TCambio                    AS iva
				,clientes.CliNit
				,ACCCCCXC.ExcepcionDeterioro
				,ACCGLTER.TERCOD
				,isnull(ClC.ClCTasa,0) as ClCTasa
				,isnull(ClC.ClCDias,0) as ClCDias
				,CASE
					WHEN (ACCCCCXC.Estado=0 AND
					ACCCCCXC.Cancelada=0) THEN 'PENDIENTE'
					WHEN (ACCCCCXC.Estado=0 AND
					ACCCCCXC.Cancelada=1) THEN 'CANCELADA'
					WHEN (ACCCCCXC.Estado=1 AND
					ACCCCCXC.Cancelada=1) THEN 'ANULADA'
				END                                     AS ESTADO2
				,ACCCCCXC.TCambio
				,ACCCCCXC.TipoCli
				,ACCCCCXC.VlrDeterioro * TCambio           AS Deterioro
				,''                                      AS Bandera
				,NomPais                                 AS Pais
				,ciunom                                  AS Ciudad
				,CAST(0 AS BIT)                          AS Sel
				,Titular.CliNom							 As NomTitular
				,IsNull(Protipomoneda.Codigo,'COP')		 As TipoMoneda
				,ACCCCCXC.dependencia
				,ciucod									 AS CodigoCiudad
		INTO	#CxcAnalisis
		FROM	ACCCCCXC
				INNER JOIN TIPOCLIENTE ON acccccxc.clitipo=tipocliente.tipcod
				INNER JOIN CLIENTES ON CLICOD=CODCLI
				LEFT JOIN CLIENTES As Titular ON Titular.CLICOD = acccccxc.CodCodeudor2
				INNER JOIN ACCGLTER ON TERNIT=CLIENTES.CLINIT
				LEFT JOIN CalificacionClientes ClC ON ClC.ClCCodigo=CLIENTES.ContCalificacion
				LEFT JOIN VENDEDORES ON VENCOD=ACCCCCXC.VENDEDOR
				LEFT JOIN dbo.ProZona ON dbo.ProZona.CodZona=dbo.clientes.clicontac2
				LEFT JOIN dbo.proPaises ON CLIENTES.cliPais=dbo.proPaises.CodPais
				LEFT JOIN dbo.prociudades ON CLIENTES.cliCodCiud=dbo.prociudades.ciucod
				LEFT JOIN Protipomoneda On Acccccxc.cxcTipMon = Protipomoneda.Codigo
				LEFT JOIN #RecibosTmp AS R ON RTRIM(LTRIM(R.RECFAC))+RTRIM(LTRIM(R.RECTIP))=RTRIM(LTRIM(NROFAC))+RTRIM(LTRIM(TIPODOC))
		WHERE	dbo.acccccxc.TipoDoc IN ('FR', 'DB', 'CC')
				AND dbo.acccccxc.FecFac <= @FechaFin
				AND CASE
					WHEN @Todo=1 THEN acccccxc.saldo
					ELSE ((ISNULL(dbo.acccccxc.VLRFAC, 0)-ISNULL(R.Abono, 0)))
					END > 0


		SET @tipo=@rangoDias
		SET @lim1=10*(CASE @tipo
			WHEN 0 THEN 1
			WHEN 1 THEN 2
			WHEN 2 THEN 3
			WHEN 3 THEN 6
			ELSE 12
		END)

		SET @lim2=@lim1*2
		SET @lim3=@lim1*3

		IF @tipo=5
		BEGIN
			SET @lim1=90;
			SET @lim2=180;
			SET @lim3=360
		END

		SELECT	LTRIM(RTRIM(nombres))                                      AS Cliente
				,Calificacion                                              AS Calificacion
				,tipodoc                                                   AS Tipo
				,nrofac                                                    AS Documento
				,fecfac                                                    AS Fecha
				,venfac                                                    AS Vence
				,Vencido                                                   AS DiasVen
				,Valor                                                     AS Valor
				,ISNULL(CONVERT(VARCHAR(10), #SEGUI.FechaPago, 103), '//') AS PagoConf
				,CASE WHEN Vencido <= 0 THEN saldo ELSE 0 END AS NoVen
				,CASE WHEN (SELECT entre FROM comboCarteraDet WHERE indice= @tipo AND columna=1 ) <= Vencido AND 
							Vencido <= (SELECT hasta FROM comboCarteraDet WHERE indice=@tipo AND columna=1) THEN saldo
					  ELSE 0 END AS Rango1
				,CASE WHEN @tipo = 0 Then
					 CASE WHEN Vencido > (SELECT entre FROM comboCarteraDet WHERE indice=@tipo AND columna=2 ) THEN saldo
						  ELSE 0 END
				 ELSE
					 CASE WHEN (SELECT entre FROM comboCarteraDet WHERE indice=@tipo AND columna=2 ) <= Vencido AND
								Vencido <= (SELECT hasta FROM comboCarteraDet WHERE indice = @tipo AND columna = 2) THEN saldo
						  ELSE 0 END END AS Rango2
				,CASE WHEN @tipo=1 THEN
					 CASE WHEN Vencido > (SELECT entre FROM comboCarteraDet WHERE indice=@tipo AND columna=3) THEN saldo
						  ELSE 0 END 
				 ELSE		  
					 CASE WHEN (SELECT entre FROM comboCarteraDet WHERE indice=@tipo AND columna=3 ) <= Vencido AND
								Vencido <= (SELECT hasta FROM comboCarteraDet WHERE indice=@tipo AND columna=3 ) THEN saldo
						  ELSE 0 END END AS Rango3
				,CASE WHEN @tipo=2 or @tipo=3 or @tipo=4 or @tipo=5 then
					 CASE WHEN Vencido>(SELECT entre FROM comboCarteraDet WHERE indice=@tipo AND columna=4 ) THEN saldo
						  ELSE 0 END 
				 ELSE
					 CASE WHEN (SELECT entre FROM comboCarteraDet WHERE indice=@tipo AND columna=4) <= Vencido AND
								Vencido <= (SELECT hasta FROM comboCarteraDet WHERE indice=@tipo AND columna=4 ) THEN saldo
						  ELSE 0 END END AS Rango4


				,CASE WHEN Vencido <= 0 THEN (saldo * TCambio) ELSE 0 END AS NoVenTcrm 

				,CASE WHEN (SELECT entre FROM comboCarteraDet WHERE indice= @tipo AND columna=1 ) <= Vencido AND 
							Vencido <= (SELECT hasta FROM comboCarteraDet WHERE indice=@tipo AND columna=1) THEN saldo  
					  ELSE 0 END AS rango1Tcrm

				,CASE WHEN @tipo = 0 Then
					 CASE WHEN Vencido > (SELECT entre FROM comboCarteraDet WHERE indice=@tipo AND columna=2 ) THEN saldo
						  ELSE 0 END
				 ELSE
					 CASE WHEN (SELECT entre FROM comboCarteraDet WHERE indice=@tipo AND columna=2 ) <= Vencido AND
								Vencido <= (SELECT hasta FROM comboCarteraDet WHERE indice = @tipo AND columna = 2) THEN saldo
						  ELSE 0 END END AS rango2Tcrm

				,CASE WHEN @tipo=1 THEN
					 CASE WHEN Vencido > (SELECT entre FROM comboCarteraDet WHERE indice=@tipo AND columna=3) THEN saldo 
						  ELSE 0 END 
				 ELSE		  
					 CASE WHEN (SELECT entre FROM comboCarteraDet WHERE indice=@tipo AND columna=3 ) <= Vencido AND
								Vencido <= (SELECT hasta FROM comboCarteraDet WHERE indice=@tipo AND columna=3 ) THEN saldo
						  ELSE 0 END END AS rango3Tcrm

				,CASE WHEN @tipo=2 or @tipo=3 or @tipo=4 or @tipo=5 then
					 CASE WHEN Vencido>(SELECT entre FROM comboCarteraDet WHERE indice=@tipo AND columna=4 ) THEN saldo
						  ELSE 0 END 
				 ELSE
					 CASE WHEN (SELECT entre FROM comboCarteraDet WHERE indice=@tipo AND columna=4) <= Vencido AND
								Vencido <= (SELECT hasta FROM comboCarteraDet WHERE indice=@tipo AND columna=4 ) THEN saldo
						  ELSE 0 END END AS rango4Tcrm
				, 0 AS rango5Tcrm
				,0 AS rango6Tcrm
				,iva                                                       AS ValorIva
				,vennom                                                    AS Vendedor
				,Nomzona                                                   AS Zona
				,CliNit                                                    AS Nit
				,CliDir                                                    AS DireccionCliente
				,CliTel                                                    AS TelCliente
				,DiasFact                                                  AS DiasFac
				,SubTotal                                                  AS SubTotal          
				,SALDO														AS Saldo
				,ExcepcionDeterioro
				,ISNULL(TERCOD, '')                                        AS TERCOD
				,isnull(ClCTasa,0) ClCTasa
				,isnull(ClCDias,0) ClCDias
				,TCambio
				,GLNUM                                                     AS TipoCli
				,Deterioro                                                 AS Deterioro
				,Bandera
				-->			    
				,CASE WHEN Vencido <= 0 THEN saldo ELSE 0 END AS NoVenORI
				,CASE WHEN (SELECT entre FROM comboCarteraDet WHERE indice= @tipo AND columna=1 ) <= Vencido AND 
							Vencido <= (SELECT hasta FROM comboCarteraDet WHERE indice=@tipo AND columna=1) THEN saldo
					  ELSE 0 END AS Rango1ORI
				,CASE WHEN @tipo = 0 Then
					 CASE WHEN Vencido > (SELECT entre FROM comboCarteraDet WHERE indice=@tipo AND columna=2 ) THEN saldo
						  ELSE 0 END
				 ELSE
					 CASE WHEN (SELECT entre FROM comboCarteraDet WHERE indice=@tipo AND columna=2 ) <= Vencido AND
								Vencido <= (SELECT hasta FROM comboCarteraDet WHERE indice = @tipo AND columna = 2) THEN saldo
						  ELSE 0 END END AS Rango2ORI
				,CASE WHEN @tipo=1 THEN
					 CASE WHEN Vencido > (SELECT entre FROM comboCarteraDet WHERE indice=@tipo AND columna=3) THEN saldo
						  ELSE 0 END 
				 ELSE		  
					 CASE WHEN (SELECT entre FROM comboCarteraDet WHERE indice=@tipo AND columna=3 ) <= Vencido AND
								Vencido <= (SELECT hasta FROM comboCarteraDet WHERE indice=@tipo AND columna=3 ) THEN saldo
						  ELSE 0 END END AS Rango3ORI
				,CASE WHEN @tipo=2 or @tipo=3 or @tipo=4 or @tipo=5 then
					 CASE WHEN Vencido>(SELECT entre FROM comboCarteraDet WHERE indice=@tipo AND columna=4 ) THEN saldo
						  ELSE 0 END 
				 ELSE
					 CASE WHEN (SELECT entre FROM comboCarteraDet WHERE indice=@tipo AND columna=4) <= Vencido AND
								Vencido <= (SELECT hasta FROM comboCarteraDet WHERE indice=@tipo AND columna=4 ) THEN saldo
						  ELSE 0 END END AS Rango4ORI
				,CASE	WHEN	(SELECT entre FROM comboCarteraDet WHERE indice = @tipo AND columna = 5 ) <= Vencido AND
								vencido <= (SELECT hasta FROM comboCarteraDet WHERE indice = @tipo AND columna = 5 ) THEN saldo
						ELSE 0 END AS Rango5ORI
				,CASE	WHEN	(SELECT entre FROM comboCarteraDet WHERE indice = @tipo AND columna = 6 ) <= Vencido THEN saldo
						ELSE 0 END AS Rango6ORI
				,iva                                                       AS ValorIvaORI
				,SubTotal                                                  AS SubTotalORI
				,Valor                                                     AS ValorORI
				,SALDO														AS SaldoORI
				,Deterioro                                                 AS DeterioroORI
				,Sel
				,CodCli
				,ESTADO2                                                   AS EstadoFactura
				,Pais                                                      AS Pais
				,Ciudad
				,ISNULL(NomTitular,'')											AS NomTitular
				,TipoMoneda
				,dependencia
				,depnom		
				,CodigoCiudad
				,codcli AS CodigoCliente
				,clinit AS  NitCliente
				,Vencido AS Venced
		INTO #TMPCARTERA FROM	#CxcAnalisis
				LEFT JOIN (SELECT	#SEG.nCotizacion
									,seg_cotizaciones.FechaPago
									,seg_cotizaciones.Seguimiento
							FROM	(	SELECT	nCotizacion
												,MAX(nId) AS nId
										FROM	seg_cotizaciones
										WHERE	tipoSeg = 'FAC'
										GROUP BY nCotizacion ) AS #SEG
									LEFT JOIN seg_cotizaciones ON #SEG.nId = seg_cotizaciones.nId) AS #SEGUI ON #SEGUI.nCotizacion=#CxcAnalisis.nrofac
									LEFT JOIN proDepende AS dep ON depcod = dependencia
				LEFT JOIN ACCGLPUC ON ACCGLPUC.GLCOD = #CxcAnalisis.TipoCli
		ORDER BY Vencido ASC

		SELECT * FROM #TMPCARTERA WHERE Nit = CASE WHEN @clinit = '' THEN Nit ELSE @clinit END
		AND (Nit LIKE CASE WHEN @search = '' THEN Nit ELSE '%'+@search+'%' END OR Cliente LIKE CASE WHEN @search = '' THEN Cliente ELSE '%'+@search+'%' END OR
			 Documento LIKE CASE WHEN @search = '' THEN Documento ELSE '%'+@search+'%' END)
		ORDER BY Venced ASC

		DROP TABLE #CxcAnalisis
		DROP TABLE #TMPCARTERA

	END

    IF @Operacion='SCan' -- OK -> Operacion para Cargar las Canceladas
	BEGIN
		SELECT dbo.acccccxc.tipodoc
			  ,ISNULL(dbo.clientes.clinom, '')                 AS nombres
			  ,dbo.acccccxc.nrofac
			  ,dbo.acccccxc.vendedor
			  ,ISNULL(dbo.vendedores.vennom, '')               AS vennom
			  ,ISNULL(dbo.ProZona.NomZona, '')                 AS NomZona
			  ,ISNULL(clientes.CliTel, '')                     AS CliTel
			  ,dbo.acccccxc.fecfac+dbo.acccccxc.venfac         AS venfac
			  ,GETDATE()                                       AS fechaActual
			  ,ISNULL(clientes.CliDir, '')                     AS CliDir
			  ,dbo.acccccxc.fecfac
			  ,((ISNULL(VLRFAC, 0)-ISNULL(ABONOF, 0))*TCambio) AS vlrfac
			  ,dbo.acccccxc.codcli
			  ,dbo.acccccxc.clitipo
			  ,dbo.tipocliente.tipnom
			  ,CASE
				 WHEN ISNULL(LTRIM(RTRIM(acccccxc.Calificacion)), '')='' THEN 'SIN GESTION'
				 ELSE ISNULL(LTRIM(RTRIM(acccccxc.Calificacion)), '')
			   END                                             AS Calificacion
			  ,SubTotal*TCambio                                AS SubTotal
			  ,dbo.acccccxc.vlrfac*TCambio                     AS Valor
			  ,(acccccxc.saldo*TCambio)                        AS SALDO
			  ,ISNULL(dbo.acccccxc.FechaPago, '')              AS FechaPago
			  ,dbo.acccccxc.vlrfac                             AS valor1
			  ,dbo.acccccxc.vlrfac                             AS valor2
			  ,dbo.acccccxc.vlrfac                             AS valor3
			  ,dbo.acccccxc.vlrfac                             AS valor4
			  ,dbo.acccccxc.vlrfac                             AS valor5
			  ,CASE
				 WHEN UPPER(LTRIM(RTRIM(dbo.acccccxc.Calificacion))) IN ('', 'OBJETADO', 'PREJURIDICO') THEN 0
				 WHEN UPPER(LTRIM(RTRIM(dbo.acccccxc.Calificacion))) IN ('SIN GESTI�N', 'EN PROGRAMACI�N') THEN 1
				 WHEN UPPER(LTRIM(RTRIM(dbo.acccccxc.Calificacion))) IN ('CONFIRMADO') AND
				   YEAR(FechaPago)<>1900 THEN 2
			   END                                             AS Estado
			  ,CASE
				 WHEN DATEDIFF(DAY, dbo.acccccxc.fecfac, @FechaFin)<0 THEN DATEDIFF(DAY, dbo.acccccxc.fecfac, @FechaFin)
				 ELSE DATEDIFF(DAY, dbo.acccccxc.fecfac, @FechaFin)
			   END                                             AS DiasFact
			  ,CASE
				 WHEN DATEDIFF(DAY, dbo.acccccxc.fecfac+dbo.acccccxc.venfac, @FechaFin)<0 THEN DATEDIFF(DAY, dbo.acccccxc.fecfac+dbo.acccccxc.venfac, @FechaFin)
				 ELSE DATEDIFF(DAY, dbo.acccccxc.fecfac+dbo.acccccxc.venfac, @FechaFin)
			   END                                             AS Vencido
			  ,acccccxc.iva*TCambio                            AS iva
			  ,clientes.CliNit
			  ,ACCCCCXC.ExcepcionDeterioro
			  ,ACCGLTER.TERCOD
			  ,isnull(ClC.ClCTasa,0) as ClCTasa
			  ,isnull(ClC.ClCDias,0) as ClCDias
			  ,CASE
				 WHEN (ACCCCCXC.Estado=0 AND
				   ACCCCCXC.Cancelada=0) THEN 'PENDIENTE'
				 WHEN (ACCCCCXC.Estado=0 AND
				   ACCCCCXC.Cancelada=1) THEN 'CANCELADA'
				 WHEN (ACCCCCXC.Estado=1 AND
				   ACCCCCXC.Cancelada=1) THEN 'ANULADA'
			   END                                             AS ESTADO2
			  ,ACCCCCXC.TCambio
			  ,ACCCCCXC.TipoCli
			  ,ACCCCCXC.VlrDeterioro*TCambio                   AS Deterioro
			  ,''                                              AS Bandera
			  ,CAST(0 AS BIT)                                  AS Sel
			  ,NomPais                                         AS Pais
			  ,ciunom                                          AS Ciudad
			  ,Titular.CliNom							 As NomTitular
			  ,IsNull(Protipomoneda.Codigo,'COP')		 As TipoMoneda
		INTO #CxcAnalisisCan
		FROM ACCCCCXC
		LEFT JOIN TIPOCLIENTE
		  ON acccccxc.clitipo=tipocliente.tipcod
		LEFT JOIN CLIENTES
		  ON CLICOD=CODCLI
		  LEFT JOIN CLIENTES As Titular ON Titular.CLICOD = acccccxc.CodCodeudor2
		LEFT JOIN ACCGLTER
		  ON TERNIT=CLIENTES.CLINIT
		LEFT JOIN CalificacionClientes ClC
		  ON ClC.ClCCodigo=CLIENTES.ContCalificacion
		LEFT JOIN VENDEDORES
		  ON VENCOD=ACCCCCXC.VENDEDOR
		LEFT JOIN dbo.ProZona
		  ON dbo.ProZona.CodZona=dbo.clientes.clicontac2
		LEFT JOIN dbo.proPaises
		  ON CLIENTES.cliPais=dbo.proPaises.CodPais
		LEFT JOIN dbo.prociudades
		  ON CLIENTES.cliCodCiud=dbo.prociudades.ciucod
		LEFT JOIN Protipomoneda On Acccccxc.cxcTipMon = Protipomoneda.Codigo
		WHERE TIPODOC IN ('FR', 'DB', 'CC')
		  AND FECFAC BETWEEN @FechaIni AND @FechaFin
		  AND (acccccxc.ESTADO=0
			AND ACCCCCXC.Cancelada=1)

		SET @tipo=@rangoDias
		SET @lim1=10*(CASE @tipo
		  WHEN 0 THEN 1
		  WHEN 1 THEN 2
		  WHEN 2 THEN 3
		  WHEN 3 THEN 6
		  ELSE 12
		END)
		SET @lim2=@lim1*2
		SET @lim3=@lim1*3

		IF @tipo=5
		BEGIN
		  SET @lim1=90;
		  SET @lim2=180;
		  SET @lim3=360
		END

		SELECT LTRIM(RTRIM(nombres))                                     AS Cliente
			  ,Calificacion                                              AS Calificacion
			  ,tipodoc                                                   AS Tipo
			  ,nrofac                                                    AS Documento
			  ,fecfac                                                    AS Fecha
			  ,venfac                                                    AS Vence
			  ,Vencido                                                   AS DiasVen
			  ,ISNULL(CONVERT(VARCHAR(10), #SEGUI.FechaPago, 103), '//') AS PagoConf
			  ,CASE 
				 WHEN Vencido <= 0 THEN saldo
				 ELSE 0
			   END                                                       AS NoVen
			  ,CASE
				 WHEN 0<Vencido AND
				   Vencido<=@lim1 THEN saldo
				 ELSE 0
			   END                                                       AS Rango1
			  ,CASE
				 WHEN @lim1<Vencido AND
				   Vencido<=@lim2 THEN saldo
				 ELSE 0
			   END                                                       AS Rango2
			  ,CASE
				 WHEN @lim2<Vencido AND
				   Vencido<=@lim3 THEN saldo
				 ELSE 0
			   END                                                       AS Rango3
			  ,CASE
				 WHEN @lim3<Vencido THEN saldo
				 ELSE 0
			   END                                                       AS Rango4
			   ,CASE WHEN Vencido <= 0 THEN (saldo * TCambio) ELSE 0 END AS NoVenTcrm 

					,CASE WHEN (SELECT entre FROM comboCarteraDet WHERE indice= @tipo AND columna=1 ) <= Vencido AND 
								Vencido <= (SELECT hasta FROM comboCarteraDet WHERE indice=@tipo AND columna=1) THEN (saldo * TCambio) 
						  ELSE 0 END AS rango1Tcrm

					,CASE WHEN @tipo = 0 Then
						 CASE WHEN Vencido > (SELECT entre FROM comboCarteraDet WHERE indice=@tipo AND columna=2 ) THEN (saldo * TCambio) 
							  ELSE 0 END
					 ELSE
						 CASE WHEN (SELECT entre FROM comboCarteraDet WHERE indice=@tipo AND columna=2 ) <= Vencido AND
									Vencido <= (SELECT hasta FROM comboCarteraDet WHERE indice = @tipo AND columna = 2) THEN (saldo * TCambio) 
							  ELSE 0 END END AS rango2Tcrm

					,CASE WHEN @tipo=1 THEN
						 CASE WHEN Vencido > (SELECT entre FROM comboCarteraDet WHERE indice=@tipo AND columna=3) THEN (saldo * TCambio) 
							  ELSE 0 END 
					 ELSE		  
						 CASE WHEN (SELECT entre FROM comboCarteraDet WHERE indice=@tipo AND columna=3 ) <= Vencido AND
									Vencido <= (SELECT hasta FROM comboCarteraDet WHERE indice=@tipo AND columna=3 ) THEN (saldo * TCambio) 
							  ELSE 0 END END AS rango3Tcrm

					,CASE WHEN @tipo=2 or @tipo=3 or @tipo=4 or @tipo=5 then
						 CASE WHEN Vencido>(SELECT entre FROM comboCarteraDet WHERE indice=@tipo AND columna=4 ) THEN (saldo * TCambio) 
							  ELSE 0 END 
					 ELSE
						 CASE WHEN (SELECT entre FROM comboCarteraDet WHERE indice=@tipo AND columna=4) <= Vencido AND
									Vencido <= (SELECT hasta FROM comboCarteraDet WHERE indice=@tipo AND columna=4 ) THEN (saldo * TCambio) 
							  ELSE 0 END END AS rango4Tcrm
					, 0 AS rango5Tcrm
					,0 AS rango6Tcrm
			  ,iva                                                       AS ValorIva
			  ,vennom                                                    AS Vendedor
			  ,Nomzona                                                   AS Zona
			  ,CliNit                                                    AS Nit
			  ,CliDir                                                    AS DireccionCliente
			  ,CliTel                                                    AS TelCliente
			  ,DiasFact                                                  AS DiasFac
			  ,SubTotal                                                  AS SubTotal
			  ,Valor                                                     AS Valor
			  ,(SALDO*TCambio)                                           AS Saldo
			  ,ExcepcionDeterioro
			  ,ISNULL(TERCOD, '')                                        AS TERCOD
			  ,ClCTasa
			  ,ClCDias
			  ,TCambio
			  ,GLNUM                                                     AS TipoCli
			  ,Deterioro                                                 AS Deterioro
			  ,Bandera
			   -->			    
			  ,CASE 
				 WHEN Vencido <= 0 THEN saldo
				 ELSE 0
			   END                                                       AS NoVenORI
			  ,CASE
				 WHEN 0<Vencido AND
				   Vencido<=@lim1 THEN saldo
				 ELSE 0
			   END                                                       AS Rango1ORI
			  ,CASE
				 WHEN @lim1<Vencido AND
				   Vencido<=@lim2 THEN saldo
				 ELSE 0
			   END                                                       AS Rango2ORI
			  ,CASE
				 WHEN @lim2<Vencido AND
				   Vencido<=@lim3 THEN saldo
				 ELSE 0
			   END                                                       AS Rango3ORI
			  ,CASE
				 WHEN @lim3<Vencido THEN saldo
				 ELSE 0
			   END                                                       AS Rango4ORI
			   ,CASE	WHEN	(SELECT entre FROM comboCarteraDet WHERE indice = @tipo AND columna = 5 ) <= Vencido AND
									vencido <= (SELECT hasta FROM comboCarteraDet WHERE indice = @tipo AND columna = 5 ) THEN saldo
							ELSE 0 END AS Rango5ORI
					,CASE	WHEN	(SELECT entre FROM comboCarteraDet WHERE indice = @tipo AND columna = 6 ) <= Vencido THEN saldo
							ELSE 0 END AS Rango6ORI
			  ,iva                                                       AS ValorIvaORI
			  ,SubTotal                                                  AS SubTotalORI
			  ,Valor                                                     AS ValorORI
			  ,(SALDO*TCambio)                                           AS SaldoORI
			  ,Deterioro                                                 AS DeterioroORI
			  ,Sel
			  ,CodCli
			  ,ESTADO2                                                   AS EstadoFactura
			  ,Pais
			  ,Ciudad
			  ,ISNULL(NomTitular,'')									 AS NomTitular
			 , TipoMoneda
		INTO #TMPCARTERA2 FROM #CxcAnalisisCan
		LEFT JOIN (SELECT #SEG.nCotizacion
						 ,seg_cotizaciones.FechaPago
						 ,seg_cotizaciones.Seguimiento
		  FROM (SELECT nCotizacion
					  ,MAX(nId) AS nId
			FROM seg_cotizaciones
			WHERE tipoSeg='FAC'
			GROUP BY nCotizacion
		  ) AS #SEG
		  LEFT JOIN seg_cotizaciones
			ON #SEG.nId=seg_cotizaciones.nId
		) AS #SEGUI
		  ON #SEGUI.nCotizacion=#CxcAnalisisCan.nrofac
		LEFT JOIN ACCGLPUC
		  ON ACCGLPUC.GLCOD=#CxcAnalisisCan.TipoCli
		ORDER BY Vencido ASC

		SELECT * FROM #TMPCARTERA2 WHERE Nit = CASE WHEN @clinit = '' THEN Nit ELSE @clinit END
		AND (Nit LIKE CASE WHEN @search = '' THEN Nit ELSE '%'+@search+'%' END OR Cliente LIKE CASE WHEN @search = '' THEN Cliente ELSE '%'+@search+'%' END OR
			 Documento LIKE CASE WHEN @search = '' THEN Documento ELSE '%'+@search+'%' END)

		DROP TABLE #CxcAnalisisCan
		DROP TABLE #TMPCARTERA2
	  END

	IF @Operacion='FICHA_FACTURA'
	BEGIN

		IF @TipoFac='DB'
		BEGIN
			SELECT DISTINCT dbo.acccccxc.nrofac                              AS nFactura
							,dbo.acccccxc.fecfac                              AS Fecha
							,(dbo.acccccxc.fecfac+dbo.acccccxc.venfac)        AS FechaVenci
							,(dbo.acccccxc.abonof*dbo.acccccxc.tcambio)       AS abono
							,CAST(dbo.acccccxc.detalle AS VARCHAR(250))       AS detalle
							,'DEBITO'                                         AS Tipo
							,dbo.acccccxc.tipodoc                             AS Tipdoc
							,dbo.acccccxc.codcli                              AS cliente
							,dbo.acccccxc.subtotal+dbo.acccccxc.vlrdescuento  AS subIva
							,dbo.acccccxc.iva                                 AS Iva
							,dbo.acccccxc.descuento+dbo.acccccxc.vlrdescuento AS vDesc
							,0                                                AS vrCredito
							,(dbo.acccccxc.vlrfac*dbo.acccccxc.tcambio)       AS total
							,dbo.acccccxc.devolucion                          AS nDevoluciones
							,dbo.acccccxc.ccdeviva                            AS nIvaDev
							,(dbo.acccccxc.saldo*dbo.acccccxc.tcambio)        AS saldo
							,''                                               AS Cajero
							,dbo.acccccxc.vendedor                            AS Vendedor
							,ISNULL(ProZona_1.nomzona, '')                    AS Zona
							,ISNULL(prociudades_1.ciunom, '')                 AS ciudad
							,CASE
							WHEN dbo.acccccxc.estado=0 AND
								dbo.acccccxc.cancelada=0 THEN 'PENDIENTE'
							WHEN dbo.acccccxc.estado=0 AND
								dbo.acccccxc.cancelada=1 THEN 'CANCELADA'
							WHEN dbo.acccccxc.estado=1 AND
								dbo.acccccxc.cancelada=1 THEN 'ANULADA'
							END                                              AS estado
							,LTRIM(RTRIM(dbo.acccccxc.nrofac))+'DB'           AS llave
							,acccccxc.Estacion
							,acccccxc.user_save                               AS Usuario
							,acccccxc.tcambio                                 AS TCambio
							,acccccxc.cxcTipMon                               AS TMoneda
			FROM dbo.acccccxc
			LEFT OUTER JOIN dbo.clientes AS clientes_1
			ON dbo.acccccxc.codcli=clientes_1.clicod
			LEFT OUTER JOIN dbo.vendedores AS vendedores_1
			ON dbo.acccccxc.vendedor=vendedores_1.vencod
			LEFT OUTER JOIN dbo.prociudades AS prociudades_1
			ON prociudades_1.ciucod=clientes_1.clicodciud
			LEFT OUTER JOIN dbo.prozona AS ProZona_1
			ON ProZona_1.codzona=clientes_1.clicontac2
			LEFT OUTER JOIN dbo.prodepende AS prodepende_1
			ON dbo.acccccxc.dependencia=prodepende_1.depcod
			WHERE dbo.acccccxc.tipodoc='DB'
			AND dbo.acccccxc.nrofac=@Factura
		END
		ELSE
		BEGIN
			SELECT DISTINCT dbo.acccccxc.nrofac                              AS nFactura
							,dbo.acccccxc.fecfac                              AS Fecha
							,(dbo.acccccxc.fecfac+dbo.acccccxc.venfac)        AS FechaVenci
							,(dbo.acccccxc.abonof*dbo.acccccxc.tcambio)       AS abono
							,CAST(dbo.acccccxc.detalle AS VARCHAR(250))       AS detalle
							,'CREDITO'                                        AS Tipo
							,dbo.acccccxc.tipodoc                             AS Tipdoc
							,dbo.acccccxc.codcli                              AS cliente
							,dbo.acccccxc.subtotal+dbo.acccccxc.vlrdescuento  AS subIva
							,dbo.acccccxc.iva                                 AS Iva
							,dbo.acccccxc.descuento+dbo.acccccxc.vlrdescuento AS vDesc
							,0                                                AS vrCredito
							,(dbo.acccccxc.vlrfac*dbo.acccccxc.tcambio)       AS total
							,dbo.acccccxc.devolucion                          AS nDevoluciones
							,dbo.acccccxc.ccdeviva                            AS nIvaDev
							,(dbo.acccccxc.saldo*dbo.acccccxc.tcambio)        AS saldo
							,''                                               AS Cajero
							,dbo.acccccxc.vendedor                            AS Vendedor
							,ISNULL(ProZona_1.nomzona, '')                    AS Zona
							,ISNULL(prociudades_1.ciunom, '')                 AS ciudad
							,CASE
							WHEN dbo.acccccxc.estado=0 AND
								dbo.acccccxc.cancelada=0 THEN 'PENDIENTE'
							WHEN dbo.acccccxc.estado=0 AND
								dbo.acccccxc.cancelada=1 THEN 'CANCELADA'
							WHEN dbo.acccccxc.estado=1 AND
								dbo.acccccxc.cancelada=1 THEN 'ANULADA'
							END                                              AS estado
							,LTRIM(RTRIM(dbo.acccccxc.nrofac))+'FR'           AS llave
							,acccccxc.Estacion
							,acccccxc.user_save                               AS Usuario
							,acccccxc.tcambio                                 AS TCambio
							,acccccxc.cxcTipMon                               AS TMoneda
			FROM dbo.acccccxc
			LEFT OUTER JOIN dbo.clientes AS clientes_1
			ON dbo.acccccxc.codcli=clientes_1.clicod
			LEFT OUTER JOIN dbo.vendedores AS vendedores_1
			ON dbo.acccccxc.vendedor=vendedores_1.vencod
			LEFT OUTER JOIN dbo.prociudades AS prociudades_1
			ON prociudades_1.ciucod=clientes_1.clicodciud
			LEFT OUTER JOIN dbo.prozona AS ProZona_1
			ON ProZona_1.codzona=clientes_1.clicontac2
			LEFT OUTER JOIN dbo.prodepende AS prodepende_1
			ON dbo.acccccxc.dependencia=prodepende_1.depcod
			WHERE (dbo.acccccxc.tipodoc IN ('FR', 'CC', 'FC'))
			AND dbo.acccccxc.nrofac=@Factura
		END

	END

	IF @Operacion='PAGOS'
	BEGIN
		SELECT	recNro
				,TipPag
				,recFec
				,recVlr
				,banNom
				,recchk
				,recbchk
				,recrtFte
				,recrtcree
				,recrtIca
				,recrtIva
				,recdescto
				,CAST(CASE WHEN recEST = 1 THEN 1 ELSE 0 END AS BIT) AS recEST
				
		FROM	Recibos
				LEFT JOIN Bancos ON recbco=bancod
		WHERE	recFac=@Factura 
				AND RecTip=@TipoFac
		Order By RecFec
	END

	IF @Operacion = 'GET_RECAUDO'
	BEGIN
		
		DECLARE @Meses TABLE (Mes INT);
		INSERT INTO @Meses (Mes)
		VALUES (1), (2), (3), (4), (5), (6), (7), (8), (9), (10), (11), (12);

		SELECT SUM(RecVlr)   AS AbonoFactura
          ,MONTH(RecFec) AS MesFechaDoc
		INTO #CARTERA 
		FROM Recibos
		WHERE YEAR(RECIBOS.RECFEC)=(@FechaFin)
		  AND recest=0
		  AND (TipPag IN ('RC', 'CN')
			OR LEFT(RECNRO, 6)='Cruce-'
			OR LEFT(RECNRO, 3)='NC-'
			OR LEFT(RECNRO, 4)='ANT-')
		GROUP BY MONTH(RecFec)

		INSERT INTO #CARTERA (AbonoFactura,MesFechaDoc)
		SELECT 0,Mes FROM @Meses WHERE Mes NOT IN (SELECT MesFechaDoc FROM #CARTERA)

		SELECT MesFechaDoc, AbonoFactura FROM #CARTERA

		DROP TABLE  #CARTERA

	END

	IF @Operacion = 'GET_CARTERA'
	BEGIN

		DECLARE @Saldos TABLE (Mes INT,Saldo NUMERIC(18,4));

		SELECT
			CONVERT(VARCHAR,EOMONTH(CAST((CAST(@FechaFin AS VARCHAR(4))+ Mes +'01') AS date)),112) AS UltimaFechaDelMes
		INTO #LASTDAYOFMONTH 
		FROM
			(SELECT '01' AS Mes UNION SELECT '02' UNION SELECT '03' UNION SELECT '04' UNION SELECT '05' UNION SELECT '06' UNION
			 SELECT '07' UNION SELECT '08' UNION SELECT '09' UNION SELECT '10' UNION SELECT '11' UNION SELECT '12') Meses

		

		DECLARE @FechaSaldo DATE
		DECLARE @SaldoMes NUMERIC(18,4);

		DECLARE qSaldo CURSOR FOR
			SELECT UltimaFechaDelMes
			FROM #LASTDAYOFMONTH

		OPEN qSaldo;

		FETCH NEXT FROM qSaldo INTO @FechaSaldo

		WHILE @@FETCH_STATUS = 0
		BEGIN

			SET @SaldoMes = (SELECT	ISNULL(SUM(((ISNULL(VLRFAC,0)-ISNULL(ABONO,0)) * TCambio)),0) As Saldo 
			FROM ACCCCCXC WITH(NOLOCK)
			LEFT JOIN(
						SELECT  RECFAC, RECTIP, ISNULL(SUM(RECVLR + RECRTIVA + RECRTICA + RECRTFTE + RECRTCREE + RECDESCTO), 0) AS ABONO
						FROM RECIBOS WITH(NOLOCK) WHERE CAST(RECFEC AS DATE) <= @FechaSaldo AND RECEST = 0 
						GROUP BY RECFAC, RECTIP)  AS R  ON RTRIM(LTRIM(R.RECFAC)) + RTRIM(LTRIM(R.RECTIP)) = RTRIM(LTRIM(NROFAC)) + RTRIM(LTRIM(TIPODOC)
					  )
			WHERE TIPODOC IN('FR', 'DB', 'CC') AND CAST(FECFAC AS DATE) BETWEEN '' AND @FechaSaldo)

			INSERT INTO @Saldos (Mes,Saldo)
			VALUES(MONTH(@FechaSaldo),@SaldoMes)

			FETCH NEXT FROM qSaldo INTO @FechaSaldo
		END

		CLOSE qSaldo;
		DEALLOCATE qSaldo;

		SELECT Mes AS MesFechaDoc,Saldo AS AbonoFactura FROM @Saldos

	END

END
GO

IF OBJECT_ID(N'dbo.WEBGLSS_SP_PQRSF') IS NULL
BEGIN
    PRINT 'Create procedure : dbo.WEBGLSS_SP_PQRSF'
    EXECUTE('CREATE PROCEDURE dbo.WEBGLSS_SP_PQRSF AS RETURN 0') 
END
GO

PRINT 'Alter procedure : dbo.WEBGLSS_SP_PQRSF'
GO

ALTER PROCEDURE [dbo].[WEBGLSS_SP_PQRSF] 
    @Operacion		VARCHAR(20) = '',
	@NitEmpresa		VARCHAR(20) = '',
	@Fecha			DATETIME = '19000101',
	@IdSituacion	INT = 0,
	@NroIdeCli		VARCHAR(20) = '',
	@IdContacto		INT = 0,
	@IdPqrsf		INT = 0,
	@Asunto			VARCHAR(60) = '',
	@Descripcion	VARCHAR(8000) = '',
	@CodigoAgente	VARCHAR(20) = '',
	@FechaConsulta  DATE		= '19000101',
	@Mes			VARCHAR(2) = 0, 
	@Anio			VARCHAR(4) = 0,
	@FechaIniC		VARCHAR(8) = 0,
	@FechaFinC		VARCHAR(8) = 0,
	@Agente			VARCHAR(20) = 0,
	@Area			VARCHAR(4) = 0,
	@Tipo			VARCHAR(4) = 0,
	@Estado			VARCHAR(4) = 0,
	@Prioridad		VARCHAR(4) = 0,
	@Cliente		VARCHAR(20) = 0,
	@Search			VARCHAR(MAX) = 0,
	@TipoPeticion			VARCHAR(20) = ''
AS
BEGIN
	
	DECLARE @FechaAux VARCHAR(8) = ''

	IF @Operacion = 'SAVE_PQRSF'
	BEGIN
		
		SET @Estado = '2'
		SET @Prioridad =  '5'
		SET @Area = '0000'

		INSERT INTO WEBGLSS_MatrizPQRSF (NitEmpresa,Fecha,FechaCierre,FechaCierreReal,Tipo,Asunto,Descripcion,Etiquetas,IdEstado,IdPrioridad,IdSituacion,IdProceso,IdContacto,NroIdeCli,NroIdResponsable,NroIdPerfilo,NroIdCerro,Perfilacion)
		VALUES(@NitEmpresa,@Fecha,GETDATE(),GETDATE(),@TipoPeticion,@Asunto,@Descripcion,NULL,2,5,@IdSituacion,@Area,@IdContacto,@NroIdeCli,'0000000000','0000000000','0000000000',0)

		DECLARE @IdPQ INT = SCOPE_IDENTITY()

		EXEC WEBGLSS_SP_PQRSF @Operacion = 'GET_PQRSF',  @IdPqrsf = @IdPQ

	END

	IF @Operacion = 'STATISTICS_A'
	BEGIN
		
		--COUNTER ESTADOS PQRSF
		SELECT 
		 Id AS Codigo,
		 CAST(Fecha AS DATE) AS Fecha,
		 CAST(FechaCierre AS DATE) AS FechaCierre,
		 CAST(FechaCierreReal AS DATE) AS FechaCierreAgente,
		 Perfilacion AS Perfilada,
		 NroIdResponsable AS AgenteResponsable,
		 NroIdCerro		  AS AgenteCierre,
		 CASE WHEN IdEstado = 1 THEN 'NUEVA' 
			  WHEN IdEstado = 2 THEN 'ABIERTA' 
			  WHEN IdEstado = 3 THEN 'PENDIENTE' 
			  WHEN IdEstado = 4 THEN 'GESTION' 
			  ELSE 'CERRADA' END AS Estado,
		CASE WHEN  IdSituacion = 1 THEN 'PETICION' 
			  WHEN IdSituacion = 2 THEN 'QUEJA' 
			  WHEN IdSituacion = 3 THEN 'RECLAMO' 
			  WHEN IdSituacion = 4 THEN 'SUGERENCIA' 
			  ELSE 'FELICITACION' END AS TipoPeticion,
		CASE WHEN  IdPrioridad = 1 THEN 'BAJA' 
			  WHEN IdPrioridad = 2 THEN 'MEDIA' 
			  WHEN IdPrioridad = 3 THEN 'ALTA' 
			  WHEN IdPrioridad = 4 THEN 'URGENTE' 
			  ELSE 'SINASIGNAR' END AS TipoPrioridad,
		 ISNULL(AR.nomare,'SINAREA')	AS Area
		FROM WEBGLSS_MatrizPQRSF PQ
		LEFT JOIN proareas AR ON PQ.IdProceso = AR.codare
		WHERE NroIdResponsable = @CodigoAgente
		
	END

	IF @Operacion = 'PQRSF_A_VS_H'
	BEGIN

		WITH HorasDelDia AS (
			SELECT 0 AS Hora
			UNION ALL
			SELECT Hora + 1
			FROM HorasDelDia
			WHERE Hora < 23
		),
		RegistrosPorHora AS (
			SELECT
				'HOY' AS Dia,
				DATEPART(HOUR, FechaCierreReal) AS HoraDelDia,
				COUNT(*) AS CantidadRegistros
			FROM WEBGLSS_MatrizPQRSF
			WHERE CAST(FechaCierreReal AS DATE) = @FechaConsulta AND NroIdCerro = @CodigoAgente
			GROUP BY DATEPART(HOUR, FechaCierreReal)
			UNION ALL
			SELECT
				'AYER' AS Dia,
				DATEPART(HOUR, FechaCierreReal) AS HoraDelDia,
				COUNT(*) AS CantidadRegistros
			FROM WEBGLSS_MatrizPQRSF
			WHERE CAST(FechaCierreReal AS DATE) = DATEADD(DAY,-1,@FechaConsulta) AND NroIdCerro = @CodigoAgente
			GROUP BY DATEPART(HOUR, FechaCierreReal)
		)

		SELECT 
			Dia,
			'H' + (REPLICATE('0', 2 - LEN(CAST(HoraDelDia AS VARCHAR(2)))) + CAST(HoraDelDia AS VARCHAR(2)) + '_00') AS HoraDelDia,
			CantidadRegistros
		INTO #TMPHOY FROM RegistrosPorHora

		SELECT * INTO #TMPFINAL FROM #TMPHOY
		PIVOT
		(
			SUM(CantidadRegistros)
			FOR HoraDelDia IN ([H00_00], [H01_00], [H02_00], [H03_00], [H04_00], [H05_00], [H06_00], [H07_00], [H08_00], [H09_00], [H10_00], [H11_00], [H12_00], [H13_00], [H14_00], [H15_00], [H16_00], [H17_00], [H18_00], [H19_00], [H20_00], [H21_00], [H22_00], [H23_00])
		) AS PivotTable;

		SELECT Dia,ISNULL([H00_00],0) AS [H00_00], ISNULL([H01_00],0) AS [H01_00], ISNULL([H02_00],0) AS [H02_00], ISNULL([H03_00],0) AS [H03_00], ISNULL([H04_00],0) AS [H04_00], ISNULL([H05_00],0) AS [H05_00]
				  ,ISNULL([H06_00],0) AS [H06_00], ISNULL([H07_00],0) AS [H07_00], ISNULL([H08_00],0) AS [H08_00], ISNULL([H09_00],0) AS [H09_00], ISNULL([H10_00],0) AS [H10_00], ISNULL([H11_00],0) AS [H11_00]
				  ,ISNULL([H12_00],0) AS [H12_00], ISNULL([H13_00],0) AS [H13_00], ISNULL([H14_00],0) AS [H14_00], ISNULL([H15_00],0) AS [H15_00], ISNULL([H16_00],0) AS [H16_00], ISNULL([H17_00],0) AS [H17_00]
				  ,ISNULL([H18_00],0) AS [H18_00], ISNULL([H19_00],0) AS [H19_00], ISNULL([H20_00],0) AS [H20_00], ISNULL([H21_00],0) AS [H21_00], ISNULL([H22_00],0) AS [H22_00], ISNULL([H23_00],0) AS [H23_00] 
		FROM #TMPFINAL

		DROP TABLE #TMPHOY
		DROP TABLE #TMPFINAL

	END
	
	IF @Operacion = 'PQRSF_PY_P_A'
	BEGIN
		
		SET @FechaAux = @Anio + REPLICATE('0',2 - LEN(@Mes)) + @Mes + '01'
		SELECT 
			 CAST(SUM(Asignadas) AS NUMERIC(18,2)) AS Asignadas
			,CAST(SUM(PromedioAsignadas) AS NUMERIC(18,2)) AS PromedioAsignadas
			,CAST(SUM(Resueltas) AS NUMERIC(18,2)) AS Resueltas
			,CAST(SUM(PromedioResueltas) AS NUMERIC(18,2)) AS PromedioResueltas
			,CAST(SUM(AsignadasPasado) AS NUMERIC(18,2)) AS AsignadasPasado
			,CAST(SUM(PromedioAsignadasPasado) AS NUMERIC(18,2)) AS PromedioAsignadasPasado
			,CAST(SUM(ResueltasPasado) AS NUMERIC(18,2)) AS ResueltasPasado
			,CAST(SUM(PromedioResueltasPasado) AS NUMERIC(18,2)) AS PromedioResueltasPasado
		FROM
		(
			SELECT
				 COUNT(*) AS Asignadas
				,CAST((CAST(COUNT(*) AS NUMERIC(18,2)) / CAST(DAY(EOMONTH(@FechaAux)) AS NUMERIC(18,2))) AS NUMERIC(18,3)) AS PromedioAsignadas
				,0 AS Resueltas			
				,0 AS PromedioResueltas
				,0 AS AsignadasPasado
				,0 AS PromedioAsignadasPasado
				,0 AS ResueltasPasado
				,0 AS PromedioResueltasPasado
			FROM WEBGLSS_MatrizPQRSF
			WHERE MONTH(Fecha) = @Mes AND YEAR(Fecha) = @Anio AND NroIdResponsable = @CodigoAgente
			UNION ALL
			SELECT
				 0 AS Asignadas
				,0 AS PromedioAsignadas
				,COUNT(*) AS Resueltas 
				,CAST((CAST(COUNT(*) AS NUMERIC(18,2)) / CAST(DAY(EOMONTH(@FechaAux)) AS NUMERIC(18,2))) AS NUMERIC(18,3)) AS PromedioResueltas
				,0 AS AsignadasPasado
				,0 AS PromedioAsignadasPasado
				,0 AS ResueltasPasado
				,0 AS PromedioResueltasPasado
			FROM WEBGLSS_MatrizPQRSF
			WHERE IdEstado = 5 AND MONTH(FechaCierreReal) = @Mes AND YEAR(FechaCierreReal) = @Anio AND NroIdCerro = @CodigoAgente

			UNION ALL

			SELECT
				 0 AS Asignadas
				,0 AS PromedioAsignadas
				,0 AS Resueltas			
				,0 AS PromedioResueltas
				,COUNT(*) AS AsignadasPasado
				,CAST((CAST(COUNT(*) AS NUMERIC(18,2)) / CAST(DAY(DATEADD(MONTH,-1,EOMONTH(@FechaAux))) AS NUMERIC(18,2))) AS NUMERIC(18,3)) AS PromedioAsignadasPasado
				,0 AS ResueltasPasado
				,0 AS PromedioResueltasPasado
			FROM WEBGLSS_MatrizPQRSF
			WHERE MONTH(Fecha) = CASE WHEN (CAST(@Mes AS INT) - 1) = 0 THEN '12' ELSE (CAST(@Mes AS INT) - 1) END 
				  AND YEAR(Fecha) = CASE WHEN (CAST(@Mes AS INT) - 1) = 0 THEN (CAST(@Anio AS INT) - 1) ELSE @Anio END AND NroIdResponsable = @CodigoAgente
			UNION ALL
			SELECT
				 0 AS Asignadas
				,0 AS PromedioAsignadas
				,0 AS Resueltas 
				,0 AS PromedioResueltas
				,0 AS AsignadasPasado
				,0 AS PromedioAsignadasPasado
				,COUNT(*) AS ResueltasPasado
				,CAST((CAST(COUNT(*) AS NUMERIC(18,2)) / CAST(DAY(DATEADD(MONTH,-1,EOMONTH(@FechaAux))) AS NUMERIC(18,2))) AS NUMERIC(18,3)) AS PromedioResueltasPasado
			FROM WEBGLSS_MatrizPQRSF
			WHERE IdEstado = 5 AND MONTH(FechaCierreReal) = CASE WHEN (CAST(@Mes AS INT) - 1) = 0 THEN '12' ELSE (CAST(@Mes AS INT) - 1) END 
				  AND YEAR(FechaCierreReal) = CASE WHEN (CAST(@Mes AS INT) - 1) = 0 THEN (CAST(@Anio AS INT) - 1) ELSE @Anio END AND NroIdCerro = @CodigoAgente
		) AS Datos 

	END

	IF @Operacion = 'PQRSF_BY_DAY_A'
	BEGIN
		
		SET @FechaAux = @Anio + REPLICATE('0',2 - LEN(@Mes)) + @Mes + '01'

		SELECT *
		INTO #TMPASSIGNED
		FROM 
			(
			  SELECT 'D'+CAST(DAY(fecha) AS VARCHAR) AS Dia, ISNULL(COUNT(*),0) AS CantidadRegistros
			  FROM WEBGLSS_MatrizPQRSF
			  WHERE MONTH(fecha) = MONTH(@FechaAux) AND YEAR(fecha) =  YEAR(@FechaAux) AND NroIdResponsable = @CodigoAgente
			  GROUP BY DAY(fecha)
			) AS RegistrosPorDia
			PIVOT 
			(
			  MAX(CantidadRegistros)
			  FOR Dia IN ([D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31])
			) AS PivotTable;

		SELECT *
		INTO #TMPRESOLVED
		FROM 
			(
			  SELECT 'D'+CAST(DAY(FechaCierreReal) AS VARCHAR) AS Dia, ISNULL(COUNT(*),0) AS CantidadRegistros
			  FROM WEBGLSS_MatrizPQRSF
			  WHERE MONTH(FechaCierreReal) = MONTH(@FechaAux) AND YEAR(FechaCierreReal) = YEAR(@FechaAux) AND IdEstado = 5  AND NroIdCerro = @CodigoAgente
			  GROUP BY DAY(FechaCierreReal)
			) AS RegistrosPorDia
			PIVOT 
			(
			  MAX(CantidadRegistros)
			  FOR Dia IN ([D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31])
			) AS PivotTable;

		SELECT 'ASSIGNED' AS Tipo, * FROM #TMPASSIGNED
		UNION ALL
		SELECT 'RESOLVED' AS Tipo, * FROM #TMPRESOLVED

		DROP TABLE #TMPASSIGNED
		DROP TABLE #TMPRESOLVED
	END

	IF @Operacion = 'GET_PQRSF'
	BEGIN

		SELECT 
			 CAST(PQ.Id AS VARCHAR) AS Codigo
			,PQ.Fecha AS Fecha
			,PQ.FechaCierre AS FechaCierre
			,PQ.FechaCierreReal AS FechaCierreReal
			,PQ.Tipo AS TipoPeticion
			,PQ.Asunto AS Asunto
			,PQ.Descripcion AS Descripcion
			,ISNULL(PQ.Etiquetas,'') AS Etiquetas
			,ES.Nombre AS Estado
			,PRI.Nombre AS TipoPrioridad
			,SI.TipoSituacion AS TipoSituacion
			,ISNULL(PRO.nomare,'SIN AREA') AS Area
			,ISNULL((CON.NombreContacto + ' - ' + CON.Telefono + ' - ' + CON.Email),'SIN CONTACTO') AS Contacto
			,TER.ternom AS NombreCliente
			,TER.termail AS EmailCliente
			,ISNULL(RES.ternom,'SIN ASIGNAR') AS AgenteResponsable
			,PER.ternom AS AgentePerfila
			,CER.ternom AS AgenteCierre
			,PQ.Perfilacion AS Perfilada
		FROM WEBGLSS_MatrizPQRSF PQ
		LEFT JOIN WEBGLSS_Estados ES ON PQ.IdEstado = ES.Id
		LEFT JOIN WEBGLSS_Prioridades PRI ON PQ.IdPrioridad = PRI.Id
		LEFT JOIN WEBGLSS_SituacionesNoConformes SI ON PQ.IdSituacion= SI.Id
		LEFT JOIN proareas PRO ON PQ.IdProceso = PRO.codare
		LEFT JOIN accglTer TER ON PQ.NroIdeCli = TER.ternit
		LEFT JOIN accglTer RES ON PQ.NroIdResponsable = RES.ternit
		LEFT JOIN accglTer PER ON PQ.NroIdPerfilo = PER.ternit
		LEFT JOIN accglTer CER ON PQ.NroIdCerro = CER.ternit
		LEFT JOIN CliOtrosContactos CON ON PQ.IdContacto = CON.Id
		WHERE PQ.Id = @IdPqrsf

	END

	IF @Operacion = 'GETPQRSFS'
	BEGIN
		SELECT 
			 CAST(PQ.Id AS VARCHAR) AS Codigo
			,PQ.Fecha AS Fecha
			,PQ.FechaCierre AS FechaCierre
			,PQ.FechaCierreReal AS FechaCierreReal
			,PQ.Tipo AS TipoPeticion
			,PQ.Asunto AS Asunto
			,PQ.Descripcion AS Descripcion
			,ISNULL(PQ.Etiquetas,'') AS Etiquetas
			,ES.Nombre AS Estado
			,PRI.Nombre AS TipoPrioridad
			,SI.TipoSituacion AS TipoSituacion
			,ISNULL(PRO.nomare,'SIN AREA') AS Area
			,ISNULL((CON.NombreContacto + ' - ' + CON.Telefono + ' - ' + CON.Email),'SIN CONTACTO') AS Contacto
			,TER.ternom AS NombreCliente
			,TER.termail AS EmailCliente
			,ISNULL(RES.ternom,'SIN ASIGNAR') AS AgenteResponsable
			,PER.ternom AS AgentePerfila
			,CER.ternom AS AgenteCierre
			,PQ.Perfilacion AS Perfilada
		INTO #TABLEFILTER
		FROM WEBGLSS_MatrizPQRSF PQ
		LEFT JOIN WEBGLSS_Estados ES ON PQ.IdEstado = ES.Id
		LEFT JOIN WEBGLSS_Prioridades PRI ON PQ.IdPrioridad = PRI.Id
		LEFT JOIN WEBGLSS_SituacionesNoConformes SI ON PQ.IdSituacion= SI.Id
		LEFT JOIN proareas PRO ON PQ.IdProceso = PRO.codare
		LEFT JOIN accglTer TER ON PQ.NroIdeCli = TER.ternit
		LEFT JOIN accglTer RES ON PQ.NroIdResponsable = RES.ternit
		LEFT JOIN accglTer PER ON PQ.NroIdPerfilo = PER.ternit
		LEFT JOIN accglTer CER ON PQ.NroIdCerro = CER.ternit
		LEFT JOIN CliOtrosContactos CON ON PQ.IdContacto = CON.Id
		WHERE (CAST(PQ.Fecha AS DATE) BETWEEN @FechaIniC AND @FechaFinC AND
			  PQ.NroIdResponsable = CASE WHEN @Agente = 'all' THEN PQ.NroIdResponsable ELSE @Agente END AND
			  PQ.IdProceso = CASE WHEN @Area = 'all' THEN PQ.IdProceso ELSE @Area END AND
			  PQ.IdSituacion = CASE WHEN @Tipo = 'all' THEN PQ.IdSituacion ELSE @Tipo END AND
			  (@Estado = 'all' AND PQ.IdEstado = PQ.IdEstado)OR (@Estado = 'cer' AND PQ.IdEstado IN ('2', '3', '4'))OR(@Estado <> 'all' AND @Estado <> 'cer' AND CAST(PQ.IdEstado AS VARCHAR) = @Estado) AND
			  PQ.IdPrioridad = CASE WHEN @Prioridad = 'all' THEN PQ.IdPrioridad ELSE @Prioridad END AND
			  PQ.NroIdeCli = CASE WHEN @Cliente = 'all' THEN PQ.NroIdeCli ELSE @Cliente END) 
			  

		SELECT * FROM #TABLEFILTER
		WHERE (Codigo LIKE CASE WHEN @Search = 'na' THEN Codigo ELSE '%'+ @Search +'%' END OR
			   Asunto LIKE CASE WHEN @Search = 'na' THEN Asunto ELSE '%'+ @Search +'%' END OR
			   Descripcion LIKE CASE WHEN @Search = 'na' THEN Descripcion ELSE '%'+ @Search +'%' END OR
			   NombreCliente LIKE CASE WHEN @Search = 'na' THEN NombreCliente ELSE '%'+ @Search +'%' END)
		ORDER BY Fecha

		DROP TABLE #TABLEFILTER
	END

	IF @Operacion = 'GETPQRSFSBYUSER'
	BEGIN
		SELECT 
			 CAST(PQ.Id AS VARCHAR) AS Codigo
			,PQ.Fecha AS Fecha
			,PQ.FechaCierre AS FechaCierre
			,PQ.FechaCierreReal AS FechaCierreReal
			,PQ.Tipo AS TipoPeticion
			,PQ.Asunto AS Asunto
			,PQ.Descripcion AS Descripcion
			,ISNULL(PQ.Etiquetas,'') AS Etiquetas
			,ES.Nombre AS Estado
			,PRI.Nombre AS TipoPrioridad
			,SI.TipoSituacion AS TipoSituacion
			,ISNULL(PRO.nomare,'SIN AREA') AS Area
			,ISNULL((CON.NombreContacto + ' - ' + CON.Telefono + ' - ' + CON.Email),'SIN CONTACTO') AS Contacto
			,ISNULL(CON.TelCelu,'') + ' - ' + ISNULL(CON.Email,'') AS ContactoNumero
			,TER.ternom AS NombreCliente
			,TER.termail AS EmailCliente
			,ISNULL(RES.ternom,'SIN ASIGNAR') AS AgenteResponsable
			,PER.ternom AS AgentePerfila
			,CER.ternom AS AgenteCierre
			,PQ.Perfilacion AS Perfilada
		INTO #TABLEFILTERU
		FROM WEBGLSS_MatrizPQRSF PQ
		LEFT JOIN WEBGLSS_Estados ES ON PQ.IdEstado = ES.Id
		LEFT JOIN WEBGLSS_Prioridades PRI ON PQ.IdPrioridad = PRI.Id
		LEFT JOIN WEBGLSS_SituacionesNoConformes SI ON PQ.IdSituacion= SI.Id
		LEFT JOIN proareas PRO ON PQ.IdProceso = PRO.codare
		LEFT JOIN accglTer TER ON PQ.NroIdeCli = TER.ternit
		LEFT JOIN accglTer RES ON PQ.NroIdResponsable = RES.ternit
		LEFT JOIN accglTer PER ON PQ.NroIdPerfilo = PER.ternit
		LEFT JOIN accglTer CER ON PQ.NroIdCerro = CER.ternit
		LEFT JOIN CliOtrosContactos CON ON PQ.IdContacto = CON.Id
		WHERE PQ.NroIdeCli = @NroIdeCli 
			AND (CAST(PQ.Fecha AS DATE) BETWEEN @FechaIniC AND @FechaFinC 
			AND PQ.IdSituacion = CASE WHEN @Tipo = 'all' THEN PQ.IdSituacion ELSE CAST(@Tipo AS INT) END 
			AND ((@Estado = 'all' AND PQ.IdEstado = PQ.IdEstado) 
			OR  (@Estado = 'cer' AND PQ.IdEstado IN ('2', '3', '4')) 
			OR  (@Estado <> 'all' AND @Estado <> 'cer' AND CAST(PQ.IdEstado AS VARCHAR) = @Estado)))

		SELECT * FROM #TABLEFILTERU
		WHERE (Codigo LIKE CASE WHEN @Search = 'na' THEN Codigo ELSE '%'+ @Search +'%' END OR
			   Asunto LIKE CASE WHEN @Search = 'na' THEN Asunto ELSE '%'+ @Search +'%' END OR
			   Descripcion LIKE CASE WHEN @Search = 'na' THEN Descripcion ELSE '%'+ @Search +'%' END)
		ORDER BY Fecha

		DROP TABLE #TABLEFILTERU
			  		
	END

	IF @Operacion = 'GET_TRATAMIENTO'
	BEGIN
		SELECT * 
		FROM WEBGLSS_TratamientosPQRSF
		WHERE NroIdResponsable = @NroIdeCli
	END

END
GO

IF OBJECT_ID(N'dbo.WEBGLSS_SP_CONFIG') IS NULL
BEGIN
    PRINT 'Create procedure : dbo.WEBGLSS_SP_CONFIG'
    EXECUTE('CREATE PROCEDURE dbo.WEBGLSS_SP_CONFIG AS RETURN 0') 
END
GO

PRINT 'Alter procedure : dbo.WEBGLSS_SP_CONFIG'
GO
ALTER PROCEDURE [dbo].[WEBGLSS_SP_CONFIG] 
    @Operacion		VARCHAR(20) = '',
	@Search			VARCHAR(MAX) = '',
	@CodigoAgente	VARCHAR(20) = '',
	@Email			VARCHAR(20) = '',
	@NitEmpresa		VARCHAR(20) = '',
	@IdPermiso		VARCHAR(500) = '',
	@Permiso		VARCHAR(500) = '',
	@Tipo			VARCHAR(50) = '',
	@Descripcion	VARCHAR(1000) = '',
	@Codigo			VARCHAR(6) = '',
	@IdUsuario		VARCHAR(200) = '',
	@IdRol			VARCHAR(200) = '',
	@Clave			VARCHAR(50) = '',
	@NroIde			VARCHAR(50) = '',
	@dtCfg WEBGLSS_TypeConfiguracion READONLY
AS
BEGIN
	
	IF @Operacion = 'CHANGE_EMAIL'
	BEGIN
		
		UPDATE WEBGLSS_Agentes SET Email = @Email WHERE NroId = @CodigoAgente
		UPDATE WEBGLSS_UsuarioEmpresas SET Email = @Email WHERE NroIde = @CodigoAgente AND NitEmpresa = @NitEmpresa
		
	END

	IF @Operacion = 'GET_PERMISOS'
	BEGIN
		
		SELECT Id,Permiso,Descripcion,Tipo FROM WEBGLSS_Permisos
		
	END

	IF @Operacion = 'GET_PERMISO'
	BEGIN
		
		SELECT Id,Permiso,Descripcion,Tipo FROM WEBGLSS_Permisos WHERE id = @IdPermiso
		
	END

	IF @Operacion = 'SAVE_PERMISO'
	BEGIN

		IF @IdPermiso = 0
		BEGIN
			SELECT @Codigo = ISNULL(REPLICATE('0',6 - LEN(CAST(MAX(CAST(Codigo AS INT) + 1) AS VARCHAR))) +  CAST((MAX(CAST(Codigo AS INT) + 1)) AS VARCHAR),'000001') FROM WEBGLSS_Permisos

			INSERT INTO WEBGLSS_Permisos(Codigo,Permiso,Descripcion,Tipo)
			VALUES(@Codigo,@Permiso,@Descripcion,@Tipo)
		END
		ELSE
		BEGIN

			UPDATE WEBGLSS_Permisos SET Permiso = @Permiso, Descripcion = @Descripcion, Tipo = @Tipo
			WHERE Id = @IdPermiso

		END

	END

	IF @Operacion = 'GET_PERMISOS_USER'
	BEGIN
		
		SELECT 
			Id
			,Codigo
			,Permiso
			,Descripcion
			,Tipo
			,ISNULL(PU.Activo,0) AS Activo
			,@IdUsuario AS IdUsuario
		FROM WEBGLSS_Permisos P
		LEFT JOIN WEBGLSS_PermisosUsuarios PU ON P.Id = PU.IdPermiso
		WHERE PU.IdUsuario = @IdUsuario
		
	END

	IF @Operacion = 'SAVE_PERMISO_US'
	BEGIN
		
		IF EXISTS(SELECT * FROM WEBGLSS_PermisosUsuarios WHERE IdPermiso = @IdPermiso AND IdUsuario = @IdUsuario)
		BEGIN
			UPDATE WEBGLSS_PermisosUsuarios SET Activo = CASE WHEN Activo = 1 THEN 0 ELSE 1 END WHERE IdPermiso = @IdPermiso AND IdUsuario = @IdUsuario
		END
		ELSE
		BEGIN
			INSERT INTO WEBGLSS_PermisosUsuarios(IdPermiso,IdUsuario,Activo) VALUES (@IdPermiso,@IdUsuario,1)
		END
		
	END

	IF @Operacion = 'GET_ROLES_US'
	BEGIN
		
		SELECT 
			Id AS IdRol,
			@IdUsuario AS IdUsuario,
			Name AS NombreRol,
			CAST(CASE WHEN UserId IS NULL AND RoleId IS NULL THEN 0 ELSE 1 END AS BIT) AS Activo
		FROM AspNetRoles ROL
		LEFT JOIN AspNetUserRoles ROLU ON ROL.Id = ROLU.RoleId  AND ROLU.UserId = @IdUsuario

	END

	IF @Operacion = 'SAVE_ROL_US'
	BEGIN
		
		IF EXISTS(SELECT * FROM AspNetUserRoles WHERE UserId = @IdUsuario AND RoleId = @IdRol)
		BEGIN
			DELETE AspNetUserRoles WHERE UserId = @IdUsuario AND RoleId = @IdRol
		END
		ELSE
		BEGIN
			INSERT INTO AspNetUserRoles(UserId,RoleId) VALUES (@IdUsuario,@IdRol)
		END
		
	END

	IF @Operacion = 'GET_CONFIG'
	BEGIN
		SELECT * FROM WEBGLSS_Configuracion WHERE Clave = @Clave
	END

	IF @Operacion = 'SAVE_CONFIG'
	BEGIN

		UPDATE CFG
		SET
			CFG.Valor = CFG2.Valor
		FROM
			WEBGLSS_Configuracion AS CFG
			INNER JOIN @dtCfg AS CFG2 ON CFG.Clave = CFG2.Clave AND ISNULL(CFG2.Valor,'') <> ''

		SELECT * FROM WEBGLSS_Configuracion

	END

	IF @Operacion = 'GET_CONFIGS'
	BEGIN
		SELECT * FROM WEBGLSS_Configuracion
	END

	IF @Operacion = 'GET_CONFIG_EMAIL'
	BEGIN
		SELECT * FROM WEBGLSS_EmailConfiguracion WHERE KeyValue = @Clave
	END

	IF @Operacion = 'GET_MENU_US'
	BEGIN

		SELECT 
			 ME.CodMnu
			,ME.NomMnu
			,ME.TpoMnu
			,ME.DepMnu
			,ME.Controller
			,ME.Action
			,ME.IcoMnu
			,ME.NvlMnu
			,ME.Orden
		FROM WEBGLSS_MenuUsuarios MU
		LEFT JOIN WEBGLSS_Menus ME ON MU.CodMnu = ME.CodMnu AND MU.NroIdUsr = @NroIde
		UNION ALL
		SELECT 
			 ME.CodMnu
			,ME.NomMnu
			,ME.TpoMnu
			,ME.DepMnu
			,ME.Controller
			,ME.Action
			,ME.IcoMnu
			,ME.NvlMnu
			,ME.Orden
		FROM WEBGLSS_MenuRoles MR
		LEFT JOIN WEBGLSS_Menus ME ON MR.CodMnu = ME.CodMnu AND MR.idRol = @IdRol
		ORDER BY NvlMnu ASC, Orden ASC

	END
END
GO

IF OBJECT_ID(N'dbo.WEBGLSS_SP_PROVEEDORES') IS NULL
BEGIN
    PRINT 'Create procedure : dbo.WEBGLSS_SP_PROVEEDORES'
    EXECUTE('CREATE PROCEDURE dbo.WEBGLSS_SP_PROVEEDORES AS RETURN 0') 
END
GO

PRINT 'Alter procedure : dbo.WEBGLSS_SP_PROVEEDORES'
GO
ALTER PROCEDURE [dbo].[WEBGLSS_SP_PROVEEDORES] 
    @Operacion		VARCHAR(20) = '',
	@Search			VARCHAR(MAX) = '',
	@Pronit			VARCHAR(20)  = '',
	@Pronit1		VARCHAR(20) = '',
	@TipDoc			VARCHAR(2) = '',
	@DigVer			VARCHAR(1) = '',
	@ProPersona		INT = 0,
	@Pronom			VARCHAR(100) = '',
	@proreplegal	VARCHAR(100) = '',
	@proced			VARCHAR(20) = '',
	@Proconta		VARCHAR(100) = '',
	@Procargo		VARCHAR(50) = '',
	@Promail		VARCHAR(200) = '',
	@Protel			VARCHAR(50) = '',
	@Procel1		VARCHAR(20) = '',
	@Profax			VARCHAR(50) = '',		--fax
	@Prodir			VARCHAR(200) = '',	-- direccion
	@Proconta2      VARCHAR(30) = '',-- probarrio --> codigo de barrio
	@Procodciud		VARCHAR(5) = '',--procodciud --> Codigo de ciudad
	@ProPais		VARCHAR(10) ='',
	@Rut			VARCHAR(20) ='',
	@Fechav			DATETIME ='19000101', ---Fecha Vence Mat MErcantil
	@Nummatri		VARCHAR(20) ='',
	@InscrR			DATETIME = '19000101', ---InscrR -----> Inscripcion rup
	@Rup			INT =0, --Rup ---> Si tiene Rup
	@certie			INT = 0, --Certificado de establecimiento de comercio
	@bienservi		INT = 0,
	@Password		VARCHAR(100) = '',
	@IdEmpresa		INT = 0,
	@NitEmpresa		VARCHAR(20) = ''
AS
BEGIN
	
	IF @Operacion = 'SAVE_PROPONENTE'
	BEGIN
		
		SELECT @Pronit = ISNULL(REPLICATE('0',12 - LEN(CAST(MAX(CAST(pronit AS INT) + 1) AS VARCHAR))) +  CAST((MAX(CAST(pronit AS INT) + 1)) AS VARCHAR),'000000000000001') FROM WEBGLSS_Proponentes


		INSERT INTO WEBGLSS_Proponentes (delmrk,pronit,pronom,PRONIT1,proconta,procargo,prodir,promail,protel,profax,tipDoc,digVer,proconta2,proreplegal,proCodCiud,proPersona,proPais,RUt,fechav,InscrR,RUp,certie,bienser,Nummatri,Password,IdEmpresa,NitEmpresa)
		VALUES('1',@Pronit,@Pronom,@Pronit1,@Proconta,@Procargo,@Prodir,@Promail,@Protel,@Profax,@TipDoc,@DigVer,@Proconta2,@proreplegal,@Procodciud,@ProPersona,@ProPais,@Rut,@Fechav,@InscrR,@Rup,@certie,@bienservi,@Nummatri,@Password,@IdEmpresa,@NitEmpresa)

		SELECT * FROM WEBGLSS_Proponentes WHERE IdProponente = SCOPE_IDENTITY()

	END

END
GO

IF OBJECT_ID(N'dbo.WEBGLSS_SP_GESTION_HUMANA') IS NULL
BEGIN
    PRINT 'Create procedure : dbo.WEBGLSS_SP_GESTION_HUMANA'
    EXECUTE('CREATE PROCEDURE dbo.WEBGLSS_SP_GESTION_HUMANA AS RETURN 0') 
END
GO

PRINT 'Alter procedure : dbo.WEBGLSS_SP_GESTION_HUMANA'
GO
ALTER PROCEDURE [dbo].[WEBGLSS_SP_GESTION_HUMANA] 
    @Operacion			VARCHAR(20) = '',
	@Search				VARCHAR(MAX) = '',
	@Identificacion		VARCHAR(20) = '',
	@CodigoEmpleado		VARCHAR(20) = '',
	@TipoNovedad		VARCHAR(4) = '', -- O PERMISO
	@ValorAnterior		VARCHAR(30) = '',
	@ValorAnteriorExt	VARCHAR(30) = '',
	@ValorNuevo			VARCHAR(30) = '',
	@ValorNuevoExt		VARCHAR(30) = '',
	@Descripcion		VARCHAR(250) = '',
	@Motivo				VARCHAR(250) = '',
	@Estado				INT = 0,
	@IdSolicitudNovedad INT = 0,
	@CodigoNovedad		VARCHAR(20) = '',
	@Valor INT = 0,
	@Razones vARCHAR(250) = '',

	---PERMISO
	@FechaInicialP		DATE = '19000101',
	@FechaFinalP		DATE = '19000101',
	@HoraInicialP		DATETIME = '19000101',
	@HoraFinalP			DATETIME = '19000101',
	@ReingresaP			INT = 0,
	@Remunerado			BIT = 0,

	--VALId
	@FechaNacimiento	DATETIME = '19000101',
	@TipoValidacion		VARCHAR(4) = '',
	@Validacion			VARCHAR(10) = '',

	--VACACIONES
	@TipoNomina			VARCHAR(4) = '',
	@Dias				INT = 0,
	----
	@FechaPeriodoInicial DATETIME = '19000101',
	@FechaPeriodoFinal DATETIME = '19000101',
	@FechaInicialVacaciones DATETIME = '19000101',
	@FechaReintegro DATETIME = '19000101',
	@DiasHabiles INT = 0,
	@DiasCompensados INT = 0,
	@DiasDisfrute INT = 0,
	@DiasTotal INT = 0,
	@DiasPagar INT = 0

AS
BEGIN

	IF @Operacion = 'GETTIPONOV'
	BEGIN

		SELECT * FROM neTipoNovedadesEmp
		WHERE delmrk = 1 AND codigo NOT IN ('0001','0006','0007','0009','0010','0011','0012')
	END

	IF @Operacion = 'GETSOLNOVEMP'
	BEGIN
		SELECT * FROM WEBGLSS_SolicitudNovedades
	END

	IF @Operacion = 'GET_EPS'
	BEGIN

		SELECT 
			LTRIM(RTRIM(epscod)) AS epscod,
			LTRIM(RTRIM(epsnit)) AS epsnit,
			epsnom
		FROM eps WHERE delmrk = 1

	END

	IF @Operacion = 'GET_FP'
	BEGIN

		SELECT 
			LTRIM(RTRIM(pencod)) AS pencod,
			LTRIM(RTRIM(pennit)) AS pennit,
			pennom
		FROM fonpen WHERE delmrk = 1

	END

	IF @Operacion = 'GET_FC'
	BEGIN

		SELECT 
			LTRIM(RTRIM(cescod)) AS cescod,
			LTRIM(RTRIM(cesnit)) AS cesnit,
			cesnom
		FROM fonCes WHERE delmrk = 1

	END

	IF @Operacion = 'GET_ARP'
	BEGIN

		SELECT 
			LTRIM(RTRIM(arpcod)) AS arpcod,
			LTRIM(RTRIM(arpnit)) AS arpnit,
			arpnom
		FROM arp WHERE delmrk = 1

	END

	IF @Operacion = 'GET_EMP_INFO'
	BEGIN
		SELECT 
			LTRIM(RTRIM(empcod)) AS CodigoEmpleado,
			tipDoc AS TipoDocEmpleado,
			LTRIM(RTRIM(empced)) AS CedulaEmpleado,
			empNom AS NombreEmpleado,
			LTRIM(RTRIM(empCar)) AS CargoEmpleado,
			LTRIM(RTRIM(empEps)) AS EpsEmpleado,
			LTRIM(RTRIM(empCesantias)) AS CesantiaEmpleado,
			LTRIM(RTRIM(empPension))	AS PensionEmpleado,
			LTRIM(RTRIM(empARP))		AS CajaCompensacion,
			empSuelBas	AS SueldoEmpleado,
			empSubTransporte AS SubsidioTransporteEmpleado,
			empEmail AS CorreoEmpleado,
			empFechana AS FechaNacimiento
		FROM neEmpleados EMP
		WHERE empCed = @Identificacion
	END

	IF @Operacion = 'GET_SOL_NOV'
	BEGIN
		
		SELECT @CodigoEmpleado = empcod FROM neEmpleados WHERE empCed = @Identificacion

		SELECT 
			SN.Id			   AS IdSolicitudNovedad,
			SN.Codigo		   AS CodigoSolicitudNovedad,
			SN.Fecha		   AS FechaNovedad,
			NE.empcod		   AS CodigoEmpleado,
			NE.empced		   AS CedulaEmpleado,
			NE.empnom		   AS NombreEmpleado,
			SN.TipoNovedad	   AS CodigoTipoNovedad,
			CASE WHEN SN.TipoNovedad = 'AUSP' THEN 'Solicitud Permiso' 
				 WHEN SN.TipoNovedad = 'AUSV' THEN 'Solicitud Vacaciones'
				 ELSE TN.novedad END AS NombreNovedad,
			SN.Descripcion	   AS DescripcionNovedad,
			SN.FechaAprobacion AS FechaAprobacionNovedad,
			SN.Estado		   AS EstadoSolicitudNovedad
		FROM WEBGLSS_SolicitudNovedades SN
		LEFT JOIN neTipoNovedadesEmp TN ON SN.TipoNovedad = TN.codigo
		LEFT JOIN neempleados NE	ON SN.CodigoEmp = NE.empcod
		WHERE  CodigoEmp = CASE WHEN RTRIM(LTRIM(@Identificacion)) = '' THEN CodigoEmp ELSE @CodigoEmpleado END
		ORDER BY SN.Fecha DESC

	END

	IF @Operacion = 'GET_SOL_NOVS'
	BEGIN
		SELECT 
			SN.Id			   AS IdSolicitudNovedad,
			SN.Codigo		   AS CodigoSolicitudNovedad,
			SN.Fecha		   AS FechaNovedad,
			SN.TipoNovedad	   AS CodigoTipoNovedad,
			CASE WHEN SN.TipoNovedad = 'AUSP' THEN 'Solicitud Permiso' 
				 WHEN SN.TipoNovedad = 'AUSV' THEN 'Solicitud Vacaciones'
				 ELSE TN.novedad END AS NombreNovedad,
			SN.Descripcion	   AS DescripcionNovedad,
			SN.FechaAprobacion AS FechaAprobacionNovedad,
			SN.Estado		   AS EstadoSolicitudNovedad,
			CASE WHEN SN.TipoNovedad = '0002' THEN (SELECT TOP(1) epsnom FROM eps WHERE epscod = SN.ValorAnterior)
				 WHEN SN.TipoNovedad = '0003' THEN ValorAnterior
				 WHEN SN.TipoNovedad = '0004' THEN (SELECT TOP(1) pennom FROM fonpen WHERE pencod = SN.ValorAnterior)
				 WHEN SN.TipoNovedad = '0005' THEN (SELECT TOP(1) cesnom FROM fonCes WHERE cescod = SN.ValorAnterior)
				 WHEN SN.TipoNovedad = '0006' THEN ValorAnterior
			     WHEN SN.TipoNovedad = '0008' THEN (SELECT TOP(1) arpnom FROM arp WHERE arpcod = SN.ValorAnterior)
				 ELSE '' END AS ValorAnterior,
			CASE WHEN SN.TipoNovedad = '0002' THEN (SELECT TOP(1) epsnom FROM eps WHERE epscod = SN.ValorNuevo)
				WHEN SN.TipoNovedad = '0003' THEN ValorNuevo
				WHEN SN.TipoNovedad = '0004' THEN (SELECT TOP(1) pennom FROM fonpen WHERE pencod = SN.ValorNuevo)
				WHEN SN.TipoNovedad = '0005' THEN (SELECT TOP(1) cesnom FROM fonCes WHERE cescod = SN.ValorNuevo)
				WHEN SN.TipoNovedad = '0006' THEN ValorNuevo
				WHEN SN.TipoNovedad = '0008' THEN (SELECT TOP(1) arpnom FROM arp WHERE arpcod = SN.ValorNuevo)
				ELSE '' END AS ValorNuevo,
			SN.FechaPeriodoI,
			SN.FechaPeriodoF,
			SN.FechaVacacionesF,
			SN.FechaVacacionesI,
			SN.DiasHabiles,
			SN.DiasCompensados,
			SN.DiasDisfrute,
			SN.TotalDias,
			SN.DiasPagar
		FROM WEBGLSS_SolicitudNovedades SN
		LEFT JOIN neTipoNovedadesEmp TN ON SN.TipoNovedad = TN.codigo
		WHERE SN.Id = @IdSolicitudNovedad

	END

	IF @Operacion = 'SAVE_SOL_NOV'
	BEGIN
		
		SELECT @CodigoEmpleado = empcod FROM neEmpleados WHERE empCed = @Identificacion
		INSERT INTO WEBGLSS_SolicitudNovedades(Fecha,TipoNovedad,CodigoEmp,ValorAnterior,ValorAnteriorExt,ValorNuevo,ValorNuevoExt,Motivo,Descripcion)
		VALUES (GETDATE(),@TipoNovedad,@CodigoEmpleado,@ValorAnterior,@ValorAnteriorExt,@ValorNuevo,@ValorAnteriorExt,@Motivo,@Descripcion)

		SET @IdSolicitudNovedad = SCOPE_IDENTITY();

		EXEC WEBGLSS_SP_GESTION_HUMANA @Operacion =  'GET_SOL_NOVS',@IdSolicitudNovedad = @IdSolicitudNovedad

	END

	IF @Operacion = 'SAVE_SOL_PER'
	BEGIN
		
		INSERT INTO neMatrices	(CodigoEmpleado,FechaRegistro,FechaEvento,FechaInicio,FechaFin,CodigoMedidaCorrectiva,
							     Estado,Observacion,TipoMatriz,HoraIni,	Horafin,Reingresa,FechaMaquina)
		VALUES (@CodigoEmpleado,GETDATE(),GETDATE(),@FechaInicialP,@FechaFinalP,@TipoNovedad,'0',@Descripcion,'0002',@HoraInicialP,@HoraFinalP,@ReingresaP,GETDATE())

		DECLARE @IdPermiso VARCHAR(10) = ''
		
		SET @IdPermiso = SCOPE_IDENTITY()

		INSERT INTO WEBGLSS_SolicitudNovedades(Codigo,Fecha,TipoNovedad,CodigoEmp,ValorAnterior,ValorAnteriorExt,ValorNuevo,ValorNuevoExt,Motivo,Descripcion)
		VALUES (('AUSP-'+@IdPermiso),GETDATE(),'AUSP',@CodigoEmpleado,'','','','','',@Descripcion)

		SET @IdSolicitudNovedad = SCOPE_IDENTITY();

		EXEC WEBGLSS_SP_GESTION_HUMANA @Operacion =  'GET_SOL_NOVS',@IdSolicitudNovedad = @IdSolicitudNovedad

	END

	IF @Operacion = 'VAL_EMP'
	BEGIN
		
		SELECT 
			'OK' AS Respuesta,
			
			LTRIM(RTRIM(empced)) AS CedulaEmpleado,
			empNom AS NombreEmpleado,
			LTRIM(RTRIM(empCar)) AS CargoEmpleado,
			LTRIM(RTRIM(empEps)) AS EpsEmpleado,
			LTRIM(RTRIM(empCesantias)) AS CesantiaEmpleado,
			LTRIM(RTRIM(empPension))	AS PensionEmpleado,
			LTRIM(RTRIM(empARP))		AS CajaCompensacion,
			empSuelBas	AS SueldoEmpleado,
			empSubTransporte AS SubsidioTransporteEmpleado
		FROM neEmpleados EMP
		WHERE empCed = @Identificacion

	END

	IF @Operacion = 'GET_JEFE_RRHH'
	BEGIN

		SELECT 
		    tercod AS Codigo
			,ternom AS Nombre
			,ternit AS Identificacion
			,tipDoc AS TipoIdentificacion
			,tertel AS Telefono
			,terdir AS Direccion
			,'jairo142014@hotmail.com' AS Email--termail AS Email
		FROM accglTer
		WHERE tercod = (SELECT TOP(1) JefeRRHH FROM gl_cfg2)

	END

	IF @Operacion = 'GET_DATA_VAC'
	BEGIN

		SELECT
			 empCed												AS IdentificacionEmpleado
			,empTipNom											AS TipoNomina
		    ,CONVERT(DATE, empVacAcu, 103)						AS FechaInicialPeriodo
			,CONVERT(DATE, (DATEADD(YY,1,empVacAcu) - 1), 103)	AS FechaFinalPeriodo
			,CONVERT(DATE, GETDATE(), 103)	 AS FechaInicialVacaciones
			,CONVERT(DATE, GETDATE(), 103) AS FechaReintegroVacaciones
			,(Select TOP(1) V.Dias From v_Dias_Vacaciones V WITH (NOLOCK) Where V.empcod = empcod) AS DiasHabiles
			,0 AS DiasCompensados
			,0 AS DiasDisfrute
			,0 AS  TotalDias
			,0 AS DiasPagar
		FROM neEmpleados
		WHERE empCed = @Identificacion

	END

	IF @Operacion = 'GET_FERIADOS'
	BEGIN

		SELECT feriado AS Feriado
		FROM holidays

	END

	IF @Operacion = 'GET_DIAS_DISF'
	BEGIN

		SELECT dbo.FN_Dias_Disfrute(@FechaInicialVacaciones ,@Dias ,@TipoNomina ) AS FechaReingreso
			  ,dbo.FN_Dias_Disfrute2(@FechaInicialVacaciones ,@Dias ,@TipoNomina ) AS DiasAdicionales
			  ,dbo.FN_Dias_Disfrute2(@FechaInicialVacaciones ,@Dias ,@TipoNomina ) + @Dias AS DiasDisfrute

	END

	IF @Operacion = 'APP_REJ_SOL'
	BEGIN
		
		UPDATE WEBGLSS_SolicitudNovedades SET Estado = @Valor, RazonesAprobacion =  @Razones, FechaAprobacion = GETDATE()
		WHERE Id = @IdSolicitudNovedad

		SELECT
			 @ValorNuevo = ValorNuevo
			,@TipoNovedad =  TipoNovedad
			,@CodigoEmpleado = CodigoEmp
			,@CodigoNovedad = Codigo
		FROM WEBGLSS_SolicitudNovedades
		WHERE Id = @IdSolicitudNovedad

		IF @TipoNovedad <> 'AUSV' AND @TipoNovedad <> 'AUSP'
		BEGIN

			EXEC  PA_NovedadesEmp @Operacion=N'Insertar'
								,@tipoNovedad=@TipoNovedad
								,@nuevoValor1=@ValorNuevo
								,@nuevoValor2=N'NO'
								,@motivo=N''
								,@usuario=N''
								,@empleado=@CodigoEmpleado
								,@cadena=N''
		END
		

		IF @TipoNovedad = 'AUSP'
		BEGIN

			IF @Valor = 2
			BEGIN
				
				UPDATE neMatrices SET Estado = 2, FechaAutorizacion = GETDATE(),Observacion2 = @Razones
				WHERE Id = REPLACE(@CodigoNovedad,'AUSP-','')

			END

			IF @Valor = 1
			BEGIN
				
				UPDATE neMatrices SET CodigoEmpleado2 = @CodigoEmpleado,FechaAutorizacion= GETDATE(),Estado = 1,Observacion2 = @Razones
				WHERE id = REPLACE(@CodigoNovedad,'AUSP-','')

				IF @Remunerado = 1
				BEGIN

					INSERT INTO	Reg_Ausentismo (CodEmp,Fecha1,Fecha2,detalle,codAusen,fechaupd,RegEstado)
					SELECT CodigoEmpleado,FechaInicio,FechaFin,Observacion,CodigoMedidaCorrectiva,GETDATE(),'Pendiente'
					FROM neMatrices
					WHERE id = REPLACE(@CodigoNovedad,'AUSP-','')

				END

			END

		END

		EXEC WEBGLSS_SP_GESTION_HUMANA @Operacion =  'GET_SOL_NOVS',@IdSolicitudNovedad = @IdSolicitudNovedad
	END

	IF @Operacion = 'SAVE_SOL_VAC'
	BEGIN
		
		INSERT INTO WEBGLSS_SolicitudNovedades(Codigo,Fecha,TipoNovedad,CodigoEmp,ValorAnterior,ValorAnteriorExt,ValorNuevo,ValorNuevoExt,Motivo,Descripcion,FechaPeriodoI,FechaPeriodoF
					,FechaVacacionesI,FechaVacacionesF,DiasHabiles,DiasCompensados,DiasDisfrute,TotalDias,DiasPagar)
		VALUES ('AUSV',GETDATE(),'AUSV',@CodigoEmpleado,'','','','','',@Descripcion,@FechaPeriodoInicial,@FechaPeriodoFinal,@FechaInicialVacaciones,@FechaReintegro,@DiasHabiles,@DiasCompensados,
				@DiasDisfrute,@DiasTotal,@DiasPagar)

		SET @IdSolicitudNovedad = SCOPE_IDENTITY();

		EXEC WEBGLSS_SP_GESTION_HUMANA @Operacion =  'GET_SOL_NOVS',@IdSolicitudNovedad = @IdSolicitudNovedad

	END

	IF @Operacion = 'GET_SOL_PER'
	BEGIN

		DECLARE @IdPermisoEmpleado INT = 0
		SELECT 
			@IdPermisoEmpleado = REPLACE(Codigo,'AUSP-','')	
		FROM WEBGLSS_SolicitudNovedades
		WHERE Id = @IdSolicitudNovedad


		SELECT 
			NE.empced AS IdentificacionEmpleado
			,NE.empcod AS CodigoEmpleado
			,MO.Nombre AS TipoPermiso
			,CONVERT(VARCHAR,MA.FechaInicio,103) AS FechaInicial
			,CONVERT(VARCHAR,MA.FechaFin,103) AS FechaFinal
			,CONVERT(VARCHAR,MA.horaini,108) AS HoraInicial
			,CONVERT(VARCHAR,MA.horafin,108) AS HoraFinal
			,MA.Reingresa AS Reingresa
			,MA.Observacion AS Observaciones
		FROM neMatrices MA
		LEFT JOIN neempleados NE ON MA.CodigoEmpleado = NE.empcod
		LEFT JOIN V_MotivosPermisos MO ON MA.CodigoMedidaCorrectiva = MO.Codigo
		WHERE Id = @IdPermisoEmpleado

	END

END
GO

IF OBJECT_ID(N'dbo.WEBGLSS_SP_SOLICITUD_USUARIO') IS NULL
BEGIN
    PRINT 'Create procedure : dbo.WEBGLSS_SP_SOLICITUD_USUARIO'
    EXECUTE('CREATE PROCEDURE dbo.WEBGLSS_SP_SOLICITUD_USUARIO AS RETURN 0') 
END
GO

PRINT 'Alter procedure : dbo.WEBGLSS_SP_SOLICITUD_USUARIO'
GO
ALTER PROCEDURE [dbo].[WEBGLSS_SP_SOLICITUD_USUARIO] 
    @Operacion			VARCHAR(20) = '',
	@Codigo				VARCHAR(20) = '',
	@NroIde				VARCHAR(20) = '',
	@TipDoc				VARCHAR(5) = '',
	@NombreCompleto		VARCHAR(100) = '',
	@PrimerNombre		VARCHAR(40) = '',
	@SegundoNombre		VARCHAR(40) = '',
	@PrimerApellido		VARCHAR(40) = '',
	@SegundoApellido	VARCHAR(40) = '',
	@Ciudad				VARCHAR(10) = '',
	@Direccion			VARCHAR(90) = '',
	@Celular			VARCHAR(20) = '',
	@Telefono			VARCHAR(20) = '',
	@Email				VARCHAR(50) = '',
	@FechaCreacion		DATETIME = '19000101',
	@NitEmpresa			VARCHAR(20) = '',
	@Estado				VARCHAR(40) = '',
	@Password			VARCHAR(50) =  ''
AS
BEGIN

	IF @Operacion = 'SAVE_SOL_CLI'
	BEGIN

		INSERT INTO WEBGLSS_SolicitudClientes(Codigo,TipDoc,NroIde,NombreCompleto,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Ciudad,Direccion,Celular,Telefono,Email,FechaCreacion,NitEmpresa,Estado,Password)
		VALUES(@Codigo,@TipDoc,@NroIde,@NombreCompleto,@PrimerNombre,@SegundoNombre,@PrimerApellido,@SegundoApellido,@Ciudad,@Direccion,@Celular,@Telefono,@Email,@FechaCreacion,@NitEmpresa,@Estado,@Password)

		SELECT * FROM WEBGLSS_SolicitudClientes WHERE Id = SCOPE_IDENTITY()

	END

END
GO


IF OBJECT_ID(N'dbo.WEBGLSS_SP_USER_MANAGER') IS NULL
BEGIN
    PRINT 'Create procedure : dbo.WEBGLSS_SP_USER_MANAGER'
    EXECUTE('CREATE PROCEDURE dbo.WEBGLSS_SP_USER_MANAGER AS RETURN 0') 
END
GO

PRINT 'Alter procedure : dbo.WEBGLSS_SP_USER_MANAGER'
GO
ALTER PROCEDURE [dbo].[WEBGLSS_SP_USER_MANAGER] 
    @Operacion			VARCHAR(20) = '',
	@Email				VARCHAR(50) = ''
AS
BEGIN

	IF @Operacion = 'GET_USER'
	BEGIN

		SELECT * FROM AspNetUsers WHERE NormalizedUserName = @Email

	END

END
GO


IF OBJECT_ID(N'dbo.PA_SSApi_User') IS NULL
BEGIN
    PRINT 'Create procedure : dbo.PA_SSApi_User'
    EXECUTE('CREATE PROCEDURE dbo.PA_SSApi_User AS RETURN 0') 
END
GO

PRINT 'Alter procedure : dbo.PA_SSApi_User'
GO

ALTER PROCEDURE [dbo].[PA_SSApi_User] 
    @Operacion			VARCHAR(20) = '',
	@Codigo				VARCHAR(20) = '',
	@CodigoSS			VARCHAR(50) = ''
AS
BEGIN
		
		IF @Operacion = 'GET_INFO_USER'
		BEGIN
			
			SELECT 
				 US.UserSSGL AS UserSSGL
				,US.Codigo  AS CodigoUsuario
				,US.Nombre  AS NombreCompleto
				,US.Usuario AS NombreUsuario
				,US.Cajero
				,US.Tipo AS TipoUsuario
				,US.Aprobar
				,US.monto
				,US.Area
				,US.cooCosto
				,US.CodEmpleado AS CodigoEmpleado
				,CONVERT(varchar(50),DECRYPTBYPASSPHRASE('GeneralLedger***',US.Clave)) as Clave 
				,US.UsarAPP
				,US.UserDep AS DependenciaUsuario
				,US.UserCliente AS EsCliente
				,US.id
				,US.ConfigTProv
				,US.CodigoTer AS CodigoTercero
				,ISNULL(TER.ternom,'') AS Nombre
				,ISNULL(TER.ternit,'') AS IdentificacionUsuario
				,ISNULL(TER.TerPriNom,'') AS PrimerNombre
				,ISNULL(TER.TerSegNom,'') AS SegundoNombre
				,ISNULL(TER.TerPriApe,'') AS PrimerApellido
				,ISNULL(TER.TerSegApe,'') AS SegundoApellido
				,ISNULL(TER.tercel,'')    AS Celular
				,ISNULL(TER.tertel,'')	   AS Telefono
				,ISNULL(TER.terdir,'')	   AS Direccion
				,ISNULL(TER.termail,'')   AS Email
				,(SELECT TOP(1) nitempresa FROM gl_cfg) AS NitEmpresa
				,(SELECT TOP(1) nomempresa FROM gl_cfg) AS NombreEmpresa
				,'AGENTE' AS Rol
				,0 AS IdEmpresa
				,(SELECT TOP(1) valor FROM GL_Configuracion WHERE Campo = 'SSLOGOEMPRESA') LogoEmpresa
				,(SELECT TOP(1) valor FROM GL_Configuracion WHERE Campo = 'KEYCONNECTIONSSGL') AS KeyConnection
				,(SELECT TOP(1) valor FROM GL_Configuracion WHERE Campo = 'APIUSERSSGL') AS UserApiGl
				,(SELECT TOP(1) valor FROM GL_Configuracion WHERE Campo = 'APIPASSWORDSSGL') AS PasswordApiGL
			FROM accglUsuarios US
			LEFT JOIN accglTer TER ON US.CodigoTer = TER.tercod AND TER.tercod <> ''
			WHERE US.Codigo = @Codigo OR US.Usuario = @Codigo AND US.delmrk = '1'

		END

		IF @Operacion = 'UPD_USER_GLSS'
		BEGIN

			UPDATE accglUsuarios SET UserSSGL = @CodigoSS WHERE Usuario = @Codigo OR Codigo = @Codigo

		END

END
GO

IF OBJECT_ID(N'dbo.WEBGLSS_SP_MENUS') IS NULL
BEGIN
    PRINT 'Create procedure : dbo.WEBGLSS_SP_MENUS'
    EXECUTE('CREATE PROCEDURE dbo.WEBGLSS_SP_MENUS AS RETURN 0') 
END
GO

PRINT 'Alter procedure : dbo.WEBGLSS_SP_MENUS'
GO

ALTER PROCEDURE [dbo].[WEBGLSS_SP_MENUS] 
    @Operacion			VARCHAR(20) = '',
	@CodigoMenu			VARCHAR(10) = '',
	@CodigoUsuario		VARCHAR(100) = '',
	@CodigoRol			VARCHAR(100) = ''
AS
BEGIN

	IF @Operacion = 'GET'
	BEGIN

		SELECT * FROM WEBGLSS_Menus WHERE delmrk = 1

	END

	IF @Operacion = 'GET_BY_USER'
	BEGIN

		SELECT
		     ME.Id
			,ME.CodMnu
			,ME.NomMnu
			,ME.Orden
			,ME.NvlMnu
			,ME.TpoMnu
			,ME.DepMnu
			,ME.Controller
			,ME.Action
			,ME.IcoMnu
			,ME.delmrk
		FROM WEBGLSS_MenuUsuarios MU
		LEFT JOIN WEBGLSS_Menus ME ON MU.CodMnu = ME.CodMnu AND MU.NroIdUsr = @CodigoUsuario
		UNION ALL
		SELECT
		     ME.Id
			,ME.CodMnu
			,ME.NomMnu
			,ME.Orden
			,ME.NvlMnu
			,ME.TpoMnu
			,ME.DepMnu
			,ME.Controller
			,ME.Action
			,ME.IcoMnu
			,ME.delmrk
		FROM WEBGLSS_MenuRoles MR
		LEFT JOIN WEBGLSS_Menus ME ON MR.CodMnu = ME.CodMnu AND MR.idRol = @CodigoRol
		ORDER BY NvlMnu ASC, Orden ASC	

	END

	IF @Operacion = 'REMOVE_MENU_USER'
	BEGIN

		DELETE WEBGLSS_MenuUsuarios WHERE NroIdUsr = @CodigoUsuario AND CodMnu = @CodigoMenu	
		SELECT * FROM WEBGLSS_Menus WHERE CodMnu = @CodigoMenu

	END

	IF @Operacion = 'ADD_MENU_USER'
	BEGIN

		INSERT INTO WEBGLSS_MenuUsuarios(NroIdUsr,CodMnu,delmrk)
		VALUES(@CodigoUsuario,@CodigoMenu,'1')
		
		SELECT * FROM WEBGLSS_Menus WHERE CodMnu = @CodigoMenu

	END

END

GO


IF OBJECT_ID(N'dbo.WEBGLSS_SP_EMPRESAGL') IS NULL
BEGIN
    PRINT 'Create procedure : dbo.WEBGLSS_SP_EMPRESAGL'
    EXECUTE('CREATE PROCEDURE dbo.WEBGLSS_SP_EMPRESAGL AS RETURN 0') 
END
GO

PRINT 'Alter procedure : dbo.WEBGLSS_SP_EMPRESAGL'
GO

ALTER PROCEDURE [dbo].[WEBGLSS_SP_EMPRESAGL] 
    @Operacion			VARCHAR(20) = ''
AS
BEGIN
	IF @Operacion = 'GET_EMPRESA_GL'
	BEGIN

		SELECT 
			 nomempresa		AS Nombre
			,dirempresa		AS Direccion
			,conciudad		AS Ciudad
			,contelefono	AS Telefono
			,nitempresa		AS Nit
			,reprelegal		AS Representante
			,(SELECT TOP(1) ISNULL(cedreplegal, '') FROM inv_gl_cfg)    AS CedulaRepresentante
			,(SELECT TOP(1) responsabledocu FROM ne_gl_cfg)			AS NombreRepresentante
			,(SELECT TOP(1) cargo FROM ne_gl_cfg) 						AS CargoRepresentante
			,(SELECT TOP(1) valor FROM GL_Configuracion WHERE Campo = 'SSLOGOEMPRESA') AS Logo
			,(SELECT TOP(1) valor FROM GL_Configuracion WHERE Campo = 'KEYCONNECTIONSSGL') AS KeyConnection
		FROM gl_cfg 

	END
END
GO

IF OBJECT_ID(N'dbo.WEBGLSS_SP_EMPLEADO') IS NULL
BEGIN
    PRINT 'Create procedure : dbo.WEBGLSS_SP_EMPLEADO'
    EXECUTE('CREATE PROCEDURE dbo.WEBGLSS_SP_EMPLEADO AS RETURN 0') 
END
GO

PRINT 'Alter procedure : dbo.WEBGLSS_SP_EMPLEADO'
GO

ALTER PROCEDURE [dbo].[WEBGLSS_SP_EMPLEADO] 
    @Operacion			VARCHAR(20) = ''
	,@CodigoEmpleado	VARCHAR(20) = ''
	,@NitEmpleado		VARCHAR(20) = ''
AS
BEGIN

	IF @Operacion = 'GET_BY_CODIGO'
	BEGIN

		SELECT 
			 *
		FROM neempleados
		WHERE empcod = @CodigoEmpleado

	END

	IF @Operacion = 'GET_BY_NIT'
	BEGIN

		SELECT 
			 *
		FROM neempleados
		WHERE empCed = @NitEmpleado

	END

END
GO

-- END CREATE PROCEDURES


IF NOT EXISTS (SELECT* FROM GL_Configuracion WHERE Campo = 'SSLOGOEMPRESA') 
	INSERT INTO GL_Configuracion (Campo,valor)
	VALUES('SSLOGOEMPRESA','')
GO

INSERT INTO GL_Configuracion (Campo,valor)
VALUES('APIUSERSSGL','CrypTh1c9xGL')

IF NOT EXISTS (SELECT* FROM GL_Configuracion WHERE Campo = 'APIUSERSSGL') 
	INSERT INTO GL_Configuracion (Campo,valor)
	VALUES('APIUSERSSGL','CrypTh1c9xGL')
GO

IF NOT EXISTS (SELECT* FROM GL_Configuracion WHERE Campo = 'KEYCONNECTIONSSGL') 
	INSERT INTO GL_Configuracion (Campo,valor)
	VALUES('KEYCONNECTIONSSGL','GLSELFSERVICE_KEY')
GO

IF NOT EXISTS (SELECT* FROM GL_Configuracion WHERE Campo = 'BaseUrlApiGLSS') 
	INSERT INTO GL_Configuracion (Campo,valor)
	VALUES('BaseUrlApiGLSS','https://clientes04.vit.com.co:5788/api/')
GO

