using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Datos.Models.ViewModels
{
    public class RutaIndexViewModel
    {
        public DateTime Fecha { get; set; }
        public string NombreCoordinador { get; set; }
        public string NombreVoluntario { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
    }

}
