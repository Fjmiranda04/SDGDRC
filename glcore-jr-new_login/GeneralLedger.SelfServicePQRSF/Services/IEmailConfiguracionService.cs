using GeneralLedger.SelfServiceCore.Data.Models;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services
{
    public interface IEmailConfiguracionService : IGenericService<EmailConfiguracion>
    {
        Task<EmailConfiguracion> GetEmailConfiguracionByKey(string key);
    }
}