namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class AgenteShowDTO
    {
        public int Id { get; set; }
        public string AgeCod { get; set; }
        public string NombreAgente { get; set; }
        public string Email { get; set; }
        public bool RecibeEmail { get; set; }
    }
}