using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSettings : MonoBehaviour
{
    private List<GameObject> _templates;
    private float _minSpawnTime;
    private float _maxSpawnTime;
    private float _minSpawnHeight;
    private float _maxSpawnHeight;

    public SpawnSettings GetSettings(List<GameObject> templates, float minSpawnTime, float maxSpawnTime, float minSpawnHeight, float maxSpawnHeight)
    {
        SpawnSettings spawnSettings = new SpawnSettings();
        spawnSettings._minSpawnTime = minSpawnTime;
        spawnSettings._maxSpawnTime = maxSpawnTime;
        spawnSettings._minSpawnHeight = minSpawnHeight;
        spawnSettings._maxSpawnHeight = maxSpawnHeight;
        spawnSettings._templates = templates;
        return spawnSettings;
    }
}
