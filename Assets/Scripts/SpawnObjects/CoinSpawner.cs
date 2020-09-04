using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : Spawner
{
    [SerializeField] private List<GameObject> _templates;

    private void Start()
    {
        foreach (var item in _templates)
        {
            Initialized(item);
        }
    }

    private void Update()
    {
        Spawn(GenerateSpawnTime(1, 3));
    }

    protected override void Spawn(float secondsBetweenSpawn)
    {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);

            Debug.DrawRay(transform.position, Vector2.down * 30, Color.red);

            if (hit && (_elapsedTime > secondsBetweenSpawn))
            {
                if (TryGetObject(out GameObject prefab))
                {
                    _elapsedTime = 0;

                    Vector3 spawnPoint = new Vector3(transform.position.x, hit.transform.position.y + Random.Range(1, 3), transform.position.z);
                    prefab.SetActive(true);
                    prefab.transform.position = spawnPoint;
                }
            }
    }
}
