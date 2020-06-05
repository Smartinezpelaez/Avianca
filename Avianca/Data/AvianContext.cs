using Avianca.Models;
using Microsoft.EntityFrameworkCore;

namespace Avianca.Data
{
    public class AvianContext : DbContext
    {
        public AvianContext(DbContextOptions<AvianContext>options) :base(options)
        {
        }
       
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Vuelos> Vuelos { get; set; }
        public DbSet<ControlDespegue> ControlDespegue { get; set; }
        public DbSet<ControlAterrizaje> ControlAterrizaje { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Reserva>().ToTable("Reserva");
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Vuelos>().ToTable("Vuelos");
            modelBuilder.Entity<ControlDespegue>().ToTable("ControlDespegue");
            modelBuilder.Entity<ControlAterrizaje>().ToTable("ControlAterrizaje");

        }

        


       



    }

}


