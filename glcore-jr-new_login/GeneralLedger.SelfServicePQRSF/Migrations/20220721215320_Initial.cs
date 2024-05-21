using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace GeneralLedger.SelfServiceCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WEBGLSS_Agentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: true),
                    NroId = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    NombreCompleto = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    RecibeEmail = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    NitEmpresa = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    delmrk = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: true, defaultValue: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEBGLSS_Agentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WEBGLSS_Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: true),
                    TipoDoc = table.Column<string>(type: "VARCHAR(5)", maxLength: 5, nullable: false),
                    NroId = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: true),
                    NombreCompleto = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    PrimerNombre = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    SegundoNombre = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: true),
                    PrimerApellido = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: true),
                    SegundoApellido = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: true),
                    Ciudad = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    Direccion = table.Column<string>(type: "VARCHAR(90)", maxLength: 90, nullable: true),
                    Celular = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Sexo = table.Column<string>(type: "VARCHAR(5)", maxLength: 5, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    NitEmpresa = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    delmrk = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEBGLSS_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WEBGLSS_Configuracion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Clave = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: true),
                    Valor = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    Descripcion = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEBGLSS_Configuracion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WEBGLSS_ContactoClientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NroIdCli = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    NombreContacto = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    Celular = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    NitEmpresa = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    delmrk = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: true, defaultValue: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEBGLSS_ContactoClientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WEBGLSS_Elementos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumEle = table.Column<string>(type: "VARCHAR(5)", maxLength: 5, nullable: true),
                    RefEle = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: true),
                    TipEle = table.Column<string>(type: "VARCHAR(5)", maxLength: 5, nullable: true),
                    NomEle = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: true),
                    VlrEle = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: true),
                    delmrk = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: true, defaultValue: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEBGLSS_Elementos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WEBGLSS_EmailConfiguracion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeyValue = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Remitente = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    NombreRemitente = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    ReplyTo = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: true),
                    Titulo = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    Asunto = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Cuerpo = table.Column<string>(type: "VARCHAR(1000)", maxLength: 1000, nullable: false),
                    Template = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    LogoEmpresa = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: true),
                    WebEmpresa = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    NombreEmpresa = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Token = table.Column<string>(type: "VARCHAR(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEBGLSS_EmailConfiguracion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WEBGLSS_Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NroId = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    NombreCompleto = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    PrimerNombre = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    SegundoNombre = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: true),
                    PrimerApellido = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    SegundoApellido = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    Ciudad = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Celular = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Sexo = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "date", maxLength: 100, nullable: false, defaultValueSql: "getdate()"),
                    NitEmpresa = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    delmrk = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: true, defaultValue: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEBGLSS_Empleados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WEBGLSS_Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nit = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: false),
                    DIV = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: false),
                    Nombre = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    CodigoLegacy = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    EmailPrincipal = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: false),
                    Estado = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: false),
                    IP = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    DB = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    KeyConnection = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    UrlWeb = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false),
                    Logo = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEBGLSS_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WEBGLSS_Estados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    delmrk = table.Column<string>(type: "VARCHAR(1)", maxLength: 1, nullable: true, defaultValue: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEBGLSS_Estados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WEBGLSS_Etiquetas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: true),
                    delmrk = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEBGLSS_Etiquetas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WEBGLSS_MatrizPQRSF",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NitEmpresa = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    FechaCierre = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "getdate()"),
                    FechaCierreReal = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "getdate()"),
                    Tipo = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true, defaultValue: "PQRSF Externa"),
                    Asunto = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    Descripcion = table.Column<string>(type: "VARCHAR(8000)", maxLength: 8000, nullable: false),
                    Etiquetas = table.Column<string>(type: "VARCHAR(300)", maxLength: 300, nullable: true),
                    IdEstado = table.Column<int>(type: "INT", maxLength: 20, nullable: false, defaultValue: 1),
                    IdPrioridad = table.Column<int>(type: "INT", maxLength: 20, nullable: false, defaultValue: 5),
                    IdSituacion = table.Column<int>(type: "int", nullable: false),
                    IdProceso = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IdContacto = table.Column<int>(type: "int", nullable: false),
                    NroIdeCli = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    NroIdResponsable = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true, defaultValue: "0000000000"),
                    NroIdPerfilo = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true, defaultValue: "0000000000"),
                    NroIdCerro = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true, defaultValue: "0000000000"),
                    Perfilacion = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEBGLSS_MatrizPQRSF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WEBGLSS_MenuRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idRol = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    CodMnu = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: true),
                    delmrk = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: true, defaultValue: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEBGLSS_MenuRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WEBGLSS_Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodMnu = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: true),
                    NomMnu = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Orden = table.Column<string>(type: "VARCHAR(3)", maxLength: 3, nullable: true),
                    NvlMnu = table.Column<string>(type: "VARCHAR(3)", maxLength: 3, nullable: true),
                    TpoMnu = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    DepMnu = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Controller = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Action = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    IcoMnu = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: true),
                    delmrk = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEBGLSS_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WEBGLSS_MenuUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NroIdUsr = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    CodMnu = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    delmrk = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: true, defaultValue: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEBGLSS_MenuUsuarios", x => new { x.Id, x.NroIdUsr, x.CodMnu });
                });

            migrationBuilder.CreateTable(
                name: "WEBGLSS_NotasPQRSF",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPQRSF = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "Datetime", nullable: false, defaultValueSql: "getdate()"),
                    Tipo = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: false, defaultValue: "Nota"),
                    Nota = table.Column<string>(type: "VARCHAR(1000)", maxLength: 1000, nullable: false),
                    NroIdeAutor = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    NitEmpresa = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEBGLSS_NotasPQRSF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WEBGLSS_Perfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodPerfil = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    NomPerfil = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    delmrk = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: true, defaultValue: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEBGLSS_Perfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WEBGLSS_Preguntas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomPregunta = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    NitEmpresa = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    delmrk = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEBGLSS_Preguntas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WEBGLSS_Prioridades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    delmrk = table.Column<string>(type: "VARCHAR(1)", maxLength: 1, nullable: true, defaultValue: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEBGLSS_Prioridades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WEBGLSS_Procesos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: true),
                    delmrk = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEBGLSS_Procesos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WEBGLSS_Respuestas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPregunta = table.Column<int>(type: "int", nullable: false),
                    IdPQRSF = table.Column<int>(type: "int", nullable: false),
                    Opcion = table.Column<bool>(type: "bit", nullable: true),
                    Observaciones = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    NitEmpresa = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    delmrk = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEBGLSS_Respuestas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WEBGLSS_Seguimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPQRSF = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "getdate()"),
                    NitEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observaciones = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEBGLSS_Seguimientos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WEBGLSS_SituacionesNoConformes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "VARCHAR(4)", maxLength: 4, nullable: true),
                    TipoSituacion = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    delmrk = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEBGLSS_SituacionesNoConformes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WEBGLSS_SolicitudClientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    TipDoc = table.Column<string>(type: "VARCHAR(5)", maxLength: 5, nullable: false),
                    NroIde = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    NombreCompleto = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    PrimerNombre = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    SegundoNombre = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: true),
                    PrimerApellido = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    SegundoApellido = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    Ciudad = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(type: "VARCHAR(90)", maxLength: 90, nullable: false),
                    Celular = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Telefono = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    NitEmpresa = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Estado = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: false, defaultValue: "1"),
                    delmrk = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: true, defaultValue: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEBGLSS_SolicitudClientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WEBGLSS_Terceros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    TipoDoc = table.Column<string>(type: "VARCHAR(5)", maxLength: 5, nullable: false),
                    NroId = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    NombreCompleto = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    PrimerNombre = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    SegundoNombre = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: true),
                    PrimerApellido = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    SegundoApellido = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    Ciudad = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(type: "VARCHAR(90)", maxLength: 90, nullable: false),
                    Celular = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Telefono = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    NitEmpresa = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Usuario = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: true),
                    delmrk = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: true, defaultValue: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEBGLSS_Terceros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WEBGLSS_TratamientosPQRSF",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPQRSF = table.Column<int>(type: "int", nullable: false),
                    Actividad = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    NroIdResponsable = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    FechaCumplimiento = table.Column<DateTime>(type: "date", nullable: false),
                    Observaciones = table.Column<string>(type: "text", nullable: true),
                    NitEmpresa = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Checked = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    FechaCheck = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "getdate()"),
                    EnvioCorreo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEBGLSS_TratamientosPQRSF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WEBGLSS_UsuarioEmpresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false),
                    NitEmpresa = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    NroIde = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEBGLSS_UsuarioEmpresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WEBGLSSS_Archivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodPQRSF = table.Column<int>(type: "Int", maxLength: 2, nullable: false),
                    Nombre = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    Ruta = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: true),
                    Url = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: true),
                    ContentType = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: true),
                    NitEmpresa = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    delmrk = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEBGLSSS_Archivos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WEBGLSS_Agentes");

            migrationBuilder.DropTable(
                name: "WEBGLSS_Clientes");

            migrationBuilder.DropTable(
                name: "WEBGLSS_Configuracion");

            migrationBuilder.DropTable(
                name: "WEBGLSS_ContactoClientes");

            migrationBuilder.DropTable(
                name: "WEBGLSS_Elementos");

            migrationBuilder.DropTable(
                name: "WEBGLSS_EmailConfiguracion");

            migrationBuilder.DropTable(
                name: "WEBGLSS_Empleados");

            migrationBuilder.DropTable(
                name: "WEBGLSS_Empresas");

            migrationBuilder.DropTable(
                name: "WEBGLSS_Estados");

            migrationBuilder.DropTable(
                name: "WEBGLSS_Etiquetas");

            migrationBuilder.DropTable(
                name: "WEBGLSS_MatrizPQRSF");

            migrationBuilder.DropTable(
                name: "WEBGLSS_MenuRoles");

            migrationBuilder.DropTable(
                name: "WEBGLSS_Menus");

            migrationBuilder.DropTable(
                name: "WEBGLSS_MenuUsuarios");

            migrationBuilder.DropTable(
                name: "WEBGLSS_NotasPQRSF");

            migrationBuilder.DropTable(
                name: "WEBGLSS_Perfiles");

            migrationBuilder.DropTable(
                name: "WEBGLSS_Preguntas");

            migrationBuilder.DropTable(
                name: "WEBGLSS_Prioridades");

            migrationBuilder.DropTable(
                name: "WEBGLSS_Procesos");

            migrationBuilder.DropTable(
                name: "WEBGLSS_Respuestas");

            migrationBuilder.DropTable(
                name: "WEBGLSS_Seguimientos");

            migrationBuilder.DropTable(
                name: "WEBGLSS_SituacionesNoConformes");

            migrationBuilder.DropTable(
                name: "WEBGLSS_SolicitudClientes");

            migrationBuilder.DropTable(
                name: "WEBGLSS_Terceros");

            migrationBuilder.DropTable(
                name: "WEBGLSS_TratamientosPQRSF");

            migrationBuilder.DropTable(
                name: "WEBGLSS_UsuarioEmpresas");

            migrationBuilder.DropTable(
                name: "WEBGLSSS_Archivos");
        }
    }
}