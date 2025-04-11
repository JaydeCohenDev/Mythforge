using GameServer.Core;
using GameServer.Core.Scripting;

namespace GameServer.Content.Scripts;

public class WynnaBramblecask : EntityScript
{
    public override void OnCreate()
    {
        ((Denizen)Entity).OnGreet = (player, self) =>
        {
            self.Tell(player, "chuckles warmly, eyes twinkling",
                "Well look what the wind blew in! Hungry, thirsty, or just need a bit of gossip with your pint?");
        };
    }
}