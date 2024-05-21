using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers.Implements
{
    public class ProGestionHumanaRepository : Repository<ProGestionHumana>, IProGestionHumanaRepository
    {
        private readonly SelfServiceContext Context;
        private readonly IConfiguration configuration;

        public ProGestionHumanaRepository(SelfServiceContext Context, IConfiguration configuration) : base(Context)
        {
            this.Context = Context;
            this.configuration = configuration;
        }

        public async Task<IEnumerable<ProCajaCompensacion>> GetCajasCompensacion(string search, string keyConnection)
        {
            List<ProCajaCompensacion> proCaja = new List<ProCajaCompensacion>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_ARP"},
                new SqlParameter { ParameterName = "@Search", Value = search},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_GESTION_HUMANA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proCaja = Functions.ConvertToList<ProCajaCompensacion>(query);

            return proCaja;
        }

        public async Task<IEnumerable<ProEps>> GetEps(string search, string keyConnection)
        {
            List<ProEps> proEps = new List<ProEps>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_EPS"},
                new SqlParameter { ParameterName = "@Search", Value = search},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_GESTION_HUMANA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proEps = Functions.ConvertToList<ProEps>(query);

            return proEps;
        }

        public async Task<IEnumerable<ProFondoCensantias>> GetFondosCesantias(string search, string keyConnection)
        {
            List<ProFondoCensantias> profc = new List<ProFondoCensantias>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_FC"},
                new SqlParameter { ParameterName = "@Search", Value = search},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_GESTION_HUMANA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            profc = Functions.ConvertToList<ProFondoCensantias>(query);

            return profc;
        }

        public async Task<IEnumerable<ProFondoPension>> GetFondosPension(string search, string keyConnection)
        {
            List<ProFondoPension> profp = new List<ProFondoPension>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_FP"},
                new SqlParameter { ParameterName = "@Search", Value = search},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_GESTION_HUMANA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            profp = Functions.ConvertToList<ProFondoPension>(query);

            return profp;
        }

        public async Task<EmpleadoNovedad> GetInfoEmpleadoNovedad(string cedulaEmpleado, string keyConnection)
        {
            EmpleadoNovedad empnov = new EmpleadoNovedad();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_EMP_INFO"},
                new SqlParameter { ParameterName = "@Identificacion", Value = cedulaEmpleado},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_GESTION_HUMANA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            empnov = Functions.ConvertToEntity<EmpleadoNovedad>(query);

            return empnov;
        }

        public async Task<IEnumerable<SolicitudNovedad>> GetSolicitudesNovedadByEmpleado(string cedulaEmpleado, string keyConnection)
        {
            List<SolicitudNovedad> solicitudesNovedadEmpleado = new List<SolicitudNovedad>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_SOL_NOV"},
                new SqlParameter { ParameterName = "@Identificacion", Value = cedulaEmpleado},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_GESTION_HUMANA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            solicitudesNovedadEmpleado = Functions.ConvertToList<SolicitudNovedad>(query);

            return solicitudesNovedadEmpleado;
        }

        public async Task<IEnumerable<ProNeTipoNovedadesEmp>> GetTipoNovedades(string search, string keyConnection)
        {
            List<ProNeTipoNovedadesEmp> proTipoNovedades = new List<ProNeTipoNovedadesEmp>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GETTIPONOV"},
                new SqlParameter { ParameterName = "@Search", Value = search},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_GESTION_HUMANA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proTipoNovedades = Functions.ConvertToList<ProNeTipoNovedadesEmp>(query);

            return proTipoNovedades;
        }

        public async Task<SolicitudNovedad> SaveApproveReject(string solicitud, string valor, string razones, bool remunerado, string keyConnection)
        {
            SolicitudNovedad solicitudNovedad = new SolicitudNovedad();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "APP_REJ_SOL"},
                new SqlParameter { ParameterName = "@IdSolicitudNovedad", Value = solicitud},
                new SqlParameter { ParameterName = "@Valor", Value = valor},
                new SqlParameter { ParameterName = "@Razones", Value = razones},
                new SqlParameter { ParameterName = "@Remunerado", Value = remunerado},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_GESTION_HUMANA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            solicitudNovedad = Functions.ConvertToEntity<SolicitudNovedad>(query);

            return solicitudNovedad;
        }

        public async Task<SolicitudNovedad> SaveSolicitudNovedadEmpleado(NovedadEmpleadoDTO novedadEmpleado, string keyConnection)
        {
            SolicitudNovedad solicitudNovedad = new SolicitudNovedad();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "SAVE_SOL_NOV"},
                new SqlParameter { ParameterName = "@TipoNovedad", Value = novedadEmpleado.TipoNovedad},
                new SqlParameter { ParameterName = "@Identificacion", Value = novedadEmpleado.CodigoEmpleado},
                new SqlParameter { ParameterName = "@ValorAnterior", Value = novedadEmpleado.ValorAnterior},
                new SqlParameter { ParameterName = "@ValorAnteriorExt", Value = novedadEmpleado.ValorAnteriorExt},
                new SqlParameter { ParameterName = "@ValorNuevo", Value = novedadEmpleado.ValorNuevo},
                new SqlParameter { ParameterName = "@ValorNuevoExt", Value = novedadEmpleado.ValorNuevoExt},
                new SqlParameter { ParameterName = "@Descripcion", Value = novedadEmpleado.Descripcion},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_GESTION_HUMANA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            solicitudNovedad = Functions.ConvertToEntity<SolicitudNovedad>(query);

            return solicitudNovedad;
        }

        public async Task<SolicitudNovedad> GetSolicitudNovedadEmpleado(string idNovedad, string keyConnection)
        {
            SolicitudNovedad solicitudNovedad = new SolicitudNovedad();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_SOL_NOVS"},
                new SqlParameter { ParameterName = "@IdSolicitudNovedad", Value = idNovedad},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_GESTION_HUMANA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            solicitudNovedad = Functions.ConvertToEntity<SolicitudNovedad>(query);

            return solicitudNovedad;
        }

        public async Task<SolicitudNovedad> SaveSolicitudPermisoEmpleado(PermisoEmpleadoDTO permisoEmpleado, string keyConnection)
        {
            SolicitudNovedad solicitudPermiso = new SolicitudNovedad();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "SAVE_SOL_PER"},
                new SqlParameter { ParameterName = "@TipoNovedad", Value = permisoEmpleado.TipoPermiso},
                new SqlParameter { ParameterName = "@Identificacion", Value = permisoEmpleado.IdentificacionEmpleado},
                new SqlParameter { ParameterName = "@CodigoEmpleado", Value = permisoEmpleado.CodigoEmpleado},
                new SqlParameter { ParameterName = "@FechaInicialP", Value = permisoEmpleado.FechaInicial.Replace("-", "")},
                new SqlParameter { ParameterName = "@FechaFinalP", Value = permisoEmpleado.FechaFinal.Replace("-", "")},
                new SqlParameter { ParameterName = "@HoraInicialP", Value = permisoEmpleado.HoraInicial},
                new SqlParameter { ParameterName = "@HoraFinalP", Value = permisoEmpleado.HoraFinal},
                new SqlParameter { ParameterName = "@ReingresaP", Value = permisoEmpleado.Reingresa},
                new SqlParameter { ParameterName = "@Descripcion", Value = permisoEmpleado.Observaciones},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_GESTION_HUMANA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            solicitudPermiso = Functions.ConvertToEntity<SolicitudNovedad>(query);

            return solicitudPermiso;
        }

        public async Task<PermisoEmpleado> GetSolicitudPermiso(string idNovedad, string keyConnection)
        {
            PermisoEmpleado permisoEmpleado = new PermisoEmpleado();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_SOL_PER"},
                new SqlParameter { ParameterName = "@IdSolicitudNovedad", Value = idNovedad},            
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_GESTION_HUMANA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            permisoEmpleado = Functions.ConvertToEntity<PermisoEmpleado>(query);

            return permisoEmpleado;
        }

        public async Task<Answer> ValidEmpleado(string Cedula, DateTime FechaDeNacimiento, string TipoValidacion, string Validacion, string keyConnection)
        {
            Answer respuesta = new Answer();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "VAL_EMP"},
                new SqlParameter { ParameterName = "@Identificacion", Value = Cedula},
                new SqlParameter { ParameterName = "@TipoValidacion", Value = TipoValidacion},
                new SqlParameter { ParameterName = "@Validacion", Value = Validacion},
                new SqlParameter { ParameterName = "@FechaNacimiento", Value = FechaDeNacimiento},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_GESTION_HUMANA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            respuesta = Functions.ConvertToEntity<Answer>(query);

            return respuesta;
        }

        public async Task<JefeRRHH> GetJefeRRHH(string keyConnection)
        {
            JefeRRHH jefe = new JefeRRHH();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_JEFE_RRHH"},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_GESTION_HUMANA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            jefe = Functions.ConvertToEntity<JefeRRHH>(query);

            return jefe;
        }

        public async Task<VacacionesDatoEmpleado> GetDatosVacacionesEmpleado(string cedulaEmpleado, string keyConnection)
        {
            VacacionesDatoEmpleado vacaciones = new VacacionesDatoEmpleado();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_DATA_VAC"},
                new SqlParameter { ParameterName = "@Identificacion", Value = cedulaEmpleado},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_GESTION_HUMANA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            vacaciones = Functions.ConvertToEntity<VacacionesDatoEmpleado>(query);

            return vacaciones;
        }

        public async Task<IEnumerable<Holidays>> GetDiasFeriados(string keyConnection)
        {
            List<Holidays> feriados = new List<Holidays>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_FERIADOS"},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_GESTION_HUMANA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            feriados = Functions.ConvertToList<Holidays>(query);

            return feriados;
        }

        public async Task<DiasDisfrutados> GetDiasDisfrutados(string fechaInicial, string tipoNomina, int dias,string keyConnection)
        {
            DiasDisfrutados diasDisfrutados = new DiasDisfrutados();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_DIAS_DISF"},
                new SqlParameter { ParameterName = "@FechaInicialVacaciones", Value = fechaInicial.Replace("-", "")},
                new SqlParameter { ParameterName = "@TipoNomina", Value = tipoNomina},
                new SqlParameter { ParameterName = "@Dias", Value = dias},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_GESTION_HUMANA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            diasDisfrutados = Functions.ConvertToEntity<DiasDisfrutados>(query);

            return diasDisfrutados;
        }

        public async Task<SolicitudNovedad> SaveSolicitudVacacionesEmpleado(VacacionesEmpleadoDTO vacacionesEmpleado, string keyConnection)
        {
            SolicitudNovedad solicitudPermiso = new SolicitudNovedad();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "SAVE_SOL_VAC"},
                new SqlParameter { ParameterName = "@TipoNovedad", Value = "AUSV"},
                new SqlParameter { ParameterName = "@Identificacion", Value = vacacionesEmpleado.IdentificacionEmpleado},
                new SqlParameter { ParameterName = "@CodigoEmpleado", Value = vacacionesEmpleado.CodigoEmpleado},
                new SqlParameter { ParameterName = "@FechaPeriodoInicial", Value = vacacionesEmpleado.FechaPeriodoInicial.Replace("-", "")},
                new SqlParameter { ParameterName = "@FechaPeriodoFinal", Value = vacacionesEmpleado.FechaPeriodoFinal.Replace("-", "")},
                new SqlParameter { ParameterName = "@FechaInicialVacaciones", Value = vacacionesEmpleado.FechaInicialVacaciones.Replace("-", "")},
                new SqlParameter { ParameterName = "@FechaReintegro", Value = vacacionesEmpleado.FechaReintegro},
                new SqlParameter { ParameterName = "@DiasHabiles", Value = vacacionesEmpleado.DiasHabiles},
                new SqlParameter { ParameterName = "@DiasCompensados", Value = vacacionesEmpleado.DiasCompensados},
                new SqlParameter { ParameterName = "@DiasDisfrute", Value = vacacionesEmpleado.DiasDisfrute},
                new SqlParameter { ParameterName = "@DiasTotal", Value = vacacionesEmpleado.DiasTotal},
                new SqlParameter { ParameterName = "@DiasPagar", Value = vacacionesEmpleado.DiasPagar},
                new SqlParameter { ParameterName = "@Descripcion", Value = vacacionesEmpleado.Observaciones},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_GESTION_HUMANA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            solicitudPermiso = Functions.ConvertToEntity<SolicitudNovedad>(query);

            return solicitudPermiso;
        }

        public async Task<SolicitudNovedad> SaveSolicitudAusentismoEmpleado(AusentismoEmpleadoDTO ausentismoEmpleado, string keyConnection)
        {
            SolicitudNovedad solicitudAusentismo = new SolicitudNovedad();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "SAVE_AUSENTISMO"},
                new SqlParameter { ParameterName = "@CodigoEmpleado", Value = ausentismoEmpleado.CodigoEmpleado},
                new SqlParameter { ParameterName = "@FechaInicioA", Value = ausentismoEmpleado.FechaInicioAusentismo.ToString("yyyyMMdd")},
                new SqlParameter { ParameterName = "@FechaFinA", Value = ausentismoEmpleado.FechaFinAusentismo.ToString("yyyyMMdd")},
                new SqlParameter { ParameterName = "@DetalleA", Value = ausentismoEmpleado.DetalleAusentismo},
                new SqlParameter { ParameterName = "@CodAusenA", Value = ausentismoEmpleado.CodigoAusentismo},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_GESTION_HUMANA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            solicitudAusentismo = Functions.ConvertToEntity<SolicitudNovedad>(query);

            return solicitudAusentismo;
        }
        public async Task<List<AusentismoShowDTO>> GetAusentismos(string keyConnection)
        {
            List<AusentismoShowDTO> ausentismos = new List<AusentismoShowDTO>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_AUSENTISMOS"},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_GESTION_HUMANA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            ausentismos = Functions.ConvertToList<AusentismoShowDTO>(query);

            return ausentismos;
        }
        public async Task<List<TipoAusentismoDTO>> GetAllTiposAusentismo(string KeyConnection)
        {
            List<TipoAusentismoDTO> tiposAusentismo = new List<TipoAusentismoDTO>();

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Operacion", "Get_TipoAus")
            };

            var connection = new SqlConnection(configuration.GetConnectionString(KeyConnection));

            var query = await ExecuteQueryDataTable("ObtenerDatos", null, CommandType.StoredProcedure, parameters.ToArray(), connection);

            foreach (DataRow row in query.Rows)
            {
                TipoAusentismoDTO tipoAusentismo = new TipoAusentismoDTO();

                if (!row.IsNull("CodigoAusentismo"))
                {
                    tipoAusentismo.CodigoAusentismo = row["CodigoAusentismo"].ToString();
                }

                if (!row.IsNull("NombreAusentismo"))
                {
                    tipoAusentismo.NombreAusentismo = row["NombreAusentismo"].ToString();
                }

                if (!row.IsNull("TipoAusentismo"))
                {
                    tipoAusentismo.TipoAusentismo = Convert.ToInt32(row["TipoAusentismo"]);
                }

                tiposAusentismo.Add(tipoAusentismo);
            }

            return tiposAusentismo;
        }

    }
}