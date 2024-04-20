using UnityEngine;

namespace TopDos.PlayerSpace
{
    public class PlayerHealth : Health
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
