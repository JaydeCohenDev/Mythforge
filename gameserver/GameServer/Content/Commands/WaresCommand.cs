using GameServer.Core;
using GameServer.Core.EntityTraits;
using GameServer.Core.Messaging;

namespace GameServer.Content.Commands;

public class WaresCommand : ICommand
{
    public string[] GetAliases() => ["wares"];

    public Task Execute(Player player, string[] args)
    {
        if (args.Length <= 0)
        {
            player.SendAsync("Who's wares are you looking for?");
            return Task.CompletedTask;
        }
        
        var eName = string.Join(' ', args);
        var entity = player.CurrentRoom?.Entities.FirstOrDefault(e => e.Name.Contains(eName, StringComparison.InvariantCultureIgnoreCase));

        if (entity is null)
        {
            player.SendAsync("You don't see anyone like that.");
            return Task.CompletedTask;
        }

        var vendorTrait = entity.GetTrait<Vendor>();

        if (vendorTrait is null)
        {
            player.SendAsync("There doesn't seem to be anything for sale.");
            return Task.CompletedTask;
        }

        var message = new MessageBuilder();
        message.AddText($"{entity.ToString()} has the following wares for sale:").AddBreak(2);
        vendorTrait.Wares.ForEach(w =>
        {
            message.AddText($"> {w.Item.Name.PadRight(20)}");
            message.AddText($"🪙 {w.Price}");
            message.AddBreak();
        });
        
        player.SendAsync(message.Build());
        return Task.CompletedTask;
    }
}