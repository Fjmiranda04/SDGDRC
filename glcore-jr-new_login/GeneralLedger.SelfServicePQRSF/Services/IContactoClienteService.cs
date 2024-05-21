using GeneralLedger.SelfServiceCore.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services
{
    public interface IContactoClienteService : IGenericService<ContactoCliente>
    {
        Task<IEnumerable<ContactoCliente>> GetContactByCliente(string codCli);
    }
}