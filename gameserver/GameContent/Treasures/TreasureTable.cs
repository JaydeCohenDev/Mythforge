namespace GameContent.Treasures;

public abstract class TreasureTable
{
    public static TreasureTable C = new TreasureTableC();
    public abstract List<Treasure> Roll();
    
    private class TreasureTableC : TreasureTable
    {
        public override List<Treasure> Roll()
        {
            throw new NotImplementedException();
        }
    }
}

