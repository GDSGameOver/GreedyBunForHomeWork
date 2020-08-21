using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : ObjectPool
{
    [SerializeField] private GameObject _template;
  
    private float _minSpawnTime = 3;
    private float _maxSpawnTime = 6;
    private float _minSpawnHeight = .5f;
    private float _maxSpawnHeight = .5f;

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
