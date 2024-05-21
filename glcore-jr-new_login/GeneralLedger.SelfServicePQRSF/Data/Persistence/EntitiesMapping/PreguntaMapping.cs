using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class PreguntaMapping : IEntityTypeConfiguration<Pregunta>
    {
        public void Configure(EntityTypeBuilder<Pregunta> builder)
        {
            builder.ToTable("WEBGLSS_Preguntas");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.NomPregunta).HasMaxLength(200).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(p => p.NitEmpresa).HasMaxLength(20).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(p => p.delmrk).HasMaxLength(2).HasColumnType("VARCHAR").HasDefaultValueSql("1");
        }
    }
}