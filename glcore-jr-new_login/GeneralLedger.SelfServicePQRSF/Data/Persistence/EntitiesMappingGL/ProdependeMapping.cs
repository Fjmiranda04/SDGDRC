using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMappingGL
{
    public class ProdependeMapping : IEntityTypeConfiguration<Prodepende>
    {
        public void Configure(EntityTypeBuilder<Prodepende> builder)
        {
            builder.HasNoKey();

            builder.ToTable("prodepende");

            builder.HasIndex(e => e.Depcod, "IX_prodepende")
                .IsUnique();

            builder.HasIndex(e => e.Depnom, "IX_prodepende_1")
                .IsUnique();

            builder.Property(e => e.Cosexc)
                .IsRequired()
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("cosexc")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cosext)
                .IsRequired()
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("cosext")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cosgrv)
                .IsRequired()
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("cosgrv")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Delmrk)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("delmrk")
                .HasDefaultValueSql("('1')");

            builder.Property(e => e.DepCaja)
                .IsRequired()
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.DepCre)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.DepDir)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.DepEst).HasColumnName("depEst");

            builder.Property(e => e.DepObser)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("depObser")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.DepPos)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DepPOS")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.DepPreCre)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.DepPrePos)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("DepPrePOS")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.DepResCre)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.DepResPos)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DepResPOS")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.DepcCosto)
                .IsRequired()
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("depcCosto")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Depcoc).HasColumnName("depcoc");

            builder.Property(e => e.Depcod)
                .IsRequired()
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("depcod")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Depcos)
                .IsRequired()
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("depcos")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Deping)
                .IsRequired()
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("deping")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Depmesas).HasColumnName("depmesas");

            builder.Property(e => e.Depnom)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("depnom")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Deppuc)
                .IsRequired()
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("deppuc")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Deptel)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("deptel")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Devoluciones)
                .IsRequired()
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("DEVOLUCIONES")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.DoconsExp)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DOConsExp")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.DoconsImp)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DOConsImp")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.EgreCons)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.FactCons)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.IdresolucionCt).HasColumnName("IDresolucionCT");

            builder.Property(e => e.IdresolucionFr).HasColumnName("IDresolucionFR");

            builder.Property(e => e.Ingexc)
                .IsRequired()
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("ingexc")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Ingext)
                .IsRequired()
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("ingext")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Inggrv)
                .IsRequired()
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("inggrv")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Invexc)
                .IsRequired()
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("invexc")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Invext)
                .IsRequired()
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("invext")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Invgrv)
                .IsRequired()
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("invgrv")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.ModifiedByUser)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Ncrcons)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NCRCons")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Ndbcons)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NDBCons")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.PreExp)
                .IsRequired()
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.PreFact)
                .IsRequired()
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.PreImp)
                .IsRequired()
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.ReciCons)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Tipo)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.TranCons)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
        }
    }
}