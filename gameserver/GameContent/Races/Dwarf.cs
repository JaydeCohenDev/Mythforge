using ScriptApi;

namespace GameContent.Races;

public class Dwarf : Race
{
    public override string Name { get; } = "Dwarf";

    public override Message GetDescription()
    {
        return new Message()
            .AppendLine(
                "<b>Dwarves</b> are a proud and unyielding race, known for their strength, resilience, and masterful craftsmanship. Stocky and enduring, they thrive in harsh environments, living long lives shaped by stone and steel. Fiercely loyal yet cautious, they guard their kin and treasures with unwavering devotion.").AppendBreak()
            .Append("> ").Append("Height: ", new TextBold()).AppendLine("~4 feet tall")
            .Append("> ").Append("Weight: ", new TextBold()).AppendLine("~120 pounds")
            .Append("> ").Append("Lifespan: ", new TextBold()).AppendLine("300–400 years")
            .Append("> ").Append("Appearance: ", new TextBold()).AppendLine(
                "Dark brown, gray, or black hair; thick beards often braided or forked; fair to ruddy skin")
            .Append("> ").Append("Temperament: ", new TextBold())
            .AppendLine("Practical, stubborn, courageous; can be introspective, suspicious, and possessive")
            .Append("> ").Append("Traits: ", new TextBold())
            .AppendLine("Muscular build, great endurance, pride in their heritage and craftsmanship")
            .Append("> ").Append("Culture: ", new TextBold())
            .AppendLine("Highly value family, tradition, and the defense of their homes")
            .Append("> ").Append("Common habitats: ", new TextBold())
            .AppendLine("Mountain halls, underground fortresses, rugged highlands").AppendBreak()

            .AppendLine("Restrictions", new TextUnderline())
            .AppendLine("> Can not become a Magic-User")
            .AppendLine("> Must have a minimum Constitution of 9")
            .AppendLine("> Charisma score limited to 17")
            .AppendLine("> Can not wield large weapons longer that 4 feet").AppendBreak()

            .AppendLine("Special Abilities", new TextUnderline())
            .AppendLine("> Darkvision: 60 feet")
            .AppendLine(
                ">  able to detect slanting passages, traps, shifting walls and new construction when searching").AppendBreak()

            .AppendLine("Saving Throws", new TextUnderline())
            .AppendLine("> +4 vs Death Ray")
            .AppendLine("> +4 vs Poison")
            .AppendLine("> +4 vs Magic Wands")
            .AppendLine("> +4 vs Paralysis")
            .AppendLine("> +4 vs Petrify")
            .AppendLine("> +4 vs Spells")
            .AppendLine("> +3 vs Dragon Breath");

    }
}