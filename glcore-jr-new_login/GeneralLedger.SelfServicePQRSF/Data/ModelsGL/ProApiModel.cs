using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.ModelsGL
{
    public class ProApiModel
    {
    }

    public class ProApiModelPedido
    {
        public string NumeroPedido { get; set; }
        public string CodigoPedido { get; set; }
        public string NitCliente { get; set; }
        public DateTime FechaPedido { get; set; }
        public decimal SubtotalPedido { get; set; }
        public decimal IvaPedido { get; set; }
        public decimal TotalPedido { get; set; }
    }

    public class ProApiModelTrackPedido
    {
        public string CodigoPedido { get; set; }
        public string NumeroPedido { get; set; }
        public string NitCliente { get; set; }
        public List<ProApiModelDetalleRemision> Remisiones{get;set;}

    }

    public class ProApiModelRemision
    {
        public DateTime FechaRemision { get; set; }
        public string NumeroRemision { get; set; }
        public List<ProApiModelDetalleRemision> DetalleRemision = new List<ProApiModelDetalleRemision>();
    }

    public class ProApiModelDetalleRemision
    {
        public DateTime FechaRemision { get; set; }
        public string NumeroRemision { get; set; }
        public string CodigoArticulo { get; set; }
        public decimal CantidadArticulo { get; set; }
        public string MedidaArticulo { get; set; }
    }

    public class ProApiModelTrackRemision
    {

    }

    public class ProApiModelFactura
    {
        public string NumeroPedido { get; set; }
        public string NumeroRemision { get; set; }
        public DateTime FechaFactura { get; set; }
        public string NumeroFactura { get; set; }
    }

    public class ProApiModelCliente
    {
        public string NombreCliente { get; set; }
        public string NitCliente { get; set; }
        public string NombreContacto { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string CategoriaPrecio { get; set; }
    }

    public class ProApiModelTrackingList
    {
        public DateTime FechaRemision { get; set; }
        public string NitCliente { get; set; }
        public string NumeroPedido { get; set; }
        public string NumeroRemision { get; set; }
        public string CodigoArticulo { get; set; }
        public decimal CantidadArticulo { get; set; }
        public string MedidaArticulo { get; set; }
    }

    public class ProApiModelArticulo
    {
        public string CodigoArticulo { get; set; }
        public string NombreArticulo { get; set; }
        public string Tipo { get; set; }
    }

}
