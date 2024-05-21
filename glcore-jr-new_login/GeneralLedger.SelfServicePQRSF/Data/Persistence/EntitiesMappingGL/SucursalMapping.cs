using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMappingGL
{
    public class SucursalMapping : IEntityTypeConfiguration<Sucursal>
    {
        public void Configure(EntityTypeBuilder<Sucursal> builder)
        {
            builder.HasNoKey();

            builder.Property(e => e.Barrio)
                .IsRequired()
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Ciudad)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ciudad")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CodPostal)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Codcli)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("codcli")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Contacto)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("contacto")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Delmrk)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("delmrk")
                .HasDefaultValueSql("('1')");

            builder.Property(e => e.Direccion)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("direccion")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.IdSucursal)
                .HasColumnType("numeric(18, 0)")
                .ValueGeneratedOnAdd()
                .HasColumnName("id_Sucursal");

            builder.Property(e => e.Pais)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pais")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Telefono)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telefono")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Zona)
                .IsRequired()
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("zona")
                .HasDefaultValueSql("('')");
        }
    }
}