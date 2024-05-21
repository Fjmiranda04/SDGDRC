using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class UsuarioEmpresaRepository : GenericRepository<UsuarioEmpresa>, IUsuarioEmpresaRepository
    {
        private readonly SelfServiceContext contex;
        private readonly IConfiguration configuration;

        public UsuarioEmpresaRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.contex = contex;
            this.configuration = configuration;
        }

        public async Task<UsuarioEmpresa> GetUsuarioByEmail(string email)
        {
            return await (from usuarioEmpresa in contex.UsuarioEmpresas
                          where usuarioEmpresa.Email == email
                          select usuarioEmpresa).FirstOrDefaultAsync();
        }
    }
}