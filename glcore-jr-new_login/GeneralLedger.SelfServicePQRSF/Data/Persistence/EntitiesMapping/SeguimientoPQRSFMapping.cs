using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class SeguimientoPQRSFMapping : IEntityTypeConfiguration<SeguimientoPQRSF>
    {
        public void Configure(EntityTypeBuilder<SeguimientoPQRSF> builder)
        {
            builder.ToTable("WEBGLSS_Seguimientos");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.IdPQRSF).IsRequired(true);
            builder.Property(c => c.Fecha).HasColumnType("date").IsRequired(true).HasDefaultValueSql("getdate()");
            builder.Property(c => c.Observaciones).HasMaxLength(200).HasColumnType("VARCHAR").IsRequired(true);
        }
    }
}