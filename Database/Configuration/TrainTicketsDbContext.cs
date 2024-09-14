﻿using Microsoft.EntityFrameworkCore;
using TrainTicketsWebApp.Database.Entities;

namespace TrainTicketsWebApp.Database.Configuration;

public class TrainTicketsDbContext : DbContext
{
    public TrainTicketsDbContext(DbContextOptions<TrainTicketsDbContext> options) : base(options)
    {
        
    }

    public DbSet<Entities.Route> Routes { get; set; }
    public DbSet<RouteDetail> RouteDetails { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<TrainStation> TrainStations { get; set; }
    public DbSet<TrainType> TrainTypes { get; set; }
    public DbSet<Trip> Trips { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer("Data source=localhost\\SQLEXPRESS; Trusted_Connection=true; Initial Catalog=TrainTicketsBase; TrustServerCertificate=true; Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entities.Route>(e =>
        {
            e.Property(x => x.Id).IsRequired();
            e.Property(x => x.Name).IsRequired().HasMaxLength(100);
            e.HasIndex(x => x.Name).IsUnique();
            e.HasMany(x => x.RouteDetails).WithOne(x => x.Routes);
        });

        modelBuilder.Entity<TrainType>(e =>
        {
            e.Property(x => x.LongName).IsRequired().HasMaxLength(100);
            e.HasKey(x => x.ShortName);
            e.Property(x => x.ShortName).HasMaxLength(10);
            e.Property(x => x.TotalPlacesAvailable).IsRequired();
            e.Property(x => x.Speed).IsRequired();
        });

        modelBuilder.Entity<TrainStation>(e =>
        {
            e.HasKey(x => x.Station);
            e.Property(x => x.Station).HasMaxLength(100);
        });

        modelBuilder.Entity<RouteDetail>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasOne(x => x.Routes).WithMany(x => x.RouteDetails).HasForeignKey(x => x.RouteId);
            e.Property(x => x.SegmentNumber).IsRequired();
            e.HasOne(x => x.StationFrom).WithMany(x => x.RouteDetailsFrom).HasForeignKey(x => x.From);
            e.HasOne(x => x.StationTo).WithMany(x => x.RouteDetailsTo).HasForeignKey(x => x.To);
            e.Property(x => x.RouteId).IsRequired();
            e.Property(x => x.Distance).IsRequired();
            e.Property(x => x.MaxSpeed).IsRequired();
            e.Property(x => x.From).HasDefaultValue("Usunięto");
            e.Property(x => x.To).HasDefaultValue("Usunięto");
        });

        modelBuilder.Entity<Schedule>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasOne(x => x.Trip).WithMany(x => x.Schedules).HasForeignKey(x => x.TripId);
            e.HasOne(x => x.StationFrom).WithMany(x => x.ScheduleStationFrom).HasForeignKey(x => x.From);
            e.HasOne(x => x.StationTo).WithMany(x => x.ScheduleStationTo).HasForeignKey(x => x.To);
            e.Property(x => x.DepartureTime).IsRequired();
            e.Property(x => x.ArrivalTime).IsRequired();
            //e.Property(x => x.StationFrom).HasDefaultValue("Usunięto");
            //e.Property(x => x.StationTo).HasDefaultValue("Usunięto");
        });

        modelBuilder.Entity<Trip>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasOne(x => x.Route).WithMany(x => x.Trips).HasForeignKey(x => x.RouteId);
            e.Property(x => x.DepartureTime).IsRequired();
            e.HasOne(x => x.TrainType).WithMany(x => x.Trips).HasForeignKey(x => x.TrainTypeName);
        });

        modelBuilder.Entity<Reservation>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.TripId).IsRequired();
            e.Property(x => x.FirstName).IsRequired().HasMaxLength(200);
            e.Property(x => x.LastName).IsRequired().HasMaxLength(200);
            e.Property(x => x.Email).IsRequired();
            e.Property(x => x.From).IsRequired();
            e.Property(x => x.To).IsRequired();
            e.Property(x => x.DepartureTime).IsRequired();
            e.Property(x => x.ArrivalTime).IsRequired();
            e.Property(x => x.TrainType).IsRequired();
            e.Property(x => x.SeatNumber).IsRequired();
            e.HasOne(x => x.Trip).WithMany(x => x.Reservations).HasForeignKey(x => x.TripId);
            e.HasOne(x => x.TrainStationFrom).WithMany(x => x.ReservationFrom).HasForeignKey(x => x.From);
            e.HasOne(x => x.TrainStationTo).WithMany(x => x.ReservationTo).HasForeignKey (x => x.To);
            e.Property(x => x.From).HasDefaultValue("Usunięto");
            e.Property(x => x.To).HasDefaultValue("Usunięto");
        });
    }
}
