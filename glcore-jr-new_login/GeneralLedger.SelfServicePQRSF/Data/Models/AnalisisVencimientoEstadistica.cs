using System;

namespace GeneralLedger.SelfServiceCore.Data.Models
{
    public class AnalisisVencimientoEstadistica
    {
        public string Cliente { get; set; }
        public string CodigoCliente { get; set; }
        public string NitCliente { get; set; }
        public string Calificacion { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int DiasVen { get; set; }
        public Decimal Valor { get; set; }
        public Decimal SubTotal { get; set; }
        public Decimal ValorIva { get; set; }
        public Decimal Saldo { get; set; }
        public Decimal NoVen { get; set; }
        public Decimal Rango1 { get; set; }
        public Decimal Rango2 { get; set; }
        public Decimal Rango3 { get; set; }
        public Decimal Rango4 { get; set; }
        public string Dependencia { get; set; }
        public string CodigoCiudad { get; set; }
    }
}