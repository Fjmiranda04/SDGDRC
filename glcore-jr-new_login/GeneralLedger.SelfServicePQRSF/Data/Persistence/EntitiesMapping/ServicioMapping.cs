using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class ServicioMapping : IEntityTypeConfiguration<Servicio>
    {
        public void Configure(EntityTypeBuilder<Servicio> builder)
        {
            builder.HasNoKey();
            builder.Property(a => a.tracod).HasColumnType("VARCHAR");
            builder.Property(a => a.tranom).HasColumnType("VARCHAR");
            builder.Property(a => a.arprecio).HasColumnType("numeric");
            builder.Property(a => a.traiva).HasColumnType("numeric");
            builder.Property(a => a.trades).HasColumnType("VARCHAR");
            builder.Property(a => a.Costo).HasColumnType("numeric");
        }
    }
}