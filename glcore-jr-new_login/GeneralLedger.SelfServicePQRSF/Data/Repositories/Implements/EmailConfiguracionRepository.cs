using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class EmailConfiguracionRepository : GenericRepository<EmailConfiguracion>, IEmailConfiguracionRepository
    {
        private readonly SelfServiceContext contex;
        private readonly IConfiguration configuration;

        public EmailConfiguracionRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.contex = contex;
            this.configuration = configuration;
        }

        public async Task<EmailConfiguracion> GetEmailConfiguracionByKey(string key)
        {
            return await (from emailcfg in contex.EmailConfiguraciones
                          where emailcfg.KeyValue == key
                          select emailcfg).FirstOrDefaultAsync();
        }
    }
}