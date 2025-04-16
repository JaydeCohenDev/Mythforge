using GameContent.Classes;
using GameContent.Scripts;
using ScriptApi;
using ScriptApi.Ability;

namespace GameContent.Races;

public abstract class Race
{
    public static Race Human { get; } = new Human();
    public static Race Elf { get; } = new Elf();
    public static Race Dwarf { get; } = new Dwarf();
    public static Race Halfling { get; } = new Halfling();
    
    public abstract string Name { get; }
    public abstract Message GetDescription();
    public abstract List<Class> AllowedClasses {get;}
    public virtual bool ValidateScores(AttributeScores scores) => true;
    public virtual bool CanWield(Weapon weapon) => true;
    public virtual int? MaxHitPointsDie {get;} = null;
    public virtual int RequiredHandsToWield(Weapon weapon) =>
        weapon.RequiredHandsToWield;

    public virtual int GetSavingThrowBonus(SavingThrow savingThrow) => 0;
    public virtual List<Ability> GetDefaultAbilities() => [];
}