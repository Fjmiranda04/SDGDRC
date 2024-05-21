using Capa_de_Datos.Models;
using Capa_de_Datos.Models.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Capa_de_Negocios.Repository
{
    public interface IRutaRepository
    {
        Task CrearRutaAsync(RutaDTO rutaDTO);
        Task<IEnumerable<RutaDTO>> ObtenerTodasLasRutasAsync();
<<<<<<< HEAD
        Task<int> CountAsync();
=======
>>>>>>> ba3530e52b780c9f309df0acce60ad2366138fa7
        Task<IEnumerable<CoordinadorDTO>> ObtenerCoordinadoresAsync();
        Task<IEnumerable<VoluntarioDTO>> ObtenerVoluntariosAsync();
    }
}
