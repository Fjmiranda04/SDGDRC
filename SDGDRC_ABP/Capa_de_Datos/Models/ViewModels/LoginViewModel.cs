using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Datos.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El campo correo electrónico es requerido.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo contraseña es requerido.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

}
