using GeneralLedger.SelfServiceCore.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services
{
    public interface IImputacionService : IGenericService<Imputacion>
    {
        Task<IEnumerable<Imputacion>> GetImputaciones(string nroFactura);
    }
}