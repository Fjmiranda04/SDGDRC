using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class TerceroMapping : IEntityTypeConfiguration<Tercero>
    {
        public void Configure(EntityTypeBuilder<Tercero> builder)
        {
            builder.ToTable("WEBGLSS_Terceros");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Codigo).HasMaxLength(20).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(t => t.TipoDoc).HasMaxLength(5).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(t => t.NroId).HasMaxLength(20).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(t => t.NombreCompleto).HasMaxLength(100).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(t => t.PrimerNombre).HasMaxLength(40).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(t => t.SegundoNombre).HasMaxLength(40).HasColumnType("VARCHAR");
            builder.Property(t => t.PrimerApellido).HasMaxLength(40).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(t => t.SegundoApellido).HasMaxLength(40).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(t => t.Ciudad).HasMaxLength(50).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(t => t.Direccion).HasMaxLength(90).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(t => t.Celular).HasMaxLength(20).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(t => t.Telefono).HasMaxLength(20).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(t => t.Email).HasMaxLength(50).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(t => t.FechaCreacion).HasDefaultValueSql("getdate()").IsRequired(true);
            builder.Property(t => t.NitEmpresa).HasMaxLength(20).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(t => t.Usuario).HasMaxLength(40).HasColumnType("VARCHAR");
            builder.Property(t => t.delmrk).HasMaxLength(2).HasColumnType("VARCHAR").HasDefaultValue("1");
        }
    }
}