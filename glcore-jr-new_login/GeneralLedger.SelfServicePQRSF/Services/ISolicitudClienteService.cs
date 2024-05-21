using GeneralLedger.SelfServiceCore.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services
{
    public interface ISolicitudClienteService : IGenericService<SolicitudCliente>
    {
        Task<IEnumerable<SolicitudCliente>> GetSolicitudClienteByStatus(string status, string nitEmpresa);
    }
}