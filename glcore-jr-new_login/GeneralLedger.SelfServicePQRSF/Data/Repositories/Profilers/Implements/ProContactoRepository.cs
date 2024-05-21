using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers.Implements
{
    public class ProContactoRepository : Repository<ContactoCliente>, IProContactoRepository
    {
        private readonly SelfServiceContext Context;
        private readonly IConfiguration configuration;

        public ProContactoRepository(SelfServiceContext Context, IConfiguration configuration) : base(Context)
        {
            this.Context = Context;
            this.configuration = configuration;
        }

        public async Task<IEnumerable<ContactoCliente>> GetContactoClientes(string keyConnection)
        {
            List<ContactoCliente> proContactos = new List<ContactoCliente>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_CONTACTOS"},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PERFILES", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proContactos = Functions.ConvertToList<ContactoCliente>(query);

            return proContactos;
        }
    }
}