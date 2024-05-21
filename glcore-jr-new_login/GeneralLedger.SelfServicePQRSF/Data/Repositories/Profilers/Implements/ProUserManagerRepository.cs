using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers.Implements
{
    public class ProUserManagerRepository : Repository<ProAspNetUser>, IProUserManagerRepository
    {
        private readonly SelfServiceContext Context;
        private readonly IConfiguration configuration;

        public ProUserManagerRepository(SelfServiceContext Context, IConfiguration configuration) : base(Context)
        {
            this.Context = Context;
            this.configuration = configuration;
        }

        public async Task<ProAspNetUser> FindByNameAsync(string email, string keyConnection)
        {
            ProAspNetUser proAspNetUser = new ProAspNetUser();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_USER"},
                new SqlParameter { ParameterName = "@Email", Value = email},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_USER_MANAGER", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proAspNetUser = Functions.ConvertToEntity<ProAspNetUser>(query);

            return proAspNetUser;
        }
    }
}