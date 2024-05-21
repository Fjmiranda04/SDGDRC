using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.Repositories;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class FichaTecnicaService : GenericService<FichaTecnica>, IFichaTecnicaService
    {
        private readonly IFichaTecnicaRepository fichaTecnicaRepository;

        public FichaTecnicaService(IFichaTecnicaRepository fichaTecnicaRepository) : base(fichaTecnicaRepository)
        {
            this.fichaTecnicaRepository = fichaTecnicaRepository;
        }

        public async Task<FichaTecnica> GetFichaTecnica(string nroFactura)
        {
            return await fichaTecnicaRepository.GetFichaTecnica(nroFactura);
        }
    }
}