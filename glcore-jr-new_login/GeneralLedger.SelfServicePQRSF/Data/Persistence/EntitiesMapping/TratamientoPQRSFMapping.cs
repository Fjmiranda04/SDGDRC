using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class TratamientoPQRSFMapping : IEntityTypeConfiguration<TratamientoPQRSF>
    {
        public void Configure(EntityTypeBuilder<TratamientoPQRSF> builder)
        {
            builder.ToTable("WEBGLSS_TratamientosPQRSF");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.IdPQRSF).IsRequired(true);
            builder.Property(c => c.NroIdResponsable).HasMaxLength(20).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(c => c.Actividad).HasMaxLength(200).HasColumnType("VARCHAR").IsRequired();
            builder.Property(c => c.FechaCumplimiento).HasColumnType("date").IsRequired(true);
            builder.Property(c => c.Observaciones).HasColumnType("text");
            builder.Property(c => c.Checked).HasDefaultValue(false);
            builder.Property(c => c.FechaCheck).HasColumnType("date").HasDefaultValueSql("getdate()");
            builder.Property(c => c.NitEmpresa).HasMaxLength(20).HasColumnType("VARCHAR").IsRequired(true);
            builder.Property(c => c.EnvioCorreo).HasDefaultValue(true);
        }
    }
}