using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class EmpresaRepository : GenericRepository<Empresa>, IEmpresaRepository
    {
        private readonly SelfServiceContext contex;
        private readonly IConfiguration configuration;

        public EmpresaRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.contex = contex;
            this.configuration = configuration;
        }

        public async Task<Empresa> GetEmpresaByNit(string Nit)
        {
            //return await (from empresa in contex.Empresas
            //              where empresa.Nit == Nit
            //              select new Empresa
            //              {
            //                  Id = empresa.Id,
            //                  Nit = empresa.Nit,
            //                  Nombre = empresa.Nombre,
            //                  KeyConnection = empresa.KeyConnection,
            //                  CodigoLegacy = empresa.CodigoLegacy,
            //              }).FirstOrDefaultAsync();

            return await contex.Empresas.AsNoTracking().FirstOrDefaultAsync(x => x.Nit == Nit);
        }
    }
}