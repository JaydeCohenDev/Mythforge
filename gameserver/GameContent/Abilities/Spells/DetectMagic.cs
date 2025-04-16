using ScriptApi;

namespace GameContent.Abilities.Spells;

public class DetectMagic : Spell
{
    public override string Name => "Detect Magic";
    public override AbilityRange GetRange(Entity caster) => new RangeInFeet(60);
    public override SpellDuration GetDuration(Entity caster) => new Turns(2);
    public override string Description =>
        "The caster of this spell is able to detect enchanted or enspelled objects or creatures within the given range by sight, seeing them surrounded by a pale glowing light. Only the caster sees the glow. Invisible creatures or objects are not detected by this spell, but the emanations of the invisibility magic will be seen as an amorphous glowing fog, possibly allowing the caster (only) to attack the invisible creature at an attack penalty of only -2.";
}