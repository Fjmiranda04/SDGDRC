using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMappingGL
{
    public class AccglCotizaMapping : IEntityTypeConfiguration<AccglCotiza>
    {
        public void Configure(EntityTypeBuilder<AccglCotiza> builder)
        {
            builder.HasKey(e => e.Cotnum)
                    .HasName("PK_accglcotiza")
                    .IsClustered(false);

            builder.ToTable("accglCotiza");

            builder.Property(e => e.Cotnum)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("cotnum")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CotAiu).HasColumnName("cotAiu");

            builder.Property(e => e.CotCalifica)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cotCalifica")
                .HasDefaultValueSql("('Sin Calificar')");

            builder.Property(e => e.CotEstacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cotEstacion")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CotFecFactura)
                .HasColumnType("datetime")
                .HasColumnName("cotFecFactura")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CotFechaOt)
                .HasColumnType("datetime")
                .HasColumnName("cotFechaOT")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CotFteFactura)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CotIvaInc).HasColumnName("cotIvaInc");

            builder.Property(e => e.CotOt)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("cotOT")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CotPedido)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CotRemision)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CotTipMon)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValueSql("('COP')");

            builder.Property(e => e.CotTipoCambio)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("cotTipoCambio")
                .HasDefaultValueSql("(1)");

            builder.Property(e => e.CotVen)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cotcan)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("cotcan")
                .HasDefaultValueSql("(0)");

            builder.Property(e => e.Cotcli)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("cotcli")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cotcondi)
                .IsUnicode(false)
                .HasColumnName("cotcondi")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cotdcto)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("cotdcto");

            builder.Property(e => e.Cotdet)
                .IsUnicode(false)
                .HasColumnName("cotdet")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cotescala)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("cotescala")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cotest)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("cotest")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.Cotfactura)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cotfactura")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cotfec)
                .HasColumnType("datetime")
                .HasColumnName("cotfec")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cotfecestado)
                .HasColumnType("datetime")
                .HasColumnName("cotfecestado")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cotflete)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("cotflete");

            builder.Property(e => e.Cotforpa)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("cotforpa")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cotgar)
                .IsUnicode(false)
                .HasColumnName("cotgar")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cotiva)
                .HasColumnName("cotiva")
                .HasDefaultValueSql("(0)");

            builder.Property(e => e.Cotna)
                .IsUnicode(false)
                .HasColumnName("cotna")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cotrete)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("cotrete");

            builder.Property(e => e.Cottot)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("cottot")
                .HasDefaultValueSql("(0)");

            builder.Property(e => e.Cotusuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cotusuario")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cotvali)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("cotvali")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.DateLastUpd)
                .HasColumnType("datetime")
                .HasDefaultValueSql("('19000101')");

            builder.Property(e => e.Delmrk)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("delmrk")
                .HasDefaultValueSql("(1)");

            builder.Property(e => e.Descuento).HasColumnType("numeric(18, 2)");

            builder.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.NumActaFinal)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("numActaFinal")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Rentabilidad)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("rentabilidad")
                .HasDefaultValueSql("((0))");

            builder.Property(e => e.Solicitante)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Vencod)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("vencod")
                .HasDefaultValueSql("('')"); builder.HasKey(e => e.Cotnum)
                    .HasName("PK_accglcotiza")
                    .IsClustered(false);

            builder.ToTable("accglCotiza");

            builder.Property(e => e.Cotnum)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("cotnum")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CotAiu).HasColumnName("cotAiu");

            builder.Property(e => e.CotCalifica)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cotCalifica")
                .HasDefaultValueSql("('Sin Calificar')");

            builder.Property(e => e.CotEstacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cotEstacion")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CotFecFactura)
                .HasColumnType("datetime")
                .HasColumnName("cotFecFactura")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CotFechaOt)
                .HasColumnType("datetime")
                .HasColumnName("cotFechaOT")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CotFteFactura)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CotIvaInc).HasColumnName("cotIvaInc");

            builder.Property(e => e.CotOt)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("cotOT")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CotPedido)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CotRemision)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CotTipMon)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValueSql("('COP')");

            builder.Property(e => e.CotTipoCambio)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("cotTipoCambio")
                .HasDefaultValueSql("(1)");

            builder.Property(e => e.CotVen)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cotcan)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("cotcan")
                .HasDefaultValueSql("(0)");

            builder.Property(e => e.Cotcli)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("cotcli")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cotcondi)
                .IsUnicode(false)
                .HasColumnName("cotcondi")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cotdcto)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("cotdcto");

            builder.Property(e => e.Cotdet)
                .IsUnicode(false)
                .HasColumnName("cotdet")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cotescala)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("cotescala")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cotest)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("cotest")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.Cotfactura)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cotfactura")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cotfec)
                .HasColumnType("datetime")
                .HasColumnName("cotfec")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cotfecestado)
                .HasColumnType("datetime")
                .HasColumnName("cotfecestado")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cotflete)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("cotflete");

            builder.Property(e => e.Cotforpa)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("cotforpa")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cotgar)
                .IsUnicode(false)
                .HasColumnName("cotgar")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cotiva)
                .HasColumnName("cotiva")
                .HasDefaultValueSql("(0)");

            builder.Property(e => e.Cotna)
                .IsUnicode(false)
                .HasColumnName("cotna")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cotrete)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("cotrete");

            builder.Property(e => e.Cottot)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("cottot")
                .HasDefaultValueSql("(0)");

            builder.Property(e => e.Cotusuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cotusuario")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cotvali)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("cotvali")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.DateLastUpd)
                .HasColumnType("datetime")
                .HasDefaultValueSql("('19000101')");

            builder.Property(e => e.Delmrk)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("delmrk")
                .HasDefaultValueSql("(1)");

            builder.Property(e => e.Descuento).HasColumnType("numeric(18, 2)");

            builder.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.NumActaFinal)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("numActaFinal")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Rentabilidad)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("rentabilidad")
                .HasDefaultValueSql("((0))");

            builder.Property(e => e.Solicitante)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Vencod)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("vencod")
                .HasDefaultValueSql("('')");
        }
    }
}