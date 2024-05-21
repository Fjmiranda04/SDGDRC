using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class PagoMapping : IEntityTypeConfiguration<Pago>
    {
        public void Configure(EntityTypeBuilder<Pago> builder)
        {
            builder.HasNoKey();
            builder.Property(x => x.recNro).HasColumnType("VARCHAR");
            builder.Property(x => x.TipPag).HasColumnType("VARCHAR");
            builder.Property(x => x.recFec).HasColumnType("date");
            builder.Property(x => x.recVlr).HasColumnType("numeric");
            builder.Property(x => x.banNom).HasColumnType("VARCHAR");
            builder.Property(x => x.recchk).HasColumnType("VARCHAR");
            builder.Property(x => x.recbchk).HasColumnType("VARCHAR");
            builder.Property(x => x.recrtFte).HasColumnType("numeric");
            builder.Property(x => x.recrtcree).HasColumnType("numeric");
            builder.Property(x => x.recrtIca).HasColumnType("numeric");
            builder.Property(x => x.recrtIva).HasColumnType("numeric");
            builder.Property(x => x.recdescto).HasColumnType("numeric");
            builder.Property(x => x.recEST).HasColumnType("bit");
        }
    }
}