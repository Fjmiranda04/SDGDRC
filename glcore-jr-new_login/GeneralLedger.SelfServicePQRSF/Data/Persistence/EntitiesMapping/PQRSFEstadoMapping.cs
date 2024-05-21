using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class PQRSFEstadoMapping : IEntityTypeConfiguration<PQRSFEstado>
    {
        public void Configure(EntityTypeBuilder<PQRSFEstado> builder)
        {
            builder.ToTable("WEBGLSS_Estados");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nombre).HasMaxLength(20).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(c => c.delmrk).HasMaxLength(1).HasColumnType("VARCHAR").HasDefaultValue("1");
        }
    }
}