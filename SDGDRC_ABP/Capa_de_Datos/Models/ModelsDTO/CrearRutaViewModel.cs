using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Datos.Models.ModelsDTO
{
    public class CrearRutaViewModel
    {
        public RutaDTO RutaDTO { get; set; }
        public IEnumerable<SelectListItem> Coordinadores { get; set; }
        public IEnumerable<SelectListItem> Voluntarios { get; set; }
    }

}
