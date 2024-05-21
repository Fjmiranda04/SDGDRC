using GeneralLedger.SelfServiceCore.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories
{
    public interface IImputacionRepository : IGenericRepository<Imputacion>
    {
        Task<IEnumerable<Imputacion>> GetImputaciones(string nroFactura);
    }
}