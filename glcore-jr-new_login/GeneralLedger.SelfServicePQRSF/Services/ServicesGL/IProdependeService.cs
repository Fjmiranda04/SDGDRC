using GeneralLedger.SelfServiceCore.Data.DTOs.DTOsGL;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.ServicesGL
{
    public interface IProdependeService : IGenericService<Prodepende>
    {
        Task<IEnumerable<ProdependeShowDTO>> GetDependencias();

        Task<string> GetCentroCostoByUser(string UserCode);
    }
}