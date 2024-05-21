using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers
{
    public interface IProPqrsfRepository : IRepository<ProPqrsf>
    {
        Task<IEnumerable<ProPqrsf>> GetStatistics(string CodigoAgente, string keyConnection);

        Task<IEnumerable<AyerVsHoy>> GetAyerVsHoyPqrsf(string CodigoAgente, string keyConnection);

        Task<DataByPeriodo> GetDataByPerido(string CodigoAgente, string Mes, string Anio, string keyConnection);

        Task<IEnumerable<PqrsfByDay>> GetPqrsfByDay(string CodigoAgente, string Mes, string Anio, string keyConnection);

        Task<ProPqrsf> SavePqrsf(PQRSF pqrsf, string keyConnection);

        Task<IEnumerable<TratamientoPQRSF>> GetTratamientos(string NroId,string keyConnection);
    }
}