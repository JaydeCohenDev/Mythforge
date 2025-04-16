namespace GameContent.Abilities.Thief;

public class ClimbWalls : ThiefAbility
{
    public override string Name => "Climb Walls";

    public override int GetSuccessChance(int thiefLevel)
    {
        return thiefLevel switch
        {
            1 => 80,
            2 => 81,
            3 => 82,
            4 => 83,
            5 => 84,
            6 => 85,
            7 => 86,
            8 => 87,
            9 => 88,
            10 => 89,
            11 => 90,
            12 => 91,
            13 => 92,
            14 => 93,
            15 => 94,
            16 => 95,
            17 => 96,
            18 => 97,
            19 => 98,
            _ => 99,
        };
    }
    
    public override string Description =>
        "permits the Thief to climb sheer surfaces with few or no visible handholds. This ability should normally be rolled by the player. If the roll fails, the Thief falls from about halfway up the wall or other vertical surface. The GM may require multiple rolls if the distance climbed is more than 100 feet.";
}