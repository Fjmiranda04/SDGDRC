using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class NotaPQRSFMapping : IEntityTypeConfiguration<NotaPQRSF>
    {
        public void Configure(EntityTypeBuilder<NotaPQRSF> builder)
        {
            builder.ToTable("WEBGLSS_NotasPQRSF");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.IdPQRSF).IsRequired();
            builder.Property(t => t.Fecha).HasColumnType("Datetime").IsRequired(true).HasDefaultValueSql("getdate()");
            builder.Property(t => t.Tipo).HasColumnType("VARCHAR").HasMaxLength(15).IsRequired(true).HasDefaultValue("Nota");
            builder.Property(t => t.Nota).HasMaxLength(1000).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(t => t.NitEmpresa).HasMaxLength(20).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(t => t.NroIdeAutor).HasMaxLength(20).HasColumnType("VARCHAR");
        }
    }
}