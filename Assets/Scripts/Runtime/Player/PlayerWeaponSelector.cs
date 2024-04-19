using System;
using TopDos.Animations;
using TopDos.Controls;
using TopDos.Weapons;
using UnityEngine;

namespace TopDos.PlayerSpace
{
    public class PlayerWeaponSelector : MonoBehaviour
    {
        private AnimatorBrain _animatorBrain;
        private ControlsHandler _controls;
        public Weapon CurrentWeapon { get; private set; }

        public event Action OnShoot;

        private void Awake()
        {
            _controls ??= GetComponent<ControlsHandler>();
            CurrentWeapon ??= GetComponentInChildren<Weapon>();
            _animatorBrain ??= GetComponent<AnimatorBrain>();
        }

        private void Start()
        {
            _controls.Controls.Gameplay.Shoot.performed += ctx => OnShoot?.Invoke();
            _controls.Controls.Gameplay.Shoot.performed += ctx => CurrentWeapon.Shoot();
            _controls.Controls.Gameplay.Shoot.performed += ctx => _animatorBrain.Play(EAnimation.ATTACK, 0.2f, 1);
        }
    }
}
