using GeneralLedger.SelfServiceCore.Data.DTOs.DTOsGL;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.ServicesGL
{
    public interface IAccglUsuarioService : IGenericService<AccglUsuario>
    {
        Task<IEnumerable<AccglUsuarioShowDTO>> GetUsuariosGL();
    }
}