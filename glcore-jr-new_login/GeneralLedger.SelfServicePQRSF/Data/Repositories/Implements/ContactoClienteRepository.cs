using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class ContactoClienteRepository : GenericRepository<ContactoCliente>, IContactoClienteRepository
    {
        private readonly SelfServiceContext contex;
        private readonly IConfiguration configuration;

        public ContactoClienteRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.contex = contex;
            this.configuration = configuration;
        }

        public async Task<IEnumerable<ContactoCliente>> GetContactByCliente(string codCli)
        {
            return await contex.ContactosCliente
                .Select(c => new ContactoCliente
                {
                    Id = c.Id,
                    NombreContacto = c.NombreContacto,
                    Telefono = c.Telefono,
                    Celular = c.Celular,
                    Email = c.Email
                }).ToListAsync();
        }
    }
}