using GeneralLedger.SelfServiceCore.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories
{
    public interface IContactoClienteRepository : IGenericRepository<ContactoCliente>
    {
        Task<IEnumerable<ContactoCliente>> GetContactByCliente(string codCli);
    }
}