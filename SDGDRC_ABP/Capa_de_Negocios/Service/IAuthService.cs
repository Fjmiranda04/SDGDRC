using Capa_de_Datos.Models;
using Capa_de_Datos.Models.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Negocios.Service
{
    public interface IAuthService
    {
        Task<string> GenerarTokenAcceso(Usuario usuario);
        Task<bool> ValidarTokenAcceso(string token);
        Task<Usuario> Login(string email, string password);
    }
}
