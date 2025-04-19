using GameContent.Afflictions;
using GameContent.Classes;
using GameContent.Misc;
using GameContent.Treasures;
using GameContent.Util;
using ScriptApi;

namespace GameContent.Creatures;

public class RatSwarm : Creature
{
    public override string Name => "Rat";
    public override string Description => "A rat swarm.";
    public override int ArmorClass => 11;
    public override int Morale => 5;
    public override int Xp => 360;
    public override HitDice HitDice => new HitDice(5, 10);
    public override Dictionary<SavingThrow,int> SavingThrows => 
        new Fighter().GetSaveScores(0);
    
    public override void Attack(Entity target)
    {
        target.ApplyDamage(Dice.Roll(1, 6));
        if (Dice.Roll(1, 100) <= 5)
        {
            target.ApplyAffliction(new Disease());
        }
    }

    public override int GetNumberAppearing(CreatureSpawnContext context) => 1;
}

public class GiantRat : Creature
{
    public override string Name => "Giant Rat";
    public override string Description => "A giant rat.";
    public override int ArmorClass => 13;
    public override int Morale => 8;
    public override int Xp => 10;
    public override HitDice HitDice => new HitDice(1, 4);
    
    public override Dictionary<SavingThrow,int> SavingThrows => 
        new Fighter().GetSaveScores(1);

    public override List<TreasureType> GetTreasure(TreasureSpawnContext context) => 
        TreasureTable.C.Roll();

    public override void Attack(Entity target)
    {
        target.ApplyDamage(Dice.Roll(1, 4));
        if (Dice.Roll(1, 100) <= 5)
        {
            target.ApplyAffliction(new Disease());
        } 
    }

    public override int GetNumberAppearing(CreatureSpawnContext context)
    {
        return context switch
        {
            InWild => Dice.Roll(3, 10),
            InLair => Dice.Roll(3, 10),
            _ => Dice.Roll(2, 6),
        };
    }
}