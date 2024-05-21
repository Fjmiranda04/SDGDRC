using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class ConfiguracionMapping : IEntityTypeConfiguration<Configuracion>
    {
        public void Configure(EntityTypeBuilder<Configuracion> builder)
        {
            builder.ToTable("WEBGLSS_Configuracion");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Clave).HasMaxLength(500).HasColumnType("VARCHAR");
            builder.Property(a => a.Valor).HasMaxLength(100).HasColumnType("VARCHAR");
            builder.Property(a => a.Descripcion).HasMaxLength(200).HasColumnType("VARCHAR");
        }
    }
}