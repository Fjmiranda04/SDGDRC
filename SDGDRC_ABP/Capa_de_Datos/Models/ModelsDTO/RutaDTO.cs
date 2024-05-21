using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Datos.Models.ModelsDTO
{
    public class RutaDTO
    {
        public DateTime Fecha { get; set; }
        public int CoordinadorId { get; set; }
        public int VoluntarioId { get; set; }
       
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
    }
}
