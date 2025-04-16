using GameContent.Util;

namespace GameContent.WorldGen;

public abstract class Biome
{
    public static Biome Plains = new Plains();
    public static Biome Forest = new Forest();
    public static Biome Marsh = new Marsh();
    public static Biome Mountains = new Mountains();
    public static Biome Water = new Water();
    public static Biome Hills = new Hills();

    public abstract Biome GenerateAdjacentBiome();
}

public class Plains : Biome
{
    public override Biome GenerateAdjacentBiome()
    {
        var roll = Dice.Roll(1, 20);
        return roll switch
        {
            <= 10 => Plains,
            <= 16 => Forest,
            <= 18 => Marsh,
            <= 19 => Mountains,
            _ => Water
        };
    }
}

public class Forest : Biome
{
    public override Biome GenerateAdjacentBiome()
    {
        var roll = Dice.Roll(1, 20);
        return roll switch
        {
            <= 10 => Forest,
            <= 16 => Plains,
            <= 18 => Hills,
            <= 19 => Mountains,
            _ => Marsh
        };
    }
}

public class Marsh : Biome
{
    public override Biome GenerateAdjacentBiome()
    {
        var roll = Dice.Roll(1, 20);
        return roll switch
        {
            <= 10 => Marsh,
            <= 16 => Water,
            <= 18 => Forest,
            <= 19 => Plains,
            _ => Hills
        };
    }
}

public class Mountains : Biome
{
    public override Biome GenerateAdjacentBiome()
    {
        var roll = Dice.Roll(1, 20);
        return roll switch
        {
            <= 10 => Mountains,
            <= 16 => Hills,
            <= 18 => Plains,
            <= 19 => Forest,
            _ => Water
        };
    }
}

public class Water : Biome
{
    public override Biome GenerateAdjacentBiome()
    {
        var roll = Dice.Roll(1, 20);
        return roll switch
        {
            <= 10 => Water,
            <= 16 => Marsh,
            <= 18 => Mountains,
            <= 19 => Plains,
            _ => Hills
        };
    }
}

public class Hills : Biome
{
    public override Biome GenerateAdjacentBiome()
    {
        var roll = Dice.Roll(1, 20);
        return roll switch
        {
            <= 10 => Hills,
            <= 16 => Mountains,
            <= 18 => Water,
            <= 19 => Forest,
            _ => Marsh
        };
    }
}