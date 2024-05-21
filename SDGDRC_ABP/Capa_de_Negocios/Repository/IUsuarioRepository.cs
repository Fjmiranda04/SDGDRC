using Capa_de_Datos.Models;
using Capa_de_Datos.Models.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Negocios.Repository
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetByIdAsync(int id);
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task CrearUsuario(UsuarioCreateDTO usuarioDTO);

<<<<<<< HEAD
        Task<int> CountAsync();
=======
   //     Task<Usuario> ValidarCredencialesAsync(string correoElectronico, string contraseña);
>>>>>>> ba3530e52b780c9f309df0acce60ad2366138fa7
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(int id);
    }
}
