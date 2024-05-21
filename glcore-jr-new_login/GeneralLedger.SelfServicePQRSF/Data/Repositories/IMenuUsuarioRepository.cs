using GeneralLedger.SelfServiceCore.Data.Models;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories
{
    public interface IMenuUsuarioRepository : IGenericRepository<MenuUsuario>
    {
        Task DeleteMenuUser(string codMnu, string nroId);

        Task<MenuUsuario> InsertMenuUsuario(string codMnu, string nroId);
    }
}