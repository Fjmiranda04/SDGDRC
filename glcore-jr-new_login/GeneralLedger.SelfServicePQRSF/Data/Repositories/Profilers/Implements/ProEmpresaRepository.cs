using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers.Implements
{
    public class ProEmpresaRepository : Repository<Empresa>, IProEmpresaRepository
    {
        private readonly SelfServiceContext Context;
        private readonly IConfiguration configuration;

        public ProEmpresaRepository(SelfServiceContext Context, IConfiguration configuration) : base(Context)
        {
            this.Context = Context;
            this.configuration = configuration;
        }

        public async Task<Empresa> GetEmpresa(string Nit, string KeyConnection)
        {
            Empresa proEmpresa = new Empresa();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_EMPRESA"},
                new SqlParameter { ParameterName = "@Nit", Value = Nit},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(KeyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_EMPRESA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proEmpresa = Functions.ConvertToEntity<Empresa>(query);

            return proEmpresa;
        }

        public async Task<IEnumerable<Empresa>> GetEmpresas(string KeyConnection)
        {
            List<Empresa> proEmpresas = new List<Empresa>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_EMPRESAS"},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(KeyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_EMPRESA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proEmpresas = Functions.ConvertToList<Empresa>(query);

            return proEmpresas;
        }

        public async Task<UsuarioEmpresa> GetUsuarioEmpresa(string Email, string KeyConnection)
        {
            UsuarioEmpresa proUsuarioEmpresa = new UsuarioEmpresa();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_US_EMPRESA"},
                new SqlParameter { ParameterName = "@EmailPrincipal", Value = Email},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(KeyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_EMPRESA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proUsuarioEmpresa = Functions.ConvertToEntity<UsuarioEmpresa>(query);

            return proUsuarioEmpresa;
        }

        public async Task<Empresa> SaveEmpresa(Empresa empresa, string KeyConnection)
        {
            Empresa proEmpresa = new Empresa();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_EMPRESAS"},
                new SqlParameter { ParameterName = "@Nit", Value = empresa.Nit},
                new SqlParameter { ParameterName = "@DIV", Value = empresa.DIV},
                new SqlParameter { ParameterName = "@Nombre", Value = empresa.Nombre},
                new SqlParameter { ParameterName = "@CodigoLegacy", Value = empresa.CodigoLegacy},
                new SqlParameter { ParameterName = "@EmailPrincipal", Value = empresa.EmailPrincipal},
                new SqlParameter { ParameterName = "@Estado", Value = empresa.Estado},
                new SqlParameter { ParameterName = "@IP", Value = empresa.IP},
                new SqlParameter { ParameterName = "@DB", Value = empresa.DB},
                new SqlParameter { ParameterName = "@KeyConnection", Value = empresa.KeyConnection},
                new SqlParameter { ParameterName = "@UrlWeb", Value = empresa.UrlWeb},
                new SqlParameter { ParameterName = "@Logo", Value = empresa.Logo},
                new SqlParameter { ParameterName = "@FechaRegistro", Value = empresa.FechaRegistro},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(KeyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_EMPRESA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proEmpresa = Functions.ConvertToEntity<Empresa>(query);

            return proEmpresa;
        }

        public async Task<UsuarioEmpresa> SaveUsuarioEmpresa(UsuarioEmpresa usuarioEmpresa, string KeyConnection)
        {
            UsuarioEmpresa proUsuarioEmpresa = new UsuarioEmpresa();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "SAVE_US_EMPRESA"},
                new SqlParameter { ParameterName = "@IdEmpresa", Value = usuarioEmpresa.IdEmpresa},
                new SqlParameter { ParameterName = "@NitEmpresa", Value = usuarioEmpresa.NitEmpresa},
                new SqlParameter { ParameterName = "@Nit", Value = usuarioEmpresa.NroIde},
                new SqlParameter { ParameterName = "@EmailPrincipal", Value = usuarioEmpresa.Email},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(KeyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_EMPRESA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proUsuarioEmpresa = Functions.ConvertToEntity<UsuarioEmpresa>(query);

            return proUsuarioEmpresa;
        }

        public async Task RemoveUsuarioEmpresa(int IdUsuarioEmpresa, string KeyConnection)
        {
            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "REMOVE_US_EMPRESA"},
                new SqlParameter { ParameterName = "@IdUsuarioEmpresa", Value = IdUsuarioEmpresa},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(KeyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_EMPRESA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);
        }

        public async Task<Empresa> GetDataEmpresa(string salt, string KeyConnection)
        {
            Empresa proEmpresas = new Empresa();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_EMPRESA_SALT"},
                new SqlParameter { ParameterName = "@Salt", Value = salt},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(KeyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_EMPRESA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proEmpresas = Functions.ConvertToEntity<Empresa>(query);

            return proEmpresas;
        }

        public async Task<EmpresaGL> GetEmpresaGL(string KeyConnection)
        {
            EmpresaGL proEmpresa = new EmpresaGL();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_EMPRESA_GL"},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(KeyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_EMPRESAGL", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proEmpresa = Functions.ConvertToEntity<EmpresaGL>(query);

            return proEmpresa;
        }
    }
}