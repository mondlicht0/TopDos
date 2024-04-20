using TopDos.Enemies;
using UnityEngine;

namespace TopDos.ObjectPooling
{
    public class EnemyObjectPool : ObjectPool<Enemy>
    {
        public EnemyObjectPool(Enemy prefab, int preloadCount)
            : base(() => Preload(prefab), GetObject, ReturnObject, preloadCount)
        {
        }

        public static Enemy Preload(Enemy prefab)
        {
            return Object.Instantiate(prefab);
        }

        public static void GetObject(Enemy obj)
        {
            obj.gameObject.SetActive(true);
        }

        public static void ReturnObject(Enemy obj)
        {
            obj.gameObject.SetActive(false);
        }
    }
}
