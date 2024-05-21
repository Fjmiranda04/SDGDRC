using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class GestionHumanaRepository : GenericRepository<GestionHumana>, IGestionHumanaRepository
    {
        private readonly SelfServiceContext contex;
        private readonly IConfiguration configuration;

        public GestionHumanaRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.contex = contex;
            this.configuration = configuration;
        }

        public async Task<List<BancosShowDTO>> GetBancos(string keyConnection)
        {
            List<BancosShowDTO> bancos = new List<BancosShowDTO>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GETBANCOS"},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_GESTIONHUMANA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            bancos = Functions.ConvertToList<BancosShowDTO>(query);

            return bancos;
        }

        public async Task<CartaBancoShowDTO> GetCartaBancos(string NumeroCedula, string Banco, string keyConnection)
        {
            CartaBancoShowDTO cartaBanco = new CartaBancoShowDTO();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GETCARTABAN"},
                new SqlParameter { ParameterName = "@NumeroCedula", Value = NumeroCedula},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_GESTIONHUMANA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            cartaBanco = Functions.ConvertToEntity<CartaBancoShowDTO>(query);

            return cartaBanco;
        }

        public async Task<CertificadoLaboralSShowDTO> GetCertificadoLaboral(string NumeroCedula, string Periodo, string keyConnection)
        {
            CertificadoLaboralSShowDTO datos = new CertificadoLaboralSShowDTO();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GETCERLAB"},
                new SqlParameter { ParameterName = "@NumeroCedula", Value = NumeroCedula},
                new SqlParameter { ParameterName = "@Periodo", Value = Periodo}
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_GESTIONHUMANA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            datos = Functions.ConvertToEntity<CertificadoLaboralSShowDTO>(query);

            return datos;
        }

        public async Task<CertificadoLaboralSShowDTO> GetCertificadoLaboralS(string NumeroCedula, string keyConnection)
        {
            CertificadoLaboralSShowDTO datos = new CertificadoLaboralSShowDTO();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GETCERLABS"},
                new SqlParameter { ParameterName = "@NumeroCedula", Value = NumeroCedula}
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_GESTIONHUMANA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            datos = Functions.ConvertToEntity<CertificadoLaboralSShowDTO>(query);

            return datos;
        }

        public async Task<IEnumerable<ComprobantePagoEmpleado>> GetComprobantePago(string NumeroCedula, string FechaI, string FechaF, string keyConnection)
        {
            List<ComprobantePagoEmpleado> comprobante = new List<ComprobantePagoEmpleado>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@tipoRpt", Value = "xEmpleado"},
                new SqlParameter { ParameterName = "@FechaIni", Value = FechaI},
                new SqlParameter { ParameterName = "@FechaFin", Value = FechaF},
                new SqlParameter { ParameterName = "@EMPLEADO", Value = NumeroCedula}
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("Proc_CbtePagoEmpleadoNet", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            comprobante = Functions.ConvertToList<ComprobantePagoEmpleado>(query);

            return comprobante;
        }

        public async Task<ContratoLaboralShowDTO> GetContratoLaboral(string NumeroCedula, string keyConnection)
        {
            ContratoLaboralShowDTO contrato = new ContratoLaboralShowDTO();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GETCONTRATO"},
                new SqlParameter { ParameterName = "@NumeroCedula", Value = NumeroCedula}
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_GESTIONHUMANA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            contrato = Functions.ConvertToEntity<ContratoLaboralShowDTO>(query);

            return contrato;
        }

        public async Task<ExamenIngresoShowDTO> GetExamenIngreso(string NumeroCedula, string keyConnection)
        {
            ExamenIngresoShowDTO examen = new ExamenIngresoShowDTO();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GETEXAMI"},
                new SqlParameter { ParameterName = "@NumeroCedula", Value = NumeroCedula}
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_GESTIONHUMANA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            examen = Functions.ConvertToEntity<ExamenIngresoShowDTO>(query);

            return examen;
        }

        public async Task<IEnumerable<HistorialLaboralEmpleado>> GetHistorialLaboral(string NumeroCedula, string keyConnection)
        {
            List<HistorialLaboralEmpleado> historial = new List<HistorialLaboralEmpleado>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_HIST_LAB_EMP"},
                new SqlParameter { ParameterName = "@NumeroCedula", Value = NumeroCedula}
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_GESTIONHUMANA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            historial = Functions.ConvertToList<HistorialLaboralEmpleado>(query);

            return historial;
        }
    }
}