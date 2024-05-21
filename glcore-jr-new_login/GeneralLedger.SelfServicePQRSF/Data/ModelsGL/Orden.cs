using System;

#nullable disable

namespace GeneralLedger.SelfServiceCore.Data.ModelsGL
{
    public partial class Orden
    {
        public string Delmrk { get; set; } = null!;
        public string Ordnro { get; set; } = null!;
        public string Ordnom { get; set; } = null!;
        public DateTime OrdFec { get; set; }
        public string Codigo { get; set; } = null!;
        public string Ordcli { get; set; } = null!;
        public DateTime? Ordliq { get; set; }
        public string Ordest { get; set; } = null!;
        public decimal Pesoneto { get; set; }
        public decimal Flete { get; set; }
        public decimal Seguro { get; set; }
        public decimal Otrosgastos { get; set; }
        public decimal Tc { get; set; }
        public decimal Subpartidas { get; set; }
        public string Codconcepto { get; set; } = null!;
        public string NroFact { get; set; } = null!;
        public DateTime FechaFact { get; set; }
        public decimal ValorFact { get; set; }
        public decimal Cif { get; set; }
        public string TipOrden { get; set; } = null!;
        public DateTime OrdFecLiq { get; set; }
        public string OrdCco { get; set; } = null!;
        public string OrdHora { get; set; } = null!;
        public string OrdCon { get; set; } = null!;
        public string OrdInf { get; set; } = null!;
        public string OrdComp { get; set; } = null!;
        public string OrdPlaca { get; set; } = null!;
        public string OrdClase { get; set; } = null!;
        public string OrdMarca { get; set; } = null!;
        public int OrdTipo { get; set; }
        public string OrdGrua { get; set; } = null!;
        public string OrdAgente { get; set; } = null!;
        public string OrdHoraSal { get; set; } = null!;
        public DateTime OrdSal { get; set; }
        public string OrdProp { get; set; } = null!;
        public int OrdTcli { get; set; }
        public int OrdFac { get; set; }
        public string OrdReg { get; set; } = null!;
        public string OrdDir { get; set; } = null!;
        public string OrdSec { get; set; } = null!;
        public string OrdBar { get; set; } = null!;
        public string OrdPoli { get; set; } = null!;
        public string OrdMed { get; set; } = null!;
        public string OrdUser { get; set; } = null!;
        public string OrdTipoO { get; set; } = null!;
        public int OrdGoC { get; set; }
        public string OrdModelo { get; set; } = null!;
        public string Ordserial { get; set; } = null!;
        public string OrdDesc { get; set; } = null!;
        public string OrdHoraF { get; set; } = null!;
        public string OrdTipOrden { get; set; } = null!;
        public string Carga { get; set; } = null!;
        public string OrdNivelGas { get; set; } = null!;
        public string OrdKm { get; set; } = null!;
        public decimal Fob { get; set; }
        public string OrdTipificador { get; set; } = null!;
        public string OrdTipificador2 { get; set; } = null!;
        public string OrdHoraLlegada { get; set; } = null!;
        public string OrdHoraEspera { get; set; } = null!;
        public string OrdHoraSalida { get; set; } = null!;
        public string OrdVendedor { get; set; } = null!;
        public string OrdFuente { get; set; } = null!;
        public string OrdDescripcion { get; set; } = null!;
        public string OrdSolucion { get; set; } = null!;
        public string UserDef { get; set; } = null!;
        public string PcDef { get; set; } = null!;
        public DateTime FechaDef { get; set; }
        public string OrdPaciente { get; set; } = null!;
        public string Nmanten { get; set; } = null!;
        public DateTime FechaCierre { get; set; }
        public string OrdenPago { get; set; } = null!;
        public DateTime FechaOp { get; set; }
        public string Autorizacion { get; set; } = null!;
        public DateTime FechaAutorizacion { get; set; }
        public int ReqGen { get; set; }
        public string SolucionAplicada { get; set; } = null!;
        public int VerHojaVida { get; set; }
        public string CodigoMtto { get; set; } = null!;
        public int Idmtto { get; set; }
        public string DiagPreliminar { get; set; } = null!;
        public string DiagTecnico { get; set; } = null!;
        public int CodActivo { get; set; }
        public decimal AcumActualKms { get; set; }
        public decimal AcumActualHrs { get; set; }
        public int AcumActualMov { get; set; }
        public string TipoMtto { get; set; } = null!;
        public string Ordescala { get; set; } = null!;
        public int OrdTipoPago { get; set; }
        public string TipDocCierre { get; set; } = null!;
        public string OrdOrigen { get; set; } = null!;
        public DateTime DateLastUpd { get; set; }
    }
}