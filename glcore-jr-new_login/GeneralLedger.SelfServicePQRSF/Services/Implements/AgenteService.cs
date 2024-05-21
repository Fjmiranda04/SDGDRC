using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class AgenteService : GenericService<Agente>, IAgenteService
    {
        private readonly IAgenteRepository agenteRepository;

        public AgenteService(IAgenteRepository agenteRepository) : base(agenteRepository)
        {
            this.agenteRepository = agenteRepository;
        }

        public Task<IEnumerable<Agente>> GetAllAgentes()
        {
            return agenteRepository.GetAllAgentes();
        }

        public async Task<Agente> GetAgenteByNroId(string nroId)
        {
            return await agenteRepository.GetAgenteByNroId(nroId);
        }
    }
}