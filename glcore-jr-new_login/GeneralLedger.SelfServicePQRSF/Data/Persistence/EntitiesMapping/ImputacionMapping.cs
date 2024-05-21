using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class ImputacionMapping : IEntityTypeConfiguration<Imputacion>
    {
        public void Configure(EntityTypeBuilder<Imputacion> builder)
        {
            builder.HasNoKey();
            builder.Property(x => x.codigo).HasColumnType("VARCHAR");
            builder.Property(x => x.cuenta).HasColumnType("VARCHAR");
            builder.Property(x => x.debito).HasColumnType("numeric");
            builder.Property(x => x.credito).HasColumnType("numeric");
            builder.Property(x => x.terceNombre).HasColumnType("VARCHAR");
            builder.Property(x => x.centroCosto).HasColumnType("VARCHAR");
        }
    }
}