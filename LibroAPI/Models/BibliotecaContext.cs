using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LibroAPI.Models
{
    public partial class BibliotecaContext : DbContext
    {
        public BibliotecaContext()
        {
        }

        public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autors { get; set; }
        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }
        public virtual DbSet<Prestamo> Prestamos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Biblioteca;User Id=bm;Password=1234567");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Autor>(entity =>
            {
                entity.ToTable("Autor");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.NumeroEstudiante)
                    .HasName("PK__Estudian__0D90AB22C34A3A2A");

                entity.ToTable("Estudiante");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.Idusuario)
                    .HasConstraintName("FK__Estudiant__IDUsu__4316F928");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.Isbn)
                    .HasName("PK__Libro__447D36EB8DE94BF0");

                entity.ToTable("Libro");

                entity.Property(e => e.Isbn).HasColumnName("ISBN");

                entity.Property(e => e.FechaLanzamiento).HasColumnType("date");

                entity.Property(e => e.Idautor).HasColumnName("IDAutor");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdautorNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.Idautor)
                    .HasConstraintName("FK_Libro_Autor");
            });

            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.HasKey(e => new { e.Isbn, e.NumeroEstudiante });

                entity.ToTable("Prestamo");

                entity.Property(e => e.Isbn).HasColumnName("ISBN");

                entity.Property(e => e.FechaFin).HasColumnType("date");

                entity.Property(e => e.FechaInicio).HasColumnType("date");

                entity.HasOne(d => d.IsbnNavigation)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.Isbn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Prestamo__ISBN__412EB0B6");

                entity.HasOne(d => d.NumeroEstudianteNavigation)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.NumeroEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Prestamo__Numero__4222D4EF");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Pass)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
