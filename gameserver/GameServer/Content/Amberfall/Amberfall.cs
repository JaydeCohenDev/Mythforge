using GameServer.Core;
using GameServer.Core.EntityTraits;
using GameServer.Core.Inventory;
using GameServer.Core.Inventory.Traits;

namespace GameServer.Content.Amberfall;

public class Amberfall : Region
{
    public class MarketSquare : Room
    {
        public MarketSquare()
        {
            Name = "Market Square";
            //Tags = [RoomTags.shop, RoomTags.social, RoomTags.trade];
            Description =
                "Stalls of rough wood and faded canvas cluster beneath the golden canopy of overhanging trees. Merchants call out their wares—spiced cider, polished stones, handwoven cloaks—while townsfolk barter under the drifting leaves.";
            Entities =
            [
                new Mob.Mob
                {
                    Name = "Fat Sparrow",
                    PressenceText =
                        "A fat sparrow struts among the market stalls, boldly pecking at stray crumbs with the entitlement of royalty.",
                    Description =
                        "A plump sparrow with toast-brown feathers hops boldly between the market stalls. Its beady eyes scan for crumbs with greedy precision."
                }.AddTraits(new Damageable(10)),
                new Denizen
                {
                    Name = "Tamsen Willowdrop",
                    Role = "Herbalist and seasonal charm seller",
                    PressenceText =
                        "Tamsen Willowdrop arranges bundles of herbs with ritual precision, her lips moving in a whisper only the leaves seem to hear.",
                    Description =
                        "An older human woman with twig-thin fingers, a weathered cloak, and a satchel that smells like a dozen forests. She claims her \"weather charms\" keep orchards from frost.",
                    OnGreet = (player, self) =>
                    {
                        self.Tell(player, "murmurs like wind through leaves",
                            "Ah, the air shifted when you walked in... Come for rosemary, or something rarer?");
                    }
                },
                new Denizen
                {
                    Name = "Brillan Caskturn",
                    Role = "Cider merchant and overenthusiastic barker",
                    PressenceText =
                        "Brillan Caskturn shouts over the bustle, holding up a bottle in each hand. “Two for a silver! Blessed by the orchard spirits themselves!”",
                    Description =
                        "A broad-shouldered dwarf with a permanent cider stain on his tunic and a voice like a crashing barrel.",
                    OnGreet = (player, self) =>
                    {
                        self.Tell(player, "booms like a festival drum",
                            "HO THERE, THIRSTY TRAVELER! Ever tasted autumn in a bottle? No? WELL TODAY’S YOUR LUCKY DAY!");
                    }
                }
            ];
        }
    }

    public class FoxAndFellow : Room
    {
        public FoxAndFellow()
        {
            Name = "Fox & Fellow";
            //Tags = [RoomTags.inn, RoomTags.social, RoomTags.rest];
            Description =
                "Laughter and low music spill from the tavern’s crooked doorway, its sign bearing a fox and a gentleman in a tricorn hat. The hearth burns bright, and the scent of roast squash and strong cider welcomes you in.";
            Entities =
            [
                new Denizen
                {
                    Name = "Wynna Bramblecask",
                    Role = "Tavernkeeper of the Fox & Fellow",
                    PressenceText =
                        "<span class='npc'>Wynna Bramblecask</span> bustles behind the bar, humming a harvest tune as she polishes mugs with a flick of her wrist.",
                    Description =
                        "Wynna Bramblecask is a stout, warm-hearted halfling with wild, curly auburn hair tucked under a cider-stained kerchief. Her sleeves are always rolled, her laugh always ready, and her belt carries more keys, ladles, and corkscrews than any one person should rightfully need. She’s run the Fox & Fellow for decades, and knows everyone’s business—sometimes before they do.",
                    OnGreet = (player, self) =>
                    {
                        self.Tell(player, "chuckles warmly, eyes twinkling",
                            "Well look what the wind blew in! Hungry, thirsty, or just need a bit of gossip with your pint?");
                    }
                },
                new Mob.Mob
                {
                    Name = "Lazy Tavern Cat",
                    PressenceText = "A lazy tavern cat is sprawled on a barstool, tail twitching lazily.",
                    Description =
                        "This portly, smoke-colored cat lounges wherever the warmest patch of floor is, usually near the fire or curled in an empty chair. Her eyes blink slowly, unimpressed by adventurers and unbothered by noise. She rules the tavern with a flick of her tail and the occasional disdainful meow."
                },
                new Denizen
                {
                    Name = "Nessa Flintbranch",
                    Role = "Wandering bard",
                    PressenceText =
                        "Nessa Flintbranch tunes her lute in a sunbeam by the window, plucking quiet notes that sound like distant memories.",
                    Description =
                        "A young half-elf with callused fingers, a chipped lute, and stories in her eyes. She trades songs for beds and questions for verses.",
                    OnGreet = (player, self) =>
                    {
                        self.Tell(player, "speaks like a lyric half-remembered",
                            "Care for a tale, or shall I sing you the silence between one?");
                    }
                }
            ];
        }
    }

