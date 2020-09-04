using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : ObjectPool
{
    public float MinSpawnTime { get; protected set; }
    public float MaxSpawnTime { get; protected set; }
    public float MinSpawnHeight { get; protected set; }
    public float MaxSpawnHeight { get; protected set; }

    protected float GenerateSpawnTime(float MinSpawnTime, float MaxSpawnTime)
    {
        _elapsedTime += Time.deltaTime;
        float secondsBetweenSpawn = Random.Range(MinSpawnTime, MaxSpawnTime);
        return secondsBetweenSpawn;
    }

    protected abstract void Spawn(float secondsBetweenSpawn);
}
