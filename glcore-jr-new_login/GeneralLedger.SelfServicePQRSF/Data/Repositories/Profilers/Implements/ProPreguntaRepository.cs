using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers.Implements
{
    public class ProPreguntaRepository : Repository<Pregunta>, IProPreguntaRepository
    {
        private readonly SelfServiceContext Context;
        private readonly IConfiguration configuration;

        public ProPreguntaRepository(SelfServiceContext Context, IConfiguration configuration) : base(Context)
        {
            this.Context = Context;
            this.configuration = configuration;
        }

        public async Task<Pregunta> DeletePregunta(int id, string keyConnection)
        {
            Pregunta pregunta = new Pregunta();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "DELETEPREGUNTA"},
                new SqlParameter { ParameterName = "@Codigo", Value = id},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PERFILES", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            pregunta = Functions.ConvertToEntity<Pregunta>(query);

            return pregunta;
        }

        public async Task<Pregunta> EditPregunta(string pregunta, int id, string keyConnection)
        {
            Pregunta pregunta_ = new Pregunta();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "EDITPREGUNTA"},
                new SqlParameter { ParameterName = "@Nombre", Value = pregunta},
                new SqlParameter { ParameterName = "@Codigo", Value = id},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PERFILES", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            pregunta_ = Functions.ConvertToEntity<Pregunta>(query);

            return pregunta_;
        }

        public async Task<IEnumerable<Pregunta>> GetPreguntas(string search, string keyConnection)
        {
            List<Pregunta> preguntas = new List<Pregunta>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GETPREGUNTAS"},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PERFILES", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            preguntas = Functions.ConvertToList<Pregunta>(query);

            return preguntas;
        }

        public async Task<Pregunta> SavePregunta(string pregunta, string keyConnection)
        {
            Pregunta pregunta_ = new Pregunta();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "SAVEPREGUNTA"},
                new SqlParameter { ParameterName = "@Nombre", Value = pregunta},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PERFILES", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            pregunta_ = Functions.ConvertToEntity<Pregunta>(query);

            return pregunta_;
        }
    }
}