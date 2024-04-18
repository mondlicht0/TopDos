using UnityEngine;

namespace TopDos.Player
{
    public class PlayerHealth : Health
    {
        [field: SerializeField] protected override int MaxHealth { get; set; }
        protected override int CurrentHealth { get; set; }
    }
}
