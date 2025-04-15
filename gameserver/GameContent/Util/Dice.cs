namespace GameContent.Util;

public static class Dice
{
    public static int Roll(int num, int sides)
    {
        int total = 0;

        for (int i = 0; i < num; i++)
        {
            total += Random.Shared.Next(sides) + 1;
        }
        
        return total;
    }
}