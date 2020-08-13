using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : ObjectPool
{
    [SerializeField] private GameObject _template;
  
    
    private float _elapsedTime = 0;

    private void Start()
    {
            Initialized(_template);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);

        Debug.DrawRay(transform.position, Vector2.down * 30, Color.red);

        float _secondsBetweenSpawn = Random.Range(3, 6);
      
        if (hit && (_elapsedTime > _secondsBetweenSpawn))
        {
            if (TryGetObject(out GameObject enemy))
            {
                _elapsedTime = 0;
              
                Vector3 spawnPoint = new Vector3(transform.position.x, hit.transform.position.y+.5f, transform.position.z);
                enemy.SetActive(true);
                enemy.transform.position = spawnPoint;
            }
        }
        DisableObjectAbroadScreen();
    }
}
