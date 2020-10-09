using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : SpawnStrategy
{
    [SerializeField] private LayerMask _bannedLayerForSpawn;
    [SerializeField] private List<GameObject> _templates;

    private ObjectPool _coinPool;
    private SpawnSettings _coinSpawnSettings;
    private string _name = "CoinPool";
    private int _capacity = 20;
    private float _overlapBoxSize = 1f;
    private float _minSpawnTime = 1;
    private float _maxSpawnTime = 2;
    private float _minSpawnHeight = 2;
    private float _maxSpawnHeight = 4;
    private float _elapsedTime = 0;

    private void Start()
    {
        _coinPool = GetPool(_coinPool, _capacity, _name);
        _coinSpawnSettings = GetSettings(_coinSpawnSettings, _templates, _minSpawnTime, _maxSpawnTime, _minSpawnHeight, _maxSpawnHeight);
        foreach (var item in _templates)
        {
            _coinPool.Initialized(item);
        }
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        Spawn(GenerateSpawnTime(_minSpawnTime, _maxSpawnTime));
    }

    protected override void Spawn(float secondsBetweenSpawn)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit && (_elapsedTime > secondsBetweenSpawn))
        {
            if (_coinPool.TryGetObject(out GameObject prefab))
            {
                _elapsedTime = 0;
                Vector3 spawnPoint = new Vector3(transform.position.x, hit.transform.position.y + Random.Range(_minSpawnHeight, _maxSpawnHeight), transform.position.z);
                Vector2 overlapBox = new Vector2(_overlapBoxSize, _overlapBoxSize);
                Collider2D[] collidersInsideOverlapBox = new Collider2D[1];
                int numberOfCollidersFound = Physics2D.OverlapBoxNonAlloc(hit.point, overlapBox, 0, collidersInsideOverlapBox, _bannedLayerForSpawn);
                if (numberOfCollidersFound == 0)
                {
                    prefab.SetActive(true);
                    prefab.transform.position = spawnPoint;
                }
            }
        }
    }

    public void Reset()
    {
        _coinPool.ResetPool();
    }
}