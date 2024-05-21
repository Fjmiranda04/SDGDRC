using GeneralLedger.SelfServiceCore.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services
{
    public interface IPagoService : IGenericService<Pago>
    {
        Task<IEnumerable<Pago>> GetPagos(string nroFactura);
    }
}