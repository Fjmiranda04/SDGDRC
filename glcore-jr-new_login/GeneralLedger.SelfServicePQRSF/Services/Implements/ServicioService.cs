using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class ServicioService : GenericService<Servicio>, IServicioService
    {
        private readonly IServicioRepository servicioRepository;

        public ServicioService(IServicioRepository servicioRepository) : base(servicioRepository)
        {
            this.servicioRepository = servicioRepository;
        }

        public async Task<IEnumerable<ServicioShowDTO>> GetServicios()
        {
            return await servicioRepository.GetServicios();
        }
    }
}