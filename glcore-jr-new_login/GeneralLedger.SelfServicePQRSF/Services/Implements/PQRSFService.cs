using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using GeneralLedger.SelfServiceCore.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class PQRSFService : GenericService<PQRSF>, IPQRSFService
    {
        private readonly IPQRSFRepository pQRSFRepository;

        public PQRSFService(IPQRSFRepository pQRSFRepository) : base(pQRSFRepository)
        {
            this.pQRSFRepository = pQRSFRepository;
        }

        public async Task<IEnumerable<PQRSFListDTO>> GetAllPQRSFByCliente(string nroId, string nitEmpresa)
        {
            return await pQRSFRepository.GetAllPQRSFByCliente(nroId, nitEmpresa);
        }

        public async Task<IEnumerable<PQRSFListDTO>> GetAllPQRSF()
        {
            return await pQRSFRepository.GetAllPQRSF();
        }

        public async Task<PQRSFShowDTO> GetPQRSFByCliente(int? Id, string NroIdCli)
        {
            return await pQRSFRepository.GetPQRSFByCliente(Id, NroIdCli);
        }

        public async Task<PQRSFCreateDTO> PreparePQRSFToCreate(string nroIde)
        {
            return await pQRSFRepository.PreparePQRSFToCreate(nroIde);
        }

        public async Task<PQRSFProfilerDTO> GetPQRSFToProfiler(int? id)
        {
            return await pQRSFRepository.GetPQRSFToProfiler(id);
        }

        public async Task<IEnumerable<PQRSFListDTO>> GetAllPQRSFByAgente(string NroIdAge)
        {
            return await pQRSFRepository.GetAllPQRSFByAgente(NroIdAge);
        }

        public async Task<PQRSFReportDTO> GetPQRSFToReport(int? id)
        {
            return await pQRSFRepository.GetPQRSFToReport(id);
        }

        public async Task<IEnumerable<ProPqrsf>> GetPqrsf(FilterPQRSFDTO filter, string KeyConnection)
        {
            return await pQRSFRepository.GetPqrsf(filter, KeyConnection);
        }

        public async Task<IEnumerable<ProPqrsf>> GetAllPQRSFByUser(string NroId, FilterPQRSFDTO filter, string KeyConnection)
        {
            return await pQRSFRepository.GetAllPQRSFByUser(NroId, filter, KeyConnection);
        }
    }
}