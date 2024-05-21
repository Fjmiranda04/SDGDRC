using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.ModelsGL
{
    public class ComprobantePagoEmpleado
    {
        public string novemp { get; set; }
        public string empnom { get; set; }
        public string novnom { get; set; }
        public decimal novdhc { get; set; }
        public decimal novdeb { get; set; }
        public string Entidad { get; set; }
        public string empEmail { get; set; }
        public string NomCargo { get; set; }
        public string TipoNomina { get; set; }
        public string empCed { get; set; }
        public decimal empSuelBas { get; set; }
        public decimal unitario { get; set; }
    }
}
