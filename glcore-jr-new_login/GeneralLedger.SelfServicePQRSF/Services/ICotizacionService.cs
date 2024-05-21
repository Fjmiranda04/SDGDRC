using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services
{
    public interface ICotizacionService : IGenericService<AccglCotiza>
    {
        Task<IEnumerable<CotizacionListDTO>> GetCotizaciones();
    }
}
