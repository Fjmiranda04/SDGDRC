using System;
using System.Collections.Generic;
using Capa_de_Datos.Models;
using Microsoft.EntityFrameworkCore;

namespace Capa_de_Datos.Data;

public partial class SdgdrcContext : DbContext
{
    public SdgdrcContext()
    {
    }

    public SdgdrcContext(DbContextOptions<SdgdrcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrador> Administradors { get; set; }

    public virtual DbSet<Coordinador> Coordinadors { get; set; }

    public virtual DbSet<Credenciale> Credenciales { get; set; }

    public virtual DbSet<Informe> Informes { get; set; }

    public virtual DbSet<RegistroDeResiduo> RegistroDeResiduos { get; set; }

    public virtual DbSet<Rutum> Ruta { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Voluntario> Voluntarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=HOTS_1004;Database=SDGDRC;User Id=FM_ADMIN;Password=admin12345;Integrated Security=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>(entity =>
        {
            entity.HasKey(e => e.IdAdministrador).HasName("PK__Administ__2D89616FF211FE61");

            entity.ToTable("Administrador");

            entity.Property(e => e.IdAdministrador)
                .ValueGeneratedNever()
                .HasColumnName("ID_Administrador");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Administradors)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Administr__ID_Us__412EB0B6");
        });

        modelBuilder.Entity<Coordinador>(entity =>
        {
            entity.HasKey(e => e.IdCoordinador).HasName("PK__Coordina__1161EB7125FF146B");

            entity.ToTable("Coordinador");

            entity.Property(e => e.IdCoordinador)
                .ValueGeneratedNever()
                .HasColumnName("ID_Coordinador");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.ÁreaDeResponsabilidad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Área_de_Responsabilidad");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Coordinadors)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Coordinad__ID_Us__3E52440B");
        });

        modelBuilder.Entity<Credenciale>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Credenci__DE4431C5DAD7A39A");

            entity.Property(e => e.IdUsuario)
                .ValueGeneratedNever()
                .HasColumnName("ID_Usuario");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Informe>(entity =>
        {
            entity.HasKey(e => e.IdInforme).HasName("PK__Informe__91D0EA9C409C7EF4");

            entity.ToTable("Informe");

            entity.Property(e => e.IdInforme)
                .ValueGeneratedNever()
                .HasColumnName("ID_Informe");
            entity.Property(e => e.EncargadoId).HasColumnName("Encargado_ID");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.RegistroResiduoId).HasColumnName("RegistroResiduo_ID");

            entity.HasOne(d => d.Encargado).WithMany(p => p.Informes)
                .HasForeignKey(d => d.EncargadoId)
                .HasConstraintName("FK__Informe__Encarga__4AB81AF0");

            entity.HasOne(d => d.RegistroResiduo).WithMany(p => p.Informes)
                .HasForeignKey(d => d.RegistroResiduoId)
                .HasConstraintName("FK__Informe__Registr__4BAC3F29");
        });

        modelBuilder.Entity<RegistroDeResiduo>(entity =>
        {
            entity.HasKey(e => e.IdRegistro).HasName("PK__Registro__8EC639F228B4F96E");

            entity.ToTable("Registro_de_Residuos");

            entity.Property(e => e.IdRegistro)
                .ValueGeneratedNever()
                .HasColumnName("ID_Registro");
            entity.Property(e => e.FechaHora)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Hora");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ubicación)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.VoluntarioRegistrador).HasColumnName("Voluntario_Registrador");

            entity.HasOne(d => d.VoluntarioRegistradorNavigation).WithMany(p => p.RegistroDeResiduos)
                .HasForeignKey(d => d.VoluntarioRegistrador)
                .HasConstraintName("FK__Registro___Volun__47DBAE45");
        });

        modelBuilder.Entity<Rutum>(entity =>
        {
            entity.HasKey(e => e.IdRuta).HasName("PK__Ruta__4851E68BCD77E0C7");

            entity.Property(e => e.IdRuta)
                .ValueGeneratedNever()
                .HasColumnName("ID_Ruta");
            entity.Property(e => e.CoordinadorAsociado).HasColumnName("Coordinador_Asociado");
            entity.Property(e => e.VoluntariosAsociados).HasColumnName("Voluntarios_Asociados");

            entity.HasOne(d => d.CoordinadorAsociadoNavigation).WithMany(p => p.Ruta)
                .HasForeignKey(d => d.CoordinadorAsociado)
                .HasConstraintName("FK__Ruta__Coordinado__440B1D61");

            entity.HasOne(d => d.VoluntariosAsociadosNavigation).WithMany(p => p.Ruta)
                .HasForeignKey(d => d.VoluntariosAsociados)
                .HasConstraintName("FK__Ruta__Voluntario__44FF419A");
        });
        modelBuilder.Entity<Rutum>()
        .Property(r => r.Latitud)
        .HasColumnType("decimal(10, 8)");

        modelBuilder.Entity<Rutum>()
            .Property(r => r.Longitud)
            .HasColumnType("decimal(10, 8)");

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__DE4431C52D1E4B64");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario)
                .ValueGeneratedNever()
                .HasColumnName("ID_Usuario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Voluntario>(entity =>
        {
            entity.HasKey(e => e.IdVoluntario).HasName("PK__Voluntar__C83DBA6ECCC1E17E");

            entity.ToTable("Voluntario");

            entity.Property(e => e.IdVoluntario)
                .ValueGeneratedNever()
                .HasColumnName("ID_Voluntario");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.Ubicación)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Voluntarios)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Voluntari__ID_Us__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
