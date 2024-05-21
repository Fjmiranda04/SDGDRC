using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping;
using GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMappingGL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GeneralLedger.SelfServiceCore.Data
{
    public class SelfServiceContext : DbContext
    {
        private IConfiguration Configuration => new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();

        private string CurrentConnectionString { get; set; }

        public SelfServiceContext(DbContextOptions<SelfServiceContext> options) : base(options)
        {
        }

        #region ContextBD

        public DbSet<PQRSF> MatrizPQRSF { get; set; }
        public DbSet<Situacion> SituacionesNoConformes { get; set; }
        public DbSet<PQRSFEstado> PQRSFEstados { get; set; }
        public DbSet<PQRSFPrioridad> PQRSFPrioridades { get; set; }
        public DbSet<TratamientoPQRSF> TratamientoPQRSFs { get; set; }
        public DbSet<SeguimientoPQRSF> SeguimientoPQRSFs { get; set; }
        public DbSet<NotaPQRSF> NotasPQRSFs { get; set; }
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<Respuesta> Respuestas { get; set; }
        public DbSet<ContactoCliente> ContactosCliente { get; set; }
        public DbSet<Agente> Agentes { get; set; }
        public DbSet<Models.Empleado> Empleados { get; set; }
        public DbSet<Proceso> Procesos { get; set; }
        public DbSet<Etiqueta> Etiquetas { get; set; }
        public DbSet<Elemento> Elementos { get; set; }
        public DbSet<Perfil> Perfiles { get; set; }
        public DbSet<UsuarioEmpresa> UsuarioEmpresas { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuRol> MenuRoles { get; set; }
        public DbSet<Models.MenuUsuario> MenuUsuarios { get; set; }
        public DbSet<Tercero> Terceros { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Configuracion> Configuraciones { get; set; }
        public DbSet<EmailConfiguracion> EmailConfiguraciones { get; set; }
        public DbSet<Archivo> Archivos { get; set; }
        public DbSet<SolicitudCliente> SolicitudClientes { get; set; }

        #endregion ContextBD

        #region ContextGL

        public DbSet<AccglPro> AccglPro { get; set; }
        public DbSet<AccglTer> accglTer { get; set; }
        public DbSet<ModelsGL.Cliente> Clientes { get; set; }
        public DbSet<AccglUsuario> UsuariosGL { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Prociudad> Prociudades { get; set; }
        public DbSet<ProPais> ProPaises { get; set; }
        public DbSet<Trabajo> Trabajos { get; set; }
        public DbSet<AccPedido> AccPedidos { get; set; }
        public DbSet<AccglCotiza> AccglCotiza { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Prodepende> Prodepende { get; set; }
        public DbSet<ViewSubCentroCosto> ViewSubCentroCosto { get; set; }
        public DbSet<Proceso> ProEtiquetas { get; set; }

        #endregion ContextGL

        #region Configuraciones

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();
            CurrentConnectionString = ConnectionTools.GetKeyConnectionString();

            if (string.IsNullOrEmpty(CurrentConnectionString))
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("GLSELFSERVICE_USERAPP"));
            }
            else
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("GLSELFSERVICE_USERAPP"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PQRSFMapping());
            modelBuilder.ApplyConfiguration(new PQRSFEstadoMapping());
            modelBuilder.ApplyConfiguration(new PQRSFPrioridadMapping());
            modelBuilder.ApplyConfiguration(new SituacionMapping());
            modelBuilder.ApplyConfiguration(new ContactoClienteMapping());
            modelBuilder.ApplyConfiguration(new ArchivoMapping());
            modelBuilder.ApplyConfiguration(new AgenteMapping());
            modelBuilder.ApplyConfiguration(new EmpleadoMapping());
            modelBuilder.ApplyConfiguration(new TratamientoPQRSFMapping());
            modelBuilder.ApplyConfiguration(new EtiquetaMapping());
            modelBuilder.ApplyConfiguration(new ElementoMapping());
            modelBuilder.ApplyConfiguration(new SeguimientoPQRSFMapping());
            modelBuilder.ApplyConfiguration(new PerfilMapping());
            modelBuilder.ApplyConfiguration(new UsuarioEmpresaMapping());
            modelBuilder.ApplyConfiguration(new MenuMapping());
            modelBuilder.ApplyConfiguration(new MenuRolMapping());
            modelBuilder.ApplyConfiguration(new MenuUsuarioMapping());
            modelBuilder.ApplyConfiguration(new PreguntaMapping());
            modelBuilder.ApplyConfiguration(new RespuestaMapping());
            modelBuilder.ApplyConfiguration(new NotaPQRSFMapping());
            modelBuilder.ApplyConfiguration(new TerceroMapping());
            modelBuilder.ApplyConfiguration(new EmpresaMapping());
            modelBuilder.ApplyConfiguration(new ConfiguracionMapping());
            modelBuilder.ApplyConfiguration(new EmailConfiguracionMapping());
            modelBuilder.ApplyConfiguration(new SolicitudClienteMapping());
            modelBuilder.ApplyConfiguration(new ProcesoMapping());

            #region Standalones

            modelBuilder.ApplyConfiguration(new ArticuloMapping());
            modelBuilder.ApplyConfiguration(new ServicioMapping());
            modelBuilder.ApplyConfiguration(new ConsecutivoMapping());
            modelBuilder.ApplyConfiguration(new PedidoMapping());
            modelBuilder.ApplyConfiguration(new AnalisisVencimientoMapping());
            modelBuilder.ApplyConfiguration(new FichaTecnicaMapping());
            modelBuilder.ApplyConfiguration(new ImputacionMapping());
            modelBuilder.ApplyConfiguration(new PagoMapping());

            #endregion Standalones

            #region GL

            modelBuilder.ApplyConfiguration(new AccglProMapping());
            modelBuilder.ApplyConfiguration(new AccglTerMapping());
            modelBuilder.ApplyConfiguration(new Persistence.EntitiesMappingGL.ClienteMapping());
            modelBuilder.ApplyConfiguration(new SucursalMapping());
            modelBuilder.ApplyConfiguration(new ProciudadMapping());
            modelBuilder.ApplyConfiguration(new ProPaisMapping());
            modelBuilder.ApplyConfiguration(new TrabajoMapping());
            modelBuilder.ApplyConfiguration(new AccPedidoMapping());
            modelBuilder.ApplyConfiguration(new AccglCotizaMapping());
            modelBuilder.ApplyConfiguration(new OrdenMapping());
            modelBuilder.ApplyConfiguration(new AccglUsuarioMapping());
            modelBuilder.ApplyConfiguration(new ProdependeMapping());
            modelBuilder.ApplyConfiguration(new ViewSubCentroCostoMapping());
            modelBuilder.ApplyConfiguration(new ProEtiquetaMapping());

            #endregion GL
        }

        #endregion Configuraciones
    }
}