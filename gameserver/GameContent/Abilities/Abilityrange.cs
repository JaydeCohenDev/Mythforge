namespace GameContent.Abilities;

public abstract class AbilityRange {}

public class RangeInFeet(int feet) : AbilityRange
{
    public int Feet => feet;
}

public class Touch() : AbilityRange {}
public class Self() : AbilityRange {}