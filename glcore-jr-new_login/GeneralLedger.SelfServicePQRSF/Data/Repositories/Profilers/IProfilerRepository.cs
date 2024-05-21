namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers
{
    public interface IProfilerRepository
    {
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