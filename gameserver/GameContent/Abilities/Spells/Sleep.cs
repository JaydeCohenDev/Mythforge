using GameContent.Util;
using ScriptApi;

namespace GameContent.Abilities.Spells;

public class Sleep : Spell
{
    public override string Name => "Sleep";

    public override AbilityRange GetRange(Entity caster) => new RangeInFeet(90);

    public override SpellDuration GetDuration(Entity caster) =>
        new Rounds(5 * caster.GetLevel());

    public override string Description =>
        new Message()
            .AppendLine(
                "This spell puts several creatures of 3 or fewer hit dice into a magical slumber. Creatures of 4 or more hit dice are not affected. The caster chooses a point of origin for the spell (within the given range, of course), and those creatures within 30’ of the chosen point may be affected. Each creature in the area of effect is allowed a save vs. Spells to resist the effect.")
            .AppendLine(
                "Sleeping creatures are helpless. Slapping or wounding awakens an affected creature, but normal noise does not. Sleep does not affect unconscious creatures, constructs, or undead creatures, and such creatures in the area of effect are ignored.")
            .AppendLine(
                "When the duration elapses, the sleeping creatures normally wake up immediately; however, if they are made very comfortable and the surroundings are quiet, the affected creatures may continue sleeping normally, at the GM’s option.")
            .Build();

}