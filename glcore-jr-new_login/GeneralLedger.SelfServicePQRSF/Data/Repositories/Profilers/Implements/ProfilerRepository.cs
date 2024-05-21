using Microsoft.Extensions.Configuration;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers.Implements
{
    public class ProfilerRepository : IProfilerRepository
    {
        private readonly SelfServiceContext Context;
        private readonly IConfiguration configuration;

        public ProfilerRepository(SelfServiceContext Context, IConfiguration configuration)
        {
            this.Context = Context;
            this.configuration = configuration;

            ProCiudades = new CiudadRepository(Context,configuration);
            ProEtiquetas = new ProEtiquetaRepository(Context, configuration);
            ProPreguntas = new ProPreguntaRepository(Context, configuration);
            ProAreas = new ProAreaRepository(Context, configuration);
            ProAccglter = new ProAccglterRepository(Context, configuration);
            ProCliente = new ProClienteRepository(Context, configuration);
            ProAgentes = new ProAgenteRepository(Context, configuration);
            ProPqrsf = new ProPqrsfRepository(Context, configuration);
            ProConfiguracion = new ProConfiguracionRepository(Context, configuration);
            ProAccglpro = new ProAccglproRepository(Context, configuration);
            ProGestionHumana = new ProGestionHumanaRepository(Context, configuration);
            ProEmpresa = new ProEmpresaRepository(Context, configuration);
            proSolicitudUsuario = new ProSolicitudUsuarioRepository(Context, configuration);
            proUserManager = new ProUserManagerRepository(Context, configuration);
            ProProfilerGeneric = new ProfilerGenericRepository(Context, configuration);
            proContacto = new ProContactoRepository(Context, configuration);
            ProMenus = new ProMenuRepository(Context, configuration);
            ProEmpleado = new ProEmpleadoRepository(Context, configuration);
            ProApi = new ProApiRepository(Context, configuration);
        }

        public ICiudadRepository ProCiudades { get; set; }
        public IProEtiquetaRepository ProEtiquetas { get; set; }
        public IProPreguntaRepository ProPreguntas { get; set; }
        public IProAreaRepository ProAreas { get; set; }
        public IProAccglterRepository ProAccglter { get; set; }
        public IProClienteRepository ProCliente { get; set; }
        public IProAgenteRepository ProAgentes { get; set; }
        public IProPqrsfRepository ProPqrsf { get; set; }
        public IProConfiguracionRespository ProConfiguracion { get; set; }
        public IProAccglproRepository ProAccglpro { get; set; }
        public IProGestionHumanaRepository ProGestionHumana { get; set; }
        public IProEmpresaRepository ProEmpresa { get; set; }
        public IProSolicitudUsuarioRepository proSolicitudUsuario { get; set; }
        public IProUserManagerRepository proUserManager { get; set; }
        public IProfilerGenericRepository ProProfilerGeneric { get; set; }
        public IProContactoRepository proContacto { get; set; }
        public IProMenuRepository ProMenus { get; set; }
        public IProEmpleadoRepository ProEmpleado { get; set; }
        public IProApiRepository ProApi { get; set; }
    }
}