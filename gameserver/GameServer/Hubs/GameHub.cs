using GameServer.Core;
using GameServer.Core.Flows;
using GameServer.Core.Scripting;
using Microsoft.AspNetCore.SignalR;
using ScriptApi;
using ScriptApi.Flow;
using Player = GameServer.Core.Player;
using ScriptFlowBuilder = GameServer.Core.Flows.ScriptFlowBuilder;

namespace GameServer.Hubs;

public class GameHub : Hub
{
    private static readonly Dictionary<string, PlayerSession> Sessions = new();
    private readonly FlowManager _flowManager = new();

    public static PlayerSession? GetPlayerSession(Player player)
        => Sessions.FirstOrDefault(
            s => s.Value.Account == player.Account).Value;
    
    public override async Task OnConnectedAsync()
    {
        var session = new PlayerSession
        {
            ConnectionId = Context.ConnectionId,
        };
        Sessions[Context.ConnectionId] = session;

        var gameManager = ScriptManager.Get<GameManagerBase>();
        ScriptFlow? initFlow = gameManager?.GetInitialFlow();
        if (initFlow != null)
        {
            var builder = new ScriptFlowBuilder();
            initFlow.Build(builder);
            await _flowManager.StartFlow(session, Clients.Caller, builder.Build());    
        }
    }
    
    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        Player player = Sessions[Context.ConnectionId].Player;
        player.LoginRoom = player.CurrentRoom!;
        player.CurrentRoom?.Entities.Remove(player);
        await World.Db.SaveChangesAsync();
        
        Sessions.Remove(Context.ConnectionId);
    }

    public async Task SendInput(string userInput)
    {
        if (!Sessions.TryGetValue(Context.ConnectionId, out PlayerSession? session))
        {
            await Clients.Caller.SendAsync("ShowMessage", "Your session could not be found. Please reconnect.");
            return;
        }

        await _flowManager.HandleInput(session, Clients.Caller, userInput);
    }
}
