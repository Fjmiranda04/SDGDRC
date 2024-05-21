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
    public class ProdependeRepository : GenericRepository<Prodepende>, IProdependeRepository
    {
        private readonly SelfServiceContext context;
        private readonly IConfiguration configuration;

        public ProdependeRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.context = contex;
            this.configuration = configuration;
        }

        public async Task<IEnumerable<ProdependeShowDTO>> GetDependencias()
        {
            return await (from dependencia in context.Prodepende
                          where dependencia.Delmrk == "1"
                          select new ProdependeShowDTO
                          {
                              Depcod = dependencia.Depcod,
                              Depnom = dependencia.Depnom,
                              DepcCosto = dependencia.DepcCosto
                          }).ToListAsync();
        }

        public async Task<string> GetCentroCostoByUser(string UserCode)
        {
            return await (from usuario in context.UsuariosGL
                          join dependencia in context.Prodepende on usuario.UserDep equals dependencia.Depcod into user_dep
                          from dep in user_dep.DefaultIfEmpty()
                          where usuario.Codigo == UserCode
                          select dep.DepcCosto
                          ).FirstOrDefaultAsync();
        }
    }
}