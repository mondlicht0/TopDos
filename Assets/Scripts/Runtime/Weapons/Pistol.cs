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
            MuzzleFlash = FindObjectOfType<ParticleSystem>();
            BulletsPool = new BulletObjectPool(_bulletPrefab, BulletPreloadCount);
        }

        public async override void Shoot()
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
