using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Models
{
    public class EmpresaGL
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Telefono { get; set; }
        public string Nit { get; set; }
        public string Representante { get; set; }
        public string CedulaRepresentante { get; set; }
        public string CargoRepresentante { get; set; }
        public string Logo { get; set; }
        public string KeyConnection { get; set; }
    }
}
