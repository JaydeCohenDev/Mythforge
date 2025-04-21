using ScriptApi;

namespace GameContent.Afflictions;

public class Poison : Affliction
{
    public override string Name => "Poison";
    public override string Description => "You are poisoned and will die if medical attention is not found.";
    public override void Apply(Entity target)
    {
        throw new NotImplementedException();
    }
}