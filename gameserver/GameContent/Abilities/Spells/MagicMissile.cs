using GameContent.Util;
using ScriptApi;

namespace GameContent.Abilities.Spells;

public class MagicMissile : Spell
{
    public override string Name => "Magic Missile";

    public override AbilityRange GetRange(Entity caster) => 
        new RangeInFeet(100 + caster.GetLevel() * 10);

    public override SpellDuration GetDuration(Entity caster) => new Instantaneous();
    
    public override string Description =>
        "This spell causes a missile of magical energy to dart forth from the caster’s fingertip and strike its target, which must be at least partially visible to the caster, dealing 1d6+1 points of damage. The missile strikes unerringly. Specific parts of a creature can’t be singled out. Inanimate objects are not damaged by the spell.<br/>For every three caster levels beyond 1st, an additional missile is fired – two at 4th level, three at 7th, four at 10th, and the maximum of five missiles at 13th level or higher. If the caster fires multiple missiles, he or she can target a single creature or several creatures. A single missile can strike only one creature. Targets must be designated before damage is rolled.";
}