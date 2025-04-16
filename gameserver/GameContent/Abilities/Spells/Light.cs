using GameContent.Util;
using ScriptApi;

namespace GameContent.Abilities.Spells;

public class Light : Spell
{
    public override string Name => "Light";

    public override AbilityRange GetRange(Entity caster) => new RangeInFeet(120);

    public override SpellDuration GetDuration(Entity caster) =>
        new Turns(6 + caster.GetLevel());
    
    public override string Description =>
        "This spell creates a light equal to torchlight which illuminates a 30’ radius area (and provides dim light for an additional 20’) around the target location or object. The effect is immobile if cast into an area, but it can be cast on a movable object. Light taken into an area of magical darkness does not function.<br/>Reversed, <b>light</b> becomes <b>darkness</b>, creating an area of darkness just as described above. This darkness blocks out Darkvision and negates mundane light sources.<br/>A light spell may be cast to counter and dispel the darkness spell of an equal or lower level caster (and vice versa). Doing so causes both spells to instantly cease, restoring the existing ambient light level.<br/>Either version of this spell may be used to blind an opponent by means of casting it on the target’s ocular organs. The target is allowed a saving throw vs. Death Ray to avoid the effect, and if the save is made, the spell does not take effect at all. A <b>light</b> or <b>darkness</b> spell cast to blind does not have the given area of effect (that is, no light or darkness is shed around the victim).";
}