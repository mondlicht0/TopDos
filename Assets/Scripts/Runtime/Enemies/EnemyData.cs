using UnityEngine;

namespace TopDos.Enemies
{
    [CreateAssetMenu(fileName = "New Enemy Data", menuName = "Data/Enemy Data", order = 0)]
    public class EnemyData : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public float Health { get; private set; }
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public float AttackRange { get; private set; }
    }
}
