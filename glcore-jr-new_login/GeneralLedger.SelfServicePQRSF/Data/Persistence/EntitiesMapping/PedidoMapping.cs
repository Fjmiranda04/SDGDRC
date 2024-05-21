using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasNoKey();
            builder.Property(a => a.Consecutivo).HasColumnType("VARCHAR");
            builder.Property(a => a.codCliente).HasColumnType("VARCHAR");
            builder.Property(a => a.idSucursal).HasColumnType("int");
            builder.Property(a => a.direccion).HasColumnType("VARCHAR");
            builder.Property(a => a.fecha).HasColumnType("date");
            builder.Property(a => a.codDependencia).HasColumnType("VARCHAR");
            builder.Property(a => a.codVendedor).HasColumnType("VARCHAR");
            builder.Property(a => a.codEscala).HasColumnType("VARCHAR");
            builder.Property(a => a.subtotal).HasColumnType("numeric");
            builder.Property(a => a.descuento).HasColumnType("int");
            builder.Property(a => a.flete).HasColumnType("int");
            builder.Property(a => a.impuesto).HasColumnType("numeric");
            builder.Property(a => a.total).HasColumnType("numeric");
            builder.Property(a => a.usuario).HasColumnType("VARCHAR");
            builder.Property(a => a.redondeo).HasColumnType("int");
            builder.Property(a => a.detalle).HasColumnType("VARCHAR");
            builder.Property(a => a.cadena).HasColumnType("VARCHAR");
            builder.Property(a => a.formapago).HasColumnType("VARCHAR");
            builder.Property(a => a.ivaFlete).HasColumnType("int");
            builder.Property(a => a.ivaincluido).HasColumnType("int");
            builder.Property(a => a.ivaPorcFlete).HasColumnType("int");
            builder.Property(a => a.fechaReq).HasColumnType("date");
            builder.Property(a => a.solicitante).HasColumnType("VARCHAR");
            builder.Property(a => a.NroCotizacion).HasColumnType("VARCHAR");
        }
    }
}