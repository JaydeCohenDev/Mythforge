using GameServer.Core.Flows;

public class FlowStep
{
    public string? Prompt { get; set; }
    public StepHandler Handler { get; set; }
}