using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories
{
    public interface IPedidoRepository : IGenericRepository<AccPedido>
    {
        Task<Consecutivo> GetConsecutivo();

        Task<PedidoCreateDTO> SavePedido(PedidoCreateDTO pedido);

        Task<PedidoCreateDTO> PreparePedidoToCreate(string NroIdCliente);

        Task<PedidoCreateDTO> GetNewPedido(string nitCliente, string keyConnection);

        Task<IEnumerable<PedidoListDTO>> GetPedidosByCliente(string Clinit);

        Task<IEnumerable<PedidoListDTO>> GetPedidos(string fechaI, string fechaF, string NroIdCliente);

        Task<IEnumerable<DetallePedidoDTO>> GetDetallesPedido(string numeroPedido);

        Task<IEnumerable<ArticuloShowDTO>> GetArticulos(string codigoEscala);

        Task<IEnumerable<ServicioShowDTO>> GetServicios(string codigoEscala);
    }
}