using Capa_de_Datos.Models;
using Capa_de_Datos.Models.ModelsDTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Negocios.Service
{
    public interface IRutaService
    {
        Task CrearRutaAsync(RutaDTO rutaDTO);
        Task<IEnumerable<RutaDTO>> ObtenerTodasLasRutasAsync();
        Task<IEnumerable<CoordinadorDTO>> ObtenerCoordinadoresAsync();
        Task<IEnumerable<VoluntarioDTO>> ObtenerVoluntariosAsync();
<<<<<<< HEAD
        Task<int> ContarRutasAsync();
=======
>>>>>>> ba3530e52b780c9f309df0acce60ad2366138fa7
    }
}
