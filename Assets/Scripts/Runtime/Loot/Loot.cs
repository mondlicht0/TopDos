using System;
using TopDos.PlayerSpace;
using UnityEngine;

public abstract class Loot : MonoBehaviour
{
    public event Action<Player> OnTakeLoot;

    private void Start()
    {
        OnTakeLoot += Receive;
    }

    public abstract void Receive(Player player);
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            OnTakeLoot?.Invoke(player);
        }
    }
}
