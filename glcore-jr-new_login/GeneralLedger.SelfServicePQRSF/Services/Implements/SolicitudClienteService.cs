using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class SolicitudClienteService : GenericService<SolicitudCliente>, ISolicitudClienteService
    {
        private readonly ISolicitudClienteRepository solicitudClienteRepository;

        public SolicitudClienteService(ISolicitudClienteRepository solicitudClienteRepository) : base(solicitudClienteRepository)
        {
            this.solicitudClienteRepository = solicitudClienteRepository;
        }

        public async Task<IEnumerable<SolicitudCliente>> GetSolicitudClienteByStatus(string status, string nitEmpresa)
        {
            return await solicitudClienteRepository.GetSolicitudClienteByStatus(status, nitEmpresa);
        }
    }
}