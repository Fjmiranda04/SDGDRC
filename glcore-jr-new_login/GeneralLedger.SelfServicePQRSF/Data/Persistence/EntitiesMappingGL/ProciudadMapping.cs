using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMappingGL
{
    public class ProciudadMapping : IEntityTypeConfiguration<Prociudad>
    {
        public void Configure(EntityTypeBuilder<Prociudad> builder)
        {
            builder.HasKey(e => e.Ciucod);

            builder.ToTable("prociudades");

            builder.Property(e => e.Ciucod)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ciucod")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Ciunom)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ciunom")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CodDpto)
                .IsRequired()
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("codDpto")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Delmrk)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("delmrk")
                .HasDefaultValueSql("('1')");
        }
    }
}