using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers
{
    public interface IProClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> SaveCliente(Cliente cliente, string keyConnection);

        Task<Cliente> GetCliente(string nitcliente, string keyConnection);
        Task<Cliente> GetClienteByCodigo(string codigoCliente, string keyConnection);

        Task<IEnumerable<Cliente>> GetClientes(string keyConnection);
    }
}