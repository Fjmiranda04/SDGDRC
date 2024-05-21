using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class SituacionMapping : IEntityTypeConfiguration<Situacion>
    {
        public void Configure(EntityTypeBuilder<Situacion> builder)
        {
            builder.ToTable("WEBGLSS_SituacionesNoConformes");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Codigo).HasMaxLength(4).HasColumnType("VARCHAR");
            builder.Property(c => c.TipoSituacion).HasMaxLength(20).HasColumnType("VARCHAR");
            builder.Property(c => c.delmrk).HasMaxLength(2).HasColumnType("VARCHAR").HasDefaultValueSql("1");
        }
    }
}