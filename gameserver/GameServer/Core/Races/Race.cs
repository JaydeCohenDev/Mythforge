namespace GameServer.Core.Races;

public class Race
{

    public static Race Human = new Race
    {
        Name = "Human",
        Description = "Adaptable and ambitious, humans thrive in every corner of the world. Known for their resilience and drive to shape their own destiny."
    };

    public static Race Elf = new Race
    {
        Name = "Elf",
        Description = "Graceful and long-lived, elves are deeply attuned to nature and magic. They value wisdom, beauty, and harmony with the natural world."
    };

    public static Race Dwarf = new Race
    {
        Name = "Dwarf",
        Description = "Stout and steadfast, dwarves are master craftsmen and fierce warriors. They build great halls beneath the mountains and prize honor above all."
    };
    
    public static Race Orc = new Race
    {
        Name = "Orc",
        Description = "Fierce and proud, orcs value strength, survival, and clan loyalty. Their courage in battle is legendary, and their resilience unmatched."
    };
    
    public static Race Undead = new Race
    {
        Name = "Undead",
        Description = "Raised from death by dark magic, the undead persist through sheer will. Though feared by many, they possess ancient knowledge and grim determination."
    };

    public static Race Ogre = new Race
    {
        Name = "Ogre",
        Description = "Towering and brutal, ogres rely on raw strength and toughness. Feared across battlefields, they smash through foes with overwhelming force."
    };

    public static Race Goblin = new Race
    {
        Name = "Goblin",
        Description = "Clever and cunning, goblins thrive in chaos. Masters of traps and tricks, they turn scrap into weapons and schemes into fortunes."
    };
    
    public static Race Vampire = new Race
    {
        Name = "Vampire",
        Description = "Cursed with eternal hunger, vampires stalk the living for sustenance. Immortal and seductive, they wield dark powers and unnatural charm."
    };

    public static Race Serpentkin = new Race
    {
        Name = "Serpentkin",
        Description = "Snake-like and stealthy, serpentkin move with grace and precision. Masters of venom and ambush, they strike swiftly from the shadows."
    };
    
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
}