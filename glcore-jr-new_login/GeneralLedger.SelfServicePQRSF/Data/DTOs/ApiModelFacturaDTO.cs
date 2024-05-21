using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class ApiModelFacturaDTO
    {
        [Required(ErrorMessage = "El número de pedido es requerido")]
        [JsonPropertyName("numeroPedido")]
        public string NumeroPedido { get; set; }

        [Required(ErrorMessage = "El número de remisión es requerido")]
        [JsonPropertyName("numeroRemision")]
        public string NumeroRemision { get; set; }

        [Required(ErrorMessage = "La fecha de factura es requerida")]
        [JsonPropertyName("fechaFactura")]
        public DateTime FechaFactura { get; set; }

        [Required(ErrorMessage = "El número de factura es requerido")]
        [JsonPropertyName("numeroFactura")]
        public string NumeroFactura { get; set; }
    }
}
