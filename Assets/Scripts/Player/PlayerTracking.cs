using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracking : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Vector3 _playerLastPosition;
    private float _distanseToMove;

    private void Start()
    {
        _playerLastPosition = _player.transform.position;
    }

    private void Update()
    {
        _distanseToMove = _player.transform.position.x - _playerLastPosition.x;
        transform.position = new Vector3(transform.position.x + _distanseToMove, transform.position.y, transform.position.z);
        _playerLastPosition = _player.transform.position;
    }
}
