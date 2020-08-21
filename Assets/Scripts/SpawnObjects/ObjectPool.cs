using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;
    

    public float MinSpawnTime { get; protected set; }
    public float MaxSpawnTime { get; protected set; }
    public float MinSpawnHeight { get; protected set; }
    public float MaxSpawnHeight { get; protected set; }

    protected float _elapsedTime = 0;
    private Camera _camera;
    private List<GameObject> _pool = new List<GameObject>();


    protected void Initialized(GameObject prefab)
    {
        _camera = Camera.main;

        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        List<int> numbersOfDisablePrefabs = new List<int>();
        for (int i = 0; i < _pool.Count; i++)
        {
            if (_pool[i].activeSelf == false)
            {
                numbersOfDisablePrefabs.Add(i);
            }
        }
        result = _pool[numbersOfDisablePrefabs[Random.Range(0, numbersOfDisablePrefabs.Count)]];
        return result != null;
    }

    public void ResetPool()
    {
        foreach (var item in _pool)
        {
            item.SetActive(false);
        }
    }

    protected void GenerateSpawnTime(float minSpawnTime, float maxSpawnTime,  out float secondsBetweenSpawn)
    {
        _elapsedTime += Time.deltaTime;
        float secondsBetweenSpawnContainer = Random.Range(minSpawnTime, maxSpawnTime);
        secondsBetweenSpawn = secondsBetweenSpawnContainer;
    }

    protected void Spawn(float minSpawnHeight, float maxSpawnHeight, float secondsBetweenSpawn)
    {
        CastGeneratingRay(out RaycastHit2D hit); 

        if (hit && (_elapsedTime > secondsBetweenSpawn))
        {
            if (TryGetObject(out GameObject prefab))
            {
                _elapsedTime = 0;

                Vector3 spawnPoint = new Vector3(transform.position.x, hit.transform.position.y + Random.Range(minSpawnHeight, maxSpawnHeight), transform.position.z);
                prefab.SetActive(true);
                prefab.transform.position = spawnPoint;
            }
        }
    }

    protected void CastGeneratingRay(out RaycastHit2D hit)
    {
        RaycastHit2D hitContainer = Physics2D.Raycast(transform.position, Vector2.down);

        Debug.DrawRay(transform.position, Vector2.down * 30, Color.red);

        hit = hitContainer;
    }
}
