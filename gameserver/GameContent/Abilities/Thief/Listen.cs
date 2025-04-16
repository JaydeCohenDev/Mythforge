namespace GameContent.Abilities.Thief;

public class Listen : ThiefAbility
{
    public override string Name => "Listen";

    public override int GetSuccessChance(int thiefLevel)
    {
        return thiefLevel switch
        {
            1 => 30,
            2 => 34,
            3 => 38,
            4 => 42,
            5 => 46,
            6 => 50,
            7 => 54,
            8 => 58,
            9 => 62,
            10 => 65,
            11 => 68,
            12 => 71,
            13 => 74,
            14 => 77,
            15 => 80,
            16 => 83,
            17 => 86,
            18 => 89,
            19 => 92,
            _ => 95,
        };
    }
    
    public override string Description =>
        "Generally used to listen at a door, or to try to listen for distant sounds in a dungeon. The GM must decide what noises the Thief might hear; a successful roll means only that a noise could have been heard. The GM should always make this roll for the player. Note that the Thief and his or her party must try to be quiet in order for the Thief to use this ability.";
}