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
    public static Action Select(int num, int sides, List<Tuple<int, Action>> options)
    {
        var roll = Roll(num, sides);
        foreach(var result in options)
            if(roll <= result.Item1)
                return result.Item2;

        throw new IndexOutOfRangeException();
    }
}

// public class RollTable<T> 
// {
//     private Dictionary<int, T> _items = [];

//     public RollTable<T>(Dictionary<string, T> items)
//     {
//         foreach(var item in items)
//         {

//         }
//     }

//     public T Roll() 
//     {

//     }
// }