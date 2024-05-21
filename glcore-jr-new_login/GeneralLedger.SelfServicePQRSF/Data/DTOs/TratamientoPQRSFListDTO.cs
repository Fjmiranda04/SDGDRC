using System;
using System.ComponentModel.DataAnnotations;

namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class TratamientoPQRSFListDTO
    {
        public int Id { get; set; }
        public string Actividad { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaCumplimiento { get; set; }

        public int IdResponsable { get; set; }
        public string NombreResponsable { get; set; }
        public bool? Checked { get; set; }
        public DateTime FechaCheck { get; set; }
        public string Observaciones { get; set; }
    }
}