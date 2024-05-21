using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class SolicitudClienteRepository : GenericRepository<SolicitudCliente>, ISolicitudClienteRepository
    {
        private readonly SelfServiceContext contex;
        private readonly IConfiguration configuration;

        public SolicitudClienteRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.contex = contex;
            this.configuration = configuration;
        }

        public async Task<IEnumerable<SolicitudCliente>> GetSolicitudClienteByStatus(string status, string nitEmpresa)
        {
            return await (from solicitud in contex.SolicitudClientes
                          where solicitud.Estado == status && solicitud.NitEmpresa == nitEmpresa
                          select solicitud).ToListAsync();
        }
    }
}