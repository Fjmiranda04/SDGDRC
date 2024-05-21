using GeneralLedger.SelfServiceCore.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers
{
    public interface IProContactoRepository : IRepository<ContactoCliente>
    {
        Task<IEnumerable<ContactoCliente>> GetContactoClientes(string keyConnection);
    }
}