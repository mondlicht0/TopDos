using UnityEngine;

namespace TopDos.PlayerSpace
{
    public class PlayerHealth : Health
    {
        [field: SerializeField] protected override int MaxHealth { get; set; }
        protected override int CurrentHealth { get; set; }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            Debug.Log("Damage");
        }
    }
}
