using TopDos.PlayerSpace;
using UnityEngine;

public class AidKit : Loot
{
    [SerializeField] private int _healAmount;
    
    public override void Receive(Player player)
    {
        if (player.TryGetComponent(out PlayerHealth health))
        {
            health.ModifyHealth(_healAmount);
        }
        
        Destroy(gameObject);
    }
}
