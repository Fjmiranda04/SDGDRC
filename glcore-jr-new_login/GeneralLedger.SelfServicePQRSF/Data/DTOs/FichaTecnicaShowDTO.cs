using GeneralLedger.SelfServiceCore.Data.Models;
using System;
using System.Collections.Generic;

namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class FichaTecnicaShowDTO
    {
        public string nFactura { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaVenci { get; set; }
        public Decimal abono { get; set; }
        public string detalle { get; set; }
        public string Tipo { get; set; }
        public string Tipdoc { get; set; }
        public string cliente { get; set; }
        public Decimal subIva { get; set; }
        public Decimal Iva { get; set; }
        public Decimal vDesc { get; set; }
        public int vrCredito { get; set; }
        public Decimal total { get; set; }
        public Decimal nDevoluciones { get; set; }
        public Decimal nIvaDev { get; set; }
        public Decimal saldo { get; set; }
        public string Cajero { get; set; }
        public string Vendedor { get; set; }
        public string Zona { get; set; }
        public string ciudad { get; set; }
        public string estado { get; set; }
        public string llave { get; set; }
        public string Estacion { get; set; }
        public string Usuario { get; set; }
        public Decimal TCambio { get; set; }
        public string TMoneda { get; set; }

        public IEnumerable<Imputacion> ListImputaciones { get; set; }
        public IEnumerable<Pago> ListPagos { get; set; }
    }
}