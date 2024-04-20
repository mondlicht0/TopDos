using System;
using UnityEngine;

namespace TopDos.Enemies
{
    public class EnemyHealth : Health
    {
        private Enemy _enemy;

        private void Start()
        {
            _enemy ??= GetComponent<Enemy>();
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            Debug.Log("Take Damage Enemy");
        }

        public override void Die()
        {
            base.Die();
            _enemy.Agent.enabled = false;
        }
    }
}
