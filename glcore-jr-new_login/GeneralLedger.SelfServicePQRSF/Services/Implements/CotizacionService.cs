using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using GeneralLedger.SelfServiceCore.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class CotizacionService : GenericService<AccglCotiza>, ICotizacionService
    {
        private readonly ICotizacionRepository cotizacionRepository;

        public CotizacionService(ICotizacionRepository cotizacionRepository) : base(cotizacionRepository)
        {
            this.cotizacionRepository = cotizacionRepository;
        }

        public async Task<IEnumerable<CotizacionListDTO>> GetCotizaciones()
        {
            return await cotizacionRepository.GetCotizaciones();
        }
    }
}
