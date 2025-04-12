
using System.Text.Json;
using GameServer.Core;
using GameServer.Core.Auth;
using GameServer.Core.Flows;
using GameServer.Core.Messaging;
using GameServer.Core.Scripting;
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
    public Player Player { get; set; }

    public bool IsLoggedIn => Account != null;

    public string CurrentRoomId { get; set; }
}

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

        await _flowManager.StartFlow(session, Clients.Caller, LoginFlow.Build());
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

    public async Task<string> GetScript(string scriptName)
    {
        ScriptFile? script = await World.Db.Scripts.Include(scriptFile => scriptFile.Author).FirstOrDefaultAsync(s => s.Name == scriptName);

        if (script == null)
        {
            return JsonSerializer.Serialize(new
            {
                success = false,
                error = $"Could not find script with name {scriptName}"
            });
        }
        
        return JsonSerializer.Serialize(new
        {
            success = true,
            script.Id,
            script.Name,
            Author = script.Author.Name,
            script.SourceCode,
        });
    }

    public async Task<string> UpdateScript(string scriptName, string sourceCode)
    {
        ScriptFile? script = await World.Db.Scripts.Include(scriptFile => scriptFile.Author).FirstOrDefaultAsync(s => s.Name == scriptName);

        if (script == null)
        {
            return JsonSerializer.Serialize(new
            {
                success = false,
                error = $"Could not find script with name {scriptName}"
            });
        }
        
        if (script.Author != Sessions.FirstOrDefault(s => s.Value.ConnectionId == Context.ConnectionId).Value.Account)
        {
            return JsonSerializer.Serialize(new
            {
                success = false,
                error = $"You do not have permission to edit this script."
            });
        }
        
        script.SourceCode = sourceCode;
        await World.Db.SaveChangesAsync();
        return JsonSerializer.Serialize(new
        {
            success = true,
            script.Id,
            script.Name,
            Author = script.Author.Name,
            script.SourceCode,
        });
    }

    public async Task<string> CreateScript(string scriptName)
    {
        var script = new ScriptFile
        {
            Name = scriptName,
            Author = Sessions.FirstOrDefault(s => s.Value.ConnectionId == Context.ConnectionId).Value.Account,
            SourceCode = ""
        };
        
        await World.Db.Scripts.AddAsync(script);
        await World.Db.SaveChangesAsync();
        
        return JsonSerializer.Serialize(new
        {
            success = true,
            script.Id,
            script.Name,
            Author = script.Author.Name,
            script.SourceCode,
        });
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
