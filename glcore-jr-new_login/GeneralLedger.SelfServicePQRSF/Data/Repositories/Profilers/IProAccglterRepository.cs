using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers
{
    public interface IProAccglterRepository : IRepository<AccglTer>
    {
        Task<IEnumerable<AccglTer>> GetTerceros(string keyConnection);

        Task<AccglTer> GetTercero(string ternit, string keyConnection);
    }
}