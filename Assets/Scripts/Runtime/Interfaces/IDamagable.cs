using System;
using UnityEngine;

public interface IDamagable
{
    void TakeDamage(int damage);
    void Die();

    public event Action OnDamageTaken;
    public event Action OnDied;
}
