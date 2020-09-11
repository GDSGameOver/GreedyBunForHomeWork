using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSettings : MonoBehaviour
{
    [SerializeField] private List<GameObject> _templates;
    [SerializeField] private float _minSpawnTime;
    [SerializeField] private float _maxSpawnTime;
    [SerializeField] private float _minSpawnHeight;
    [SerializeField] private float _maxSpawnHeight;

    public float GetMinSpawnTime()
    {
        return _minSpawnTime;
    }

    public float GetMaxSpawnTime()
    {
        return _maxSpawnTime;
    }

    public float GetMinSpawnHeight()
    {
        return _minSpawnHeight;
    }

    public float GetMaxSpawnHeight()
    {
        return _maxSpawnHeight;
    }
    public List<GameObject> GetTemplates()
    {
        return _templates;
    }

}
