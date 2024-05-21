using System;

namespace GeneralLedger.SelfServiceCore.Data.Models
{
    public class Proponente
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string NitEmpresa { get; set; }
        public string TipoDoc { get; set; }
        public string NitProveedor { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Telefono { get; set; }
        public string Fax { get; set; }
        public string RepLegal { get; set; }
        public string CedRepLegal { get; set; }
        public string ContactoRepLegal { get; set; }
        public string CargoLegal { get; set; }
        public bool IsRUP { get; set; }
        public string NumeroRUT { get; set; }
        public DateTime FechaVencimientoRUT { get; set; }
        public DateTime FechaInscripcionRUT { get; set; }
        public bool IsCertificadoEstablecimientoComercio { get; set; }
        public string NumeroMatriculaMercantil { get; set; }
        public int TipoBienServicio { get; set; }
        public int TipoActividadComercial { get; set; }
        public int IdEmpresa { get; set; }
    }
}