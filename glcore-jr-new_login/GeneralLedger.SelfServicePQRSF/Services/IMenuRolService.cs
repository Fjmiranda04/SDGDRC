using GeneralLedger.SelfServiceCore.Data.Models;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services
{
    public interface IMenuRolService : IGenericService<MenuRol>
    {
        Task DeleteMenuRol(string codMnu, string idRol);

        Task<MenuRol> InsertMenuRol(string codMnu, string idRol);
    }
}