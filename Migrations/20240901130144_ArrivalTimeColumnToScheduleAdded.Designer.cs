﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrainTicketsWebApp.Database.Configuration;

#nullable disable

namespace TrainTicketsWebApp.Migrations
{
    [DbContext(typeof(TrainTicketsDbContext))]
    [Migration("20240901130144_ArrivalTimeColumnToScheduleAdded")]
    partial class ArrivalTimeColumnToScheduleAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TrainTicketsWebApp.Database.Entities.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("TrainTicketsWebApp.Database.Entities.RouteDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<string>("From")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("MaxSpeed")
                        .HasColumnType("int");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.Property<int>("SegmentNumber")
                        .HasColumnType("int");

                    b.Property<string>("To")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("From");

                    b.HasIndex("RouteId");

                    b.HasIndex("To");

                    b.ToTable("RouteDetails");
                });

            modelBuilder.Entity("TrainTicketsWebApp.Database.Entities.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("From")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("To")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("From");

                    b.HasIndex("To");

                    b.HasIndex("TripId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("TrainTicketsWebApp.Database.Entities.TrainStation", b =>
                {
                    b.Property<string>("Station")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Station");

                    b.ToTable("TrainStations");
                });

            modelBuilder.Entity("TrainTicketsWebApp.Database.Entities.TrainType", b =>
                {
                    b.Property<string>("ShortName")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("LongName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<int>("TotalPlacesAvailable")
                        .HasColumnType("int");

                    b.HasKey("ShortName");

                    b.ToTable("TrainTypes");
                });

            modelBuilder.Entity("TrainTicketsWebApp.Database.Entities.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.Property<string>("TrainTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("RouteId");

                    b.HasIndex("TrainTypeName");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("TrainTicketsWebApp.Database.Entities.RouteDetail", b =>
                {
                    b.HasOne("TrainTicketsWebApp.Database.Entities.TrainStation", "StationFrom")
                        .WithMany("RouteDetailsFrom")
                        .HasForeignKey("From")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainTicketsWebApp.Database.Entities.Route", "Routes")
                        .WithMany("RouteDetails")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainTicketsWebApp.Database.Entities.TrainStation", "StationTo")
                        .WithMany("RouteDetailsTo")
                        .HasForeignKey("To")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Routes");

                    b.Navigation("StationFrom");

                    b.Navigation("StationTo");
                });

            modelBuilder.Entity("TrainTicketsWebApp.Database.Entities.Schedule", b =>
                {
                    b.HasOne("TrainTicketsWebApp.Database.Entities.TrainStation", "StationFrom")
                        .WithMany("ScheduleStationFrom")
                        .HasForeignKey("From")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainTicketsWebApp.Database.Entities.TrainStation", "StationTo")
                        .WithMany("ScheduleStationTo")
                        .HasForeignKey("To")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainTicketsWebApp.Database.Entities.Trip", "Trip")
                        .WithMany("Schedules")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StationFrom");

                    b.Navigation("StationTo");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("TrainTicketsWebApp.Database.Entities.Trip", b =>
                {
                    b.HasOne("TrainTicketsWebApp.Database.Entities.Route", "Route")
                        .WithMany("Trips")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainTicketsWebApp.Database.Entities.TrainType", "TrainType")
                        .WithMany("Trips")
                        .HasForeignKey("TrainTypeName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Route");

                    b.Navigation("TrainType");
                });

            modelBuilder.Entity("TrainTicketsWebApp.Database.Entities.Route", b =>
                {
                    b.Navigation("RouteDetails");

                    b.Navigation("Trips");
                });

            modelBuilder.Entity("TrainTicketsWebApp.Database.Entities.TrainStation", b =>
                {
                    b.Navigation("RouteDetailsFrom");

                    b.Navigation("RouteDetailsTo");

                    b.Navigation("ScheduleStationFrom");

                    b.Navigation("ScheduleStationTo");
                });

            modelBuilder.Entity("TrainTicketsWebApp.Database.Entities.TrainType", b =>
                {
                    b.Navigation("Trips");
                });

            modelBuilder.Entity("TrainTicketsWebApp.Database.Entities.Trip", b =>
                {
                    b.Navigation("Schedules");
                });
#pragma warning restore 612, 618
        }
    }
}
