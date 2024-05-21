using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class MenuRolMapping : IEntityTypeConfiguration<MenuRol>
    {
        public void Configure(EntityTypeBuilder<MenuRol> builder)
        {
            builder.ToTable("WEBGLSS_MenuRoles");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.idRol).HasMaxLength(50).HasColumnType("VARCHAR");
            builder.Property(m => m.CodMnu).HasMaxLength(10).HasColumnType("VARCHAR");
            builder.Property(m => m.delmrk).HasMaxLength(2).HasColumnType("VARCHAR").HasDefaultValue(1);
        }
    }
}