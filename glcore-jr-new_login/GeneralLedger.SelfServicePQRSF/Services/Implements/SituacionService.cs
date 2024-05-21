using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.Repositories;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class SituacionService : GenericService<Situacion>, ISituacionService
    {
        private readonly ISituacionRepository situacionRepository;

        public SituacionService(ISituacionRepository situacionRepository) : base(situacionRepository)
        {
            this.situacionRepository = situacionRepository;
        }
    }
}