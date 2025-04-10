namespace GameServer.Core.Inventory.Material;

public class GearMaterial
{
    public static GearMaterial Iron = new GearMaterial
    {
        Name = "Iron",
        Description = "A basic metal"
    };
    
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
}