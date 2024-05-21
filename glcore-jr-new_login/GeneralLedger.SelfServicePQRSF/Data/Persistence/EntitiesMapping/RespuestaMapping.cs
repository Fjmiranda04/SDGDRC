using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class RespuestaMapping : IEntityTypeConfiguration<Respuesta>
    {
        public void Configure(EntityTypeBuilder<Respuesta> builder)
        {
            builder.ToTable("WEBGLSS_Respuestas");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.IdPregunta).IsRequired(true);
            builder.Property(p => p.IdPQRSF).IsRequired(true);
            builder.Property(p => p.Observaciones).HasMaxLength(100).HasColumnType("VARCHAR");
            builder.Property(p => p.NitEmpresa).HasMaxLength(20).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(p => p.delmrk).HasMaxLength(2).HasColumnType("VARCHAR").HasDefaultValueSql("1");
        }
    }
}