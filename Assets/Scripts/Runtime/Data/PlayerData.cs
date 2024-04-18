using UnityEngine;

namespace TopDos.Player.Data
{
    [CreateAssetMenu(fileName = "New Player Data", menuName = "Data/Player Data", order = 0)]
    public class PlayerData : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public float JumpForceScalar { get; private set; }

    }
}
