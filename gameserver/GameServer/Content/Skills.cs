using GameServer.Core.Skill;

namespace GameServer.Content;

public static class Skills
{
    #region General
    public static Skill Adventuring = new Skill
    {
        Name = "🧭 Adventuring",
        Description = "Measures your ability to travel, navigate, and survive in the wilds and unknown lands. Enhances exploration, map-reading, and endurance.",
        BaseCost = 26,
        Unlocks = {
            {1, [
                //new CommandUnlock<GotoCommand>()
            ]},
        }
    };

    public static Skill Shadowcraft = new Skill
    {
        Name = "🕶️ Shadowcraft",
        Description = "Governs stealth, disguise, and the art of staying unnoticed. Vital for thieves, spies, and assassins.",
        BaseCost = 74
    };

    public static Skill Mercentile = new Skill
    {
        Name = "💰 Mercentile",
        Description = "Enhances your ability to trade, haggle, and understand market trends. Better deals, rarer goods, and cheaper training.",
        BaseCost = 113
    };

    public static Skill Security = new Skill
    {
        Name = "🔐 Security",
        Description = "The knowledge of locks, traps, and how to create or bypass them. Covers lockpicking, locksmithing, and basic trap disarming.",
        BaseCost = 86
    };

    public static Skill Trapcraft = new Skill
    {
        Name = "🪤 Trapcraft",
        Description = "The art of constructing snares, pressure plates, and magical tripwires. Essential for hunters and dungeon delvers alike.",
        BaseCost = 121
    };
    #endregion

    #region Combat
    public static Skill Swordmanship = new Skill
    {
        Name = "⚔️ Swordmanship",
        Description = "Proficiency with all types of swords. Affects damage, criticals, and special sword techniques.",
    };

    public static Skill Axecraft = new Skill
    {
        Name = "🪓 Axecraft",
        Description = "Mastery of axes in combat. Brutal, close-range destruction and armor shredding."
    };

    public static Skill SmallBlades = new Skill
    {
        Name = "🗡️ Small Blades",
        Description = "Precision and speed with daggers and small knives. Boosts critical strikes, stealth attacks, and dual-wielding."
    };

    public static Skill BluntWeaponry = new Skill
    {
        Name = "🔨 Blunt Weaponry",
        Description = "Proficiency with maces, clubs, and hammers. Great for staggering foes and breaking defenses."
    };
    #endregion

    #region Magic
    public static Skill Nature = new Skill
    {
        Name = "🌿 Nature",
        Description = "Channel the forces of nature. Summon beasts, heal with herbs, and control plant life.",
        BaseCost = 233
    };

    public static Skill Plaguecraft = new Skill
    {
        Name = "☣️ Plaguecraft",
        Description = "Wield disease and decay. Inflict sickness, rot flesh, and curse the unprepared.",
        BaseCost = 233
    };

    public static Skill Necromancy = new Skill
    {
        Name = "💀 Necromancy",
        Description = "Command the dead and steal life from the living. Summon skeletons, raise corpses, and speak with spirits.",
        BaseCost = 233
    };

    public static Skill Elementia = new Skill
    {
        Name = "🔥 Elementia",
        Description = "Control fire, water, air, and earth. Devastate the battlefield with raw elemental fury.",
        BaseCost = 281
    };

    public static Skill Divinity = new Skill
    {
        Name = "✨ Divinity",
        Description = "Tap into divine energies for healing, smiting undead, and warding off evil.",
        BaseCost = 221
    };

    public static Skill Hematurgy = new Skill
    {
        Name = "🩸 Hematurgy",
        Description = "Manipulate your own blood and the blood of others. Sacrifice health for power, torment foes, and empower curses.",
        BaseCost = 267
    };
    #endregion

    #region Crafting
    public static Skill Enchanting = new Skill
    {
        Name = "🔮 Enchanting",
        Description = "Imbue items with magical properties using runes, essences, and arcane rituals. Enhances gear with powerful effects or passive enchantments.",
        BaseCost = 313
    };

    public static Skill Alchemy = new Skill
    {
        Name = "⚗️ Alchemy",
        Description = "Mix potions, elixirs, poisons, and explosive concoctions. A blend of science and sorcery.",
        BaseCost = 297
    };

    public static Skill Blacksmithing = new Skill
    {
        Name = "⚒️ Blacksmithing",
        Description = "Create and enhance metal weapons, armor, and tools. Strong arms, strong gear.",
        BaseCost = 263
    };

    public static Skill Leatherworking = new Skill
    {
        Name = "👝 Leatherworking",
        Description = "Turn beast hides into light armor, cloaks, and pouches. Useful for hunters and rangers.",
        BaseCost = 193
    };

    public static Skill Cooking = new Skill
    {
        Name = "🍳 Cooking",
        Description = "Prepare meals with various effects—healing, buffs, or even magical properties.",
        BaseCost = 83
    };

    public static Skill Carpentry = new Skill
    {
        Name = "🪑 Carpentry",
        Description = "Craft wooden items such as furniture, bows, and housing materials.",
        BaseCost = 166,
    };

    public static Skill Construction = new Skill
    {
        Name = "🏗️ Construction",
        Description = "Build homes, workshops, and fortifications from raw materials. Enables player-created structures and settlements to shape the world around them.",
        BaseCost = 953,
    };
    #endregion

    #region Gathering
    public static Skill Mining = new Skill
    {
        Name = "⛏️ Mining",
        Description = "Extract ore, stone, and rare gems from deep within the earth. Essential for crafting, construction, and uncovering hidden veins of power.",
        BaseCost = 93,
    };

    public static Skill Farming = new Skill
    {
        Name = "🌾 Farming",
        Description = "Grow crops, tend livestock, and harvest natural ingredients. A vital part of any community.",
        BaseCost = 83
    };

    public static Skill Fishing = new Skill
    {
        Name = "🎣 Fishing",
        Description = "Catch fish and aquatic treasures. Useful for food, alchemy, and trade.",
        BaseCost = 27
    };

    public static Skill Logging = new Skill
    {
        Name = "🪓 Logging",
        Description = "Chop down trees and harvest wood efficiently. Critical for construction and tools.",
        BaseCost = 27
    };
    #endregion
}