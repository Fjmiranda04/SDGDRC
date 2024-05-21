using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("WEBGLSS_Clientes");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.NroId).HasMaxLength(30).HasColumnType("VARCHAR");
            builder.Property(c => c.TipoDoc).HasMaxLength(5).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(c => c.Codigo).HasMaxLength(15).HasColumnType("VARCHAR");
            builder.Property(c => c.NombreCompleto).HasMaxLength(100).HasColumnType("VARCHAR");
            builder.Property(c => c.PrimerNombre).HasMaxLength(100).HasColumnType("VARCHAR");
            builder.Property(c => c.SegundoNombre).HasMaxLength(40).HasColumnType("VARCHAR");
            builder.Property(c => c.PrimerApellido).HasMaxLength(40).HasColumnType("VARCHAR");
            builder.Property(c => c.SegundoApellido).HasMaxLength(40).HasColumnType("VARCHAR");
            builder.Property(c => c.Ciudad).HasMaxLength(50).HasColumnType("VARCHAR");
            builder.Property(c => c.Direccion).HasMaxLength(90).HasColumnType("VARCHAR");
            builder.Property(c => c.Celular).HasMaxLength(50).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(c => c.Telefono).HasMaxLength(50).HasColumnType("VARCHAR");
            builder.Property(c => c.Email).HasMaxLength(100).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(c => c.Sexo).HasMaxLength(5).HasColumnType("VARCHAR");
            builder.Property(c => c.FechaCreacion).HasDefaultValueSql("getdate()").IsRequired(true);
            builder.Property(c => c.NitEmpresa).HasMaxLength(20).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(c => c.delmrk).HasMaxLength(2).HasColumnType("VARCHAR").HasDefaultValueSql("1");
        }
    }
}