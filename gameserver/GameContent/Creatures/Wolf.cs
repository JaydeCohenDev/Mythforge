using GameContent.Classes;
using GameContent.Misc;
using GameContent.Util;
using ScriptApi;

namespace GameContent.Creatures;

public class Wolf : Creature
{
    public override string Name => "Wolf";

    public override string Description => "Wolves are pack hunters known for their persistence and cunning. They prefer to surround and flank a foe when they can.";

    public override int ArmorClass => 13;

    public override HitDice HitDice => new HitDice(2, 8);

    public override int Morale => 8;

    public override int Xp => 75;

    public override Dictionary<SavingThrow, int> SavingThrows => Class.Fighter.GetSaveScores(2);

    public override void Attack(Entity target)
    {
        target.ApplyDamage(Dice.Roll(1, 6));
    }

    public override int GetNumberAppearing(CreatureSpawnContext context) 
        => context switch {
            InDungeon => Dice.Roll(2, 6),
            InWild => Dice.Roll(3, 6),
            InLair => Dice.Roll(3, 6),
            _ => 0
        };
}

public class DireWolf : Wolf
{
    public override string Name => "Dire Wolf";

    public override string Description => "Dire wolves are efficient pack hunters that will kill anything they can catch. Dire wolves are generally mottled gray or black, about 9 feet long and weighing some 800 pounds.";

    public override int ArmorClass => 14;

    public override HitDice HitDice => new HitDice(4, 8);

    public override int Morale => 9;

    public override int Xp => 240;

    public override Dictionary<SavingThrow, int> SavingThrows => Class.Fighter.GetSaveScores(4);

    public override void Attack(Entity target)
    {
        target.ApplyDamage(Dice.Roll(2, 4));
    }

    public override int GetNumberAppearing(CreatureSpawnContext context) 
        => context switch {
            InDungeon => Dice.Roll(1, 4),
            InWild => Dice.Roll(2, 4),
            InLair => Dice.Roll(2, 4),
            _ => 0
        };
}