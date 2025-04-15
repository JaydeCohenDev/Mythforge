using ScriptApi;

namespace GameContent.Classes;

public class Thief : Class
{
    public override string Name { get; init; } = "Thief";
    
    public override Message GetDescription()
    {
        return new Message()
            .AppendLine(
                "<b>Thieves</b> are cunning opportunists who live by their wits, slipping past traps, picking locks, and vanishing into shadows with stolen gold in hand. Masters of stealth and agility, they rely on precision over power—and always keep an eye on the prize.")
            .AppendBreak()
            .AppendLine("> <b>Role</b>: Stealth expert, trap-handler, and opportunistic striker")
            .AppendLine("> <b>Combat Ability</b>: Better than Magic-Users, weaker than Fighters")
            .AppendLine("> <b>Durability</b>: Fragile; hardier than Magic-Users at higher levels")
            .AppendLine(
                "> <b>Spellcasting</b>: Picking pockets, opening locks, disarming traps, moving silently, hiding in shadows, climbing walls, and hearing noises")
            .AppendLine("> <b>Special Ability</b>: <b>Turn Undead</b> — repel undead creatures with holy power")
            .AppendLine("> <b>Prime Requisite</b>: <b>Dexterity</b> (minimum score of 9 required)")
            .AppendLine("> <b>Armor</b>: May wear leather armor only; metal armor and shields are forbidden")
            .AppendLine("> <b>Weapons</b>: May use any weapon")
            .AppendLine("> <b>Style</b>: Prefers subtlety, misdirection, and careful planning over brute force");
    }
}