using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class ServicioRepository : GenericRepository<Servicio>, IServicioRepository
    {
        private readonly SelfServiceContext contex;
        private readonly IConfiguration configuration;

        public ServicioRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.contex = contex;
            this.configuration = configuration;
        }

        public async Task<IEnumerable<ServicioShowDTO>> GetServicios()
        {
            //return await (from servicio in contex.Trabajos
            //              select new Servicio
            //              {
            //                  tracod = servicio.Tracod,
            //                  trades = servicio.Trades,
            //                  tranom = servicio.Tranom,
            //                  traiva = servicio.Traiva,
            //                  arprecio = servicio.Arprecio,
            //                  Costo = servicio.Costo,
            //                  tramed = servicio.Tramed
            //              }).ToListAsync();
            List<ServicioShowDTO> servicios = new List<ServicioShowDTO>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GETSERVICIOS"},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PEDIDOS", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            servicios = Functions.ConvertToList<ServicioShowDTO>(query);

            return servicios;
        }
    }
}