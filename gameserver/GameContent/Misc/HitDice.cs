using GameContent.Util;

namespace GameContent.Misc;

public class HitDice(int num, int sides, int mod = 0)
{
    public int Num { get; set; } = num;
    public int Sides { get; set; } = sides;
    public int Mod {get; set;} = mod;

    public int Roll() => Dice.Roll(Num, Sides) + Mod;
}