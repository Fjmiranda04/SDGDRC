using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers
{
    public interface IProfilerGenericRepository : IRepository<ProGeneric>
    {
        Task<IEnumerable<Situacion>> GetAllSituaciones(string keyConnection);

        Task<IEnumerable<Estado>> GetAllEstados(string keyConnection);

        Task<IEnumerable<Prioridad>> GetAllPrioridades(string keyConnection);

        Task<IEnumerable<Prodepende>> GetDependencias(string keyConnection);
        Task<IEnumerable<TipoPermiso>> GetTipoPermisos(string keyConnection);
    }
}