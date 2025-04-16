using GameContent.Abilities;
using GameContent.Classes;
using ScriptApi;
using ScriptApi.Ability;

namespace GameContent.Races;

public class Human : Race
{
    public override string Name { get; } = "Human";
    public override List<Class> AllowedClasses => [
        Class.Cleric, Class.Fighter, Class.MagicUser, Class.Thief
    ];

    public override List<Ability> GetDefaultAbilities() => [
        new HumanLearning()
    ];

    public override Message GetDescription()
    {
        return new Message()
            .AppendLine(
                "<b>Humans</b> are a diverse and ambitious race, ever adapting to the world around them. With short lives but boundless drive, they build kingdoms, forge legends, and shape the fate of the realms.").AppendBreak()
            .Append("> ").Append("Height: ", new TextBold()).AppendLine("~6 feet tall (male average)")
            .Append("> ").Append("Weight: ", new TextBold()).AppendLine("~175 pounds (male average)")
            .Append("> ").Append("Lifespan: ", new TextBold()).AppendLine("~75 years")
            .Append("> ").Append("Appearance: ", new TextBold()).AppendLine(
                "Highly varied in build, complexion, and features — shaped by region and culture")
            .Append("> ").Append("Temperament: ", new TextBold())
            .AppendLine("Determined, adaptable, driven by curiosity and ambition")
            .Append("> ").Append("Traits: ", new TextBold())
            .AppendLine("Resourceful, versatile, capable of great heroism or treachery")
            .Append("> ").Append("Culture: ", new TextBold())
            .AppendLine("Widely diverse, from humble villages to mighty empires")
            .Append("> ").Append("Common habitats: ", new TextBold())
            .AppendLine("Everywhere — forests, plains, mountains, cities, and beyond").AppendBreak()

            .AppendLine("Restrictions", new TextUnderline())
            .AppendLine("> None").AppendBreak()

            .AppendLine("Special Abilities", new TextUnderline())
            .AppendLine("> +10% experience gain").AppendBreak()

            .AppendLine("Saving Throws", new TextUnderline())
            .AppendLine("> No bonuses");
    }
}