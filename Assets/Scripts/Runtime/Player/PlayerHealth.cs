using UnityEngine;

namespace TopDos.PlayerSpace
{
    public class PlayerHealth : Health
    {
        public override void ModifyHealth(int amount)
        {
            base.ModifyHealth(amount);
        }

        public override void Die()
        {
            base.Die();
        }
    }
}
