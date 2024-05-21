using System;

namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class SolicitudClienteCreateDTO
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string TipDoc { get; set; }
        public string NroIde { get; set; }
        public string NombreCompleto { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string NitEmpresa { get; set; }
        public string Estado { get; set; }
        public string delmrk { get; set; }
    }
}