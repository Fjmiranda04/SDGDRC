using GeneralLedger.SelfServiceCore.Data.DTOs.DTOsGL;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using GeneralLedger.SelfServiceCore.Data.Repositories.RepositoriesGL;
using GeneralLedger.SelfServiceCore.Services.Implements;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.ServicesGL.Implements
{
    public class OrdenService : GenericService<Orden>, IOrdenService
    {
        private readonly IOrdenRepository ordenRepository;

        public OrdenService(IOrdenRepository ordenRepository) : base(ordenRepository)
        {
            this.ordenRepository = ordenRepository;
        }

        public async Task<IEnumerable<CanvasShowDTO>> GetCanvas(string usuario, string subcentro)
        {
            return await ordenRepository.GetCanvas(usuario, subcentro);
        }

        public async Task<IEnumerable<CanvasShowDTO>> GetCanvas(string SubCentro)
        {
            return await ordenRepository.GetCanvas(SubCentro);
        }

        public async Task<IEnumerable<CanvasShowDTO>> GetOTFacturar()
        {
            return await ordenRepository.GetOTFacturar();
        }
    }
}