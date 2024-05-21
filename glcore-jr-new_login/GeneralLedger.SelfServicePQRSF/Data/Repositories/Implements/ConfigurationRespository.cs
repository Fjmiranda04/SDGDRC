using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class ConfigurationRespository : GenericRepository<Configuracion>, IConfiguracionRepository
    {
        private readonly SelfServiceContext contex;
        private readonly IConfiguration configuration;

        public ConfigurationRespository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.contex = contex;
            this.configuration = configuration;
        }

        public async Task<Configuracion> GetConfiguracionByKey(string key)
        {
            return await (from configuraciones in contex.Configuraciones
                          where configuraciones.Clave == key
                          select configuraciones).FirstOrDefaultAsync();
        }
    }
}