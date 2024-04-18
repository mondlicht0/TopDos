using System;
using TopDos.Weapons.Data;
using UnityEngine;

namespace TopDos.Weapons
{
    public class Pistol : Weapon
    {
        [SerializeField] private Bullet _bulletPrefab;

        protected override ParticleSystem MuzzleFlash { get; set; }

        private void Awake()
        {
            MuzzleFlash = FindObjectOfType<ParticleSystem>();
        }

        public override void Shoot()
        {
            MuzzleFlash.Play();
            var bullet = Instantiate(_bulletPrefab, MuzzleFlash.transform.position, transform.root.transform.rotation);
        }
    }
}
