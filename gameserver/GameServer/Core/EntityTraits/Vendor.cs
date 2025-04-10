using GameServer.Core.Inventory;

namespace GameServer.Core.EntityTraits;

public class Vendor(List<Vendor.VendorWare> wares) : EntityTrait
{
    public record struct VendorWare
    {
        public Item Item { get; set; }
        public int Price { get; set; }
    }
    
    public List<VendorWare> Wares { get; init; } = wares;
}