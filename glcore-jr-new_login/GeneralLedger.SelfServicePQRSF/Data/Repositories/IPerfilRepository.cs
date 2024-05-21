using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories
{
    public interface IPerfilRepository : IGenericRepository<Perfil>
    {
        Task<PerfilListDTO> GetPerfilByUser(string CodPerfil);
    }
}