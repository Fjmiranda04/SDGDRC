using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services
{
    public interface IEmpleadoService : IGenericService<Empleado>
    {
        Task<EmpleadoShowDTO> GetEmpleadoByNroId(string nroId);
    }
}