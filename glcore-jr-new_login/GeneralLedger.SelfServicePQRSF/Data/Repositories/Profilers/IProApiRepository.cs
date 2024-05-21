using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers
{
    public interface IProApiRepository: IRepository<ProApiModel>
    {
        Task<ProApiModelPedido> AddPedido(ApiModelPedidoDTO apiModelPedidoDTO);
        Task<IEnumerable<ProApiModelTrackPedido>> GetTrackingPedidos();
        Task<ProApiModelTrackPedido> SendTrackingPedido();
        Task<IEnumerable<ProApiModelCliente>> GetClientes();
        Task<IEnumerable<ProApiModelFactura>> GetFacturas();
        Task<IEnumerable<ProApiModelArticulo>> GetArticulos();


        Task<ProApiModelTrackPedido> AddTrackPedido(ApiModelTrackPedidoDTO apiModelTrackPedidoDTO);
        Task<ProApiModelTrackRemision> AddTrackRemision(ApiModelTrackRemisionDTO apiModelTrackRemisionDTO);
        Task<ProApiModelFactura> AddTrackRemision(ApiModelFacturaDTO apiModelFacturaDTO);
    }
}
