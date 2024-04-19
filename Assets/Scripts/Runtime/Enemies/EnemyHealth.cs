using UnityEngine;

namespace TopDos.Enemies
{
    public class EnemyHealth : Health
    {
        protected override int MaxHealth { get; set; }
        protected override int CurrentHealth { get; set; }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
        }

        public override void Die()
        {
            base.Die();
        }
    }
}
