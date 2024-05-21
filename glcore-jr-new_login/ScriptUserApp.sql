/***START TABLES***/
IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'AspNetRoleClaims'))
BEGIN
	CREATE TABLE [dbo].[AspNetRoleClaims](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[RoleId] [nvarchar](450) NOT NULL,
		[ClaimType] [nvarchar](max) NULL,
		[ClaimValue] [nvarchar](max) NULL,
	 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'AspNetRoles'))
BEGIN
	CREATE TABLE [dbo].[AspNetRoles](
		[Id] [nvarchar](450) NOT NULL,
		[Name] [nvarchar](256) NULL,
		[NormalizedName] [nvarchar](256) NULL,
		[ConcurrencyStamp] [nvarchar](max) NULL,
	 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'AspNetUserClaims'))
BEGIN
	CREATE TABLE [dbo].[AspNetUserClaims](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[UserId] [nvarchar](450) NOT NULL,
		[ClaimType] [nvarchar](max) NULL,
		[ClaimValue] [nvarchar](max) NULL,
	 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'AspNetUserLogins'))
BEGIN
	CREATE TABLE [dbo].[AspNetUserLogins](
		[LoginProvider] [nvarchar](128) NOT NULL,
		[ProviderKey] [nvarchar](128) NOT NULL,
		[ProviderDisplayName] [nvarchar](max) NULL,
		[UserId] [nvarchar](450) NOT NULL,
	 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
	(
		[LoginProvider] ASC,
		[ProviderKey] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'AspNetUserRoles'))
BEGIN
	CREATE TABLE [dbo].[AspNetUserRoles](
		[UserId] [nvarchar](450) NOT NULL,
		[RoleId] [nvarchar](450) NOT NULL,
	 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
	(
		[UserId] ASC,
		[RoleId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'AspNetUsers'))
BEGIN
	CREATE TABLE [dbo].[AspNetUsers](
		[Id] [nvarchar](450) NOT NULL,
		[NroId] [nvarchar](max) NULL,
		[Nombre] [nvarchar](max) NULL,
		[PriNombre] [nvarchar](max) NULL,
		[SegNombre] [nvarchar](max) NULL,
		[PriApellido] [nvarchar](max) NULL,
		[SegApellido] [nvarchar](max) NULL,
		[IdEmpresa] [int] NOT NULL,
		[NitEmpresa] [nvarchar](max) NULL,
		[UsuarioGL] [varchar](20) NOT NULL,		
		[CodigoUsuarioGL] [varchar](4) NOT NULL,		
		[CodigoEmpleado] [varchar](20) NOT NULL,
		[CodigoTercero] [varchar](20) NOT NULL,
		[TipoUsuario] [varchar](5) NOT NULL,
		[Celular] [nvarchar](20) NULL,
		[Telefono] [nvarchar](20) NULL,
		[Direccion] [nvarchar](max) NULL,
		[Dependencia] [varchar](6) NOT NULL,
		[EmailUser] [varchar](50) NOT NULL,
		[EsCliente] [bit] NOT NULL,
		[KeyConnection] [varchar](50) NOT NULL,		
		[UserName] [nvarchar](256) NULL,
		[NormalizedUserName] [nvarchar](256) NULL,
		[Email] [nvarchar](256) NULL,
		[NormalizedEmail] [nvarchar](256) NULL,
		[EmailConfirmed] [bit] NOT NULL,
		[PasswordHash] [nvarchar](max) NULL,
		[SecurityStamp] [nvarchar](max) NULL,
		[ConcurrencyStamp] [nvarchar](max) NULL,
		[PhoneNumber] [nvarchar](max) NULL,
		[PhoneNumberConfirmed] [bit] NOT NULL,
		[TwoFactorEnabled] [bit] NOT NULL,
		[LockoutEnd] [datetimeoffset](7) NULL,
		[LockoutEnabled] [bit] NOT NULL,
		[AccessFailedCount] [int] NOT NULL,
	 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'AspNetUserTokens'))
BEGIN
	CREATE TABLE [dbo].[AspNetUserTokens](
		[UserId] [nvarchar](450) NOT NULL,
		[LoginProvider] [nvarchar](128) NOT NULL,
		[Name] [nvarchar](128) NOT NULL,
		[Value] [nvarchar](max) NULL,
	 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
	(
		[UserId] ASC,
		[LoginProvider] ASC,
		[Name] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'WEBGLSS_GrupoEmpresas'))
BEGIN
	CREATE TABLE [dbo].[WEBGLSS_GrupoEmpresas](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Codigo] [varchar](20) NOT NULL,
		[Nombre] [varchar](250) NOT NULL,
		[FechaRegistro] [datetime2](7) NOT NULL,
	 CONSTRAINT [PK_WEBGLSS_GrupoEmpresas] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'WEBGLSS_Empresas'))
