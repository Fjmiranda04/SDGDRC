using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.Extensions.Configuration;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class TrabajoRepository : GenericRepository<Trabajo>, ITrabajoRepository
    {
        private readonly SelfServiceContext contex;
        private readonly IConfiguration configuration;

        public TrabajoRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.contex = contex;
            this.configuration = configuration;
        }
    }
}