using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.ModelsGL.ModelProfilers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers
{
    public interface IProAgenteRepository : IRepository<Agente>
    {
        Task<IEnumerable<Agente>> GetAgentes(string search, string keyConnection);

        Task<Agente> GetAgente(string codigo, string keyConnection);

        Task<Agente> AddAgentes(Agente agente, string keyConnection);

        Task DeleteAgente(string codigo, string keyConnection);

        Task<Agente> EnabledEmail(string codigo, string keyConnection);

        Task<AspNetUsers> GetUsuarioAgente(string codigo, string keyConnection);

        Task<Agente> SaveUsuarioAgente(Agente agente, string keyConnection);
    }
}