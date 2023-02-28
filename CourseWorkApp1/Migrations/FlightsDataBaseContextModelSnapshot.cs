﻿// <auto-generated />
using System;
using CourseWorkApp1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CourseWorkApp1.Migrations
{
    [DbContext(typeof(FlightsDataBaseContext))]
    partial class FlightsDataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0-preview.1.23111.4");

            modelBuilder.Entity("CourseWorkApp1.Country", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Distance")
                        .HasColumnType("TEXT");

                    b.Property<string>("Distinguishments")
                        .HasColumnType("TEXT");

                    b.Property<string>("Information")
                        .HasColumnType("TEXT");

                    b.Property<string>("Language")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Picture")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Country", (string)null);
                });

            modelBuilder.Entity("CourseWorkApp1.Flight", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("AmountOfPlaces")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long?>("CountryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<long?>("GeneralAmountOfPlaces")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("IsTaken")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("CourseWorkApp1.TakenFlight", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CityName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Date")
                        .HasColumnType("TEXT");

                    b.Property<long?>("FlightId")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<string>("Time")
                        .HasColumnType("TEXT");

                    b.Property<long?>("UserIdCheck")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.HasIndex("UserIdCheck");

                    b.ToTable("TakenFlights");
                });

            modelBuilder.Entity("CourseWorkApp1.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Citizenship")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Fullname")
                        .HasColumnType("TEXT");

                    b.Property<long?>("PassportId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("Passport_Id");

                    b.Property<long?>("PassportSeries")
                        .HasColumnType("INTEGER")
                        .HasColumnName("Passport_Series");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<long?>("PhoneNumber")
                        .HasColumnType("INTEGER")
                        .HasColumnName("Phone_number");

                    b.Property<long?>("UserTakenTickets")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserTakenTickets");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CourseWorkApp1.Flight", b =>
                {
                    b.HasOne("CourseWorkApp1.Country", "Country")
                        .WithMany("Flights")
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("CourseWorkApp1.TakenFlight", b =>
                {
                    b.HasOne("CourseWorkApp1.Flight", "Flight")
                        .WithMany("TakenFlights")
                        .HasForeignKey("FlightId");

                    b.HasOne("CourseWorkApp1.User", "UserIdCheckNavigation")
                        .WithMany("TakenFlights")
                        .HasForeignKey("UserIdCheck");

                    b.Navigation("Flight");

                    b.Navigation("UserIdCheckNavigation");
                });

            modelBuilder.Entity("CourseWorkApp1.User", b =>
                {
                    b.HasOne("CourseWorkApp1.TakenFlight", "UserTakenTicketsNavigation")
                        .WithMany("Users")
                        .HasForeignKey("UserTakenTickets");

                    b.Navigation("UserTakenTicketsNavigation");
                });

            modelBuilder.Entity("CourseWorkApp1.Country", b =>
                {
                    b.Navigation("Flights");
                });

            modelBuilder.Entity("CourseWorkApp1.Flight", b =>
                {
                    b.Navigation("TakenFlights");
                });

            modelBuilder.Entity("CourseWorkApp1.TakenFlight", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("CourseWorkApp1.User", b =>
                {
                    b.Navigation("TakenFlights");
                });
#pragma warning restore 612, 618
        }
    }
}
