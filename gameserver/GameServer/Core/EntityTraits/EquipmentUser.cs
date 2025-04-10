using GameServer.Core.Inventory;

namespace GameServer.Core.EntityTraits;

public class EquipmentUser<T> : EntityTrait where T : Enum
{
    public Dictionary<T, Item> Equipment { get; } = [];

    public bool Equip(T slot, Item item)
    {
        if (GetEquipment(slot) != null) 
            return false;
        
        Equipment.Add(slot, item);
        return true;
    }

    public void Unequip(T slot)
    {
        Equipment.Remove(slot);
    }
    
    public Item? GetEquipment(T slot)
    {
        return Equipment.GetValueOrDefault(slot);
    }
}