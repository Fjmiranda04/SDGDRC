using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.ModelsGL
{
    public class UserApplicationGL
    {
        public string Id { get; set; }
        public string IdentificacionUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string CodigoUsuario { get; set; }
        public string UserSSGL { get; set; }
        public string CodigoUsuarioGL { get; set; }
        public string CodigoEmpleado { get; set; }
        public string CodigoTercero { get; set; }
        public string TipoUsuario { get; set; }
        public string DependenciaUsuario { get; set; }
        public bool EsCliente { get; set; }
        public string Contrasena { get; set; }

        //OTROS

        public string NombreCompleto { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Celular { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public int IdEmpresa { get; set; }
        public string NitEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public string LogoEmpresa { get; set; }
        public string Rol { get; set; }
        public string KeyConnection { get; set; }

        //Autentication
        public string UserApiGl { get; set; }
        public string PasswordApiGL { get; set; }
    }
}
