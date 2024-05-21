using GeneralLedger.SelfServiceCore.Data.ModelsGL.ModelProfilers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers.Implements
{
    public class ProAreaRepository : Repository<ProArea>, IProAreaRepository
    {
        private readonly SelfServiceContext Context;
        private readonly IConfiguration configuration;

        public ProAreaRepository(SelfServiceContext Context, IConfiguration configuration) : base(Context)
        {
            this.Context = Context;
            this.configuration = configuration;
        }

        public async Task<ProArea> DeleteArea(string codigo, string keyConnection)
        {
            ProArea proArea = new ProArea();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "DELETEAREA"},
                new SqlParameter { ParameterName = "@Codigo", Value = codigo},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PERFILES", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proArea = Functions.ConvertToEntity<ProArea>(query);

            return proArea;
        }

        public async Task<ProArea> EditArea(string area, string codigo, string keyConnection)
        {
            ProArea proArea = new ProArea();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "EDITAREA"},
                new SqlParameter { ParameterName = "@Nombre", Value = area},
                new SqlParameter { ParameterName = "@Codigo", Value = codigo},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PERFILES", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proArea = Functions.ConvertToEntity<ProArea>(query);

            return proArea;
        }

        public async Task<IEnumerable<ProArea>> GetAreas(string search, string keyConnection)
        {
            List<ProArea> proAreas = new List<ProArea>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GETAREAS"},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PERFILES", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proAreas = Functions.ConvertToList<ProArea>(query);

            return proAreas;
        }

        public async Task<ProArea> SaveArea(string area, string keyConnection)
        {
            ProArea proArea = new ProArea();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "SAVEAREA"},
                new SqlParameter { ParameterName = "@Nombre", Value = area},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PERFILES", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proArea = Functions.ConvertToEntity<ProArea>(query);

            return proArea;
        }
    }
}