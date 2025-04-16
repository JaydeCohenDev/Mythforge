using GameContent.Abilities.Spells;
using GameContent.Scripts;
using GameContent.Util;
using ScriptApi;
using ScriptApi.Ability;
using Shield = GameContent.Scripts.Shield;

namespace GameContent.Classes;

public class MagicUser : Class
{
    public override string Name { get; init; } = "Magic-User";
    
    public class MagicUserClassLevel : ClassLevel
    {
        public required Dictionary<int, int> Spells {get; init;}
    }

    public override bool ValidateScores(AttributeScores scores) =>
        scores.Intelligence >= 9;

    public override bool CanWield(Weapon weapon) =>
        weapon.Kind is WeaponKind.Dagger or WeaponKind.Staff;

    public override bool CanUseArmor(Armor armor) => false;
    public override bool CanUseShield(Shield shield) => false;

    public override List<Ability> GetDefaultAbilities() => [
        new ReadMagic(), GetRandomStartingSpell()
    ];

    private static Spell GetRandomStartingSpell()
    {
        int roll = Dice.Roll(1, 12);
        return roll switch
        {
            1 => new CharmPerson(),
            2 => new DetectMagic(),
            3 => new FloatingDisk(),
            4 => new HoldPortal(),
            5 => new Light(),
            6 => new MagicMissile(),
            7 => new MagicMouth(),
            8 => new ProtectionFromEvil(),
            9 => new ReadLanguages(),
            10 => new Abilities.Spells.Shield(),
            11 => new Sleep(),
            12 => new Ventriloquism(),
            _ => new MagicMissile()
        };
    }

