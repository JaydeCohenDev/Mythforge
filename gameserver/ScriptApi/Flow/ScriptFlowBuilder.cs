namespace ScriptApi.Flow;

public delegate Task StepHandler(IFlowApi api, string input);

public abstract class ScriptFlowBuilder
{
    public abstract void AddStep(Message message, StepHandler handler);
}