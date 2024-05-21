using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class EmailConfiguracionMapping : IEntityTypeConfiguration<EmailConfiguracion>
    {
        public void Configure(EntityTypeBuilder<EmailConfiguracion> builder)
        {
            builder.ToTable("WEBGLSS_EmailConfiguracion");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.KeyValue).HasMaxLength(20).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(e => e.Remitente).HasMaxLength(40).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(e => e.NombreRemitente).HasMaxLength(100).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(e => e.ReplyTo).HasMaxLength(500).HasColumnType("VARCHAR");
            builder.Property(e => e.Titulo).HasMaxLength(100).HasColumnType("VARCHAR");
            builder.Property(e => e.Asunto).HasMaxLength(100).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(e => e.Cuerpo).HasMaxLength(1000).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(e => e.Template).HasMaxLength(50).HasColumnType("VARCHAR");
            builder.Property(e => e.LogoEmpresa).HasMaxLength(200).HasColumnType("VARCHAR");
            builder.Property(e => e.WebEmpresa).HasMaxLength(50).HasColumnType("VARCHAR");
            builder.Property(e => e.NombreEmpresa).HasMaxLength(50).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(e => e.Token).HasMaxLength(2000).HasColumnType("VARCHAR").IsRequired(true);
        }
    }
}