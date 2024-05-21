namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class NovedadEmpleadoDTO
    {
        public string TipoNovedad { get; set; }
        public string CodigoEmpleado { get; set; }
        public string ValorAnterior { get; set; }
        public string ValorAnteriorExt { get; set; }
        public string ValorNuevo { get; set; }
        public string ValorNuevoExt { get; set; }
        public string Descripcion { get; set; }
    }
}