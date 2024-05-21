using System;

namespace GeneralLedger.SelfServiceCore.Data.ModelsGL
{
    public class EmpleadoNovedad
    {
        public string CodigoEmpleado { get; set; }
        public string TipoDocEmpleado { get; set; }
        public string CedulaEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public string CargoEmpleado { get; set; }
        public string EpsEmpleado { get; set; }
        public string CesantiaEmpleado { get; set; }
        public string PensionEmpleado { get; set; }
        public string CajaCompensacion { get; set; }
        public decimal SueldoEmpleado { get; set; }
        public decimal SubsidioTransporteEmpleado { get; set; }
        public string CorreoEmpleado { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}