namespace GeneralLedger.SelfServiceCore.Data.Models
{
    public class DetallePedido
    {
        public string codigo { get; set; }
        public string cantidad { get; set; }//
        public string detalle { get; set; }
        public string medida { get; set; }
        public string vlrUni { get; set; }//
        public string tipoMov { get; set; }
        public string cuentaInv { get; set; }
        public string cuentaCos { get; set; }
        public string cuentaIng { get; set; }
        public string tecnico { get; set; }
        public int iva { get; set; }
        public string costo { get; set; }//
        public string dependencia { get; set; }
        public string escala { get; set; }
        public string porDescuento { get; set; }//
        public string tercero { get; set; }
        public string valorIva { get; set; }//
        public string subtotal { get; set; }//
        public string cco { get; set; }
        public string NumDoc { get; set; }
        public string tipdoc_ped { get; set; }
    }
}