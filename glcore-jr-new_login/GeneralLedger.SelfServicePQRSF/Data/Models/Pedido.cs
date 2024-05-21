using System;
using System.Collections.Generic;

namespace GeneralLedger.SelfServiceCore.Data.Models
{
    public class Pedido
    {
        public string Consecutivo { get; set; }
        public string TipoCliente { get; set; }
        public string codCliente { get; set; }
        public int idSucursal { get; set; }
        public string direccion { get; set; }
        public DateTime fecha { get; set; }
        public string codDependencia { get; set; }
        public string codVendedor { get; set; }
        public string codEscala { get; set; }
        public decimal subtotal { get; set; }
        public string subtotalString { get; set; }
        public int descuento { get; set; }
        public int flete { get; set; }
        public decimal impuesto { get; set; }
        public string impuestoString { get; set; }
        public decimal total { get; set; }
        public string totalString { get; set; }
        public string usuario { get; set; }
        public int redondeo { get; set; }
        public string detalle { get; set; }
        public string cadena { get; set; }
        public string formapago { get; set; }
        public int ivaFlete { get; set; }
        public int ivaincluido { get; set; }
        public int ivaPorcFlete { get; set; }
        public DateTime fechaReq { get; set; }
        public string solicitante { get; set; }
        public string NroCotizacion { get; set; }

        public IEnumerable<DetallePedido> detalles { get; set; }
    }
}