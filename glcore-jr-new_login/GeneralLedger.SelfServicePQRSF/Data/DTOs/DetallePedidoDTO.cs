using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class DetallePedidoDTO
    {
        public string CodigoArticulo { get; set; }
        public string Detalle { get; set; }
        public decimal Cantidad { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Iva { get; set; }
        public decimal ValorSubtotal { get; set; }
        public Decimal Total { get; set; }
    }
}
