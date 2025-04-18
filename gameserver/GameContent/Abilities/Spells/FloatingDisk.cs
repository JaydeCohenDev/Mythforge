﻿using GameContent.Util;
using ScriptApi;

namespace GameContent.Abilities.Spells;

public class FloatingDisk : Spell
{
    public override string Name => "Floating Disk";
    public override AbilityRange GetRange(Entity caster) => new Touch();

    public override SpellDuration GetDuration(Entity caster) =>
        new Turns(5 + caster.GetLevel());
    
    public override string Description =>
        "This spell creates an invisible, slightly concave circular plane of force for carrying loads. It is about the size of a shield, being 3 feet in diameter and 1 inch deep at its center. It can hold a maximum of 500 pounds of weight. (Note that water weighs about 8 pounds per gallon.) The disc must be loaded so that the items placed upon it are properly supported, or they will (of course) fall off. For example, the disc can support just over 62 gallons of water, but the water must be in a barrel or other reasonable container that can be placed upon the disc. Similarly, a pile of loose coins will tend to slip and slide about, and some will fall off with every step the caster takes; but a large sack full of coins, properly tied, will remain stable.<br/>The disc floats level to the ground, at about the height of the caster’s waist. It remains still when within 10’ of the caster, and follows at the caster’s movement rate if he or she moves away from it. The floating disc can be pushed as needed to position it but will be dispelled if somehow moved more than 10’ from the caster. When the spell duration expires, the disc disappears from existence and drops whatever was supported to the surface beneath.";
}