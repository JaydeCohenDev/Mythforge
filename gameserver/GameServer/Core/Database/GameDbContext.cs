using GameServer.Core.Auth;
using GameServer.Core.Scripting;
using Microsoft.EntityFrameworkCore;

namespace GameServer.Core.Database;

public class GameDbContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Entity> Entities { get; set; }
    public DbSet<ScriptInstance> ScriptInstances { get; set; }
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=game.db");
        optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>(player =>
        {
            player.ToTable("Players");
        });

        modelBuilder.Entity<Entity>()
            .HasMany(e => e.Scripts)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Account>()
            .HasOne(p => p.Player)
            .WithOne(a => a.Account)
            .HasForeignKey<Player>(a => a.AccountId);
        
        modelBuilder.Entity<Room>() 
            .HasMany(r => r.Exits)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "RoomLink",
                r => r.HasOne<Room>().WithMany().OnDelete(DeleteBehavior.Restrict),
                r => r.HasOne<Room>().WithMany().OnDelete(DeleteBehavior.Restrict)
            );
    }
}