namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class FilterPQRSFDTO
    {
        public string FechaCreacionIni { set; get; }
        public string FechaCreacionFin { set; get; }
        public string Agente { set; get; }
        public string Area { set; get; }
        public string Tipo { set; get; }
        public string Estado { set; get; }
        public string Prioridad { set; get; }
        public string Cliente { set; get; }
        public string Search { set; get; }
    }
}