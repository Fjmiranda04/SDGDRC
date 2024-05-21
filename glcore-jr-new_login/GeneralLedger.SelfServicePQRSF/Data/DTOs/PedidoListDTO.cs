using System;
using System.Collections.Generic;

namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class PedidoListDTO
    {
        public string NumeroPedido { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public DateTime FechaRequerido { get; set; }
        public Decimal Total { get; set; }
        public Decimal SubTotal { get; set; }
        public Decimal ValorIva { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Calificacion { get; set; }

        public List<DetallePedidoDTO> Detalles { get; set; }

      /*  public string CodigoArticulo { get; set; }
        public string Detalle { get; set; }

        public decimal Cantidad { get; set;}

        public Decimal ValorUnitario { get; set; }
        public Decimal ValorSubtotal { get; set; }
        public Decimal Iva { get; set; }*/
    }
}