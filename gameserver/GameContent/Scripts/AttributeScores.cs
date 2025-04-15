using GameContent.Util;
using ScriptApi;

namespace GameContent.Scripts;

public class AttributeScores : EntityScript
{
    public int Strength { get; private set; }
    public int Dexterity { get; private set; }
    public int Constitution { get; private set; }
    public int Intelligence { get; private set; }
    public int Wisdom { get; private set; }
    public int Charisma { get; private set; }

    public void Generate()
    {
        Strength = Dice.Roll(3, 6);
        Dexterity = Dice.Roll(3, 6);
        Constitution = Dice.Roll(3, 6);
        Intelligence = Dice.Roll(3, 6);
        Wisdom = Dice.Roll(3, 6);
        Charisma = Dice.Roll(3, 6);
    }

    public override string ToString()
    {
        return
            $"STR: {Strength}, DEX: {Dexterity}, CON: {Constitution}, INT: {Intelligence}, WIS: {Wisdom}, CHA: {Charisma}";
    }
}