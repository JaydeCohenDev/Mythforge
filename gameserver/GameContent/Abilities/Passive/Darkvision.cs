using ScriptApi.Ability;

namespace GameContent.Abilities.Passive;

public class Darkvision(int rangeInFeet) : PassiveAbility
{
    public override string Name => "Darkvision";
    public override string Description => "Darkvision is the ability to see even in total darkness. Darkvision is black and white only but otherwise like normal sight. Darkvision does not grant one the ability to see in magical darkness.";
    public int RangeInFeet => rangeInFeet;
}
