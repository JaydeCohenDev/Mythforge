
using System.Text.Json;
using GameServer.Core;
using GameServer.Core.Auth;
using GameServer.Core.Flows;
using GameServer.Core.Messaging;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace GameServer.Hubs;

public class PlayerSession
{
    public string ConnectionId { get; set; }

    public IFlow CurrentFlow { get; set; }

    public Dictionary<string, object> TempData { get; set; } = new();

    public string Name { get; set; }
    public Account Account { get; set; }

    public bool IsLoggedIn => Account != null;

    public string CurrentRoomId { get; set; }
}

public class GameHub : Hub
{
    private static readonly Dictionary<string, PlayerSession> Sessions = new();
    private readonly FlowManager _flowManager = new();
    
    public override async Task OnConnectedAsync()
    {
        var session = new PlayerSession
        {
            ConnectionId = Context.ConnectionId,
        };
        Sessions[Context.ConnectionId] = session;

        await _flowManager.StartFlow(session, Clients.Caller, LoginFlow.Build());
    }
    
    public override Task OnDisconnectedAsync(Exception? exception)
    {
        Sessions.Remove(Context.ConnectionId);
        return Task.CompletedTask;
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
    
    private async Task HandleGameInput(PlayerSession session, string input)
    {
        
    }

    public Task<string> GetRegion(string regionId)
    {
        Console.WriteLine($"Getting region data for {regionId}");

        if (Region.All.TryGetValue(regionId, out Region? region))
        {
            Console.WriteLine($"Found region! {region.Name}. Sending to client.");
            return Task.FromResult(JsonSerializer.Serialize(new
            {
                success = true,
                data = region
            }));
        }

        return Task.FromResult(JsonSerializer.Serialize(new
        {
            success = false,
            error = $"Could not find region with id {regionId}"
        }));
    }

    public Task<string> GetRoom(string roomId)
    {
        Console.WriteLine($"Getting room data for {roomId}");

        if (Room.All.TryGetValue(roomId, out Room? room))
        {
            Console.WriteLine($"Found room! {room.Name}. Sending to client.");
            return Task.FromResult(JsonSerializer.Serialize(new
            {
                success = true,
                data = room
            }));
        }

        return Task.FromResult(JsonSerializer.Serialize(new
        {
            success = false,
            error = $"Could not find region with id {roomId}"
        }));
    }
}
