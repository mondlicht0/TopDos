using System;
using UnityEngine;

namespace TopDos.Enemies
{
    public class EnemyHealth : Health
    {
        private GameMachine _gameManager;
        private ScoreManager _scoreManager;
        private Enemy _enemy;

        private void Start()
        {
            _gameManager = FindObjectOfType<GameMachine>();
            _scoreManager = FindObjectOfType<ScoreManager>();
            _enemy ??= GetComponent<Enemy>();
        }

        public override void ModifyHealth(int amount)
        {
            base.ModifyHealth(amount);
            Debug.Log("Take Damage Enemy");
        }

        public override void Die()
        {
            base.Die();
            _gameManager.SendEnemyKilled(_enemy);
            _enemy.Agent.enabled = false;
        }
    }
}
