using GameContent.Util;
using ScriptApi;

namespace GameContent.Abilities.Spells;

public class HoldPortal : Spell
{
    public override string Name => "Hold Portal";

    public override AbilityRange GetRange(Entity caster) =>
        new RangeInFeet(100 + caster.GetLevel() * 10);

    public override SpellDuration GetDuration(Entity caster) =>
        new Rounds(caster.GetLevel());
    
    public override string Description =>
        "This spell magically holds shut a door, gate, window, or shutter of wood, metal, or stone. The magic affects the portal just as if it were securely closed and normally locked. A <b>knock</b> spell or a successful <b>dispel magic</b> spell can negate a hold portal spell.";
}