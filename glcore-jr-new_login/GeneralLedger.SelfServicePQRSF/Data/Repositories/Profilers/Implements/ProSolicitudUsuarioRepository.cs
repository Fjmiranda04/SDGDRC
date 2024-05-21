using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers.Implements
{
    public class ProSolicitudUsuarioRepository : Repository<SolicitudCliente>, IProSolicitudUsuarioRepository
    {
        private readonly SelfServiceContext Context;
        private readonly IConfiguration configuration;

        public ProSolicitudUsuarioRepository(SelfServiceContext Context, IConfiguration configuration) : base(Context)
        {
            this.Context = Context;
            this.configuration = configuration;
        }

        public async Task<SolicitudCliente> SaveSolicitudCliente(SolicitudCliente solicitudCliente, string Key)
        {
            SolicitudCliente proSolicitudCliente = new SolicitudCliente();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "SAVE_SOL_CLI"},
                new SqlParameter { ParameterName = "@Codigo", Value = solicitudCliente.Codigo},
                new SqlParameter { ParameterName = "@NroIde", Value = solicitudCliente.NroIde},
                new SqlParameter { ParameterName = "@TipDoc", Value = solicitudCliente.TipDoc},
                new SqlParameter { ParameterName = "@NombreCompleto", Value = solicitudCliente.NombreCompleto},
                new SqlParameter { ParameterName = "@PrimerNombre", Value = solicitudCliente.PrimerNombre},
                new SqlParameter { ParameterName = "@SegundoNombre", Value = solicitudCliente.SegundoNombre},
                new SqlParameter { ParameterName = "@PrimerApellido", Value = solicitudCliente.PrimerApellido},
                new SqlParameter { ParameterName = "@SegundoApellido", Value = solicitudCliente.SegundoApellido},
                new SqlParameter { ParameterName = "@Ciudad", Value = solicitudCliente.Ciudad},
                new SqlParameter { ParameterName = "@Direccion", Value = solicitudCliente.Direccion},
                new SqlParameter { ParameterName = "@Celular", Value = solicitudCliente.Celular},
                new SqlParameter { ParameterName = "@Telefono", Value = solicitudCliente.Telefono},
                new SqlParameter { ParameterName = "@Email", Value = solicitudCliente.Email},
                new SqlParameter { ParameterName = "@FechaCreacion", Value = solicitudCliente.FechaCreacion},
                new SqlParameter { ParameterName = "@NitEmpresa", Value = solicitudCliente.NitEmpresa},
                new SqlParameter { ParameterName = "@Estado", Value = solicitudCliente.Estado},
                new SqlParameter { ParameterName = "@Password", Value = solicitudCliente.Password},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(Key));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_SOLICITUD_USUARIO", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proSolicitudCliente = Functions.ConvertToEntity<SolicitudCliente>(query);

            return proSolicitudCliente;
        }
    }
}