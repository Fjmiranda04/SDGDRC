using GeneralLedger.SelfServiceCore.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services
{
    public interface IArchivoService : IGenericService<Archivo>
    {
        Task<IEnumerable<Archivo>> GetArchivosByIdPQRSF(int idPQRSF);
    }
}