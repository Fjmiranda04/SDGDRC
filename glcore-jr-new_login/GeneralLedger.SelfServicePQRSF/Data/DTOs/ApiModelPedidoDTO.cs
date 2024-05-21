using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class ApiModelPedidoDTO
    {
        [Required(ErrorMessage = "El código de pedido es requerido")]
        [JsonPropertyName("codigoPedido")]
        public string CodigoPedido { get; set; }

        [Required(ErrorMessage = "El nit del cliente es requerido")]
        [JsonPropertyName("nitCliente")]
        public string NitCliente { get; set; }

        [Required(ErrorMessage = "El fecha del pedido es requerida (dd/MM/yyyy)")]
        [JsonPropertyName("fechaPedido")]
        [RegularExpression(@"^\d{2}/\d{2}/\d{4}$", ErrorMessage = "El formato de la fecha debe ser dd/MM/yyyy")]
        public string FechaPedido { get; set; }

        [JsonPropertyName("observacionPedido")]
        public string ObservacionPedido { get; set; }

        [Required(ErrorMessage = "Los ítems del pedido son requerido, al menos un ítem")]
        [JsonPropertyName("detallePedido")]
        public List<ApiModelDetallePedidoDTO> DetallePedido { get; set; }
    }
}
