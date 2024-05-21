using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class UsuarioEmpresaMapping : IEntityTypeConfiguration<UsuarioEmpresa>
    {
        public void Configure(EntityTypeBuilder<UsuarioEmpresa> builder)
        {
            builder.ToTable("WEBGLSS_UsuarioEmpresas");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.IdEmpresa).HasColumnType("int").IsRequired(true);
            builder.Property(u => u.NitEmpresa).HasMaxLength(20).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(u => u.NroIde).HasMaxLength(20).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(u => u.Email).HasMaxLength(40).HasColumnType("VARCHAR").IsRequired(true);
        }
    }
}