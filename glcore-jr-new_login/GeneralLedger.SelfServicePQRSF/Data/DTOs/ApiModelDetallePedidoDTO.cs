using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class ApiModelDetallePedidoDTO
    {
        [Required(ErrorMessage = "El código del ítem es requerido")]
        [JsonPropertyName("codigoArticulo")]
        public string CodigoArticulo { get; set; }

        [JsonPropertyName("referenciaArticulo")]
        public string ReferenciaArticulo { get; set; }

        [Required(ErrorMessage = "La cantidad del ítem es requerida")]
        [Range(1,int.MaxValue,ErrorMessage = "La cantidad mínima del ítem debe ser 1")]
        [JsonPropertyName("cantidadArticulo")]
        public string CantidadArticulo { get; set; }

        [Required]
        [JsonPropertyName("costoUnitarioArticulo")]
        public string CostoUnitarioArticulo { get; set; }

        [Required(ErrorMessage = "El valor unitario del ítem es requerido")]
        [Range(0.1, int.MaxValue, ErrorMessage = "El valor unitario no puede ser 0")]
        [JsonPropertyName("valorUnitarioArticulo")]
        public decimal ValorUnitarioArticulo { get; set; }

        [Required(ErrorMessage = "La tarifa de iva del ítem es requerida")]
        [Range(0, int.MaxValue, ErrorMessage = "El valor unitario no puede ser negativo")]
        [JsonPropertyName("porcentajeIva")]
        public decimal PorcentajeIva { get; set; }


        [JsonPropertyName("medidaArticulo")]
        public string MedidaArticulo { get; set; }

        [JsonPropertyName("tipoArticulo")]
        [Required(ErrorMessage = "El Tipo de ítem es requerido")]
        public string TipoArticulo { get; set; }
    }
}
