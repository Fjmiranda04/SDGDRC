using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using GeneralLedger.SelfServiceCore.Data.Repositories;
using GeneralLedger.SelfServiceCore.Data.Repositories.Implements;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class PedidoService : GenericService<AccPedido>, IPedidoService
    {
        private readonly IPedidoRepository pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository) : base(pedidoRepository)
        {
            this.pedidoRepository = pedidoRepository;
        }

        public async Task<Consecutivo> GetConsecutivo()
        {
            return await pedidoRepository.GetConsecutivo();
        }

        public async Task<PedidoCreateDTO> PreparePedidoToCreate(string NroId)
        {
            return await pedidoRepository.PreparePedidoToCreate(NroId);
        }

        public async Task<PedidoCreateDTO> SavePedido(PedidoCreateDTO pedido)
        {
            return await pedidoRepository.SavePedido(pedido);
        }

        public async Task<IEnumerable<PedidoListDTO>> GetPedidosByCliente(string NroId)
        {
            return await pedidoRepository.GetPedidosByCliente(NroId);
        }

        public async Task<IEnumerable<PedidoListDTO>> GetPedidos(string fechaI, string fechaF, string NroIdCliente)
        {
            return await pedidoRepository.GetPedidos(fechaI, fechaF, NroIdCliente);
        }

        public async Task<PedidoCreateDTO> GetNewPedido(string NroIdCliente, string keyConnection)
        {
            return await pedidoRepository.GetNewPedido(NroIdCliente, keyConnection);
        }

        public async Task<IEnumerable<ArticuloShowDTO>> GetArticulos(string codigEscala)
        {
            return await pedidoRepository.GetArticulos(codigEscala);
        }

        public async Task<IEnumerable<ServicioShowDTO>> GetServicios(string codigoEscala)
        {
            return await pedidoRepository.GetServicios(codigoEscala);
        }

        public async Task<IEnumerable<DetallePedidoDTO>> GetDetallesPedido(string numeroPedido)
        {
            return await pedidoRepository.GetDetallesPedido(numeroPedido);
        }
    }

}