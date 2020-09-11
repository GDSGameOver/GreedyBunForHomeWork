using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpawnSettings))]
public class PlatformSpawner : Spawner
{
    [SerializeField] private List<Transform> _platformSpawnPoints = new List<Transform>();
    [SerializeField] private Platform _startPlatform;
    [SerializeField] private float _amountOfChangeSpawnerPosition = 5;
    private List<GameObject> _templates;
    private float _minSpawnTime;
    private float _maxSpawnTime;

    private void Start()
    {
        GetSpawnSettings(ref _minSpawnTime, ref _maxSpawnTime, ref _templates);

        foreach (var item in _templates)
        {
            Initialized(item);
        }
    }

    private void Update()
    {
        Spawn(GenerateSpawnTime(_minSpawnTime, _maxSpawnTime));
    }

    protected override void Spawn(float secondsBetweenSpawn)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);

        Debug.DrawRay(transform.position, Vector2.down * 30, Color.red);

        if ((!hit) && (_elapsedTime > secondsBetweenSpawn))
        {
            ChangePositionOfSpawner(_amountOfChangeSpawnerPosition);

            if (TryGetObject(out GameObject platform))
            {
                _elapsedTime = 0;

                Vector3 spawnPoint = new Vector3(transform.position.x, _platformSpawnPoints[Random.Range(0, 2)].position.y, transform.position.z);

                platform.SetActive(true);

                platform.transform.position = spawnPoint;

                ChangePositionOfSpawner(-_amountOfChangeSpawnerPosition);
            }
        }
    }

    private void ChangePositionOfSpawner(float amountOfChangeSpawnerPosition)
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x += amountOfChangeSpawnerPosition;
        transform.position = currentPosition;
    }

    public void ActivateStartPlatform()
    {
        _startPlatform.gameObject.SetActive(true);
    }
}
