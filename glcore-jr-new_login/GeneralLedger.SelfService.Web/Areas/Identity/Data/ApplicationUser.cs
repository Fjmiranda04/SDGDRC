using Microsoft.AspNetCore.Identity;

namespace GeneralLedger.SelfService.Web.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string NroId { get; set; }
        public string Nombre { get; set; }
        public string PriNombre { get; set; }
        public string SegNombre { get; set; }
        public string PriApellido { get; set; }
        public string SegApellido { get; set; }
        public int IdEmpresa { get; set; }
        public string NitEmpresa { get; set; }
        public string UsuarioGL { get; set; }
        public string CodigoUsuarioGL { get; set; }
        public string CodigoEmpleado { get; set; }
        public string CodigoTercero { get; set; }
        public string TipoUsuario { get; set; }
        public string Celular { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Dependencia { get; set; }
        public string EmailUser { get; set; }
        public bool EsCliente { get; set; }
        public string KeyConnection { get; set; }
    }
}