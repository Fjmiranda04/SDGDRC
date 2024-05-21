using System;

namespace GeneralLedger.SelfServiceCore.Data.Models
{
    public class PQRSF
    {
        public int Id { get; set; }
        public string NitEmpresa { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaCierre { get; set; }
        public DateTime FechaCierreReal { get; set; }
        public string Tipo { get; set; }
        public string Asunto { get; set; }
        public string Descripcion { get; set; }
        public string Etiquetas { get; set; }
        public int IdEstado { get; set; }
        public int IdPrioridad { get; set; }
        public int IdSituacion { get; set; }
        public string IdProceso { get; set; }
        public int IdContacto { get; set; }
        public string NroIdeCli { get; set; }
        public string NroIdResponsable { get; set; }
        public string NroIdPerfilo { get; set; }
        public string NroIdCerro { get; set; }
        public bool Perfilacion { get; set; }
    }
}