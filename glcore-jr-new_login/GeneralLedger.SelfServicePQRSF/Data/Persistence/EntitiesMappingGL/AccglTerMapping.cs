using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMappingGL
{
    public class AccglTerMapping : IEntityTypeConfiguration<AccglTer>
    {
        public void Configure(EntityTypeBuilder<AccglTer> builder)
        {
            builder.HasKey(e => e.Tercod);

            builder.ToTable("accglTer");

            builder.HasIndex(e => e.Ternit, "IX_accglTer_1")
                .IsUnique();

            builder.Property(e => e.Tercod)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tercod")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.AutoEmail).HasColumnName("autoEmail");

            builder.Property(e => e.Delmrk)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("delmrk")
                .HasDefaultValueSql("(1)");

            builder.Property(e => e.DigVer)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("digVer")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.InsDateTime)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.ModifiedByUser)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.ProTipoTer)
                .IsRequired()
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("proTipoTer")
                .HasDefaultValueSql("((1))");

            builder.Property(e => e.Salario)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("salario");

            builder.Property(e => e.TerBan)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("terBan")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.TerCiu)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.TerCodCiu)
                .IsRequired()
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("terCodCiu")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.TerCodCiuBanco)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.TerCta)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("terCta")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.TerCuentaCredito)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.TerCuentaDebito)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.TerEstacion)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("(host_name())");

            builder.Property(e => e.TerFax)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("terFax")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.TerIdentidad)
                .HasColumnType("numeric(18, 0)")
                .ValueGeneratedOnAdd()
                .HasColumnName("Ter_Identidad");

            builder.Property(e => e.TerPais)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("terPais")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.TerPersona).HasColumnName("terPersona");

            builder.Property(e => e.TerPriApe)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.TerPriNom)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.TerRegi).HasDefaultValueSql("((1))");

            builder.Property(e => e.TerSegApe)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.TerSegNom)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.TerTip)
                .IsRequired()
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.TerUsuario)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Tercargocontacto)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tercargocontacto")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Tercedreplegal)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tercedreplegal")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Tercel)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tercel")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Tercontacto)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tercontacto")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Terdir)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("terdir")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Termail)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("termail")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Ternit)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ternit")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Ternom)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ternom")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Terreplegal)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("terreplegal")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Tertel)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tertel")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Terzona)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("terzona")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.TipDoc)
                .IsRequired()
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("tipDoc")
                .HasDefaultValueSql("('')");
        }
    }
}