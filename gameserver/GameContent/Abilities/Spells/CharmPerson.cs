using GameContent.Scripts;
using ScriptApi;

namespace GameContent.Abilities.Spells;

public class CharmPerson : Spell
{
    public override string Name => "Charm Person";
    public override AbilityRange GetRange(Entity caster) => new RangeInFeet(30);
    public override SpellDuration GetDuration(Entity caster) => new Special();
    public override string Description =>
        "This spell makes a humanoid creature of 4 hit dice or less regard the caster as its trusted friend and ally. Humans and demi-humans may be affected, regardless of level of ability. A save vs. Spells will negate the effect. If the creature is currently being threatened or attacked by the caster or his or her allies, it receives a +5 bonus on its saving throw. The spell does not enable the caster to control the charmed person as if it were an automaton; rather, it perceives his or her words and actions in the most favorable way. The caster can try to give the subject orders, but it will not do anything it wouldn’t ordinarily do, and further may receive an additional saving throw to overcome the magic (at the GM’s discretion). The caster must speak the target’s language to communicate any commands, or else be good at pantomiming; of course, if the caster is attacked, the charmed creature will act to protect its “friend” (though that could mean attacking the caster’s enemies, or attempting to carry off the caster to a “safe” place). The target receives a new saving throw each day if it has an Intelligence of 13 or greater, every week if its Intelligence is 9-12, or every month if its Intelligence is 8 or less.";

    public override void Activate(Entity user, Entity target)
    {
        var creature = target.GetScript<CreatureScript>();
        if (creature == null || creature.CreatureType == null)
        {
            user.Tell(new Message("That is not a valid target"));
            return;
        }

        if (creature.CreatureType.HitDice.Num > 4)
        {
            user.Tell(new Message("That creature is too powerful to be affected by this spell"));
            return;
        }

        bool isTargetThreatened = false;

        if (!creature.CreatureType.MakeSavingThrow(SavingThrow.Spells, isTargetThreatened ? 5 : 0))
        {
            user.Tell(new Message($"{target.Name} resists the effects!"));
            return;
        }

        var script = creature.Entity.AttachScript<CharmedScript>();
        script.Master = user;
        
        user.Tell(new Message($"{target.Name} is now charmed and will be receptive to commands. You are their master."));

    }
}