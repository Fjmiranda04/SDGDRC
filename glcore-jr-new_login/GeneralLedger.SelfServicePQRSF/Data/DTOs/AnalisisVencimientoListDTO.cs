using System;

namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class AnalisisVencimientoListDTO
    {
        public string Cliente { get; set; }
        public string Calificacion { get; set; }
        public string Tipo { get; set; }
        public string Documento { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Vence { get; set; }
        public int DiasVen { get; set; }
        public Decimal Valor { get; set; }
        public string PagoConf { get; set; }
        public Decimal NoVen { get; set; }
        public Decimal Rango1 { get; set; }
        public Decimal Rango2 { get; set; }
        public Decimal Rango3 { get; set; }
        public Decimal Rango4 { get; set; }
        public Decimal ValorIva { get; set; }
        public string Vendedor { get; set; }
        public string Zona { get; set; }
        public string Nit { get; set; }
        public string DireccionCliente { get; set; }
        public string TelCliente { get; set; }
        public int DiasFac { get; set; }
        public Decimal SubTotal { get; set; }
        public Decimal Saldo { get; set; }
        public int ExcepcionDeterioro { get; set; }
        public string TERCOD { get; set; }
        public Decimal ClCTasa { get; set; }
        public int ClCDias { get; set; }
        public Decimal TCambio { get; set; }
        public string TipoCli { get; set; }
        public Decimal Deterioro { get; set; }
        public string Bandera { get; set; }
        public Decimal NoVenORI { get; set; }
        public Decimal Rango1ORI { get; set; }
        public Decimal Rango2ORI { get; set; }
        public Decimal Rango3ORI { get; set; }
        public Decimal Rango4ORI { get; set; }
        public Decimal Rango5ORI { get; set; }
        public Decimal Rango6ORI { get; set; }
        public Decimal ValorIvaORI { get; set; }
        public Decimal SubTotalORI { get; set; }
        public Decimal ValorORI { get; set; }
        public Decimal SaldoORI { get; set; }
        public Decimal DeterioroORI { get; set; }
        public bool Sel { get; set; }
        public string CodCli { get; set; }
        public string EstadoFactura { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string NomTitular { get; set; }
        public string TipoMoneda { get; set; }
    }
}