using UnityEngine;
using TopDos.ObjectPooling;
using Cysharp.Threading.Tasks;
using System;

namespace TopDos.Weapons
{
    public class Pistol : Weapon
    {
        private const int BulletPreloadCount = 20;

        [SerializeField] private Bullet _bulletPrefab;
        protected override ParticleSystem MuzzleFlash { get; set; }
        protected override BulletObjectPool BulletsPool { get; set; }

        private void Awake()
        {
            MuzzleFlash = GetComponentInChildren<ParticleSystem>();
            BulletsPool = new BulletObjectPool(_bulletPrefab, MuzzleFlash.transform, BulletPreloadCount);
        }

        public override async void Shoot()
        {
            MuzzleFlash.Play();
            Bullet bullet = BulletsPool.Get();
            bullet.transform.position = MuzzleFlash.transform.position;
            bullet.transform.rotation = MuzzleFlash.transform.rotation;
            bullet.OnCollisionHit += () => BulletsPool.Return(bullet);

            await UniTask.Delay(TimeSpan.FromSeconds(bullet.BulletLifeTime));
            BulletsPool.Return(bullet);
        }
    }
}
