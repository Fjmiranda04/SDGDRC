using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using GeneralLedger.SelfServiceCore.Data.Repositories.RepositoriesGL;
using GeneralLedger.SelfServiceCore.Services.Implements;

namespace GeneralLedger.SelfServiceCore.Services.ServicesGL.Implements
{
    public class AccPedidoService : GenericService<AccPedido>, IAccPedidoService
    {
        private readonly IAccPedidoRepository accPedidoRepository;

        public AccPedidoService(IAccPedidoRepository accPedidoRepository) : base(accPedidoRepository)
        {
            this.accPedidoRepository = accPedidoRepository;
        }
    }
}