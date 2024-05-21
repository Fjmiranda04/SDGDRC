using GeneralLedger.SelfServiceCore.Data.Models;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories
{
    public interface IConfiguracionRepository : IGenericRepository<Configuracion>
    {
        Task<Configuracion> GetConfiguracionByKey(string key);
    }
}