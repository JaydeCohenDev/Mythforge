using GameContent.Util;

namespace GameContent.Treasures;

public abstract class TreasureTable
{
    public static TreasureTable C = new TreasureTableC();
    public static TreasureTable P = new TreasureTableP();
    public static TreasureTable Q = new TreasureTableQ();
    public static TreasureTable R = new TreasureTableR();
    public static TreasureTable S = new TreasureTableS();
    public static TreasureTable T = new TreasureTableT();
    public static TreasureTable U = new TreasureTableU();
    public static TreasureTable V = new TreasureTableV();
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
    private class TreasureTableP : TreasureTable
    {
        public override List<TreasureType> Roll()
        {
            List<TreasureType> result = [];

            var rolls = new (int chance, Func<TreasureType> create)[]
            {
                (100, () => new CopperTreasure(Dice.Roll(3, 8)))
            };

            foreach (var (chance, create) in rolls)
            {
                if (Dice.Roll(1, 100) <= chance)
                    result.Add(create());
            }

            return result;
        }
    }
    private class TreasureTableQ : TreasureTable
    {
        public override List<TreasureType> Roll()
        {
            List<TreasureType> result = [];

            var rolls = new (int chance, Func<TreasureType> create)[]
            {
                (100, () => new SilverTreasure(Dice.Roll(3, 6)))
            };

            foreach (var (chance, create) in rolls)
            {
                if (Dice.Roll(1, 100) <= chance)
                    result.Add(create());
            }

            return result;
        }
    }
    private class TreasureTableR : TreasureTable
    {
        public override List<TreasureType> Roll()
        {
            List<TreasureType> result = [];

            var rolls = new (int chance, Func<TreasureType> create)[]
            {
                (100, () => new ElectrumTreasure(Dice.Roll(2, 6)))
            };

            foreach (var (chance, create) in rolls)
            {
                if (Dice.Roll(1, 100) <= chance)
                    result.Add(create());
            }

            return result;
        }
    }
    private class TreasureTableS : TreasureTable
    {
        public override List<TreasureType> Roll()
        {
            List<TreasureType> result = [];

            var rolls = new (int chance, Func<TreasureType> create)[]
            {
                (100, () => new GoldTreasure(Dice.Roll(2, 4)))
            };

            foreach (var (chance, create) in rolls)
            {
                if (Dice.Roll(1, 100) <= chance)
                    result.Add(create());
            }

            return result;
        }
    }
    private class TreasureTableT : TreasureTable
    {
        public override List<TreasureType> Roll()
        {
            List<TreasureType> result = [];

            var rolls = new (int chance, Func<TreasureType> create)[]
            {
                (100, () => new PlatinumTreasure(Dice.Roll(1, 6)))
            };

            foreach (var (chance, create) in rolls)
            {
                if (Dice.Roll(1, 100) <= chance)
                    result.Add(create());
            }

            return result;
        }
    }
    private class TreasureTableU : TreasureTable
    {
        public override List<TreasureType> Roll()
        {
            List<TreasureType> result = [];

            var rolls = new (int chance, Func<TreasureType> create)[]
            {
                (50, () => new CopperTreasure(Dice.Roll(1, 20))),
                (50, () => new SilverTreasure(Dice.Roll(1, 20))),
                (25, () => new GoldTreasure(Dice.Roll(1, 20))),
                (5, () => new GemTreasure(Dice.Roll(1, 4))),
                (5, () => new JewelryTreasure(Dice.Roll(1, 4))),
                (2, () => new MagicItemsTreasure(1)),
            };

            foreach (var (chance, create) in rolls)
            {
                if (Dice.Roll(1, 100) <= chance)
                    result.Add(create());
            }

            return result;
        }
    }
    private class TreasureTableV : TreasureTable
    {
        public override List<TreasureType> Roll()
        {
            List<TreasureType> result = [];

            var rolls = new (int chance, Func<TreasureType> create)[]
            {
                (25, () => new SilverTreasure(Dice.Roll(1, 20))),
                (25, () => new ElectrumTreasure(Dice.Roll(1, 20))),
                (50, () => new GoldTreasure(Dice.Roll(1, 20))),
                (25, () => new PlatinumTreasure(Dice.Roll(1, 20))),
                (10, () => new GemTreasure(Dice.Roll(1, 4))),
                (10, () => new JewelryTreasure(Dice.Roll(1, 4))),
                (5, () => new MagicItemsTreasure(1)),
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

public abstract class TreasureSpawnContext {}
public class IndividualTreasure : TreasureSpawnContext {}
public class LairTreasure : TreasureSpawnContext{}
