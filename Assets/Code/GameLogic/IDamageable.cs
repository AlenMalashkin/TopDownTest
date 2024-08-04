using System;

namespace Code.GameLogic
{
    public interface IDamageable
    {
        event Action Died;
        float MaxHealth { get; }
        float CurrentHealth { get; }
        void TakeDamage(float damage);
    }
}