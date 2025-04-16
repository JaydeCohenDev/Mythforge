using ScriptApi;

namespace GameContent.Abilities.Spells;

public class ReadLanguages : Spell
{
    public override string Name => "Read Languages";

    public override AbilityRange GetRange(Entity caster) => new Touch();

    public override SpellDuration GetDuration(Entity caster) => new Special();

    public override string Description =>
        new Message()
            .AppendLine(
                "This spell grants the caster the ability to read almost any written language. It may be cast in one of three modes:")
            .AppendLine(
                "In the first mode, the spell allows the caster to read any number of written works in a variety of languages. This mode lasts for 1 turn per caster level.")
            .AppendLine(
                "In the second mode, the spell allows the caster to read any one book or tome; this mode lasts 3 hours per caster level.")
            .AppendLine(
                "In the third mode, the spell allows the caster to read any one non-magical scroll or other single-sheet document; this mode is permanent.")
            .AppendLine(
                "This spell does not work on any sort of magical text, such as spell scrolls or spellbooks; see <b>read magic</b>, below, for the correct spell to use in such cases.")
            .AppendLine("The spell grants the ability to read the texts, but does not in any way hasten the reading nor grant understanding of concepts the caster doesn’t otherwise have the ability to understand. Also, for this spell to function, there must be at least one living creature that can read the given language somewhere on the same plane. The knowledge is not copied from that creature’s mind; rather, it is the existence of the knowledge that enables the spell to function.")
            .Build();

}