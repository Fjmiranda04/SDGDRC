using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class PermisoEmpleadoDTO
    {
        public string IdentificacionEmpleado { get; set; }
        public string CodigoEmpleado { get; set; }
        public string TipoPermiso { get; set; }
        public string FechaInicial { get; set; }
        public string FechaFinal { get; set; }
        public string HoraInicial { get; set; }
        public string HoraFinal { get; set; }
        public bool Reingresa { get; set; }
        public string Observaciones { get; set; }
    }
}
