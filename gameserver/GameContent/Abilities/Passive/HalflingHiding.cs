using ScriptApi.Ability;

namespace GameContent.Abilities.Passive;

public class HalflingHiding : PassiveAbility
{
    public override string Name => "Halfling Hiding";

    public override string Description => "Outdoors in their preferred forest terrain, Halflings are able to hide very effectively; so long as they remain still there is only a 10% chance they will be detected. Even indoors, in dungeons or in non-preferred terrain Halflings are able to hide such that there is only a 30% chance of detection.";
}