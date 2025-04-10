using GameServer.Core.EntityTraits;
using GameServer.Core.Messaging;

namespace GameServer.Core;

public class Denizen : Entity
{
    public string? Role;
    public Action<Player, Denizen>? OnGreet;

    public Denizen(int maxHealth = 100)
    {
        AddTraits(new Damageable(maxHealth));
    }

    public void Greet(Player player)
    {
        Console.WriteLine("GREET");
        OnGreet?.Invoke(player, this);
    }

    public void Tell(Player player, string method, string message)
    {
        string? response = new MessageBuilder()
            .AddDialogue(this, method, message)
            .Build();
        player.SendAsync(response);
    }

    public override string ToString()
    {
        return $"<npc payload='{Payload.Encode(this)}'>{Name}</npc>";
    }
}