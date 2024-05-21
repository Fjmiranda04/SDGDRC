using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using GeneralLedger.SelfServiceCore.Data.Repositories;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class TerceroService : GenericService<AccglTer>, ITerceroService
    {
        private readonly ITerceroRepository terceroRepository;

        public TerceroService(ITerceroRepository terceroRepository) : base(terceroRepository)
        {
            this.terceroRepository = terceroRepository;
        }
    }
}