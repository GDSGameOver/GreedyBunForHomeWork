using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class PlayerCollisionHandler : MonoBehaviour
{
    private Player _player;

    public event UnityAction GameEnded;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _player.PickUpCoin();
        }

        if (collision.TryGetComponent(out Enemy enemy)) 
        {
            _player.PlayerDie();
            GameEnded?.Invoke();
        }
    }
}