BEGIN
	CREATE TABLE [dbo].[WEBGLSS_Empresas](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Nit] [varchar](15) NOT NULL,
		[IdGrupo] [int] NOT NULL,
		[DIV] [varchar](2) NOT NULL,
		[Nombre] [varchar](100) NOT NULL,
		[CodigoLegacy] [varchar](10) NOT NULL,
		[EmailPrincipal] [varchar](2) NOT NULL,
		[Estado] [varchar](2) NOT NULL,
		[IP] [varchar](30) NOT NULL,
		[DB] [varchar](30) NOT NULL,
		[KeyConnection] [varchar](40) NOT NULL,
		[UrlWeb] [varchar](500) NOT NULL,
		[Logo] [varchar](500) NOT NULL,
		[Salt] [varchar](500) NOT NULL,
		[FechaRegistro] [datetime2](7) NOT NULL,
	 CONSTRAINT [PK_WEBGLSS_Empresas] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

/***END TABLAS***/

/***START ALTER TABLES***/
IF NOT EXISTS ( select * from dbo.syscolumns where id = object_id(N'[dbo].[AspNetUsers]') and OBJECTPROPERTY(id, N'IsUserTable') = 1 and  name = 'KeyConnection')
	ALTER TABLE AspNetUsers ADD KeyConnection VARCHAR(50) DEFAULT '' NOT NULL
GO

IF NOT EXISTS ( select * from dbo.syscolumns where id = object_id(N'[dbo].[AspNetUsers]') and OBJECTPROPERTY(id, N'IsUserTable') = 1 and  name = 'UsuarioGL')
	ALTER TABLE AspNetUsers ADD UsuarioGL VARCHAR(20) DEFAULT '' NOT NULL
GO

IF NOT EXISTS ( select * from dbo.syscolumns where id = object_id(N'[dbo].[AspNetUsers]') and OBJECTPROPERTY(id, N'IsUserTable') = 1 and  name = 'CodigoEmpleado')
	ALTER TABLE AspNetUsers ADD CodigoEmpleado VARCHAR(20) DEFAULT '' NOT NULL
GO

IF NOT EXISTS ( select * from dbo.syscolumns where id = object_id(N'[dbo].[AspNetUsers]') and OBJECTPROPERTY(id, N'IsUserTable') = 1 and  name = 'CodigoTercero')
	ALTER TABLE AspNetUsers ADD CodigoTercero VARCHAR(20) DEFAULT '' NOT NULL
GO

IF NOT EXISTS ( select * from dbo.syscolumns where id = object_id(N'[dbo].[AspNetUsers]') and OBJECTPROPERTY(id, N'IsUserTable') = 1 and  name = 'TipoUsuario')
	ALTER TABLE AspNetUsers ADD TipoUsuario VARCHAR(5) DEFAULT '' NOT NULL
GO

IF NOT EXISTS ( select * from dbo.syscolumns where id = object_id(N'[dbo].[AspNetUsers]') and OBJECTPROPERTY(id, N'IsUserTable') = 1 and  name = 'Telefono')
	ALTER TABLE AspNetUsers ADD Telefono VARCHAR(20) DEFAULT '' NOT NULL
GO

IF NOT EXISTS ( select * from dbo.syscolumns where id = object_id(N'[dbo].[AspNetUsers]') and OBJECTPROPERTY(id, N'IsUserTable') = 1 and  name = 'EmailUser')
	ALTER TABLE AspNetUsers ADD EmailUser VARCHAR(50) DEFAULT '' NOT NULL
GO

IF NOT EXISTS ( select * from dbo.syscolumns where id = object_id(N'[dbo].[AspNetUsers]') and OBJECTPROPERTY(id, N'IsUserTable') = 1 and  name = 'EsCliente')
	ALTER TABLE AspNetUsers ADD EsCliente BIT DEFAULT 0 NOT NULL
GO

IF NOT EXISTS ( select * from dbo.syscolumns where id = object_id(N'[dbo].[AspNetUsers]') and OBJECTPROPERTY(id, N'IsUserTable') = 1 and  name = 'CodigoUsuarioGL')
	ALTER TABLE AspNetUsers ADD CodigoUsuarioGL VARCHAR(20) DEFAULT '' NOT NULL
GO

IF NOT EXISTS ( select * from dbo.syscolumns where id = object_id(N'[dbo].[WEBGLSS_Empresas]') and OBJECTPROPERTY(id, N'IsUserTable') = 1 and  name = 'Salt')
	ALTER TABLE WEBGLSS_Empresas ADD Salt VARCHAR(500) DEFAULT '' NOT NULL
GO

IF NOT EXISTS ( select * from dbo.syscolumns where id = object_id(N'[dbo].[WEBGLSS_Empresas]') and OBJECTPROPERTY(id, N'IsUserTable') = 1 and  name = 'IdGrupo')
	ALTER TABLE WEBGLSS_Empresas ADD IdGrupo INT DEFAULT 0 NOT NULL
GO
/***END ALTER TABLES***/


