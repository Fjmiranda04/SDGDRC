using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class CotizacionRepository : GenericRepository<AccglCotiza>, ICotizacionRepository
    {
        private readonly SelfServiceContext contex;
        private readonly IConfiguration configuration;

        public CotizacionRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.contex = contex;
            this.configuration = configuration;
        }

        public async Task<IEnumerable<CotizacionListDTO>> GetCotizaciones()
        {
            List<CotizacionListDTO> cotizaciones = new List<CotizacionListDTO>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GETCOTIZA"}
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_COTIZACIONES", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            cotizaciones = Functions.ConvertToList<CotizacionListDTO>(query);

            return cotizaciones;
        }
    }
}
