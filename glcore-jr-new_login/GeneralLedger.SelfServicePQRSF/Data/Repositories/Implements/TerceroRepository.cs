using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.Extensions.Configuration;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class TerceroRepository : GenericRepository<AccglTer>, ITerceroRepository
    {
        private readonly SelfServiceContext contex;
        private readonly IConfiguration configuration;

        public TerceroRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.contex = contex;
            this.contex = contex;
        }
    }
}