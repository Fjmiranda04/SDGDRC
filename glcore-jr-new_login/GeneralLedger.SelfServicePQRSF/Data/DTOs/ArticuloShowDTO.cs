using System;

namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class ArticuloShowDTO
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public Decimal Costo { get; set; }
        public string Referencia { get; set; }
        public Decimal Iva { get; set; }
        public Decimal Existencia { get; set; }
        public string Medida { get; set; }
        public Decimal PrecioMinimo { get; set; }
        public Decimal Minimo { get; set; }
        public Decimal Maximo { get; set; }
        public Decimal Precio { get; set; }
        public string Escala { get; set; }
    }
}