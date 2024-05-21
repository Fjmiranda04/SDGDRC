using GeneralLedger.SelfServiceCore.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories
{
    public interface IArchivoRepository : IGenericRepository<Archivo>
    {
        Task<IEnumerable<Archivo>> GetArchivosByIdPQRSF(int idPQRSF);
    }
}