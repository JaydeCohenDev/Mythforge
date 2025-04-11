using System.Text.Json;
using GameServer.Content;
using GameServer.Core.Auth;
using Microsoft.EntityFrameworkCore;

namespace GameServer.Core.Database;

public class GameDbContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Region> Regions { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=game.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Room>()
            .Property(r => r.Tags)
            .HasConversion(v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<List<RoomTags>>(v, (JsonSerializerOptions)null));

        modelBuilder.Entity<Player>(player =>
        {
            player.ToTable("Players");
        });
        
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