using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class AnalisisVencimientoMapping : IEntityTypeConfiguration<AnalisisVencimiento>
    {
        public void Configure(EntityTypeBuilder<AnalisisVencimiento> builder)
        {
            builder.HasNoKey();
            builder.Property(x => x.Cliente).HasColumnType("VARCHAR");
            builder.Property(x => x.Calificacion).HasColumnType("VARCHAR");
            builder.Property(x => x.Tipo).HasColumnType("VARCHAR");
            builder.Property(x => x.Documento).HasColumnType("VARCHAR");
            builder.Property(x => x.Fecha).HasColumnType("date");
            builder.Property(x => x.Vence).HasColumnType("date");
            builder.Property(x => x.DiasVen).HasColumnType("int");
            builder.Property(x => x.Valor).HasColumnType("numeric");
            builder.Property(x => x.PagoConf).HasColumnType("VARCHAR");
            builder.Property(x => x.NoVen).HasColumnType("numeric");
            builder.Property(x => x.ValorIva).HasColumnType("numeric");
            builder.Property(x => x.Vendedor).HasColumnType("VARCHAR");
            builder.Property(x => x.Zona).HasColumnType("VARCHAR");
            builder.Property(x => x.Nit).HasColumnType("VARCHAR");
            builder.Property(x => x.DireccionCliente).HasColumnType("VARCHAR");
            builder.Property(x => x.TelCliente).HasColumnType("VARCHAR");
            builder.Property(x => x.DiasFac).HasColumnType("int");
            builder.Property(x => x.SubTotal).HasColumnType("numeric");
            builder.Property(x => x.Saldo).HasColumnType("numeric");
            builder.Property(x => x.TCambio).HasColumnType("numeric");
            builder.Property(x => x.TipoCli).HasColumnType("VARCHAR");
            builder.Property(x => x.Bandera).HasColumnType("VARCHAR");
            builder.Property(x => x.CodCli).HasColumnType("VARCHAR");
            builder.Property(x => x.EstadoFactura).HasColumnType("VARCHAR");
            builder.Property(x => x.Pais).HasColumnType("VARCHAR");
            builder.Property(x => x.Ciudad).HasColumnType("VARCHAR");
            builder.Property(x => x.NomTitular).HasColumnType("VARCHAR");
            builder.Property(x => x.TipoMoneda).HasColumnType("VARCHAR");
        }
    }
}