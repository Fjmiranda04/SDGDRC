using Dapper;
using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Cliente = GeneralLedger.SelfServiceCore.Data.ModelsGL.Cliente;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers.Implements
{
    public class ProClienteRepository : Repository<Cliente>, IProClienteRepository
    {
        private readonly SelfServiceContext Context;
        private readonly IConfiguration configuration;

        public ProClienteRepository(SelfServiceContext Context, IConfiguration configuration) : base(Context)
        {
            this.Context = Context;
            this.configuration = configuration;
        }

        public Task<Cliente> GeCliente(string nitcliente)
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente> SaveCliente(Cliente cliente, string keyConnection)
        {
            Cliente clienter = new Cliente();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                     new SqlParameter("@tipDoc", cliente.TipDoc),
                     new SqlParameter("@clinit", cliente.Clinit),
                     new SqlParameter("@clinom", $"{cliente.CliPriNom} {cliente.CliSegNom} {cliente.CliPriApe} {cliente.CliSegApe}"),
                     new SqlParameter("@cliPriNom", cliente.CliPriNom),
                     new SqlParameter("@cliSegNom", cliente.CliSegNom),
                     new SqlParameter("@cliPriApe", cliente.CliPriApe),
                     new SqlParameter("@cliSegApe", cliente.CliSegApe),
                     new SqlParameter("@clidir", cliente.Clidir),
                     new SqlParameter("@clicodciud", cliente.CliCodCiud),
                     new SqlParameter("@clitel", cliente.Clitel),
                     new SqlParameter("@climail", cliente.Climail),
                     new SqlParameter("@Operacion", "IC")
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_TERCERO_CLIENTE", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            clienter = Functions.ConvertToEntity<Cliente>(query);

            return clienter;
        }

        public async Task<Cliente> GetCliente(string nitcliente, string keyConnection)
        {
            Cliente clienter = new Cliente();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter("@Operacion", "SC"),
                new SqlParameter("@clinit", nitcliente),
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_TERCERO_CLIENTE", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            clienter = Functions.ConvertToEntity<Cliente>(query);

            return clienter;
        }

        public async Task<IEnumerable<Cliente>> GetClientes(string keyConnection)
        {
            var clientes = new List<Cliente>();

            var parms = new DynamicParameters();

            parms.Add("Operacion", "GET_CLIENTES_PQRSF");

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            return await connection.QueryAsync<Cliente>("WEBGLSS_SP_TERCERO_CLIENTE", parms, commandType: CommandType.StoredProcedure);
        }

        public Task<Cliente> GetClienteByCodigo(string codigoCliente, string keyConnection)
        {
            throw new NotImplementedException();
        }
    }
}