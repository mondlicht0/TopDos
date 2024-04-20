using System;
using System.Collections.Generic;
using System.Linq;
using TopDos.Enemies;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class LootDropManager : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private List<LootData> _lootList;
    private GameMachine _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameMachine>();
        _gameManager.OnEnemyKilled += DropLoot;
    }

    private void DropLoot(Enemy enemy)
    {
        int chance = Random.Range(0, 101);
        var possibleItems = _lootList.Where(loot => chance <= loot.DropChance).ToList();

        if (possibleItems.Count <= 0)
        {
            return;
        }
        
        CreateLoot(possibleItems, enemy.transform.position);
    }

    private void CreateLoot(List<LootData> possibleItems, Vector3 pos)
    {
        Instantiate(_lootList[Random.Range(0, possibleItems.Count)].LootPrefab, pos, Quaternion.identity);
    }
}
