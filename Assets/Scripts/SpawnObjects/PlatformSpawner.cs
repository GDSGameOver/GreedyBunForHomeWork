using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : SpawnStrategy
{
    [SerializeField] private List<Transform> _platformSpawnPoints = new List<Transform>();
    [SerializeField] private Platform _startPlatform;
    [SerializeField] private List<GameObject> _templates;

    private float _distanceBetweenPlatforms = 3;
    private ObjectPool _platformPool;
    private Vector3 _startPosition = new Vector3(-12, 6, 0);

    public override void Spawn(float secondsBetweenSpawn, ref float elapsedTime)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if ((!hit) && (elapsedTime > secondsBetweenSpawn))
        {
            MoveToNextSpawnPosition(_distanceBetweenPlatforms);

            if (_platformPool.TryGetObject(out GameObject platform))
            {
                Vector3 spawnPoint = new Vector3(transform.position.x, _platformSpawnPoints[Random.Range(0, 2)].position.y, transform.position.z);
                platform.SetActive(true);
                platform.transform.position = spawnPoint;
                elapsedTime = 0;
            }
        }
    }

    private void MoveToNextSpawnPosition(float distanceBetweenPlatforms)
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x += distanceBetweenPlatforms;
        transform.position = currentPosition;
    }

    public override void Reset()
    {
        _startPlatform.gameObject.SetActive(true);
        _platformPool.ResetPool();
        transform.localPosition = _startPosition;
    }

    public override void Initialized()
    {
        MinSpawnTime = 1;
        MaxSpawnTime = 1;
        MinSpawnHeight = 0;
        MaxSpawnHeight = 0;
        Templates = _templates;
        Capacity = 6;
        Name = "PlatformPool";
        _platformPool = GetPool(_platformPool, Capacity, Name);
        foreach (var item in Templates)
        {
            _platformPool.Initialized(item);
        }
    }
}