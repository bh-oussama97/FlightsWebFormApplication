using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Configuration; 
using webforms.Models;
using System.Configuration;

namespace webforms.DataLayer
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        // Define database tables (DbSet represents each table in the database)
        public DbSet<FlightRm> Flights { get; set; }
        public DbSet<TimePlaceRm> Timeplaces { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["mytest"].ConnectionString);

            }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use a fixed seed for consistency in tests and debugging
            Random random = new Random(42);

            // Define relationships between entities
            modelBuilder.Entity<FlightRm>()
                .HasOne(f => f.Arrival)
                .WithMany()
                .HasForeignKey(f => f.ArrivalId)
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete

            modelBuilder.Entity<FlightRm>()
                .HasOne(f => f.Departure)
                .WithMany()
                .HasForeignKey(f => f.DepartureId)
                .OnDelete(DeleteBehavior.NoAction);

            // Enable optimistic concurrency control on RemainingNumberOfSeats
            modelBuilder.Entity<FlightRm>()
                .Property(p => p.RemainingNumberOfSeats)
                .IsConcurrencyToken();

            // Seed initial data for TimePlaceRm (locations and estimated times)
            modelBuilder.Entity<TimePlaceRm>().HasData(
                new TimePlaceRm { Id = 1, Place = "Los Angeles", Time = DateTime.UtcNow.AddHours(random.Next(1, 3)) },
                new TimePlaceRm { Id = 2, Place = "Istanbul", Time = DateTime.UtcNow.AddHours(random.Next(4, 10)) },
                new TimePlaceRm { Id = 3, Place = "Munich", Time = DateTime.UtcNow.AddHours(random.Next(1, 10)) },
                new TimePlaceRm { Id = 4, Place = "Schiphol", Time = DateTime.UtcNow.AddHours(random.Next(4, 15)) },
                new TimePlaceRm { Id = 5, Place = "London", Time = DateTime.UtcNow.AddHours(random.Next(1, 15)) },
                new TimePlaceRm { Id = 6, Place = "Vizzola-Ticino", Time = DateTime.UtcNow.AddHours(random.Next(4, 18)) },
                new TimePlaceRm { Id = 7, Place = "Amsterdam", Time = DateTime.UtcNow.AddHours(random.Next(1, 21)) },
                new TimePlaceRm { Id = 8, Place = "Glasgow", Time = DateTime.UtcNow.AddHours(random.Next(4, 21)) },
                new TimePlaceRm { Id = 9, Place = "Zurich", Time = DateTime.UtcNow.AddHours(random.Next(1, 23)) },
                new TimePlaceRm { Id = 10, Place = "Baku", Time = DateTime.UtcNow.AddHours(random.Next(4, 25)) }
            );

            // Seed initial data for FlightRm (sample flight information)
            modelBuilder.Entity<FlightRm>().HasData(
                new FlightRm { Id = 1, Airline = "American Airlines", Price = random.Next(90, 5000).ToString(), DepartureId = 1, ArrivalId = 2, RemainingNumberOfSeats = random.Next(1, 853) },
                new FlightRm { Id = 2, Airline = "Deutsche BA", Price = random.Next(90, 5000).ToString(), DepartureId = 3, ArrivalId = 4, RemainingNumberOfSeats = random.Next(1, 853) },
                new FlightRm { Id = 3, Airline = "British Airways", Price = random.Next(90, 5000).ToString(), DepartureId = 5, ArrivalId = 6, RemainingNumberOfSeats = random.Next(1, 853) },
                new FlightRm { Id = 4, Airline = "Basiq Air", Price = random.Next(90, 5000).ToString(), DepartureId = 7, ArrivalId = 8, RemainingNumberOfSeats = random.Next(1, 853) },
                new FlightRm { Id = 5, Airline = "BB Heliag", Price = random.Next(90, 5000).ToString(), DepartureId = 9, ArrivalId = 10, RemainingNumberOfSeats = random.Next(1, 853) }
            );
        }
    }
}
