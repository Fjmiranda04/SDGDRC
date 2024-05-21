using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class AusentismoEmpleadoDTO
    {
        public string CodigoEmpleado { get; set; }
        public DateTime FechaInicioAusentismo { get; set; }
        public DateTime FechaFinAusentismo { get; set; }
        public string DetalleAusentismo { get; set; }
        public string CodigoAusentismo { get; set; }
    }

}
