using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class AnalisisVencimientoService : GenericService<AnalisisVencimiento>, IAnalisisVencimientoService
    {
        private readonly IAnalisisVencimientoRepository analisisVencimientoRepository;

        public AnalisisVencimientoService(IAnalisisVencimientoRepository analisisVencimientoRepository) : base(analisisVencimientoRepository)
        {
            this.analisisVencimientoRepository = analisisVencimientoRepository;
        }

        public async Task<IEnumerable<AnalisisVencimiento>> GetAnalisisVencimientoByCliente(string search, string nit, string endDate, string startDate = "", int daysRange = 2, bool cancel = false)
        {
            return await analisisVencimientoRepository.GetAnalisisVencimientoByCliente(search, nit, endDate, startDate, daysRange, cancel);
        }

        public async Task<IEnumerable<AnalisisVencimientoEstadistica>> GetAnalisisVencimientoEstadisticas(string date, string rango, string keyConnection)
        {
            return await analisisVencimientoRepository.GetAnalisisVencimientoEstadisticas(date, rango, keyConnection);
        }

        public async Task<Recaudos> GetRecaudoCartera(string date, string keyConnection)
        {
            return await analisisVencimientoRepository.GetRecaudoCartera(date, keyConnection);
        }
    }
}