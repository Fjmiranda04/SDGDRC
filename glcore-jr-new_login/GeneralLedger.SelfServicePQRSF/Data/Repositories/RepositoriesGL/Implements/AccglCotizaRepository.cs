using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using GeneralLedger.SelfServiceCore.Data.Repositories.Implements;
using Microsoft.Extensions.Configuration;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.RepositoriesGL.Implements
{
    public class AccglCotizaRepository : GenericRepository<AccglCotiza>, IAccglCotizaRepository
    {
        private readonly SelfServiceContext context;
        private readonly IConfiguration configuration;

        public AccglCotizaRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.context = contex;
            this.configuration = configuration;
        }
    }
}