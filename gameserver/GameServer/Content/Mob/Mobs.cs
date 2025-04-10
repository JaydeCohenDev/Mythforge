namespace GameServer.Content.Mob;

public static class Mobs
{
    /* FOREST */
    public static Mob MossbackElk = new Mob
    {
        // Rarity = Uncommon
        Name = "Mossback Elk",
        PressenceText = "A Mossback Elk stands tall amid the underbrush, its moss-covered form blending almost perfectly with the forest.",
        Description = "A towering elk, its hide covered in thick moss and creeping ivy. Its antlers stretch like twisted branches, heavy with hanging vines.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.forest, RoomTags.wilderness)]
    };

    public static Mob WhisperingWisp = new Mob
    {
        // Rarity = Uncommon
        Name = "Whispering Wisp",
        PressenceText = "A Whispering Wisp drifts lazily between the trees, its glow pulsing in time with your heartbeat.",
        Description = "A pale blue wisp floats just above the ground, flickering like a candle in the wind. Its faint whispers brush against your thoughts, luring you deeper.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.forest, RoomTags.wilderness)]
    };

    public static Mob ThornhideWolf = new Mob
    {
        // Rarity = Common
        Name = "Thornhide Wolf",
        PressenceText = "A Thornhide Wolf prowls nearby, its thorny pelt snagging against low branches as it watches you.",
        Description = "A sleek predator, its fur matted with thorns and burrs from the undergrowth. Amber eyes gleam with feral cunning as it stalks its prey.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.forest, RoomTags.wilderness)]
    };

    public static Mob GroveGuardian = new Mob
    {
        // Rarity = Rare
        Name = "Grove Guardian",
        PressenceText = "Grove Guardian lumbers into view, creaking like an old oak in a storm.",
        Description = "An ancient sentinel of living wood, barklike skin carved with natural runes. Slow but relentless, it protects the forest from intruders.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.forest, RoomTags.wilderness)]
    };

    public static Mob GlowBeetleSwarm = new Mob
    {
        // Rarity = Common
        Name = "Glow Beetle Swarm",
        PressenceText = "A Glow Beetle Swarm flares bright as it shifts, a thousand tiny lights swirling in the air.",
        Description = "A shimmering cloud of tiny beetles, their shells casting green and gold light in every direction. They move with an almost hive-mind precision.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.forest, RoomTags.wilderness)]
    };

    /* EMBERWOOD */
    public static Mob AmberStag = new Mob
    {
        // Rarity = Rare
        Name = "Amber Stag",
        PressenceText = "An Amber Stag steps gracefully between the amber-leafed trees, its golden antlers catching the filtered light.",
        Description = "A regal deer with golden-amber antlers that seem to glow softly in the forest gloom. To see it is said to bring either great fortune or deep misfortune.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.emberwood, RoomTags.wilderness)]
    };

    public static Mob LanternMoth = new Mob
    {
        // Rarity = Common
        Name = "Lantern Moth",
        PressenceText = "A Lantern Moth drifts lazily past, its gentle glow casting shifting patterns on the mossy ground.",
        Description = "A large moth that emits a warm, flickering light from its wings. These creatures fill the Emberwood twilight like floating lanterns.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.emberwood, RoomTags.wilderness)]
    };

    public static Mob WhisperrootCreeper = new Mob
    {
        // Rarity = Uncommon
        Name = "Whisperroot Creeper",
        PressenceText = "A Whisperroot Creeper slithers slowly across the forest floor, vines coiling as if tasting the air.",
        Description = "Animated vines, twisted by ancient magic, that slither across the mossy ground. Their movement is accompanied by faint rustling whispers.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.emberwood, RoomTags.wilderness)]
    };

    public static Mob DuskhollowOwl = new Mob
    {
        // Rarity = Uncommon
        Name = "Duskhollow Owl",
        PressenceText = "A Duskhollow Owl watches silently from a low branch, its dark eyes reflecting the shifting light.",
        Description = "A silent predator with deep, dark eyes that seem to follow your every move. Its eerie calls are said to mimic voices heard in dreams.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.emberwood, RoomTags.wilderness)]
    };

    public static Mob VeilshadeFox = new Mob
    {
        // Rarity = Rare
        Name = "Veilshade Fox",
        PressenceText = "A Veilshade Fox flickers at the edge of your vision, vanishing into the mist before you can focus.",
        Description = "A phantom-like fox with a smoky, shadowy coat. Known to vanish into the morning mists, it is a creature of quiet cunning and fleeting glimpses.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.emberwood, RoomTags.wilderness)]
    };

