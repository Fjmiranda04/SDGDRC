namespace GeneralLedger.SelfServiceCore.Data.ModelsGL
{
    public class AccglUsuario
    {
        public string Delmrk { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public decimal Cajero { get; set; }
        public string Tipo { get; set; }
        public int Aprobar { get; set; }
        public decimal Monto { get; set; }
        public string Area { get; set; }
        public string CooCosto { get; set; }
        public string CodEmpleado { get; set; }
        public byte[] Clave { get; set; }
        public int UsarApp { get; set; }
        public string UserDep { get; set; }
        public int UserCliente { get; set; }
        public decimal Id { get; set; }
        public int ConfigTprov { get; set; }
    }
}