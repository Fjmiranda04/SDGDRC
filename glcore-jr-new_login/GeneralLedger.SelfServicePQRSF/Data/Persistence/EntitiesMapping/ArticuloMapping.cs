using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class ArticuloMapping : IEntityTypeConfiguration<Articulo>
    {
        public void Configure(EntityTypeBuilder<Articulo> builder)
        {
            builder.HasNoKey();
            builder.Property(a => a.arcod).HasColumnType("VARCHAR");
            builder.Property(a => a.ARESPE).HasColumnType("VARCHAR");
            builder.Property(a => a.ArCosto).HasColumnType("numeric");
            builder.Property(a => a.ARREF).HasColumnType("VARCHAR");
            builder.Property(a => a.ArIva).HasColumnType("numeric");
            builder.Property(a => a.Existencia).HasColumnType("numeric");
            builder.Property(a => a.ARMED).HasColumnType("VARCHAR");
            builder.Property(a => a.remplazo).HasColumnType("VARCHAR");
            builder.Property(a => a.artipoar).HasColumnType("int");
            builder.Property(a => a.PrecioMinimo).HasColumnType("numeric");
            builder.Property(a => a.armar).HasColumnType("VARCHAR");
            builder.Property(a => a.Minimo).HasColumnType("int");
            builder.Property(a => a.Arlote).HasColumnType("int");
            builder.Property(a => a.arDosificacion).HasColumnType("numeric");
            builder.Property(a => a.CtaInventario).HasColumnType("VARCHAR");
            builder.Property(a => a.ArEspecificacion).HasColumnType("VARCHAR");
            builder.Property(a => a.CtaCosto).HasColumnType("VARCHAR");
            builder.Property(a => a.CtaIngreso).HasColumnType("VARCHAR");
            builder.Property(a => a.arventa).HasColumnType("numeric");
            builder.Property(a => a.ArDisco).HasColumnType("numeric");
            builder.Property(a => a.ArEven).HasColumnType("numeric");
            builder.Property(a => a.ArPrecio).HasColumnType("numeric");
            builder.Property(a => a.ArModalidad).HasColumnType("int");
            builder.Property(a => a.Maximo).HasColumnType("int");
            builder.Property(a => a.ARSECTOR).HasColumnType("VARCHAR");
            builder.Property(a => a.ARMINIMO).HasColumnType("numeric");
            builder.Property(a => a.PRECIO).HasColumnType("numeric");
            builder.Property(a => a.arporpre1).HasColumnType("numeric");
            builder.Property(a => a.arporpre2).HasColumnType("numeric");
            builder.Property(a => a.arporpre3).HasColumnType("numeric");
            builder.Property(a => a.arporpre4).HasColumnType("numeric");
            builder.Property(a => a.arporpremin).HasColumnType("numeric");
        }
    }
}