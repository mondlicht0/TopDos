using TopDos.Weapons.Data;
using UnityEngine;

namespace TopDos.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [field: SerializeField] public WeaponConfiguration WeaponConfig { get; private set; }

        public abstract void Shoot();
    }
}
