using GameContent.Util;

namespace GameContent.Treasures;

public abstract class TreasureType
{
    
}

public class CopperTreasure(int numInHundreds) : TreasureType
{
    public int Num => numInHundreds * 100;
}

public class SilverTreasure(int numInHundreds) : TreasureType
{
    public int Num => numInHundreds * 100;
}

public class ElectrumTreasure(int numInHundreds) : TreasureType
{
    public int Num => numInHundreds * 100;
}

public class GoldTreasure(int numInHundreds) : TreasureType
{
    public int Num => numInHundreds * 100;
}

public class PlatinumTreasure(int numInHundreds) : TreasureType
{
    public int Num => numInHundreds * 100;
}

public class GemTreasure : TreasureType
{
    public List<Gem> Gems { get; } = [];
    
    public GemTreasure(int num)
    {
        List<GemType> gemTypes = [];
        for (int i = 0; i < num; i++)
        {
            int valueAdjustmentRoll = Dice.Roll(2, 6);
            int roll = Dice.Roll(1, 100);
            if (roll <= 20)
            {
                GemType gemType = valueAdjustmentRoll switch
                {
                    2 => new OrnamentalGemType(null),
                    3 => new OrnamentalGemType((0.5f, "Small")),
                    4 => new OrnamentalGemType((0.75f, "Chipped")),
                    >= 5 and <= 9 => new OrnamentalGemType(null),
                    10 => new OrnamentalGemType((1.5f, "Polished")),
                    11 => new OrnamentalGemType((2, "Large")),
                    12 => new SemipreciousGemType(null),
                    _ => throw new Exception("Invalid value adjustment roll")
                };
                gemTypes.Add(gemType);
            }
            else if (roll <= 45)
            {
                GemType gemType = valueAdjustmentRoll switch
                {
                    2 => new SemipreciousGemType(null),
                    3 => new SemipreciousGemType((0.5f, "Small")),
                    4 => new SemipreciousGemType((0.75f, "Chipped")),
                    >= 5 and <= 9 => new SemipreciousGemType(null),
                    10 => new SemipreciousGemType((1.5f, "Polished")),
                    11 => new SemipreciousGemType((2, "Large")),
                    12 => new FancyGemType(null),
                    _ => throw new Exception("Invalid value adjustment roll")
                };
                gemTypes.Add(gemType);
            }
            else if (roll <= 75)
            {
                GemType gemType = valueAdjustmentRoll switch
                {
                    2 => new FancyGemType(null),
                    3 => new FancyGemType((0.5f, "Small")),
                    4 => new FancyGemType((0.75f, "Chipped")),
                    >= 5 and <= 9 => new FancyGemType(null),
                    10 => new FancyGemType((1.5f, "Polished")),
                    11 => new FancyGemType((2, "Large")),
                    12 => new PreciousGemType(null),
                    _ => throw new Exception("Invalid value adjustment roll")
                };
                gemTypes.Add(gemType);
            }
            else if (roll <= 95)
            {
                GemType gemType = valueAdjustmentRoll switch
                {
                    2 => new PreciousGemType(null),
                    3 => new PreciousGemType((0.5f, "Small")),
                    4 => new PreciousGemType((0.75f, "Chipped")),
                    >= 5 and <= 9 => new PreciousGemType(null),
                    10 => new PreciousGemType((1.5f, "Polished")),
                    11 => new PreciousGemType((2, "Large")),
                    12 => new PerfectGemType(null),
                    _ => throw new Exception("Invalid value adjustment roll")
                };
                gemTypes.Add(gemType);
            }
            else
            {
                GemType gemType = valueAdjustmentRoll switch
                {
                    2 => new PerfectGemType(null),
                    3 => new PerfectGemType((0.5f, "Small")),
                    4 => new PerfectGemType((0.75f, "Chipped")),
                    >= 5 and <= 9 => new PerfectGemType(null),
                    10 => new PerfectGemType((1.5f, "Polished")),
                    11 => new PerfectGemType((2, "Large")),
                    12 => new JewelGemType(null),
                    _ => throw new Exception("Invalid value adjustment roll")
                };
                gemTypes.Add(gemType);
            }
        }

        foreach (GemType gemType in gemTypes)
            Gems.AddRange(gemType.GenerateGems());
    }
}

public class JewelryTreasure : TreasureType
{
    public List<Jewelery> Jewelry { get; } = [];

    public JewelryTreasure(int num)
    {
        for (int i = 0; i < num; i++)
            Jewelry.Add(Jewelery.Generate());
    }
}

public class MagicItemsTreasure(int num) : TreasureType
{
    
}