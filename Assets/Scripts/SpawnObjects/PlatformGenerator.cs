using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : ObjectPool
{
    [SerializeField] private List<GameObject> _templates;
    [SerializeField] private List<Transform> _platformSpawnPoints = new List<Transform>();
    [SerializeField] private Platform _startPlatform;

    private float _minSpawnTime = 1;
    private float _maxSpawnTime = 2.5f;

    private void Start()
    {
        foreach (var item in _templates)
        {
            Initialized(item);
        }
    }

    private void Update()
    {
        GenerateSpawnTime(_minSpawnTime, _maxSpawnTime, out float secondsBetweenSpawn);
        Spawn(secondsBetweenSpawn);
    }

    private void Spawn(float secondsBetweenSpawn)
    {
        CastGeneratingRay(out RaycastHit2D hit);

        if ((!hit) && (_elapsedTime > secondsBetweenSpawn))
        {
            ChangePositionOfGeneratingRay(5);

            if (TryGetObject(out GameObject platform))
            {
                _elapsedTime = 0;

                Vector3 spawnPoint = new Vector3(transform.position.x, _platformSpawnPoints[Random.Range(0, 2)].position.y, transform.position.z);

                platform.SetActive(true);

                platform.transform.position = spawnPoint;

                ChangePositionOfGeneratingRay(-5);
            }
        }
    }

    private void ChangePositionOfGeneratingRay(float amountOfChangeRayPosition)
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x += amountOfChangeRayPosition;
        transform.position = currentPosition;
    }

    public void ActivateStartPlatform()
    {
        _startPlatform.gameObject.SetActive(true);
    }
}
