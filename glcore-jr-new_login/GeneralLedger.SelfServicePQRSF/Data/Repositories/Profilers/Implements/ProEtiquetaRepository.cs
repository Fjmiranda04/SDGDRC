using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers.Implements
{
    public class ProEtiquetaRepository : Repository<ProEtiqueta>, IProEtiquetaRepository
    {
        private readonly SelfServiceContext Context;
        private readonly IConfiguration configuration;

        public ProEtiquetaRepository(SelfServiceContext Context, IConfiguration configuration) : base(Context)
        {
            this.Context = Context;
            this.configuration = configuration;
        }

        public async Task<IEnumerable<ProEtiqueta>> GetEtiquetas(string search, string keyConnection)
        {
            List<ProEtiqueta> proEtiquetas = new List<ProEtiqueta>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GETETIQUETAS"},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PERFILES", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proEtiquetas = Functions.ConvertToList<ProEtiqueta>(query);

            return proEtiquetas;
        }

        public async Task<ProEtiqueta> SaveEtiqueta(string etiqueta, string keyConnection)
        {
            ProEtiqueta proEtiqueta = new ProEtiqueta();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "SAVEETIQUETAS"},
                new SqlParameter { ParameterName = "@Nombre", Value = etiqueta},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PERFILES", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proEtiqueta = Functions.ConvertToEntity<ProEtiqueta>(query);

            return proEtiqueta;
        }

        public async Task<ProEtiqueta> EditEtiqueta(string etiqueta, string codigo, string keyConnection)
        {
            ProEtiqueta proEtiqueta = new ProEtiqueta();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "EDITETIQUETAS"},
                new SqlParameter { ParameterName = "@Nombre", Value = etiqueta},
                new SqlParameter { ParameterName = "@Codigo", Value = codigo},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PERFILES", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proEtiqueta = Functions.ConvertToEntity<ProEtiqueta>(query);

            return proEtiqueta;
        }

        public async Task<ProEtiqueta> DeleteEtiqueta(string codigo, string keyConnection)
        {
            ProEtiqueta proEtiqueta = new ProEtiqueta();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "DELETEETIQUETA"},
                new SqlParameter { ParameterName = "@Codigo", Value = codigo},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PERFILES", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proEtiqueta = Functions.ConvertToEntity<ProEtiqueta>(query);

            return proEtiqueta;
        }
    }
}