using GeneralLedger.SelfServiceCore.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories
{
    public interface IAgenteRepository : IGenericRepository<Agente>
    {
        Task<IEnumerable<Agente>> GetAllAgentes();

        Task<Agente> GetAgenteByNroId(string nroId);
    }
}