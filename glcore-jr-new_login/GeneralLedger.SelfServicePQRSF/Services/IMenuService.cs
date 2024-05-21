using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services
{
    public interface IMenuService : IGenericService<Menu>
    {
        Task<IEnumerable<MenuListDTO>> GetMenusByUser(string NroIdUsr);

        Task<IEnumerable<MenuListDTO>> GetMenusByRol(string idRol);

        Task<IEnumerable<MenuListDTO>> GetMenusByUser(string NroIdUsr, string idRol);
    }
}