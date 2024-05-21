using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class ArchivoMapping : IEntityTypeConfiguration<Archivo>
    {
        public void Configure(EntityTypeBuilder<Archivo> builder)
        {
            builder.ToTable("WEBGLSSS_Archivos");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CodPQRSF).HasMaxLength(2).HasColumnType("Int");
            builder.Property(c => c.Nombre).HasMaxLength(100).HasColumnType("VARCHAR");
            builder.Property(c => c.Ruta).HasMaxLength(150).HasColumnType("VARCHAR");
            builder.Property(c => c.Url).HasMaxLength(200).HasColumnType("VARCHAR");
            builder.Property(c => c.ContentType).HasMaxLength(150).HasColumnType("VARCHAR");
            builder.Property(c => c.NitEmpresa).HasMaxLength(20).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(c => c.delmrk).HasMaxLength(2).HasColumnType("VARCHAR").HasDefaultValueSql("1");
        }
    }
}