using GameContent.Scripts;
using ScriptApi;

namespace GameContent.Classes;

public abstract class ClassLevel
{
    public required int RequiredExperience {get; init;}
    public required string HitDice {get; init;}
    public required int AbilityBonus  {get; init;}
}

public abstract class Class
{
    public static Class Cleric { get; } = new Cleric();
    public static Class Fighter { get; } = new Fighter();
    public static Class MagicUser { get; } = new MagicUser();
    public static Class Thief { get; } = new Thief();
    
    public abstract string Name { get; init; }
    public abstract  Dictionary<int, ClassLevel> Levels {get;}
    public abstract Message GetDescription();
    public abstract Dictionary<SavingThrow, int> GetSaveScores(int level);
    public virtual bool ValidateScores(AttributeScores scores) => true;
    public virtual bool CanWield(Weapon weapon) => true;
}