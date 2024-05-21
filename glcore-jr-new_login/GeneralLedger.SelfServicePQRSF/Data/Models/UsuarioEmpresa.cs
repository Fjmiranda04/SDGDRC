namespace GeneralLedger.SelfServiceCore.Data.Models
{
    public class UsuarioEmpresa
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string NitEmpresa { get; set; }
        public string NroIde { get; set; }
        public string Email { get; set; }
    }
}