using ScriptApi;

namespace GameContent.Races;

public class Elf : Race
{
    public override string Name { get; } = "Elf";

    public override Message GetDescription()
    {
        return new Message()
            .AppendLine(
                "<b>Elves</b> are a graceful and long-lived race, marked by their elegance, sharp senses, and otherworldly beauty. Curious and confident, they move through the world with an air of quiet pride, their lives spanning millennia beneath ancient canopies and starlit skies.").AppendBreak()
            .Append("> ").Append("Height: ", new TextBold()).AppendLine("~5 feet tall")
            .Append("> ").Append("Weight: ", new TextBold()).AppendLine("~130 pounds")
            .Append("> ").Append("Lifespan: ", new TextBold()).AppendLine("1200+ years")
            .Append("> ").Append("Appearance: ", new TextBold()).AppendLine(
                "Pale skin, dark hair, pointed ears, delicate features, little to no body or facial hair")
            .Append("> ").Append("Temperament: ", new TextBold())
            .AppendLine("Inquisitive, passionate, self-assured, sometimes haughty")
            .Append("> ").Append("Traits: ", new TextBold())
            .AppendLine("Lithe, graceful, exceptional eyesight and hearing")
            .Append("> ").Append("Culture: ", new TextBold())
            .AppendLine("Deep connection to nature, artistry, and ancient traditions")
            .Append("> ").Append("Common habitats: ", new TextBold())
            .AppendLine("Enchanted forests, hidden groves, and timeless woodland realms").AppendBreak()

            .AppendLine("Restrictions", new TextUnderline())
            .AppendLine("> No class restrictions")
            .AppendLine("> Must have a minimum Intelligence of 9")
            .AppendLine("> Constitution score limited to 17")
            .AppendLine("> Hit points die limited to d6").AppendBreak()

            .AppendLine("Special Abilities", new TextUnderline())
            .AppendLine("> Darkvision: 60 feet")
            .AppendLine(">  Higher chance of finding secret doors")
            .AppendLine(">  Can not be paralyzed by Ghouls")
            .AppendLine(">  Less likely to be surprised in combat").AppendBreak()

            .AppendLine("Saving Throws", new TextUnderline())
            .AppendLine("> +1 vs Paralysis")
            .AppendLine("> +1 vs Petrify")
            .AppendLine("> +2 vs Magic Wands")
            .AppendLine("> +2 vs Spells");

    }
}