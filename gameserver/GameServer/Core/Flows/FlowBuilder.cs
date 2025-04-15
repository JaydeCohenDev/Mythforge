using GameServer.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace GameServer.Core.Flows;

public delegate Task StepHandler(FlowContext context, PlayerSession session, IClientProxy caller, string input);

public class FlowContext
{
    public bool Ended { get; private set; } = false;
    public bool Continue { get; set; } = true;

    public void EndFlow()
    {
        Ended = true;
    }
}

public class FlowBuilder
{
    private readonly List<FlowStep> _steps = new();
    private Func<PlayerSession, IClientProxy, Task> _onComplete = (session, caller) => Task.CompletedTask;

    public FlowBuilder Step(string prompt, StepHandler handler)
    {
        _steps.Add(new FlowStep
        {
            Prompt = prompt,
            Handler = handler
        });
        return this;
    }
    
    public FlowBuilder Step(StepHandler handler)
    {
        _steps.Add(new FlowStep
        {
            Prompt = null, // No prompt
            Handler = handler
        });
        return this;
    }

    public FlowBuilder End(Func<PlayerSession, IClientProxy, Task> onComplete)
    {
        _onComplete = onComplete;
        return this;
    }

    public IFlow Build(string name)
    {
        return new BuiltFlow(name, _steps, _onComplete);
    }

    private class BuiltFlow : FlowBase
    {
        private readonly List<FlowStep> _steps;
        private readonly Func<PlayerSession, IClientProxy, Task> _onComplete;

        protected string _name;
        public override string Name => _name;

        public BuiltFlow(string name, List<FlowStep> steps, Func<PlayerSession, IClientProxy, Task> onComplete)
        {
            _name = name;
            _steps = steps;
            _onComplete = onComplete;
        }

        public override async Task Start(PlayerSession session, IClientProxy caller)
        {
            //Console.WriteLine($"Flow: {Name} - Starting");
            session.TempData["stepIndex"] = 0;
            if(_steps[0].Prompt != null)
                await ShowMessage(caller, _steps[0].Prompt!);
        }

        public override async Task HandleInput(PlayerSession session, IClientProxy caller, string input)
        {
            
            //Console.WriteLine($"Flow: {Name} - Input: {input}");
            //Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(session.TempData));

            
            int stepIndex = (int)session.TempData["stepIndex"];
            var step = _steps[stepIndex];
            
            var context = new FlowContext();
            
            await step.Handler(context, session, caller, input);

            if (context.Ended)
            {
                //Console.WriteLine("STOPPING FLOW: "+ Name);
                return; // Stop flow immediatley
            }

            if (context.Continue)
            {
                stepIndex++;
            }
            
            if (stepIndex < _steps.Count)
            {
                if (_steps[stepIndex].Prompt != null)
                {
                    session.TempData["stepIndex"] = stepIndex;
                    await ShowMessage(caller, _steps[stepIndex].Prompt);
                }
            }
            else
            {
                
                await _onComplete(session, caller);
            }
        }
    }
}