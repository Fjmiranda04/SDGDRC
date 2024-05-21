using Capa_de_Datos.Models;
using Capa_de_Datos.Models.ModelsDTO;
using Capa_de_Negocios.Repository;
using Capa_de_Negocios.Repository.Implementations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Negocios.Service.Implementations
{
    public class RutaService : IRutaService
    {
        private readonly IRutaRepository _rutaRepository;

        public RutaService(IRutaRepository rutaRepository)
        {
            _rutaRepository = rutaRepository;
        }


        public async Task<IEnumerable<RutaDTO>> ObtenerTodasLasRutasAsync()
        {
            return await _rutaRepository.ObtenerTodasLasRutasAsync();
        }

        public async Task CrearRutaAsync(RutaDTO rutaDTO)
        {
            try
            {
                // Delegar la creación de la ruta al repositorio
                await _rutaRepository.CrearRutaAsync(rutaDTO);
            }
            catch (Exception ex)
            {
                // Manejar excepciones aquí (registrando, lanzando una excepción personalizada, etc.)
                throw new Exception("Error en el servicio al crear la ruta", ex);
            }
        }
        public async Task<IEnumerable<CoordinadorDTO>> ObtenerCoordinadoresAsync()
        {
            return await _rutaRepository.ObtenerCoordinadoresAsync();
        }


        public async Task<IEnumerable<VoluntarioDTO>> ObtenerVoluntariosAsync()
        {
            return await _rutaRepository.ObtenerVoluntariosAsync();
        }

<<<<<<< HEAD
        public async Task<int> ContarRutasAsync()
        {
            return await _rutaRepository.CountAsync();
        }
=======
>>>>>>> ba3530e52b780c9f309df0acce60ad2366138fa7

    }
}
