using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers
{
    public interface IProMenuRepository: IRepository<MenuUsuario>
    {
        Task<IEnumerable<MenuUsuario>> GetMenusByUser(string CodigoUsuario, string CodigoRol, string keyConnection);
        Task<IEnumerable<MenuUsuario>> GetMenus(string keyConnection);
        Task<MenuUsuario> RemoveMenuUsuario(string CodigoMenu,string CodigoUsuario,string keyConnection);
        Task<MenuUsuario> AddMenuUsuario(string CodigoMenu, string CodigoUsuario, string keyConnection);
    }
}