    public static Mob EmberwoodWisp = new Mob
    {
        // Rarity = Uncommon
        Name = "Emberwood Wisp",
        PressenceText = "An Emberwood Wisp floats between the trunks, its amber glow pulsing gently in the gloom.",
        Description = "A drifting light that seems to guide — or mislead — those who follow it. Some say the wisps are echoes of lost souls searching for a way home.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.emberwood, RoomTags.wilderness)]
    };

    public static Mob GloamBeetle = new Mob
    {
        // Rarity = Common
        Name = "Gloam Beetle",
        PressenceText = "A Gloam Beetle scuttles across the bark, its ember-like glow casting tiny shadows.",
        Description = "Jet-black beetles with glowing orange lines tracing their shells. Harmless alone, but they swarm if disturbed.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.emberwood, RoomTags.wilderness)]
    };

    public static Mob SighingTreant = new Mob
    {
        // Rarity = Rare
        Name = "Sighing Treant",
        PressenceText = "A Sighing Treant looms nearby, its creaking form groaning under its own ancient weight.",
        Description = "An ancient treefolk, its bark etched with the passage of centuries. It sighs mournfully as though burdened by endless memories.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.emberwood, RoomTags.wilderness)]
    };

    public static Mob BriarShade = new Mob
    {
        // Rarity = Uncommon
        Name = "Briar Shade",
        PressenceText = "A Briar Shade coils out from the undergrowth, thorny tendrils twisting in the dim light.",
        Description = "A semi-corporeal entity formed of shadow and brambles. It moves with predatory grace, weaving through the thickets.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.emberwood, RoomTags.wilderness)]
    };

    public static Mob CovenCrow = new Mob
    {
        // Rarity = Common
        Name = "Coven Crow",
        PressenceText = "A Coven Crow perches overhead, its sharp gaze fixed firmly upon you.",
        Description = "A large, intelligent crow with glossy black feathers. They gather in unsettling numbers, watching travelers with uncanny awareness.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.emberwood, RoomTags.wilderness)]
    };

    public static Mob MossweaverSpider = new Mob
    {
        // Rarity = Uncommon
        Name = "Mossweaver Spider",
        PressenceText = "A Mossweaver Spider dangles from an overhanging branch, its runic web shimmering in the light.",
        Description = "An enormous spider that spins glowing green silk into patterns resembling ancient runes. Hunters say their webs hold latent magic.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.emberwood, RoomTags.wilderness)]
    };

    public static Mob FeralGroveSpirit = new Mob
    {
        // Rarity = Very Rare
        Name = "Feral Grove Spirit",
        PressenceText = "The Feral Grove Spirit materializes from the forest gloom, its form shifting like leaves in the wind.",
        Description = "A wild elemental force of the forest, tangled in moss and thorns. It radiates raw, untamed power, a manifestation of the Emberwood’s ancient will.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.emberwood, RoomTags.wilderness)]
    };

    /* POND */
    public static Mob LilypadSprite = new Mob
    {
        // Rarity = Uncommon
        Name = "Lilypad Sprite",
        PressenceText = "A Lilypad Sprite flits over the water's surface, trailing ripples of gentle magic.",
        Description = "A playful water spirit that dances across lilypads, its laughter like the tinkling of tiny bells. They sometimes lure the curious closer to the pond's depths.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.pond, RoomTags.wilderness)]
    };

    public static Mob BogSerpent = new Mob
    {
        // Rarity = Rare
        Name = "Bog Serpent",
        PressenceText = "A Bog Serpent coils in the shallows, its sinuous form barely visible beneath the murky water.",
        Description = "A long, camouflaged snake that lurks just below the pond's surface. Known for ambushing prey with lightning speed.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.pond, RoomTags.wilderness)]
    };

    public static Mob MirrorCarp = new Mob
    {
        // Rarity = Rare
        Name = "Mirror Carp",
        PressenceText = "A Mirror Carp glides beneath the water, its scales reflecting your gaze back at you.",
        Description = "A massive, shimmering fish whose silver scales reflect more than just light. Some claim it reveals visions of your inner self.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.pond, RoomTags.wilderness)]
    };

