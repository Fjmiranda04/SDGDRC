using System;
using System.Collections.Generic;

namespace GeneralLedger.SelfServiceCore.Data.Models
{
    public class RecaudoCartera
    {
        public int MesFechaDoc { get; set; }
        public Decimal AbonoFactura { get; set; }
    }

    public class Recaudos
    {
        public List<RecaudoCartera> ListCartera = new List<RecaudoCartera>();
        public List<RecaudoCartera> ListRecaudo = new List<RecaudoCartera>();
    }
}