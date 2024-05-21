using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using GeneralLedger.SelfServiceCore.Data.Repositories;
using GeneralLedger.SelfServiceCore.Data.Repositories.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class SolicitanteCtzService : GenericService<CliOtrosContactos>, ISolicitanteCtzService
    {
        private readonly ISolicitanteCtzRepository solicitanteCtzRepository;

        public SolicitanteCtzService(ISolicitanteCtzRepository solicitanteCtzRepository) : base(solicitanteCtzRepository)
        {
            this.solicitanteCtzRepository = solicitanteCtzRepository;
        }

        public async Task<IEnumerable<SolicitanteCtzListDTO>> GetSolicitantes(string filter, string nitCliente)
        {
            return await solicitanteCtzRepository.GetSolicitantes(filter, nitCliente);
        }

    }
}
