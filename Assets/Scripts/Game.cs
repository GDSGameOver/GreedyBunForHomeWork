using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Movement _camera;
    [SerializeField] private GameOverMenu _gameOverMenu;
    [SerializeField] private PlayerCollisionHandler _endGameTrigger;

    private List<SpawnStrategy> _spawners = new List<SpawnStrategy>();
    private float _platformSpawnElapsedTime;
    private float _enemySpawnElapsedTime;
    private float _coinSpawnElapsedTime;

    private void OnEnable()
    {
        _endGameTrigger.GameEnded += Reset;
    }

    private void OnDisable()
    {
        _endGameTrigger.GameEnded -= Reset;
    }

    private void Start()
    {
        InitializeSpawners();
    }

    private void Update()
    {
        Spawn();
    }

    private void Reset()
    {
        _player.Reset();
        _camera.Reset();
        _gameOverMenu.Open();
        foreach (var spawner in _spawners)
        {
            spawner.Reset();
        }
    }

    private void Spawn()
    {
        _platformSpawnElapsedTime += Time.deltaTime;
        _enemySpawnElapsedTime += Time.deltaTime;
        _coinSpawnElapsedTime += Time.deltaTime;
        for (int i = 0; i < _spawners.Count; i++)
        {
            if (_spawners[i].TryGetComponent<PlatformSpawner>(out PlatformSpawner platformSpawner) == true)
            {
                platformSpawner.Spawn(Random.Range(platformSpawner.MinSpawnTime, platformSpawner.MaxSpawnTime), ref _platformSpawnElapsedTime);
            }
            else if (_spawners[i].TryGetComponent<EnemySpawner>(out EnemySpawner enemySpawner) == true)
            {
                enemySpawner.Spawn(Random.Range(enemySpawner.MinSpawnTime, enemySpawner.MaxSpawnTime), ref _enemySpawnElapsedTime);
            }
            else if (_spawners[i].TryGetComponent<CoinSpawner>(out CoinSpawner coinSpawner) == true)
            {
                coinSpawner.Spawn(Random.Range(coinSpawner.MinSpawnTime, coinSpawner.MaxSpawnTime), ref _coinSpawnElapsedTime);
            }
        }
    }

    private void InitializeSpawners()
    {
        PlatformSpawner _platformSpawner = FindObjectOfType<PlatformSpawner>();
        EnemySpawner _enemySpawner = FindObjectOfType<EnemySpawner>();
        CoinSpawner _coinSpawner = FindObjectOfType<CoinSpawner>();
        _spawners.Add(_platformSpawner);
        _spawners.Add(_enemySpawner);
        _spawners.Add(_coinSpawner);
        for (int i = 0; i < _spawners.Count; i++)
        {
            _spawners[i].Initialized();
        }
    }
}
