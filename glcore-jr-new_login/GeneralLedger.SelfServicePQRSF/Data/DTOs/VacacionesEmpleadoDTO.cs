using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class VacacionesEmpleadoDTO
    {
        public string IdentificacionEmpleado { get; set; }
        public string CodigoEmpleado { get; set; }
        public string FechaPeriodoInicial { get; set; }
        public string FechaPeriodoFinal { get; set; }
        public string FechaInicialVacaciones { get; set; }
        public string FechaReintegro { get; set; }
        public int DiasHabiles { get; set; }
        public int DiasCompensados { get; set; }
        public int DiasDisfrute { get; set; }
        public int DiasTotal { get; set; }
        public int DiasPagar { get; set; }
        public string Observaciones { get; set; }
    }
}
