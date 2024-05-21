using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.ModelsGL
{
    public class HistorialLaboralEmpleado
    {
        public string NombreEmpleado { get; set; }
        public string CedulaEmpleado { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public string Motivo { get; set; }
    }
}
