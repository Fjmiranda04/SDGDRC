using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMappingGL
{
    public class ViewSubCentroCostoMapping : IEntityTypeConfiguration<ViewSubCentroCosto>
    {
        public void Configure(EntityTypeBuilder<ViewSubCentroCosto> builder)
        {
            builder.HasNoKey();

            builder.ToView("View_SubCentro_Costo");

            builder.Property(e => e.CodigoCentro)
                .IsRequired()
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Codigo_Centro");

            builder.Property(e => e.CodigoSub)
                .IsRequired()
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Codigo_Sub");

            builder.Property(e => e.Delmrk)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("delmrk");

            builder.Property(e => e.NombreCentro)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_Centro");

            builder.Property(e => e.NombreSub)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_Sub");
        }
    }
}