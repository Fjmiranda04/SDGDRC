using Common;
using Common.Implements;
using GeneralLedger.SelfService.Web.Areas.Identity.Data.Repository;
using GeneralLedger.SelfService.Web.Areas.Identity.Data.Repository.Implements;
using GeneralLedger.SelfService.Web.Areas.Identity.Services;
using GeneralLedger.SelfService.Web.Areas.Identity.Services.Implements;
using GeneralLedger.SelfServiceCore.Data;
using GeneralLedger.SelfServiceCore.Data.Repositories;
using GeneralLedger.SelfServiceCore.Data.Repositories.Implements;
using GeneralLedger.SelfServiceCore.Data.Repositories.Profilers;
using GeneralLedger.SelfServiceCore.Data.Repositories.Profilers.Implements;
using GeneralLedger.SelfServiceCore.Data.Repositories.RepositoriesGL;
using GeneralLedger.SelfServiceCore.Data.Repositories.RepositoriesGL.Implements;
using GeneralLedger.SelfServiceCore.Services;
using GeneralLedger.SelfServiceCore.Services.Implements;
using GeneralLedger.SelfServiceCore.Services.Profilers;
using GeneralLedger.SelfServiceCore.Services.Profilers.Implements;
using GeneralLedger.SelfServiceCore.Services.ServicesGL;
using GeneralLedger.SelfServiceCore.Services.ServicesGL.Implements;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace GeneralLedger.SelfService.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configuracion de la conexion
            services.AddHttpContextAccessor();
            services.AddDbContext<SelfServiceContext>(Options =>
            {
                Options.UseSqlServer(Configuration.GetConnectionString("GLSELFSERVICE_KEY"));
                Options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            #region Repositories

            services.AddScoped<IPQRSFRepository, PQRSFRepository>();
            services.AddScoped<IPQRSFEstadoRepository, PQRSFEstadoRepository>();
            services.AddScoped<IPQRSFPrioridadRepository, PQRSFPrioridadRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ISituacionRepository, SituacionRepository>();
            services.AddScoped<IContactoClienteRepository, ContactoClienteRepository>();
            services.AddScoped<IArchivoRepository, ArchivoRepository>();
            services.AddScoped<IAgenteRepository, AgenteRepository>();
            services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
            services.AddScoped<IProcesoRepository, ProcesoRepository>();
            services.AddScoped<ITratamientoPQRSFRepository, TratamientoPQRSFRepository>();
            services.AddScoped<IEtiquetaRepository, EtiquetaRepository>();
            services.AddScoped<IElementoRepository, ElementoRepository>();
            services.AddScoped<ISeguimientoPQRSFRepository, SeguimientoPQRSFRepository>();
            services.AddScoped<IUsuarioEmpresaRepository, UsuarioEmpresaRepository>();
            services.AddScoped<IPerfilRepository, PerfilRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IMenuRolRepository, MenuRolRepository>();
            services.AddScoped<IMenuUsuarioRepository, MenuUsuarioRepository>();
            services.AddScoped<IPreguntaRepository, PreguntaRepository>();
            services.AddScoped<IRespuestaRepository, RespuestaRepository>();
            services.AddScoped<INotaPQRSFRepository, NotaPQRSFRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IConfiguracionRepository, ConfigurationRespository>();
            services.AddScoped<IEmailConfiguracionRepository, EmailConfiguracionRepository>();
            services.AddScoped<ITerceroRepository, TerceroRepository>();
            services.AddScoped<ISolicitudClienteRepository, SolicitudClienteRepository>();
            services.AddScoped<IProfilerRepository, ProfilerRepository>();

            services.AddScoped<IArticuloRepository, ArticuloRepository>();
            services.AddScoped<IServicioRepository, ServicioRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<ICotizacionRepository, CotizacionRepository>();
            services.AddScoped<ISolicitanteCtzRepository, SolicitanteCtzRepository>();
            services.AddScoped<IAnalisisVencimientoRepository, AnalisisVencimientoRepository>();
            services.AddScoped<IFichaTecnicaRepository, FichaTecnicaRepository>();
            services.AddScoped<IImputacionRepository, ImputacionRepository>();
            services.AddScoped<IPagoRepository, PagoRepository>();
            services.AddScoped<ITrabajoRepository, TrabajoRepository>();
            services.AddScoped<IAccPedidoRepository, AccPedidoRepository>();
            services.AddScoped<IAccglCotizaRepository, AccglCotizaRepository>();
            services.AddScoped<IOrdenRepository, OrdenRepository>();
            services.AddScoped<IAccglUsuarioRepository, AccglUsuariosRespository>();
            services.AddScoped<IProdependeRepository, ProdependeRepository>();
            services.AddScoped<IViewSubCentroCostoRepository, ViewSubCentroCostoRepository>();
            services.AddScoped<IGestionHumanaRepository, GestionHumanaRepository>();

            #endregion Repositories

            #region Services

            services.AddScoped<IPQRSFService, PQRSFService>();
            services.AddScoped<IPQRSFEstadoService, PQRSFEstadoService>();
            services.AddScoped<IPQRSFPrioridadService, PQRSFPrioridadService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ISituacionService, SituacionService>();
            services.AddScoped<IContactoClienteService, ContactoClienteService>();
            services.AddScoped<IArchivoService, ArchivoService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IAgenteService, AgenteService>();
            services.AddScoped<IEmpleadoService, EmpleadoService>();
            services.AddScoped<IProcesoService, ProcesoService>();
            services.AddScoped<ITratamientoPQRSFService, TratamientoPQRSFService>();
            services.AddScoped<IEtiquetaService, EtiquetaService>();
            services.AddScoped<IElementoService, ElementoService>();
            services.AddScoped<ISeguimientoPQRSFService, SeguimientoPQRSFService>();
            services.AddScoped<IUsuarioEmpresaService, UsuarioEmpresaService>();
            services.AddScoped<IPerfilService, PerfilService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IMenuRolService, MenuRolService>();
            services.AddScoped<IMenuUsuarioService, MenuUsuarioService>();
            services.AddScoped<IPreguntaService, PreguntaService>();
            services.AddScoped<IRespuestaService, RespuestaService>();
            services.AddScoped<INotaPQRSFService, NotaPQRSFService>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IConfiguracionService, ConfiguracionService>();
            services.AddScoped<IEmailConfiguracionService, EmailConfiguracionService>();
            services.AddScoped<ITerceroService, TerceroService>();
            services.AddScoped<ISolicitudClienteService, SolicitudClienteService>();
            services.AddScoped<IProfilerService, ProfilerService>();

            services.AddScoped<IArticuloService, ArticuloService>();
            services.AddScoped<IServicioService, ServicioService>();
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<ICotizacionService, CotizacionService>();
            services.AddScoped<ISolicitanteCtzService, SolicitanteCtzService>();
            services.AddScoped<IAnalisisVencimientoService, AnalisisVencimientoService>();
            services.AddScoped<IFichaTecnicaService, FichaTecnicaService>();
            services.AddScoped<IImputacionService, ImputacionService>();
            services.AddScoped<IPagoService, PagoService>();
            services.AddScoped<ITrabajoService, TrabajoService>();
            services.AddScoped<IAccPedidoService, AccPedidoService>();
            services.AddScoped<IAccglCotizaService, AccglCotizaService>();
            services.AddScoped<IOrdenService, OrdenService>();
            services.AddScoped<IAccglUsuarioService, AccglUsuarioService>();
            services.AddScoped<IProdependeService, ProdependeService>();
            services.AddScoped<IViewSubCentroCostoService, ViewSubCentroCostoService>();
            services.AddScoped<IGestionHumanaService, GestionHumanaService>();

            #endregion Services

            #region Resources

            services.AddScoped<IArchivoControl, ArchivoControl>();
            services.AddScoped<IAmazonUploader, AmazonUploader>();
            services.AddScoped<IMail, Mail>();

            #endregion Resources

            #region Others

            services.AddScoped<IGenericRepositoryIdentity, GenericRepositoryIdentity>();
            services.AddScoped<IGenericServiceIdentity, GenericServiceIdentity>();

            #endregion Others

            // AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            // --------------------------------------------------------
            services.AddLogging();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });

            //Carpeta de los archivos para convertir reportes a PDF
            Rotativa.AspNetCore.RotativaConfiguration.Setup(env.WebRootPath, "../Rotativa");
        }
    }
}