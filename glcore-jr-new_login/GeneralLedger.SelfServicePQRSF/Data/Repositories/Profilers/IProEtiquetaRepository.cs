using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers
{
    public interface IProEtiquetaRepository : IRepository<ProEtiqueta>
    {
        Task<IEnumerable<ProEtiqueta>> GetEtiquetas(string search, string keyConnection);

        Task<ProEtiqueta> SaveEtiqueta(string etiqueta, string keyConnection);

        Task<ProEtiqueta> EditEtiqueta(string etiqueta, string codigo, string keyConnection);

        Task<ProEtiqueta> DeleteEtiqueta(string codigo, string keyConnection);
    }
}