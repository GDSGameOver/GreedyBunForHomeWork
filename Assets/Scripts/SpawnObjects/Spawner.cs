using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpawnSettings))]
public class Spawner : ObjectPool
{
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

    protected float GenerateSpawnTime(float minSpawnTime, float maxSpawnTime)
    {
        _elapsedTime += Time.deltaTime;
        float secondsBetweenSpawn = Random.Range(minSpawnTime, maxSpawnTime);
        return secondsBetweenSpawn;
    }

    protected void GetSpawnSettings(ref float  _minSpawnTime, ref float _maxSpawnTime, ref List<GameObject> _templates)
    {
        SpawnSettings spawnSettings = GetComponent<SpawnSettings>();
        _minSpawnTime = spawnSettings.GetMinSpawnTime();
        _maxSpawnTime = spawnSettings.GetMaxSpawnTime();
        _templates = spawnSettings.GetTemplates();
    }

    protected virtual void Spawn(float secondsBetweenSpawn)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);

        Debug.DrawRay(transform.position, Vector2.down * 30, Color.red);

        SpawnSettings spawnSettings = GetComponent<SpawnSettings>();

        if (hit && (_elapsedTime > secondsBetweenSpawn))
        {
            if (TryGetObject(out GameObject prefab))
            {
                _elapsedTime = 0;
      
                Vector3 spawnPoint = new Vector3(transform.position.x, hit.transform.position.y + Random.Range(spawnSettings.GetMinSpawnHeight(), spawnSettings.GetMaxSpawnHeight()), transform.position.z);
                prefab.SetActive(true);
                prefab.transform.position = spawnPoint;
            }
        }
    }

    
 }


