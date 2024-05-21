using GeneralLedger.SelfServiceCore.Data.Models;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories
{
    public interface IUsuarioEmpresaRepository : IGenericRepository<UsuarioEmpresa>
    {
        Task<UsuarioEmpresa> GetUsuarioByEmail(string email);
    }
}