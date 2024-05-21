using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers.Implements
{
    public class ProAccglterRepository : Repository<AccglTer>, IProAccglterRepository
    {
        private readonly SelfServiceContext Context;
        private readonly IConfiguration configuration;

        public ProAccglterRepository(SelfServiceContext Context, IConfiguration configuration) : base(Context)
        {
            this.Context = Context;
            this.configuration = configuration;
        }

        public async Task<AccglTer> GetTercero(string ternit, string keyConnection)
        {
            AccglTer proAccglTer = new AccglTer();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GETTERCERO"},
                new SqlParameter { ParameterName = "@Codigo", Value = ternit},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PERFILES", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proAccglTer = Functions.ConvertToEntity<AccglTer>(query);

            return proAccglTer;
        }

        public async Task<IEnumerable<AccglTer>> GetTerceros(string keyConnection)
        {
            List<AccglTer> proAccglTers = new List<AccglTer>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GETTERCEROS"},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PERFILES", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proAccglTers = Functions.ConvertToList<AccglTer>(query);

            return proAccglTers;
        }
    }
}