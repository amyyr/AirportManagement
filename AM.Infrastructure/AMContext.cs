using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
    public class AMContext :DbContext
    {
        DbSet<Plane> Planes { get; set; }
        DbSet<Flight> Flights { get; set; }
        DbSet<Passenger> Passengers { get; set; }
        DbSet<Staff> Staff { get; set; }
        DbSet<Traveller> Travellers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
              Initial Catalog=AirportManagementDB;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new PassangerConfiguration());
            //modelBuilder.ApplyConfiguration(new());
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder config)
        {
            config.Properties<DateTime>().HaveColumnType("datetime2");
        }
    }
}
