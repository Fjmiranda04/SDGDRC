using Dapper;
using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class AnalisisVencimientoRepository : GenericRepository<AnalisisVencimiento>, IAnalisisVencimientoRepository
    {
        private readonly SelfServiceContext contex;
        private readonly IConfiguration configuration;

        public AnalisisVencimientoRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.contex = contex;
            this.configuration = configuration;
        }

        public async Task<IEnumerable<AnalisisVencimiento>> GetAnalisisVencimientoByCliente(string search, string nit, string endDate, string startDate = "", int daysRange = 2, bool cancel = false)
        {
            var operacion = cancel ? "SCan" : "S";
            List<AnalisisVencimiento> analisis = new List<AnalisisVencimiento>();

            var parametros = new DynamicParameters();

            parametros.Add("Operacion", operacion);
            parametros.Add("SubOperacion", string.Empty);
            parametros.Add("FechaIni", startDate);
            parametros.Add("FechaFin", endDate);
            parametros.Add("rangoDias", daysRange);
            parametros.Add("clinit", nit);
            parametros.Add("NDocumento", string.Empty);
            parametros.Add("SuperSalud", string.Empty);
            parametros.Add("Anno", string.Empty);
            parametros.Add("Anno1", string.Empty);
            parametros.Add("codCliente", string.Empty);
            parametros.Add("search", search);

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            return await connection.QueryAsync<AnalisisVencimiento>("WEBGLSS_SP_AnalisisVenCMI", parametros, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AnalisisVencimientoEstadistica>> GetAnalisisVencimientoEstadisticas(string date, string rango, string keyConnection)
        {


            var parms = new DynamicParameters();

            parms.Add("Operacion", "S");
            parms.Add("FechaFin", date.Replace("-", ""));
            parms.Add("rangoDias", rango);

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            return await connection.QueryAsync<AnalisisVencimientoEstadistica>("WEBGLSS_SP_AnalisisVenCMI", parms, commandType: CommandType.StoredProcedure);
        }

        public async Task<Recaudos> GetRecaudoCartera(string date, string keyConnection)
        {
            List<RecaudoCartera> recaudoCartera1 = new();
            List<RecaudoCartera> recaudoCartera2 = new();
            Recaudos recaudos = new Recaudos();

            var parms = new DynamicParameters();

            parms.Add("Operacion", "GET_CARTERA");
            parms.Add("FechaFin", date.Replace("-", ""));

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            recaudoCartera1 = connection.Query<RecaudoCartera>("WEBGLSS_SP_AnalisisVenCMI", parms, commandType: CommandType.StoredProcedure).ToList();

            var parms2 = new DynamicParameters();

            parms2.Add("Operacion", "GET_RECAUDO");
            parms2.Add("FechaFin", date.Replace("-", ""));

            recaudoCartera2 = connection.Query<RecaudoCartera>("WEBGLSS_SP_AnalisisVenCMI", parms2, commandType: CommandType.StoredProcedure).ToList();

            recaudos.ListCartera = recaudoCartera1;
            recaudos.ListRecaudo = recaudoCartera2;

            return recaudos;
        }
    }
}