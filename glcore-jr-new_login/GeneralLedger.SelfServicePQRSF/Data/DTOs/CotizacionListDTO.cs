using System;

namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class CotizacionListDTO
    {
        public string Cotizacion { get; set; }
        public string NroIdCliente { get; set; }
        public string Cliente { get; set; }
        public string Etiqueta { get; set; }
        public DateTime Fecha { get; set; }
        public string Dias { get; set; }
        public string Estado { get; set; }
        public string Gestion { get; set; }
        public string Valor { get; set; }
        public string Descripcion { get; set; }
        public string Dependencia { get; set; }
        public Decimal Total { get; set; }
    }
}
