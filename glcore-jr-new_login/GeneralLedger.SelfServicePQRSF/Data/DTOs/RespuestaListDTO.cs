namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class RespuestaListDTO
    {
        public int Id { get; set; }
        public string Pregunta { get; set; }
        public bool? Opcion { get; set; }
        public string Observaciones { get; set; }
    }
}