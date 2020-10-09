using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnStrategy : MonoBehaviour
{
    protected float GenerateSpawnTime(float minSpawnTime, float maxSpawnTime)
    {
        float secondsBetweenSpawn = Random.Range(minSpawnTime, maxSpawnTime);
        return secondsBetweenSpawn;
    }

    protected ObjectPool GetPool(ObjectPool pool, int capacity, string name)
    {
        ObjectPool objectPool = new ObjectPool();
        pool = objectPool.GetPool(capacity, new GameObject(), name);
        return pool;
    }

    protected SpawnSettings GetSettings(SpawnSettings settings, List<GameObject> templates, float minSpawnTime, float maxSpawnTime, float minSpawnHeight, float maxSpawnHeight )
    {
        SpawnSettings spawnSettings = new SpawnSettings();
        settings = spawnSettings.GetSettings(templates, minSpawnTime, maxSpawnTime, minSpawnHeight, maxSpawnHeight);
        return settings;
    }

    protected abstract void Spawn(float secondsBetweenSpawn);
}