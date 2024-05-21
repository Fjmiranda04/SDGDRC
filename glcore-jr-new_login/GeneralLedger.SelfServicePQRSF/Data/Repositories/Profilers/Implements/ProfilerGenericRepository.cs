using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers.Implements
{
    public class ProfilerGenericRepository : Repository<ProGeneric>, IProfilerGenericRepository
    {
        private readonly SelfServiceContext Context;
        private readonly IConfiguration configuration;

        public ProfilerGenericRepository(SelfServiceContext Context, IConfiguration configuration) : base(Context)
        {
            this.Context = Context;
            this.configuration = configuration;
        }

        public async Task<IEnumerable<Estado>> GetAllEstados(string keyConnection)
        {
            List<Estado> proEstado = new List<Estado>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_ESTADOS"},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PERFILES", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proEstado = Functions.ConvertToList<Estado>(query);

            return proEstado;
        }

        public async Task<IEnumerable<Prioridad>> GetAllPrioridades(string keyConnection)
        {
            List<Prioridad> proPrioridad = new List<Prioridad>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_PRIORIDADES"},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PERFILES", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proPrioridad = Functions.ConvertToList<Prioridad>(query);

            return proPrioridad;
        }

        public async Task<IEnumerable<Situacion>> GetAllSituaciones(string keyConnection)
        {
            List<Situacion> proSituaciones = new List<Situacion>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_SITUACIONES"},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PERFILES", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proSituaciones = Functions.ConvertToList<Situacion>(query);

            return proSituaciones;
        }

        public async Task<IEnumerable<Prodepende>> GetDependencias(string keyConnection)
        {
            List<Prodepende> prodependes = new List<Prodepende>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_DEPENDENCIA"},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PERFILES", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            prodependes = Functions.ConvertToList<Prodepende>(query);

            return prodependes;
        }

        public async Task<IEnumerable<TipoPermiso>> GetTipoPermisos(string keyConnection)
        {
            List<TipoPermiso> tipoPermisos = new List<TipoPermiso>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_TIP_PERMISOS"},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PERFILES", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            tipoPermisos = Functions.ConvertToList<TipoPermiso>(query);

            return tipoPermisos;
        }
    }
}