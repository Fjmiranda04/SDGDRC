using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.Repositories;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class PQRSFPrioridadService : GenericService<PQRSFPrioridad>, IPQRSFPrioridadService
    {
        private readonly IPQRSFPrioridadRepository pQRSFPrioridadRepository;

        public PQRSFPrioridadService(IPQRSFPrioridadRepository pQRSFPrioridadRepository) : base(pQRSFPrioridadRepository)
        {
            this.pQRSFPrioridadRepository = pQRSFPrioridadRepository;
        }
    }
}