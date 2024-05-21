using GeneralLedger.SelfServiceCore.Data.DTOs.DTOsGL;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using GeneralLedger.SelfServiceCore.Data.Repositories.Implements;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.RepositoriesGL.Implements
{
    public class AccglUsuariosRespository : GenericRepository<AccglUsuario>, IAccglUsuarioRepository
    {
        private readonly SelfServiceContext context;
        private readonly IConfiguration configuration;

        public AccglUsuariosRespository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.context = contex;
            this.configuration = configuration;
        }

        public async Task<IEnumerable<AccglUsuarioShowDTO>> GetUsuariosGL()
        {
            return await (from usuario in context.UsuariosGL
                          where usuario.Delmrk == "1"
                          select new AccglUsuarioShowDTO
                          {
                              Codigo = usuario.Codigo,
                              Nombre = usuario.Nombre,
                              Usuario = usuario.Usuario,
                              UserDep = usuario.UserDep,
                          }).ToListAsync();
        }
    }
}