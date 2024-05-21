using GeneralLedger.SelfServiceCore.Data.Models;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories
{
    public interface IEmailConfiguracionRepository : IGenericRepository<EmailConfiguracion>
    {
        Task<EmailConfiguracion> GetEmailConfiguracionByKey(string key);
    }
}