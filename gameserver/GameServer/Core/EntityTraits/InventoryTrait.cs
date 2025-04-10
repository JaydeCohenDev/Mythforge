using GameServer.Core.Inventory;

namespace GameServer.Core.EntityTraits;

public class InventoryTrait : EntityTrait
{
    public Dictionary<Item, int> Items { get; } = [];
    
    public void AddItem(Item item, int num = 1)
    {
        Items.Add(item, num);
    }
}