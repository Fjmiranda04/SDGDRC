using GeneralLedger.SelfServiceCore.Data.Models;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services
{
    public interface IUsuarioEmpresaService : IGenericService<UsuarioEmpresa>
    {
        Task<UsuarioEmpresa> GetUsuarioByEmail(string email);
    }
}