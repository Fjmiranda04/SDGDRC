using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.Repositories;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class EtiquetaService : GenericService<Etiqueta>, IEtiquetaService
    {
        private readonly IEtiquetaRepository etiquetaRepository;

        public EtiquetaService(IEtiquetaRepository etiquetaRepository) : base(etiquetaRepository)
        {
            this.etiquetaRepository = etiquetaRepository;
        }
    }
}