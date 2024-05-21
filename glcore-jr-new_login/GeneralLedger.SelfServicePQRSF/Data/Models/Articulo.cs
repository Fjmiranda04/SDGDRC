using System;

namespace GeneralLedger.SelfServiceCore.Data.Models
{
    public class Articulo
    {
        public string arcod { get; set; }
        public string ARESPE { get; set; }
        public Decimal ArCosto { get; set; }
        public string ARREF { get; set; }
        public Decimal ArIva { get; set; }
        public Decimal Existencia { get; set; }
        public string ARMED { get; set; }
        public string remplazo { get; set; }
        public int artipoar { get; set; }
        public Decimal PrecioMinimo { get; set; }
        public string armar { get; set; }
        public int Minimo { get; set; }
        public int Arlote { get; set; }
        public Decimal arDosificacion { get; set; }
        public string CtaInventario { get; set; }
        public string ArEspecificacion { get; set; }
        public string CtaCosto { get; set; }
        public string CtaIngreso { get; set; }
        public Decimal arventa { get; set; }
        public Decimal ArDisco { get; set; }
        public Decimal ArEven { get; set; }
        public Decimal ArPrecio { get; set; }
        public int ArModalidad { get; set; }
        public int Maximo { get; set; }
        public string ARSECTOR { get; set; }
        public Decimal ARMINIMO { get; set; }
        public Decimal PRECIO { get; set; }
        public Decimal arporpre1 { get; set; }
        public Decimal arporpre2 { get; set; }
        public Decimal arporpre3 { get; set; }
        public Decimal arporpre4 { get; set; }
        public Decimal arporpremin { get; set; }
    }
}