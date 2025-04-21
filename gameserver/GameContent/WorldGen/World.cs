using System.Numerics;
using DelaunatorSharp;
using GameContent.Util;

namespace GameContent.WorldGen;

public class Position : IPoint
{
    public double X { get; set; }
    public double Y { get; set; }
}

public class Location
{
    public required Position Position;
    public required Biome Biome;

    public readonly List<Location> Connections = [];
}

public abstract class LocationFeature {}
public abstract class LairFeature : LocationFeature {}
public abstract class DungeonFeature : LocationFeature {}
public abstract class LandmarkFeature : LocationFeature
{
    public LandmarkFeature()
    {
        LandmarkNature nature = Dice.Roll(1, 6) switch
        {
            <= 3 => new Natural(),
            <= 5 => new Artifical(),
            <= 6 => new Magic(),
        };


    }

    private abstract class LandmarkNature {}
    private class Natural : LandmarkNature {
        // public Natural() {
        //     var type = Dice.Roll(1, 6) switch {
        //         1 => 
        //     };
        // }
    }
    private class Artifical : LandmarkNature {}
    private class Magic : LandmarkNature {}

    private abstract class LandmarkFind {}
    private class Hazard : LandmarkFind {}
    private class Empty : LandmarkFeature {}
    private class Special : LandmarkFeature {}
    private class Monsters : LandmarkFind {}
}
public abstract class SettlementFeature : LocationFeature {}

public class World
{
    private World() {}

    public readonly Dictionary<Position, Location> Locations = [];

    public static World Generate()
    {
        var world = new World();

        for (int i = 0; i < 25; i++)
        {
            var pos = new Position
            {
                X = Random.Shared.NextDouble() * 100.0,
                Y = Random.Shared.NextDouble() * 100.0
            };
            var loc = new Location
            {
                Position = pos,
                Biome = Biome.Random(),
            };
            world.Locations.Add(pos, loc);
            
            // Generate features
            // Lair, Dungeon, Settlement, Landmark
            // Natural resources
        }

        var d = new Delaunator(world.Locations.Keys.ToArray<IPoint>());
        d.ForEachTriangleEdge((edge) =>
        {
            var p = world.Locations[(Position)edge.P];
            var q = world.Locations[(Position)edge.Q];
            p.Connections.Add(q);
            q.Connections.Add(p);
        });

        return world;
    }
}