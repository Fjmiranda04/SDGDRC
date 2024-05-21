using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class ElementoMapping : IEntityTypeConfiguration<Elemento>
    {
        public void Configure(EntityTypeBuilder<Elemento> builder)
        {
            builder.ToTable("WEBGLSS_Elementos");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.NumEle).HasMaxLength(5).HasColumnType("VARCHAR");
            builder.Property(e => e.RefEle).HasMaxLength(15).HasColumnType("VARCHAR");
            builder.Property(e => e.TipEle).HasMaxLength(5).HasColumnType("VARCHAR");
            builder.Property(e => e.NomEle).HasMaxLength(30).HasColumnType("VARCHAR");
            builder.Property(e => e.VlrEle).HasMaxLength(15).HasColumnType("VARCHAR");
            builder.Property(e => e.delmrk).HasMaxLength(2).HasColumnType("VARCHAR").HasDefaultValue("1");
        }
    }
}