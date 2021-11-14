using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Platform _startPlatform;
    [SerializeField] private Template[] _templates;

    private List<Template> _pool = new List<Template>();


    private void Start()
    {
        InitializePool();
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        TryToSpawn(Layer.Ground, _pool, hit);
        TryToSpawn(Layer.OnGround, _pool, hit);
    }

    private void InitializePool()
    {
        for (int i = 0; i < _templates.Length; i++)
        {
            for (int y = 0; y < _templates[i].AmountInPool; y++)
            {
                Template spawned = Instantiate(_templates[i]); 
                spawned.gameObject.SetActive(false);
                _pool.Add(spawned);
            }
        }
    }

    private void TryToSpawn(Layer layer, List<Template> pool, RaycastHit2D hit)
    {
        Template template = GetRandomTemplate(layer, pool);
        bool spawnAreaFree = CheckSpawnArea(template, hit);
        if (spawnAreaFree)
        {
            Spawn(template, hit);
        }
    }

    private Template GetRandomTemplate(Layer layer, List<Template> pool)
    {
        var disableTemplates = pool.Where(template => template.Layer  == layer && template.isActiveAndEnabled == false);

        if (disableTemplates.Count() == 1)
            return disableTemplates.First();

        foreach (var template in disableTemplates)
        {
            float chanceToSpawn = Random.Range(0.1f, 100);
            if (template.ChanceToSpawn >= chanceToSpawn)
            {
                return template;
            }
        }
        return null;
    }

    private bool CheckSpawnArea(Template template, RaycastHit2D hit)
    {
        Collider2D[] collisionedColliders = new Collider2D[1];
        Vector2 centerOfArea = hit.point;
        float angleOfArea = 360;
        bool spawnAreaFree = Physics2D.OverlapBoxNonAlloc(centerOfArea, template.OverlapArea, angleOfArea, collisionedColliders, template.BannedLayersForSpawn) < 1;
        return spawnAreaFree;
    }

    private void Spawn(Template template, RaycastHit2D hit)
    {
        template.transform.position = new Vector2(hit.point.x + template.OffsetPositions[Random.Range(0, template.OffsetPositions.Count)].x, hit.point.y + template.OffsetPositions[Random.Range(0, template.OffsetPositions.Count)].y);
        template.gameObject.SetActive(true);
    }

    public void Reset()
    {
        _startPlatform.gameObject.SetActive(true);
        foreach (var template in _pool)
        {
            template.gameObject.SetActive(false);
        }
    }
}
