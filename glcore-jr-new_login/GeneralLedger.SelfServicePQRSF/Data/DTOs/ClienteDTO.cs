namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string TipoDoc { get; set; }
        public string NroId { get; set; }
        public string NombreCompleto { get; set; }
        public string Celular { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }
}