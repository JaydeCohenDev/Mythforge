using System.Timers;
using GameServer.Content;
using GameServer.Content.Amberfall;
using GameServer.Content.Mob;
using GameServer.Core.Database;
using Microsoft.EntityFrameworkCore;

namespace GameServer.Core;

public class World
{
    public static GameDbContext Db { get; } = new();

    public World()
    {
        var timer = new System.Timers.Timer(2000);
        timer.AutoReset = true;

        System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(Mobs).TypeHandle);

        timer.Elapsed += (object? source, ElapsedEventArgs e) =>
        {
            Tick();
        };
        timer.Start();
    }

    public void Tick()
    {
        Console.WriteLine("World Tick");
        Db.Regions.Include(r => r.Rooms).ThenInclude(r => r.Entities).ThenInclude(r => r.Scripts).ForEachAsync(r => r.Tick());
    }
}