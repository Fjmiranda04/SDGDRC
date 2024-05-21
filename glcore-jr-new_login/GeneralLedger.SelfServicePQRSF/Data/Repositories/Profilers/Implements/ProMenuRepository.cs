using Dapper;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers.Implements
{
    public class ProMenuRepository : Repository<MenuUsuario>, IProMenuRepository
    {
        private readonly SelfServiceContext Context;
        private readonly IConfiguration configuration;
        public ProMenuRepository(SelfServiceContext Context, IConfiguration configuration) : base(Context)
        {
            this.Context = Context;
            this.configuration = configuration;
        }

        public async Task<IEnumerable<MenuUsuario>> GetMenusByUser(string CodigoUsuario, string CodigoRol, string keyConnection)
        {
            List<MenuUsuario> menuUsuarios = new List<MenuUsuario>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_BY_USER"},
                new SqlParameter { ParameterName = "@CodigoUsuario", Value = CodigoUsuario},
                new SqlParameter { ParameterName = "@CodigoRol", Value = CodigoRol},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_MENUS", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            menuUsuarios = Functions.ConvertToList<MenuUsuario>(query);

            return menuUsuarios;

        }

        public async Task<IEnumerable<MenuUsuario>> GetMenus(string keyConnection)
        {
            List<MenuUsuario> menuUsuarios = new List<MenuUsuario>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET"},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_MENUS", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            menuUsuarios = Functions.ConvertToList<MenuUsuario>(query);

            return menuUsuarios;

        }

        public async Task<MenuUsuario> RemoveMenuUsuario(string CodigoMenu, string CodigoUsuario, string keyConnection)
        {
            MenuUsuario menuUsuario = new MenuUsuario();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "REMOVE_MENU_USER"},
                new SqlParameter { ParameterName = "@CodigoMenu", Value = CodigoMenu},
                new SqlParameter { ParameterName = "@CodigoUsuario", Value = CodigoUsuario},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_MENUS", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            menuUsuario = Functions.ConvertToEntity<MenuUsuario>(query);

            return menuUsuario;
        }

        public async Task<MenuUsuario> AddMenuUsuario(string CodigoMenu, string CodigoUsuario, string keyConnection)
        {
            MenuUsuario menuUsuario = new MenuUsuario();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "ADD_MENU_USER"},
                new SqlParameter { ParameterName = "@CodigoMenu", Value = CodigoMenu},
                new SqlParameter { ParameterName = "@CodigoUsuario", Value = CodigoUsuario},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_MENUS", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            menuUsuario = Functions.ConvertToEntity<MenuUsuario>(query);

            return menuUsuario;
        }
    }
}
