using UnityEngine;

[CreateAssetMenu(fileName = "New Drop Loot", menuName = "Loot/New Drop Loot", order = 0)]
public class LootData : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; } 
    [field: SerializeField] public GameObject LootPrefab { get; private set; }
    [field: SerializeField] public int DropChance { get; private set; }
}
