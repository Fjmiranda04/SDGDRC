using GeneralLedger.SelfServiceCore.Data.ModelsGL.ModelProfilers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers
{
    public interface IProAreaRepository : IRepository<ProArea>
    {
        Task<IEnumerable<ProArea>> GetAreas(string search, string keyConnection);

        Task<ProArea> SaveArea(string area, string keyConnection);

        Task<ProArea> EditArea(string area, string codigo, string keyConnection);

        Task<ProArea> DeleteArea(string codigo, string keyConnection);
    }
}