using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class MenuUsuarioMapping : IEntityTypeConfiguration<MenuUsuario>
    {
        public void Configure(EntityTypeBuilder<MenuUsuario> builder)
        {
            builder.ToTable("WEBGLSS_MenuUsuarios");
            builder.HasKey(m => new { m.Id, m.NroIdUsr, m.CodMnu });
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.NroIdUsr).HasMaxLength(20).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(m => m.CodMnu).HasMaxLength(10).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(m => m.delmrk).HasMaxLength(2).HasColumnType("VARCHAR").HasDefaultValue(1);
        }
    }
}