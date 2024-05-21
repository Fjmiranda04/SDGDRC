using GeneralLedger.SelfServiceCore.Data.Models;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services
{
    public interface IMenuUsuarioService : IGenericService<MenuUsuario>
    {
        Task DeleteMenuUser(string codMnu, string nroId);

        Task<MenuUsuario> InsertMenuUsuario(string codMnu, string nroId);
    }
}