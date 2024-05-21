using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers
{
    public interface IProGestionHumanaRepository : IRepository<ProGestionHumana>
    {
        Task<IEnumerable<ProNeTipoNovedadesEmp>> GetTipoNovedades(string search, string keyConnection);
        Task<IEnumerable<ProEps>> GetEps(string search, string keyConnection);
        Task<IEnumerable<ProFondoPension>> GetFondosPension(string search, string keyConnection);
        Task<IEnumerable<ProFondoCensantias>> GetFondosCesantias(string search, string keyConnection);
        Task<IEnumerable<ProCajaCompensacion>> GetCajasCompensacion(string search, string keyConnection);
        Task<EmpleadoNovedad> GetInfoEmpleadoNovedad(string cedulaEmpleado, string keyConnection);
        Task<SolicitudNovedad> SaveSolicitudNovedadEmpleado(NovedadEmpleadoDTO novedadEmpleado, string keyConnection);
        Task<SolicitudNovedad> SaveSolicitudPermisoEmpleado(PermisoEmpleadoDTO permisoEmpleado, string keyConnection);
        Task<SolicitudNovedad> SaveSolicitudVacacionesEmpleado(VacacionesEmpleadoDTO vacacionesEmpleado, string keyConnection);
        Task<SolicitudNovedad> SaveSolicitudAusentismoEmpleado(AusentismoEmpleadoDTO ausentismoEmpleado, string keyConnection);
        Task<List<AusentismoShowDTO>> GetAusentismos(string keyConnection);
        Task<List<TipoAusentismoDTO>> GetAllTiposAusentismo(string KeyConnection);
        Task<SolicitudNovedad> GetSolicitudNovedadEmpleado(string idNovedad, string keyConnection);
        Task<IEnumerable<SolicitudNovedad>> GetSolicitudesNovedadByEmpleado(string cedulaEmpleado, string keyConnection);
        Task<SolicitudNovedad> SaveApproveReject(string solicitud, string valor, string razones,bool remunerado, string keyConnection);
        Task<Answer> ValidEmpleado(string Cedula, DateTime FechaDeNacimiento, string TipoValidacion, string Validacion, string keyConnection);
        Task<JefeRRHH> GetJefeRRHH(string keyConnection);
        Task<VacacionesDatoEmpleado> GetDatosVacacionesEmpleado(string cedulaEmpleado,string keyConnection);
        Task<DiasDisfrutados> GetDiasDisfrutados(string fechaInicial, string tipoNomina,int dias,string keyConnection);
        Task<IEnumerable<Holidays>> GetDiasFeriados( string keyConnection);
        Task<PermisoEmpleado> GetSolicitudPermiso(string idNovedad, string keyConnection);
    }
}