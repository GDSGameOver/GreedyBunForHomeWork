using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject : MonoBehaviour
{
    [SerializeField] private GridLayer _layer;
    [SerializeField] private float _chance;
    [SerializeField] private int _amountInPool;

    public GridLayer Layer => _layer;
    public float Chance => _chance;
    public int AmountInPool => _amountInPool;
}
