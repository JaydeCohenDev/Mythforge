using System.Text.Json;
using GameServer.Content;
using GameServer.Core.Auth;
using GameServer.Core.Scripting;
using Microsoft.EntityFrameworkCore;

namespace GameServer.Core.Database;

public class GameDbContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<ScriptFile> Scripts { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=game.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>(player =>
        {
            player.ToTable("Players");
        });
        
        //modelBuilder.Entity<Entity>().Navigation(e => e.Scripts).AutoInclude();
        //modelBuilder.Entity<Entity>().Navigation(e => e.CurrentRoom).AutoInclude();
//
        //modelBuilder.Entity<Player>().Navigation(p => p.CurrentRoom).AutoInclude();
        //modelBuilder.Entity<Player>().Navigation(p => p.Account).AutoInclude();
//
        //modelBuilder.Entity<Room>().HasMany(e => e.Entities).WithOne(e => e.CurrentRoom);
//
        //modelBuilder.Entity<Room>().Navigation(r => r.Entities).AutoInclude();
        //modelBuilder.Entity<Room>().Navigation(r => r.Exits).AutoInclude();
        //modelBuilder.Entity<Room>().Navigation(r => r.Scripts).AutoInclude();

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