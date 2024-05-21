using GeneralLedger.SelfServiceCore.Data.DTOs.DTOsGL;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.RepositoriesGL
{
    public interface IProdependeRepository : IGenericRepository<Prodepende>
    {
        Task<IEnumerable<ProdependeShowDTO>> GetDependencias();

        Task<string> GetCentroCostoByUser(string UserCode);
    }
}