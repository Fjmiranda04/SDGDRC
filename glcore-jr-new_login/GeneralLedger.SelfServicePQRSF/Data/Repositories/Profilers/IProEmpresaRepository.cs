using GeneralLedger.SelfServiceCore.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers
{
    public interface IProEmpresaRepository : IRepository<Empresa>
    {
        Task<IEnumerable<Empresa>> GetEmpresas(string KeyConnection);

        Task<Empresa> GetEmpresa(string Nit, string KeyConnection);
        Task<EmpresaGL> GetEmpresaGL(string KeyConnection);

        Task<Empresa> GetDataEmpresa(string salt, string KeyConnection);

        Task<UsuarioEmpresa> GetUsuarioEmpresa(string Email, string KeyConnection);

        Task RemoveUsuarioEmpresa(int IdUsuarioEmpresa, string KeyConnection);

        Task<UsuarioEmpresa> SaveUsuarioEmpresa(UsuarioEmpresa usuarioEmpresa, string KeyConnection);

        Task<Empresa> SaveEmpresa(Empresa empresa, string KeyConnection);
    }
}