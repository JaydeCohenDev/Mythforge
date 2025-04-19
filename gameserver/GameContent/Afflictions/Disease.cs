using GameContent.Util;
using ScriptApi;

namespace GameContent.Afflictions;

public class Disease : Affliction
{
    public override string Name => "Disease";

    public override string Description =>
        "The infected character will lose one point of Constitution per hour; after losing each point, the character is allowed a save vs. Death Ray (adjusted by the current Constitution bonus or penalty) to break the fever and end the disease. Any character reduced to zero Constitution is dead.";

    public override void Apply(Entity target)
    {
        var script = target.AttachScript<DiseaseScript>();
        script.HoursBeforeActive = Dice.Roll(3, 6);
    }
}