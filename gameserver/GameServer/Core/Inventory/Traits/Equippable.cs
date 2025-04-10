namespace GameServer.Core.Inventory.Traits;

public class Equippable(Enum slot) : ItemTrait
{
    public Enum Slot { get; init; } = slot;
}