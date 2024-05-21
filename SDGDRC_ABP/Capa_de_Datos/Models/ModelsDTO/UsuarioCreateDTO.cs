using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Datos.Models.ModelsDTO
{
    public class UsuarioCreateDTO
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public string? Tipo { get; set; }
        public string? Contraseña { get; set; }
        public string? Ubicación { get; set; }
        public string? AreaResponsabilidad { get; set; } // Nueva propiedad para el área de responsabilidad
    }


}
