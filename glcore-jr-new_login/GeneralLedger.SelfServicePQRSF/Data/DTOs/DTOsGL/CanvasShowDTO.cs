using System;

namespace GeneralLedger.SelfServiceCore.Data.DTOs.DTOsGL
{
    public class CanvasShowDTO
    {
        public string NroOrden { get; set; }
        public DateTime OrdenLastUpdate { get; set; }
        public string OrdenCliente { get; set; }
        public int OrdenDias { get; set; }
        public string Cotizacion { get; set; }
        public DateTime CotizacionLastUpdate { get; set; }
        public string CotizacionCliente { get; set; }
        public int CotizacionDias { get; set; }
        public string Pedido { get; set; }
        public DateTime PedidoLastUpdate { get; set; }
        public string PedidoCliente { get; set; }
        public int PedidoDias { get; set; }
    }
}