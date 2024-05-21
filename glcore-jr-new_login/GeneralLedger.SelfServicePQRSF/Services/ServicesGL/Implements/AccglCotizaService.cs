using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using GeneralLedger.SelfServiceCore.Data.Repositories.RepositoriesGL;
using GeneralLedger.SelfServiceCore.Services.Implements;

namespace GeneralLedger.SelfServiceCore.Services.ServicesGL.Implements
{
    public class AccglCotizaService : GenericService<AccglCotiza>, IAccglCotizaService
    {
        private readonly IAccglCotizaRepository accglCotizaRepository;

        public AccglCotizaService(IAccglCotizaRepository accglCotizaRepository) : base(accglCotizaRepository)
        {
            this.accglCotizaRepository = accglCotizaRepository;
        }
    }
}