using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pool = new List<GameObject>();

    public void Initialized(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }

    public bool TryGetObject(out GameObject result)
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

    public ObjectPool GetPool(int capacity, GameObject container, string name)
    {
        ObjectPool objectPool = new ObjectPool();
        objectPool._capacity = capacity;
        objectPool._container = container;
        objectPool._container.name = name;
        return objectPool;
    }

    public void ResetPool()
    {
        foreach (var item in _pool)
        {
            item.SetActive(false);
        }
    }
}