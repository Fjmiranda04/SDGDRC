using GeneralLedger.SelfServiceCore.Data.Models;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories
{
    public interface IEmpresaRepository : IGenericRepository<Empresa>
    {
        Task<Empresa> GetEmpresaByNit(string Nit);
    }
}