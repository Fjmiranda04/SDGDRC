using System;
using System.ComponentModel.DataAnnotations;

namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class SeguimientoPQRSFCreateDTO
    {
        public int Id { get; set; }

        [Required]
        public int IdPQRSF { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public string Observaciones { get; set; }
    }
}