using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class Template : MonoBehaviour
{
    [SerializeField] private float _chanceToSpawn;
    [SerializeField] private int _amountInPool;
    [SerializeField] private Vector2 _overlapArea;
    [SerializeField] private List<Vector3> _offsetPositions;
    [SerializeField] private Layer _layer;
    [SerializeField] private LayerMask _bannedLayersForSpawn;

    public float ChanceToSpawn => _chanceToSpawn;
    public int AmountInPool => _amountInPool;
    public Vector2 OverlapArea => _overlapArea;
    public List<Vector3> OffsetPositions => _offsetPositions;
    public Layer Layer => _layer;
    public LayerMask BannedLayersForSpawn => _bannedLayersForSpawn;
}
