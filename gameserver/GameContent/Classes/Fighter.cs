using GameContent.Scripts;
using ScriptApi;

namespace GameContent.Classes;

public class Fighter : Class
{
    public class FighterClassLevel : ClassLevel {}
    public override string Name { get; init; } = "Fighter";

    public override bool ValidateScores(AttributeScores scores) =>
        scores.Strength >= 9;
    
    public override Dictionary<SavingThrow, int> GetSaveScores(int level)
    {
        return level switch
        {
            0 => new Dictionary<SavingThrow, int>()
            {
                { SavingThrow.DeathRayPoison, 13 },
                { SavingThrow.MagicWands, 14 },
                { SavingThrow.ParalysisPetrify, 15 },
                { SavingThrow.DragonBreath, 16 },
                { SavingThrow.Spells, 18 },
            },
            1 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 12 },
                { SavingThrow.MagicWands, 13 },
                { SavingThrow.ParalysisPetrify, 14 },
                { SavingThrow.DragonBreath, 15 },
                { SavingThrow.Spells, 17 },
            },
            >= 2 and <= 3 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 11 },
                { SavingThrow.MagicWands, 12 },
                { SavingThrow.ParalysisPetrify, 14 },
                { SavingThrow.DragonBreath, 15 },
                { SavingThrow.Spells, 16 },
            },
            >= 4 and <= 5 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 11 },
                { SavingThrow.MagicWands, 11 },
                { SavingThrow.ParalysisPetrify, 13 },
                { SavingThrow.DragonBreath, 14 },
                { SavingThrow.Spells, 15 },
            },
            >= 6 and <= 7 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 10 },
                { SavingThrow.MagicWands, 11 },
                { SavingThrow.ParalysisPetrify, 12 },
                { SavingThrow.DragonBreath, 14 },
                { SavingThrow.Spells, 15 },
            },
            >= 8 and <= 9 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 9 },
                { SavingThrow.MagicWands, 10 },
                { SavingThrow.ParalysisPetrify, 12 },
                { SavingThrow.DragonBreath, 13 },
                { SavingThrow.Spells, 14 },
            },
            >= 10 and <= 11 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 9 },
                { SavingThrow.MagicWands, 9 },
                { SavingThrow.ParalysisPetrify, 11 },
                { SavingThrow.DragonBreath, 12 },
                { SavingThrow.Spells, 13 },
            },
            >= 12 and <= 13 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 8 },
                { SavingThrow.MagicWands, 9 },
                { SavingThrow.ParalysisPetrify, 10 },
                { SavingThrow.DragonBreath, 12 },
                { SavingThrow.Spells, 13 },
            },
            >= 14 and <= 15 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 7 },
                { SavingThrow.MagicWands, 8 },
                { SavingThrow.ParalysisPetrify, 10 },
                { SavingThrow.DragonBreath, 11 },
                { SavingThrow.Spells, 12 },
            },
            >= 16 and <= 17 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 7 },
                { SavingThrow.MagicWands, 7 },
                { SavingThrow.ParalysisPetrify, 9 },
                { SavingThrow.DragonBreath, 10 },
                { SavingThrow.Spells, 11 },
            },
            >= 18 and <= 19 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 6 },
                { SavingThrow.MagicWands, 7 },
                { SavingThrow.ParalysisPetrify, 8 },
                { SavingThrow.DragonBreath, 10 },
                { SavingThrow.Spells, 11 },
            },
            _ => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 5 },
                { SavingThrow.MagicWands, 6 },
                { SavingThrow.ParalysisPetrify, 8 },
                { SavingThrow.DragonBreath, 9 },
                { SavingThrow.Spells, 10 },
            }
        };
    }

    public override Dictionary<int, ClassLevel> Levels => new(){
        {1, new FighterClassLevel{
            RequiredExperience = 0,
            HitDice = "1d8",
            AbilityBonus = 1
        }},
        {2, new FighterClassLevel{
            RequiredExperience = 2_000,
            HitDice = "2d8",
            AbilityBonus = 2
        }},
        {3, new FighterClassLevel{
            RequiredExperience = 4_000,
            HitDice = "3d8",
            AbilityBonus = 2
        }},
        {4, new FighterClassLevel{
            RequiredExperience = 8_000,
            HitDice = "4d8",
            AbilityBonus = 3
        }},
        {5, new FighterClassLevel{
            RequiredExperience = 16_000,
            HitDice = "5d8",
            AbilityBonus = 4
        }},
        {6, new FighterClassLevel{
            RequiredExperience = 32_000,
            HitDice = "6d8",
            AbilityBonus = 4
        }},
        {7, new FighterClassLevel{
            RequiredExperience = 64_000,
            HitDice = "7d8",
            AbilityBonus = 5
        }},
        {8, new FighterClassLevel{
            RequiredExperience = 120_000,
            HitDice = "8d8",
            AbilityBonus = 6
        }},
        {9, new FighterClassLevel{
            RequiredExperience = 240_000,
            HitDice = "9d8",
            AbilityBonus = 6
        }},
        {10, new FighterClassLevel{
            RequiredExperience = 360_000,
            HitDice = "9d8+2",
            AbilityBonus = 6
        }},
        {11, new FighterClassLevel{
            RequiredExperience = 480_000,
            HitDice = "9d8+4",
            AbilityBonus = 7
        }},
        {12, new FighterClassLevel{
            RequiredExperience = 600_000,
            HitDice = "9d8+6",
            AbilityBonus = 7
        }},
        {13, new FighterClassLevel{
            RequiredExperience = 720_000,
            HitDice = "9d8+8",
            AbilityBonus = 8
        }},
        {14, new FighterClassLevel{
            RequiredExperience = 840_000,
            HitDice = "9d8+10",
            AbilityBonus = 8
        }},
        {15, new FighterClassLevel{
            RequiredExperience = 960_000,
            HitDice = "9d8+12",
            AbilityBonus = 8
        }},
        {16, new FighterClassLevel{
            RequiredExperience = 1_080_000,
            HitDice = "9d8+14",
            AbilityBonus = 9
        }},
        {17, new FighterClassLevel{
            RequiredExperience = 1_200_000,
            HitDice = "9d8+16",
            AbilityBonus = 9
        }},
        {18, new FighterClassLevel{
            RequiredExperience = 1_320_000,
            HitDice = "9d8+18",
            AbilityBonus = 10
        }},
        {19, new FighterClassLevel{
            RequiredExperience = 1_440_000,
            HitDice = "9d8+20",
            AbilityBonus = 10
        }},
        {20, new FighterClassLevel{
            RequiredExperience = 1_560_000,
            HitDice = "9d8+22",
            AbilityBonus = 10
        }}
    };

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