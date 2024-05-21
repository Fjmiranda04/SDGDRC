using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMappingGL
{
    public class ProEtiquetaMapping : IEntityTypeConfiguration<ProEtiqueta>
    {
        public void Configure(EntityTypeBuilder<ProEtiqueta> builder)
        {
            builder.HasKey(e => e.Codigo);

            builder.ToTable("proEtiquetas");

            builder.Property(e => e.delmrk)
               .IsRequired()
               .HasMaxLength(4)
               .IsUnicode(false);

            builder.Property(e => e.Nombre)
               .IsRequired()
               .HasMaxLength(50)
               .IsUnicode(false)
               .HasDefaultValueSql("('')");

            builder.Property(e => e.Codigo)
               .IsRequired()
               .HasMaxLength(10)
               .IsUnicode(false)
               .HasDefaultValueSql("('')");
        }
    }
}