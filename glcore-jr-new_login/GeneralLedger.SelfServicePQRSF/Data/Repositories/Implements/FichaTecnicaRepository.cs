using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class FichaTecnicaRepository : GenericRepository<FichaTecnica>, IFichaTecnicaRepository
    {
        private readonly SelfServiceContext contex;
        private readonly IConfiguration configuration;

        public FichaTecnicaRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.contex = contex;
            this.configuration = configuration;
        }

        public async Task<FichaTecnica> GetFichaTecnica(string nroFactura)
        {
            var parametros = new SqlParameter[]{
                new SqlParameter(){ParameterName = "@Operacion",Value = "FICHA_FACTURA",IsNullable = true},
                new SqlParameter(){ParameterName = "@Factura",Value = nroFactura,IsNullable = true},
                new SqlParameter(){ParameterName = "@TipoFac",Value = "FR",IsNullable = true},
                new SqlParameter(){ParameterName = "@FechaIni",Value = "",IsNullable = true},
                new SqlParameter(){ParameterName = "@FechaFin",Value = "",IsNullable = true},
            };

            var result = await ExecuteStoredProcedure(parametros, "WEBGLSS_SP_AnalisisVenCMI");

            return result.FirstOrDefault();
        }
    }
}