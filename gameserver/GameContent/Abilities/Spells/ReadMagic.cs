using ScriptApi;

namespace GameContent.Abilities.Spells;

public class ReadMagic : Spell
{
    public override string Name => "Read Magic";
    public override SpellDuration GetDuration(Entity caster) => new Permanent();
    public override AbilityRange GetRange(Entity caster) => new Touch();

    public override string Description =>
        "When cast upon any magical text, such as a spellbook or magic-user spell scroll, this spell enables the caster to read that text. Casting this spell on a cursed text will generally trigger the curse. All Magic-Users begin play knowing this spell, and it can be prepared even if the Magic-User loses access to his or her spellbook.";
}