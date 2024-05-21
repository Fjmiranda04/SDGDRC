using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class ApiModelTrackPedidoDTO
    {
        [Required(ErrorMessage = "El número de pedido es requerido")]
        [JsonPropertyName("numeroPedido")]
        public string NumeroPedido { get; set; }

        [Required(ErrorMessage = "El nit del cliente es requerido")]
        [JsonPropertyName("nitCliente")]
        public string NitCliente { get; set; }

        [Required(ErrorMessage = "Los datos de remisión son requeridos")]
        [JsonPropertyName("remision")]
        public List<ApiModelRemisionDTO> Remision { get; set; }
    }

    public class ApiModelRemisionDTO
    {
        [Required(ErrorMessage = "La fecha de remisión es requerida")]
        [JsonPropertyName("fechaRemision")]
        public DateTime FechaRemision { get; set; }

        [Required(ErrorMessage = "El número de remisión es requerido")]
        [JsonPropertyName("numeroRemision")]
        public string NumeroRemision { get; set; }

        [Required(ErrorMessage = "El código de ítem es requerido")]
        [JsonPropertyName("codigoArticulo")]
        public string CodigoArticulo { get; set; }

        [Required(ErrorMessage = "La cantidad del ítem es requerida")]
        [JsonPropertyName("cantidadArticulo")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad mínima del ítem debe ser 1")]
        public decimal CantidadArticulo { get; set; }

        [Required(ErrorMessage = "La medida del ítem es requerida")]
        [JsonPropertyName("medidaArticulo")]
        public string MedidaArticulo { get; set; }
    }
}
