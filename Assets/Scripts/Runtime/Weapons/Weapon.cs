using TopDos.ObjectPooling;
using TopDos.Weapons.Data;
using UnityEngine;

namespace TopDos.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [field: SerializeField] public WeaponConfiguration WeaponConfig { get; private set; }
        protected abstract BulletObjectPool BulletsPool { get; set; }
        protected abstract ParticleSystem MuzzleFlash { get; set; }

        public abstract void Shoot();
    }
}
