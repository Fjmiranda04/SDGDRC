using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.Extensions.Configuration;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class SituacionRepository : GenericRepository<Situacion>, ISituacionRepository
    {
        private readonly IConfiguration configuration;

        public SituacionRepository(SelfServiceContext context, IConfiguration configuration) : base(context, configuration)
        {
            this.configuration = configuration;
        }
    }
}