using System.Timers;

namespace GameServer.Core;

public class World
{
    public List<Region> Regions = [];

    public World()
    {
        var timer = new System.Timers.Timer(2000);
        timer.AutoReset = true;
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