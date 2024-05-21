using GeneralLedger.SelfServiceCore.Data.Models;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services
{
    public interface IEmpresaService : IGenericService<Empresa>
    {
        Task<Empresa> GetEmpresaByNit(string Nit);
    }
}