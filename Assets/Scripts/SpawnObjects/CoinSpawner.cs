using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : SpawnStrategy
{
    [SerializeField] private LayerMask _bannedLayerForSpawn;
    [SerializeField] private List<GameObject> _templates;

    private ObjectPool _coinPool;
    private float _overlapBoxSize = 1f;

    public override void Spawn(float secondsBetweenSpawn, ref float elapsedTime)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit && (elapsedTime > secondsBetweenSpawn))
        {
            if (_coinPool.TryGetObject(out GameObject prefab))
            {
                Vector3 spawnPoint = new Vector3(transform.position.x, hit.transform.position.y + Random.Range(MinSpawnHeight, MaxSpawnHeight), transform.position.z);
                Vector2 overlapBox = new Vector2(_overlapBoxSize, _overlapBoxSize);
                Collider2D[] collidersInsideOverlapBox = new Collider2D[1];
                int numberOfCollidersFound = Physics2D.OverlapBoxNonAlloc(hit.point, overlapBox, 0, collidersInsideOverlapBox, _bannedLayerForSpawn);
                if (numberOfCollidersFound == 0)
                {
                    prefab.SetActive(true);
                    prefab.transform.position = spawnPoint;
                    elapsedTime = 0;
                }
            }
        }
    }

    public override void Reset()
    {
        _coinPool.ResetPool();
    }

    public override void Initialized()
    {
        MinSpawnTime = 1;
        MaxSpawnTime = 2;
        MinSpawnHeight = 2;
        MaxSpawnHeight = 4;
        Capacity = 20;
        Templates = _templates;
        Name = "CoinPool";
        _coinPool = GetPool(_coinPool, Capacity, Name);
        foreach (var item in Templates)
        {
            _coinPool.Initialized(item);
        }
    }
}