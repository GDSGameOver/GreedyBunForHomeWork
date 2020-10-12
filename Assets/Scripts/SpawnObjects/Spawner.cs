using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private List<SpawnStrategy> _spawnStrategies = new List<SpawnStrategy>();
    private float _platformSpawnElapsedTime;
    private float _enemySpawnElapsedTime;
    private float _coinSpawnElapsedTime;

    private void Start()
    {
        InitializeSpawners();
    }

    private void Update()
    {
        Spawn();
    }

    private void Spawn()
    {
        _platformSpawnElapsedTime += Time.deltaTime;
        _enemySpawnElapsedTime += Time.deltaTime;
        _coinSpawnElapsedTime += Time.deltaTime;
        for (int i = 0; i < _spawnStrategies.Count; i++)
        {
            if (_spawnStrategies[i].TryGetComponent<PlatformSpawnStrategy>(out PlatformSpawnStrategy platformSpawner) == true)
            {
                platformSpawner.Spawn(Random.Range(platformSpawner.MinSpawnTime, platformSpawner.MaxSpawnTime), ref _platformSpawnElapsedTime);
            }
            else if (_spawnStrategies[i].TryGetComponent<EnemySpawnStrategy>(out EnemySpawnStrategy enemySpawner) == true)
            {
                enemySpawner.Spawn(Random.Range(enemySpawner.MinSpawnTime, enemySpawner.MaxSpawnTime), ref _enemySpawnElapsedTime);
            }
            else if (_spawnStrategies[i].TryGetComponent<CoinSpawnStrategy>(out CoinSpawnStrategy coinSpawner) == true)
            {
                coinSpawner.Spawn(Random.Range(coinSpawner.MinSpawnTime, coinSpawner.MaxSpawnTime), ref _coinSpawnElapsedTime);
            }
        }
    }

    private void InitializeSpawners()
    {
        PlatformSpawnStrategy _platformSpawner = FindObjectOfType<PlatformSpawnStrategy>();
        EnemySpawnStrategy _enemySpawner = FindObjectOfType<EnemySpawnStrategy>();
        CoinSpawnStrategy _coinSpawner = FindObjectOfType<CoinSpawnStrategy>();
        _spawnStrategies.Add(_platformSpawner);
        _spawnStrategies.Add(_enemySpawner);
        _spawnStrategies.Add(_coinSpawner);
        for (int i = 0; i < _spawnStrategies.Count; i++)
        {
            _spawnStrategies[i].Initialized();
        }
    }

    public void Reset()
    {
        foreach (var spawner in _spawnStrategies)
        {
            spawner.Reset();
        }
    }
}
