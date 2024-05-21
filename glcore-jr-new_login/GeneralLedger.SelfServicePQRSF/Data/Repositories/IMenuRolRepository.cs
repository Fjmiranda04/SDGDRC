using GeneralLedger.SelfServiceCore.Data.Models;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories
{
    public interface IMenuRolRepository : IGenericRepository<MenuRol>
    {
        Task DeleteMenuRol(string codMnu, string idRol);

        Task<MenuRol> InsertMenuRol(string codMnu, string idRol);
    }
}