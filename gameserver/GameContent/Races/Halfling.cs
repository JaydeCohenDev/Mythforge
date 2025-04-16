using GameContent.Abilities;
using GameContent.Abilities.Passive;
using GameContent.Classes;
using GameContent.Scripts;
using ScriptApi;
using ScriptApi.Ability;

namespace GameContent.Races;

public class Halfling : Race
{
    public override string Name { get; } = "Halfling";
    public override List<Class> AllowedClasses => [
        Class.Cleric, Class.Fighter, Class.Thief
    ];

    public override int? MaxHitPointsDie => 6;

    public override int RequiredHandsToWield(Weapon weapon)
    {
        if(weapon.Size == WeaponSize.Medium) return 2;
        return base.RequiredHandsToWield(weapon);
    }

    public override bool CanWield(Weapon weapon)
    {
        return weapon.Size < WeaponSize.Large;
    }

    public override int GetSavingThrowBonus(SavingThrow savingThrow)
    {
        if(savingThrow == SavingThrow.DeathRayPoison) return 4;
        if(savingThrow == SavingThrow.MagicWands) return 4;
        if(savingThrow == SavingThrow.ParalysisPetrify) return 4;
        if(savingThrow == SavingThrow.Spells) return 4;
        if(savingThrow == SavingThrow.DragonBreath) return 3;
        return base.GetSavingThrowBonus(savingThrow);
    }

    public override bool ValidateScores(AttributeScores scores)
    {
        return 
            scores.Dexterity >= 9 &&
            scores.Strength <= 17;
    }

    public override List<Ability> GetDefaultAbilities() => [
        new HalflingAccuracy(), new HalflingCourage(), new HalflingHiding(), new HalflingWit()
    ];

    public override Message GetDescription()
    {
        return new Message()
            .AppendLine(
                "<b>Halflings</b> are cheerful and nimble folk, small in stature but surprisingly hardy. Known for their quiet steps and warm hearts, they cherish simple joys and peaceful lives, walking barefoot along sunlit paths for a century or more.").AppendBreak()
            .Append("> ").Append("Height: ", new TextBold()).AppendLine("~3 feet tall")
            .Append("> ").Append("Weight: ", new TextBold()).AppendLine("~60 pounds")
            .Append("> ").Append("Lifespan: ", new TextBold()).AppendLine("~100 years")
            .Append("> ").Append("Appearance: ", new TextBold()).AppendLine(
                "Curly brown hair (head and feet), fair skin with ruddy cheeks, little to no facial hair")
            .Append("> ").Append("Temperament: ", new TextBold())
            .AppendLine("Outgoing, unassuming, good-natured")
            .Append("> ").Append("Traits: ", new TextBold())
            .AppendLine("Rugged for their size, dexterous, nimble, move quietly, remain very still when needed")
            .Append("> ").Append("Culture: ", new TextBold())
            .AppendLine("Enjoy simple pleasures, tight-knit communities, and the comforts of home")
            .Append("> ").Append("Common habitats: ", new TextBold())
            .AppendLine("Rural villages, rolling hills, and peaceful countryside").AppendBreak()

            .AppendLine("Restrictions", new TextUnderline())
            .AppendLine("> Can not become a Magic-User")
            .AppendLine("> Must have a minimum Dexterity of 9")
            .AppendLine("> Strength score limited to 17")
            .AppendLine("> Hit points die limited to d6")
            .AppendLine("> May not use Large weapons")
            .AppendLine("> Medium weapons must be wielded with two hands").AppendBreak()

            .AppendLine("Special Abilities", new TextUnderline())
            .AppendLine("> +1 attack bonus with ranged weapons")
            .AppendLine("> +2 AC when attacking a creature sized greater than medium")
            .AppendLine("> +1 initiative")
            .AppendLine("> 90% hide effectiveness in forest terrain")
            .AppendLine("> 70% hide effectiveness in other terrain or indoors").AppendBreak()

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