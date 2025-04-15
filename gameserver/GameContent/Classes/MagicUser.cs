using ScriptApi;

namespace GameContent.Classes;

public class MagicUser : Class
{
    public override string Name { get; init; } = "Magic-User";
    
    public override Message GetDescription()
    {
        return new Message()
            .AppendLine(
                "<b>Magic-Users</b> are seekers of arcane power, wielding spells through intellect and study rather than faith. Though frail and poor in combat, they command forces that can shape reality, drawn from ancient tomes and hidden knowledge.")
            .AppendBreak()
            .AppendLine("> <b>Role</b>: Arcane spellcaster and wielder of mystical forces")
            .AppendLine("> <b>Combat Ability</b>: Weakest of all classes in melee")
            .AppendLine("> <b>Durability</b>: Fragile; lowest hit points and no armor")
            .AppendLine("> <b>Spellcasting</b>: Begins with <i>read magic</i> + one 1st-level spell")
            .AppendLine("> <b>Prime Requisite</b>: <b>Intelligence</b> (minimum score of 9 required)")
            .AppendLine("> <b>Armor</b>: May not wear armor or use shields")
            .AppendLine("> <b>Weapons</b>: Limited to dagger and walking staff (or cudgel)")
            .AppendLine("> <b>Spellbook</b>: Starts with spells recorded in a book from their master")
            .AppendLine("> <b>Magic Source</b>: Derived from study, logic, and arcane insight");
    }
}