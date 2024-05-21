using GeneralLedger.SelfServiceCore.Data.Models;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services
{
    public interface IConfiguracionService : IGenericService<Configuracion>
    {
        Task<Configuracion> GetConfiguracionByKey(string key);
    }
}