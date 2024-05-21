using System;
using System.Collections.Generic;

namespace GeneralLedger.SelfServiceCore.Data.Models
{
    public class PedidoCabeceraE
    {
        public DateTime Fecha { get; set; }
        public DateTime FechaRequerida { get; set; }
        public string CodigoCliente { get; set; }
        public string Sucursal { get; set; }
        public string Solicitante { get; set; }
        public string CodigoRuta { get; set; }
        private List<PedidoDetalleE> detalle = new List<PedidoDetalleE>();
    }
}