using System;
using System.ComponentModel.DataAnnotations;

namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class TratamientoPQRSFCreateDTO
    {
        public int Id { get; set; }

        [Required]
        public int IdPQRSF { get; set; }

        [Required]
        public string Actividad { get; set; }

        [Required]
        public string NroIdResponsable { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required]
        public DateTime FechaCumplimiento { get; set; }

        public string Observaciones { get; set; }
    }
}