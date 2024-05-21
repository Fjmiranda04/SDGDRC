using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class SolicitanteCtzRepository : GenericRepository<CliOtrosContactos>, ISolicitanteCtzRepository
    {
        private readonly SelfServiceContext contex;
        private readonly IConfiguration configuration;
        public SolicitanteCtzRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.contex = contex;
            this.configuration = configuration;
        }
        public async Task<IEnumerable<SolicitanteCtzListDTO>> GetSolicitantes(string filter, string nitCliente)
        {
            List<SolicitanteCtzListDTO> solicitantes = new List<SolicitanteCtzListDTO>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GETSOLIC"},
                new SqlParameter { ParameterName = "@NroIdCliente", Value = nitCliente},
                new SqlParameter { ParameterName = "@Filter", Value = filter}
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_VENTAS", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            solicitantes = Functions.ConvertToList<SolicitanteCtzListDTO>(query);

            return solicitantes;
        }
    }
}
