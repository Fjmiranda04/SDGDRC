using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMappingGL
{
    public class AccglUsuarioMapping : IEntityTypeConfiguration<AccglUsuario>
    {
        public void Configure(EntityTypeBuilder<AccglUsuario> builder)
        {
            builder.HasNoKey();

            builder.ToTable("accglUsuarios");

            builder.HasIndex(e => e.Codigo, "IX_accglUsuarios")
                .IsUnique();

            builder.HasIndex(e => e.Nombre, "IX_accglUsuarios_1")
                .IsUnique();

            builder.Property(e => e.Area)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cajero).HasColumnType("numeric(18, 0)");

            builder.Property(e => e.CodEmpleado)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.ConfigTprov).HasColumnName("ConfigTProv");

            builder.Property(e => e.CooCosto)
                .IsRequired()
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("cooCosto")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Delmrk)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("delmrk")
                .HasDefaultValueSql("('1')");

            builder.Property(e => e.Id)
                .HasColumnType("numeric(18, 0)")
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            builder.Property(e => e.Monto)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("monto");

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Tipo)
                .IsRequired()
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.UsarApp).HasColumnName("UsarAPP");

            builder.Property(e => e.UserDep)
                .IsRequired()
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Usuario)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
        }
    }
}