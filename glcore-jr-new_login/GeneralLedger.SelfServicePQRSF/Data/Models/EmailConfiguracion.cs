namespace GeneralLedger.SelfServiceCore.Data.Models
{
    public class EmailConfiguracion
    {
        public int Id { get; set; }
        public string KeyValue { get; set; }
        public string Remitente { get; set; }
        public string NombreRemitente { get; set; }
        public string ReplyTo { get; set; }
        public string Titulo { get; set; }
        public string Asunto { get; set; }
        public string Cuerpo { get; set; }
        public string Template { get; set; }
        public string LogoEmpresa { get; set; }
        public string WebEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public string Token { get; set; }
    }
}