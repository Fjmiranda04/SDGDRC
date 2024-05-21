using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMappingGL
{
    public class TrabajoMapping : IEntityTypeConfiguration<Trabajo>
    {
        public void Configure(EntityTypeBuilder<Trabajo> builder)
        {
            builder.HasNoKey();

            builder.ToView("Trabajos");

            builder.Property(e => e.Aiu)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("AIU");

            builder.Property(e => e.Ardisco)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("ardisco");

            builder.Property(e => e.Areven)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("areven");

            builder.Property(e => e.Arprecio)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("arprecio");

            builder.Property(e => e.Arventa)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("arventa");

            builder.Property(e => e.Costo)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("costo");

            builder.Property(e => e.Delmrk)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("delmrk");

            builder.Property(e => e.Escala1)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("escala1");

            builder.Property(e => e.Escala2)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("escala2");

            builder.Property(e => e.Escala3)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("escala3");

            builder.Property(e => e.Escala4)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("escala4");

            builder.Property(e => e.Mensaje)
                .IsRequired()
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("mensaje");

            builder.Property(e => e.ProxRevision).HasColumnName("proxRevision");

            builder.Property(e => e.TiempoEstimado)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("tiempoEstimado");

            builder.Property(e => e.TraCant).HasColumnType("numeric(18, 3)");

            builder.Property(e => e.TraCargo)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.TraCes).HasColumnType("numeric(18, 2)");

            builder.Property(e => e.TraEnDolares).HasColumnName("traEnDolares");

            builder.Property(e => e.TraFormato)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.TraImpoconsumo)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("traImpoconsumo");

            builder.Property(e => e.TraInt).HasColumnType("numeric(18, 2)");

            builder.Property(e => e.TraPces)
                .IsRequired()
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("TraPCes");

            builder.Property(e => e.TraPint)
                .IsRequired()
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("TraPInt");

            builder.Property(e => e.TraPpri)
                .IsRequired()
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("TraPPri");

            builder.Property(e => e.TraPrecio).HasColumnType("numeric(18, 2)");

            builder.Property(e => e.TraPri).HasColumnType("numeric(18, 2)");

            builder.Property(e => e.TraPvac)
                .IsRequired()
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("TraPVac");

            builder.Property(e => e.TraTipSer)
                .IsRequired()
                .HasMaxLength(3)
                .IsUnicode(false);

            builder.Property(e => e.TraVac).HasColumnType("numeric(18, 2)");

            builder.Property(e => e.Tracco)
                .IsRequired()
                .HasMaxLength(4)
                .IsUnicode(false);

            builder.Property(e => e.Tracod)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("tracod");

            builder.Property(e => e.Tracon)
                .IsRequired()
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("tracon");

            builder.Property(e => e.Tracta)
                .IsRequired()
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("tracta");

            builder.Property(e => e.Tradatosrips).HasColumnName("tradatosrips");

            builder.Property(e => e.Trades)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("trades");

            builder.Property(e => e.Traestancia).HasColumnName("traestancia");

            builder.Property(e => e.Tragrupo)
                .IsRequired()
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("tragrupo");

            builder.Property(e => e.Traiva)
                .HasColumnType("numeric(18, 5)")
                .HasColumnName("traiva");

            builder.Property(e => e.Tralinea)
                .IsRequired()
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("tralinea");

            builder.Property(e => e.Tramed)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tramed");

            builder.Property(e => e.Tranom)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tranom");

            builder.Property(e => e.Trapor)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("trapor");

            builder.Property(e => e.Trarips)
                .IsRequired()
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("trarips");

            builder.Property(e => e.Tratip).HasColumnName("tratip");

            builder.Property(e => e.Tratipfrm).HasColumnName("tratipfrm");

            builder.Property(e => e.Tratipqx)
                .IsRequired()
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("tratipqx");

            builder.Property(e => e.Travlr)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("travlr");
        }
    }
}