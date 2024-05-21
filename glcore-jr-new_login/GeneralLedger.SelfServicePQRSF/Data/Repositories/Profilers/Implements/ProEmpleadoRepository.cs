using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers.Implements
{
    public class ProEmpleadoRepository : Repository<Empleado>, IProEmpleadoRepository
    {
        private readonly SelfServiceContext Context;
        private readonly IConfiguration configuration;
        public ProEmpleadoRepository(SelfServiceContext Context, IConfiguration configuration) : base(Context)
        {
            this.Context = Context;
            this.configuration = configuration;
        }

        public async Task<Empleado> GetEmpleadoByCodigo(string CodigoEmpleado, string KeyConnection)
        {
            Empleado empleado = new Empleado();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_BY_CODIGO"},
                new SqlParameter { ParameterName = "@CodigoEmpleado", Value = CodigoEmpleado},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(KeyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_EMPLEADO", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            empleado = Functions.ConvertToEntity<Empleado>(query);

            return empleado;
        }

        public async Task<Empleado> GetEmpleadoByNit(string NitEmpleado, string KeyConnection)
        {
            Empleado empleado = new Empleado();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_BY_NIT"},
                new SqlParameter { ParameterName = "@NitEmpleado", Value = NitEmpleado},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(KeyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_EMPLEADO", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            empleado = Functions.ConvertToEntity<Empleado>(query);

            return empleado;
        }

        public async Task<List<EmpleadoShowDTO>> GetAllEmpleados(string KeyConnection)
        {
            List<EmpleadoShowDTO> empleados = new List<EmpleadoShowDTO>();

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Operacion", "Get_Emp")
            };

            var connection = new SqlConnection(configuration.GetConnectionString(KeyConnection));

            var query = await ExecuteQueryDataTable("ObtenerDatos", null, CommandType.StoredProcedure, parameters.ToArray(), connection);

            foreach (DataRow row in query.Rows)
            {
                EmpleadoShowDTO empleado = new EmpleadoShowDTO();

                if (!row.IsNull("CodigoEmpleado"))
                {
                    empleado.NroIdEmp = row["CodigoEmpleado"].ToString();
                }

                if (!row.IsNull("NombreEmpleado"))
                {
                    empleado.NombreCompleto = row["NombreEmpleado"].ToString();
                }

                if (!row.IsNull("PrestacionServicio"))
                {
                    empleado.Eps = row["PrestacionServicio"].ToString();
                }

                empleados.Add(empleado);
            }

            return empleados;
        }



    }
}
