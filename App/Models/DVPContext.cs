using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace App_DVP.Models
{
    public partial class DVPContext : DbContext
    {
        public DVPContext()
        {
        }

        public DVPContext(DbContextOptions<DVPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EntidadPersona> EntidadPersonas { get; set; } = null!;
        public virtual DbSet<EntidadUsuario> EntidadUsuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local)\\SQLEXPRESS; DataBase=DVP; Trusted_Connection=True; TrustServerCertificate=True;");
            }*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntidadPersona>(entity =>
            {
                entity.HasKey(e => e.Identificador)
                    .HasName("PK__EntidadP__F2374EB19545C644");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdentificacíonCompleta)
                    .HasMaxLength(41)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(concat([TipoIdentificacion],'-',[NumeroIdentificacion]))", false);

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(101)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(concat([Nombres],' ',[Apellidos]))", false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroIdentificacion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipoIdentificacion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NuevaContrasena)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EntidadUsuario>(entity =>
            {
                entity.HasKey(e => e.Identificador)
                    .HasName("PK__EntidadU__F2374EB11DCCF629");

                entity.ToTable("EntidadUsuario");

                entity.HasIndex(e => e.Usuario, "UQ__EntidadU__E3237CF711C2D36C")
                    .IsUnique();

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Pass)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
