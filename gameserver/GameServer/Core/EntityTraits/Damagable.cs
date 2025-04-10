using System;

namespace GameServer.Core.EntityTraits;

public class Damageable : EntityTrait
{
    public int MaxHealth { get; set; }
    public int Health { get; protected set; }

    public Damageable(int maxHealth)
    {
        MaxHealth = maxHealth;
        Health = MaxHealth;
    }

    public void ApplyDamage(Object damageSource, int amount)
    {
        if (IsAlive())
            Health -= amount;

        if (IsDead())
        {

        }
    }

    public void Heal(int amount)
    {
        Health = Math.Min(Health + amount, MaxHealth);
    }

    public bool IsAlive() => Health > 0;
    public bool IsDead() => !IsAlive();
}
