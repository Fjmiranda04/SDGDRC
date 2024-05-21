using GeneralLedger.SelfServiceCore.Data.DTOs.DTOsGL;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.RepositoriesGL
{
    public interface IViewSubCentroCostoRepository : IGenericRepository<ViewSubCentroCosto>
    {
        Task<IEnumerable<ViewSubCentroCostoShowDTO>> GetSubCentrosCostos();
    }
}