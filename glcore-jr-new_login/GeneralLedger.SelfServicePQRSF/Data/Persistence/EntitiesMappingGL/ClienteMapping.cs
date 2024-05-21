using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMappingGL
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(e => e.Clicod);

            builder.ToTable("clientes");

            builder.HasIndex(e => e.Cliciud, "IX_Clientes_2");

            builder.HasIndex(e => new { e.Delmrk, e.CliPotencial }, "IX_Clientes_Estado");

            builder.HasIndex(e => e.Clinit, "IX_clientes")
                .IsUnique();

            builder.HasIndex(e => e.Clinom, "IX_clientes_1")
                .IsUnique();

            builder.Property(e => e.Clicod)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("clicod")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Actcli)
                .HasColumnName("actcli")
                .HasDefaultValueSql("(1)");

            builder.Property(e => e.AsignaPuntos).HasColumnName("asigna_puntos");

            builder.Property(e => e.Calificacion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CliCodActividad)
                .IsRequired()
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CliCodCiud)
                .IsRequired()
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("cliCodCiud")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CliCodPostal)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cliCodPostal")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CliCondiciones)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("cliCondiciones")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CliCredaDias).HasColumnName("cliCredaDias");

            builder.Property(e => e.CliCuenControl).HasColumnName("cliCuenControl");

            builder.Property(e => e.CliCupo)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("cliCupo");

            builder.Property(e => e.CliCxC)
                .HasColumnType("numeric(12, 0)")
                .HasColumnName("cliCxC");

            builder.Property(e => e.CliEmailRep)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cliEmailRep")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CliEnt)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cliEnt")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CliEps)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CliEstacion)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("(host_name())");

            builder.Property(e => e.CliFormulaDirecta).HasDefaultValueSql("((1))");

            builder.Property(e => e.CliManCod2)
                .IsRequired()
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CliMatriMercantil)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cliMatriMercantil")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CliNcomercial)
                .IsRequired()
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("cliNcomercial")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CliObser)
                .IsRequired()
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("cliObser")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CliPais)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cliPais")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CliPersona).HasColumnName("cliPersona");

            builder.Property(e => e.CliPorcentajeLiq).HasColumnType("numeric(18, 3)");

            builder.Property(e => e.CliPotencial).HasDefaultValueSql("((2))");

            builder.Property(e => e.CliPriApe)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cliPriApe")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CliPriNom)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cliPriNom")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CliSegApe)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("cliSegApe")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CliSegNom)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("cliSegNom")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CliSis).HasColumnName("cliSIS");

            builder.Property(e => e.CliTarjeta)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("cliTarjeta")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CliTelRep)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cliTelRep")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CliTipoCli)
                .IsRequired()
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CliUsuario)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CliValor).HasColumnType("numeric(18, 2)");

            builder.Property(e => e.CliVence)
                .HasColumnType("datetime")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CliVencidas).HasColumnName("cliVencidas");

            builder.Property(e => e.CliVlrExaIngH).HasColumnType("numeric(18, 2)");

            builder.Property(e => e.CliVlrExaIngM).HasColumnType("numeric(18, 2)");

            builder.Property(e => e.CliVlrExaRet).HasColumnType("numeric(18, 2)");

            builder.Property(e => e.Cliaa)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cliaa")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cliactividad)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("cliactividad")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cliauto).HasColumnName("cliauto");

            builder.Property(e => e.Cliautoica).HasColumnName("cliautoica");

            builder.Property(e => e.Cliban)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cliban")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Clicargo)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("clicargo")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cliced)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cliced")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Clicel1)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("clicel1")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Clicel2)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("clicel2")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cliciud)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cliciud")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Clicodcta)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("clicodcta")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Clicodeps)
                .IsRequired()
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("clicodeps")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cliconta)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cliconta")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Clicontac2)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("clicontac2")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Clicontac3)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("clicontac3")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Clicual)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("clicual")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Clicuen)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("clicuen")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Clicupocre)
                .HasColumnType("numeric(12, 0)")
                .HasColumnName("clicupocre");

            builder.Property(e => e.Clidcto)
                .HasColumnName("CLIDCTO")
                .HasDefaultValueSql("(1)");

            builder.Property(e => e.Clidependencia)
                .IsRequired()
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("clidependencia")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Clidesaut)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("clidesaut")
                .HasDefaultValueSql("(0)");

            builder.Property(e => e.Clidir)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("clidir")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Clidire2)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("clidire2")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cliesc)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cliesc")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Clifax)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("clifax")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cligran).HasColumnName("cligran");

            builder.Property(e => e.Cliica).HasColumnName("cliica");

            builder.Property(e => e.Climail)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("climail")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Climail2)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("climail2")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Climancod)
                .IsRequired()
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("climancod")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Clinit)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("clinit")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Clinit2)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("clinit2")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Clinoactividad)
                .IsRequired()
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("clinoactividad")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Clinom)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("clinom")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Clinom2)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("clinom2")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Clinumcontra)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("clinumcontra")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cliporica)
                .HasColumnType("numeric(3, 0)")
                .HasColumnName("cliporica");

            builder.Property(e => e.Cliproc).HasColumnName("cliproc");

            builder.Property(e => e.Clipuntos)
                .HasColumnType("numeric(11, 0)")
                .HasColumnName("clipuntos");

            builder.Property(e => e.Cliregi).HasColumnName("cliregi");

            builder.Property(e => e.Clireplegal)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("clireplegal")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cliretefte)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Clireteica)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Clireteiva)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Clitel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("clitel")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Clitelofic)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("clitelofic")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Clitipcuen).HasColumnName("clitipcuen");

            builder.Property(e => e.Cliultcompra)
                .HasColumnType("datetime")
                .HasColumnName("cliultcompra")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cliweb)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cliweb")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CodCiudCom)
                .IsRequired()
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("codCiudCom")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CodiudNac)
                .IsRequired()
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("codiudNac")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Codscco)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.ContCalificacion)
                .IsRequired()
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Convenio)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("convenio")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Delmrk)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("delmrk")
                .HasDefaultValueSql("(1)");

            builder.Property(e => e.DiasInteres).HasColumnName("dias_interes");

            builder.Property(e => e.DigVer)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("digVer")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Disponible).HasColumnType("numeric(18, 2)");

            builder.Property(e => e.Egreso)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("egreso");

            builder.Property(e => e.Entidad).HasColumnName("entidad");

            builder.Property(e => e.EstCivCli)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.EstLabCli).HasColumnName("EstLabCLi");

            builder.Property(e => e.Facturable)
                .IsRequired()
                .HasColumnName("facturable")
                .HasDefaultValueSql("((1))");

            builder.Property(e => e.FechaAniversario)
                .HasColumnType("datetime")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.FechaRetiro)
                .HasColumnType("datetime")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Fecing)
                .HasColumnType("datetime")
                .HasColumnName("fecing")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.Fnacli)
                .HasColumnType("datetime")
                .HasColumnName("fnacli")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.HabitoPago)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("habitoPago")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.IdRecord)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Id_Record");

            builder.Property(e => e.InsDateTime)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.Jailing)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.ModifiedByUser)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.MotivoRetiro)
                .IsRequired()
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.NivEstCli)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.ProTipoTer)
                .IsRequired()
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("proTipoTer")
                .HasDefaultValueSql("((1))");

            builder.Property(e => e.ResPatCli)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Salcli)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("salcli");

            builder.Property(e => e.SaveServer).HasColumnName("Save_Server");

            builder.Property(e => e.TipConCli)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.TipDoc)
                .IsRequired()
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("tipDoc")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.TipVivCli)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Vendedor)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
        }
    }
}