using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMappingGL
{
    public class AccglProMapping : IEntityTypeConfiguration<AccglPro>
    {
        public void Configure(EntityTypeBuilder<AccglPro> builder)
        {
            builder.HasKey(e => e.Pronit);

            builder.ToTable("accglPro");

            builder.HasIndex(e => new { e.Pronom, e.Pronit }, "IX_accglPro")
                .IsUnique();

            builder.HasIndex(e => e.Procod, "IX_accglPro_1");

            builder.HasIndex(e => e.Pronit1, "IX_accglPro_2")
                .IsUnique();

            builder.Property(e => e.Pronit)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("pronit")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Activc).HasColumnName("activc");

            builder.Property(e => e.Bienser).HasColumnName("bienser");

            builder.Property(e => e.Certie).HasColumnName("certie");

            builder.Property(e => e.ContCalificacion)
                .IsRequired()
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Delmrk)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("delmrk")
                .HasDefaultValueSql("('1')");

            builder.Property(e => e.DigVer)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("digVer")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Fechav)
                .HasColumnType("datetime")
                .HasColumnName("fechav")
                .HasDefaultValueSql("('19000101')");

            builder.Property(e => e.Garanp).HasColumnName("garanp");

            builder.Property(e => e.InsDateTime)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.InscrR)
                .HasColumnType("datetime")
                .HasDefaultValueSql("('19000101')");

            builder.Property(e => e.ModifiedByUser)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Nummatri)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.ProCal)
                .IsRequired()
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("proCal")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.ProCla)
                .HasColumnName("proCla")
                .HasDefaultValueSql("(1)");

            builder.Property(e => e.ProCodCiud)
                .IsRequired()
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("proCodCiud")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.ProCredaDias).HasColumnName("proCredaDias");

            builder.Property(e => e.ProEstacion)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("(host_name())");

            builder.Property(e => e.ProFechaServer)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.ProOblFac).HasColumnName("proOblFac");

            builder.Property(e => e.ProObser)
                .IsRequired()
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("proObser")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.ProPais)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("proPais")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.ProPersona).HasColumnName("proPersona");

            builder.Property(e => e.ProPriApe)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("proPriApe")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.ProPriNom)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("proPriNom")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.ProSegApe)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("proSegApe")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.ProSegNom)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("proSegNom")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.ProTarjeta)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("proTarjeta")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.ProTipoProvee)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("proTipoProvee")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.ProTipoTer)
                .IsRequired()
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("proTipoTer")
                .HasDefaultValueSql("((1))");

            builder.Property(e => e.ProUsuario)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Proaa)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("proaa")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Proactividad)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("proactividad")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Proase).HasColumnName("proase");

            builder.Property(e => e.Proasesores)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("proasesores")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Proauto)
                .HasColumnType("numeric(1, 0)")
                .HasColumnName("proauto");

            builder.Property(e => e.Proautoica)
                .HasColumnType("numeric(1, 0)")
                .HasColumnName("proautoica");

            builder.Property(e => e.Proban)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("proban")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Procargo)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("procargo")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Proced)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("proced")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Procel)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("procel")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Procer).HasColumnName("procer");

            builder.Property(e => e.Prociud)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("prociud")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Prociudades)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("prociudades")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Procod)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("procod")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.ProcodActividad)
                .IsRequired()
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("procodActividad")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Procondiciones)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("procondiciones")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Proconta)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("proconta")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Proconta2)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("proconta2")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Procual)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("procual")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Procuen)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("procuen")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Prodeclarar).HasColumnName("prodeclarar");

            builder.Property(e => e.Prodir)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("prodir")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Proent)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("proent")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Proesta).HasColumnName("proesta");

            builder.Property(e => e.Proestado)
                .HasColumnName("proestado")
                .HasDefaultValueSql("((2))");

            builder.Property(e => e.Profax)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("profax")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Profecres)
                .HasColumnType("datetime")
                .HasColumnName("profecres")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Profecres2)
                .HasColumnType("datetime")
                .HasColumnName("profecres2")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Proflex).HasColumnName("proflex");

            builder.Property(e => e.Progran)
                .HasColumnType("numeric(1, 0)")
                .HasColumnName("progran");

            builder.Property(e => e.Proica)
                .HasColumnType("numeric(1, 0)")
                .HasColumnName("proica");

            builder.Property(e => e.Proiva)
                .HasColumnType("numeric(1, 0)")
                .HasColumnName("proiva");

            builder.Property(e => e.Promail)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("promail")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Pronit1)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("PRONIT1")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Pronit2)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pronit2")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Pronoactividad)
                .HasColumnType("numeric(5, 0)")
                .HasColumnName("pronoactividad");

            builder.Property(e => e.Pronom)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pronom")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Pronom2)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pronom2")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Proporica)
                .HasColumnType("numeric(18, 3)")
                .HasColumnName("proporica");

            builder.Property(e => e.Propres).HasColumnName("propres");

            builder.Property(e => e.Proproc).HasColumnName("proproc");

            builder.Property(e => e.Proregi)
                .HasColumnType("numeric(1, 0)")
                .HasColumnName("proregi");

            builder.Property(e => e.Proreplegal)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("proreplegal")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Prores)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("prores")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Prores2)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("prores2")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Prosis).HasColumnName("prosis");

            builder.Property(e => e.Protel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("protel")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Protel2)
                .IsRequired()
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("protel2")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Protipcuen)
                .HasColumnName("protipcuen")
                .HasDefaultValueSql("(1)");

            builder.Property(e => e.Proweb)
                .IsRequired()
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("proweb")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Retefuen)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Reteica)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Reteiva)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Rfinal).HasColumnType("numeric(18, 0)");

            builder.Property(e => e.Rinicial).HasColumnType("numeric(18, 0)");

            builder.Property(e => e.Rup).HasColumnName("RUp");

            builder.Property(e => e.Rut)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("RUt")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.TimeEnv).HasColumnName("timeEnv");

            builder.Property(e => e.TipDocu)
                .IsRequired()
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("tipDocu")
                .HasDefaultValueSql("('')");
        }
    }
}