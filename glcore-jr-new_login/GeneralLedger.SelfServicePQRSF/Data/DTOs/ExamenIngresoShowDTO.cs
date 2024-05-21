namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class ExamenIngresoShowDTO
    {
        public string NombreEmpleado { get; set; }
        public string Cedula { get; set; }
        public string Cargo { get; set; }
        public string CentroCosto { get; set; }
        public string Fecha { get; set; }
        public string JefeRRHH { get; set; }
        public string Codigo { get; set; } = "";
        public string Version { get; set; } = "";
        public string FechaVigencia { get; set; } = "";
        public string NombreEmpresa { get; set; } = "";
        public string DireccionEmpresa { get; set; } = "";
        public string TelefonoEmpresa { get; set; } = "";
        public string EmailEmpresa { get; set; } = "";
        public string NitEmpresa { get; set; } = "";
    }
}