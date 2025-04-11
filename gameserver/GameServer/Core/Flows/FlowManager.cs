using GameServer.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace GameServer.Core.Flows;

public class FlowManager
{
    public async Task StartFlow(PlayerSession session, IClientProxy caller, IFlow flow)
    {
        session.CurrentFlow = flow;
        await flow.Start(session, caller);
    }

    public async Task HandleInput(PlayerSession session, IClientProxy caller, string input)
    {
        if (session.CurrentFlow != null)
        {
            await session.CurrentFlow.HandleInput(session, caller, input);
        }
        else
        {
            await caller.SendAsync("ShowMessage", "No active flow. Please reconnect.");
        }
    }
}