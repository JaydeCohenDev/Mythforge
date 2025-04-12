using GameServer.Core;

namespace GameServer.Content.Amberfall;

public class Emberwood : Region
{
    public class EmberwoodEdge : Room
    {
        public EmberwoodEdge()
        {
            Name = "Emberwood Edge";
            //Tags = [RoomTags.emberwood, RoomTags.forest, RoomTags.wilderness];
            Description = "You stand beneath towering, amber-leafed trees at the edge of the Emberwood. Shafts of sunlight filter through the dense canopy, casting dancing patterns on the mossy ground. The forest feels watchful here, as if holding its breath.";
        }
    }

    public class EmberPath : Room
    {
        public EmberPath()
        {
            Name = "Ember Path";
            //Tags = [RoomTags.emberwood, RoomTags.forest, RoomTags.wilderness];
            Description = "Lantern posts line the winding path, their lights long extinguished. The trail grows narrower as it snakes beneath ancient boughs, the ground soft beneath your boots with a thick layer of fallen leaves.";
        }
    }

    public class WhisperingThicket : Room
    {
        public WhisperingThicket()
        {
            Name = "Whispering Thicket";
            //Tags = [RoomTags.emberwood, RoomTags.forest, RoomTags.wilderness];
            Description = "The thicket tightens around you, branches clawing at your sleeves. Soft whispers ride the breeze, though no figures are in sight. Faint trails crisscross the undergrowth, some ending abruptly in gnarled roots.";
        }
    }

    public Emberwood() : base()
    {
        Name = "Emberwood";
        Description = "";
        All.Add(Name.ToId(), this);

        Room? emberwoodEdge = AddRoom(new Room
        {
            Name = "Emberwood Edge",
            //Tags = [RoomTags.emberwood, RoomTags.forest, RoomTags.wilderness],
            Description = "You stand beneath towering, amber-leafed trees at the edge of the Emberwood. Shafts of sunlight filter through the dense canopy, casting dancing patterns on the mossy ground. The forest feels watchful here, as if holding its breath."
        });
        Room? emberPath = AddRoom(new Room
        {
            Name = "Ember Path",
            //Tags = [RoomTags.emberwood, RoomTags.forest, RoomTags.wilderness],
            Description = "Lantern posts line the winding path, their lights long extinguished. The trail grows narrower as it snakes beneath ancient boughs, the ground soft beneath your boots with a thick layer of fallen leaves."
        });
        Room? whisperingThicket = AddRoom(new Room
        {
            Name = "Whispering Thicket",
            //Tags = [RoomTags.emberwood, RoomTags.forest, RoomTags.wilderness],
            Description = "The thicket tightens around you, branches clawing at your sleeves. Soft whispers ride the breeze, though no figures are in sight. Faint trails crisscross the undergrowth, some ending abruptly in gnarled roots."
        });
        Room? wishingPool = AddRoom(new Room
        {
            Name = "Wishing Pool",
            //Tags = [RoomTags.pond, RoomTags.emberwood, RoomTags.wilderness],
            Description = "The crystal-clear surface of the pool reflects the sky perfectly, as though untouched by time. Offerings of carved wood and silver leaves rest on the mossy stones along the bank."
        });
        Room? foxgloveCrossing = AddRoom(new Room
        {
            Name = "Foxglove Crossing",
            //Tags = [RoomTags.pond, RoomTags.emberwood, RoomTags.wilderness],
            Description = "A stone bridge spans the stream here, foxglove blooms bursting from the cracks between the stones. Water murmurs below, carrying fallen leaves downstream toward Applehearth Mill."
        });
        LinkSequential(emberPath, whisperingThicket, wishingPool, foxgloveCrossing);
        LinkRooms([emberPath, emberwoodEdge]);

        Room? lanternHollow = AddRoom(new Room
        {
            Name = "Lantern Hollow",
            //Tags = [RoomTags.emberwood, RoomTags.wilderness],
            Description = "A wide clearing opens beneath the sky, colorful ribbons and old lantern hooks swaying in the breeze. The grass bears the marks of recent gatherings: fire pits, trampled earth, and leftover charms fluttering from poles."
        });
        Room? applehearthMill = AddRoom(new Room
        {
            Name = "Applehearth Mill",
            //Tags = [RoomTags.farm, RoomTags.wilderness],
            Description = "The mill wheel creaks as the stream presses onward, its steady turning filling the quiet glade. Sacks of grain and crates of cider sit stacked beneath a wooden awning, awaiting transport back to Amberfall."
        });
        Room? orchardRows = AddRoom(new Room
        {
            Name = "Orchard Rows",
            //Tags = [RoomTags.spring, RoomTags.wilderness],
            Description = "Neat rows of apple and pear trees stretch in orderly lines, their branches heavy with fruit. The air is thick with the scent of ripening harvest, and fallen leaves crunch beneath your feet. Bees hum lazily between blossoms, and baskets sit ready for the picking."
        });
        Room? harvestGrounds = AddRoom(new Room
        {
            Name = "Harvest Grounds",
            Description = "This broad field bears the lively scars of hard work and celebration. Fire pits and carving tables stand beneath colorful banners strung between wooden poles. Wicker effigies and lantern frames lean against crates, waiting for festival hands to bring them to life."
        });
        LinkSequential(applehearthMill, orchardRows, harvestGrounds);
        LinkRooms(applehearthMill, lanternHollow);

        Room? cemetary = AddRoom(new Room
        {
            Name = "Autumn's Rest Cemetary",
            //Tags = [RoomTags.cemetary, RoomTags.wilderness],
            Description = "Weathered gravestones lean beneath a grove of crimson-leafed maples, their roots curling over forgotten names. Wind stirs loose leaves into quiet spirals among moss-covered statues."
        });
        Room? hollowBarrows = AddRoom(new Room
        {
            Name = "Hollow Barrows",
            //Tags = [RoomTags.cemetary, RoomTags.wilderness],
            Description = "Low mounds rise from the earth, their entrances dark and cool. Carvings of forgotten runes edge the stonework, half-choked by ivy and time. A chill clings to the air here."
        });
        Room? burialHill = AddRoom(new Room
        {
            Name = "Burial Hill",
            //Tags = [RoomTags.cemetary, RoomTags.wilderness],
            Description = "You climb the gentle slope of Burial Hill, where twisted roots break through the soil like grasping fingers. Old graves here are marked with crumbling stones, half-swallowed by moss and time. The wind whistles between the markers, carrying whispers of lives long passed."
        });
        Room? forgottenShrine = AddRoom(new Room
        {
            Name = "Forgotten Shrine",
            //Tags = [RoomTags.magic, RoomTags.wilderness],
            Description = "Nestled between leaning oaks and ivy-draped stones, the shrine is little more than a circle of carved rocks, worn smooth by centuries of rain. Faint markings, perhaps once sacred, linger beneath the moss. A quiet weight hangs in the air, as though the shrine still waits for offerings."
        });
        LinkSequential(hollowBarrows, burialHill, forgottenShrine);
        LinkRooms(burialHill, cemetary);

        LinkRooms(emberwoodEdge, lanternHollow, cemetary);

    }
}