using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services
{
    public interface IPerfilService : IGenericService<Perfil>
    {
        Task<PerfilListDTO> GetPerfilByUser(string CodPerfil);
    }
}