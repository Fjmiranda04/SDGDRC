using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class AgenteRepository : GenericRepository<Agente>, IAgenteRepository
    {
        private readonly SelfServiceContext contex;
        private readonly IConfiguration configuration;

        public AgenteRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.contex = contex;
            this.configuration = configuration;
        }

        public async Task<IEnumerable<Agente>> GetAllAgentes()
        {
            //return await (from agente in contex.Agentes
            //              where agente.RecibeEmail == true && agente.delmrk == "1"
            //              select agente
            //              ).ToListAsync();

            return await contex.Agentes.AsNoTracking().Where(x => x.RecibeEmail == true && x.delmrk == "1").ToListAsync();
        }

        public async Task<Agente> GetAgenteByNroId(string nroId)
        {
            //return await (from agente in contex.Agentes
            //              where agente.NroId == nroId
            //              select agente).FirstOrDefaultAsync();

            return await contex.Agentes.FirstOrDefaultAsync(x => x.NroId == nroId);
        }
    }
}