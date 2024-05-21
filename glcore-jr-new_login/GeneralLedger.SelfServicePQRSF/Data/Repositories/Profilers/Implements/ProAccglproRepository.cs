using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers.Implements
{
    public class ProAccglproRepository : Repository<AccglPro>, IProAccglproRepository
    {
        private readonly SelfServiceContext Context;
        private readonly IConfiguration configuration;

        public ProAccglproRepository(SelfServiceContext Context, IConfiguration configuration) : base(Context)
        {
            this.configuration = configuration;
            this.Context = Context;
        }

        public async Task<AccglPro> SaveProponente(AccglPro proponente, string keyConnection)
        {
            AccglPro proProponete = new AccglPro();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "SAVE_PROPONENTE"},
                new SqlParameter { ParameterName = "@Pronit", Value = proponente.Pronit},
                new SqlParameter { ParameterName = "@Pronit1", Value = proponente.Pronit1},
                new SqlParameter { ParameterName = "@TipDoc", Value = proponente.TipDocu},
                new SqlParameter { ParameterName = "@DigVer", Value = proponente.DigVer},
                new SqlParameter { ParameterName = "@ProPersona", Value = proponente.ProPersona},
                new SqlParameter { ParameterName = "@Pronom", Value = proponente.Pronom},
                new SqlParameter { ParameterName = "@proreplegal", Value = proponente.Proreplegal},
                new SqlParameter { ParameterName = "@proced", Value = proponente.Proced},
                new SqlParameter { ParameterName = "@Proconta", Value = proponente.Proconta},
                new SqlParameter { ParameterName = "@Procargo", Value = proponente.Procargo},
                new SqlParameter { ParameterName = "@Promail", Value = proponente.Promail},
                new SqlParameter { ParameterName = "@Protel", Value = proponente.Protel},
                new SqlParameter { ParameterName = "@Procel1", Value = proponente.Procel},
                new SqlParameter { ParameterName = "@Profax", Value = proponente.Profax},
                new SqlParameter { ParameterName = "@Prodir", Value = proponente.Prodir},
                new SqlParameter { ParameterName = "@Proconta2", Value = proponente.Proconta2},
                new SqlParameter { ParameterName = "@Procodciud", Value = proponente.ProCodCiud},
                new SqlParameter { ParameterName = "@ProPais", Value = proponente.ProPais},
                new SqlParameter { ParameterName = "@Rut", Value = proponente.Rut},
                new SqlParameter { ParameterName = "@Fechav", Value = proponente.Fechav},
                new SqlParameter { ParameterName = "@Nummatri", Value = proponente.Nummatri},
                new SqlParameter { ParameterName = "@InscrR", Value = proponente.InscrR},
                new SqlParameter { ParameterName = "@Rup", Value = proponente.Rup},
                new SqlParameter { ParameterName = "@certie", Value = proponente.Certie},
                new SqlParameter { ParameterName = "@bienservi", Value = proponente.Bienser},
                new SqlParameter { ParameterName = "@Password", Value = proponente.Password},
                new SqlParameter { ParameterName = "@IdEmpresa", Value = proponente.IdEmpresa},
                new SqlParameter { ParameterName = "@NitEmpresa", Value = proponente.NitEmpresa},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PROVEEDORES", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proProponete = Functions.ConvertToEntity<AccglPro>(query);

            return proProponete;
        }
    }
}