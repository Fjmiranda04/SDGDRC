using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories
{
    public interface IServicioRepository : IGenericRepository<Servicio>
    {
        Task<IEnumerable<ServicioShowDTO>> GetServicios();
    }
}