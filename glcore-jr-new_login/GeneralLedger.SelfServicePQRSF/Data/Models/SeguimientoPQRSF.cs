using System;

namespace GeneralLedger.SelfServiceCore.Data.Models
{
    public class SeguimientoPQRSF
    {
        public int Id { get; set; }
        public int IdPQRSF { get; set; }
        public DateTime Fecha { get; set; }
        public string NitEmpresa { get; set; }
        public string Observaciones { get; set; }
    }
}