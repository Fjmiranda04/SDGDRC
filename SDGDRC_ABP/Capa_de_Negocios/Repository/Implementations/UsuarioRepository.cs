using Capa_de_Datos.Models;
using Capa_de_Datos.Models.ModelsDTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Capa_de_Datos.Data;


namespace Capa_de_Negocios.Repository.Implementations
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SdgdrcContext _dbContext;

        public UsuarioRepository(SdgdrcContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _dbContext.Usuarios.FindAsync(id);
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

<<<<<<< HEAD
        
=======
        /*
         public async Task CrearUsuario(UsuarioCreateDTO usuarioDTO)
         {
             if (usuarioDTO.Tipo == "Coordinador")
             {
                 await _dbContext.Database.ExecuteSqlInterpolatedAsync(
                     $@" EXEC CrearUsuario 
             @Nombre = {usuarioDTO.Nombre}, 
             @Apellido = {usuarioDTO.Apellido}, 
             @Email = {usuarioDTO.Email}, 
             @Tipo = {usuarioDTO.Tipo}, 
             @Contraseña = {usuarioDTO.Contraseña},
             @Area_de_Responsabilidad = {usuarioDTO.Area_de_Responsabilidad}
         ");
             }
             else
             {
                 await _dbContext.Database.ExecuteSqlInterpolatedAsync(
                     $@" EXEC CrearUsuario 
             @Nombre = {usuarioDTO.Nombre}, 
             @Apellido = {usuarioDTO.Apellido}, 
             @Email = {usuarioDTO.Email}, 
             @Tipo = {usuarioDTO.Tipo}, 
             @Contraseña = {usuarioDTO.Contraseña}
         ");
             }
         }
        */
>>>>>>> ba3530e52b780c9f309df0acce60ad2366138fa7

        public async Task CrearUsuario(UsuarioCreateDTO usuarioDTO)
        {
            if (usuarioDTO.Tipo == "Voluntario")
            {
                await _dbContext.Database.ExecuteSqlInterpolatedAsync(
                    $@" EXEC CrearUsuario 
            @Nombre = {usuarioDTO.Nombre}, 
            @Apellido = {usuarioDTO.Apellido}, 
            @Email = {usuarioDTO.Email}, 
            @Tipo = {usuarioDTO.Tipo}, 
            @Contraseña = {usuarioDTO.Contraseña},
            @Ubicación = {usuarioDTO.Ubicación}
        ");
            }
            else if (usuarioDTO.Tipo == "Coordinador")
            {
                await _dbContext.Database.ExecuteSqlInterpolatedAsync(
                    $@" EXEC CrearUsuario 
            @Nombre = {usuarioDTO.Nombre}, 
            @Apellido = {usuarioDTO.Apellido}, 
            @Email = {usuarioDTO.Email}, 
            @Tipo = {usuarioDTO.Tipo}, 
            @Contraseña = {usuarioDTO.Contraseña},
            @AreaResponsabilidad = {usuarioDTO.AreaResponsabilidad}
        ");
            }
            else if (usuarioDTO.Tipo == "Administrador")
            {
                await _dbContext.Database.ExecuteSqlInterpolatedAsync(
                    $@" EXEC CrearUsuario 
            @Nombre = {usuarioDTO.Nombre}, 
            @Apellido = {usuarioDTO.Apellido}, 
            @Email = {usuarioDTO.Email}, 
            @Tipo = {usuarioDTO.Tipo}, 
            @Contraseña = {usuarioDTO.Contraseña}
        ");
            }
        }
<<<<<<< HEAD
        public async Task<int> CountAsync()
        {
            return await _dbContext.Usuarios.CountAsync();
        }
=======
/*
        public async Task<Usuario> ValidarCredencialesAsync(string correoElectronico, string contraseña)
        {
            var usuario = await _dbContext.Usuarios
                .FirstOrDefaultAsync(u => u.Email == correoElectronico);

            if (usuario != null)
            {
                // Obtener las credenciales del usuario
                var credenciales = await _dbContext.Credenciales
                    .FirstOrDefaultAsync(c => c.IdUsuario == usuario.IdUsuario);

                // Verificar la contraseña
                if (credenciales != null && credenciales.Contraseña == contraseña)
                {
                    return usuario;
                }
            }

            return null;
        }

        */







>>>>>>> ba3530e52b780c9f309df0acce60ad2366138fa7
        public async Task UpdateAsync(Usuario usuario)
        {
            _dbContext.Entry(usuario).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var usuario = await GetByIdAsync(id);
            if (usuario != null)
            {
                _dbContext.Usuarios.Remove(usuario);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
