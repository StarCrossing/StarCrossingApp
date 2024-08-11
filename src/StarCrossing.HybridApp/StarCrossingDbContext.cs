using Microsoft.EntityFrameworkCore;
using StarCrossing.HybridApp.Data;
using StarCrossing.HybridApp.Data.Resources;

namespace StarCrossing.HybridApp;

public class StarCrossingDbContext(DbContextOptions<StarCrossingDbContext> options) : DbContext(options)
{
    public DbSet<Player> Player => Set<Player>();
    public DbSet<GameResource> Resources => Set<GameResource>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
