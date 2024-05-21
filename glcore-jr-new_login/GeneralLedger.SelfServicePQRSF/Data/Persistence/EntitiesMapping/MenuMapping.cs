using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class MenuMapping : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("WEBGLSS_Menus");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CodMnu).HasMaxLength(10).HasColumnType("VARCHAR");
            builder.Property(c => c.NomMnu).HasMaxLength(50).HasColumnType("VARCHAR").IsRequired();
            builder.Property(c => c.Orden).HasMaxLength(3).HasColumnType("VARCHAR");
            builder.Property(c => c.NvlMnu).HasMaxLength(3).HasColumnType("VARCHAR");
            builder.Property(c => c.TpoMnu).HasMaxLength(10).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(c => c.DepMnu).HasMaxLength(10).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(c => c.Controller).HasMaxLength(20).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(c => c.Action).HasMaxLength(20).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(c => c.IcoMnu).HasMaxLength(40).HasColumnType("VARCHAR");
            builder.Property(c => c.delmrk).HasMaxLength(2).HasColumnType("VARCHAR").HasDefaultValueSql("1");
        }
    }
}