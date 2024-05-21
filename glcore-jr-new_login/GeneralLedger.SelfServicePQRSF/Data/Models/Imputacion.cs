using System;

namespace GeneralLedger.SelfServiceCore.Data.Models
{
    public class Imputacion
    {
        public string codigo { get; set; }
        public string cuenta { get; set; }
        public Decimal debito { get; set; }
        public Decimal credito { get; set; }
        public string terceNombre { get; set; }
        public string centroCosto { get; set; }
    }
}