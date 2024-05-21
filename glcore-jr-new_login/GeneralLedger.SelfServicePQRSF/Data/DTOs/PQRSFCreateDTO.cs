using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class PQRSFCreateDTO
    {
        public int Id { get; set; }

        [Required]
        public string NitEmpresa { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        public string Tipo { get; set; }

        [Required]
        public string IdSituacion { get; set; }

        [Required]
        public string NroIdeCli { get; set; }

        public string NombreCliente { get; set; }

        [Required]
        public int IdContacto { get; set; }

        [Required]
        public string Asunto { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public List<ContactoCliente> ContactoClientes { get; set; }

        public List<Situacion> Situaciones { get; set; }

        public List<IFormFile> Archivos { get; set; }
    }
}