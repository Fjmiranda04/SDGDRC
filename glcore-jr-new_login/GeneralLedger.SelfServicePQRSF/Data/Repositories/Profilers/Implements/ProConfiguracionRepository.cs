using Dapper;
using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers.Implements
{
    public class ProConfiguracionRepository : Repository<ProConfiguracion>, IProConfiguracionRespository
    {
        private readonly SelfServiceContext Context;
        private readonly IConfiguration configuration;

        public ProConfiguracionRepository(SelfServiceContext Context, IConfiguration configuration) : base(Context)
        {
            this.configuration = configuration;
            this.Context = Context;
        }

        public async Task<string> ChangeEmail(string Email, string CodigoAgente, string NitEmpresa, string keyConnection)
        {
            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "CHANGE_EMAIL"},
                new SqlParameter { ParameterName = "@CodigoAgente", Value = CodigoAgente},
                new SqlParameter { ParameterName = "@Email", Value = Email},
                new SqlParameter { ParameterName = "@NitEmpresa", Value = NitEmpresa},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_CONFIG", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            return Email;
        }

        public async Task<IEnumerable<ProPermisos>> GetPermisos(string search, string keyConnection)
        {
            List<ProPermisos> proPermisos = new List<ProPermisos>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_PERMISOS"},
                new SqlParameter { ParameterName = "@Search", Value = search},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_CONFIG", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proPermisos = Functions.ConvertToList<ProPermisos>(query);

            return proPermisos;
        }

        public async Task<ProPermisos> GetPermiso(int idPermiso, string keyConnection)
        {
            ProPermisos proPermiso = new ProPermisos();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_PERMISO"},
                new SqlParameter { ParameterName = "@idPermiso", Value = idPermiso},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_CONFIG", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proPermiso = Functions.ConvertToEntity<ProPermisos>(query);

            return proPermiso;
        }

        public async Task<ProPermisos> SavePermiso(int idPermiso, string permiso, string tipo, string descripcion, string keyConnection)
        {
            ProPermisos proPermiso = new ProPermisos();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "SAVE_PERMISO"},
                new SqlParameter { ParameterName = "@IdPermiso", Value = idPermiso},
                new SqlParameter { ParameterName = "@Permiso", Value = permiso},
                new SqlParameter { ParameterName = "@Tipo", Value = tipo},
                new SqlParameter { ParameterName = "@Descripcion", Value = descripcion},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_CONFIG", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proPermiso = Functions.ConvertToEntity<ProPermisos>(query);

            return proPermiso;
        }

        public async Task<IEnumerable<ProPermisosUsuarios>> GetPermisosUsuario(string idUsuario, string keyConnection)
        {
            List<ProPermisosUsuarios> proPermisoUsuarios = new List<ProPermisosUsuarios>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_PERMISOS_USER"},
                new SqlParameter { ParameterName = "@IdUsuario", Value = idUsuario},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_CONFIG", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proPermisoUsuarios = Functions.ConvertToList<ProPermisosUsuarios>(query);

            return proPermisoUsuarios;
        }

        public async Task<ProPermisos> SavePermisoUsuario(string idUsuario, int idPermiso, string keyConnection)
        {
            ProPermisos proPermiso = new ProPermisos();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "SAVE_PERMISO_US"},
                new SqlParameter { ParameterName = "@IdPermiso", Value = idPermiso},
                new SqlParameter { ParameterName = "@IdUsuario", Value = idUsuario},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_CONFIG", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proPermiso = Functions.ConvertToEntity<ProPermisos>(query);

            return proPermiso;
        }

        public async Task<IEnumerable<ProRolesUsuarios>> GetRolesUsuario(string idUsuario, string keyConnection)
        {
            List<ProRolesUsuarios> proRolesUsuarios = new List<ProRolesUsuarios>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_ROLES_US"},
                new SqlParameter { ParameterName = "@IdUsuario", Value = idUsuario},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_CONFIG", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proRolesUsuarios = Functions.ConvertToList<ProRolesUsuarios>(query);

            return proRolesUsuarios;
        }

        public async Task<ProRolesUsuarios> SaveRolUsuario(string idUsuario, string idRol, string keyConnection)
        {
            ProRolesUsuarios proRolUsuario = new ProRolesUsuarios();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "SAVE_ROL_US"},
                new SqlParameter { ParameterName = "@IdRol", Value = idRol},
                new SqlParameter { ParameterName = "@IdUsuario", Value = idUsuario},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_CONFIG", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proRolUsuario = Functions.ConvertToEntity<ProRolesUsuarios>(query);

            return proRolUsuario;
        }

        public async Task<Configuracion> GetConfiguracion(string idConfiguracion, string keyConnection)
        {
            Configuracion proConfiguracion = new Configuracion();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_CONFIG"},
                new SqlParameter { ParameterName = "@Clave", Value = idConfiguracion},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_CONFIG", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proConfiguracion = Functions.ConvertToEntity<Configuracion>(query);

            return proConfiguracion;
        }

        public async Task<EmailConfiguracion> GetConfiguracionEmail(string clave, string keyConnection)
        {
            EmailConfiguracion proEmailConfiguracion = new EmailConfiguracion();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_CONFIG_EMAIL"},
                new SqlParameter { ParameterName = "@Clave", Value = clave},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_CONFIG", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proEmailConfiguracion = Functions.ConvertToEntity<EmailConfiguracion>(query);

            return proEmailConfiguracion;
        }

        public async Task<IEnumerable<Configuracion>> GetConfiguraciones(string keyConnection)
        {
            List<Configuracion> proConfiguraciones = new List<Configuracion>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_CONFIGS"},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_CONFIG", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proConfiguraciones = Functions.ConvertToList<Configuracion>(query);

            return proConfiguraciones;
        }

        public async Task<IEnumerable<ModelsGL.MenuUsuario>> GetMenusByUser(string nroIde, string idRol, string keyConnection)
        {
            List<ModelsGL.MenuUsuario> menuUsuarios = new List<ModelsGL.MenuUsuario>();

            var parms = new DynamicParameters();

            parms.Add("Operacion", "GET_MENU_US");
            parms.Add("NroIde", nroIde);
            parms.Add("IdRol", idRol);

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            return await connection.QueryAsync<ModelsGL.MenuUsuario>("WEBGLSS_SP_CONFIG", parms, commandType: CommandType.StoredProcedure);
        }

        public async Task<Archivo> SaveArchivo(Archivo archivo, string keyConnection)
        {
            Archivo proArchivo = new Archivo();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "SAVE_FILE"},
                new SqlParameter { ParameterName = "@IdPQRSF", Value = archivo.CodPQRSF},
                new SqlParameter { ParameterName = "@NombreArchivo", Value = archivo.Nombre},
                new SqlParameter { ParameterName = "@Ruta", Value = archivo.Ruta},
                new SqlParameter { ParameterName = "@Url", Value = archivo.Url},
                new SqlParameter { ParameterName = "@ContentType", Value = archivo.ContentType},
                new SqlParameter { ParameterName = "@NitEmpresa", Value = archivo.NitEmpresa},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PERFILES", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proArchivo = Functions.ConvertToEntity<Archivo>(query);

            return proArchivo;
        }

        public async Task<IEnumerable<Configuracion>> SaveConfiguraciones(List<Configuracion> configuraciones, string keyConnection)
        {
            List<Configuracion> configs = new List<Configuracion>();
            var dt = Functions.ConvertToDataTable(configuraciones);

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "SAVE_CONFIG"},
                new SqlParameter { ParameterName = "@dtCfg", Value = dt},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_CONFIG", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            configs = Functions.ConvertToList<Configuracion>(query);

            return configs;
        }
    }
}