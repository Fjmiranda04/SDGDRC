using GeneralLedger.SelfServiceCore.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services
{
    public interface IAnalisisVencimientoService : IGenericService<AnalisisVencimiento>
    {
        Task<IEnumerable<AnalisisVencimiento>> GetAnalisisVencimientoByCliente(string search, string nit, string endDate, string startDate = "", int daysRange = 2, bool cancel = false);

        Task<IEnumerable<AnalisisVencimientoEstadistica>> GetAnalisisVencimientoEstadisticas(string date, string rango, string keyConnection);

        Task<Recaudos> GetRecaudoCartera(string date, string keyConnection);
    }
}