using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : SpawnStrategy
{
    [SerializeField] private List<GameObject> _templates;

    private ObjectPool _enemyPool;
    private SpawnSettings _enemySpawnSettings;
    private string _name = "EnemiesPool";
    private int _capacity = 6;
    private float _minSpawnTime = 3;
    private float _maxSpawnTime = 6;
    private float _minSpawnHeight = 0;
    private float _maxSpawnHeight = 0;
    private float _elapsedTime = 0;

    private void Start()
    {
        _enemyPool = GetPool(_enemyPool, _capacity, _name);
        _enemySpawnSettings = GetSettings(_enemySpawnSettings, _templates, _minSpawnTime, _maxSpawnTime, _minSpawnHeight, _maxSpawnHeight);
        foreach (var item in _templates)
        {
            _enemyPool.Initialized(item); 
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
            if (_enemyPool.TryGetObject(out GameObject prefab))
            {
                _elapsedTime = 0;
                Vector3 spawnPoint = new Vector3(transform.position.x, hit.transform.position.y + Random.Range(_minSpawnHeight, _maxSpawnHeight), transform.position.z);
                prefab.SetActive(true);
                prefab.transform.position = spawnPoint;
            }
        }
    }

    public void Reset()
    {
        _enemyPool.ResetPool();
    }
}
