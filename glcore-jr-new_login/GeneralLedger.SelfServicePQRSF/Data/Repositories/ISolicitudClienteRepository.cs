using GeneralLedger.SelfServiceCore.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories
{
    public interface ISolicitudClienteRepository : IGenericRepository<SolicitudCliente>
    {
        Task<IEnumerable<SolicitudCliente>> GetSolicitudClienteByStatus(string status, string nitEmpresa);
    }
}