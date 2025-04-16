namespace GameContent.Abilities.Thief;

public class RemoveTraps : ThiefAbility
{
    public override string Name => "Remove Traps";

    public override int GetSuccessChance(int thiefLevel)
    {
        return thiefLevel switch
        {
            1 => 20,
            2 => 25,
            3 => 30,
            4 => 35,
            5 => 40,
            6 => 45,
            7 => 50,
            8 => 55,
            9 => 60,
            10 => 63,
            11 => 66,
            12 => 69,
            13 => 72,
            14 => 75,
            15 => 78,
            16 => 79,
            17 => 80,
            18 => 81,
            19 => 82,
            _ => 83,
        };
    }
    
    public override string Description =>
        "Generally rolled twice: first to detect the trap, and second to disarm it. The GM will make these rolls as the player won’t know for sure if the character is successful or not until someone actually tests the trapped (or suspected) area.";
}