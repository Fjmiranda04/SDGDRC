using System;

namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class ServicioShowDTO
    {
        public string Codigo { get; set; }
        public string Servicio { get; set; }
        public string Medida { get; set; }
        public Decimal Valor { get; set; }
        public Decimal Iva { get; set; }
        public string Descripcion { get; set; }
        public Decimal Precio { get; set; }
        public string Escala { get; set; }
    }
}