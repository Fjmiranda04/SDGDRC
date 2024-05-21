using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class ProcesoMapping : IEntityTypeConfiguration<Proceso>
    {
        public void Configure(EntityTypeBuilder<Proceso> builder)
        {
            builder.ToTable("proareas");
            builder.HasKey(c => c.codare);
            builder.Property(c => c.delmrk).HasMaxLength(2).HasColumnType("VARCHAR").HasDefaultValueSql("1");
            builder.Property(c => c.nomare).HasMaxLength(30).HasColumnType("VARCHAR");
            builder.Property(c => c.codare).HasMaxLength(30).HasColumnType("VARCHAR");
            builder.Property(c => c.areResponsable).HasMaxLength(30).HasColumnType("VARCHAR");
        }
    }
}