using ScriptApi.Ability;

namespace GameContent.Abilities;

public class HalflingCourage : PassiveAbility
{
    public override string Name => "Halfling Courage";
    public override string Description => "When attacked in melee by creatures larger than man-sized, Halflings gain a +2 bonus to their Armor Class.";
}