    public class MossAndMortar : Room
    {
        public MossAndMortar()
        {
            Name = "Moss & Mortar";
            //Tags = [RoomTags.alchemy, RoomTags.shop, RoomTags.social];
            Description =
                "A crooked little shop stuffed with drying herbs, bottled moonlight, and forest oddities. The air buzzes faintly with magic, and a small bell jingles as you enter beneath a branch-bound sign.";
            Entities =
            [
                new Denizen
                {
                    Name = "Elorric “El” Vale",
                    Role = "Apprentice potionmaker (and amateur alchemist)",
                    PressenceText =
                        "<name>Elorric Vale</name> frowns at a bubbling flask, muttering, “Okay… this time with less toadspit...”",
                    Description =
                        "A nervous half-elf with ink-stained sleeves and burn marks on his fingers. Constantly trying new things. Not all of them legal.",
                    OnGreet = (player, self) =>
                    {
                        self.Tell(player, "blurts out mid-panic, eyes wide",
                            "Wait—don't touch that! Oh. Uh. Hi! Sorry. You, uh, didn’t happen to bring any powdered bat whiskers, did you?");
                    }
                }
            ];
        }
    }

    public class SouthshadeLane : Room
    {
        public SouthshadeLane()
        {
            Name = "Southshade Lane";
            //Tags = [RoomTags.residential, RoomTags.farming, RoomTags.homes];
            Description =
                "The southern stretch of town is quieter—cobbled paths lined with orchard cottages, chicken coops, and low stone walls. Children play under apple trees while elders sip cider and gossip on worn benches.";
            Entities =
            [
                new Denizen
                {
                    Name = "Gran Mayra",
                    Role = "Town elder, knows every family story",
                    PressenceText =
                        "Gran Mayrarocks gently in her creaky chair, offering a nod that somehow feels like a full interrogation.",
                    Description =
                        "A hunched old woman in a knit shawl who sits on her porch shelling nuts and judging the clouds.",
                    OnGreet = (player, self) =>
                    {
                        self.Tell(player, "drawls slow and steady, with a smile that knows too much",
                            "Mmm. You’ve got your mother’s walk… and your grandfather’s trouble behind the eyes. Sit a spell. Let’s see what else you’ve inherited.");
                    }
                }
            ];
        }
    }

    public class Barracks : Room
    {
        public Barracks()
        {
            Name = "The Watchman’s Lodge";
            //Tags = [RoomTags.millitary, RoomTags.training, RoomTags.quest];
            Description =
                "The barracks sit tucked between the orchard’s edge and the watch path. Training dummies lean against the fence, and you hear the clink of armor and barked drills within.";
            Entities =
            [
                new Denizen
                {
                    Name = "Ser Darn Hollowfall",
                    Role = "Captain of the Orchard Watch",
                    PressenceText =
                        "<name>Ser Darn</name> leans back in his chair, chewing an apple core, watching recruits with one eye open and one hand on his blade.",
                    Description =
                        "A scarred, sleepy-eyed human who prefers storytelling over swordplay—until the trouble starts. He teaches Swordmanship.",
                    OnGreet = (player, self) =>
                    {
                        self.Tell(player, "speaks around an apple bite, lazy drawl",
                            "If you’re here to join up, hope you brought boots and a good excuse. If not—well, pull up a crate and tell me why you’re still breathing.");
                    }
                }.AddTraits(new SkillTeacher(Skills.Swordmanship)),
                new Mob.Mob
                {
                    Name = "Watch Hound",
                    PressenceText = "A watch hound lies near the wall, eyes scanning the yard with quiet vigilance.",
                    Description =
                        "A muscular hound with brindled fur and sharp eyes. It pads silently beside the guards, ears perked and tail held low. Loyal and alert, it only growls when it senses something out of place."
                }
            ];
        }
    }

