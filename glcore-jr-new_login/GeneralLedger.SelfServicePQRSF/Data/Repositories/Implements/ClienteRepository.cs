using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        private readonly IConfiguration configuration;

        public ClienteRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IEnumerable<ClienteListDTO>> GetClientes(string filter)
        {
            List<ClienteListDTO> clientes = new List<ClienteListDTO>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GETCLIENTES"},
                new SqlParameter { ParameterName = "@Filter", Value = filter}
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_VENTAS", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            clientes = Functions.ConvertToList<ClienteListDTO>(query);

            return clientes;
        }

    }
}