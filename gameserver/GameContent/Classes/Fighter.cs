using ScriptApi;

namespace GameContent.Classes;

public class Fighter : Class
{
    public override string Name { get; init; } = "Fighter";
    
    public override Message GetDescription()
    {
        return new Message()
            .AppendLine(
                "<b>Fighters</b> are warriors born of battle—soldiers, mercenaries, barbarian raiders, and champions who meet danger with steel in hand. Trained for war and hardened by violence, they are unmatched in martial skill and sheer toughness.")
            .AppendBreak()
            .AppendLine("> <b>Role</b>: Frontline combatant and weapon master")
            .AppendLine("> <b>Combat Ability</b>: Best of all classes")
            .AppendLine("> <b>Durability</b>: Highest hit points; toughest class")
            .AppendLine("> <b>Spellcasting</b>: None, but can use many magical weapons and armor")
            .AppendLine("> <b>Prime Requisite</b>: <b>Strength</b> (minimum score of 9 required)")
            .AppendLine("> <b>Armor</b>: May wear any armor")
            .AppendLine(
                "> <b>Weapons</b>: May use any weapon");
    }
}