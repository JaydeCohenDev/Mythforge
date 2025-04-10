using GameServer.Core;
using GameServer.Core.EntityTraits;
using GameServer.Core.Inventory;

namespace GameServer.Content.Commands;

public class BuyCommand : ICommand
{
    public string[] GetAliases() => ["buy"];

    public Task Execute(Player player, string[] args)
    {
        if (args.Length < 4)
        {
            player.SendAsync("? BUY [NUM] [ITEM] from [VENDOR]");
            return Task.CompletedTask;
        }

        if (!int.TryParse(args[0], out int num) || num <= 0)
        {
            player.SendAsync("? BUY [NUM] [ITEM] from [VENDOR]");
            return Task.CompletedTask;
        }

        string itemName = args[1];
        
        string vendorName = args[3];

        var vendor = player.CurrentRoom.Entities.FirstOrDefault(e =>
            e.Name.Contains(vendorName, StringComparison.InvariantCultureIgnoreCase));

        if (vendor is null)
        {
            player.SendAsync("You don't see anything like that");
            return Task.CompletedTask;
        }

        var vendorTrait = vendor.GetTrait<Vendor>();
        if (vendorTrait is null)
        {
            player.SendAsync($"{vendor.Name} doesn't sell anything");
            return Task.CompletedTask;
        }

        var vendorItem = vendorTrait.Wares.FirstOrDefault(w =>
            w.Item.Name.Contains(itemName, StringComparison.InvariantCultureIgnoreCase));

        if (vendorItem.Equals(default))
        {
            player.SendAsync($"{vendor.Name} doesn't have that for sale.");
            return Task.CompletedTask;
        }
        
        int cost = vendorItem.Price * num;

        if (player.Gold < cost)
        {
            player.SendAsync($"You don't have enough gold to buy {vendorItem.Item.Name}.<br/> It will cost 🪙 {cost} but you only have 🪙 {player.Gold}");
            return Task.CompletedTask;
        }

        player.Gold -= cost;
        player.GetTrait<InventoryTrait>()!.AddItem((vendorItem.Item.Clone() as Item)!, num);

        player.SendAsync($"You paid 🪙 {cost} to {vendor.Name}. {num}x {vendorItem.Item.Name} added to inventory.");
        
        return Task.CompletedTask;
    }
}