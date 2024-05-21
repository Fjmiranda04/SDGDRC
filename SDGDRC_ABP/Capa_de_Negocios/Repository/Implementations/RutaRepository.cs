using Capa_de_Datos.Data;
using Capa_de_Datos.Models;
using Capa_de_Datos.Models.ModelsDTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Negocios.Repository.Implementations
{
    public class RutaRepository : IRutaRepository
    {
        private readonly SdgdrcContext _dbContext;

        public RutaRepository(SdgdrcContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CrearRutaAsync(RutaDTO rutaDTO)
        {
            try
            {
                // Ejecutar el procedimiento almacenado para crear la ruta
                await _dbContext.Database.ExecuteSqlInterpolatedAsync($@"
                EXEC CrearRuta 
                    @Fecha = {rutaDTO.Fecha}, 
                    @CoordinadorID = {rutaDTO.CoordinadorId}, 
                    @VoluntarioID = {rutaDTO.VoluntarioId}, 
                    @Latitud = {rutaDTO.Latitud}, 
                    @Longitud = {rutaDTO.Longitud}");
            }
            catch (Exception ex)
            {
                // Manejar excepciones aquí (registrando, lanzando una excepción personalizada, etc.)
                throw new Exception("Error al crear la ruta", ex);
            }


        }
        public async Task<IEnumerable<RutaDTO>> ObtenerTodasLasRutasAsync()
        {
            // Obtener todas las rutas desde la base de datos
            var rutas = await _dbContext.Ruta
                .Select(r => new RutaDTO
                {
                    Fecha = r.Fecha,
                    CoordinadorId = r.CoordinadorAsociado,
                    VoluntarioId = r.VoluntariosAsociados,
                    Latitud = r.Latitud,
                    Longitud = r.Longitud
                })
                .ToListAsync();

            return rutas;
        }
        public async Task<IEnumerable<CoordinadorDTO>> ObtenerCoordinadoresAsync()
        {
            return await _dbContext.Usuarios
                .Where(u => u.Tipo == "Coordinador")
                .Select(u => new CoordinadorDTO
                {
                    IdCoordinador = u.IdUsuario,
                    NombreCompleto = u.Nombre + " " + u.Apellido
                })
                .ToListAsync();
        }


        public async Task<IEnumerable<VoluntarioDTO>> ObtenerVoluntariosAsync()
        {
            return await _dbContext.Usuarios
                .Where(u => u.Tipo == "Voluntario")
                .Select(u => new VoluntarioDTO
                {
                    IdVoluntario = u.IdUsuario,
                    NombreCompleto = u.Nombre + " " + u.Apellido
                })
                .ToListAsync();
        }

<<<<<<< HEAD
        public async Task<int> CountAsync()
        {
            return await _dbContext.Ruta.CountAsync();
        }

=======
>>>>>>> ba3530e52b780c9f309df0acce60ad2366138fa7
    }
}
