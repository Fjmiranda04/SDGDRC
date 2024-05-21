namespace GeneralLedger.SelfServiceCore.Data.Models
{
    public class Agente
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string NroId { get; set; }
        public string NombreCompleto { get; set; }
        public string Email { get; set; }
        public bool? RecibeEmail { get; set; }
        public string NitEmpresa { get; set; }
        public string Area { get; set; }
        public string delmrk { get; set; }
    }
}