using GameContent.Util;
using ScriptApi;

namespace GameContent.Abilities.Spells;

public class Ventriloquism : Spell
{
    public override string Name => "Ventriloquism";

    public override AbilityRange GetRange(Entity caster) => new RangeInFeet(60);

    public override SpellDuration GetDuration(Entity caster) =>
        new Turns(caster.GetLevel());

    public override string Description =>
        "This spell allows the caster to cause his or her voice to sound from someplace else within range, for example, from a dark alcove or statue.";

}