using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers
{
    public interface IProAccglproRepository : IRepository<AccglPro>
    {
        Task<AccglPro> SaveProponente(AccglPro proponente, string keyConnection);
    }
}