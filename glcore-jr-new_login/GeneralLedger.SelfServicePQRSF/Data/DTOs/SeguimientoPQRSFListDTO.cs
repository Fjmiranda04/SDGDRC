using System;
using System.ComponentModel.DataAnnotations;

namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class SeguimientoPQRSFListDTO
    {
        public int Id { get; set; }
        public int IdPQRSF { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fecha { get; set; }

        public string Observaciones { get; set; }
    }
}