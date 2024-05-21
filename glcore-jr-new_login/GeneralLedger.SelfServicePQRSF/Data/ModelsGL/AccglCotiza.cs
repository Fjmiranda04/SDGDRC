using System;

#nullable disable

namespace GeneralLedger.SelfServiceCore.Data.ModelsGL
{
    public partial class AccglCotiza
    {
        public string Delmrk { get; set; } = null!;
        public string Cotnum { get; set; } = null!;
        public string? Cotcli { get; set; }
        public DateTime? Cotfec { get; set; }
        public string Cotdet { get; set; } = null!;
        public decimal? Cotcan { get; set; }
        public int? Cotiva { get; set; }
        public decimal? Cottot { get; set; }
        public string Cotest { get; set; } = null!;
        public string CotVen { get; set; } = null!;
        public int CotTip { get; set; }
        public string Cotcondi { get; set; } = null!;
        public string Vencod { get; set; } = null!;
        public string Cotvali { get; set; } = null!;
        public string Cotforpa { get; set; } = null!;
        public string Cotgar { get; set; } = null!;
        public string Cotna { get; set; } = null!;
        public decimal Cotflete { get; set; }
        public decimal Cotdcto { get; set; }
        public decimal Cotrete { get; set; }
        public decimal CotTipoCambio { get; set; }
        public string CotCalifica { get; set; } = null!;
        public DateTime Cotfecestado { get; set; }
        public string Cotfactura { get; set; } = null!;
        public DateTime CotFecFactura { get; set; }
        public string Cotescala { get; set; } = null!;
        public string Cotusuario { get; set; } = null!;
        public string CotEstacion { get; set; } = null!;
        public string CotOt { get; set; } = null!;
        public DateTime CotFechaOt { get; set; }
        public string Solicitante { get; set; } = null!;
        public decimal Descuento { get; set; }
        public int DesdeOt { get; set; }
        public DateTime FechaRegistro { get; set; }
        public decimal? Rentabilidad { get; set; }
        public string NumActaFinal { get; set; } = null!;
        public int CotAiu { get; set; }
        public int CotIvaInc { get; set; }
        public string CotRemision { get; set; } = null!;
        public string CotFteFactura { get; set; } = null!;
        public int CodigoSolicitante { get; set; }
        public string CotTipMon { get; set; } = null!;
        public string? CotPedido { get; set; }
        public DateTime DateLastUpd { get; set; }
    }
}