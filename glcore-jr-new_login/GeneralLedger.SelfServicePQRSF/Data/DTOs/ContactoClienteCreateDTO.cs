namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class ContactoClienteCreateDTO
    {
        public int Id { get; set; }
        public string NroIdCli { get; set; }
        public string NombreContacto { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string NitEmpresa { get; set; }
    }
}