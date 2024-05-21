using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories
{
    public interface IClienteRepository : IGenericRepository<Cliente>
    {
        Task<IEnumerable<ClienteListDTO>> GetClientes(string filter);
    }
}