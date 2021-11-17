using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GridObject[] _templates;
    [SerializeField] private Platform _startPlatform;
    [SerializeField] private float _viewRadius;
    [SerializeField] private float _cellSize;

    private HashSet<Vector2Int> _collisionsMatrix = new HashSet<Vector2Int>();
    private List<GridObject> _pool = new List<GridObject>();

    private void Start()
    {
        InitializePool();
    }

    private void Update()
    {
        FillRadius(transform.position, _viewRadius);
    }

    private void FillRadius(Vector2 center, float viewRadius)
    {
        var cellCountOnAxis = (int)(viewRadius / _cellSize);
        var fillAreaCenter = WorldToGridPosition(center);

        for (int x = -cellCountOnAxis; x < cellCountOnAxis; x++)
        {
                TryCreateRandomObjectOnLayer(GridLayer.Ground, fillAreaCenter + new Vector2Int(x, 0), _pool);
                TryCreateRandomObjectOnLayer(GridLayer.OnGround, fillAreaCenter + new Vector2Int(x, 0), _pool);
        }
    }

    private void TryCreateRandomObjectOnLayer(GridLayer layer, Vector2Int gridPosition, List<GridObject> pool)
    {
        gridPosition.y = (int)layer;

        if (_collisionsMatrix.Contains(gridPosition))
            return;
        else
            _collisionsMatrix.Add(gridPosition);

        var template = GetRandomTemplate(layer, pool);

        if (template == null)
            return;

        var position = GridToWorldPosition(gridPosition);

        template.transform.position = position;
        template.gameObject.SetActive(true);
    }

    private GridObject GetRandomTemplate(GridLayer layer, List<GridObject> pool)
    {
        var disableTemplates = pool.Where(template => template.Layer == layer && template.isActiveAndEnabled == false);

        if (disableTemplates.Count() == 1)
            return disableTemplates.First();

        foreach (var template in disableTemplates)
        {
            float chanceToSpawn = Random.Range(0.1f, 100);
            if (template.Chance >= chanceToSpawn)
            {
                return template;
            }
        }
        return null;
    }

    private void InitializePool()
    {
        for (int i = 0; i < _templates.Length; i++)
        {
            for (int y = 0; y < _templates[i].AmountInPool; y++)
            {
                GridObject spawned = Instantiate(_templates[i]);
                spawned.gameObject.SetActive(false);
                _pool.Add(spawned);
            }
        }
    }

    public void Reset()
    {
        _collisionsMatrix = new HashSet<Vector2Int>();
        _startPlatform.gameObject.SetActive(true);
        foreach (var template in _pool)
        {
            template.gameObject.SetActive(false);
        }
    }

    private Vector2 GridToWorldPosition(Vector2Int gridPosition)
    {
        return new Vector2(
            gridPosition.x * _cellSize,
            gridPosition.y * _cellSize);
          //  gridPosition.z * _cellSize);
    }

    private Vector2Int WorldToGridPosition(Vector2 worldPosition)
    {
        return new Vector2Int(
            (int)(worldPosition.x / _cellSize),
            (int)(worldPosition.y / _cellSize));
           // (int)(worldPosition.z / _cellSize));
    }
}
