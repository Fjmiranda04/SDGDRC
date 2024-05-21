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
    public class ViewSubCentroCostoRepository : GenericRepository<ViewSubCentroCosto>, IViewSubCentroCostoRepository
    {
        private readonly SelfServiceContext context;
        private readonly IConfiguration configuration;

        public ViewSubCentroCostoRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.context = contex;
            this.configuration = configuration;
        }

        public async Task<IEnumerable<ViewSubCentroCostoShowDTO>> GetSubCentrosCostos()
        {
            return await (from subcco in context.ViewSubCentroCosto
                          where subcco.Delmrk == "1"
                          select new ViewSubCentroCostoShowDTO
                          {
                              CodigoCentro = subcco.CodigoCentro,
                              CodigoSub = subcco.CodigoSub,
                              NombreCentro = subcco.NombreCentro,
                              NombreSub = subcco.NombreSub,
                          }).ToListAsync();
        }
    }
}