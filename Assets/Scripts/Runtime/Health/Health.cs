using System;
using UnityEngine;

public abstract class Health : MonoBehaviour, IDamagable
{
    [field: SerializeField] public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }

    public event Action OnDamageTaken;
    public event Action OnDied;

    private void Awake()
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
