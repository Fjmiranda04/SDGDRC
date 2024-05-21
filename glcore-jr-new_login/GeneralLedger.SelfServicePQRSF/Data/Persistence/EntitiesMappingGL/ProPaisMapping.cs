using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMappingGL
{
    public class ProPaisMapping : IEntityTypeConfiguration<ProPais>
    {
        public void Configure(EntityTypeBuilder<ProPais> builder)
        {
            builder.HasNoKey();

            builder.ToTable("proPaises");

            builder.Property(e => e.CodPais)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.DelMrk)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("delMrk")
                .HasDefaultValueSql("(1)");

            builder.Property(e => e.NomPais)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
        }
    }
}