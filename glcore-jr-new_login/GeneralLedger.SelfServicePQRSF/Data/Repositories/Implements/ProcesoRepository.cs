using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.Extensions.Configuration;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class ProcesoRepository : GenericRepository<Proceso>, IProcesoRepository
    {
        private readonly IConfiguration configuration;

        public ProcesoRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.configuration = configuration;
        }
    }
}