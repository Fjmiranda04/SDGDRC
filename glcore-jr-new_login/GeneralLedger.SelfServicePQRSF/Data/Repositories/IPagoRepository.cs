using GeneralLedger.SelfServiceCore.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories
{
    public interface IPagoRepository : IGenericRepository<Pago>
    {
        Task<IEnumerable<Pago>> GetPagos(string nroFactura);
    }
}