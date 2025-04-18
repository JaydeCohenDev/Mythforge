// using GameServer.Core.Auth;
// using GameServer.Core.Scripting;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.ChangeTracking;
// using Newtonsoft.Json;
// using ScriptApi;

// namespace GameServer.Core.Database;

// public class GameDbContext : DbContext
// {
//     public DbSet<Account> Accounts { get; set; }
//     public DbSet<Region> Regions { get; set; }
//     public DbSet<Room> Rooms { get; set; }
//     public DbSet<Player> Players { get; set; }
//     public DbSet<Entity> Entities { get; set; }
//     public DbSet<ScriptInstance> ScriptInstances { get; set; }
    
    
//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//     {
//         optionsBuilder.UseSqlite("Data Source=game.db");
//         optionsBuilder.UseLazyLoadingProxies();
//     }

//     protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         modelBuilder.Entity<Player>(player =>
//         {
//             player.ToTable("Players");
//         });

//         modelBuilder.Entity<Entity>()
//             .HasMany(e => e.Scripts)
//             .WithOne()
//             .OnDelete(DeleteBehavior.Cascade);
        
//         modelBuilder.Entity<Account>()
//             .HasOne(p => p.Player)
//             .WithOne(a => a.Account)
//             .HasForeignKey<Player>(a => a.AccountId);
        
//         modelBuilder.Entity<Room>() 
//             .HasMany(r => r.Exits)
//             .WithMany()
//             .UsingEntity<Dictionary<string, object>>(
//                 "RoomLink",
//                 r => r.HasOne<Room>().WithMany().OnDelete(DeleteBehavior.Restrict),
//                 r => r.HasOne<Room>().WithMany().OnDelete(DeleteBehavior.Restrict)
//             );

//         modelBuilder.Entity<ScriptInstance>()
//             .Property(si => si.RuntimeScript)
//             .HasConversion(
//                 // Serialize ScriptBase (RuntimeScript) -> JSON string for save
//                 v => SerializeScript(v),

//                 // Deserialize JSON string -> ScriptBase for load
//                 v => DeserializeScript(v)

//             )
//             .HasColumnName("ScriptData");
//     }

//     private static string? SerializeScript(ScriptBase? script)
//     {
//         if (script == null) return null;

//         Console.WriteLine($"Serializing script of type '{script.GetType().FullName}'.");
        
//         // Include ScriptClassName and the script data in serialization
//         var scriptData = new
//         {
//             ScriptClassName = script.GetType().Name,
//             Data = script.SerializePersistedProperties()
//         };

//         return JsonConvert.SerializeObject(scriptData);
//     }

//     private static ScriptBase? DeserializeScript(string? scriptData)
//     {
//         if (string.IsNullOrEmpty(scriptData)) return null;

//         // Deserialize wrapper object to extract ScriptClassName and actual data
//         var deserializedData = JsonConvert.DeserializeObject<dynamic>(scriptData);
//         if (deserializedData == null) return null;

//         string? scriptClassName = deserializedData.ScriptClassName;
//         string? data = deserializedData.Data;

//         if (string.IsNullOrEmpty(scriptClassName) || string.IsNullOrEmpty(data))
//         {
//             throw new InvalidOperationException("Invalid script data or missing ScriptClassName.");
//         }

//         // Create an instance of the ScriptBase subclass
//         var script = ScriptManager.CreateScript<ScriptBase>(scriptClassName);
//         if (script == null)
//         {
//             throw new InvalidCastException($"Unable to cast type '{scriptClassName}' to ScriptBase.");
//         }

//         // Populate the ScriptBase object using the JSON data
//         JsonConvert.PopulateObject(data, script);
//         script.TrackChanges();

//         // Attach event handlers for tracking changes
//         script.OnSaveRequested += () =>
//         {
//             Console.WriteLine($"Change detected and save requested for script of type '{scriptClassName}'.");
//         };

//         return script;
//     }

// }