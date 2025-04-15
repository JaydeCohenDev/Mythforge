using ScriptApi;

namespace GameContent.Classes;

public class Cleric : Class
{
    public override string Name { get; init; } = "Cleric";

    public override Message GetDescription()
    {
        return new Message()
            .AppendLine(
                "<b>Clerics</b> are devout champions of faith, serving gods, pantheons, or spiritual ideals. While many minister in temples and towns, some are called to the front lines—turning back undead horrors, healing the wounded, and smiting evil in their deity’s name.")
            .AppendBreak()
            .AppendLine("> <b>Role</b>: Divine warrior and healer; protects allies and repels darkness")
            .AppendLine("> <b>Combat Ability</b>: Moderate (better than Thieves, weaker than Fighters)")
            .AppendLine("> <b>Durability</b>: Hardy, especially at lower levels")
            .AppendLine("> <b>Spellcasting</b>: Gains divine spells starting at <b>2nd level</b>")
            .AppendLine("> <b>Special Ability</b>: <b>Turn Undead</b> — repel undead creatures with holy power")
            .AppendLine("> <b>Prime Requisite</b>: <b>Wisdom</b> (minimum score of 9 required)")
            .AppendLine("> <b>Armor</b>: May wear any armor")
            .AppendLine(
                "> <b>Weapons</b>: Restricted to blunt weapons (e.g., warhammer, mace, maul, club, quarterstaff, sling)");
    }
}