using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : ObjectPool
{
    [SerializeField] private List<GameObject> _templates;
  
    [SerializeField] private List<Transform> _platformSpawnPoints = new List<Transform>();
  

    private float _elapsedTime = 0;

    private void Start()
    {
        foreach (var item in _templates)
        {
            Initialized(item);
        }

    }

    private void Update()
    {
       
        _elapsedTime += Time.deltaTime;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);

        Debug.DrawRay(transform.position, Vector2.down*30, Color.red);

        float _secondsBetweenSpawn = Random.Range(1, 2.5f);


        if ((!hit) && (_elapsedTime > _secondsBetweenSpawn))
        {
            Vector3 currentPosition = transform.position;
            currentPosition.x += 5;
            transform.position = currentPosition;
            if (TryGetObject(out GameObject platform))
            {
                _elapsedTime = 0;

                Vector3 spawnPoint = new Vector3(transform.position.x, _platformSpawnPoints[Random.Range(0,2)].position.y, transform.position.z);
                
                platform.SetActive(true);
                
                platform.transform.position = spawnPoint;
                currentPosition = transform.position;
                currentPosition.x -= 5;
                transform.position = currentPosition;
            }
        }
        DisableObjectAbroadScreen();
    }
}
