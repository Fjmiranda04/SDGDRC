using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using System.Collections.Generic;

namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class PedidoCreateDTO
    {
        public string Consecutivo { get; set; } = "";
        public string Fecha { get; set; }
        public string FechaRequerido { get; set; }
        public string NombreCliente { get; set; } = "";
        public string NitCliente { get; set; } = "";
        public string CodigoCliente { get; set; } = "";
        public string CodigoSolicitante { get; set; } = "";
        public string CodigoEscala { get; set; } = "";
        public string CodigoVendedor { get; set; } = "";
        public string TipoCliente { get; set; } = "";
        public string Telefono { get; set; } = "";
        public string Direccion { get; set; } = "";
        public string CodigoPostal { get; set; } = "";
        public string CodigoCiudad { get; set; } = "";
        public string CodigoPais { get; set; } = "";
        public string CodigoSucursal { get; set; } = "";
        public string Detalle { get; set; } = "";
        public string SubTotal { get; set; } = "0";
        public string ValorIva { get; set; } = "0";
        public string Total { get; set; } = "0";
        public int IvaIncluido { get; set; }

        public List<DetallePedido> detalles { get; set; }
        public List<SucursalShowDTO> Sucursales { get; set; }
        public List<CliOtrosContactos> Solicitantes { get; set; }
    }
}