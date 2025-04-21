using ScriptApi;

public class CharacterScript : EntityScript
{
    public bool MakeSavingThrow(SavingThrow savingThrow, int modifier)
    {
        throw new NotImplementedException();
        // var target = SavingThrows[savingThrow] + modifier;
        
        // var roll = Dice.Roll(1, 20);

        // if (roll == 1) return false;
        // if(roll == 20) return true;
        // return roll >= target;
    }
}