using GameContent.Scripts;
using ScriptApi;

namespace GameContent.Classes;

public class Cleric : Class
{
    public class ClericClassLevel : ClassLevel
    {
        public required Dictionary<int, int> Spells {get; init;}
    }

    public override string Name { get; init; } = "Cleric";

    public override bool ValidateScores(AttributeScores scores) =>
        scores.Wisdom >= 9;

    public override bool CanWield(Weapon weapon) =>
        weapon.Type == WeaponType.Blunt;

    public override Dictionary<SavingThrow, int> GetSaveScores(int level)
    {
        return level switch
        {
            1 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 11 },
                { SavingThrow.MagicWands, 12 },
                { SavingThrow.ParalysisPetrify, 14 },
                { SavingThrow.DragonBreath, 16 },
                { SavingThrow.Spells, 15 },
            },
            >= 2 and <= 3 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 10 },
                { SavingThrow.MagicWands, 11 },
                { SavingThrow.ParalysisPetrify, 13 },
                { SavingThrow.DragonBreath, 15 },
                { SavingThrow.Spells, 14 },
            },
            >= 4 and <= 5 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 9 },
                { SavingThrow.MagicWands, 10 },
                { SavingThrow.ParalysisPetrify, 13 },
                { SavingThrow.DragonBreath, 15 },
                { SavingThrow.Spells, 14 },
            },
            >= 6 and <= 7 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 9 },
                { SavingThrow.MagicWands, 10 },
                { SavingThrow.ParalysisPetrify, 12 },
                { SavingThrow.DragonBreath, 14 },
                { SavingThrow.Spells, 13 },
            },
            >= 8 and <= 9 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 8 },
                { SavingThrow.MagicWands, 9 },
                { SavingThrow.ParalysisPetrify, 12 },
                { SavingThrow.DragonBreath, 14 },
                { SavingThrow.Spells, 13 },
            },
            >= 10 and <= 11 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 8 },
                { SavingThrow.MagicWands, 9 },
                { SavingThrow.ParalysisPetrify, 11 },
                { SavingThrow.DragonBreath, 13 },
                { SavingThrow.Spells, 12 },
            },
            >= 12 and <= 13 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 7 },
                { SavingThrow.MagicWands, 8 },
                { SavingThrow.ParalysisPetrify, 11 },
                { SavingThrow.DragonBreath, 13 },
                { SavingThrow.Spells, 12 },
            },
            >= 14 and <= 15 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 7 },
                { SavingThrow.MagicWands, 8 },
                { SavingThrow.ParalysisPetrify, 10 },
                { SavingThrow.DragonBreath, 12 },
                { SavingThrow.Spells, 11 },
            },
            >= 16 and <= 17 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 6 },
                { SavingThrow.MagicWands, 7 },
                { SavingThrow.ParalysisPetrify, 10 },
                { SavingThrow.DragonBreath, 11 },
                { SavingThrow.Spells, 10 },
            },
            >= 18 and <= 19 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 6 },
                { SavingThrow.MagicWands, 7 },
                { SavingThrow.ParalysisPetrify, 9 },
                { SavingThrow.DragonBreath, 11 },
                { SavingThrow.Spells, 10 },
            },
            _ => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 5 },
                { SavingThrow.MagicWands, 6 },
                { SavingThrow.ParalysisPetrify, 9 },
                { SavingThrow.DragonBreath, 11 },
                { SavingThrow.Spells, 10 },
            }
        };
    }

    public override Dictionary<int, ClassLevel> Levels => new()
    {
        {1, new ClericClassLevel{
            RequiredExperience = 0,
            HitDice = "1d6",
            AbilityBonus = 1,
            Spells = new Dictionary<int, int>
            {
                {1, 0},
                {2, 0},
                {3, 0},
                {4, 0},
                {5, 0},
                {6, 0}
            }
        }},
        {2, new ClericClassLevel{
            RequiredExperience = 1_500,
            HitDice = "2d6",
            AbilityBonus = 1,
            Spells = new Dictionary<int, int>
            {
                {1, 1},
                {2, 0},
                {3, 0},
                {4, 0},
                {5, 0},
                {6, 0}
            }
        }},
        {3, new ClericClassLevel{
            RequiredExperience = 3_000,
            HitDice = "3d6",
            AbilityBonus = 2,
            Spells = new Dictionary<int, int>
            {
                {1, 2},
                {2, 0},
                {3, 0},
                {4, 0},
                {5, 0},
                {6, 0}
            }
        }},
        {4, new ClericClassLevel{
            RequiredExperience = 6_000,
            HitDice = "4d6",
            AbilityBonus = 2,
            Spells = new Dictionary<int, int>
            {
                {1, 2},
                {2, 1},
                {3, 0},
                {4, 0},
                {5, 0},
                {6, 0}
            }
        }},
        {5, new ClericClassLevel{
            RequiredExperience = 12_000,
            HitDice = "5d6",
            AbilityBonus = 3,
            Spells = new Dictionary<int, int>
            {
                {1, 2},
                {2, 2},
                {3, 0},
                {4, 0},
                {5, 0},
                {6, 0}
            }
        }},
        {6, new ClericClassLevel{
            RequiredExperience = 24_000,
            HitDice = "6d6",
            AbilityBonus = 3,
            Spells = new Dictionary<int, int>
            {
                {1, 2},
                {2, 2},
                {3, 1},
                {4, 0},
                {5, 0},
                {6, 0}
            }
        }},
        {7, new ClericClassLevel{
            RequiredExperience = 48_000,
            HitDice = "7d6",
            AbilityBonus = 4,
            Spells = new Dictionary<int, int>
            {
                {1, 3},
                {2, 2},
                {3, 2},
                {4, 0},
                {5, 0},
                {6, 0}
            }
        }},
        {8, new ClericClassLevel{
            RequiredExperience = 90_000,
            HitDice = "8d6",
            AbilityBonus = 4,
            Spells = new Dictionary<int, int>
            {
                {1, 3},
                {2, 2},
                {3, 2},
                {4, 1},
                {5, 0},
                {6, 0}
            }
        }},
        {9, new ClericClassLevel{
            RequiredExperience = 180_000,
            HitDice = "9d6",
            AbilityBonus = 5,
            Spells = new Dictionary<int, int>
            {
                {1, 3},
                {2, 3},
                {3, 2},
                {4, 2},
                {5, 0},
                {6, 0}
            }
        }},
        {10, new ClericClassLevel{
            RequiredExperience = 270_000,
            HitDice = "9d6+1",
            AbilityBonus = 5,
            Spells = new Dictionary<int, int>
            {
                {1, 3},
                {2, 3},
                {3, 2},
                {4, 2},
                {5, 1},
                {6, 0}
            }
        }},
        {11, new ClericClassLevel{
            RequiredExperience = 360_000,
            HitDice = "9d6+2",
            AbilityBonus = 5,
            Spells = new Dictionary<int, int>
            {
                {1, 4},
                {2, 3},
                {3, 3},
                {4, 2},
                {5, 2},
                {6, 0}
            }
        }},
        {12, new ClericClassLevel{
            RequiredExperience = 450_000,
            HitDice = "9d6+3",
            AbilityBonus = 6,
            Spells = new Dictionary<int, int>
            {
                {1, 4},
                {2, 4},
                {3, 3},
                {4, 2},
                {5, 2},
                {6, 1}
            }
        }},
        {13, new ClericClassLevel{
            RequiredExperience = 540_000,
            HitDice = "9d6+4",
            AbilityBonus = 6,
            Spells = new Dictionary<int, int>
            {
                {1, 4},
                {2, 4},
                {3, 3},
                {4, 3},
                {5, 2},
                {6, 2}
            }
        }},
        {14, new ClericClassLevel{
            RequiredExperience = 630_000,
            HitDice = "9d6+5",
            AbilityBonus = 6,
            Spells = new Dictionary<int, int>
            {
                {1, 4},
                {2, 4},
                {3, 4},
                {4, 3},
                {5, 2},
                {6, 2}
            }
        }},
        {15, new ClericClassLevel{
            RequiredExperience = 720_000,
            HitDice = "9d6+6",
            AbilityBonus = 7,
            Spells = new Dictionary<int, int>
            {
                {1, 4},
                {2, 4},
                {3, 4},
                {4, 3},
                {5, 3},
                {6, 2}
            }
        }},
        {16, new ClericClassLevel{
            RequiredExperience = 810_000,
            HitDice = "9d6+7",
            AbilityBonus = 7,
            Spells = new Dictionary<int, int>
            {
                {1, 5},
                {2, 4},
                {3, 4},
                {4, 3},
                {5, 3},
                {6, 2}
            }
        }},
        {17, new ClericClassLevel{
            RequiredExperience = 900_000,
            HitDice = "9d6+8",
            AbilityBonus = 7,
            Spells = new Dictionary<int, int>
            {
                {1, 5},
                {2, 5},
                {3, 4},
                {4, 3},
                {5, 3},
                {6, 2}
            }
        }},
        {18, new ClericClassLevel{
            RequiredExperience = 990_000,
            HitDice = "9d6+9",
            AbilityBonus = 8,
            Spells = new Dictionary<int, int>
            {
                {1, 5},
                {2, 5},
                {3, 4},
                {4, 4},
                {5, 3},
                {6, 3}
            }
        }},
        {19, new ClericClassLevel{
            RequiredExperience = 1_080_000,
            HitDice = "9d6+10",
            AbilityBonus = 8,
            Spells = new Dictionary<int, int>
            {
                {1, 6},
                {2, 5},
                {3, 4},
                {4, 4},
                {5, 3},
                {6, 3}
            }
        }},
        {20, new ClericClassLevel{
            RequiredExperience = 1_170_000,
            HitDice = "9d6+11",
            AbilityBonus = 8,
            Spells = new Dictionary<int, int>
            {
                {1, 6},
                {2, 5},
                {3, 5},
                {4, 4},
                {5, 3},
                {6, 3}
            }
        }}
    };

    public override Message GetDescription()
    {
        return new Message()
            .AppendLine(
                "<b>Clerics</b> are devout champions of faith, serving gods, pantheons, or spiritual ideals. While many minister in temples and towns, some are called to the front lines—turning back undead horrors, healing the wounded, and smiting evil in their deity’s name.")
            .AppendBreak()
            .AppendLine("> <b>Role</b>: Divine warrior and healer; protects allies and repels darkness")
            .AppendLine("> <b>Combat Ability</b>: Moderate (better than Thieves, weaker than Fighters)")
            .AppendLine("> <b>Durability</b>: Hardy, especially at lower levels")
            .AppendLine("> <b>Spellcasting</b>: Gains divine spells starting at <b>2nd level</b>")
            .AppendLine("> <b>Special Ability</b>: <b>Turn Undead</b> — repel undead creatures with holy power")
            .AppendLine("> <b>Prime Requisite</b>: <b>Wisdom</b> (minimum score of 9 required)")
            .AppendLine("> <b>Armor</b>: May wear any armor")
            .AppendLine(
                "> <b>Weapons</b>: Restricted to blunt weapons (e.g., warhammer, mace, maul, club, quarterstaff, sling)");
    }

    
}