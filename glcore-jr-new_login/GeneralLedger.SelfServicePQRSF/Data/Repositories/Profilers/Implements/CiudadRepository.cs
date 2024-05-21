using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.Extensions.Configuration;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers.Implements
{
    public class CiudadRepository : Repository<Prociudad>, ICiudadRepository
    {
        private readonly SelfServiceContext Context;
        private readonly IConfiguration configuration;

        public CiudadRepository(SelfServiceContext Context, IConfiguration configuration) : base(Context)
        {
            this.Context = Context;
            this.configuration = configuration;
        }
    }
}