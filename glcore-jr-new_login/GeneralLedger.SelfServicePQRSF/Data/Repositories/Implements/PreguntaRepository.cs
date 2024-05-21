using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.Extensions.Configuration;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class PreguntaRepository : GenericRepository<Pregunta>, IPreguntaRepository
    {
        private readonly SelfServiceContext contex;
        private readonly IConfiguration configuration;

        public PreguntaRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.contex = contex;
            this.configuration = configuration;
        }
    }
}