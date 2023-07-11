using IRRegistroEstudiantes.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace IRRegistroEstudiantes.Model.Context;

public partial class IRRegistroEstudiantesContext : DbContext
{
    public IRRegistroEstudiantesContext()
    {
    }

    public IRRegistroEstudiantesContext(DbContextOptions<IRRegistroEstudiantesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<EstudianteMaterias> EstudianteMateria { get; set; }

    public virtual DbSet<Materia> Materia { get; set; }

    public virtual DbSet<Profesor> Profesores { get; set; }

    public virtual DbSet<ProfesorMaterias> ProfesorMateria { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.ToTable("Estudiante");

            entity.HasIndex(e => e.IdUsuario, "IX_Estudiante").IsUnique();

            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Carrera)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.Estudiante)
                .HasForeignKey<Estudiante>(d => d.IdUsuario)
                .HasConstraintName("FK_Estudiante_Usuario");
        });

        modelBuilder.Entity<EstudianteMaterias>(entity =>
        {
            entity.ToTable("Estudiante_Materia");

            entity.HasIndex(e => new { e.IdEstudiante, e.IdProfesorMateria }, "IX_Estudiante_Materia").IsUnique();

            entity.Property(e => e.IdEstudiante).HasColumnName("Id_Estudiante");
            entity.Property(e => e.IdProfesorMateria).HasColumnName("Id_Profesor_Materia");

            entity.HasOne(d => d.IdEstudianteNavigation).WithMany(p => p.EstudianteMateria)
                .HasForeignKey(d => d.IdEstudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Estudiante_Materia_Estudiante");

            entity.HasOne(d => d.IdProfesorMateriaNavigation).WithMany(p => p.EstudianteMateria)
                .HasForeignKey(d => d.IdProfesorMateria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Estudiante_Materia_Profesor_Materia");
        });

        modelBuilder.Entity<Materia>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Profesor>(entity =>
        {
            entity.ToTable("Profesor");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProfesorMaterias>(entity =>
        {
            entity.ToTable("Profesor_Materia");

            entity.Property(e => e.IdMateria).HasColumnName("Id_Materia");
            entity.Property(e => e.IdProfesor).HasColumnName("Id_Profesor");

            entity.HasOne(d => d.IdMateriaNavigation).WithMany(p => p.ProfesorMateria)
                .HasForeignKey(d => d.IdMateria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Profesor_Materia_Materia");

            entity.HasOne(d => d.IdProfesorNavigation).WithMany(p => p.ProfesorMateria)
                .HasForeignKey(d => d.IdProfesor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Profesor_Materia_Profesor");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("Usuario");

            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
