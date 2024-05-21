using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers.Implements
{
    public class ProPqrsfRepository : Repository<ProPqrsf>, IProPqrsfRepository
    {
        private readonly SelfServiceContext Context;
        private readonly IConfiguration configuration;

        public ProPqrsfRepository(SelfServiceContext Context, IConfiguration configuration) : base(Context)
        {
            this.Context = Context;
            this.configuration = configuration;
        }

        public async Task<IEnumerable<ProPqrsf>> GetStatistics(string CodigoAgente, string keyConnection)
        {
            List<ProPqrsf> proStatistics = new List<ProPqrsf>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "STATISTICS_A"},
                new SqlParameter { ParameterName = "@CodigoAgente", Value = CodigoAgente},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PQRSF", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proStatistics = Functions.ConvertToList<ProPqrsf>(query);

            return proStatistics;
        }

        public async Task<IEnumerable<AyerVsHoy>> GetAyerVsHoyPqrsf(string CodigoAgente, string keyConnection)
        {
            List<AyerVsHoy> ayerVsHoy = new List<AyerVsHoy>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "PQRSF_A_VS_H"},
                new SqlParameter { ParameterName = "@CodigoAgente", Value = CodigoAgente},
                new SqlParameter { ParameterName = "@FechaConsulta", Value = DateTime.Now.ToString("yyyMMdd")},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PQRSF", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            ayerVsHoy = Functions.ConvertToList<AyerVsHoy>(query);

            return ayerVsHoy;
        }

        public async Task<DataByPeriodo> GetDataByPerido(string CodigoAgente, string Mes, string Anio, string keyConnection)
        {
            DataByPeriodo dataByPeriodo = new DataByPeriodo();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "PQRSF_PY_P_A"},
                new SqlParameter { ParameterName = "@CodigoAgente", Value = CodigoAgente},
                new SqlParameter { ParameterName = "@Mes", Value = Mes},
                new SqlParameter { ParameterName = "@Anio", Value =Anio},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PQRSF", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            dataByPeriodo = Functions.ConvertToEntity<DataByPeriodo>(query);

            decimal porcentaje = 100;

            dataByPeriodo.PorcentajeUpDownAsignadas = ((dataByPeriodo.Asignadas - dataByPeriodo.AsignadasPasado) / ((dataByPeriodo.AsignadasPasado == 0) ? 1 : dataByPeriodo.AsignadasPasado)) * porcentaje;
            dataByPeriodo.PorcentajeUpDownResueltas = ((dataByPeriodo.Resueltas - dataByPeriodo.ResueltasPasado) / ((dataByPeriodo.ResueltasPasado == 0) ? 1 : dataByPeriodo.ResueltasPasado)) * porcentaje;
            dataByPeriodo.PorcentajeUpDownAsignadasProm = ((dataByPeriodo.PromedioAsignadas - dataByPeriodo.PromedioAsignadasPasado) / ((dataByPeriodo.PromedioAsignadasPasado == 0) ? 1 : dataByPeriodo.PromedioAsignadasPasado)) * porcentaje;
            dataByPeriodo.PorcentajeUpDownResueltasProm = ((dataByPeriodo.PromedioResueltas - dataByPeriodo.PromedioResueltasPasado) / ((dataByPeriodo.PromedioResueltasPasado == 0) ? 1 : dataByPeriodo.PromedioResueltasPasado)) * porcentaje;

            return dataByPeriodo;
        }

        public async Task<IEnumerable<PqrsfByDay>> GetPqrsfByDay(string CodigoAgente, string Mes, string Anio, string keyConnection)
        {
            List<PqrsfByDay> pqrsfByDay = new List<PqrsfByDay>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "PQRSF_BY_DAY_A"},
                new SqlParameter { ParameterName = "@CodigoAgente", Value = CodigoAgente},
                new SqlParameter { ParameterName = "@Mes", Value = Mes},
                new SqlParameter { ParameterName = "@Anio", Value =Anio},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PQRSF", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            pqrsfByDay = Functions.ConvertToList<PqrsfByDay>(query);

            return pqrsfByDay;
        }

        public async Task<ProPqrsf> SavePqrsf(PQRSF pqrsf, string keyConnection)
        {
            ProPqrsf proPqrsf = new ProPqrsf();
            pqrsf.Tipo = "PQRSF Externa";
            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "SAVE_PQRSF"},
                new SqlParameter { ParameterName = "@TipoPeticion", Value = pqrsf.Tipo},
                new SqlParameter { ParameterName = "@Fecha", Value = pqrsf.Fecha},
                new SqlParameter { ParameterName = "@NroIdeCli", Value = pqrsf.NroIdeCli},
                new SqlParameter { ParameterName = "@NitEmpresa", Value = pqrsf.NitEmpresa},
                new SqlParameter { ParameterName = "@IdSituacion", Value =pqrsf.IdSituacion},
                new SqlParameter { ParameterName = "@IdContacto", Value =pqrsf.IdContacto},
                new SqlParameter { ParameterName = "@Asunto", Value =pqrsf.Asunto},
                new SqlParameter { ParameterName = "@Descripcion", Value =pqrsf.Descripcion},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PQRSF", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proPqrsf = Functions.ConvertToEntity<ProPqrsf>(query);

            return proPqrsf;
        }

        public async Task<IEnumerable<TratamientoPQRSF>> GetTratamientos(string NroId, string keyConnection)
        {
            List<TratamientoPQRSF> tratamientoPqrsf = new List<TratamientoPQRSF>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_TRATAMIENTO"},
                new SqlParameter { ParameterName = "@NroIdeCli", Value = NroId},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PQRSF", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            tratamientoPqrsf = Functions.ConvertToList<TratamientoPQRSF>(query);

            return tratamientoPqrsf;
        }
    }
}