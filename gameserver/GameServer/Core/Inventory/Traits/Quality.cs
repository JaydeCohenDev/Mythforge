namespace GameServer.Core.Inventory.Traits;

public class ItemQuality
{
    public static ItemQuality Common = new ItemQuality
    {
        Name = "Common"
    };
    public static ItemQuality Uncommon = new ItemQuality
    {
        Name = "Uncommon"
    };
    public static ItemQuality Rare = new ItemQuality
    {
        Name = "Rare"
    };
    public static ItemQuality Epic = new ItemQuality
    {
        Name = "Epic"
    };
    public static ItemQuality Legendary = new ItemQuality
    {
        Name = "Legendary"
    };
    public static ItemQuality Mythic = new ItemQuality
    {
        Name = "Mythic"
    };
    
    public string Name { get; init; } = "";
}

public class WithQuality(ItemQuality quality) : ItemTrait
{
    public ItemQuality Quality { get; init; } = quality;
}