namespace GameContent.Abilities.Thief;

public class Hide : ThiefAbility
{
    public override string Name => "Hide";

    public override int GetSuccessChance(int thiefLevel)
    {
        return thiefLevel switch
        {
            1 => 10,
            2 => 15,
            3 => 20,
            4 => 25,
            5 => 30,
            6 => 35,
            7 => 40,
            8 => 45,
            9 => 50,
            10 => 53,
            11 => 56,
            12 => 59,
            13 => 62,
            14 => 65,
            15 => 68,
            16 => 69,
            17 => 70,
            18 => 71,
            19 => 72,
            _ => 73,
        };
    }
    
    public override string Description =>
        "Permits the Thief to hide in any shadowed area large enough to contain his or her body. Like Move Silently, the Thief always believes he or she is being successful, so the GM makes the roll. A Thief hiding in shadows must remain still for this ability to work.";
}