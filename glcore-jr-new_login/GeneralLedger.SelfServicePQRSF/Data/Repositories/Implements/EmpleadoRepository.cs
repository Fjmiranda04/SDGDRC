using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleadoRepository
    {
        private readonly SelfServiceContext contex;
        private readonly IConfiguration configuration;

        public EmpleadoRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.contex = contex;
            this.configuration = configuration;
        }

        public async Task<EmpleadoShowDTO> GetEmpleadoByNroId(string nroId)
        {
            return await (from empleado in contex.Empleados
                          where empleado.NroId == nroId
                          select new EmpleadoShowDTO
                          {
                              Id = empleado.Id,
                              NroIdEmp = empleado.NroId,
                              NitEmpresa = empleado.NitEmpresa,
                              NombreCompleto = empleado.NombreCompleto,
                              Telefono = empleado.Telefono,
                              Email = empleado.Email,
                              Celular = empleado.Celular
                          }).FirstOrDefaultAsync();
        }
    }
}