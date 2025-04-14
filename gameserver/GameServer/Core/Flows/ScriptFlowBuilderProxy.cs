using GameServer.Core.Auth;
using GameServer.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using ScriptApi;
using ScriptApi.Flow;

namespace GameServer.Core.Flows;

public class ScriptFlowBuilder : ScriptApi.Flow.ScriptFlowBuilder
{
    private readonly FlowBuilder _flowBuilder = new();

    private class FlowApi(ScriptFlowBuilder builder, FlowContext context, PlayerSession session, IClientProxy caller) : ScriptApi.Flow.IFlowApi
    {
        public void StoreTemp(string name, object value)
        {
            session.TempData[name] = value;
        }

        public object? GetTemp(string name)
        {
            return session.TempData.TryGetValue(name, out object? value) ? value : null;
        }

        public void RemoveTemp(string name)
        {
            session.TempData.Remove(name);
        }

        public async Task<bool> HasAccount(string accountName)
        {
            Account? account = await World.Db.Accounts.FirstOrDefaultAsync(x => x.Name == accountName);
            return account != null;
        }

        public Task StartFlow(ScriptFlow flow)
        {
            var flowBuilder = new ScriptFlowBuilder();
            flow.Build(flowBuilder);
            session.CurrentFlow = flowBuilder.Build();
            return Task.CompletedTask;
        }

        public async Task<bool> ValidateLogin(string accountName, string pass)
        {
            Account? account = await World.Db.Accounts.Include(account => account.Player).FirstOrDefaultAsync(x => x.Name == accountName);
            if (account == null) return false;
            if (account.Password == pass)
            {
                session.Account = account;
                session.Player = account.Player;
                return true;
            }

            return false;
        }

        public async Task TellUser(Message message)
        {
            await caller.SendAsync("ShowMessage", message.Build());
        }

        public void RestartCurrentFlow()
        {
            session.CurrentFlow = builder.Build();
        }

        public void FinalizeLogin()
        {
            session.Player.LoginRoom.AddEntity(session.Player);
        }

        public async Task ResumeMainGameFlow()
        {
            context.EndFlow();
            session.CurrentFlow = MainGameFlow.Build();
            await session.CurrentFlow.Start(session, caller);
        }
    }
    
    public override void AddStep(Message message, ScriptApi.Flow.StepHandler handler)
    {
        _flowBuilder.Step(message.Build(), async (context, session, caller, input) =>
        {
            await handler(new FlowApi(this, context, session, caller), input);
        });
    }

    public IFlow Build() => _flowBuilder.Build("SCRIPT-FLOW");
}