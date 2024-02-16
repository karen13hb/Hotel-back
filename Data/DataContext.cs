using HotelClubApi.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HotelClubApi.Data
{
    public class DataContext: DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<TipoHabitacion> TipoHabitaciones { get; set; }
        public DbSet<Reservacion> Reservaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoHabitacion>().ToTable("tipo_Habitacion");
            modelBuilder.Entity<Reservacion>().ToTable("reservaciones");
        }

    }
}
