using System;

namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class CartaBancoShowDTO
    {
        public string NitEmpresa { get; set; } = "";
        public string NombreEmpresa { get; set; } = "";
        public string NombreEmpleado { get; set; } = "";
        public string Cedula { get; set; } = "";
        public string TipoContrato { get; set; } = "";
        public Decimal Sueldo { get; set; } = 0;
        public string Cargo { get; set; } = "";
        public string FechaIngreso { get; set; } = "";
        public string FechaRetiro { get; set; } = "";
        public string CuentaBanco { get; set; } = "";
        public string NombreBanco { get; set; } = "";
        public string CentroCosto { get; set; } = "";
        public string JefeRRHH { get; set; } = "";
        public string DireccionEmpresa { get; set; } = "";
        public string TelefonoEmpresa { get; set; } = "";
        public string EmailEmpresa { get; set; } = "";
        public string Fecha { get; set; } = "";
        public string Ciudad { get; set; } = "";
        public string Codigo { get; set; } = "";
        public string Version { get; set; } = "";
        public string FechaVigencia { get; set; } = "";
    }
}