using GameServer.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace GameServer.Core.Flows;

public interface IFlow
{
    string Name { get; }
    Task Start(PlayerSession session, IClientProxy caller);
    Task HandleInput(PlayerSession session, IClientProxy caller, string input);
}