    public class WatchTower : Room
    {
        public WatchTower()
        {
            Name = "The Timber Crown";
            //Tags = [RoomTags.millitary, RoomTags.exploration, RoomTags.high_ground];
            Description =
                "A tall wooden tower rises above the treetops, its frame dark with age but sturdy still. From here, one can see the Emberwood stretching endlessly east—and the winding roads that bring both trade and trouble.";
            Entities =
            [
                new Denizen
                {
                    Name = "Mira Kestrel",
                    Role = "Night watch scout and stargazer",
                    PressenceText =
                        "Mira Kestrel stands at the tower window, telescope raised, eyes following stars—or something darker.",
                    Description =
                        "A quiet, sharp-eyed ranger with a weather-beaten cloak and a notebook full of constellations and forest movement.",
                    OnGreet = (player, self) =>
                    {
                        self.Tell(player, "says softly, without turning from the stars",
                            "You're out late. Sky’s clear… but not everything watching you comes from above.");
                    }
                }
            ];
        }
    }

    public class HighbranchRow : Room
    {
        public HighbranchRow()
        {
            Name = "Highbranch Row";
            //Tags = [RoomTags.residential, RoomTags.noble, RoomTags.historic];
            Description =
                "Perched on a low hill, the homes here are older, their mossy roofs and thick shutters whispering of generations past. The air feels cooler, and the leaves fall slower up here.";
        }
    }

    public class Temple : Room
    {
        public Temple()
        {
            Name = "The Grove Chapel";
            //Tags = [RoomTags.religion, RoomTags.magic, RoomTags.quest];
            Description =
                "Carved of honey-colored stone, the chapel is quiet and warm, lit by rows of floating candles. Forest offerings line the steps: bundles of herbs, carved acorns, feathers, and smooth river stones.";
            Entities =
            [
                new Denizen
                {
                    Name = "Brother Halewin",
                    Role = "Caretaker of the temple",
                    PressenceText =
                        "Brother Halewin kneels before a candlelit altar, arranging leaves and bones into quiet spirals.",
                    Description =
                        "A soft-spoken, gentle man with bark-brown robes and sap on his fingertips. Said to have once heard the forest speak.",
                    OnGreet = (player, self) =>
                    {
                        self.Tell(player, "whispers like moss growing",
                            "Peace upon your roots, traveler. The grove remembers your steps… even if you do not.");
                    }
                }
            ];
        }
    }

    public class AmberholdManor : Room
    {
        public AmberholdManor()
        {
            Name = "Amberhold Manor";
            //Tags = [RoomTags.noble, RoomTags.historic, RoomTags.religion];
            Description =
                "Once a summer retreat for the lesser line of a distant royal house, the manor is modest but elegant. Ivy climbs its pillars, and its windows glow with quiet candlelight—even when no one's home.";
            Entities =
            [
                new Denizen
                {
                    Name = "Lady Ceirine Autumnvale",
                    Role = "Keeper of the manor, descendant of the old royal line",
                    PressenceText =
                        "Lady Ceirine stands at the manor window, unmoving as she watches the wind stir the trees below.",
                    Description =
                        "Pale and poised, with golden hair braided like vines and a voice like wind in long halls. Keeps to herself, mostly.",
                    OnGreet = (player, self) =>
                    {
                        self.Tell(player, "speaks like a faded echo down marble corridors",
                            "You walk paths once meant for kings. Tell me… do they whisper to you, too?");
                    }
                }
            ];
        }
    }
    
