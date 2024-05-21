using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class EtiquetaMapping : IEntityTypeConfiguration<Etiqueta>
    {
        public void Configure(EntityTypeBuilder<Etiqueta> builder)
        {
            builder.ToTable("WEBGLSS_Etiquetas");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nombre).HasMaxLength(40).HasColumnType("VARCHAR");
            builder.Property(c => c.delmrk).HasMaxLength(2).HasColumnType("VARCHAR").HasDefaultValueSql("1");
        }
    }
}