using Capa_de_Datos.Models;
using Capa_de_Datos.Models.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Negocios.Repository
{
    
        public interface IAuthRepository
        {
        Task<Usuario> Login(string email, string password);
        Task<bool> UsuarioExiste(string email);

    }

}


