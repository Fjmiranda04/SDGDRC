using System;

namespace GeneralLedger.SelfServiceCore.Data.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nit { get; set; }
        public string DIV { get; set; }
        public string Nombre { get; set; }
        public string CodigoLegacy { get; set; }
        public string EmailPrincipal { get; set; }
        public string Estado { get; set; }
        public string IP { get; set; }
        public string DB { get; set; }
        public string KeyConnection { get; set; }
        public string UrlWeb { get; set; }
        public string Logo { get; set; }
        public string Salt { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}