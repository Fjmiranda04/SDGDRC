using GeneralLedger.SelfServiceCore.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class PQRSFProfilerDTO
    {
        #region Datos neMAtrizPQR

        public int Id { get; set; }
        public string NitEmpresa { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fecha { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaCierre { get; set; }

        public DateTime FechaCierreReal { get; set; }
        public string Tipo { get; set; }
        public string Asunto { get; set; }
        public string Descripcion { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public int IdPrioridad { get; set; }
        public string Etiquetas { get; set; }
        public int IdSituacion { get; set; }
        public string NroIdeCli { get; set; }
        public string NroIdResponsable { get; set; }
        public string NroIdPerfilo { get; set; }
        public string IdProceso { get; set; }
        public int IdContacto { get; set; }
        public bool Perfilacion { get; set; }

        #endregion Datos neMAtrizPQR

        #region SituacionNoConformes

        public string TipoSituacion { get; set; }

        #endregion SituacionNoConformes

        #region DatosCliente

        public string NombreCliente { get; set; }
        public string EmailCliente { get; set; }

        #endregion DatosCliente

        #region DatosCliOtrosContactos

        public string NombreContacto { get; set; }
        public string Celular { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        #endregion DatosCliOtrosContactos

        #region Archivos

        private List<Archivo> ListArchivos { get; set; }

        #endregion Archivos
    }
}