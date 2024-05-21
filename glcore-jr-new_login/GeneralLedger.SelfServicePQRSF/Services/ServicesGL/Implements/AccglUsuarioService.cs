using GeneralLedger.SelfServiceCore.Data.DTOs.DTOsGL;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using GeneralLedger.SelfServiceCore.Data.Repositories.RepositoriesGL;
using GeneralLedger.SelfServiceCore.Services.Implements;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.ServicesGL.Implements
{
    public class AccglUsuarioService : GenericService<AccglUsuario>, IAccglUsuarioService
    {
        private readonly IAccglUsuarioRepository accglUsuarioRespository;

        public AccglUsuarioService(IAccglUsuarioRepository accglUsuarioRespository) : base(accglUsuarioRespository)
        {
            this.accglUsuarioRespository = accglUsuarioRespository;
        }

        public async Task<IEnumerable<AccglUsuarioShowDTO>> GetUsuariosGL()
        {
            return await accglUsuarioRespository.GetUsuariosGL();
        }
    }
}