using GeneralLedger.SelfServiceCore.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class PQRSFShowDTO
    {
        #region DatosneMatrizPQR

        public int Id { get; set; }
        public string NitEmpresa { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fecha { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaCierre { get; set; }

        public string Asunto { get; set; }
        public string DescripcionSituacion { get; set; }
        public string CliCod { get; set; }
        public string Tipo { get; set; }
        public int Contacto { get; set; }
        public string Estado { get; set; }

        #endregion DatosneMatrizPQR

        #region Datos neSituacionesNoConformes

        public string TipoSituacion { get; set; }
        public string IdSituacion { get; set; }

        #endregion Datos neSituacionesNoConformes

        #region Datos Clientes

        public string NombreCliente { get; set; }

        #endregion Datos Clientes

        #region DatosCliOtrosContactos

        public string NombreContacto { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }

        #endregion DatosCliOtrosContactos

        #region Archivo

        public List<Archivo> ListArchivos { get; set; }

        #endregion Archivo

        #region Notas

        public List<NotaPQRSFListDTO> ListNotas { get; set; }

        #endregion Notas

        #region EmpleadoEncargado

        public int pqrResponsable { get; set; }

        #endregion EmpleadoEncargado

        #region Proceso

        public int CodigoProceso { get; set; }

        #endregion Proceso
    }
}