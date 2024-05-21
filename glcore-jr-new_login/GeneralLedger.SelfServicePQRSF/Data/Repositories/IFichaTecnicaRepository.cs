using GeneralLedger.SelfServiceCore.Data.Models;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories
{
    public interface IFichaTecnicaRepository : IGenericRepository<FichaTecnica>
    {
        Task<FichaTecnica> GetFichaTecnica(string nroFactura);
    }
}