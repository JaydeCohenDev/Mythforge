using GameContent.Afflictions;
using GameContent.Classes;
using GameContent.Misc;
using GameContent.Util;
using ScriptApi;

namespace GameContent.Creatures;

public class GiantBee : Creature
{
    public override string Name => "Giant Bee";
    public override string Description => throw new NotImplementedException();
    public override int ArmorClass => 13;
    public override HitDice HitDice => new(1, 4);
    public override int Morale => 9;
    public override int Xp => 13;
    
    public override void Attack(Entity target)
    {
        // Sting
        target.Tell(new Message("The Giant Bee stings you!"));
        target.ApplyDamage(Dice.Roll(1, 4));

        if (!target.MakeSavingThrow(SavingThrow.DeathRayPoison))
        {
            target.Tell(new Message("You feel the bee's venom seep into your veins."));
            target.ApplyAffliction(new Poison());
            
            // TODO: Looses stinger and dies!
        }
    }

    public override int GetNumberAppearing(CreatureSpawnContext context) =>
        context switch
        {
            InDungeon => Dice.Roll(1, 6),
            InWild => Dice.Roll(1, 6),
            InLair => Dice.Roll(5, 6),
        };

    public override Dictionary<SavingThrow, int> SavingThrows => Class.Fighter.GetSaveScores(1);
}

public class GiantQueenBee : GiantBee
{
    public override string Name => "Giant Queen-Bee";
    public override HitDice HitDice => new(2, 8);
    public override int Xp => 75;

    public override void Attack(Entity target)
    {
        // bite
        target.Tell(new Message("The queen bee bites you!"));
        target.ApplyDamage(Dice.Roll(1, 8));
    }
    
    public override int GetNumberAppearing(CreatureSpawnContext context) => 1;
}