using ScriptApi.Ability;

namespace GameContent.Abilities.Thief;

public abstract class ThiefAbility : Ability
{
    public abstract int GetSuccessChance(int thiefLevel);
}