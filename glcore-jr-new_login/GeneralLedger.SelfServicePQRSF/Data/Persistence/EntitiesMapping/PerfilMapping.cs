using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class PerfilMapping : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.ToTable("WEBGLSS_Perfiles");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.CodPerfil).HasMaxLength(10).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(p => p.NomPerfil).HasMaxLength(40).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(p => p.delmrk).HasMaxLength(2).HasColumnType("VARCHAR").HasDefaultValue("1");
        }
    }
}