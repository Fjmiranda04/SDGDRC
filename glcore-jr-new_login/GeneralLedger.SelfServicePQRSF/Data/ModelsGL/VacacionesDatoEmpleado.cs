using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.ModelsGL
{
    public class VacacionesDatoEmpleado
    {
        public string IdentificacionEmpleado  { get; set; }
        public string TipoNomina { get; set; }
        public DateTime FechaInicialPeriodo { get; set; }
        public DateTime FechaFinalPeriodo { get; set; }
        public DateTime FechaInicialVacaciones { get; set; }
        public DateTime FechaReintegroVacaciones { get; set; }
        public decimal DiasHabiles { get; set; }
        public int DiasCompensados { get; set; }
        public int DiasDisfrute { get; set; }
        public int TotalDias { get; set; }
        public int DiasPagar { get; set; }

        public List<DateTime> DiasFestivos = new List<DateTime>();
    }
}
