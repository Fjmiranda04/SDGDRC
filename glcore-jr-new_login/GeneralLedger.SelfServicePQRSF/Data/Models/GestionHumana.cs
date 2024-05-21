using System;

namespace GeneralLedger.SelfServiceCore.Data.Models
{
    public class GestionHumana
    {
        #region Certificado Laboral -Sueldo

        public string CTSNombreEmpleado { get; set; }
        public Decimal CTSSueldo { get; set; }
        public string CTSCargo { get; set; }
        public DateTime CTSFechaIngreso { get; set; }
        public DateTime CTSFechaRetiro { get; set; }
        public Decimal CTSSubSidioTransporte { get; set; }
        public Decimal CTSHorasExtras { get; set; }

        #endregion Certificado Laboral -Sueldo

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
    }
}