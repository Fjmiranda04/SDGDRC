using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers
{
    public interface IProConfiguracionRespository : IRepository<ProConfiguracion>
    {
        Task<string> ChangeEmail(string Email, string CodigoAgente, string NitEmpresa, string keyConnection);

        Task<IEnumerable<ProPermisos>> GetPermisos(string search, string keyConnection);

        Task<ProPermisos> GetPermiso(int idPermiso, string keyConnection);

        Task<ProPermisos> SavePermiso(int idPermiso, string permiso, string tipo, string descripcion, string keyConnection);

        Task<IEnumerable<ProPermisosUsuarios>> GetPermisosUsuario(string idUsuario, string keyConnection);

        Task<ProPermisos> SavePermisoUsuario(string idUsuario, int idPermiso, string keyConnection);

        Task<IEnumerable<ProRolesUsuarios>> GetRolesUsuario(string idUsuario, string keyConnection);

        Task<ProRolesUsuarios> SaveRolUsuario(string idUsuario, string idRol, string keyConnection);

        Task<Configuracion> GetConfiguracion(string idConfiguracion, string keyConnection);

        Task<IEnumerable<Configuracion>> GetConfiguraciones(string keyConnection);

        Task<IEnumerable<Configuracion>> SaveConfiguraciones(List<Configuracion> configuraciones, string keyConnection);

        Task<EmailConfiguracion> GetConfiguracionEmail(string clave, string keyConnection);

        Task<IEnumerable<ModelsGL.MenuUsuario>> GetMenusByUser(string nroIde, string idRol, string keyConnection);

        Task<Archivo> SaveArchivo(Archivo archivo, string keyConnection);
    }
}