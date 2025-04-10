
using System.Text.Json;
using GameServer.Core;
using Microsoft.AspNetCore.SignalR;

namespace GameServer.Hubs;

public class GameHub : Hub
{
    public override Task OnDisconnectedAsync(Exception? exception)
    {
        Game.OnPlayerDisconnected?.Invoke(Context.ConnectionId);

        return base.OnDisconnectedAsync(exception);
    }

    public override Task OnConnectedAsync()
    {
        Console.WriteLine(Context.ConnectionId);
        Game.OnPlayerConnected?.Invoke(Context.ConnectionId);

        return base.OnConnectedAsync();
    }

    public Task SendInput(string userInput)
    {
        Console.WriteLine(userInput);
        Player player = Player.All[Context.ConnectionId];

        string commandName = userInput.Split(" ").First();
        string[] args = userInput.Split(" ").Skip(1).ToArray();

        ICommand? command = Game.FindCommand(commandName);
        if (command is not null)
        {
            command.Execute(player, args);
            return Task.CompletedTask;
        }

        Clients.Caller.SendAsync("ShowMessage", "Command not found");
        return Task.CompletedTask;

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
