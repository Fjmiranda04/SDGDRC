using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class PQRSFReportDTO
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
        public string Estado { get; set; }
        public string Etiquetas { get; set; }
        public string Proceso { get; set; }
        public string Prioridad { get; set; }

        #endregion Datos neMAtrizPQR

        #region AgenteResponsable

        public string AgenteResposable { get; set; }

        #endregion AgenteResponsable

        #region SituacionNoConformes

        public string TipoSituacion { get; set; }

        #endregion SituacionNoConformes

        #region DatosCliente

        public string NroIdeCli { get; set; }
        public string NombreCliente { get; set; }
        public string EmailCliente { get; set; }

        #endregion DatosCliente

        #region ContactosCliente

        public string NombreContacto { get; set; }
        public string CelularContacto { get; set; }
        public string TelefonoContacto { get; set; }
        public string EmailContacto { get; set; }

        #endregion ContactosCliente

        #region Tratamiento

        public List<TratamientoPQRSFListDTO> ListTratamientos { get; set; }

        #endregion Tratamiento

        #region Seguimiento

        public List<SeguimientoPQRSFListDTO> ListSeguimientos { get; set; }

        #endregion Seguimiento

        #region RespuestasCierre

        public List<RespuestaListDTO> ListRespuestasCierre { get; set; }

        #endregion RespuestasCierre
    }
}