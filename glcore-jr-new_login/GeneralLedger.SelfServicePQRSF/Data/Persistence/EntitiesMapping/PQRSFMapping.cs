using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class PQRSFMapping : IEntityTypeConfiguration<PQRSF>
    {
        public void Configure(EntityTypeBuilder<PQRSF> builder)
        {
            builder.ToTable("WEBGLSS_MatrizPQRSF");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.NitEmpresa).HasMaxLength(20).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(c => c.Tipo).HasMaxLength(20).HasColumnType("VARCHAR").HasDefaultValue("PQRSF Externa");
            builder.Property(c => c.Fecha).HasColumnType("datetime").IsRequired(true).HasDefaultValueSql("getdate()");
            builder.Property(c => c.FechaCierre).HasColumnType("datetime").HasDefaultValueSql("getdate()");
            builder.Property(c => c.FechaCierreReal).HasColumnType("datetime").HasDefaultValueSql("getdate()");
            builder.Property(c => c.IdSituacion).IsRequired(true);
            builder.Property(c => c.Asunto).HasMaxLength(60).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(c => c.Descripcion).HasMaxLength(8000).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(c => c.IdEstado).HasMaxLength(20).HasColumnType("INT").HasDefaultValue(2);
            builder.Property(c => c.IdPrioridad).HasMaxLength(20).HasColumnType("INT").HasDefaultValue(5);
            builder.Property(c => c.Etiquetas).HasMaxLength(300).HasColumnType("VARCHAR").HasDefaultValue("");
            builder.Property(c => c.NroIdeCli).HasMaxLength(30).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(c => c.IdContacto).IsRequired(true);
            builder.Property(c => c.NroIdResponsable).HasMaxLength(20).HasColumnType("VARCHAR").HasDefaultValue("0000000000");
            builder.Property(c => c.NroIdPerfilo).HasMaxLength(20).HasColumnType("VARCHAR").HasDefaultValue("0000000000");
            builder.Property(c => c.NroIdCerro).HasMaxLength(20).HasColumnType("VARCHAR").HasDefaultValue("0000000000");
            builder.Property(c => c.IdProceso).HasDefaultValue("0000");
            builder.Property(c => c.Perfilacion).HasDefaultValue(false);
        }
    }
}