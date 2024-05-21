using GeneralLedger.SelfServiceCore.Data.DTOs.DTOsGL;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using GeneralLedger.SelfServiceCore.Data.Repositories.RepositoriesGL;
using GeneralLedger.SelfServiceCore.Services.Implements;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.ServicesGL.Implements
{
    public class ViewSubCentroCostoService : GenericService<ViewSubCentroCosto>, IViewSubCentroCostoService
    {
        private readonly IViewSubCentroCostoRepository viewSubCentroCostoRepository;

        public ViewSubCentroCostoService(IViewSubCentroCostoRepository viewSubCentroCostoRepository) : base(viewSubCentroCostoRepository)
        {
            this.viewSubCentroCostoRepository = viewSubCentroCostoRepository;
        }

        public Task<IEnumerable<ViewSubCentroCostoShowDTO>> GetSubCentrosCostos()
        {
            return viewSubCentroCostoRepository.GetSubCentrosCostos();
        }
    }
}