using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class PerfilRepository : GenericRepository<Perfil>, IPerfilRepository
    {
        private readonly SelfServiceContext contex;
        private readonly IConfiguration configuration;

        public PerfilRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.contex = contex;
            this.configuration = configuration;
        }

        public async Task<PerfilListDTO> GetPerfilByUser(string CodPerfil)
        {
            return await (from perfil in contex.Perfiles
                          where perfil.CodPerfil == CodPerfil
                          select new PerfilListDTO
                          {
                              NomPerfil = perfil.NomPerfil
                          }).FirstOrDefaultAsync();
        }
    }
}