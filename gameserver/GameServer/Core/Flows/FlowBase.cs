using GameServer.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace GameServer.Core.Flows;

public abstract class FlowBase : IFlow
{
    public abstract string Name { get; }
    public virtual Task Start(PlayerSession session, IClientProxy caller) => Task.CompletedTask;
    public abstract Task HandleInput(PlayerSession session, IClientProxy caller, string input);
    protected Task ShowMessage(IClientProxy caller, string message) => caller.SendAsync("ShowMessage", message);
}