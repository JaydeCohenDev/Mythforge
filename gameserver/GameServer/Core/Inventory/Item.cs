using GameServer.Core.Inventory.Material;
using GameServer.Core.Inventory.Traits;

namespace GameServer.Core.Inventory;

public enum ItemTag
{
    Gear,
    Weapon,
    Tool
}

public class Item : ICloneable
{
    public static Func<ItemQuality, Item> CreateMiningTool = (quality) => new Item
    {
        Name = "Mining Tool",
        Description = "A mining tool",
        Tags = [ItemTag.Tool],
        Traits = [new WithQuality(quality), new MiningTool()]
    };
    
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<ItemTag> Tags { get; init; } = [];
    public List<ItemTrait> Traits { get; init; } = [];
    
    public T? GetTrait<T>() where T : ItemTrait 
        => Traits.OfType<T>().FirstOrDefault();

    public virtual Item WithTraits(params ItemTrait[] traits)
    {
        Traits.AddRange(traits);
        return this;
    }

    public object Clone()
    {
        return (Item)this.MemberwiseClone();
    }
}

public class Gear : Item
{
    public Gear(GearMaterial material, ItemQuality quality)
    {
        Tags.Add(ItemTag.Gear);

        WithTraits(new MadeOf(material), new WithQuality(quality));
    }

    public new Gear WithTraits(params ItemTrait[] traits)
    {
        base.WithTraits(traits);
        return this;
    }
}

public class Weapon : Gear
{
    public static Weapon SimpleDagger = new Weapon(GearMaterial.Iron, ItemQuality.Common)
    {
        Name = "Simple Dagger",
        Description = "A simple dagger"
    };
    
    public Weapon(GearMaterial material, ItemQuality quality) : base(material, quality)
    {
        Tags.Add(ItemTag.Weapon);
    }

    public new Weapon WithTraits(params ItemTrait[] traits)
    {
        base.WithTraits(traits);
        return this;
    }
}