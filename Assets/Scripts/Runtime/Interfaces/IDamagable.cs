using System;
using UnityEngine;

public interface IDamagable
{
    void ModifyHealth(int amount);
    void Die();

    public event Action OnModifyHealth;
    public event Action OnDied;
}
