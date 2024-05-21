using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class EmpresaMapping : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("WEBGLSS_Empresas");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nit).HasMaxLength(15).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(x => x.DIV).HasMaxLength(2).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(x => x.Nombre).HasMaxLength(100).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(x => x.CodigoLegacy).HasMaxLength(10).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(x => x.EmailPrincipal).HasMaxLength(2).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(x => x.Estado).HasMaxLength(2).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(x => x.UrlWeb).HasMaxLength(500).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(x => x.Logo).HasMaxLength(500).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(x => x.IP).HasMaxLength(30).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(x => x.DB).HasMaxLength(30).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(x => x.KeyConnection).HasMaxLength(40).HasColumnType("VARCHAR").IsRequired(true);
        }
    }
}