using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.ModelsGL.ModelProfilers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers.Implements
{
    public class ProAgenteRepository : Repository<Agente>, IProAgenteRepository
    {
        private readonly SelfServiceContext Context;
        private readonly IConfiguration configuration;

        public ProAgenteRepository(SelfServiceContext Context, IConfiguration configuration) : base(Context)
        {
            this.Context = Context;
            this.configuration = configuration;
        }

        public Task<Agente> AddAgentes(Agente agente, string keyConnection)
        {
            throw new NotImplementedException();
        }

        public async Task<Agente> EnabledEmail(string codigo, string keyConnection)
        {
            Agente proAgente = new Agente();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "ENABLEDMAIL"},
                 new SqlParameter { ParameterName = "@Codigo", Value = codigo},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PERFILES", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proAgente = Functions.ConvertToEntity<Agente>(query);

            return proAgente;
        }

        public async Task<IEnumerable<Agente>> GetAgentes(string search, string keyConnection)
        {
            List<Agente> proAgente = new List<Agente>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GETAGENTES"},
                new SqlParameter { ParameterName = "@Search", Value = search},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PERFILES", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proAgente = Functions.ConvertToList<Agente>(query);

            return proAgente;
        }

        public async Task<Agente> GetAgente(string codigo, string keyConnection)
        {
            Agente proAgente = new Agente();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GETAGENTE"},
                new SqlParameter { ParameterName = "@Codigo", Value = codigo},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PERFILES", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proAgente = Functions.ConvertToEntity<Agente>(query);

            return proAgente;
        }

        public async Task DeleteAgente(string codigo, string keyConnection)
        {
            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "DELETEAGENTE"},
                new SqlParameter { ParameterName = "@Codigo", Value = codigo},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            await ExecuteQueryDataTable("WEBGLSS_SP_PERFILES", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);
        }

        public async Task<AspNetUsers> GetUsuarioAgente(string codigo, string keyConnection)
        {
            AspNetUsers aspnetuser = new AspNetUsers();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GETUSERTOAGENTE"},
                 new SqlParameter { ParameterName = "@Codigo", Value = codigo},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PERFILES", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            aspnetuser = Functions.ConvertToEntity<AspNetUsers>(query);

            return aspnetuser;
        }

        public async Task<Agente> SaveUsuarioAgente(Agente agente, string keyConnection)
        {
            Agente proAgente = new Agente();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "SAVEAGENTE"},
                new SqlParameter { ParameterName = "@NroId", Value = agente.NroId},
                new SqlParameter { ParameterName = "@Nombre", Value = agente.NombreCompleto},
                new SqlParameter { ParameterName = "@Email", Value = agente.Email},
                 new SqlParameter { ParameterName = "@RecibeEmail", Value = agente.RecibeEmail},
                 new SqlParameter { ParameterName = "@Area", Value = agente.Area},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PERFILES", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proAgente = Functions.ConvertToEntity<Agente>(query);

            return proAgente;
        }
    }
}