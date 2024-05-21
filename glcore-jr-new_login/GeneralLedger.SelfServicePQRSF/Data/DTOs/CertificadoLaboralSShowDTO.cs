using System;

namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class CertificadoLaboralSShowDTO
    {
        #region Certificado Laboral -Sueldo

        public string CTSNombreEmpleado { get; set; }
        public string CTSCedula { get; set; }
        public Decimal CTSSueldo { get; set; }
        public string CTSSueldoEscrito { get; set; }
        public string CTSTipoContrato { get; set; }
        public string CTSCargo { get; set; }
        public string CTSFechaIngreso { get; set; }
        public string CTSFechaRetiro { get; set; }
        public Decimal CTSSubSidioTransporte { get; set; }
        public Decimal CTSHorasExtras { get; set; }
        public Decimal CTSSueldoPromedio { get; set; }
        public Decimal CTSHorasExtraPromedio { get; set; }

        #endregion Certificado Laboral -Sueldo

        #region Certificado Ingreso y Cesantias

        public string Periodo { get; set; }
        public Decimal Salario { get; set; }
        public Decimal Cesantias { get; set; }
        public Decimal OtrosIng { get; set; }
        public Decimal TotalIng { get; set; }
        public Decimal Salud { get; set; }
        public Decimal Pension { get; set; }
        public Decimal PensionVoluntaria { get; set; }
        public Decimal Retencion { get; set; }

        #endregion Certificado Ingreso y Cesantias

        public string Logo { get; set; }
        public string NombreEmpresa { get; set; }
        public string NitEmpresa { get; set; }
        public string DireccionEmpresa { get; set; }
        public string Contelefono { get; set; }
        public string Conciudad { get; set; }
        public string NombreDepartamento { get; set; }
        public string RepresentanteLegal { get; set; }
        public string NitRepresentanteLegal { get; set; }
        public string DocumentoRepresentanteLegal { get; set; }
        public string CargoRepresentanteLegal { get; set; }
        public string FechaCertificado { get; set; }
    }
}