using GeneralLedger.SelfServiceCore.Data.Models;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers
{
    public interface IProSolicitudUsuarioRepository : IRepository<SolicitudCliente>
    {
        Task<SolicitudCliente> SaveSolicitudCliente(SolicitudCliente solicitudCliente, string Key);
    }
}