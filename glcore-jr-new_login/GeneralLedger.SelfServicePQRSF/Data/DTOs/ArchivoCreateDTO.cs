namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class ArchivoCreateDTO
    {
        public int Id { get; set; }
        public int CodPQRSF { get; set; }
        public string Nombre { get; set; }
        public string Ruta { get; set; }
        public string Url { get; set; }
        public string ContentType { get; set; }
        public string delmrk { get; set; }
    }
}