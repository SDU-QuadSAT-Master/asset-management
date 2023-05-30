using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    public DbSet<Drone> Drones { get; set; }
    public DbSet<FlightEntry> FlightEntrys { get; set; }
    public DbSet<Antenna> Antennas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseNpgsql("Host=postgres; Database=assets; Username=usr_assets; Password=assets");
}