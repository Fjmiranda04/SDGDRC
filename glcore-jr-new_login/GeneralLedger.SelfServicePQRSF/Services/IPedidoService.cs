using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services
{
    public interface IPedidoService : IGenericService<AccPedido>
    {
        Task<Consecutivo> GetConsecutivo();

        Task<PedidoCreateDTO> SavePedido(PedidoCreateDTO pedido);

        Task<PedidoCreateDTO> PreparePedidoToCreate(string NroId);

        Task<PedidoCreateDTO> GetNewPedido(string NroIdCliente, string keyConnection);

        Task<IEnumerable<PedidoListDTO>> GetPedidosByCliente(string NroId);

        Task<IEnumerable<PedidoListDTO>> GetPedidos(string fechaI, string fechaF, string NroIdCliente);

        Task<IEnumerable<ArticuloShowDTO>> GetArticulos(string codigEscala);

        Task<IEnumerable<ServicioShowDTO>> GetServicios(string codigoEscala);

        Task<IEnumerable<DetallePedidoDTO>> GetDetallesPedido(string numeroPedido);
    }

}