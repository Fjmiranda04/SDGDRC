using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.Repositories;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class ConfiguracionService : GenericService<Configuracion>, IConfiguracionService
    {
        private readonly IConfiguracionRepository configuracionRepository;

        public ConfiguracionService(IConfiguracionRepository configuracionRepository) : base(configuracionRepository)
        {
            this.configuracionRepository = configuracionRepository;
        }

        public async Task<Configuracion> GetConfiguracionByKey(string key)
        {
            return await configuracionRepository.GetConfiguracionByKey(key);
        }
    }
}