using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : ObjectPool
{
    [SerializeField] private GameObject _template;

    private float _minSpawnTime = 1;
    private float _maxSpawnTime = 3;
    private float _minSpawnHeight = 1;
    private float _maxSpawnHeight = 3;

    private void Start()
    {
        Initialized(_template);
    }

    private void Update()
    {
        GenerateSpawnTime(_minSpawnTime, _maxSpawnTime, out float secondsBetweenSpawn);
        Spawn(_minSpawnHeight, _maxSpawnHeight, secondsBetweenSpawn);
    }
}
