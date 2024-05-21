using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories
{
    public interface IPQRSFRepository : IGenericRepository<PQRSF>
    {
        Task<IEnumerable<PQRSFListDTO>> GetAllPQRSFByCliente(string NroIdCli, string NitEmpresa);

        Task<IEnumerable<ProPqrsf>> GetAllPQRSFByUser(string NroId, FilterPQRSFDTO filter, string KeyConnection);

        Task<IEnumerable<PQRSFListDTO>> GetAllPQRSF();

        Task<PQRSFShowDTO> GetPQRSFByCliente(int? Id, string NroIdeCli);

        Task<PQRSFCreateDTO> PreparePQRSFToCreate(string NroIdeCli);

        Task<PQRSFProfilerDTO> GetPQRSFToProfiler(int? id);

        Task<IEnumerable<PQRSFListDTO>> GetAllPQRSFByAgente(string NroIdAge);

        Task<PQRSFReportDTO> GetPQRSFToReport(int? id);

        Task<IEnumerable<ProPqrsf>> GetPqrsf(FilterPQRSFDTO filter, string KeyConnection);
    }
}