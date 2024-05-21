namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class RespuestaCreateDTO
    {
        public int Id { get; set; }
        public int IdPregunta { get; set; }
        public int IdPQRSF { get; set; }
        public bool? Opcion { get; set; }
        public string Observaciones { get; set; }
    }
}