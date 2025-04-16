namespace GameContent.Abilities.Thief;

public class PickPockets : ThiefAbility
{
    public override string Name => "Pick Pockets";

    public override int GetSuccessChance(int thiefLevel)
    {
        return thiefLevel switch
        {
            1 => 30,
            2 => 35,
            3 => 40,
            4 => 45,
            5 => 50,
            6 => 55,
            7 => 60,
            8 => 65,
            9 => 70,
            10 => 74,
            11 => 78,
            12 => 82,
            13 => 86,
            14 => 90,
            15 => 94,
            16 => 95,
            17 => 96,
            18 => 97,
            19 => 98,
            _ => 99,
        };
    }
    
    public override string Description =>
        "Allows the Thief to lift the wallet, cut the purse, etc. of a victim without the victim noticing. Obviously, if the roll is failed, the Thief didn’t get what he or she wanted; but further, the intended victim (or an onlooker, at the GM’s option) will notice the attempt if the die roll is more than two times the target number (or if the die roll is 00).";
}