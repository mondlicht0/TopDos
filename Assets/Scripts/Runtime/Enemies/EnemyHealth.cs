using UnityEngine;

namespace TopDos.Enemies
{
    public class EnemyHealth : Health
    {
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
