using GameContent.Util;
using ScriptApi;

namespace GameContent.Abilities.Spells;

public class Shield : Spell
{
    public override string Name => "Shield";

    public override AbilityRange GetRange(Entity caster) => new Self();

    public override SpellDuration GetDuration(Entity caster) =>
        new Rounds(5 + caster.GetLevel());

    public override string Description =>
        "Shield creates an invisible, shield-like mobile disk of force that hovers in front of the caster. It negates <b>magic missile</b> attacks directed at the caster, and improves the caster’s Armor Class by +3 vs. melee attacks and +6 vs. missile weapons. The Armor Class benefits do not apply to attacks originating from behind the caster, but <b>magic missiles</b> are warded off from all directions.";


}