using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.Extensions.Configuration;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class EtiquetaRepository : GenericRepository<Etiqueta>, IEtiquetaRepository
    {
        private readonly SelfServiceContext contex;
        private readonly IConfiguration configuration;

        public EtiquetaRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.contex = contex;
            this.configuration = configuration;
        }
    }
}