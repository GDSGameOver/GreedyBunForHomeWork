using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : SpawnStrategy
{
    [SerializeField] private List<Transform> _platformSpawnPoints = new List<Transform>();
    [SerializeField] private Platform _startPlatform;
    [SerializeField] private float _distanceBetweenPlatforms = 5;
    [SerializeField] private List<GameObject> _templates;

    private SpawnSettings _platformSpawnSettings;
    private ObjectPool _platformPool;
    private Vector3 _startPosition = new Vector3(-12, 6, 0);
    private float _minSpawnTime = 1;
    private float _maxSpawnTime = 2;
    private float _minSpawnHeight = 0;
    private float _maxSpawnHeight = 0;
    private float _elapsedTime = 0;
    private string _name = "PlatformPool";
    private int _capacity = 6;

    private void Start()
    {
        _platformPool = GetPool(_platformPool, _capacity, _name);
        _platformSpawnSettings = GetSettings(_platformSpawnSettings, _templates, _minSpawnTime, _maxSpawnTime, _minSpawnHeight, _maxSpawnHeight);
        foreach (var item in _templates)
        {
            _platformPool.Initialized(item);
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
        if ((!hit) && (_elapsedTime > secondsBetweenSpawn))
        {
            MoveToNextSpawnPosition(_distanceBetweenPlatforms);

            if (_platformPool.TryGetObject(out GameObject platform))
            {
                _elapsedTime = 0;
                Vector3 spawnPoint = new Vector3(transform.position.x, _platformSpawnPoints[Random.Range(0, 2)].position.y, transform.position.z);
                platform.SetActive(true);
                platform.transform.position = spawnPoint;
            }
        }
    }

    private void MoveToNextSpawnPosition(float amountOfChangeSpawnerPosition)
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x += amountOfChangeSpawnerPosition;
        transform.position = currentPosition;
    }

    public void Reset()
    {
        _startPlatform.gameObject.SetActive(true);
        _platformPool.ResetPool();
        transform.localPosition = _startPosition;
    }
}