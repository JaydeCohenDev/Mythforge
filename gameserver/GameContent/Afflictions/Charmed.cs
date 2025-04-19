using GameContent.Scripts;
using ScriptApi;

namespace GameContent.Afflictions;

public class Charmed : Affliction
{
    public override string Name => "Charmed";
    public override string Description => "The character is charmed and loyal to its master.";

    public override void Apply(Entity target)
    {
        var script = target.AttachScript<CharmedScript>();
    }
}