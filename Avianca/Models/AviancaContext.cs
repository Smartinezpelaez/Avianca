using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Avianca.Models
{
    /*public partial class AviancaContext : DbContext
    {
        public AviancaContext()
        {
        }

        public AviancaContext(DbContextOptions<AviancaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<Vuelos> Vuelos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-L2IS8NH\\SQLEXPRESS;Database=Avianca;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Documento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tipodocumento)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Clase)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Destino)
                    .HasColumnName("destino")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaReserva).HasColumnType("datetime");

                entity.Property(e => e.FechaSalida).HasColumnType("datetime");

                entity.Property(e => e.HoraVuelo).HasColumnType("datetime");

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Origen)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vuelos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Clase)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Destino)
                    .HasColumnName("destino")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaReserva).HasColumnType("datetime");

                entity.Property(e => e.FechaSalida).HasColumnType("datetime");

                entity.Property(e => e.HoraVuelo).HasColumnType("datetime");

                entity.Property(e => e.Origen)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }*/
}
