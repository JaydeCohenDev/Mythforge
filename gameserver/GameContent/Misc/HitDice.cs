using GameContent.Util;

namespace GameContent.Misc;

public class HitDice(int num, int sides)
{
    public int Num { get; set; } = num;
    public int Sides { get; set; } = sides;

    public int Roll() => Dice.Roll(Num, Sides);
}