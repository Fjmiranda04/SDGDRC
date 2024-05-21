namespace GeneralLedger.SelfServiceCore.Data.Models
{
    public class Respuesta
    {
        public int Id { get; set; }
        public int IdPregunta { get; set; }
        public int IdPQRSF { get; set; }
        public bool? Opcion { get; set; }
        public string Observaciones { get; set; }
        public string NitEmpresa { get; set; }
        public string delmrk { get; set; }
    }
}