using System.Drawing;
using GameContent.Util;
using SimplexNoise;

namespace GameContent.WorldGen;

public class World
{
    private static Dictionary<Point, Location> Locations { get; } = [];
    private World() {}
    
    public static World Generate(int numLocations)
    {
        var world = new World();

        List<Point> OpenList = [new Point(0, 0)]; 
        
        for (int i = 0; i < numLocations; i++)
        {
            var newPoint = OpenList[Random.Shared.Next(0, OpenList.Count)];
            OpenList.Remove(newPoint);

            var location = new Location
            {
                Biome = GetNeighborBiome(newPoint).GenerateAdjacentBiome()
            };
            Locations.Add(newPoint, location);

            // Feature pressence
            if (Dice.Roll(1, 6) == 1)
            {
                var featureTypeRoll = Dice.Roll(1, 12);
                var featureType = featureTypeRoll switch
                {
                    <= 2 => FeatureType.RuinsAndRelics,
                    <= 4 => FeatureType.LuridLairs,
                    <= 6 => FeatureType.RiversAndRoads,
                    <= 8 => FeatureType.CastlesAndCitadels,
                    <= 10 => FeatureType.TemplesAndShrines,
                    _ => FeatureType.VillagesAndTowns
                };
            };
            
        }
        
        return world;
    }

    private static Biome GetNeighborBiome(Point point)
    {
        List<Biome> biomes = [];
        GetNeighbors(point).ForEach(p =>
        {
            if(Locations.TryGetValue(p, out Location? location))
                biomes.Add(location.Biome);
        });
        return biomes.Count > 0 ? biomes[Random.Shared.Next(0, biomes.Count)] : Biome.Plains;
    }

    private static List<Point> GetNeighbors(Point point)
    {
        return [
            new Point(point.X - 1, point.Y),
            new Point(point.X + 1, point.Y),
            new Point(point.X, point.Y - 1),
            new Point(point.X, point.Y + 1)
        ];
    }
}