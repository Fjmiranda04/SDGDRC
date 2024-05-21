using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using GeneralLedger.SelfServiceCore.Data.Repositories;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class TrabajoService : GenericService<Trabajo>, ITrabajoService
    {
        private readonly ITrabajoRepository trabajoRepository;

        public TrabajoService(ITrabajoRepository trabajoRepository) : base(trabajoRepository)
        {
            this.trabajoRepository = trabajoRepository;
        }
    }
}