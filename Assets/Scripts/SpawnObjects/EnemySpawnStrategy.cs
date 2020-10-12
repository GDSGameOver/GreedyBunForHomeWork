using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnStrategy : SpawnStrategy
{
    [SerializeField] private List<GameObject> _templates;

    private ObjectPool _enemyPool = new ObjectPool();

    public override void Spawn(float secondsBetweenSpawn,  ref float elapsedTime)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit && (elapsedTime > secondsBetweenSpawn))
        {
            if (_enemyPool.TryGetObject(out GameObject prefab))
            {
                Vector3 spawnPoint = new Vector3(transform.position.x, hit.transform.position.y + Random.Range(MinSpawnHeight, MaxSpawnHeight), transform.position.z);
                prefab.SetActive(true);
                prefab.transform.position = spawnPoint;
                elapsedTime = 0;
            }
        }
    }

    public override void Reset()
    {
        _enemyPool.ResetPool();
    }

    public override void Initialized()
    {
        MinSpawnTime = 3;
        MaxSpawnTime = 10;
        MinSpawnHeight = 0;
        MaxSpawnHeight = 0;
        Templates = _templates;
        Capacity = 6;
        Name = "EnemyPool";
        _enemyPool = GetPool(_enemyPool, Capacity, Name);
        foreach (var item in Templates)
        {
            _enemyPool.Initialized(item);
        }
    }
}