    public static Mob MudGolem = new Mob
    {
        // Rarity = Uncommon
        Name = "Mud Golem",
        PressenceText = "A Mud Golem rises from the pond's edge, dripping with thick, clinging sludge.",
        Description = "An animated creature formed of pond muck and river stones. Slow but relentless, it defends its watery territory with crushing strength.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.pond, RoomTags.wilderness)]
    };

    public static Mob CroakingHerald = new Mob
    {
        // Rarity = Common
        Name = "Croaking Herald",
        PressenceText = "A Croaking Herald bellows from a mossy rock, its deep calls echoing across the pond.",
        Description = "An enormous frog with a booming voice that carries for miles. Locals say its croak foretells storms on the horizon.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.pond, RoomTags.wilderness)]
    };

    /* FARM */
    public static Mob PlagueRat = new Mob
    {
        // Rarity = Common
        Name = "Plague Rat",
        PressenceText = "A Plague Rat scurries between the crops, its mangy fur twitching with disease.",
        Description = "Bloated and aggressive, these vermin spread sickness wherever they roam. Farmers live in fear of their nests.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.farm, RoomTags.wilderness)]
    };

    public static Mob ScarecrowRevenant = new Mob
    {
        // Rarity = Rare
        Name = "Scarecrow Revenant",
        PressenceText = "A Scarecrow Revenant lurches from its post, straw-stuffed limbs creaking with unnatural life.",
        Description = "A haunted effigy animated by bitter curses. Its hollow gaze watches over barren fields, longing for forgotten harvests.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.farm, RoomTags.wilderness)]
    };

    public static Mob HarvestHare = new Mob
    {
        // Rarity = Common
        Name = "Harvest Hare",
        PressenceText = "A Harvest Hare darts through the crops, its oversized form nimbly weaving between stalks.",
        Description = "An enormous rabbit drawn to ripe fields. While a nuisance to farmers, its golden fur is prized for lucky charms.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.farm, RoomTags.wilderness)]
    };

    public static Mob CornstalkHorror = new Mob
    {
        // Rarity = Uncommon
        Name = "Cornstalk Horror",
        PressenceText = "A Cornstalk Horror rustles toward you, its bundled stalks twisting unnaturally.",
        Description = "A grotesque figure woven from corn husks and twine, animated by dark harvest magic. Its rustling steps send shivers down the spine.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.farm, RoomTags.wilderness)]
    };

    public static Mob RoosterDrake = new Mob
    {
        // Rarity = Rare
        Name = "Rooster Drake",
        PressenceText = "A Rooster Drake puffs out its fiery plumage, fixing you with a fierce glare.",
        Description = "A strange hybrid of rooster and drake, fiercely territorial and quick to attack. Its crowing carries the crackle of fire.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.farm, RoomTags.wilderness)]
    };

    /* SPRING */
    public static Mob BloomStag = new Mob
    {
        // Rarity = Rare
        Name = "Bloom Stag",
        PressenceText = "A Bloom Stag strides into view, petals falling from its blossoming antlers.",
        Description = "A majestic creature crowned with antlers in full bloom. It embodies the spirit of spring's renewal.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.spring, RoomTags.wilderness)]
    };

    public static Mob PollenWraith = new Mob
    {
        // Rarity = Uncommon
        Name = "Pollen Wraith",
        PressenceText = "A Pollen Wraith swirls past on the breeze, its form dissolving into golden dust.",
        Description = "A spectral figure composed of drifting pollen and spring winds. Beautiful but dangerous to those who breathe too deeply.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.spring, RoomTags.wilderness)]
    };

    public static Mob HatchlingSwarm = new Mob
    {
        // Rarity = Common
        Name = "Hatchling Swarm",
        PressenceText = "A Hatchling Swarm buzzes in chaotic formation, newly awakened to the world.",
        Description = "A cloud of newly hatched insects, eager to feed. Individually harmless, but overwhelming in numbers.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.spring, RoomTags.wilderness)]
    };

    public static Mob MistDryad = new Mob
    {
        // Rarity = Rare
        Name = "Mist Dryad",
        PressenceText = "A Mist Dryad emerges from the morning fog, her form trailing tendrils of mist.",
        Description = "A spirit born from the mists of spring dawns. She can be a guide or a deceiver, depending on her whims.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.spring, RoomTags.wilderness)]
    };

