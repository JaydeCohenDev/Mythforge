using GameServer.Core;
using GameServer.Core.EntityTraits;
using GameServer.Core.Inventory;
using GameServer.Core.Inventory.Traits;
using GameServer.Core.Messaging;

namespace GameServer.Content.Commands;

public class EquipmentCommand : ICommand
{
    public string[] GetAliases() => ["equipment", "eq"];

    public Task Execute(Player player, string[] args)
    {
        var equipment = player.GetTrait<EquipmentUser<HumanoidEquipmentSlot>>()!;
        var message = new MessageBuilder()
            .AddText("Your equipment:").AddBreak(2);

        foreach (var slot in Enum.GetValues<HumanoidEquipmentSlot>())
        {
            var item = "-empty-";
            if (equipment.GetEquipment(slot) is Item equippedItem)
            {
                item = equippedItem.Name;
            }

            message.AddText($"<pre>{slot.ToString().PadRight(20)} : {item}</pre>");
        }
        
        player.SendAsync(message.Build());
        return Task.CompletedTask;
    }
}

public class EquipCommand : ICommand
{
    public string[] GetAliases() => ["equip", "wield", "wear"];

    public Task Execute(Player player, string[] args)
    {
        if (args.Length == 0)
        {
            player.SendAsync("Equip what?");
            return Task.CompletedTask;
        }

        var itemName = string.Join(' ', args);
        
        var inv = player.GetTrait<InventoryTrait>()!;
        
        var item = inv.Items.FirstOrDefault(i => i.Key.Name.Contains(itemName, StringComparison.InvariantCultureIgnoreCase)).Key;
        if (item.GetTrait<Equippable>() is not Equippable equippable)
        {
            player.SendAsync("You can't equip that.");
            return Task.CompletedTask;
        }
        
        var eq = player.GetTrait<EquipmentUser<HumanoidEquipmentSlot>>()!;
        if (eq.GetEquipment((HumanoidEquipmentSlot)equippable.Slot) is Item equippedItem)
        {
            player.SendAsync($"{equippedItem.Name} is equipped in {equippable.Slot}");
            return Task.CompletedTask;
        }
        
        eq.Equip((HumanoidEquipmentSlot)equippable.Slot, item);
        player.SendAsync($"You place the {item.Name} in your {equippable.Slot}");

        return Task.CompletedTask;
    }
}

public class UnwieldCommand : ICommand
{
    public string[] GetAliases() => ["unwield"];

    public Task Execute(Player player, string[] args)
    {
        throw new NotImplementedException();
    }
}