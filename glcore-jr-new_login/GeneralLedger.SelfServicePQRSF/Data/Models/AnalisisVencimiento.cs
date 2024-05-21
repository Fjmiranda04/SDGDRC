using System;

namespace GeneralLedger.SelfServiceCore.Data.Models
{
    public class AnalisisVencimiento
    {
        public string Cliente { get; set; }
        public string Calificacion { get; set; }
        public string Tipo { get; set; }
        public string Documento { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Vence { get; set; }
        public int DiasVen { get; set; }
        public string PagoConf { get; set; }
        public Decimal NoVen { get; set; }
        public Decimal ValorIva { get; set; }
        public string Vendedor { get; set; }
        public string Zona { get; set; }
        public string Nit { get; set; }
        public string DireccionCliente { get; set; }
        public string TelCliente { get; set; }
        public int DiasFac { get; set; }
        public Decimal SubTotal { get; set; }
        public Decimal Valor { get; set; }
        public Decimal Saldo { get; set; }
        public Decimal TCambio { get; set; }
        public string TipoCli { get; set; }
        public string Bandera { get; set; }
        public string CodCli { get; set; }
        public string EstadoFactura { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string NomTitular { get; set; }
        public string TipoMoneda { get; set; }
    }
}