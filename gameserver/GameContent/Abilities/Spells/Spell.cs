using ScriptApi;
using ScriptApi.Ability;

namespace GameContent.Abilities.Spells;

public abstract class SpellDuration{}
public class Permanent : SpellDuration {}
public class Instantaneous : SpellDuration {}

public class Turns(int turns) : SpellDuration
{
    public int NumTurns => turns;
}
public class Rounds(int rounds) : SpellDuration
{
    public int NumRounds => rounds;
}
public class Special : SpellDuration {}

public abstract class Spell : Ability
{
    public abstract SpellDuration GetDuration(Entity caster);
    public abstract AbilityRange GetRange(Entity caster);
}