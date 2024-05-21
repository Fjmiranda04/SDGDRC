using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories
{
    public interface ISeguimientoPQRSFRepository : IGenericRepository<SeguimientoPQRSF>
    {
        Task<IEnumerable<SeguimientoPQRSFListDTO>> GetAllSeguimientoById(int? id);
    }
}