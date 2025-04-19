using GameContent.Util;
using ScriptApi;

namespace GameContent.Scripts;

public class AttributeScores : EntityScript
{
    [Persist] public int Strength { get; private set; }
    [Persist] public int Dexterity { get; private set; }
    [Persist] public int Constitution { get; private set; }
    [Persist] public int Intelligence { get; private set; }
    [Persist] public int Wisdom { get; private set; }
    [Persist] public int Charisma { get; private set; }

    public void Generate()
    {
        Strength = Dice.Roll(3, 6);
        Dexterity = Dice.Roll(3, 6);
        Constitution = Dice.Roll(3, 6);
        Intelligence = Dice.Roll(3, 6);
        Wisdom = Dice.Roll(3, 6);
        Charisma = Dice.Roll(3, 6);
    }

    public void DrainConstitution(int amount = 1)
    {
        Constitution = Math.Max(0, Constitution - amount);

        if(Constitution <= 0)
        {
            Entity.Tell(new Message("You're constition is depleted. You have been slain."));
            Entity.Kill();
        }
    }

    public override string ToString()
    {
        return
            $"STR: {Strength}, DEX: {Dexterity}, CON: {Constitution}, INT: {Intelligence}, WIS: {Wisdom}, CHA: {Charisma}";
    }
}