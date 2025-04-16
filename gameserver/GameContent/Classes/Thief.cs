using GameContent.Abilities.Thief;
using GameContent.Scripts;
using ScriptApi;
using ScriptApi.Ability;
using Shield = GameContent.Scripts.Shield;

namespace GameContent.Classes;

public class Thief : Class
{
    public class ThiefClassLevel : ClassLevel {}
    public override string Name { get; init; } = "Thief";

    public override bool ValidateScores(AttributeScores scores) =>
        scores.Dexterity >= 9;

    public override bool CanUseArmor(Armor armor) =>
        !armor.IsMetal;

    public override bool CanUseShield(Shield shield) => false;

    public override List<Ability> GetDefaultAbilities() => [
        new OpenLocks(), new RemoveTraps(), new PickPockets(),
        new MoveSilently(), new ClimbWalls(), new Hide(), new Listen(),
        new SneakAttack()
    ];

    public override Dictionary<int, ClassLevel> Levels => new()
    {
        {1, new ThiefClassLevel{
            RequiredExperience = 0,
            HitDice = "1d4",
            AbilityBonus = 1,
        }},
        {2, new ThiefClassLevel{
            RequiredExperience = 1_250,
            HitDice = "2d4",
            AbilityBonus = 1,
        }},
        {3, new ThiefClassLevel{
            RequiredExperience = 2_500,
            HitDice = "3d4",
            AbilityBonus = 2,
        }},
        {4, new ThiefClassLevel{
            RequiredExperience = 5_000,
            HitDice = "4d4",
            AbilityBonus = 2,
        }},
        {5, new ThiefClassLevel{
            RequiredExperience = 10_000,
            HitDice = "5d4",
            AbilityBonus = 3,
        }},
        {6, new ThiefClassLevel{
            RequiredExperience = 20_000,
            HitDice = "6d4",
            AbilityBonus = 3,
        }},
        {7, new ThiefClassLevel{
            RequiredExperience = 40_000,
            HitDice = "7d4",
            AbilityBonus = 4,
        }},
        {8, new ThiefClassLevel{
            RequiredExperience = 75_000,
            HitDice = "8d4",
            AbilityBonus = 4,
        }},
        {9, new ThiefClassLevel{
            RequiredExperience = 150_000,
            HitDice = "9d4",
            AbilityBonus = 5,
        }},
        {10, new ThiefClassLevel{
            RequiredExperience = 225_000,
            HitDice = "9d4+2",
            AbilityBonus = 5,
        }},
        {11, new ThiefClassLevel{
            RequiredExperience = 300_000,
            HitDice = "9d4+4",
            AbilityBonus = 5,
        }},
        {12, new ThiefClassLevel{
            RequiredExperience = 375_000,
            HitDice = "9d4+6",
            AbilityBonus = 6,
        }},
        {13, new ThiefClassLevel{
            RequiredExperience = 450_000,
            HitDice = "9d4+8",
            AbilityBonus = 6,
        }},
        {14, new ThiefClassLevel{
            RequiredExperience = 525_000,
            HitDice = "9d4+10",
            AbilityBonus = 6,
        }},
        {15, new ThiefClassLevel{
            RequiredExperience = 600_000,
            HitDice = "9d4+12",
            AbilityBonus = 7,
        }},
        {16, new ThiefClassLevel{
            RequiredExperience = 675_000,
            HitDice = "9d4+14",
            AbilityBonus = 7,
        }},
        {17, new ThiefClassLevel{
            RequiredExperience = 750_000,
            HitDice = "9d4+16",
            AbilityBonus = 7,
        }},
        {18, new ThiefClassLevel{
            RequiredExperience = 825_000,
            HitDice = "9d4+18",
            AbilityBonus = 8,
        }},
        {19, new ThiefClassLevel{
            RequiredExperience = 900_000,
            HitDice = "9d4+20",
            AbilityBonus = 8,
        }},
        {20, new ThiefClassLevel{
            RequiredExperience = 975_000,
            HitDice = "9d4+22",
            AbilityBonus = 8,
        }},
    };
    
    public override Dictionary<SavingThrow, int> GetSaveScores(int level)
    {
        return level switch
        {
            1 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 13 },
                { SavingThrow.MagicWands, 14 },
                { SavingThrow.ParalysisPetrify, 13 },
                { SavingThrow.DragonBreath, 16 },
                { SavingThrow.Spells, 15 },
            },
            >= 2 and <= 3 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 12 },
                { SavingThrow.MagicWands, 14 },
                { SavingThrow.ParalysisPetrify, 12 },
                { SavingThrow.DragonBreath, 15 },
                { SavingThrow.Spells, 14 },
            },
            >= 4 and <= 5 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 11 },
                { SavingThrow.MagicWands, 13 },
                { SavingThrow.ParalysisPetrify, 12 },
                { SavingThrow.DragonBreath, 14 },
                { SavingThrow.Spells, 13 },
            },
            >= 6 and <= 7 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 11 },
                { SavingThrow.MagicWands, 13 },
                { SavingThrow.ParalysisPetrify, 11 },
                { SavingThrow.DragonBreath, 13 },
                { SavingThrow.Spells, 13 },
            },
            >= 8 and <= 9 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 10 },
                { SavingThrow.MagicWands, 12 },
                { SavingThrow.ParalysisPetrify, 11 },
                { SavingThrow.DragonBreath, 12 },
                { SavingThrow.Spells, 12 },
            },
            >= 10 and <= 11 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 9 },
                { SavingThrow.MagicWands, 12 },
                { SavingThrow.ParalysisPetrify, 10 },
                { SavingThrow.DragonBreath, 11 },
                { SavingThrow.Spells, 11 },
            },
            >= 12 and <= 13 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 9 },
                { SavingThrow.MagicWands, 10 },
                { SavingThrow.ParalysisPetrify, 10 },
                { SavingThrow.DragonBreath, 10 },
                { SavingThrow.Spells, 11 },
            },
            >= 14 and <= 15 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 8 },
                { SavingThrow.MagicWands, 10 },
                { SavingThrow.ParalysisPetrify, 9 },
                { SavingThrow.DragonBreath, 9 },
                { SavingThrow.Spells, 10 },
            },
            >= 16 and <= 17 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 7 },
                { SavingThrow.MagicWands, 9 },
                { SavingThrow.ParalysisPetrify, 9 },
                { SavingThrow.DragonBreath, 8 },
                { SavingThrow.Spells, 9 },
            },
            >= 18 and <= 19 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 7 },
                { SavingThrow.MagicWands, 9 },
                { SavingThrow.ParalysisPetrify, 8 },
                { SavingThrow.DragonBreath, 7 },
                { SavingThrow.Spells, 9 },
            },
            _ => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 6 },
                { SavingThrow.MagicWands, 8 },
                { SavingThrow.ParalysisPetrify, 8 },
                { SavingThrow.DragonBreath, 6 },
                { SavingThrow.Spells, 8 },
            }
        };
    }
    
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