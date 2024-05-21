using GeneralLedger.SelfServiceCore.Data.DTOs.DTOsGL;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using GeneralLedger.SelfServiceCore.Data.Repositories.RepositoriesGL;
using GeneralLedger.SelfServiceCore.Services.Implements;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.ServicesGL.Implements
{
    public class ProdependeService : GenericService<Prodepende>, IProdependeService
    {
        private readonly IProdependeRepository prodependeRepository;

        public ProdependeService(IProdependeRepository prodependeRepository) : base(prodependeRepository)
        {
            this.prodependeRepository = prodependeRepository;
        }

        public async Task<string> GetCentroCostoByUser(string UserCode)
        {
            return await prodependeRepository.GetCentroCostoByUser(UserCode);
        }

        public async Task<IEnumerable<ProdependeShowDTO>> GetDependencias()
        {
            return await prodependeRepository.GetDependencias();
        }
    }
}