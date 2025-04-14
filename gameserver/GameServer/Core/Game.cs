using GameServer.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace GameServer.Core;

public static class Game
{
    public static Action<string>? OnPlayerConnected;
    public static Action<string>? OnPlayerDisconnected;
    public static IHubContext<GameHub> HubContext { get; set; } = null!;

    public static World World = new World();

    public static void Init()
    {
        
    }

}