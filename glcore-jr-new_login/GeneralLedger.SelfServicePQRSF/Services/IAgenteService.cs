using GeneralLedger.SelfServiceCore.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services
{
    public interface IAgenteService : IGenericService<Agente>
    {
        Task<IEnumerable<Agente>> GetAllAgentes();

        Task<Agente> GetAgenteByNroId(string nroId);
    }
}