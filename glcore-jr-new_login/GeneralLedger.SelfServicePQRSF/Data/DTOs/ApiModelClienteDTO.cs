using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class ApiModelClienteDTO
    {
        [Required(ErrorMessage = "El Nombre del Cliente es requerido")]
        [JsonPropertyName("nombreCliente")]
        public string NombreCliente { get; set; }

        [Required(ErrorMessage = "El Nit del Cliente es requerido")]
        [JsonPropertyName("nitCliente")]
        public string NitCliente { get; set; }

        [Required(ErrorMessage = "El Nombre de Contacto es requerido")]
        [JsonPropertyName("nombreContacto")]
        public string NombreContacto { get; set; }

        [Required(ErrorMessage = "El Telefono es requerido")]
        [JsonPropertyName("telefono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El Correo es requerido")]
        [JsonPropertyName("correo")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "La Dirección es requerida")]
        [JsonPropertyName("direccion")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "La Categoria de Precio es requerida")]
        [JsonPropertyName("categoriaPrecio")]
        public string CategoriaPrecio { get; set; }
    }
}
