using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services
{
    public interface IServicioService : IGenericService<Servicio>
    {
        Task<IEnumerable<ServicioShowDTO>> GetServicios();
    }
}