using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMappingGL
{
    public class OrdenMapping : IEntityTypeConfiguration<Orden>
    {
        public void Configure(EntityTypeBuilder<Orden> builder)
        {
            builder.HasKey(e => new { e.Ordnro, e.OrdTipOrden })
                    .HasName("PK_ORDENES")
                    .IsClustered(false);

            builder.ToTable("ordenes");

            builder.Property(e => e.Ordnro)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("ordnro")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdTipOrden)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.AcumActualHrs).HasColumnType("numeric(18, 2)");

            builder.Property(e => e.AcumActualKms).HasColumnType("numeric(18, 2)");

            builder.Property(e => e.Autorizacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Carga)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("carga")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Cif)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("CIF");

            builder.Property(e => e.Codconcepto)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("codconcepto")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codigo")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CodigoMtto)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("codigoMtto")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.DateLastUpd)
                .HasColumnType("datetime")
                .HasDefaultValueSql("('19000101')");

            builder.Property(e => e.Delmrk)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("delmrk")
                .HasDefaultValueSql("(1)");

            builder.Property(e => e.DiagPreliminar)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.DiagTecnico)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.FechaAutorizacion)
                .HasColumnType("datetime")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.FechaCierre)
                .HasColumnType("datetime")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.FechaDef)
                .HasColumnType("datetime")
                .HasColumnName("fecha_def")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.FechaFact)
                .HasColumnType("datetime")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.FechaOp)
                .HasColumnType("datetime")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Flete)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("flete");

            builder.Property(e => e.Fob)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("fob");

            builder.Property(e => e.Idmtto).HasColumnName("idmtto");

            builder.Property(e => e.Nmanten)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("NManten")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.NroFact)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdAgente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ordAgente")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdBar)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdCco)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("OrdCCO")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdClase)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ordClase")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdComp)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ordComp")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdCon)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ordCon")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdDesc)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("ordDesc")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdDescripcion)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdDir)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdFac).HasColumnName("ordFac");

            builder.Property(e => e.OrdFec)
                .HasColumnType("datetime")
                .HasColumnName("ordFec")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdFecLiq)
                .HasColumnType("datetime")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdFuente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdGoC)
                .HasColumnName("ordGoC")
                .HasDefaultValueSql("(1)");

            builder.Property(e => e.OrdGrua)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ordGrua")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdHora)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ordHora")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdHoraEspera)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdHoraF)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ordHoraF")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdHoraLlegada)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdHoraSal)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ordHoraSal")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdHoraSalida)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdInf)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ordInf")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdKm)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdMarca)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ordMarca")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdMed)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdModelo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ordModelo")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdNivelGas)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdOrigen)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ordOrigen")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdPaciente)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ordPaciente")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdPlaca)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ordPlaca")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdPoli)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdProp)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("ordProp")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdReg)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdSal)
                .HasColumnType("datetime")
                .HasColumnName("ordSal")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdSec)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdSolucion)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdTcli)
                .HasColumnName("ordTCli")
                .HasDefaultValueSql("(1)");

            builder.Property(e => e.OrdTipificador)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdTipificador2)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdTipo)
                .HasColumnName("ordTipo")
                .HasDefaultValueSql("(1)");

            builder.Property(e => e.OrdTipoO)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ordTipoO")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdTipoPago).HasColumnName("ordTipoPago");

            builder.Property(e => e.OrdUser)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ordUser")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdVendedor)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Ordcli)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ordcli")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.OrdenPago)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Ordescala)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ordescala")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Ordest)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ordest")
                .HasDefaultValueSql("((0))");

            builder.Property(e => e.Ordliq)
                .HasColumnType("datetime")
                .HasColumnName("ordliq")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Ordnom)
                .HasMaxLength(600)
                .IsUnicode(false)
                .HasColumnName("ordnom")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Ordserial)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ordserial")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Otrosgastos)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("otrosgastos");

            builder.Property(e => e.PcDef)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PC_def")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Pesoneto)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("pesoneto");

            builder.Property(e => e.Seguro)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("seguro");

            builder.Property(e => e.SolucionAplicada)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Subpartidas)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("subpartidas");

            builder.Property(e => e.Tc)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("TC");

            builder.Property(e => e.TipDocCierre)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("tipDocCierre")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.TipOrden)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.TipoMtto)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('P')");

            builder.Property(e => e.UserDef)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("User_Def")
                .HasDefaultValueSql("('')");

            builder.Property(e => e.ValorFact).HasColumnType("numeric(18, 2)");

            builder.Property(e => e.VerHojaVida).HasColumnName("verHojaVida");
        }
    }
}