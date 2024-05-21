using System;

namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class ContratoLaboralShowDTO
    {
        public string NombreEmpresa { get; set; } = "";
        public string NitEmpresa { get; set; } = "";
        public string DireccionEmpresa { get; set; } = "";
        public string NombreEmpleado { get; set; } = "";
        public string CedulaEmpleado { get; set; } = "";
        public string DireccionEmpleado { get; set; } = "";
        public string Telefono { get; set; } = "";
        public string FechaNacimientoEmpleado { get; set; } = "";
        public string ProfesionEmpleado { get; set; } = "";
        public Decimal SalarioBasico { get; set; } = 0;
        public string Cargo { get; set; } = "";
        public string PeriodoPago { get; set; } = "";
        public string FechaInicio { get; set; } = "";
        public string FechaFin { get; set; } = "";
        public string CiudadContratacion { get; set; } = "";
        public string DepartamentoContratamento { get; set; } = "";
        public string TipoContrato { get; set; } = "";
        public string CiudadFirma { get; set; } = "";
        public string DepartamentoFirma { get; set; } = "";
        public string FechaFirma { get; set; } = "";
        public string TipoDoc { get; set; } = "";
    }
}