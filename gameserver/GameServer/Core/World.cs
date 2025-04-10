using System.Timers;
using GameServer.Content;
using GameServer.Content.Amberfall;
using GameServer.Content.Mob;

namespace GameServer.Core;

public class World
{
    public List<Region> Regions { get; init; } = [];

    public World()
    {
        Game.OnPlayerConnected += connectionId =>
        {
            var player = new Player(connectionId);
            Room? spawnRoom = Regions[0].Rooms[0];
            spawnRoom.Entities.Add(player);
            spawnRoom.AddEntity(player);
        };

        Game.OnPlayerDisconnected += connectionId =>
        {
            if (Player.All.TryGetValue(connectionId, out Player? player))
            {
                player.Destroy();
            }
        };

        Regions.AddRange([
            new Amberfall(),
            new Emberwood(),
        ]);

        Room? amberfall = Room.All.FirstOrDefault(r => r.Value.Name == "Southshade Lane").Value;
        Room? emberwood = Room.All.FirstOrDefault(r => r.Value.Name == "Emberwood Edge").Value;
        amberfall.Exits.Add(emberwood);
        emberwood.Exits.Add(amberfall);

        var timer = new System.Timers.Timer(2000);
        timer.AutoReset = true;

        System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(Mobs).TypeHandle);

        Room.All.ToList().ForEach(room =>
        {

            Mob.All.ForEach(mob =>
             {
                 if (mob.SpawnConditions.Count > 0)
                 {
                     mob.SpawnConditions.ForEach(condition =>
                     {
                         if (condition.CanSpawn(room.Value) && Random.Shared.Next(5) == 0)
                         {
                             Console.WriteLine($"Spawned {mob.Name} in {room.Value.Name}");
                             room.Value.Entities.Add(mob);
                         }
                     });
                 }
             });
        });

        timer.Elapsed += (object? source, ElapsedEventArgs e) =>
        {
            Tick();
        };
        timer.Start();
    }

    public void Tick()
    {
        Regions.ForEach(r => r.Tick());
    }
}