using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class ArchivoService : GenericService<Archivo>, IArchivoService
    {
        private readonly IArchivoRepository archivoRepository;

        public ArchivoService(IArchivoRepository archivoRepository) : base(archivoRepository)
        {
            this.archivoRepository = archivoRepository;
        }

        public async Task<IEnumerable<Archivo>> GetArchivosByIdPQRSF(int idPQRSF)
        {
            return await archivoRepository.GetArchivosByIdPQRSF(idPQRSF);
        }
    }
}