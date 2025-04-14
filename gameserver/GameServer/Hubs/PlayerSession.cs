using GameServer.Core;
using GameServer.Core.Auth;
using GameServer.Core.Flows;

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