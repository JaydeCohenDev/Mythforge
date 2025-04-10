using GameServer.Core.EntityTraits;
using GameServer.Core.Messaging;

namespace GameServer.Core.Ability;

public class BasicAttack : Ability
{
    public override void Activate(Entity user, Entity target)
    {
        int damage = 10;

        string? message = new MessageBuilder()
            .AddEntityName(user)
            .AddText(" unleashes a powerful punch at ")
            .AddEntityName(target)
            .AddText($"! [{damage}hp]")
            .Build();

        user.CurrentRoom?.SendAsync(message);
        target.GetTrait<Damageable>()?.ApplyDamage(user, damage);
    }
}