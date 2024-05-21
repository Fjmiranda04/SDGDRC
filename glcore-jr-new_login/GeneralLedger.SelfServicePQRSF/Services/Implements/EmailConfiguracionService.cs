using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.Repositories;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class EmailConfiguracionService : GenericService<EmailConfiguracion>, IEmailConfiguracionService
    {
        private readonly IEmailConfiguracionRepository emailConfiguracionRepository;

        public EmailConfiguracionService(IEmailConfiguracionRepository emailConfiguracionRepository) : base(emailConfiguracionRepository)
        {
            this.emailConfiguracionRepository = emailConfiguracionRepository;
        }

        public async Task<EmailConfiguracion> GetEmailConfiguracionByKey(string key)
        {
            return await emailConfiguracionRepository.GetEmailConfiguracionByKey(key);
        }
    }
}