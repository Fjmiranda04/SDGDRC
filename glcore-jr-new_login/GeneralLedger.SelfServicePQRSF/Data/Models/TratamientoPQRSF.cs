using System;

namespace GeneralLedger.SelfServiceCore.Data.Models
{
    public class TratamientoPQRSF
    {
        public int Id { get; set; }
        public int IdPQRSF { get; set; }
        public string Actividad { get; set; }
        public string NroIdResponsable { get; set; }
        public DateTime FechaCumplimiento { get; set; }
        public string Observaciones { get; set; }
        public string NitEmpresa { get; set; }
        public bool? Checked { get; set; }
        public DateTime FechaCheck { get; set; }
        public bool? EnvioCorreo { get; set; }
    }
}