using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnStrategy : MonoBehaviour
{
    public List<GameObject> Templates { get; protected set; }
    public float MinSpawnTime { get; protected set; }
    public float MaxSpawnTime { get; protected set; }
    public float MinSpawnHeight { get; protected set; }
    public float MaxSpawnHeight { get; protected set; }
    public int Capacity { get; protected set; }
    public string Name { get; protected set; }

    protected ObjectPool GetPool(ObjectPool pool, int capacity, string name)
    {
        ObjectPool objectPool = new ObjectPool();
        pool = objectPool.GetPool(capacity, new GameObject(), name);
        return pool;
    }

    public abstract void Spawn(float secondsBetweenSpawn, ref float elapsedTime);

    public abstract void Reset();

    public abstract void Initialized();
}