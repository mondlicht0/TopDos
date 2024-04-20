using System;
using Cysharp.Threading.Tasks;
using TopDos.Enemies;
using TopDos.ObjectPooling;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    private const int EnemyPreloadCount = 10;
    
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _spawnRange;
    [SerializeField] private float _spawnRate;
    
    private EnemyObjectPool _enemyPool;

    private void Awake()
    {
        _enemyPool = new EnemyObjectPool(_enemyPrefab, EnemyPreloadCount);
    }

    private async void Start()
    {
        // TODO: FIX
        while (true)
        {
            SpawnRandomEnemy();
            await UniTask.Delay(TimeSpan.FromSeconds(_spawnRate));
        }
    }

    private void SpawnRandomEnemy()
    {
        Vector3 spawnPoint;
        if (TryGetRandomPoint(Vector3.zero, _spawnRange, out spawnPoint))
        {
            Enemy enemy = _enemyPool.Get();
            enemy.transform.position = spawnPoint;
        }

        else
        {
            Enemy enemy = _enemyPool.Get();
            enemy.transform.position = Vector3.zero;
        }
    }

    private bool TryGetRandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;

        if (NavMesh.SamplePosition(randomPoint, out hit, _spawnRange, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
}
