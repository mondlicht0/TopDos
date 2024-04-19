using UnityEngine;

namespace TopDos.Weapons.Data
{
    [CreateAssetMenu(fileName = "New Weapon Data", menuName = "Data/New Weapon Data", order = 0)]
    public class WeaponConfiguration : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float FireRate { get; private set; }
        [field: SerializeField] public float MaxAmmo { get; private set; }
    }
}
