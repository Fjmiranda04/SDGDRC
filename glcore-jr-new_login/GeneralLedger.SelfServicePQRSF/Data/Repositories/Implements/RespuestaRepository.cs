using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.Extensions.Configuration;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class RespuestaRepository : GenericRepository<Respuesta>, IRespuestaRepository
    {
        private readonly SelfServiceContext contex;
        private readonly IConfiguration configuration;

        public RespuestaRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.contex = contex;
            this.configuration = configuration;
        }
    }
}