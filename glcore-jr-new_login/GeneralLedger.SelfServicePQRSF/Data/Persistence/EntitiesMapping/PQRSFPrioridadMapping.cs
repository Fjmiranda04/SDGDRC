using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class PQRSFPrioridadMapping : IEntityTypeConfiguration<PQRSFPrioridad>
    {
        public void Configure(EntityTypeBuilder<PQRSFPrioridad> builder)
        {
            builder.ToTable("WEBGLSS_Prioridades");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nombre).HasMaxLength(20).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(c => c.delmrk).HasMaxLength(1).HasColumnType("VARCHAR").HasDefaultValue("1");
        }
    }
}