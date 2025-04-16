namespace GameContent.Abilities.Thief;

public class MoveSilently : ThiefAbility
{
    public override string Name => "Move Silently";

    public override int GetSuccessChance(int thiefLevel)
    {
        return thiefLevel switch
        {
            1 => 25,
            2 => 30,
            3 => 35,
            4 => 40,
            5 => 45,
            6 => 50,
            7 => 55,
            8 => 60,
            9 => 65,
            10 => 68,
            11 => 71,
            12 => 74,
            13 => 77,
            14 => 80,
            15 => 83,
            16 => 85,
            17 => 87,
            18 => 89,
            19 => 91,
            _ => 93,
        };
    }
    
    public override string Description =>
        "Like Remove Traps, is always rolled by the GM. The Thief will usually believe he or she is moving silently regardless of the die roll, but those he or she is trying to avoid will hear the Thief if the roll is failed.";
}