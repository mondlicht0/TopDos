using TopDos.Weapons.Data;
using UnityEngine;

namespace TopDos.Weapons
{
    public class Pistol : Weapon
    {
        [SerializeField] private Bullet _bulletPrefab;
        
        public override void Shoot()
        {
            var bullet = Instantiate(_bulletPrefab);
        }
    }
}
