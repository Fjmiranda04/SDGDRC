using Capa_de_Datos.Models;
using Capa_de_Datos.Models.ModelsDTO;
using Capa_de_Negocios.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capa_de_Negocios.Service.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
        }

        public async Task<Usuario> ObtenerUsuarioPorId(int id)
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodosLosUsuarios()
        {
            return await _usuarioRepository.GetAllAsync();
        }

        public async Task CrearUsuario(UsuarioCreateDTO usuarioDTO)
        {
            await _usuarioRepository.CrearUsuario(usuarioDTO);
        }

        public async Task ActualizarUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }

            await _usuarioRepository.UpdateAsync(usuario);
        }

        public async Task EliminarUsuario(int id)
        {
            await _usuarioRepository.DeleteAsync(id);
        }
<<<<<<< HEAD
        public async Task<int> ContarUsuarioAsync()
        {
            return await _usuarioRepository.CountAsync();
        }
=======
/*
        public Task<Usuario> ValidarCredencialesAsync(string correoElectronico, string contraseña)
        {
            return _usuarioRepository.ValidarCredencialesAsync(correoElectronico, contraseña);
        }*/
>>>>>>> ba3530e52b780c9f309df0acce60ad2366138fa7
    }

}
