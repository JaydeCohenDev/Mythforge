using GameContent.Abilities;
using GameContent.Abilities.Passive;
using GameContent.Classes;
using GameContent.Scripts;
using ScriptApi;
using ScriptApi.Ability;

namespace GameContent.Races;

public class Elf : Race
{
    public override string Name { get; } = "Elf";
    public override int? MaxHitPointsDie => 6;
    public override List<Class> AllowedClasses => [
        Class.Cleric, Class.Fighter, Class.MagicUser, Class.Thief
    ];

    public override int GetSavingThrowBonus(SavingThrow savingThrow)
    {
        if(savingThrow == SavingThrow.MagicWands) return 2;
        if(savingThrow == SavingThrow.ParalysisPetrify) return 1;
        if(savingThrow == SavingThrow.Spells) return 2;
        return base.GetSavingThrowBonus(savingThrow);
    }

    public override bool ValidateScores(AttributeScores scores)
    {
        return 
            scores.Intelligence >= 9 &&
            scores.Constitution <= 17;
    }

    public override List<Ability> GetDefaultAbilities() =>
        [new Darkvision(60), new ElvenSight(), new ElvenImmunity(), new ElvenAwareness()];

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