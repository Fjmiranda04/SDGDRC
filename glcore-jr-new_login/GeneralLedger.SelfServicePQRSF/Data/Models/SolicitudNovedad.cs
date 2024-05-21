using System;

namespace GeneralLedger.SelfServiceCore.Data.Models
{
    public class SolicitudNovedad
    {
        public int IdSolicitudNovedad { get; set; }
        public string CodigoSolicitudNovedad { get; set; }
        public string CodigoEmpleado { get; set; }
        public string CedulaEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public DateTime FechaNovedad { get; set; }
        public string CodigoTipoNovedad { get; set; }
        public string NombreNovedad { get; set; }
        public string DescripcionNovedad { get; set; }
        public DateTime FechaAprobacionNovedad { get; set; }
        public int EstadoSolicitudNovedad { get; set; }
        public string ValorAnterior { get; set; }
        public string ValorNuevo { get; set; }

        //PARA VACACIONES

        public DateTime FechaPeriodoI { get; set; }
        public DateTime FechaPeriodoF { get; set; }
        public DateTime FechaVacacionesF { get; set; }
        public DateTime FechaVacacionesI { get; set; }
        public int DiasHabiles { get; set; }
        public int DiasCompensados { get; set; }
        public int DiasDisfrute { get; set; }
        public int TotalDias { get; set; }
        public int DiasPagar { get; set; }

        // PARA AUSENTISMO
        public DateTime FechaInicioAusentismo { get; set; }
        public DateTime FechaFinAusentismo { get; set; }
        public string DetalleAusentismo { get; set; }
        public string CodigoAusentismo { get; set; }
    }
}