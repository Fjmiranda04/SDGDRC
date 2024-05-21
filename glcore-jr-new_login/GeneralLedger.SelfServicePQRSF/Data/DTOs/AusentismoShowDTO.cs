using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class AusentismoShowDTO
    {
        public int Id_Unico { get; set; }
        public string CodigoEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public DateTime Fecha1 { get; set; }
        public DateTime Fecha2 { get; set; }
        public string Tipo_Ausentismo { get; set; }
        public string Detalle { get; set; }
    }

}
