using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class ContactoClienteMapping : IEntityTypeConfiguration<ContactoCliente>
    {
        public void Configure(EntityTypeBuilder<ContactoCliente> builder)
        {
            builder.ToTable("WEBGLSS_ContactoClientes");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.NroIdCli).HasMaxLength(20).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(c => c.NombreContacto).HasMaxLength(50).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(c => c.Telefono).HasMaxLength(20).HasColumnType("VARCHAR");
            builder.Property(c => c.Celular).HasMaxLength(20).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(c => c.Email).HasMaxLength(100).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(c => c.NitEmpresa).HasMaxLength(20).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(c => c.Delmrk).HasMaxLength(2).HasColumnType("VARCHAR").HasDefaultValue("1");
        }
    }
}