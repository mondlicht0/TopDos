using System;
using TopDos.Animations;
using TopDos.Controls;
using TopDos.Weapons;
using UnityEngine;

namespace TopDos.Player
{
    public class PlayerWeaponSelector : MonoBehaviour
    {
        private AnimatorBrain _animatorBrain;
        private Weapon _currentWeapon;
        private ControlsHandler _controls;

        private void Awake()
        {
            _controls ??= GetComponent<ControlsHandler>();
            _currentWeapon ??= GetComponent<Weapon>();
            _animatorBrain ??= GetComponent<AnimatorBrain>();
        }

        private void Start()
        {
            _controls.Controls.Gameplay.Shoot.performed += ctx => _currentWeapon.Shoot();
            _controls.Controls.Gameplay.Shoot.performed += ctx => _animatorBrain.Play(EAnimation.PISTOLSHOOT, 0.2f, 1);
        }
    }
}
