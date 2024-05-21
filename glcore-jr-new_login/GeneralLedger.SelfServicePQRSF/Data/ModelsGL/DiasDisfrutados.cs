using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.ModelsGL
{
    public class DiasDisfrutados
    {
        public DateTime FechaReingreso { get; set; }
        public int DiasAdicionales { get; set; }
        public int DiasDisfrute { get; set; }
    }
}
