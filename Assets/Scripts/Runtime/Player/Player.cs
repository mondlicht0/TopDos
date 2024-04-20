using System;
using TopDos.Animations;
using TopDos.Controls;
using UnityEngine;

namespace TopDos.PlayerSpace
{
    public class Player : MonoBehaviour
    {
        private PlayerHealth _playerHealth;
        private PlayerWeaponSelector _weaponSelector;
        private CharacterController _characterController;
        private IMovement _playerMovement;
        private Animator _animator;
        private AnimatorBrain _animatorBrain;
        private GameMachine _gameManager;
        [field: SerializeField] public PlayerData Data { get; private set; }


        private void Awake()
        {
            _playerHealth ??= GetComponent<PlayerHealth>();
            _weaponSelector ??= GetComponent<PlayerWeaponSelector>();
            _playerMovement ??= GetComponent<PlayerMovement>();
            _characterController ??= GetComponent<CharacterController>();
            _animator ??= GetComponent<Animator>();
            _animatorBrain ??= GetComponent<AnimatorBrain>();
            _gameManager.OnGameOver += () => gameObject.SetActive(false);
        }

        public void SubscribeOnHealthDie(Action action)
        {
            _playerHealth.OnDied += action;
        }
    }
}