/**START INSERTS**/
IF NOT EXISTS (SELECT * FROM AspNetRoles)
BEGIN

	INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1432885d-3427-4af9-8ef4-049196888edf', N'EMPLEADO', N'EMPLEADO', N'0b9d7989-9c00-44d0-8253-a5e8096c7e23')

	INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'a17942b2-986e-4901-9765-1d8e22e70ae3', N'AGENTE', N'AGENTE', N'c61bdafe-2174-4574-8e35-8f6db8f48218')

	INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'ef7c9c4e-6671-4f75-a5d0-147cd17722fd', N'CLIENTE', N'CLIENTE', N'a0285306-ce55-4535-a945-e6a0fad2be1d')

	INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'f2224629-c117-4247-aece-812b8950fc03', N'ADMIN', N'ADMIN', N'92c8a3fc-8668-4c77-8c5b-f6598a23f8e1')

END
GO
/**END INSERTS**/


/***START PROCEDURES**/
IF OBJECT_ID(N'dbo.WEBGLSS_SP_EMPRESA') IS NULL
BEGIN
    PRINT 'Create procedure : dbo.WEBGLSS_SP_EMPRESA'
    EXECUTE('CREATE PROCEDURE dbo.WEBGLSS_SP_EMPRESA AS RETURN 0') 
END
GO

PRINT 'Alter procedure : dbo.WEBGLSS_SP_EMPRESA'
GO
ALTER PROCEDURE [dbo].[WEBGLSS_SP_EMPRESA] 
    @Operacion			VARCHAR(20) = '',
	@Nit				VARCHAR(20) = '',
	@NitEmpresa			VARCHAR(20) = '',
	@DIV				VARCHAR(1) = '',
	@Nombre				VARCHAR(100) = '',
	@CodigoLegacy		VARCHAR(10) = '',
	@EmailPrincipal		VARCHAR(30) = '',
	@Estado				VARCHAR(2) = '',
	@IP					VARCHAR(30) = '',
	@DB					VARCHAR(30) = '',
	@KeyConnection		VARCHAR(40) = '',
	@UrlWeb				VARCHAR(500) = '',
	@Logo				VARCHAR(500) = '',	
	@FechaRegistro		DATETIME = '19000101',
	@IdEmpresa			INT = 0,
	@IdUsuarioEmpresa	INT = 0,
	@Salt				VARCHAR(500) = ''
AS
BEGIN

	IF @Operacion = 'GET_EMPRESA'
	BEGIN
		
		SELECT 
			Id
			,Nit
			,DIV
			,Nombre
			,CodigoLegacy
			,EmailPrincipal
			,Estado
			,IP
			,DB
			,KeyConnection
			,UrlWeb
			,Logo
			,FechaRegistro
			,Salt
			,IdGrupo
		FROM WEBGLSS_Empresas WHERE Nit = @Nit

	END

	IF @Operacion = 'GET_EMPRESAS'
	BEGIN
		
		SELECT 
			Id
			,Nit
			,DIV
			,Nombre
			,CodigoLegacy
			,EmailPrincipal
			,Estado
			,IP
			,DB
			,KeyConnection
			,UrlWeb
			,Logo
			,FechaRegistro
			,Salt
			,IdGrupo
		FROM WEBGLSS_Empresas 

	END

	IF @Operacion = 'SAVE_EMPRESA'
	BEGIN
		
		INSERT INTO WEBGLSS_Empresas(Nit,DIV,Nombre,CodigoLegacy,EmailPrincipal,Estado,IP,DB,KeyConnection,UrlWeb,Logo,FechaRegistro)
		VALUES(@Nit,@DIV,@Nombre,@CodigoLegacy,@EmailPrincipal,@Estado,@IP,@DB,@KeyConnection,@UrlWeb,@Logo,@FechaRegistro)

		SELECT * FROM WEBGLSS_Empresas WHERE Id = SCOPE_IDENTITY()

	END

	IF @Operacion = 'DEL_US_EMPRESA'
	BEGIN

		DELETE WEBGLSS_UsuarioEmpresas WHERE Id = @IdUsuarioEmpresa

	END

	IF @Operacion = 'SAVE_US_EMPRESA'
	BEGIN
		
		INSERT INTO WEBGLSS_UsuarioEmpresas(IdEmpresa,NitEmpresa,NroIde,Email)
		VALUES(@IdEmpresa,@NitEmpresa,@Nit,@EmailPrincipal)
		
		SELECT * FROM WEBGLSS_UsuarioEmpresas WHERE Id = SCOPE_IDENTITY()

	END

	IF @Operacion = 'GET_US_EMPRESA'
	BEGIN
		
		SELECT * FROM WEBGLSS_UsuarioEmpresas WHERE Email = @EmailPrincipal

	END

	IF @Operacion = 'GET_EMPRESA_SALT'
	BEGIN
		
		SELECT * FROM WEBGLSS_Empresas WHERE Salt = @Salt

	END

END
GO

/***END PROCEDURES***/