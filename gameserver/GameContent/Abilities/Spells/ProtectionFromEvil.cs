using GameContent.Util;
using ScriptApi;

namespace GameContent.Abilities.Spells;

public class ProtectionFromEvil : Spell
{
    public override string Name => "Protection From Evil";

    public override AbilityRange GetRange(Entity caster) => new Touch();

    public override SpellDuration GetDuration(Entity caster) =>
        new Turns(caster.GetLevel());

    public override string Description =>
        new Message()
            .AppendLine(
                "This spell wards a creature from attacks by evil creatures, from mental control, and from summoned creatures. It creates a magical barrier around the subject at a distance of 1 foot. The barrier moves with the subject and has three major effects.")
            .AppendLine(
                "First, the subject gains a +2 bonus to AC and a +2 bonus on saves. Both these bonuses apply against attacks made or effects created by evil creatures. Note that the definition of “evil” is left to the individual GM to decide.")
            .AppendLine(
                "Second, the barrier blocks any attempt to possess the warded creature (by a magic jar attack, for example) or to exercise mental control over the creature (including charm spells or effects). The protection does not prevent such effects from targeting the protected creature, but it suppresses the effect for the duration of the protection from evil effect. If the protection from evil effect ends before the effect granting control does, the would-be controller would then be able to command the controlled creature. Likewise, the barrier keeps out a possessing life force but does not expel one if it is in place before the spell is cast.")
            .AppendLine(
                "Third, the spell prevents bodily contact by summoned creatures (regardless of whether they are “evil” or not). This causes the natural weapon attacks of such creatures to fail and the creatures to recoil if such attacks require touching the warded creature. The protection against contact by summoned creatures ends if the warded creature makes an attack against or tries to force the barrier against the blocked creature.")
            .AppendLine(
                "Reversed, this spell becomes <b>protection from good</b>. It functions in all ways as described above, save that “good” creatures are kept away, rather than “evil” creatures.")
            .Build();

}