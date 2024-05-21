using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class PagoService : GenericService<Pago>, IPagoService
    {
        private readonly IPagoRepository pagoRepository;

        public PagoService(IPagoRepository pagoRepository) : base(pagoRepository)
        {
            this.pagoRepository = pagoRepository;
        }

        public async Task<IEnumerable<Pago>> GetPagos(string nroFactura)
        {
            return await pagoRepository.GetPagos(nroFactura);
        }
    }
}