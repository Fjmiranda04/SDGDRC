using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers
{
    public interface IProEmpleadoRepository: IRepository<Empleado>
    {
        Task<Empleado> GetEmpleadoByCodigo(string CodigoEmpleado,string KeyConnection);
        Task<Empleado> GetEmpleadoByNit(string NitEmpleado, string KeyConnection);
        Task<List<EmpleadoShowDTO>> GetAllEmpleados(string KeyConnection);
    }
}
