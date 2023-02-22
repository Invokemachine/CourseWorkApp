using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CourseWorkApp1;

public partial class FlightsDataBaseContext : DbContext
{
    public FlightsDataBaseContext()
    {
    }

    public FlightsDataBaseContext(DbContextOptions<FlightsDataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Flight> Flights { get; set; }

    public virtual DbSet<TakenFlight> TakenFlights { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\AzatYTebiLove\\Desktop\\FlightsDataBase.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country");
        });

        modelBuilder.Entity<Flight>(entity =>
        {
            entity.HasOne(d => d.Country).WithMany(p => p.Flights).HasForeignKey(d => d.CountryId);
        });

        modelBuilder.Entity<TakenFlight>(entity =>
        {
            entity.HasOne(d => d.Flight).WithMany(p => p.TakenFlights).HasForeignKey(d => d.FlightId);

            entity.HasOne(d => d.UserIdCheckNavigation).WithMany(p => p.TakenFlights).HasForeignKey(d => d.UserIdCheck);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.PassportId).HasColumnName("Passport_Id");
            entity.Property(e => e.PassportSeries).HasColumnName("Passport_Series");
            entity.Property(e => e.PhoneNumber).HasColumnName("Phone_number");

            entity.HasOne(d => d.UserTakenTicketsNavigation).WithMany(p => p.Users).HasForeignKey(d => d.UserTakenTickets);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
