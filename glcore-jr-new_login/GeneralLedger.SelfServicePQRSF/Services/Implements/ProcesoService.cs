using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.Repositories;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class ProcesoService : GenericService<Proceso>, IProcesoService
    {
        private readonly IProcesoRepository procesoRepository;

        public ProcesoService(IProcesoRepository procesoRepository) : base(procesoRepository)
        {
            this.procesoRepository = procesoRepository;
        }
    }
}