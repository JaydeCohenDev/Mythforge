using GameContent.Treasures;
using ScriptApi;

namespace GameContent.Creature;

public abstract class CreatureSpawnContext{}
public class InWild : CreatureSpawnContext{}
public class InLair : CreatureSpawnContext{}
public class InDungeon : CreatureSpawnContext{}

public abstract class Creature
{
    public abstract string Name { get; }
    public abstract int ArmorClass { get; }
    public abstract int HitDice { get; }
    public abstract int Morale { get; }
    public abstract int Xp { get; }
    public abstract void Attack(Entity target);
    public abstract int GetNumberAppearing(CreatureSpawnContext context);
    public virtual List<TreasureType> GetTreasure() => []; 
    public abstract Dictionary<SavingThrow,int> SaveAs { get; }
}