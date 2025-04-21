using GameContent.Classes;
using GameContent.Misc;
using GameContent.Treasures;
using GameContent.Util;
using ScriptApi;

namespace GameContent.Creatures;

public class Goblin : Creature
{
    public override string Name => "Goblin";

    public override string Description => "Goblins are small, wicked humanoids that favor ambushes, overwhelming odds, dirty tricks, and any other edge they can devise. An adult goblin stands 3 to 3½ feet tall and weigh 40 to 45 pounds. Its eyes are usually bright and crafty-looking, varying in color from red to yellow. A goblin’s skin color ranges from yellow through any shade of orange to a deep red; usually all members of a single tribe are about the same color. Goblins wear clothing of dark leather, tending toward drab, soiled-looking colors. ";

    public override int ArmorClass => 14;

    public override HitDice HitDice => new HitDice(1, 8, -1);

    public override int Morale => 7;

    public override int Xp => 10;

    public override Dictionary<SavingThrow, int> SavingThrows => Class.Fighter.GetSaveScores(1);

    public override List<TreasureType> GetTreasure(TreasureSpawnContext context)
    {
        return context switch {
            IndividualTreasure => TreasureTable.R.Roll(),
            LairTreasure => TreasureTable.C.Roll(),
            _ => []
        };
    }

    public override void Attack(Entity target)
    {
        throw new NotImplementedException();
    }

    public override int GetNumberAppearing(CreatureSpawnContext context)
    {
        return context switch {
            InDungeon => Dice.Roll(2, 4),
            InWild => Dice.Roll(6, 10),
            InLair => Dice.Roll(6, 10),
            _ => throw new InvalidOperationException()
        };
    }
}

public class GoblinRider : Goblin
{
    // Rides a dire wolf
    public override string Name => "Goblin Rider";
}

public class GoblinWarrior : Goblin
{
    public override string Name => "Goblin Warrior";

    public override HitDice HitDice => new HitDice(3, 8, -3);

    public override int Xp => 145;
}

public class GoblinChieftan : Goblin
{
    // TODO: +1 damage, +10' movement
    public override string Name => "Goblin Chieftan";

    public override HitDice HitDice => new HitDice(5, 8, -5);
    public override int ArmorClass => 15;

    public override int Xp => 360;
}

public class GoblinKing : Goblin
{
    //wearing chainmail and carrying a shield, with a movement of 10’, and having a +1 bonus to damage. 

    //Goblins have a +2 bonus to morale while their king is present (this is not cumulative with the bonus given by a warrior leader). In addition, a lair has a chance equal to 1 on 1d6 of a shaman being present (or 1-2 on 1d6 if a goblin king is present).

    public override string Name => "Goblin King";

    public override HitDice HitDice => new HitDice(7, 8, -7);
    public override int ArmorClass => 16;

    public override int Xp => 670;
}

public class GoblinShaman : Goblin
{
    //Clerical abilities at level 1d4+1
    public override string Name => "Goblin Shaman";

    public override HitDice HitDice => new HitDice(7, 8, -7);
    public override int ArmorClass => 16;

    public override int Xp => 670;
}