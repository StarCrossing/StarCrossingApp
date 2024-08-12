using Microsoft.EntityFrameworkCore;
using StarCrossing.HybridApp.Data;
using StarCrossing.HybridApp.Data.Resources;

namespace StarCrossing.HybridApp;

public class StarCrossingDbContext(DbContextOptions<StarCrossingDbContext> options) : DbContext(options)
{
    public DbSet<Building> Buildings => Set<Building>();
    public DbSet<Player> Player => Set<Player>();
    public DbSet<GameResource> Resources => Set<GameResource>();
    public DbSet<Vassal> Vassals => Set<Vassal>();

    public StarCrossingDbContext() : this(new DbContextOptionsBuilder<StarCrossingDbContext>().Options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
            return;

        Console.WriteLine("Configuring database");
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        Console.WriteLine($"Database path: {path}");
        optionsBuilder.UseSqlite($"Data Source=StarCrossing.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Building>()
            .HasDiscriminator(x => x.Name)
            .HasValue<Farm>("Farm")
            .HasValue<Fishery>("Fishery")
            .HasValue<GoldMine>("Gold Mine")
            .HasValue<Harbor>("Harbor")
            .HasValue<Hunter>("Hunter")
            .HasValue<IronMine>("Iron Mine")
            .HasValue<Lumberyard>("Lumberyard")
            .HasValue<MarbleQuarry>("Marble Quarry")
            .HasValue<Obelisk>("Obelisk")
            .HasValue<Palace>("Palace")
            .HasValue<Pasture>("Pasture")
            .HasValue<StonePit>("Stone Pit")
            .HasValue<Temple>("Temple")
            .HasValue<TradeDepot>("Trade Depot")
            .HasValue<Vineyard>("Vineyard")
            .HasValue<Woodsman>("Woodsman")
            .IsComplete();

        modelBuilder.Entity<GameResource>()
            .HasDiscriminator(x => x.Name)
            .HasValue<Gold>("Gold")
            .HasValue<Iron>("Iron")
            .HasValue<Marble>("Marble")
            .HasValue<Meat>("Meat")
            .HasValue<Quintessence>("Quintessence")
            .HasValue<Stone>("Stone")
            .HasValue<Wheat>("Wheat")
            .HasValue<Wine>("Wine")
            .HasValue<Wood>("Wood")
            .IsComplete();
    }
}