    public override Dictionary<int, ClassLevel> Levels => new()
    {
        {1, new MagicUserClassLevel{
            RequiredExperience = 0,
            HitDice = "1d4",
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
        {2, new MagicUserClassLevel{
            RequiredExperience = 2_500,
            HitDice = "2d4",
            AbilityBonus = 1,
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
        {3, new MagicUserClassLevel{
            RequiredExperience = 5_000,
            HitDice = "3d4",
            AbilityBonus = 1,
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
        {4, new MagicUserClassLevel{
            RequiredExperience = 10_000,
            HitDice = "4d4",
            AbilityBonus = 2,
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
        {5, new MagicUserClassLevel{
            RequiredExperience = 20_000,
            HitDice = "5d4",
            AbilityBonus = 2,
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
        {6, new MagicUserClassLevel{
            RequiredExperience = 40_000,
            HitDice = "6d4",
            AbilityBonus = 3,
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
        {7, new MagicUserClassLevel{
            RequiredExperience = 80_000,
            HitDice = "7d4",
            AbilityBonus = 3,
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
        {8, new MagicUserClassLevel{
            RequiredExperience = 150_000,
            HitDice = "8d4",
            AbilityBonus = 3,
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
        {9, new MagicUserClassLevel{
            RequiredExperience = 300_000,
            HitDice = "9d4",
            AbilityBonus = 4,
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
        {10, new MagicUserClassLevel{
            RequiredExperience = 450_000,
            HitDice = "9d4+1",
            AbilityBonus = 4,
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
        {11, new MagicUserClassLevel{
            RequiredExperience = 600_000,
            HitDice = "9d4+2",
            AbilityBonus = 4,
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
        {12, new MagicUserClassLevel{
            RequiredExperience = 750_000,
            HitDice = "9d4+3",
            AbilityBonus = 4,
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
        {13, new MagicUserClassLevel{
            RequiredExperience = 900_000,
            HitDice = "9d4+4",
            AbilityBonus = 5,
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
        {14, new MagicUserClassLevel{
            RequiredExperience = 1_050_000,
            HitDice = "9d4+5",
            AbilityBonus = 5,
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
        {15, new MagicUserClassLevel{
            RequiredExperience = 1_200_000,
            HitDice = "9d4+6",
            AbilityBonus = 5,
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
        {16, new MagicUserClassLevel{
            RequiredExperience = 1_350_000,
            HitDice = "9d4+7",
            AbilityBonus = 6,
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
        {17, new MagicUserClassLevel{
            RequiredExperience = 1_500_000,
            HitDice = "9d4+8",
            AbilityBonus = 6,
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
        {18, new MagicUserClassLevel{
            RequiredExperience = 1_650_000,
            HitDice = "9d4+9",
            AbilityBonus = 6,
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
        {19, new MagicUserClassLevel{
            RequiredExperience = 1_800_000,
            HitDice = "9d4+10",
            AbilityBonus = 7,
            Spells = new Dictionary<int, int>
            {
                {1, 6},
                {2, 5},
                {3, 5},
                {4, 4},
                {5, 3},
                {6, 3}
            }
        }},
        {20, new MagicUserClassLevel{
            RequiredExperience = 1_950_000,
            HitDice = "9d4+11",
            AbilityBonus = 7,
            Spells = new Dictionary<int, int>
            {
                {1, 6},
                {2, 5},
                {3, 5},
                {4, 4},
                {5, 4},
                {6, 3}
            }
        }}
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
                { SavingThrow.DeathRayPoison, 13 },
                { SavingThrow.MagicWands, 14 },
                { SavingThrow.ParalysisPetrify, 13 },
                { SavingThrow.DragonBreath, 15 },
                { SavingThrow.Spells, 14 },
            },
            >= 4 and <= 5 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 12 },
                { SavingThrow.MagicWands, 13 },
                { SavingThrow.ParalysisPetrify, 12 },
                { SavingThrow.DragonBreath, 15 },
                { SavingThrow.Spells, 13 },
            },
            >= 6 and <= 7 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 12 },
                { SavingThrow.MagicWands, 12 },
                { SavingThrow.ParalysisPetrify, 11 },
                { SavingThrow.DragonBreath, 14 },
                { SavingThrow.Spells, 13 },
            },
            >= 8 and <= 9 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 11 },
                { SavingThrow.MagicWands, 11 },
                { SavingThrow.ParalysisPetrify, 10 },
                { SavingThrow.DragonBreath, 14 },
                { SavingThrow.Spells, 12 },
            },
            >= 10 and <= 11 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 11 },
                { SavingThrow.MagicWands, 10 },
                { SavingThrow.ParalysisPetrify, 9 },
                { SavingThrow.DragonBreath, 13 },
                { SavingThrow.Spells, 11 },
            },
            >= 12 and <= 13 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 10 },
                { SavingThrow.MagicWands, 10 },
                { SavingThrow.ParalysisPetrify, 9 },
                { SavingThrow.DragonBreath, 13 },
                { SavingThrow.Spells, 11 },
            },
            >= 14 and <= 15 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 10 },
                { SavingThrow.MagicWands, 9 },
                { SavingThrow.ParalysisPetrify, 8 },
                { SavingThrow.DragonBreath, 12 },
                { SavingThrow.Spells, 10 },
            },
            >= 16 and <= 17 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 9 },
                { SavingThrow.MagicWands, 8 },
                { SavingThrow.ParalysisPetrify, 7 },
                { SavingThrow.DragonBreath, 12 },
                { SavingThrow.Spells, 9 },
            },
            >= 18 and <= 19 => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 9 },
                { SavingThrow.MagicWands, 7 },
                { SavingThrow.ParalysisPetrify, 6 },
                { SavingThrow.DragonBreath, 11 },
                { SavingThrow.Spells, 9 },
            },
            _ => new Dictionary<SavingThrow, int>
            {
                { SavingThrow.DeathRayPoison, 8 },
                { SavingThrow.MagicWands, 6 },
                { SavingThrow.ParalysisPetrify, 5 },
                { SavingThrow.DragonBreath, 11 },
                { SavingThrow.Spells, 8 },
            }
        };
    }

    
    public override Message GetDescription()
    {
        return new Message()
            .AppendLine(
                "<b>Magic-Users</b> are seekers of arcane power, wielding spells through intellect and study rather than faith. Though frail and poor in combat, they command forces that can shape reality, drawn from ancient tomes and hidden knowledge.")
            .AppendBreak()
            .AppendLine("> <b>Role</b>: Arcane spellcaster and wielder of mystical forces")
            .AppendLine("> <b>Combat Ability</b>: Weakest of all classes in melee")
            .AppendLine("> <b>Durability</b>: Fragile; lowest hit points and no armor")
            .AppendLine("> <b>Spellcasting</b>: Begins with <i>read magic</i> + one 1st-level spell")
            .AppendLine("> <b>Prime Requisite</b>: <b>Intelligence</b> (minimum score of 9 required)")
            .AppendLine("> <b>Armor</b>: May not wear armor or use shields")
            .AppendLine("> <b>Weapons</b>: Limited to dagger and walking staff (or cudgel)")
            .AppendLine("> <b>Spellbook</b>: Starts with spells recorded in a book from their master")
            .AppendLine("> <b>Magic Source</b>: Derived from study, logic, and arcane insight");
    }
}