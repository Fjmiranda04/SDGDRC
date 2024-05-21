using System;
using System.Collections.Generic;

namespace GeneralLedger.SelfServiceCore.Data.ModelsGL
{
    public class ProPqrsf
    {
        public string Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaCierre { get; set; }
        public DateTime FechaCierreReal { get; set; }
        public string TipoPeticion { get; set; }
        public string Asunto { get; set; }
        public string Descripcion { get; set; }
        public string Eiquetas { get; set; }
        public string Estado { get; set; }
        public string TipoPrioridad { get; set; }
        public string TipoSituacion { get; set; }
        public string Area { get; set; }
        public string Contacto { get; set; }
        public string ContactoNumero { get; set; }
        public string NombreCliente { get; set; }
        public string EmailCliente { get; set; }
        public string AgenteResponsable { get; set; }
        public string AgentePerfila { get; set; }
        public string AgenteCierre { get; set; }
        public bool Perfilada { get; set; }
    }

    public class AyerVsHoy
    {
        public string Dia { get; set; }
        public int? H00_00 { get; set; }
        public int? H01_00 { get; set; }
        public int? H02_00 { get; set; }
        public int? H03_00 { get; set; }
        public int? H04_00 { get; set; }
        public int? H05_00 { get; set; }
        public int? H06_00 { get; set; }
        public int? H07_00 { get; set; }
        public int? H08_00 { get; set; }
        public int? H09_00 { get; set; }
        public int? H10_00 { get; set; }
        public int? H11_00 { get; set; }
        public int? H12_00 { get; set; }
        public int? H13_00 { get; set; }
        public int? H14_00 { get; set; }
        public int? H15_00 { get; set; }
        public int? H16_00 { get; set; }
        public int? H17_00 { get; set; }
        public int? H18_00 { get; set; }
        public int? H19_00 { get; set; }
        public int? H20_00 { get; set; }
        public int? H21_00 { get; set; }
        public int? H22_00 { get; set; }
        public int? H23_00 { get; set; }
    }

    public class DataByPeriodo
    {
        public decimal Asignadas { get; set; }
        public decimal PromedioAsignadas { get; set; }
        public decimal Resueltas { get; set; }
        public decimal PromedioResueltas { get; set; }
        public decimal AsignadasPasado { get; set; }
        public decimal PromedioAsignadasPasado { get; set; }
        public decimal ResueltasPasado { get; set; }
        public decimal PromedioResueltasPasado { get; set; }

        public decimal PorcentajeUpDownAsignadas { get; set; }
        public decimal PorcentajeUpDownResueltas { get; set; }
        public decimal PorcentajeUpDownAsignadasProm { get; set; }
        public decimal PorcentajeUpDownResueltasProm { get; set; }

        public List<PqrsfByDay> pqrsfByDays = new List<PqrsfByDay>();
    }

    public class PqrsfByDay
    {
        public string Tipo { get; set; }
        public int D1 { get; set; }
        public int D2 { get; set; }
        public int D3 { get; set; }
        public int D4 { get; set; }
        public int D5 { get; set; }
        public int D6 { get; set; }
        public int D7 { get; set; }
        public int D8 { get; set; }
        public int D9 { get; set; }
        public int D10 { get; set; }
        public int D11 { get; set; }
        public int D12 { get; set; }
        public int D13 { get; set; }
        public int D14 { get; set; }
        public int D15 { get; set; }
        public int D16 { get; set; }
        public int D17 { get; set; }
        public int D18 { get; set; }
        public int D19 { get; set; }
        public int D20 { get; set; }
        public int D21 { get; set; }
        public int D22 { get; set; }
        public int D23 { get; set; }
        public int D24 { get; set; }
        public int D25 { get; set; }
        public int D26 { get; set; }
        public int D27 { get; set; }
        public int D28 { get; set; }
        public int D29 { get; set; }
        public int D30 { get; set; }
        public int D31 { get; set; }
    }
}