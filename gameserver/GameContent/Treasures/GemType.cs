using GameContent.Util;

namespace GameContent.Treasures;

public abstract class GemType((float valueAdjusmnet, string modifier)? adjustmenet)
{
    public abstract string Name { get; }
    public abstract int ValueInGold { get; }
    public abstract int RollNumberFound();

    protected (float valueAdjusmnet, string modifier)? _adjustmenet = adjustmenet;

    public List<Gem> GenerateGems()
    {
        List<Gem> result = [];
        for (int i = 0; i < RollNumberFound(); i++)
        {
            var name = $"{Name} {Gem.RollName()}";
            var adjustedValue = ValueInGold;
            if (_adjustmenet is not null)
            {
                adjustedValue *= (int)_adjustmenet.Value.valueAdjusmnet;
                name += $" [{_adjustmenet.Value.modifier}]";
            }
            
            var gem = new Gem
            {
                Name = name,
                ValueInGold = adjustedValue,
            };
        }
        return result;
    }
}

public class Gem
{
    public required string Name { get; init; }
    public required int ValueInGold { get; init; }

    public static string RollName()
    {
        int roll = Dice.Roll(1, 100);
        return roll switch
        {
            <= 05 => "Alexandrite",
            <= 12 => "Amethyst",
            <= 20 => "Aventurine",
            <= 30 => "Chlorastrolite",
            <= 40 => "Diamond",
            <= 43 => "Emerald",
            <= 48 => "Fire Opal",
            <= 57 => "Fluorospar",
            <= 63 => "Garnet",
            <= 68 => "Heliotrope",
            <= 78 => "Malachite",
            <= 88 => "Rhodonite",
            <= 91 => "\tRuby",
            <= 95 => "Sapphire",
            _ => "Topaz"
        };
    }
}

public class OrnamentalGemType((float valueAdjusmnet, string modifier)? adjustmenet) : GemType(adjustmenet)
{
    public override string Name => "Ornamental";
    public override int ValueInGold => 10;
    public override int RollNumberFound() => Dice.Roll(1, 10);
}

public class SemipreciousGemType((float valueAdjusmnet, string modifier)? adjustmenet) : GemType(adjustmenet)
{
    public override string Name => "Semiprecious";
    public override int ValueInGold => 50;
    public override int RollNumberFound() => Dice.Roll(1, 8);
}

public class FancyGemType((float valueAdjusmnet, string modifier)? adjustmenet) : GemType(adjustmenet)
{
    public override string Name => "Fancy";
    public override int ValueInGold => 100;
    public override int RollNumberFound() => Dice.Roll(1, 6);
}

public class PreciousGemType((float valueAdjusmnet, string modifier)? adjustmenet) : GemType(adjustmenet)
{
    public override string Name => "Precious";
    public override int ValueInGold => 500;
    public override int RollNumberFound() => Dice.Roll(1, 4);
}

public class PerfectGemType((float valueAdjusmnet, string modifier)? adjustmenet) : GemType(adjustmenet)
{
    public override string Name => "Perfect";
    public override int ValueInGold => 1_000;
    public override int RollNumberFound() => Dice.Roll(1, 2);
}

public class JewelGemType((float valueAdjusmnet, string modifier)? adjustmenet) : GemType(adjustmenet)
{
    public override string Name => "Jewel";
    public override int ValueInGold => 5_000;
    public override int RollNumberFound() => 1;
}