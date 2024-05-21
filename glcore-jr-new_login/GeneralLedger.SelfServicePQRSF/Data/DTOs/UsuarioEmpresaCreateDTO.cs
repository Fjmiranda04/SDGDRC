namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class UsuarioEmpresaCreateDTO
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string NitEmpresa { get; set; }
        public string NroIde { get; set; }
        public string Email { get; set; }
    }
}