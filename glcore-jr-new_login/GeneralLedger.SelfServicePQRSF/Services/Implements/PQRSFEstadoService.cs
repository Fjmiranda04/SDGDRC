using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.Repositories;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class PQRSFEstadoService : GenericService<PQRSFEstado>, IPQRSFEstadoService
    {
        private readonly IPQRSFEstadoRepository pQRSFEstadoRepository;

        public PQRSFEstadoService(IPQRSFEstadoRepository pQRSFEstadoRepository) : base(pQRSFEstadoRepository)
        {
            this.pQRSFEstadoRepository = pQRSFEstadoRepository;
        }
    }
}