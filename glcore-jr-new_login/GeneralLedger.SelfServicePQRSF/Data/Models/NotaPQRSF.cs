using System;

namespace GeneralLedger.SelfServiceCore.Data.Models
{
    public class NotaPQRSF
    {
        public int Id { get; set; }
        public int IdPQRSF { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public string Nota { get; set; }
        public string NroIdeAutor { get; set; }
        public string NitEmpresa { get; set; }
    }
}