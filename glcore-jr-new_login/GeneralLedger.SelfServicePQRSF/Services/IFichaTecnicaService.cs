using GeneralLedger.SelfServiceCore.Data.Models;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services
{
    public interface IFichaTecnicaService : IGenericService<FichaTecnica>
    {
        Task<FichaTecnica> GetFichaTecnica(string nroFactura);
    }
}