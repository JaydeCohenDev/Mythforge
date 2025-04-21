namespace GameContent.WorldGen;

public abstract class Biome
{
    public static Biome Desert => new Desert();
    public static Biome Grassland => new Grassland();
    public static Biome Jungle => new Jungle();
    public static Biome Mountains => new Mountains();
    public static Biome Ocean => new Ocean();
    public static Biome River => new River();
    public static Biome Swamp => new Swamp();
    public static Biome Forest => new Forest();

    public static Biome Random() => System.Random.Shared.Next(8) switch
    {
        0 => Grassland,
        1 => Jungle,
        2 => Mountains,
        3 => Ocean,
        4 => River,
        5 => Swamp,
        6 => Forest,
        7 => Desert,
    };
}

public class Desert : Biome {}
public class Grassland : Biome {}
public class Jungle : Biome {}
public class Mountains : Biome {}
public class Ocean : Biome {}
public class River : Biome {}
public class Swamp : Biome {}
public class Forest : Biome {}