    public Amberfall() : base()
    {
        
        Name = "Amberfall";
        Description = "You stand at the edge of Amberfall, a quiet orchard town where golden leaves drift endlessly from the trees. Wooden bridges span a murmuring stream that winds through mossy cottages and cider-sweet groves. The scent of apples and woodsmoke hangs in the air, and faint charms dangle from doorways, clinking softly in the breeze. To the north, the shadow of the Emberwood looms—ancient, watchful, and not entirely silent.";
        All.Add(Name.ToId(), this);
        Room? marketSquare = AddRoom(new Room
        {
            Name = "Market Square",
            //Tags = [RoomTags.shop, RoomTags.social, RoomTags.trade],
            Description = "Stalls of rough wood and faded canvas cluster beneath the golden canopy of overhanging trees. Merchants call out their wares—spiced cider, polished stones, handwoven cloaks—while townsfolk barter under the drifting leaves.",
            Entities = [
                new Mob.Mob{
                    Name = "Fat Sparrow",
                    PressenceText = "A fat sparrow struts among the market stalls, boldly pecking at stray crumbs with the entitlement of royalty.",
                    Description = "A plump sparrow with toast-brown feathers hops boldly between the market stalls. Its beady eyes scan for crumbs with greedy precision."
                }.AddTraits(new Damageable(10)),
                new Denizen {
                    Name = "Tamsen Willowdrop",
                    Role = "Herbalist and seasonal charm seller",
                    PressenceText = "Tamsen Willowdrop arranges bundles of herbs with ritual precision, her lips moving in a whisper only the leaves seem to hear.",
                    Description = "An older human woman with twig-thin fingers, a weathered cloak, and a satchel that smells like a dozen forests. She claims her \"weather charms\" keep orchards from frost.",
                    OnGreet = (player, self) => {
                        self.Tell(player, "murmurs like wind through leaves", "Ah, the air shifted when you walked in... Come for rosemary, or something rarer?");
                    }
                },
                new Denizen {
                    Name = "Brillan Caskturn",
                    Role = "Cider merchant and overenthusiastic barker",
                    PressenceText = "Brillan Caskturn shouts over the bustle, holding up a bottle in each hand. “Two for a silver! Blessed by the orchard spirits themselves!”",
                    Description = "A broad-shouldered dwarf with a permanent cider stain on his tunic and a voice like a crashing barrel.",
                    OnGreet = (player, self) => {
                        self.Tell(player, "booms like a festival drum", "HO THERE, THIRSTY TRAVELER! Ever tasted autumn in a bottle? No? WELL TODAY’S YOUR LUCKY DAY!");
                    }
                }
            ]
        });
        var generalStore = new Room
        {
            Name = "The Hollow Log",
            //Tags = [RoomTags.shop, RoomTags.social, RoomTags.trade],
            Description = "Tucked beneath the sweeping boughs of an old oak, The Hollow Log is a cozy general store built partly into the trunk of a fallen tree. Shelves carved from the wood itself hold everything from bundles of herbs to coiled rope and clay pots. The scent of beeswax and dried apples lingers in the air.",
            Entities = [
                new Denizen
                {
                    Name = "Merrin Thistlewick",
                    Role = "Shopkeeper of The Hollow Log",
                    PressenceText = "<name>Merrin Thistlewick</name> arranges jars on the counter, pausing to brush wood shavings from his apron with a calloused hand.",
                    Description = "Merrin Thistlewick is a wiry human man in his middle years, with streaks of grey in his chestnut hair and a perpetual smudge of sawdust on his cheeks. His eyes are sharp and warm, like cider on a chill morning, and his hands work tirelessly to stock the shop with both everyday needs and the occasional curiosity from the Emberwood. Merrin has a quiet way about him, speaking softly but with purpose, and always seems to know exactly what you came looking for.",
                    OnGreet = (player, self) =>
                    {
                        self.Tell(player, "gives you a nod and a faint smile", "If you're looking to trade, you're in the right place. Tools, trinkets, or tales—I've got a little of everything.");
                    },
                    Traits = [new Vendor([
                        new Vendor.VendorWare
                        {
                            Item = new Item
                            {
                                Name = "Old Shoddy Pickaxe",
                                Description = "",
                                Tags = [ItemTag.Tool],
                                Traits = [
                                    new WithQuality(ItemQuality.Common),
                                    new MiningTool(),
                                    new Equippable(HumanoidEquipmentSlot.MainHand)
                                ]
                            },
                            Price = 15,
                        }
                    ])]
                }
            ]
        };
        var tavern = new Room
        {
            Name = "Fox & Fellow",
            //Tags = [RoomTags.inn, RoomTags.social, RoomTags.rest],
            Description = "Laughter and low music spill from the tavern’s crooked doorway, its sign bearing a fox and a gentleman in a tricorn hat. The hearth burns bright, and the scent of roast squash and strong cider welcomes you in.",
            Entities = [
                new Denizen{
                    Name = "Wynna Bramblecask",
                    Role = "Tavernkeeper of the Fox & Fellow",
                    PressenceText = "<span class='npc'>Wynna Bramblecask</span> bustles behind the bar, humming a harvest tune as she polishes mugs with a flick of her wrist.",
                    Description = "Wynna Bramblecask is a stout, warm-hearted halfling with wild, curly auburn hair tucked under a cider-stained kerchief. Her sleeves are always rolled, her laugh always ready, and her belt carries more keys, ladles, and corkscrews than any one person should rightfully need. She’s run the Fox & Fellow for decades, and knows everyone’s business—sometimes before they do.",
                    OnGreet = (player, self) => {
                        self.Tell(player, "chuckles warmly, eyes twinkling", "Well look what the wind blew in! Hungry, thirsty, or just need a bit of gossip with your pint?");
                    }
                },
                new Mob.Mob{
                    Name = "Lazy Tavern Cat",
                    PressenceText = "A lazy tavern cat is sprawled on a barstool, tail twitching lazily.",
                    Description = "This portly, smoke-colored cat lounges wherever the warmest patch of floor is, usually near the fire or curled in an empty chair. Her eyes blink slowly, unimpressed by adventurers and unbothered by noise. She rules the tavern with a flick of her tail and the occasional disdainful meow."
                },
                new Denizen{
                    Name = "Nessa Flintbranch",
                    Role = "Wandering bard",
                    PressenceText = "<span class='npc'>Nessa Flintbranch</span> tunes her lute in a sunbeam by the window, plucking quiet notes that sound like distant memories.",
                    Description = "A young half-elf with callused fingers, a chipped lute, and stories in her eyes. She trades songs for beds and questions for verses.",
                    OnGreet = (player, self) => {
                        self.Tell(player, "speaks like a lyric half-remembered", "Care for a tale, or shall I sing you the silence between one?");
                    }
                }
            ]
        };
        var alchemyShop = new Room
        {
            Name = "Moss & Mortar",
            //Tags = [RoomTags.alchemy, RoomTags.shop, RoomTags.social],
            Description = "A crooked little shop stuffed with drying herbs, bottled moonlight, and forest oddities. The air buzzes faintly with magic, and a small bell jingles as you enter beneath a branch-bound sign.",
            Entities = [
                new Denizen{
                    Name = "Elorric “El” Vale",
                    Role = "Apprentice potionmaker (and amateur alchemist)",
                    PressenceText = "<name>Elorric Vale</name> frowns at a bubbling flask, muttering, “Okay… this time with less toadspit...”",
                    Description = "A nervous half-elf with ink-stained sleeves and burn marks on his fingers. Constantly trying new things. Not all of them legal.",
                    OnGreet = (player, self) => {
                        self.Tell(player, "blurts out mid-panic, eyes wide", "Wait—don't touch that! Oh. Uh. Hi! Sorry. You, uh, didn’t happen to bring any powdered bat whiskers, did you?");
                    }
                }
            ]
        };
        AddLinkedSubRooms(marketSquare, [tavern, alchemyShop, generalStore]);

        Room? lowerAmberfall = AddRoom(new Room
        {
            Name = "Southshade Lane",
            //Tags = [RoomTags.residential, RoomTags.farming, RoomTags.homes],
            Description = "The southern stretch of town is quieter—cobbled paths lined with orchard cottages, chicken coops, and low stone walls. Children play under apple trees while elders sip cider and gossip on worn benches.",
            Entities = [
                new Denizen{
                    Name = "Gran Mayra",
                    Role = "Town elder, knows every family story",
                    PressenceText = "<span class='npc'>Gran Mayra</span> rocks gently in her creaky chair, offering a nod that somehow feels like a full interrogation.",
                    Description = "A hunched old woman in a knit shawl who sits on her porch shelling nuts and judging the clouds.",
                    OnGreet = (player, self) => {
                        self.Tell(player, "drawls slow and steady, with a smile that knows too much", "Mmm. You’ve got your mother’s walk… and your grandfather’s trouble behind the eyes. Sit a spell. Let’s see what else you’ve inherited.");
                    }
                }
            ]
        });
        var barracks = new Room
        {
            Name = "The Watchman’s Lodge",
            //Tags = [RoomTags.millitary, RoomTags.training, RoomTags.quest],
            Description = "The barracks sit tucked between the orchard’s edge and the watch path. Training dummies lean against the fence, and you hear the clink of armor and barked drills within.",
            Entities = [
                new Denizen{
                    Name = "Ser Darn Hollowfall",
                    Role = "Captain of the Orchard Watch",
                    PressenceText = "<name>Ser Darn</name> leans back in his chair, chewing an apple core, watching recruits with one eye open and one hand on his blade.",
                    Description = "A scarred, sleepy-eyed human who prefers storytelling over swordplay—until the trouble starts. He teaches Swordmanship.",
                    OnGreet = (player, self) => {
                        self.Tell(player, "speaks around an apple bite, lazy drawl", "If you’re here to join up, hope you brought boots and a good excuse. If not—well, pull up a crate and tell me why you’re still breathing.");
                    }
                }.AddTraits(new SkillTeacher(Skills.Swordmanship)),
                new Mob.Mob{
                    Name = "Watch Hound",
                    PressenceText = "A watch hound lies near the wall, eyes scanning the yard with quiet vigilance.",
                    Description = "A muscular hound with brindled fur and sharp eyes. It pads silently beside the guards, ears perked and tail held low. Loyal and alert, it only growls when it senses something out of place."
                }
            ]
        };
        var watchTower = new Room
        {
            Name = "The Timber Crown",
            //Tags = [RoomTags.millitary, RoomTags.exploration, RoomTags.high_ground],
            Description = "A tall wooden tower rises above the treetops, its frame dark with age but sturdy still. From here, one can see the Emberwood stretching endlessly east—and the winding roads that bring both trade and trouble.",
            Entities = [
                new Denizen{
                    Name = "Mira Kestrel",
                    Role = "Night watch scout and stargazer",
                    PressenceText = "<span class='npc'>Mira Kestrel</span> stands at the tower window, telescope raised, eyes following stars—or something darker.",
                    Description = "A quiet, sharp-eyed ranger with a weather-beaten cloak and a notebook full of constellations and forest movement.",
                    OnGreet = (player, self) => {
                        self.Tell(player, "says softly, without turning from the stars", "You're out late. Sky’s clear… but not everything watching you comes from above.");
                    }
                }
            ]
        };
        AddLinkedSubRooms(lowerAmberfall, [barracks, watchTower]);

        Room? upperAmberfall = AddRoom(new Room
        {
            Name = "Highbranch Row",
            //Tags = [RoomTags.residential, RoomTags.noble, RoomTags.historic],
            Description = "Perched on a low hill, the homes here are older, their mossy roofs and thick shutters whispering of generations past. The air feels cooler, and the leaves fall slower up here."
        });
        var temple = new Room
        {
            Name = "The Grove Chapel",
            //Tags = [RoomTags.religion, RoomTags.magic, RoomTags.quest],
            Description = "Carved of honey-colored stone, the chapel is quiet and warm, lit by rows of floating candles. Forest offerings line the steps: bundles of herbs, carved acorns, feathers, and smooth river stones.",
            Entities = [
                new Denizen{
                    Name = "Brother Halewin",
                    Role = "Caretaker of the temple",
                    PressenceText = "<span class='npc'>Brother Halewin</span> kneels before a candlelit altar, arranging leaves and bones into quiet spirals.",
                    Description = "A soft-spoken, gentle man with bark-brown robes and sap on his fingertips. Said to have once heard the forest speak.",
                    OnGreet = (player, self) => {
                        self.Tell(player, "whispers like moss growing", "Peace upon your roots, traveler. The grove remembers your steps… even if you do not.");
                    }
                }
            ]
        };
        var royalQuarters = new Room
        {
            Name = "Amberhold Manor",
            //Tags = [RoomTags.noble, RoomTags.historic, RoomTags.religion],
            Description = "Once a summer retreat for the lesser line of a distant royal house, the manor is modest but elegant. Ivy climbs its pillars, and its windows glow with quiet candlelight—even when no one's home.",
            Entities = [
                new Denizen{
                    Name = "Lady Ceirine Autumnvale",
                    Role = "Keeper of the manor, descendant of the old royal line",
                    PressenceText = "<span class='npc'>Lady Ceirine</span> stands at the manor window, unmoving as she watches the wind stir the trees below.",
                    Description = "Pale and poised, with golden hair braided like vines and a voice like wind in long halls. Keeps to herself, mostly.",
                    OnGreet = (player, self) => {
                        self.Tell(player, "speaks like a faded echo down marble corridors", "You walk paths once meant for kings. Tell me… do they whisper to you, too?");
                    }
                }
            ]
        };
        AddLinkedSubRooms(upperAmberfall, [temple, royalQuarters]);

        LinkRooms(marketSquare, upperAmberfall, lowerAmberfall);
    }
}
