using ScriptApi;

namespace GameContent.Abilities.Spells;

public class MagicMouth : Spell
{
    public override string Name => "Magic Mouth";

    public override AbilityRange GetRange(Entity caster) => new RangeInFeet(30);

    public override SpellDuration GetDuration(Entity caster) => new Special();
    
    public override string Description =>
        "This spell imbues the chosen non-living object with an enchanted mouth that suddenly appears and speaks its message the next time a specified event occurs. The message, which may be up to three words per caster level long, can be in any language known by the caster and can be delivered over a period of 10 minutes, at any volume from a whisper to a yell. The voice will resemble the caster’s, but will not be identical. The mouth cannot use command words or activate magical effects. It does, however, move according to the words articulated; if it were placed upon a statue, the mouth of the statue would move and appear to speak. Of course, magic mouth can be placed upon a tree, rock, or any other object.<br/>The spell functions when specific conditions are fulfilled according to the caster’s command as set in the spell. Commands can be as general or as detailed as desired, although only visual and audible triggers can be used. Triggers react to what appears to be the case. Disguises and illusions can fool them. Normal darkness does not defeat a visual trigger, but magical darkness or invisibility does. Silent movement or magical silence defeats audible triggers. Audible triggers can be keyed to general types of noises or to a specific noise or spoken word. Actions can serve as triggers if they are visible or audible. A magic mouth cannot distinguish level, hit dice, or class except by external garb.<br/>The range limit of a trigger is 10 feet per caster level, so a 6th-level caster can command a magic mouth to respond to triggers as far as 60 feet away. Regardless of range, the mouth can respond only to visible or audible triggers and actions in line of sight or within hearing distance.";
}