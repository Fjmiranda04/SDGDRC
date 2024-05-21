using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class ArticuloRepository : GenericRepository<Articulo>, IArticuloRepository
    {
        private readonly SelfServiceContext contex;
        private readonly IConfiguration configuration;

        public ArticuloRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.contex = contex;
            this.configuration = configuration;
        }

        public async Task<IEnumerable<ArticuloShowDTO>> GetArticulos()
        {
            List<ArticuloShowDTO> articulos = new List<ArticuloShowDTO>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GETARTICULOS"},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PEDIDOS", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            articulos = Functions.ConvertToList<ArticuloShowDTO>(query);

            return articulos;
        }
    }
}