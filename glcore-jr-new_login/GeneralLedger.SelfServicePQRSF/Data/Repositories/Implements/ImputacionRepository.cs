using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class ImputacionRepository : GenericRepository<Imputacion>, IImputacionRepository
    {
        private readonly SelfServiceContext contex;
        private readonly IConfiguration configuration;

        public ImputacionRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.contex = contex;
            this.configuration = configuration;
        }

        public async Task<IEnumerable<Imputacion>> GetImputaciones(string nroFactura)
        {
            var parametros = new SqlParameter[]{
                new SqlParameter(){ParameterName = "@Operacion",Value = "IMP",IsNullable = true},
                new SqlParameter(){ParameterName = "@Factura",Value = nroFactura,IsNullable = true},
                new SqlParameter(){ParameterName = "@TipoFac",Value = "FR",IsNullable = true},
            };

            return await ExecuteStoredProcedure(parametros, "PA_ViewCMIVentas");
        }
    }
}