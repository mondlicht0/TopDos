using TopDos.Weapons;
using Object = UnityEngine.Object;

namespace TopDos.ObjectPooling
{
    public class BulletObjectPool : ObjectPool<Bullet>
    {
        public BulletObjectPool(Bullet prefab, int preloadCount) 
            : base(() => Preload(prefab), GetObject, ReturnObject, preloadCount)
        {
        }

        public static Bullet Preload(Bullet prefab)
        {
            return Object.Instantiate(prefab);
        }

        public static void GetObject(Bullet obj)
        {
            obj.gameObject.SetActive(true);
        }

        public static void ReturnObject(Bullet obj)
        {
            obj.gameObject.SetActive(false);
        }
    }
}
