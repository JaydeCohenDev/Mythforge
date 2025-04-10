using GameServer.Core.Inventory.Material;

namespace GameServer.Core.Inventory.Traits;

public class MadeOf(GearMaterial material) : ItemTrait
{
    public GearMaterial Material { get; init; } = material;
}