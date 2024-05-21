using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class AgenteMapping : IEntityTypeConfiguration<Agente>
    {
        public void Configure(EntityTypeBuilder<Agente> builder)
        {
            builder.ToTable("WEBGLSS_Agentes");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Codigo).HasMaxLength(10).HasColumnType("VARCHAR");
            builder.Property(a => a.NroId).HasMaxLength(20).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(a => a.NombreCompleto).HasMaxLength(50).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(a => a.Email).HasMaxLength(50).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(a => a.RecibeEmail).HasDefaultValue(true);
            builder.Property(a => a.NitEmpresa).HasMaxLength(20).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(a => a.delmrk).HasMaxLength(2).HasColumnType("VARCHAR").HasDefaultValue("1");
        }
    }
}