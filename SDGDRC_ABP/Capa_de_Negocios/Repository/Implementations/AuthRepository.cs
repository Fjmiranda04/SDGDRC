using Capa_de_Datos.Data;
using Capa_de_Datos.Models;
using Capa_de_Datos.Models.ModelsDTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Negocios.Repository.Implementations
{
    public class AuthRepository : IAuthRepository
    {
        private readonly SdgdrcContext _context;

        public AuthRepository(SdgdrcContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Login(string email, string password)
        {
            // Buscar el usuario por su correo electrónico en la base de datos
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

            if (usuario == null)
            {
                // El usuario no existe
                return null;
            }

            // Obtener las credenciales del usuario
            var credenciales = await _context.Credenciales.FirstOrDefaultAsync(c => c.IdUsuario == usuario.IdUsuario);

            if (credenciales == null)
            {
                // No se encontraron credenciales para el usuario
                return null;
            }

            // Verificar la contraseña
            if (!VerificarPasswordHash(password, credenciales.Contraseña))
            {
                // La contraseña no es válida
                return null;
            }

            // El usuario y la contraseña son válidos
            return usuario;
        }

        public async Task<bool> UsuarioExiste(string email)
        {
            // Verificar si existe un usuario con el correo electrónico dado
            return await _context.Usuarios.AnyAsync(u => u.Email == email);
        }

        // Método para verificar la contraseña
        private bool VerificarPasswordHash(string password, string passwordHash)
        {
            // Comparar la contraseña proporcionada con la contraseña almacenada
            return password == passwordHash;
        }
<<<<<<< HEAD

        public async Task<int> CountAsync()
        {
            return await _context.Ruta.CountAsync();
        }
=======
>>>>>>> ba3530e52b780c9f309df0acce60ad2366138fa7
    }

}
