using System;

namespace GeneralLedger.SelfServiceCore.Data.Models
{
    public class Pago
    {
        public string recNro { get; set; }
        public string TipPag { get; set; }
        public DateTime recFec { get; set; }
        public Decimal recVlr { get; set; }
        public string banNom { get; set; }
        public string recchk { get; set; }
        public string recbchk { get; set; }
        public Decimal recrtFte { get; set; }
        public Decimal recrtcree { get; set; }
        public Decimal recrtIca { get; set; }
        public Decimal recrtIva { get; set; }
        public Decimal recdescto { get; set; }
        public bool recEST { get; set; }
    }
}