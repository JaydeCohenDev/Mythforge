using GameContent.Util;

namespace GameContent.Treasures;

public class Jewelery
{
    public required string Name { get; set; }
    public required int Value { get; set; }

    public static string GenerateName()
    {
        var roll = Dice.Roll(1, 100);
        return roll switch
        {
            <= 6 => "Anklet",
            <= 12 => "Belt",
            <= 14 => "Bowl",
            <= 21 => "Bracelet",
            <= 27 => "Brooch",
            <= 32 => "Buckle",
            <= 37 => "Chain",
            <= 40 => "Choker",
            <= 42 => "Circlet",
            <= 47 => "Clasp",
            <= 51 => "Comb",
            <= 52 => "Crown",
            <= 55 => "Cup",
            <= 62 => "Earring",
            <= 65 => "Flagon",
            <= 68 => "Goblet",
            <= 73 => "Knife",
            <= 77 => "Letter Opener",
            <= 80 => "Locket",
            <= 82 => "Medal",
            <= 89 => "Necklace",
            <= 90 => "Plate",
            <= 95 => "Pin",
            <= 96 => "Sceptre",
            <= 99 => "Statuette",
            _ => "Tiara",
        };
    }
    
    public static Jewelery Generate()
    {
        return new Jewelery
        {
            Name = GenerateName(),
            Value = Dice.Roll(2, 8) * 100
        };
    }
}