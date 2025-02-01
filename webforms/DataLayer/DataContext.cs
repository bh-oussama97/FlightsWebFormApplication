using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Claims;
using webforms.Models;

namespace webforms.DataLayer
{
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DbSet<FlightRm> Flights { get; set; }
        public DbSet<TimePlaceRm> Timeplaces { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["mytest"].ConnectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Random random = new Random();

            modelBuilder.Entity<FlightRm>()
            .HasOne(f => f.Arrival)
            .WithMany()
            .HasForeignKey(f => f.ArrivalId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FlightRm>()
                .HasOne(f => f.Departure)
                .WithMany()
                .HasForeignKey(f => f.DepartureId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FlightRm>().Property(p => p.RemainingNumberOfSeats).IsConcurrencyToken();
            modelBuilder.Entity<TimePlaceRm>().HasData(
                new TimePlaceRm { Id = 1, Place = "Los Angeles", Time = DateTime.Now.AddHours(random.Next(1, 3)) },
                new TimePlaceRm { Id = 2, Place = "Istanbul", Time = DateTime.Now.AddHours(random.Next(4, 10)) },
                new TimePlaceRm { Id = 3, Place = "Munchen", Time = DateTime.Now.AddHours(random.Next(1, 10)) },
                new TimePlaceRm { Id = 4, Place = "Schiphol", Time = DateTime.Now.AddHours(random.Next(4, 15)) },
                new TimePlaceRm { Id = 5, Place = "London, England", Time = DateTime.Now.AddHours(random.Next(1, 15)) },
                new TimePlaceRm { Id = 6, Place = "Vizzola-Ticino", Time = DateTime.Now.AddHours(random.Next(4, 18)) },
                new TimePlaceRm { Id = 7, Place = "Amsterdam", Time = DateTime.Now.AddHours(random.Next(1, 21)) },
                new TimePlaceRm { Id = 8, Place = "Glasgow, Scotland", Time = DateTime.Now.AddHours(random.Next(4, 21)) },
                new TimePlaceRm { Id = 9, Place = "Zurich", Time = DateTime.Now.AddHours(random.Next(1, 23)) },
                new TimePlaceRm { Id = 10, Place = "Baku", Time = DateTime.Now.AddHours(random.Next(4, 25)) }
            );

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