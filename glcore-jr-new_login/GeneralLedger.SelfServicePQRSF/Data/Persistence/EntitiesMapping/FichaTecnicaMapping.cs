using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class FichaTecnicaMapping : IEntityTypeConfiguration<FichaTecnica>
    {
        public void Configure(EntityTypeBuilder<FichaTecnica> builder)
        {
            builder.HasNoKey();
            builder.Property(x => x.nFactura).HasColumnType("VARCHAR");
            builder.Property(x => x.Fecha).HasColumnType("date");
            builder.Property(x => x.FechaVenci).HasColumnType("date");
            builder.Property(x => x.abono).HasColumnType("numeric");
            builder.Property(x => x.detalle).HasColumnType("VARCHAR");
            builder.Property(x => x.Tipo).HasColumnType("VARCHAR");
            builder.Property(x => x.Tipdoc).HasColumnType("VARCHAR");
            builder.Property(x => x.cliente).HasColumnType("VARCHAR");
            builder.Property(x => x.subIva).HasColumnType("numeric");
            builder.Property(x => x.Iva).HasColumnType("numeric");
            builder.Property(x => x.vDesc).HasColumnType("numeric");
            builder.Property(x => x.vrCredito).HasColumnType("int");
            builder.Property(x => x.total).HasColumnType("numeric");
            builder.Property(x => x.nDevoluciones).HasColumnType("numeric");
            builder.Property(x => x.nIvaDev).HasColumnType("numeric");
            builder.Property(x => x.saldo).HasColumnType("numeric");
            builder.Property(x => x.Cajero).HasColumnType("VARCHAR");
            builder.Property(x => x.Vendedor).HasColumnType("VARCHAR");
            builder.Property(x => x.Zona).HasColumnType("VARCHAR");
            builder.Property(x => x.ciudad).HasColumnType("VARCHAR");
            builder.Property(x => x.estado).HasColumnType("VARCHAR");
            builder.Property(x => x.llave).HasColumnType("VARCHAR");
            builder.Property(x => x.Estacion).HasColumnType("VARCHAR");
            builder.Property(x => x.Usuario).HasColumnType("VARCHAR");
            builder.Property(x => x.TCambio).HasColumnType("numeric");
            builder.Property(x => x.TMoneda).HasColumnType("VARCHAR");
        }
    }
}