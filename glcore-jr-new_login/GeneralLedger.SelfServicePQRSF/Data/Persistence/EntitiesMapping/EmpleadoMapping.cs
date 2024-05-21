using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class EmpleadoMapping : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.ToTable("WEBGLSS_Empleados");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.NroId).HasMaxLength(20).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(c => c.NombreCompleto).HasMaxLength(100).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(c => c.PrimerNombre).HasMaxLength(40).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(c => c.SegundoNombre).HasMaxLength(40).HasColumnType("VARCHAR");
            builder.Property(c => c.PrimerApellido).HasMaxLength(40).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(c => c.SegundoApellido).HasMaxLength(40).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(c => c.Ciudad).HasMaxLength(50).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(c => c.Direccion).HasMaxLength(100).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(c => c.Celular).HasMaxLength(50).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(c => c.Telefono).HasMaxLength(50).HasColumnType("VARCHAR");
            builder.Property(c => c.Email).HasMaxLength(50).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(c => c.Sexo).HasMaxLength(20).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(c => c.FechaCreacion).HasMaxLength(100).HasColumnType("date").IsRequired(true).HasDefaultValueSql("getdate()");
            builder.Property(c => c.NitEmpresa).HasMaxLength(20).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(c => c.delmrk).HasMaxLength(2).HasColumnType("VARCHAR").HasDefaultValue("1");
        }
    }
}