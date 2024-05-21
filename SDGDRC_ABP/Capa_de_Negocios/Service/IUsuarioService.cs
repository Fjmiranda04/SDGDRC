using Capa_de_Datos.Models;
using Capa_de_Datos.Models.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Negocios.Service
{
    public interface IUsuarioService
    {
        Task<Usuario> ObtenerUsuarioPorId(int id);
        Task<IEnumerable<Usuario>> ObtenerTodosLosUsuarios();
        Task CrearUsuario(UsuarioCreateDTO usuarioDTO);
        Task ActualizarUsuario(Usuario usuario);
        Task EliminarUsuario(int id);

<<<<<<< HEAD
        Task<int> ContarUsuarioAsync();
=======
       // Task<Usuario> ValidarCredencialesAsync(string correoElectronico, string contraseña);
>>>>>>> ba3530e52b780c9f309df0acce60ad2366138fa7
    }
}
