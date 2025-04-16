using ScriptApi.Ability;

namespace GameContent.Abilities.Thief;

public class SneakAttack : Ability
{
    public override string Name => "Sneak Attack";

    public override string Description =>
        "Thieves can perform a <b>Sneak Attack</b> any time they are behind an opponent in melee and it is reasonably likely the opponent doesn’t know the Thief is there. The GM may require a Move Silently or Hide roll to determine this. The Sneak Attack is made with a +4 attack bonus and does double damage if it is successful. A Thief usually can’t make a Sneak Attack on the same opponent twice in any given combat.<br/>The Sneak Attack can be performed with any melee (but not missile) weapon, or may be performed bare-handed (in which case subduing damage is done). Also, the Sneak Attack can be performed with the “flat of the blade;” the bonuses and penalties cancel out, so the attack has a +0 attack bonus and does normal damage; the damage done in this case is subduing damage.";
}