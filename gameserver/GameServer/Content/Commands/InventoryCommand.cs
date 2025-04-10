using GameServer.Core;
using GameServer.Core.EntityTraits;
using GameServer.Core.Messaging;

namespace GameServer.Content.Commands;

public class InventoryCommand : ICommand
{
    public Task Execute(Player player, string[] args)
    {
        var inv = player.GetTrait<InventoryTrait>()!;

        MessageBuilder message = new MessageBuilder()
            .AddText("You are carrying:").AddBreak(2);
        
        inv.Items.ToList().ForEach(i =>
        {
            message.AddText($"> {i.Value}x {i.Key.Name}").AddBreak();
        });
        player.SendAsync(message.Build());
        
        return Task.CompletedTask;
    }

    public string[] GetAliases() => ["inventory", "inv"];
}