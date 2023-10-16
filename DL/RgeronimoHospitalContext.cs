using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class RgeronimoHospitalContext : DbContext
{
    public RgeronimoHospitalContext()
    {
    }

    public RgeronimoHospitalContext(DbContextOptions<RgeronimoHospitalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<TipoSangre> TipoSangres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database=RGeronimoHospital; TrustServerCertificate=True; Trusted_Connection=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("PK__Paciente__C93DB49B4282623B");

            entity.ToTable("Paciente");

            entity.Property(e => e.Am)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AM");
            entity.Property(e => e.Ap)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AP");
            entity.Property(e => e.FechaIngreso).HasColumnType("datetime");
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sexo)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Sintomas)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTipoSangreNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdTipoSangre)
                .HasConstraintName("FK__Paciente__IdTipo__398D8EEE");
        });

        modelBuilder.Entity<TipoSangre>(entity =>
        {
            entity.HasKey(e => e.IdTipoSangre).HasName("PK__TipoSang__3FA617D994A16A87");

            entity.ToTable("TipoSangre");

            entity.Property(e => e.IdTipoSangre).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
