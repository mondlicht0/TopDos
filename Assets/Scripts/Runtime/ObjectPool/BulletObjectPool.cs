using TopDos.Weapons;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TopDos.ObjectPooling
{
    public class BulletObjectPool : ObjectPool<Bullet>
    {
        private static Transform _muzzleFlash;
        public BulletObjectPool(Bullet prefab, Transform muzzleFlash, int preloadCount) 
            : base(() => Preload(prefab, muzzleFlash), GetObject, ReturnObject, preloadCount)
        {
            _muzzleFlash = muzzleFlash;
        }

        public static Bullet Preload(Bullet prefab, Transform MuzzleFlash)
        {
            return Object.Instantiate(prefab, MuzzleFlash.transform.position, MuzzleFlash.transform.rotation);
        }

        public static void GetObject(Bullet obj)
        {
            obj.transform.position = _muzzleFlash.position;
            obj.transform.rotation = _muzzleFlash.rotation;
            obj.gameObject.SetActive(true);
        }

        public static void ReturnObject(Bullet obj)
        {
            obj.gameObject.SetActive(false);
        }
    }
}
