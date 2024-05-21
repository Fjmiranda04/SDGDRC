using System;
using System.ComponentModel.DataAnnotations;

namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class PQRSFListDTO
    {
        #region DatosneMatrizPQR

        public int Id { get; set; }
        public string NitEmpresa { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fecha { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaCierre { get; set; }

        public DateTime FechaCierreReal { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public string Asunto { get; set; }
        public int IdPrioridad { get; set; }
        public string Prioridad { get; set; }
        public string IdProceso { get; set; }
        public string NroIdResponsable { get; set; }
        public string NroIdCerro { get; set; }
        public string NombreResponsable { get; set; }

        #endregion DatosneMatrizPQR

        #region Datos SituacionesNoConformes

        public int IdSituacion { get; set; }
        public string TipoSituacion { get; set; }

        #endregion Datos SituacionesNoConformes

        #region Datos Clientes

        public string NombreCliente { get; set; }
        public string Email { get; set; }

        #endregion Datos Clientes

        #region ClienteContactos

        public string NombreContacto { get; set; }

        #endregion ClienteContactos

        #region Agentes

        public string NombreAgente { get; set; }

        #endregion Agentes
    }
}