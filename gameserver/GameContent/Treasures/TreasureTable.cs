using GameContent.Util;

namespace GameContent.Treasures;

public abstract class TreasureTable
{
    public static TreasureTable C = new TreasureTableC();
    public abstract List<TreasureType> Roll();
    
    private class TreasureTableC : TreasureTable
    {
        public override List<TreasureType> Roll()
        {
            List<TreasureType> result = [];

            var rolls = new (int chance, Func<TreasureType> create)[]
            {
                (60, () => new CopperTreasure(Dice.Roll(6, 6))),
                (60, () => new SilverTreasure(Dice.Roll(4, 4))),
                (30, () => new ElectrumTreasure(Dice.Roll(2, 6))),
                (25, () => new GemTreasure(Dice.Roll(1, 4))),
                (25, () => new JewelryTreasure(Dice.Roll(1, 4))),
                (15, () => new MagicItemsTreasure(Dice.Roll(1, 2))),
            };

            foreach (var (chance, create) in rolls)
            {
                if (Dice.Roll(1, 100) <= chance)
                    result.Add(create());
            }

            return result;
        }
    }
}

