using UnityEngine;
using TopDos.ObjectPooling;
using Cysharp.Threading.Tasks;
using System;

namespace TopDos.Weapons
{
    public class Pistol : Weapon
    {
        private const int BulletPreloadCount = 10;

        [SerializeField] private AudioClip _sound;
        [SerializeField] private Bullet _bulletPrefab;
        private AudioSource _audio;
        protected override ParticleSystem MuzzleFlash { get; set; }
        protected override BulletObjectPool BulletsPool { get; set; }

        private void Awake()
        {
            _audio = GetComponent<AudioSource>();
            MuzzleFlash = GetComponentInChildren<ParticleSystem>();
            BulletsPool = new BulletObjectPool(_bulletPrefab, MuzzleFlash.transform, BulletPreloadCount);
        }

        public override async void Shoot()
        {
            MuzzleFlash.Play();
            _audio.PlayOneShot(_sound);
            Bullet bullet = BulletsPool.Get();
            bullet.Init(WeaponConfig);
            //bullet.transform.position = MuzzleFlash.transform.position;
            bullet.transform.rotation = MuzzleFlash.transform.rotation;
            bullet.OnCollisionHit += () => BulletsPool.Return(bullet);

            await UniTask.Delay(TimeSpan.FromSeconds(bullet.BulletLifeTime));
            BulletsPool.Return(bullet);
        }
    }
}
