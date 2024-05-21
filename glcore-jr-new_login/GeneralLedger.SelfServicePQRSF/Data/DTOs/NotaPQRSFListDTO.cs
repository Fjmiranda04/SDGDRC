using System;

namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class NotaPQRSFListDTO
    {
        public int Id { get; set; }
        public int IdPQRSF { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public string Nota { get; set; }
        public string Autor { get; set; }
    }
}