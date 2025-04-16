namespace GameContent.Abilities.Thief;

public class OpenLocks : ThiefAbility
{
    public override string Name => "Open Locks";

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
            16 => 84,
            17 => 85,
            18 => 86,
            19 => 87,
            _ => 88,
        };
    }
    
    public override string Description =>
        "Allows the Thief to unlock a lock without a proper key. It may only be tried once per lock. If the attempt fails, the Thief must wait until he or she has gained another level of experience before trying again.";
}