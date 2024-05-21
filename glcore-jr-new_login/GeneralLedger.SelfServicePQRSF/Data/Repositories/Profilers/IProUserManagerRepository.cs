using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers
{
    public interface IProUserManagerRepository : IRepository<ProAspNetUser>
    {
        Task<ProAspNetUser> FindByNameAsync(string email, string keyConnection);
    }
}