    public static Mob FestivalSprite = new Mob
    {
        // Rarity = Uncommon
        Name = "Festival Sprite",
        PressenceText = "A Festival Sprite twirls through the air, scattering petals and laughter alike.",
        Description = "Joyful fae that celebrate the changing season with dance and mischief. Their revelry is infectious, though they are not always harmless.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.spring, RoomTags.wilderness)]
    };

    /* MAGIC */
    public static Mob ArcaneSentinel = new Mob
    {
        // Rarity = Rare
        Name = "Arcane Sentinel",
        PressenceText = "An Arcane Sentinel hums with latent power, runes glowing softly along its stony frame.",
        Description = "A construct of enchanted stone and ancient glyphs. It patrols forgotten halls and arcane ruins, attacking only when its wards are threatened.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.magic, RoomTags.wilderness)]
    };

    public static Mob ManaLeech = new Mob
    {
        // Rarity = Uncommon
        Name = "Mana Leech",
        PressenceText = "A Mana Leech flutters near, its translucent wings shimmering with stolen light.",
        Description = "A small, ethereal creature that feeds on magical energy. Casters beware — its bite drains more than health.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.magic, RoomTags.wilderness)]
    };

    public static Mob RunebornOwl = new Mob
    {
        // Rarity = Uncommon
        Name = "Runeborn Owl",
        PressenceText = "A Runeborn Owl perches silently above, glowing glyphs pulsing across its feathers.",
        Description = "A mysterious owl with feathers etched in arcane script. Said to deliver dreams, omens, or knowledge — depending on whom it watches.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.magic, RoomTags.wilderness)]
    };

    public static Mob SpellwispSwarm = new Mob
    {
        // Rarity = Common
        Name = "Spellwisp Swarm",
        PressenceText = "A Spellwisp Swarm crackles through the air, each spark a fragment of lost magic.",
        Description = "A cluster of unstable spell fragments that drift through magical fields. They can be mesmerizing — or explosively dangerous.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.magic, RoomTags.wilderness)]
    };

    public static Mob ChronomancerShade = new Mob
    {
        // Rarity = Very Rare
        Name = "Chronomancer's Shade",
        PressenceText = "The Chronomancer's Shade flickers in and out of existence, as if time itself cannot hold it still.",
        Description = "A fractured remnant of a time-warping mage, frozen between moments. Its presence disrupts reality in unpredictable ways.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.magic, RoomTags.wilderness)]
    };

    /* CEMETARY */
    public static Mob BoneCrows = new Mob
    {
        // Rarity = Common
        Name = "Bone Crows",
        PressenceText = "A murder of Bone Crows circles overhead, skeletal wings rattling in the wind.",
        Description = "Dark-feathered carrion birds with exposed bone and hollow eyes. They gather in graveyards, feasting on both flesh and memory.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.cemetary, RoomTags.wilderness)]
    };

    public static Mob MourningShade = new Mob
    {
        // Rarity = Rare
        Name = "Mourning Shade",
        PressenceText = "A Mourning Shade weeps silently beside a crooked gravestone, her form barely clinging to the material world.",
        Description = "A sorrowful spirit drawn to places of grief. Her wailing cry carries a curse for those who disturb the resting dead.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.cemetary, RoomTags.wilderness)]
    };

    public static Mob CryptStalker = new Mob
    {
        // Rarity = Uncommon
        Name = "Crypt Stalker",
        PressenceText = "A Crypt Stalker slinks from behind a tomb, its claws scraping softly across the stone.",
        Description = "A gaunt ghoul with sunken eyes and a hunger for the living. It lurks in shadows, stalking intruders through mausoleums and catacombs.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.cemetary, RoomTags.wilderness)]
    };

    public static Mob WraithboundHound = new Mob
    {
        // Rarity = Uncommon
        Name = "Wraithbound Hound",
        PressenceText = "A Wraithbound Hound prowls the grave path, its eyes glowing with spectral fire.",
        Description = "Once a loyal guardian, now bound in undeath to protect its master's tomb. Its growl chills the soul.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.cemetary, RoomTags.wilderness)]
    };

    public static Mob GravestoneGolem = new Mob
    {
        // Rarity = Rare
        Name = "Gravestone Golem",
        PressenceText = "A Gravestone Golem rises from shattered earth, cobbled together from broken memorials.",
        Description = "A hulking construct built from tombstones, chains, and grave earth. It exists only to punish desecrators.",
        SpawnConditions = [new RoomTagSpawnCondition(RoomTags.cemetary, RoomTags.wilderness)]
    };
}