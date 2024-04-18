using System;
using UnityEngine;

public abstract class Health : MonoBehaviour, IDamagable
{
    protected abstract int MaxHealth { get; set; }
    protected abstract int CurrentHealth { get; set; }

    public event Action OnDamageTaken;
    public event Action OnDied;

    private void OnEnable()
    {
        CurrentHealth = MaxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        OnDamageTaken?.Invoke();

        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        OnDied?.Invoke();
    }
}
