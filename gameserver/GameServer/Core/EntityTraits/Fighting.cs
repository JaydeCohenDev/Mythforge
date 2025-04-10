namespace GameServer.Core.EntityTraits;

public class Fighting : EntityTrait
{
    public Damageable? CurrentTarget { get; private set; }
    public Ability.Ability Ability { get; set; }

    public Fighting(Ability.Ability ability)
    {
        Ability = ability;
    }

    public void EngageTarget(Damageable damageable)
    {
        CurrentTarget = damageable;
    }

    public override void Tick()
    {
        base.Tick();



        if (CurrentTarget is not null)
            Ability.Activate(Owner, CurrentTarget.Owner);

    }
}