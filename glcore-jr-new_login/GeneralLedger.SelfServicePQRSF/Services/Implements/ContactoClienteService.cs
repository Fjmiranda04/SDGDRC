using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class ContactoClienteService : GenericService<ContactoCliente>, IContactoClienteService
    {
        private readonly IContactoClienteRepository contactoClienteRepository;

        public ContactoClienteService(IContactoClienteRepository contactoClienteRepository) : base(contactoClienteRepository)
        {
            this.contactoClienteRepository = contactoClienteRepository;
        }

        public async Task<IEnumerable<ContactoCliente>> GetContactByCliente(string codCli)
        {
            return await contactoClienteRepository.GetContactByCliente(codCli);
        }
    }
}