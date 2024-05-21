using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.Repositories;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class EmpleadoService : GenericService<Empleado>, IEmpleadoService
    {
        private readonly IEmpleadoRepository empleadoRepository;

        public EmpleadoService(IEmpleadoRepository empleadoRepository) : base(empleadoRepository)
        {
            this.empleadoRepository = empleadoRepository;
        }

        public async Task<EmpleadoShowDTO> GetEmpleadoByNroId(string nroId)
        {
            return await empleadoRepository.GetEmpleadoByNroId(nroId);
        }
    }
}