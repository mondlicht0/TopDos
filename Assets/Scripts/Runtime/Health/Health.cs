using System;
using UnityEngine;

public abstract class Health : MonoBehaviour, IDamagable
{
    [field: SerializeField] public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }

    public event Action OnModifyHealth;
    public event Action OnDied;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    public virtual void ModifyHealth(int amount)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0, MaxHealth);

        OnModifyHealth?.Invoke();
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
