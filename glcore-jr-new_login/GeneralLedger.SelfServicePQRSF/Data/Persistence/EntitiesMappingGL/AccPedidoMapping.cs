using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMappingGL
{
    public class AccPedidoMapping : IEntityTypeConfiguration<AccPedido>
    {
        public void Configure(EntityTypeBuilder<AccPedido> builder)
        {
            builder.HasKey(e => new { e.Nrofac, e.Tipodoc });

            builder.ToTable("accPedidos");

            builder.Property(e => e.Nrofac)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("nrofac")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Tipodoc)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("tipodoc")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Abonof)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("abonof");

            builder.Property(e => e.Aiu)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("AIU");

            builder.Property(e => e.AntFactura).HasColumnType("numeric(18, 2)");

            builder.Property(e => e.Anticipos).HasColumnType("numeric(18, 2)");

            builder.Property(e => e.Anulada).HasColumnName("anulada");

            builder.Property(e => e.Buque)
                .IsRequired()
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("buque")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Calificacion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cancelada).HasColumnName("cancelada");

            builder.Property(e => e.Causado).HasColumnName("CAUSADO");

            builder.Property(e => e.CcDevIva)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("ccDevIva");

            builder.Property(e => e.Ciudad)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Clitipo)
                .IsRequired()
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("clitipo")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CodCodeudor)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("codCodeudor")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CodEscala)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CodImp)
                .IsRequired()
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CodPagfacel)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CodUsuario)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("codUsuario")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Codcli)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("codcli")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Codcodeudor2)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("codcodeudor2")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Concepto)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("concepto")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CtaCrAutoCree)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CtaDbAutoCree)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cuotas).HasColumnName("cuotas");

            builder.Property(e => e.CxcIdSucursal)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("cxc_Id_Sucursal");

            builder.Property(e => e.CxcTipMon)
                .IsRequired()
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("cxcTipMon")
                .HasDefaultValueSql("('COP')");

            builder.Property(e => e.DateLastUpd)
                .HasColumnType("datetime")
                .HasDefaultValueSql("('19000101')");

            builder.Property(e => e.Dependencia)
                .IsRequired()
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("dependencia")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Descuento)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("descuento");

            builder.Property(e => e.Descuento1)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("descuento1");

            builder.Property(e => e.Descuento2)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("descuento2");

            builder.Property(e => e.Detalle)
                .IsRequired()
                .HasColumnType("ntext")
                .HasColumnName("detalle")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Devolucion).HasColumnType("numeric(18, 2)");

            builder.Property(e => e.Direccion)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Do)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("DO")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Docutransporte)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("docutransporte")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Embarcador)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("embarcador")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Estacion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(host_name())");

            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.Property(e => e.Fatcco)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("fatcco")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.FecAnu)
                .HasColumnType("datetime")
                .HasColumnName("fecANU")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.FecAuto)
                .HasColumnType("datetime")
                .HasColumnName("fecAuto")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.FecFactura)
                .HasColumnType("datetime")
                .HasColumnName("fecFACTURA")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.FecOri)
                .HasColumnType("datetime")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.FecRem)
                .HasColumnType("datetime")
                .HasColumnName("fecREM")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.FecTcrm)
                .HasColumnType("datetime")
                .HasColumnName("FecTCRM")
                .HasDefaultValueSql("('19000101')");

            builder.Property(e => e.Fecfac)
                .HasColumnType("datetime")
                .HasColumnName("fecfac")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.FechaPago)
                .HasColumnType("datetime")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.FechaReq)
                .HasColumnType("datetime")
                .HasColumnName("fechaReq")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.FechaSave)
                .HasColumnType("datetime")
                .HasColumnName("fecha_save")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.Fechap)
                .HasColumnType("datetime")
                .HasColumnName("fechap")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Feeban)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("FEEBan");

            builder.Property(e => e.Flete).HasColumnType("numeric(18, 2)");

            builder.Property(e => e.FormaPago)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("formaPago")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Glosa)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("glosa");

            builder.Property(e => e.Glosa2)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("glosa2");

            builder.Property(e => e.ImpoConsumo).HasColumnType("numeric(18, 2)");

            builder.Property(e => e.Ipoconsumo)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("ipoconsumo");

            builder.Property(e => e.Iva)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("iva");

            builder.Property(e => e.Iva2)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("iva2");

            builder.Property(e => e.IvaFlete)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ivaFlete");

            builder.Property(e => e.IvaPorcFlete)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ivaPorcFlete");

            builder.Property(e => e.Lineamar)
                .IsRequired()
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("lineamar")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Mercancia)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("mercancia")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Multa)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("multa");

            builder.Property(e => e.NIvaInc).HasColumnName("_nIvaInc");

            builder.Property(e => e.Nota)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("nota")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.NotaAclaratoria)
                .IsRequired()
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.NumeroPedido)
                .IsRequired()
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("numeroPedido")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OcRef)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("oc_ref")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OcRefFec)
                .HasColumnType("datetime")
                .HasColumnName("oc_ref_fec")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Otnumero)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OTnumero")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.PedidoDo)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("PedidoDO")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.PorAutoCree).HasColumnType("numeric(18, 2)");

            builder.Property(e => e.Porint)
                .HasColumnType("numeric(18, 5)")
                .HasColumnName("porint");

            builder.Property(e => e.Ptodestino)
                .IsRequired()
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ptodestino")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Ptoorigen)
                .IsRequired()
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ptoorigen")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Recibo)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("recibo")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Redondeo).HasColumnName("REDONDEO");

            builder.Property(e => e.Remision)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Rtcree)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("rtcree");

            builder.Property(e => e.Rtfte)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("rtfte");

            builder.Property(e => e.Rtfte2)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("RTFTE2");

            builder.Property(e => e.Rtgarantia)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("rtgarantia");

            builder.Property(e => e.Rtica)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("rtica");

            builder.Property(e => e.Rtiva)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("rtiva");

            builder.Property(e => e.Saldo)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("saldo");

            builder.Property(e => e.SaldoCxp)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("saldoCXP");

            builder.Property(e => e.SaldoNiif).HasColumnType("numeric(18, 2)");

            builder.Property(e => e.SaldoUsd)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("SaldoUSD");

            builder.Property(e => e.Solicitante)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("solicitante")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Subtotal)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("subtotal");

            builder.Property(e => e.Tcambio)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("TCambio")
                .HasDefaultValueSql("((1))");

            builder.Property(e => e.Telefono)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.TipoFactura)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Tipocli)
                .IsRequired()
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("tipocli")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.UserSave)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("user_save")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.ValCifFob).HasColumnType("numeric(18, 2)");

            builder.Property(e => e.ValorExtra).HasColumnType("numeric(18, 2)");

            builder.Property(e => e.ValorPesos).HasColumnType("numeric(18, 2)");

            builder.Property(e => e.ValorUsd)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("ValorUSD");

            builder.Property(e => e.Vendedor)
                .IsRequired()
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("vendedor")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Venfac).HasColumnName("venfac");

            builder.Property(e => e.Viaje)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("viaje")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.VlrDescuento).HasColumnType("numeric(18, 2)");

            builder.Property(e => e.VlrFeeban)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("VlrFEEBan");

            builder.Property(e => e.Vlrfac)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrfac");

            builder.Property(e => e.XAbono)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("xAbono");

            builder.Property(e => e.XAnticipo)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("xAnticipo");

            builder.Property(e => e.XDescuento)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("xDescuento");

            builder.Property(e => e.XRetefuente)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("xRetefuente");

            builder.Property(e => e.XReteica)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("xReteica");

            builder.Property(e => e.XReteiva)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("xReteiva");

            builder.Property(e => e.XSaldo)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("xSaldo");
        }
    }
}